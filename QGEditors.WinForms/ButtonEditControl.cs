/*
 *  QGEditor
 *  Copyright (c) 2014-2016 GuQiang - <guqiangjs@gmail.com>
 *  ALL RIGHTS RESERVED
*/

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace QGEditors.WinForms
{
    /// <summary>
    /// 表示一个支持内置按钮的控件，该控件可用于显示或编辑无格式文本。
    /// </summary>
    [DefaultProperty("Buttons")]
    [DefaultEvent("ButtonClick")]
    [ToolboxBitmap(typeof(ButtonEditControl), "Resources.ButtonEditControl.png")]
    [Description("支持在编辑框中内置按钮的文本编辑器。")]
    public sealed class ButtonEditControl : TextBox
    {
        #region Fields

        private static bool _setLocalAndSize = false;

        /// <summary>
        /// 按钮集合
        /// </summary>
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private EditorButtonCollection _buttons = new EditorButtonCollection();

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private ToolTip _buttonTip = new ToolTip();

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private ObservableDictionary<Button, EditorButton> _innerButtons = new ObservableDictionary<Button, EditorButton>();

        #endregion

        #region Constructors

        /// <summary>
        /// 初始化 <see cref="QGEditors.WinForms.ButtonEditControl"/>  类的新实例。
        /// </summary>
        public ButtonEditControl()
        {
            this.Buttons.CollectionChanged += Buttons_CollectionChanged;

            this._buttonTip.AutoPopDelay = 10000;

            _innerButtons.CollectionChanged += _innerButtons_CollectionChanged;
        }

        #endregion

        #region Events

        /// <summary>
        /// 当单击一个按钮编辑器按钮时发生。
        /// </summary>
        public event ButtonPressedEventHandler ButtonClick;

        #endregion

        #region Properties

        /// <summary>
        /// 获取当前编辑器中的按钮的集合。
        /// </summary>
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public EditorButtonCollection Buttons
        {
            get
            {
                return _buttons;
            }
        }

        #endregion

        #region Methods

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            if (this.ShortcutsEnabled && e != null)
            {
                Button btn = FindButton(e.KeyCode);
                if (btn != null)
                {
                    this.btn_Click(btn, EventArgs.Empty);
                }
            }
        }

        protected override void OnResize(EventArgs e)
        {
            SetSizeAndLocation();
            base.OnResize(e);
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == UnsafeNativeMethods.EM_SETMARGINS && !_setLocalAndSize)
            {
                SetSizeAndLocation();
            }
        }

        private static Rectangle GetTextRectangle(Button btn, EditorButton editorBtn)
        {
            //图片左右偏移量
            int imageMargin = 1;
            //文字高度偏移量
            int textTopMargin = 0;

            int width = editorBtn.CaptionSize.Width.ToInt32();
            int height = editorBtn.CaptionSize.Height.ToInt32();

            int top = ((btn.ClientSize.Height - height) / 2) + textTopMargin;
            int left = (btn.ClientSize.Width - width) / 2;

            left = (left < 0) ? 0 : left;

            //减去图片后的剩余宽度
            int residualWidth = width;

            Image btnImg = editorBtn.GetImage();
            if (btnImg != null)
            {
                Point imagePoint = btn.GetImageLocation(editorBtn.ImageAlign, btnImg);
                switch (editorBtn.ImageAlign)
                {
                    case ContentAlignment.BottomCenter:
                    case ContentAlignment.MiddleCenter:
                    case ContentAlignment.TopCenter:
                        left = top = width = height = residualWidth = 0;
                        break;

                    case ContentAlignment.BottomLeft:
                    case ContentAlignment.TopLeft:
                    case ContentAlignment.MiddleLeft:
                        left = btn.GetImageLocation(editorBtn.ImageAlign, btnImg).X + btnImg.Width + imageMargin;
                        //可用范围
                        residualWidth = btn.ClientSize.Width - (imagePoint.X + btnImg.Width);
                        break;

                    case ContentAlignment.BottomRight:
                    case ContentAlignment.TopRight:
                    case ContentAlignment.MiddleRight:
                        left = 0;
                        //可用范围
                        residualWidth = imagePoint.X - imageMargin;
                        break;
                }
                width = (width > residualWidth) ? residualWidth : width;
            }

            return new Rectangle(left, top, width, height);
        }

        private static void SetButtonFlat(Button btn)
        {
            if (btn != null)
            {
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.FlatAppearance.MouseOverBackColor = Color.BlanchedAlmond;
            }
        }

        private static void SyncEditorButtonProperties(EditorButton editorBtn, Button btn)
        {
            if (editorBtn != null && btn != null)
            {
                btn.Enabled = editorBtn.Enabled;
                btn.Width = editorBtn.Width;
                btn.Cursor = editorBtn.Cursor;
                btn.Visible = editorBtn.Visible;
                if (string.IsNullOrEmpty(editorBtn.Name))
                {
                    editorBtn.Name = btn.Name;
                }
                else
                {
                    btn.Name = editorBtn.Name;
                }
            }
        }

        private void _innerButtons_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (KeyValuePair<Button, EditorButton> item in e.NewItems)
                    {
                        ListenButtonEvents(item.Key as Button);
                    }
                    break;

                case NotifyCollectionChangedAction.Remove:
                    foreach (KeyValuePair<Button, EditorButton> item in e.OldItems)
                    {
                        UnListenButtonEvents(item.Key as Button);
                    }
                    break;
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                EditorButton editorBtn = _innerButtons[btn];
                if (editorBtn != null && editorBtn.Enabled)
                {
                    if (this.ButtonClick != null)
                    {
                        this.ButtonClick(editorBtn, new ButtonPressedEventArgs(editorBtn));
                    }
                    SyncEditorButtonProperties(editorBtn, btn);
                }
            }
        }

        private void btn_MouseHover(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                EditorButton editorBtn = this._innerButtons[btn];
                if (editorBtn != null && !string.IsNullOrEmpty(editorBtn.ToolTip))
                {
                    this._buttonTip.Show(editorBtn.ToolTip, btn);
                }
            }
        }

        private void btn_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                this._buttonTip.Hide(btn);
            }
        }

        private void btn_Paint(object sender, PaintEventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                EditorButton editorBtn = _innerButtons[btn];
                if (editorBtn != null)
                {
                    Point imagePoint = new Point(0, 0);
                    Image btnImg = editorBtn.GetImage();
                    if (editorBtn.GetImage() != null)
                    {
                        imagePoint = btn.GetImageLocation(editorBtn.ImageAlign, btnImg);

                        if(editorBtn.Enabled)
                        {
                            e.Graphics.DrawImage(btnImg, new Rectangle(imagePoint, btnImg.Size));
                        }
                        else
                        {
                            ControlPaint.DrawImageDisabled(e.Graphics, btnImg, imagePoint.X, imagePoint.Y, Color.Transparent);
                        }

                        
                    }
                    if (!string.IsNullOrEmpty(editorBtn.Caption))
                    {
                        Rectangle textRect = GetTextRectangle(btn, editorBtn);
                        if (!textRect.IsEmpty)
                        {
                            if (editorBtn.Enabled)
                            {
                                using (Brush brush = new SolidBrush(editorBtn.CaptionColor))
                                {
                                    e.Graphics.DrawString(editorBtn.Caption, editorBtn.CaptionFont, brush, GetTextRectangle(btn, editorBtn));
                                }
                            }
                            else
                            {
                                ControlPaint.DrawStringDisabled(e.Graphics, editorBtn.Caption, editorBtn.CaptionFont, Color.Transparent, GetTextRectangle(btn, editorBtn), TextFormatFlags.Default);
                            }
                        }
                    }
                }
            }
        }


        private void btn_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            EditorButton editBtn = sender as EditorButton;
            Button btn = FindButton(editBtn);
            SyncEditorButtonProperties(editBtn, btn);
            SetSizeAndLocation();
            btn.Refresh();
        }

        private void Buttons_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (object o in e.NewItems)
                    {
                        ListenPropertyChanged(o as EditorButton);
                    }
                    break;

                case NotifyCollectionChangedAction.Remove:
                    foreach (object o in e.OldItems)
                    {
                        UnListenPropertyChanged(o as EditorButton);
                    }
                    break;
            }
            CreateButtons();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:丢失范围之前释放对象")]
        private void CreateButtons()
        {
            this.Controls.Clear();
            this._innerButtons.Clear();
            foreach (EditorButton editorButton in Buttons)
            {
                if (editorButton != null && editorButton.Visible)
                {
                    Button btn = new Button();
                    btn.Padding = btn.Margin = new Padding(0);
                    SyncEditorButtonProperties(editorButton, btn);
                    SetButtonFlat(btn);
                    this.Controls.Add(btn);
                    this._innerButtons.Add(btn, editorButton);
                }
            }
            SetSizeAndLocation();
        }

        private Button FindButton(Keys keys)
        {
            return FindButton(FindEditorButton(keys));
        }

        private Button FindButton(EditorButton button)
        {
            if (button == null)
            {
                return null;
            }
            foreach (KeyValuePair<Button, EditorButton> kv in this._innerButtons)
            {
                if (ButtonEditControl.Equals(kv.Value, button))
                {
                    return kv.Key;
                }
            }
            return null;
        }

        private EditorButton FindEditorButton(Keys keys)
        {
            foreach (EditorButton btn in this._innerButtons.Values)
            {
                if (Enum.Equals(keys, btn.Shortcut))
                {
                    return btn;
                }
            }
            return null;
        }

        private void ListenButtonEvents(Button btn)
        {
            if (btn != null)
            {
                btn.MouseHover += btn_MouseHover;
                btn.MouseLeave += btn_MouseLeave;
                btn.MouseMove += btn_MouseMove;
                btn.Paint += btn_Paint;
                btn.SizeChanged += (o, e) => OnResize(e);
                btn.Click += btn_Click;
            }
        }

        void btn_MouseMove(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                #region 边框竖线
                Graphics graphics = btn.CreateGraphics();
                graphics.DrawLine(SystemPens.ActiveBorder, new Point(btn.ClientRectangle.Width - 1, 0), new Point(btn.ClientRectangle.Width - 1, btn.ClientRectangle.Bottom));
                graphics.DrawLine(SystemPens.ActiveBorder, new Point(0, 0), new Point(0, btn.ClientRectangle.Bottom));
                #endregion
            }
        }

        private void ListenPropertyChanged(EditorButton btn)
        {
            if (btn != null)
            {
                btn.PropertyChanged += btn_PropertyChanged;
            }
        }

        private void SetSizeAndLocation()
        {
            _setLocalAndSize = true;

            if (_innerButtons.Count <= 0)
            {
                return;
            }
            int rightStartLeft = this.Width;
            int leftStartLeft = 0;
            int width = 0;
            Button[] btns = new Button[_innerButtons.Count];
            _innerButtons.Keys.CopyTo(btns, 0);
            for (int i = btns.Length - 1; i >= 0; i--)
            {
                btns[i].Size = new Size(btns[i].Width, this.ClientSize.Height);
                if (!_innerButtons[btns[i]].IsLeft)
                {
                    btns[i].Location = new Point(rightStartLeft - btns[i].Width, 0);
                    rightStartLeft = btns[i].Location.X;
                    width = width + btns[i].Width;
                }
                else
                {
                    btns[i].Location = new Point(leftStartLeft - 1, 0);
                    leftStartLeft = btns[i].Width;
                }
            }

            UnsafeNativeMethods.SendMessage(this.Handle, UnsafeNativeMethods.EM_SETMARGINS, (IntPtr)UnsafeNativeMethods.EC_RIGHTMARGIN, (IntPtr)((width - 1) * 0x10000));
            UnsafeNativeMethods.SendMessage(this.Handle, UnsafeNativeMethods.EM_SETMARGINS, (IntPtr)UnsafeNativeMethods.EC_LEFTMARGIN, (IntPtr)((leftStartLeft + 1) & 0xFFFF));

            _setLocalAndSize = false;
        }

        private void UnListenButtonEvents(Button btn)
        {
            if (btn != null)
            {
                btn.MouseHover -= btn_MouseHover;
                btn.MouseLeave -= btn_MouseLeave;
                btn.MouseMove -= btn_MouseMove;
                btn.Paint -= btn_Paint;
                btn.SizeChanged -= (o, e) => OnResize(e);
                btn.Click -= btn_Click;
            }
        }

        private void UnListenPropertyChanged(EditorButton btn)
        {
            if (btn != null)
            {
                btn.PropertyChanged -= btn_PropertyChanged;
            }
        }

        #endregion
    }
}