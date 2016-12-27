/*
 *  QGEditor
 *  Copyright (c) 2014-2016 GuQiang - <guqiangjs@gmail.com>
 *  ALL RIGHTS RESERVED
*/

using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace QGEditors.WinForms
{
    /// <summary>
    /// 扩展 <see cref="SplitContainer"/> 。分割区域的可移动条中间显示分隔符。
    /// </summary>
    [ToolboxBitmap(typeof(SplitContainerControl), "Resources.SplitContainerControl.png")]
    public sealed class SplitContainerControl : SplitContainer, INotifyPropertyChanged, INotifyPropertyChanging
    {
        #region Fields

        //绘图高度
        private const int _HEIGHT = 1;

        //最大高度或最大宽度（根据Orientation属性确定）
        private const int _MAX = 15;

        //间隔宽度
        private const int _SPACING = 3;

        //绘图宽度
        private const int _WIDTH = 1;

        private Image _splitterImage;

        private ImageLayout _splitterImageLayout = ImageLayout.Center;

        #endregion

        #region Events

        /// <summary>
        /// 在更改属性值时发生。
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// 在属性值更改时发生。
        /// </summary>
        public event PropertyChangingEventHandler PropertyChanging;

        #endregion

        #region Properties

        /// <summary>
        /// 获取或设置显示在拆分器上的图像。
        /// </summary>
        /// <value>
        /// 默认值为 <c>null</c>。
        /// </value>
        [DefaultValue((string)null)]
        [Localizable(true)]
        public Image SplitterImage
        {
            get
            {
                return _splitterImage;
            }
            set
            {
                if (_splitterImage != value && this.RaisePropertyChanging("Image"))
                {
                    Image img = this.SplitterImage;
                    this._splitterImage = value;
                    this.RaisePropertyChanged<Image>("Image", img, value);
                    this.Refresh();
                }
            }
        }

        /// <summary>
        /// 获取或设置在 <see cref="System.Windows.Forms.ImageLayout"/> 枚举中定义的背景图像布局。。
        /// </summary>
        [DefaultValue(ImageLayout.Center)]
        [Localizable(true)]
        public ImageLayout SplitterImageLayout
        {
            get
            {
                return _splitterImageLayout;
            }
            set
            {
                if (this._splitterImageLayout != value && this.RaisePropertyChanging("BackgroundImageLayout"))
                {
                    ImageLayout layout = this._splitterImageLayout;
                    this._splitterImageLayout = value;
                    this.RaisePropertyChanged<ImageLayout>("BackgroundImageLayout", layout, value);
                    this.Refresh();
                }
            }
        }

        #endregion

        #region Methods

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate")]
        internal void RaisePropertyChanged<T>(string propertyName, T oldValue, T newValue)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChangedEventArgsEx e = new PropertyChangedEventArgsEx(propertyName, oldValue, newValue);
                this.PropertyChanged(this, e);
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate")]
        internal bool RaisePropertyChanging(string propertyName)
        {
            if (this.PropertyChanging != null)
            {
                PropertyChangingEventArgsEx e = new PropertyChangingEventArgsEx(propertyName);
                this.PropertyChanging(this, e);
                return !e.Cancel;
            }
            return true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (e == null || e.ClipRectangle == null || e.Graphics == null)
            {
                return;
            }

            if (this.SplitterImage == null)
            {
                #region 绘制默认分隔符

                Pen pen = SystemPens.ControlDark;
                Brush brush = SystemBrushes.ControlDark;

                if (e.ClipRectangle.Contains(this.PointToClient(Control.MousePosition)))
                {
                    pen = SystemPens.ControlDarkDark;
                    brush = SystemBrushes.ControlDarkDark;
                }

                Rectangle rect = new Rectangle();

                if (this.Orientation == Orientation.Horizontal)
                {
                    int startX = (e.ClipRectangle.Width / 2 - _MAX / 2);
                    int endX = (e.ClipRectangle.Width / 2 + _MAX / 2);
                    rect.X = startX;
                    rect.Width = _MAX;
                    rect.Y = e.ClipRectangle.Y + (e.ClipRectangle.Height - _HEIGHT) / 2;
                    rect.Height = e.ClipRectangle.Height - 1;
                }
                else
                {
                    int startX = (e.ClipRectangle.Height / 2 - _MAX / 2);
                    int endX = (e.ClipRectangle.Height / 2 + _MAX / 2);
                    rect.X = e.ClipRectangle.X + (e.ClipRectangle.Width - _WIDTH) / 2;
                    rect.Width = e.ClipRectangle.Width - 1;
                    rect.Y = startX;
                    rect.Height = _MAX;
                }

                Queue<Rectangle> rects = new Queue<Rectangle>();

                if (this.Orientation == Orientation.Horizontal)
                {
                    int left = rect.X;
                    while (left < (rect.X + _MAX) && left + _WIDTH < (rect.X + _MAX))
                    {
                        Rectangle rec = new Rectangle();
                        rec.X = left;
                        rec.Width = _WIDTH;
                        rec.Height = _HEIGHT;
                        rec.Y = rect.Y;
                        left = left + _SPACING;
                        rects.Enqueue(rec);
                    }
                }
                else
                {
                    int top = rect.Y;
                    while (top < (rect.Y + _MAX) && top + _HEIGHT < (rect.Y + _MAX))
                    {
                        Rectangle rec = new Rectangle();
                        rec.X = rect.X;
                        rec.Width = _WIDTH;
                        rec.Height = _HEIGHT;
                        rec.Y = top;
                        top = top + _SPACING;
                        rects.Enqueue(rec);
                    }
                }
                if (rects.Count > 0)
                {
                    e.Graphics.DrawRectangles(pen, rects.ToArray());
                    e.Graphics.FillRectangles(brush, rects.ToArray());
                }

                #endregion
            }
            else
            {
                #region 根据设置绘制图片

                e.Graphics.DrawBackgroundImage(this.SplitterImage, this.BackColor, this.SplitterImageLayout, this.SplitterRectangle, this.SplitterRectangle, new Point(0, 0), this.RightToLeft);

                #endregion
            }
        }

        #endregion
    }
}