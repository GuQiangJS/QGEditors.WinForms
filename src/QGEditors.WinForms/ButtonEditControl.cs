// QGEditor
// Copyright (c) 2014-2016 GuQiang - <guqiangjs@gmail.com>
// ALL RIGHTS RESERVED

#region

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Windows.Forms;

#endregion

namespace QGEditors.WinForms {
    /// <summary>
    ///     表示一个支持内置按钮的控件，该控件可用于显示或编辑无格式文本。
    /// </summary>
    /// <remarks>
    ///     <para>ButtonEditControl编辑器是文本编辑器，允许您在编辑框中显示无限数量的按钮。</para>
    ///     <para>
    ///         ButtonEditControl类提供Buttons属性来访问编辑器中显示的按钮集合。每个按钮都由<see cref="EditorButton" />
    ///         对象表示，该对象提供了一些指定按钮的外观，快捷方式，可见性，提示文本等属性。
    ///         通过设置<see cref="EditorButton.Kind" />属性可以选择使用<see cref="ButtonPredefines" />预置的按钮类型。
    ///     </para>
    ///     <para>通过处理<see cref="ButtonEditControl.ButtonClick" />事件来响应点击编辑器按钮事件。</para>
    /// </remarks>
    /// <example>
    ///     <include file='Helper/HelperDoc.xml'
    ///         path='Comments/Examples/example[@class="ButtonEditControl" and @method="none"]/*' />
    /// </example>
    [DefaultProperty("Buttons")]
    [DefaultEvent("ButtonClick")]
    [ToolboxBitmap(typeof(ButtonEditControl), "Resources.ButtonEditControl.png")]
    [Description("支持在编辑框中内置按钮的文本编辑器。")]
    public sealed class ButtonEditControl : TextBox {
        #region Constructors

        /// <summary>
        ///     初始化 <see cref="QGEditors.WinForms.ButtonEditControl" />  类的新实例。
        /// </summary>
        public ButtonEditControl() {
            Buttons.CollectionChanged += Buttons_CollectionChanged;

            _buttonTip.AutoPopDelay = 10000;
            Font = QGEditorControl.DefaultFont;

            _innerButtons.CollectionChanged += _innerButtons_CollectionChanged;
        }

        #endregion

        #region Events

        /// <summary>
        ///     当单击一个按钮编辑器按钮时发生。
        /// </summary>
        public event ButtonPressedEventHandler ButtonClick;

        #endregion

        #region Fields

        private static bool _setLocalAndSize;

        /// <summary>
        ///     按钮集合
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private readonly EditorButtonCollection _buttons =
            new EditorButtonCollection();

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private readonly ToolTip _buttonTip = new ToolTip();

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private readonly ObservableDictionary<Button, EditorButton>
            _innerButtons = new ObservableDictionary<Button, EditorButton>();

        #endregion

        #region Properties

        /// <summary>
        ///     获取或设置控件显示的文字的字体。
        /// </summary>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Unrestricted="true" />
        ///     <IPermission
        ///         class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Unrestricted="true" />
        ///     <IPermission
        ///         class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Flags="UnmanagedCode, ControlEvidence" />
        ///     <IPermission
        ///         class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Unrestricted="true" />
        /// </PermissionSet>
        public override Font Font {
            get { return base.Font; }
            set { base.Font = value; }
        }

        private bool ShouldSerializeFont() {
            return Font != QGEditorControl.DefaultFont;
        }

        /// <summary>
        ///     获取当前编辑器中的按钮的集合。
        /// </summary>
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public EditorButtonCollection Buttons {
            get { return _buttons; }
        }

        #endregion

        #region Methods

        protected override void OnResize(EventArgs e) {
            SetSizeAndLocation();
            base.OnResize(e);
        }

