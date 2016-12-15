using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Windows.Forms;

namespace QGEditors.WinForms
{
    public class ButtonEdit : TextBox
    {
        #region Fields

        protected Dictionary<Button, EditorButton> _innerButtons = new Dictionary<Button, EditorButton>();
        private static readonly object buttonClick = new object();
        private ToolTip _buttonTip = new ToolTip();

        private EditorButtonCollection _buttons = new EditorButtonCollection();

        #endregion

        #region Constructors

        public ButtonEdit()
        {
            this.Buttons.CollectionChanged += Buttons_CollectionChanged;

            this._buttonTip.AutoPopDelay = 10000;
        }

        void ListenPropertyChanging(EditorButton btn)
        {
            if (btn != null)
            {
            btn.PropertyChanging += btn_PropertyChanging;
            }
        }

        void ListenPropertyChanged(EditorButton btn)
        {
            if (btn != null)
            {
                btn.PropertyChanged += btn_PropertyChanged;
            }
        }

        void UnListenPropertyChanging(EditorButton btn)
        {
            if (btn != null)
            {
            btn.PropertyChanging -= btn_PropertyChanging;
            }
        }

        void UnListenPropertyChanged(EditorButton btn)
        {
            if (btn != null)
            {
                btn.PropertyChanged -= btn_PropertyChanged;
            }
        }

        void btn_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            EditorButton editBtn = sender as EditorButton;
            Button btn = FindButton(editBtn);
            SyncEditorButtonProperties(editBtn, btn);
            SetSizeAndLocation();
            btn.Refresh();
        }

        void btn_PropertyChanging(object sender, System.ComponentModel.PropertyChangingEventArgs e)
        {
        }

        void Buttons_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (object o in e.NewItems)
                    {
                        ListenPropertyChanging(o as EditorButton);
                        ListenPropertyChanged(o as EditorButton);
                    }
                    break;
                default:
                    throw new NotImplementedException();
            }
            CreateButtons();
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

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            CreateButtons();
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            Button btn = FindButton(e.KeyCode);
            if (btn != null)
            {
                this.btn_Click(btn, EventArgs.Empty);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            SetSizeAndLocation();
            base.OnResize(e);
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);

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

        void btn_Paint(object sender, PaintEventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                EditorButton editorBtn = _innerButtons[btn];
                if (editorBtn != null)
                {
                    Point imagePoint = GetImagePoint(null, null, null);
                    if (editorBtn.Image != null)
                    {
                        imagePoint = GetImagePoint(btn, editorBtn, editorBtn.Image);
                        e.Graphics.DrawImage(editorBtn.Image, new Rectangle(imagePoint, editorBtn.Image.Size));
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

        Rectangle GetTextRectangle(Button btn, EditorButton editorBtn)
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

            if (editorBtn.Image != null)
            {
                Point imagePoint = GetImagePoint(btn, editorBtn, editorBtn.Image);
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
                        left = GetImagePoint(btn, editorBtn, editorBtn.Image).X + editorBtn.Image.Width + imageMargin;
                        //可用范围
                        residualWidth = btn.ClientSize.Width - (imagePoint.X + editorBtn.Image.Width);
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

        Point GetImagePoint(Button btn,EditorButton editorBtn, Image image)
        {
            if (btn != null && editorBtn != null && image != null)
            {
                switch (editorBtn.ImageAlign)
                {
                    case ContentAlignment.BottomCenter:
                        return new Point((btn.ClientSize.Width - editorBtn.Image.Width) / 2, btn.ClientSize.Height - editorBtn.Image.Height);
                    case ContentAlignment.BottomLeft:
                        return new Point(0, btn.ClientSize.Height - editorBtn.Image.Height);
                    case ContentAlignment.BottomRight:
                        return new Point(btn.ClientSize.Width - editorBtn.Image.Width, btn.ClientSize.Height - editorBtn.Image.Height);
                    case ContentAlignment.TopCenter:
                        return new Point((btn.ClientSize.Width - editorBtn.Image.Width) / 2, 0);
                    case ContentAlignment.TopLeft:
                        return new Point(0, 0);
                    case ContentAlignment.TopRight:
                        return new Point(btn.ClientSize.Width - editorBtn.Image.Width, 0);
                    case ContentAlignment.MiddleCenter:
                        return new Point((btn.ClientSize.Width - editorBtn.Image.Width) / 2, (btn.ClientSize.Height - editorBtn.Image.Height) / 2);
                    case ContentAlignment.MiddleLeft:
                        return new Point(0, (btn.ClientSize.Height - editorBtn.Image.Height) / 2);
                    case ContentAlignment.MiddleRight:
                        return new Point(btn.ClientSize.Width - editorBtn.Image.Width, (btn.ClientSize.Height - editorBtn.Image.Height) / 2);
                }
            }
            return new Point(0, 0);
        }

        void btn_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                this._buttonTip.Hide(btn);
            }
        }

        void btn_MouseHover(object sender, EventArgs e)
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


        private void SetButtonFlat(Button btn)
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
            if (_innerButtons.Count <= 0)
            {
                return;
            }
            int rightStartLeft = this.ClientSize.Width;
            int leftStartLeft = 0;
            int width = 0;
            Button[] btns=new Button[_innerButtons.Count];
            _innerButtons.Keys.CopyTo(btns,0);
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
            SendMessage(this.Handle, EM_SETMARGINS, (IntPtr)EC_RIGHTMARGIN, (IntPtr)(width * 0x10000));
            SendMessage(this.Handle, EM_SETMARGINS, (IntPtr)EC_LEFTMARGIN, (IntPtr)(leftStartLeft & 0xFFFF));
        }

        private const int EM_SETMARGINS = 0xD3;
        private const int EC_LEFTMARGIN = 0x1;
        private const int EC_RIGHTMARGIN = 0x2;

        private void SyncEditorButtonProperties(EditorButton editorBtn, Button btn)
        {
            if (editorBtn != null && btn != null)
            {
                btn.Enabled = editorBtn.Enabled;
                btn.Width = editorBtn.Width;
                //btn.Image = editorBtn.Image;
                btn.Cursor = editorBtn.Cursor;
                //btn.ImageAlign = editorBtn.ImageAlign;
                btn.Visible = editorBtn.Visible;
                //if (editorBtn.Kind == ButtonPredefines.Glyph)
                //{
                //    btn.Text = editorBtn.Caption;
                //}
                //else
                //{
                //    btn.Text = string.Empty;
                //}
                //switch (btn.ImageAlign)
                //{
                //    case ContentAlignment.MiddleLeft:
                //    case ContentAlignment.TopLeft:
                //    case ContentAlignment.BottomLeft:
                //        btn.TextImageRelation = TextImageRelation.ImageBeforeText;
                //        break;
                //    case ContentAlignment.MiddleRight:
                //    case ContentAlignment.TopRight:
                //    case ContentAlignment.BottomRight:
                //        btn.TextImageRelation = TextImageRelation.TextBeforeImage;
                //        break;
                //    case ContentAlignment.TopCenter:
                //        btn.TextImageRelation = TextImageRelation.ImageAboveText;
                //        break;
                //    case ContentAlignment.BottomCenter:
                //        btn.TextImageRelation = TextImageRelation.TextAboveImage;
                //        break;
                //    case ContentAlignment.MiddleCenter:
                //        btn.ResetText();
                //        break;
                //}
            }
        }

        #endregion
    }
}