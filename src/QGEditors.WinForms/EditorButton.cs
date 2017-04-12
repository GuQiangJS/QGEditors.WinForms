// QGEditor
// Copyright (c) 2014-2016 GuQiang - <guqiangjs@gmail.com>
// ALL RIGHTS RESERVED

#region

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using QGEditors.WinForms.Properties;

#endregion

namespace QGEditors.WinForms {
    /// <summary>
    ///     表示 <see cref="QGEditors.WinForms.ButtonEditControl" /> 控件或后代中显示的单个编辑器按钮。
    /// </summary>
    [ComVisible(false)]
    [ToolboxItem(false)]
    [DefaultProperty("Kind")]
    public class EditorButton : INotifyPropertyChanged, INotifyPropertyChanging {
        #region Classes

        private class ImageComparer : IEqualityComparer<Image> {
            #region Methods

            public bool Equals(Image x, Image y) {
                if (x == null && y == null)
                    return true;
                if (x == null || y == null)
                    return false;

                using (var ms1 = new MemoryStream()) {
                    using (var ms2 = new MemoryStream()) {
                        x.Save(ms1, ImageFormat.Bmp);
                        y.Save(ms2, ImageFormat.Bmp);
                        var im1 = ms1.GetBuffer();
                        var im2 = ms2.GetBuffer();
                        if (im1.Length != im2.Length)
                            return false;
                        for (var i = 0; i < im1.Length; i++)
                            if (im1[i] != im2[i])
                                return false;
                        return true;
                    }
                }
            }

            [SuppressMessage("Microsoft.Design", "CA1062:验证公共方法的参数", MessageId = "0")]
            public int GetHashCode(Image obj) {
                return obj.GetHashCode();
            }

            #endregion
        }

        #endregion

        #region Fields

        /// <summary>
        ///     默认的按钮绘图器
        /// </summary>
        private static readonly Graphics _defButtonGraphics;

        /// <summary>
        ///     标题
        /// </summary>
        private string _caption = "";

        /// <summary>
        ///     名称
        /// </summary>
        private string _name = "";

        /// <summary>
        ///     标题前景色
        /// </summary>
        private Color _captionColor = Control.DefaultForeColor;

        /// <summary>
        ///     标题字体
        /// </summary>
        private Font _captionFont = QGEditorControl.DefaultFont;

        /// <summary>
        ///     标题尺寸矩形大小（根据Caption属性计算）
        /// </summary>
        private SizeF _captionSize;

        /// <summary>
        ///     鼠标指针图像
        /// </summary>
        private Cursor _cursor = Cursors.Default;

        /// <summary>
        ///     默认宽度
        /// </summary>
        private readonly int _defaultWidth = 19;

        /// <summary>
        ///     是否可用
        /// </summary>
        private bool _enable = true;

        /// <summary>
        ///     图像
        /// </summary>
        private Image _image;

        /// <summary>
        ///     图像对齐方式
        /// </summary>
        private ContentAlignment _imageAlign = ContentAlignment.MiddleCenter;

        /// <summary>
        ///     图像相等比较器
        /// </summary>
        private readonly ImageComparer _imageComparer = new ImageComparer();

        /// <summary>
        ///     按钮是否放在左侧
        /// </summary>
        private bool _isLeft;

        /// <summary>
        ///     按钮类型
        /// </summary>
        private ButtonPredefines _kind = ButtonPredefines.Elipsis;

        private Image[] _presetImages;

        private Image[] presetImages {
            get {
                if (_presetImages == null || _presetImages.Length <= 0) {
                    var i = new Queue<Image>();
                    var images = Enum.GetNames(typeof(ButtonPredefines));
                    foreach (var image in images) {
                        var obj = Resources.ResourceManager.GetObject(image, Resources.Culture);
                        Image im = (Bitmap) obj;
                        if (im != null)
                            i.Enqueue(im);
                    }
                    _presetImages = i.ToArray();
                }
                return _presetImages;
            }
        }