        /// <summary>
        ///     Processes the command key.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <param name="keyData">The key data.</param>
        /// <returns>
        ///     如果命令键已由控件处理，则为 true；否则为 false。
        /// </returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
            Button btn = null;
            if (ShortcutsEnabled && TryGetButtonByCmdKey(keyData, out btn)) {
                btn_Click(btn, EventArgs.Empty);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        ///     Tries the get button by command key.
        /// </summary>
        /// <param name="keyData">The key data.</param>
        /// <param name="btn">The BTN.</param>
        /// <returns></returns>
        private bool TryGetButtonByCmdKey(Keys keyData, out Button btn) {
            btn = null;
            foreach (var kv in _innerButtons)
                if (kv.Value.ShortcutKeys == keyData) {
                    btn = kv.Key;
                    return true;
                }
            return false;
        }

        protected override void WndProc(ref Message m) {
            base.WndProc(ref m);
            if (m.Msg == UnsafeNativeMethods.EM_SETMARGINS && !_setLocalAndSize)
                SetSizeAndLocation();
        }

        private static Rectangle GetTextRectangle(Button btn, EditorButton editorBtn) {
            //图片左右偏移量
            var imageMargin = 1;
            //文字高度偏移量
            var textTopMargin = 0;

            var width = editorBtn.CaptionSize.Width;
            var height = editorBtn.CaptionSize.Height;

            var top = (btn.ClientSize.Height - height) / 2 + textTopMargin;
            var left = (btn.ClientSize.Width - width) / 2;

            left = left < 0 ? 0 : left;

            //减去图片后的剩余宽度
            var residualWidth = width;

            var btnImg = editorBtn.GetImage();
            if (btnImg != null) {
                var imagePoint = btn.GetImageLocation(editorBtn.ImageAlign, btnImg);
                switch (editorBtn.ImageAlign) {
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
                width = width > residualWidth ? residualWidth : width;
            }

            return new Rectangle(left, top, width, height);
        }

        private static void SetButtonFlat(Button btn) {
            if (btn != null) {
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.FlatAppearance.MouseOverBackColor = Color.BlanchedAlmond;
            }
        }

        private static void SyncEditorButtonProperties(EditorButton editorBtn, Button btn) {
            if (editorBtn != null && btn != null) {
                btn.Enabled = editorBtn.Enabled;
                btn.Width = editorBtn.Width + btn.Padding.Left + btn.Padding.Right;
                btn.Cursor = editorBtn.Cursor;
                btn.Visible = editorBtn.Visible;
                if (string.IsNullOrEmpty(editorBtn.Name))
                    editorBtn.Name = btn.Name;
                else
                    btn.Name = editorBtn.Name;
            }
        }

        private void _innerButtons_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e) {
            switch (e.Action) {
                case NotifyCollectionChangedAction.Add:
                    foreach (KeyValuePair<Button, EditorButton> item in e.NewItems)
                        ListenButtonEvents(item.Key);
                    break;

                case NotifyCollectionChangedAction.Remove:
                    foreach (KeyValuePair<Button, EditorButton> item in e.OldItems)
                        UnListenButtonEvents(item.Key);
                    break;
            }
        }

        private void btn_Click(object sender, EventArgs e) {
            var btn = sender as Button;
            if (btn != null) {
                var editorBtn = _innerButtons[btn];
                if (editorBtn != null && editorBtn.Enabled) {
                    if (ButtonClick != null)
                        ButtonClick(editorBtn, new ButtonPressedEventArgs(editorBtn));
                    SyncEditorButtonProperties(editorBtn, btn);
                }
            }
        }

        private void btn_MouseHover(object sender, EventArgs e) {
            var btn = sender as Button;
            if (btn != null) {
                var editorBtn = _innerButtons[btn];
                if (editorBtn != null && !string.IsNullOrEmpty(editorBtn.ToolTip))
                    _buttonTip.Show(editorBtn.ToolTip, btn);
            }
        }

        private void btn_MouseLeave(object sender, EventArgs e) {
            var btn = sender as Button;
            if (btn != null)
                _buttonTip.Hide(btn);
        }

        private void btn_Paint(object sender, PaintEventArgs e) {
            var btn = sender as Button;
            if (btn != null) {
                var editorBtn = _innerButtons[btn];
                if (editorBtn != null) {
                    var imagePoint = new Point(0, 0);
                    var btnImg = editorBtn.GetImage();
                    if (editorBtn.GetImage() != null) {
                        imagePoint = btn.GetImageLocation(editorBtn.ImageAlign, btnImg);

                        if (editorBtn.Enabled)
                            e.Graphics.DrawImage(btnImg, new Rectangle(imagePoint, btnImg.Size));
                        else
                            ControlPaint.DrawImageDisabled(e.Graphics, btnImg, imagePoint.X, imagePoint.Y,
                                Color.Transparent);
                    }
                    if (!string.IsNullOrEmpty(editorBtn.Caption)) {
                        var textRect = GetTextRectangle(btn, editorBtn);
                        if (!textRect.IsEmpty)
                            if (editorBtn.Enabled)
                                using (Brush brush = new SolidBrush(editorBtn.CaptionColor)) {
                                    e.Graphics.DrawString(editorBtn.Caption, editorBtn.CaptionFont, brush,
                                        GetTextRectangle(btn, editorBtn));
                                }
                            else
                                ControlPaint.DrawStringDisabled(e.Graphics, editorBtn.Caption, editorBtn.CaptionFont,
                                    Color.Transparent, GetTextRectangle(btn, editorBtn), TextFormatFlags.Default);
                    }
                }
            }
        }


        private void btn_PropertyChanged(object sender, PropertyChangedEventArgs e) {
            var editBtn = sender as EditorButton;
            var btn = FindButton(editBtn);
            SyncEditorButtonProperties(editBtn, btn);
            SetSizeAndLocation();
            btn.Refresh();
        }

        private void Buttons_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e) {
            switch (e.Action) {
                case NotifyCollectionChangedAction.Add:
                    foreach (var o in e.NewItems)
                        ListenPropertyChanged(o as EditorButton);
                    break;

                case NotifyCollectionChangedAction.Remove:
                    foreach (var o in e.OldItems)
                        UnListenPropertyChanged(o as EditorButton);
                    break;
            }
            CreateButtons();
        }

