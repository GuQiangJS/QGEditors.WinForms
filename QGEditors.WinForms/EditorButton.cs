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
    [ComVisible(false)]
    [ToolboxItem(false)]
    [DefaultProperty("Kind")]
    public class EditorButton : INotifyPropertyChanged, INotifyPropertyChanging
    {
        #region Fields

        private static Font _defButtonFont = new Button().Font;
        private static Graphics _defButtonGraphics = new Button().CreateGraphics();
        private string _caption = "";
        private SizeF _captionSize;
        private Cursor _cursor = Cursors.Default;
        private int _defaultWidth = 19;
        private bool _enable = true;
        private Image _image = null;
        private ContentAlignment _imageAlign = ContentAlignment.MiddleCenter;
        private ImageComparer _imageComparer = new ImageComparer();
        private bool _isLeft = false;
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

        public EditorButton()
        {
        }

        public EditorButton(ButtonPredefines kind)
            : this()
        {
            SetKind(kind);
        }

        #endregion

        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        public event PropertyChangingEventHandler PropertyChanging;

        #endregion

        #region Properties

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

        [DefaultValue(typeof(Cursor), "Default")]
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

        [DefaultValue(true)]
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

        [DefaultValue((string)null)]
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

        [DefaultValue(32)]
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

        [DefaultValue(false)]
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

        [DefaultValue(1)]
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

        //TODO
        [DefaultValue(0)]
        public virtual Keys Shortcut { get; set; }

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

        [DefaultValue(true)]
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

        [DefaultValue(19)]
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

        public override string ToString()
        {
            return ObjectHelper.GetObjectText(this);
        }

        protected internal virtual void RaisePropertyChanged<T>(string propertyName, T oldValue, T newValue)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChangedEventArgsEx e = new PropertyChangedEventArgsEx(propertyName, oldValue, newValue);
                this.PropertyChanged(this, e);
            }
        }

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

            public int GetHashCode(Image obj)
            {
                return obj.GetHashCode();
            }

            #endregion
        }

        #endregion
    }
}