        private string _tooltip = "";
        private bool _visible = true;
        private int _width = 19;

        #endregion

        #region Constructors

        [SuppressMessage("Microsoft.Performance", "CA1810:InitializeReferenceTypeStaticFieldsInline")]
        static EditorButton() {
            Button btn = null;
            try {
                btn = new Button();
                _defButtonGraphics = btn.CreateGraphics();
            }
            finally {
                btn.Dispose();
                btn = null;
            }
        }

        /// <summary>
        ///     初始化 <see cref="QGEditors.WinForms.EditorButton" />  类的新实例。
        /// </summary>
        public EditorButton() {
        }

        /// <summary>
        ///     使用预置的按钮类型，初始化 <see cref="QGEditors.WinForms.EditorButton" />  类的新实例。
        /// </summary>
        /// <param name="kind">预置的按钮类型</param>
        public EditorButton(ButtonPredefines kind)
            : this() {
            SetKind(kind);
        }

        #endregion

        #region Events

        /// <summary>
        ///     在某一属性值已更改时发生。
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        ///     在某个属性值将更改时发生。
        /// </summary>
        public event PropertyChangingEventHandler PropertyChanging;

        #endregion

        #region Properties

        /// <summary>
        ///     获取或设置与当前按钮关联的文本。
        /// </summary>
        /// <remarks>
        ///     <see cref="EditorButton.Width" />会根据文本长度变化。
        /// </remarks>
        /// <value>
        ///     与此编辑器按钮关联的文本。
        /// </value>
        [DefaultValue("")]
        [Localizable(true)]
        public virtual string Caption {
            get { return _caption; }
            set {
                if (!string.Equals(_caption, value) && RaisePropertyChanging("Caption")) {
                    var cap = Caption;
                    _caption = value;
                    _captionSize = value.GetTextSize(_defButtonGraphics, CaptionFont);
                    Width = _captionSize.Width.ToInt32();
                    RaisePropertyChanged("Caption", cap, value);
                }
            }
        }

        [DefaultValue("")]
        [Localizable(true)]
        public virtual string Name {
            get { return _name; }
            set {
                if (!string.Equals(_name, value) && RaisePropertyChanging("Name")) {
                    var name = Name;
                    _name = value;
                    RaisePropertyChanged("Name", name, value);
                }
            }
        }

        /// <summary>
        ///     获取或设置与当前按钮关联的文本的字体。
        /// </summary>
        /// <value>
        ///     要应用于由控件显示的文本的 <see cref="Font" />。默认为 <see cref="QGEditorControl.DefaultFont" /> 属性的值。
        /// </value>
        [Localizable(true)]
        public virtual Font CaptionFont {
            get { return _captionFont; }
            set {
                if (!Equals(_captionFont, value) && RaisePropertyChanging("CaptionFont")) {
                    var capFont = CaptionFont;
                    _captionFont = value;
                    RaisePropertyChanged("CaptionFont", capFont, value);
                }
            }
        }

        /// <summary>
        ///     获取或设置当鼠标指针位于当前按钮上时显示的光标。
        /// </summary>
        /// <value>
        ///     一个 <see cref="System.Windows.Forms.Cursor" />，表示当鼠标指针位于控件上时显示的光标。
        ///     默认值 <see cref="Cursors.Default" />
        /// </value>
        [DefaultValue(typeof(Cursor), "Default")]
        [Localizable(true)]
        public virtual Cursor Cursor {
            get { return _cursor; }
            set {
                if (_cursor != value && RaisePropertyChanging("Cursor")) {
                    var cur = Cursor;
                    _cursor = value;
                    RaisePropertyChanged("Cursor", cur, value);
                }
            }
        }

