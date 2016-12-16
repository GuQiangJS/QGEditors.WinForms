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
    [DefaultEvent("ButtonClick")]
    public class ButtonEdit : TextBox
    {
        #region Fields

        private static readonly object buttonClick = new object();
        private static bool _setLocalAndSize = false;
        private EditorButtonCollection _buttons = new EditorButtonCollection();
        private ToolTip _buttonTip = new ToolTip();
        private Dictionary<Button, EditorButton> _innerButtons = new Dictionary<Button, EditorButton>();

        #endregion

        #region Constructors

        public ButtonEdit()
        {
            this.Buttons.CollectionChanged += Buttons_CollectionChanged;

            this._buttonTip.AutoPopDelay = 10000;
        }

        #endregion

        #region Events

        public event ButtonPressedEventHandler ButtonClick
        {
            add
            {
                base.Events.AddHandler(buttonClick, value);
            }
            remove
            {
                base.Events.RemoveHandler(buttonClick, value);
            }
        }

        #endregion

        #region Properties

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

        protected internal virtual void RaiseButtonClick(ButtonPressedEventArgs e)
        {
            ButtonPressedEventHandler handler = (ButtonPressedEventHandler)base.Events[buttonClick];
            if (handler != null)
            {
                handler(this.GetEventSender(), e);
            }
        }

        protected virtual object GetEventSender()
        {
            if (this.Parent != null)
            {
                return this.Parent;
            }
            return this;
        }

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

        protected override void OnPaint(PaintEventArgs e)
        {
            CreateButtons();
            base.OnPaint(e);
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

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                EditorButton editorBtn = _innerButtons[btn];
                if (editorBtn != null)
                {
                    RaiseButtonClick(new ButtonPressedEventArgs(editorBtn));
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
                        e.Graphics.DrawImage(btnImg, new Rectangle(imagePoint, btnImg.Size));
                    }
                    if (!string.IsNullOrEmpty(editorBtn.Caption))
                    {
                        Rectangle textRect = GetTextRectangle(btn, editorBtn);
                        if (!textRect.IsEmpty)
                        {
                            e.Graphics.DrawString(editorBtn.Caption, btn.Font, SystemBrushes.ControlText, GetTextRectangle(btn, editorBtn));
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

        private void CreateButtons()
        {
            this.Controls.Clear();
            this._innerButtons.Clear();
            foreach (EditorButton editorButton in Buttons)
            {
                if (editorButton != null && editorButton.Visible)
                {
                    Button btn = new Button();
                    btn.MouseHover += btn_MouseHover;
                    btn.MouseLeave += btn_MouseLeave;
                    btn.Paint += btn_Paint;
                    btn.Padding = new Padding(0);
                    btn.Margin = new Padding(0);
                    SyncEditorButtonProperties(editorButton, btn);
                    SetButtonFlat(btn);
                    btn.SizeChanged += (o, e) => OnResize(e);
                    this.Controls.Add(btn);
                    this._innerButtons.Add(btn, editorButton);
                    btn.Click += btn_Click;
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
                if (ButtonEdit.Equals(kv.Value, button))
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

        private Rectangle GetTextRectangle(Button btn, EditorButton editorBtn)
        {
            //图片左右偏移量
            int imageMargin = 1;
            int textTopMargin = 1;

            int width = Convert.ToInt32(Math.Round(editorBtn.CaptionSize.Width));
            int height = Convert.ToInt32(Math.Round(editorBtn.CaptionSize.Height));
            //文字高度+1偏移量
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

        private void ListenPropertyChanged(EditorButton btn)
        {
            if (btn != null)
            {
                btn.PropertyChanged += btn_PropertyChanged;
            }
        }

        private static void SetButtonFlat(Button btn)
        {
            if (btn != null)
            {
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.FlatAppearance.MouseOverBackColor = SystemColors.GradientInactiveCaption;
            }
        }

        private void SetSizeAndLocation()
        {
            _setLocalAndSize = true;

            if (_innerButtons.Count <= 0)
            {
                return;
            }
            int rightStartLeft = this.ClientSize.Width;
            int leftStartLeft = 0;
            int width = 0;
            Button[] btns = new Button[_innerButtons.Count];
            _innerButtons.Keys.CopyTo(btns, 0);
            for (int i = btns.Length - 1; i >= 0; i--)
            {
                btns[i].Size = new Size(btns[i].Width, this.ClientSize.Height + 1);
                if (!_innerButtons[btns[i]].IsLeft)
                {
                    btns[i].Location = new Point(rightStartLeft - btns[i].Width, -1);
                    rightStartLeft = btns[i].Location.X;
                    width = width + btns[i].Width;
                }
                else
                {
                    btns[i].Location = new Point(leftStartLeft, -1);
                    leftStartLeft = btns[i].Width;
                }
            }
            UnsafeNativeMethods.SendMessage(this.Handle, UnsafeNativeMethods.EM_SETMARGINS, (IntPtr)UnsafeNativeMethods.EC_RIGHTMARGIN, (IntPtr)(width * 0x10000));
            UnsafeNativeMethods.SendMessage(this.Handle, UnsafeNativeMethods.EM_SETMARGINS, (IntPtr)UnsafeNativeMethods.EC_LEFTMARGIN, (IntPtr)(leftStartLeft & 0xFFFF));

            _setLocalAndSize = false;
        }

        private static void SyncEditorButtonProperties(EditorButton editorBtn, Button btn)
        {
            if (editorBtn != null && btn != null)
            {
                btn.Enabled = editorBtn.Enabled;
                btn.Width = editorBtn.Width;
                btn.Cursor = editorBtn.Cursor;
                btn.Visible = editorBtn.Visible;
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