        [SuppressMessage("Microsoft.Reliability", "CA2000:丢失范围之前释放对象")]
        private void CreateButtons() {
            Controls.Clear();
            _innerButtons.Clear();
            foreach (var editorButton in Buttons)
                if (editorButton != null && editorButton.Visible) {
                    var btn = new Button();
                    btn.Padding = btn.Margin = new Padding(0);
                    SyncEditorButtonProperties(editorButton, btn);
                    SetButtonFlat(btn);
                    Controls.Add(btn);
                    _innerButtons.Add(btn, editorButton);
                }
            SetSizeAndLocation();
        }

        private Button FindButton(EditorButton button) {
            if (button == null)
                return null;
            foreach (var kv in _innerButtons)
                if (Equals(kv.Value, button))
                    return kv.Key;
            return null;
        }

        private void ListenButtonEvents(Button btn) {
            if (btn != null) {
                btn.MouseHover += btn_MouseHover;
                btn.MouseLeave += btn_MouseLeave;
                btn.MouseMove += btn_MouseMove;
                btn.Paint += btn_Paint;
                btn.SizeChanged += (o, e) => OnResize(e);
                btn.Click += btn_Click;
            }
        }

        private void btn_MouseMove(object sender, MouseEventArgs e) {
            var btn = sender as Button;
            if (btn != null) {
                #region 边框竖线

                var graphics = btn.CreateGraphics();
                graphics.DrawLine(SystemPens.ActiveBorder, new Point(btn.ClientRectangle.Width - 1, 0),
                    new Point(btn.ClientRectangle.Width - 1, btn.ClientRectangle.Bottom));
                graphics.DrawLine(SystemPens.ActiveBorder, new Point(0, 0), new Point(0, btn.ClientRectangle.Bottom));

                #endregion
            }
        }

        private void ListenPropertyChanged(EditorButton btn) {
            if (btn != null)
                btn.PropertyChanged += btn_PropertyChanged;
        }

        private void SetSizeAndLocation() {
            _setLocalAndSize = true;

            if (_innerButtons.Count <= 0)
                return;
            var rightStartLeft = Width;
            var leftStartLeft = 0;
            var width = 0;
            var btns = new Button[_innerButtons.Count];
            _innerButtons.Keys.CopyTo(btns, 0);
            for (var i = btns.Length - 1; i >= 0; i--) {
                btns[i].Size = new Size(btns[i].Width, ClientSize.Height);
                if (!_innerButtons[btns[i]].IsLeft) {
                    btns[i].Location = new Point(rightStartLeft - btns[i].Width, 0);
                    rightStartLeft = btns[i].Location.X;
                    width = width + btns[i].Width;
                }
                else {
                    btns[i].Location = new Point(leftStartLeft - 1, 0);
                    leftStartLeft = btns[i].Width;
                }
            }

            UnsafeNativeMethods.SendMessage(Handle, UnsafeNativeMethods.EM_SETMARGINS,
                (IntPtr) UnsafeNativeMethods.EC_RIGHTMARGIN, (IntPtr) ((width - 1) * 0x10000));
            UnsafeNativeMethods.SendMessage(Handle, UnsafeNativeMethods.EM_SETMARGINS,
                (IntPtr) UnsafeNativeMethods.EC_LEFTMARGIN, (IntPtr) ((leftStartLeft + 1) & 0xFFFF));

            _setLocalAndSize = false;
        }

        private void UnListenButtonEvents(Button btn) {
            if (btn != null) {
                btn.MouseHover -= btn_MouseHover;
                btn.MouseLeave -= btn_MouseLeave;
                btn.MouseMove -= btn_MouseMove;
                btn.Paint -= btn_Paint;
                btn.SizeChanged -= (o, e) => OnResize(e);
                btn.Click -= btn_Click;
            }
        }

        private void UnListenPropertyChanged(EditorButton btn) {
            if (btn != null)
                btn.PropertyChanged -= btn_PropertyChanged;
        }

        #endregion
    }
}