        /// <summary>
        ///     获取或设置一个值，该值指示当前按钮是否可以对用户交互作出响应。
        /// </summary>
        /// <value>
        ///     如果控件可以对用户交互作出响应，则为 <c>true</c>；否则为 <c>false</c>。 默认值为 <c>true</c>。
        /// </value>
        [DefaultValue(true)]
        [Localizable(true)]
        public virtual bool Enabled {
            get { return _enable; }
            set {
                if (!Equals(_enable, value) && RaisePropertyChanging("Enabled")) {
                    var enable = Enabled;
                    _enable = value;
                    RaisePropertyChanged("Enabled", enable, value);
                }
            }
        }

        /// <summary>
        ///     获取或设置显示在当前按钮上的图像。
        /// </summary>
        /// <remarks>
        ///     如果 <see cref="System.Drawing.Image" /> 不存在于 <see cref="ButtonPredefines" /> 提供的预设集合中
        ///     ，则 <see cref="EditorButton.Kind" /> 属性会被置为 <see cref="ButtonPredefines.Glyph" />。
        /// </remarks>
        /// <value>
        ///     默认值为 <c>null</c>。
        /// </value>
        [DefaultValue(null)]
        [Localizable(true)]
        public virtual Image Image {
            get { return _image; }
            set {
                if (_image != value && RaisePropertyChanging("Image")) {
                    var img = Image;
                    _image = value;
                    RaisePropertyChanged("Image", img, value);
                    if (!presetImages.Contains(value, _imageComparer))
                        _kind = ButtonPredefines.Glyph;
                }
            }
        }

        /// <summary>
        ///     获取或设置当前按钮上的图像对齐方式。
        /// </summary>
        /// <value>
        ///     <see cref="System.Drawing.ContentAlignment" /> 值之一。 默认值为 <see cref="ContentAlignment.MiddleCenter" />。
        /// </value>
        [DefaultValue(32)]
        [Localizable(true)]
        public virtual ContentAlignment ImageAlign {
            get { return _imageAlign; }
            set {
                if (_imageAlign != value && RaisePropertyChanging("ImageAlign")) {
                    var align = ImageAlign;
                    _imageAlign = value;
                    RaisePropertyChanged("ImageAlign", align, value);
                }
            }
        }

        /// <summary>
        ///     获取或设置当前按钮的位置。
        /// </summary>
        /// <value>
        ///     如果为 <c>true</c> 那么编辑器按钮会从父级控件的左侧开始绘制，反之则从从父级控件的右侧开始绘制。
        ///     默认值为 <c>false</c>。
        /// </value>
        [DefaultValue(false)]
        [Localizable(true)]
        public virtual bool IsLeft {
            get { return _isLeft; }
            set {
                if (!Equals(_isLeft, value) && RaisePropertyChanging("IsLeft")) {
                    var isLeft = IsLeft;
                    _isLeft = value;
                    RaisePropertyChanged("IsLeft", isLeft, value);
                }
            }
        }

        /// <summary>
        ///     获取或设置要在当前按钮中预设的图像类型。
        /// </summary>
        /// <remarks>
        ///     默认为 <see cref="ButtonPredefines.Elipsis" /> 。
        ///     修改为 <see cref="ButtonPredefines.Glyph" /> 后会根据 <see cref="EditorButton.Image" /> 属性和
        ///     <see cref="EditorButton.Caption" /> 属性显示内容。
        /// </remarks>
        [DefaultValue(7)]
        [Localizable(true)]
        public virtual ButtonPredefines Kind {
            get { return _kind; }
            set {
                if (Kind != value && RaisePropertyChanging("Kind")) {
                    var kind = Kind;
                    _kind = value;
                    RaisePropertyChanged("Kind", kind, value);
                }
            }
        }

        /// <summary>
        ///     获取或设置用于激活当前按钮功能的快捷方式。
        /// </summary>
        /// <remarks>
        ///     <see cref="TextBoxBase.ShortcutsEnabled" /> 属性指示该快捷方式是否可用。
        /// </remarks>
        /// <value>默认值 <see cref="Keys.None" /> 。</value>
        [DefaultValue(0)]
        [Localizable(true)]
        public virtual Keys ShortcutKeys { get; set; }

