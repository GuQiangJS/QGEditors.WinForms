/*
 *  QGEditor
 *  Copyright (c) 2014-2016 GuQiang - <guqiangjs@gmail.com>
 *  ALL RIGHTS RESERVED
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using QGEditors.WinForms.Properties;

namespace QGEditors.WinForms
{
    /// <summary>
    /// 表示 <see cref="QGEditors.WinForms.ButtonTextBoxControl"/> 控件或后代中显示的单个编辑器按钮。
    /// </summary>
    [ComVisible(false)]
    [ToolboxItem(false)]
    [DefaultProperty("Kind")]
    public class EditorButton : INotifyPropertyChanged, INotifyPropertyChanging
    {
        #region Fields

        /// <summary>
        /// 默认的按钮字体
        /// </summary>
        private static Font _defButtonFont;
        /// <summary>
        /// 默认的按钮绘图器
        /// </summary>
        private static Graphics _defButtonGraphics;
        /// <summary>
        /// 标题
        /// </summary>
        private string _caption = "";
        /// <summary>
        /// 标题尺寸矩形大小（根据Caption属性计算）
        /// </summary>
        private SizeF _captionSize;
        /// <summary>
        /// 鼠标指针图像
        /// </summary>
        private Cursor _cursor = Cursors.Default;
        /// <summary>
        /// 默认宽度
        /// </summary>
        private int _defaultWidth = 19;
        /// <summary>
        /// 是否可用
        /// </summary>
        private bool _enable = true;
        /// <summary>
        /// 图像
        /// </summary>
        private Image _image = null;
        /// <summary>
        /// 图像对其方式
        /// </summary>
        private ContentAlignment _imageAlign = ContentAlignment.MiddleCenter;
        /// <summary>
        /// 图像相等比较器
        /// </summary>
        private ImageComparer _imageComparer = new ImageComparer();
        /// <summary>
        /// 按钮是否放在左侧
        /// </summary>
        private bool _isLeft = false;
        /// <summary>
        /// 按钮类型
        /// </summary>
        private ButtonPredefines _kind = ButtonPredefines.Elipsis;

        private Image[] _presetImages ={Resources.Backward,Resources.Delete,Resources.Delete,Resources.Down,
                                      Resources.Edit,Resources.Elipsis,Resources.Favorite,Resources.Forward,
                                      Resources.Help,Resources.Left,Resources.Loop,Resources.Minus,
                                      Resources.OK,Resources.Option,Resources.Pause,Resources.Play,
                                      Resources.Plus,Resources.Redo,Resources.Right,Resources.Search,
                                      Resources.Trash,Resources.Undo,Resources.Up};

        private string _tooltip = "";
        private bool _visible = true;
        private int _width = 19;

        #endregion

        #region Constructors

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1810:InitializeReferenceTypeStaticFieldsInline")]
        static EditorButton()
        {
            Button btn = null;
            try
            {
                btn = new Button();
                _defButtonFont = btn.Font;
                _defButtonGraphics = btn.CreateGraphics();
            }
            finally
            {
                btn.Dispose();
                btn = null;
            }
        }

        /// <summary>
        /// 初始化 <see cref="QGEditors.WinForms.EditorButton"/>  类的新实例。
        /// </summary>
        public EditorButton()
        {
        }

        /// <summary>
        /// 使用预置的按钮类型，初始化 <see cref="QGEditors.WinForms.EditorButton"/>  类的新实例。
        /// </summary>
        /// <param name="kind">预置的按钮类型</param>
        public EditorButton(ButtonPredefines kind)
            : this()
        {
            SetKind(kind);
        }

        #endregion

        #region Events

        /// <summary>
        /// 在某一属性值已更改时发生。
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// 在某个属性值将更改时发生。
        /// </summary>
        public event PropertyChangingEventHandler PropertyChanging;

        #endregion

        #region Properties

        /// <summary>
        /// 获取或设置与当前按钮关联的文本。
        /// </summary>
        /// <remarks>
        /// <see cref="EditorButton.Width"/>会根据文本长度变化。
        /// </remarks>
        /// <value>
        /// 与此编辑器按钮关联的文本。
        /// </value>
        [DefaultValue("")]
        [Localizable(true)]
        public virtual string Caption
        {
            get
            {
                return _caption;
            }
            set
            {
                if (!string.Equals(this._caption, value) && this.RaisePropertyChanging("Caption"))
                {
                    string cap = this.Caption;
                    this._caption = value;
                    this._captionSize = value.GetTextSize(_defButtonGraphics, _defButtonFont);
                    this.Width = Convert.ToInt32(Math.Round(this._captionSize.Width));
                    this.RaisePropertyChanged<string>("Caption", cap, value);
                }
            }
        }

        /// <summary>
        /// 获取或设置当鼠标指针位于当前按钮上时显示的光标。
        /// </summary>
        /// <value>
        /// 一个 <see cref="System.Windows.Forms.Cursor"/>，表示当鼠标指针位于控件上时显示的光标。
        /// 默认值 <see cref="Cursors.Default"/>
        /// </value>
        [DefaultValue(typeof(Cursor), "Default")]
        [Localizable(true)]
        public virtual Cursor Cursor
        {
            get
            {
                return _cursor;
            }
            set
            {
                if (_cursor != value && this.RaisePropertyChanging("Cursor"))
                {
                    Cursor cur = this.Cursor;
                    this._cursor = value;
                    this.RaisePropertyChanged<Cursor>("Cursor", cur, value);
                }
            }
        }

        /// <summary>
        /// 获取或设置一个值，该值指示当前按钮是否可以对用户交互作出响应。
        /// </summary>
        /// <value>
        /// 如果控件可以对用户交互作出响应，则为 <c>true</c>；否则为 <c>false</c>。 默认值为 <c>true</c>。
        /// </value>
        [DefaultValue(true)]
        [Localizable(true)]
        public virtual bool Enabled
        {
            get
            {
                return _enable;
            }
            set
            {
                if (!bool.Equals(this._enable, value) && this.RaisePropertyChanging("Enabled"))
                {
                    bool enable = this.Enabled;
                    this._enable = value;
                    this.RaisePropertyChanged<bool>("Enabled", enable, value);
                }
            }
        }

        /// <summary>
        /// 获取或设置显示在当前按钮上的图像。
        /// </summary>
        /// <remarks>
        /// 如果 <see cref="System.Drawing.Image"/> 不存在于 <see cref="ButtonPredefines"/> 提供的预设集合中
        /// ，则 <see cref="EditorButton.Kind"/> 属性会被置为 <see cref="ButtonPredefines.Glyph"/>。
        /// </remarks>
        /// <value>
        /// 默认值为 <c>null</c>。
        /// </value>
        [DefaultValue((string)null)]
        [Localizable(true)]
        public virtual Image Image
        {
            get
            {
                return _image;
            }
            set
            {
                if (_image != value && this.RaisePropertyChanging("Image"))
                {
                    Image img = this.Image;
                    this._image = value;
                    this.RaisePropertyChanged<Image>("Image", img, value);
                    if (!_presetImages.Contains(value, _imageComparer))
                    {
                        this._kind = ButtonPredefines.Glyph;
                    }
                }
            }
        }

        /// <summary>
        /// 获取或设置当前按钮上的图像对齐方式。
        /// </summary>
        /// <value>
        /// <see cref="System.Drawing.ContentAlignment"/> 值之一。 默认值为 <see cref="ContentAlignment.MiddleCenter"/>。
        /// </value>
        [DefaultValue(32)]
        [Localizable(true)]
        public virtual ContentAlignment ImageAlign
        {
            get
            {
                return _imageAlign;
            }
            set
            {
                if (this._imageAlign != value && this.RaisePropertyChanging("ImageAlign"))
                {
                    ContentAlignment align = this.ImageAlign;
                    this._imageAlign = value;
                    this.RaisePropertyChanged<ContentAlignment>("ImageAlign", align, value);
                }
            }
        }

        /// <summary>
        /// 获取或设置当前按钮的位置。
        /// </summary>
        /// <value>
        /// 如果为 <c>true</c> 那么编辑器按钮会从父级控件的左侧开始绘制，反之则从从父级控件的右侧开始绘制。
        /// 默认值为 <c>false</c>。
        /// </value>
        [DefaultValue(false)]
        [Localizable(true)]
        public virtual bool IsLeft
        {
            get
            {
                return _isLeft;
            }
            set
            {
                if (!bool.Equals(this._isLeft, value) && this.RaisePropertyChanging("IsLeft"))
                {
                    bool isLeft = this.IsLeft;
                    this._isLeft = value;
                    this.RaisePropertyChanged<bool>("IsLeft", isLeft, value);
                }
            }
        }

        /// <summary>
        /// 获取或设置要在当前按钮中预设的图像类型。
        /// </summary>
        /// <remarks>
        /// 默认为 <see cref="ButtonPredefines.Elipsis"/> 。
        /// 修改为 <see cref="ButtonPredefines.Glyph"/> 后会根据 <see cref="EditorButton.Image"/> 属性和 <see cref="EditorButton.Caption"/> 属性显示内容。
        /// </remarks>
        [DefaultValue(1)]
        [Localizable(true)]
        public virtual ButtonPredefines Kind
        {
            get
            {
                return _kind;
            }
            set
            {
                if (this.Kind != value && this.RaisePropertyChanging("Kind"))
                {
                    ButtonPredefines kind = this.Kind;
                    this._kind = value;
                    this.RaisePropertyChanged<ButtonPredefines>("Kind", kind, value);
                }
            }
        }

        /// <summary>
        /// 获取或设置用于激活当前按钮功能的快捷方式。
        /// </summary>
        /// <remarks>
        /// <see cref="TextBoxBase.ShortcutsEnabled"/> 属性指示该快捷方式是否可用。
        /// </remarks>
        /// <value>默认值 <see cref="Keys.None"/> 。</value>
        [DefaultValue(0)]
        [Localizable(true)]
        public virtual Keys Shortcut { get; set; }

        /// <summary>
        /// 获取或设置为在此元素显示的工具提示对象 用户界面 (UI)。
        /// </summary>
        [DefaultValue("")]
        [Localizable(true)]
        public virtual string ToolTip
        {
            get
            {
                return _tooltip;
            }
            set
            {
                if (!string.Equals(this._tooltip, value) && this.RaisePropertyChanging("ToolTip"))
                {
                    string tip = this.ToolTip;
                    this._tooltip = value;
                    this.RaisePropertyChanged<string>("ToolTip", tip, value);
                }
            }
        }

        /// <summary>
        /// 获取或设置一个值，该值指示是否显示当前按钮。
        /// </summary>
        /// <value>默认值 <c>true</c> 。</value>
        [DefaultValue(true)]
        [Localizable(true)]
        public virtual bool Visible
        {
            get
            {
                return _visible;
            }
            set
            {
                if (!bool.Equals(this._visible, value) && this.RaisePropertyChanging("Visible"))
                {
                    bool visible = this.Visible;
                    this._visible = value;
                    this.RaisePropertyChanged<bool>("Visible", visible, value);
                }
            }
        }

        /// <summary>
        /// 获取或设置当前按钮的宽度。
        /// </summary>
        /// <value>默认值 19 。</value>
        [DefaultValue(19)]
        [Localizable(true)]
        public virtual int Width
        {
            get
            {
                return _width;
            }
            set
            {
                int v = _defaultWidth;
                if (this.Kind == ButtonPredefines.Glyph && this.Image == null)
                {
                    if (_captionSize != SizeF.Empty)
                    {
                        v = (int)_captionSize.Width + 9;
                    }
                }
                v = (v > value) ? v : value;

                if (!int.Equals(this._width, v) && this.RaisePropertyChanging("Width"))
                {
                    int width = this.Width;
                    this._width = v;
                    this.RaisePropertyChanged<int>("Width", width, v);
                }
            }
        }

        internal SizeF CaptionSize
        {
            get
            {
                return _captionSize;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// 返回的字符串表示形式 <see cref="EditorButton"/> 对象。
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ObjectHelper.GetObjectText(this);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate")]
        protected internal virtual void RaisePropertyChanged<T>(string propertyName, T oldValue, T newValue)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChangedEventArgsEx e = new PropertyChangedEventArgsEx(propertyName, oldValue, newValue);
                this.PropertyChanged(this, e);
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate")]
        protected internal virtual bool RaisePropertyChanging(string propertyName)
        {
            if (this.PropertyChanging != null)
            {
                PropertyChangingEventArgsEx e = new PropertyChangingEventArgsEx(propertyName);
                this.PropertyChanging(this, e);
                return !e.Cancel;
            }
            return true;
        }

        private void SetKind(ButtonPredefines kind)
        {
            this._kind = kind;
            this._image = kind.GetImage();
        }

        #endregion

        #region Classes

        private class ImageComparer : IEqualityComparer<Image>
        {
            #region Methods

            public bool Equals(Image x, Image y)
            {
                if (x == null && y == null)
                {
                    return true;
                }
                else if (x == null || y == null)
                {
                    return false;
                }

                using (MemoryStream ms1 = new MemoryStream())
                {
                    using (MemoryStream ms2 = new MemoryStream())
                    {
                        x.Save(ms1, System.Drawing.Imaging.ImageFormat.Bmp);
                        y.Save(ms2, System.Drawing.Imaging.ImageFormat.Bmp);
                        byte[] im1 = ms1.GetBuffer();
                        byte[] im2 = ms2.GetBuffer();
                        if (im1.Length != im2.Length)
                            return false;
                        else
                        {
                            for (int i = 0; i < im1.Length; i++)
                                if (im1[i] != im2[i])
                                    return false;
                        }
                        return true;
                    }
                }
            }

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:验证公共方法的参数", MessageId = "0")]
            public int GetHashCode(Image obj)
            {
                return obj.GetHashCode();
            }

            #endregion
        }

        #endregion
    }
}