        /// <summary>
        ///     获取或设置为在此元素显示的工具提示对象 用户界面 (UI)。
        /// </summary>
        [DefaultValue("")]
        [Localizable(true)]
        public virtual string ToolTip {
            get { return _tooltip; }
            set {
                if (!string.Equals(_tooltip, value) && RaisePropertyChanging("ToolTip")) {
                    var tip = ToolTip;
                    _tooltip = value;
                    RaisePropertyChanged("ToolTip", tip, value);
                }
            }
        }

        /// <summary>
        ///     获取或设置一个值，该值指示是否显示当前按钮。
        /// </summary>
        /// <value>默认值 <c>true</c> 。</value>
        [DefaultValue(true)]
        [Localizable(true)]
        public virtual bool Visible {
            get { return _visible; }
            set {
                if (!Equals(_visible, value) && RaisePropertyChanging("Visible")) {
                    var visible = Visible;
                    _visible = value;
                    RaisePropertyChanged("Visible", visible, value);
                }
            }
        }

        /// <summary>
        ///     获取或设置当前按钮的宽度。
        /// </summary>
        /// <value>默认值 19 。</value>
        [DefaultValue(19)]
        [Localizable(true)]
        public virtual int Width {
            get { return _width; }
            set {
                var v = _defaultWidth;
                if (Kind == ButtonPredefines.Glyph && Image == null)
                    if (CaptionSizeF != SizeF.Empty)
                        v = CaptionSize.Width;
                v = v > value ? v : value;

                if (!Equals(_width, v) && RaisePropertyChanging("Width")) {
                    var width = Width;
                    _width = v;
                    RaisePropertyChanged("Width", width, v);
                }
            }
        }

        /// <summary>
        ///     获取或设置与当前按钮关联的文本的前景色。
        /// </summary>
        /// <value>
        ///     要应用于由控件显示的文本的 <see cref="Color" />。默认为 <see cref="Control.DefaultForeColor" /> 属性的值。
        /// </value>
        public Color CaptionColor {
            get { return _captionColor; }
            set {
                if (!Equals(_captionColor, value) && RaisePropertyChanging("CaptionColor")) {
                    var capColor = CaptionColor;
                    _captionColor = value;
                    RaisePropertyChanged("CaptionColor", capColor, value);
                }
            }
        }

        /// <summary>
        ///     获取与当前按钮关联的文本的大小。
        /// </summary>
        public SizeF CaptionSizeF {
            get { return _captionSize; }
        }

        /// <summary>
        ///     获取与当前按钮关联的文本的大小。
        /// </summary>
        public Size CaptionSize {
            get { return Size.Ceiling(CaptionSizeF); }
        }

        #endregion

        #region Methods

        /// <summary>
        ///     返回的字符串表示形式 <see cref="EditorButton" /> 对象。
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            return ObjectHelper.GetObjectText(this);
        }

        [SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate")]
        protected internal virtual void RaisePropertyChanged<T>(string propertyName, T oldValue, T newValue) {
            if (PropertyChanged != null) {
                var e = new PropertyChangedEventArgsEx(propertyName, oldValue, newValue);
                PropertyChanged(this, e);
            }
        }

        [SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate")]
        protected internal virtual bool RaisePropertyChanging(string propertyName) {
            if (PropertyChanging != null) {
                var e = new PropertyChangingEventArgsEx(propertyName);
                PropertyChanging(this, e);
                return !e.Cancel;
            }
            return true;
        }

        protected void ResetCaptionColor() {
            CaptionColor = Control.DefaultForeColor;
        }

        protected bool ShouldSerializeCaptionColor() {
            return CaptionColor != Control.DefaultForeColor;
        }

        protected void ResetCaptionFont() {
            CaptionFont = QGEditorControl.DefaultFont;
        }

        protected bool ShouldSerializeCaptionFont() {
            return CaptionFont != QGEditorControl.DefaultFont;
        }

        private void SetKind(ButtonPredefines kind) {
            _kind = kind;
            _image = kind.GetImage();
        }

        #endregion
    }
}