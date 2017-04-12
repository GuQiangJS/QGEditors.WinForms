// QGEditor
// Copyright (c) 2014-2016 GuQiang - <guqiangjs@gmail.com>
// ALL RIGHTS RESERVED

#region

using System;
using System.Windows.Forms;

#endregion

namespace QGEditors.WinForms.DEMO {
    public partial class ButtonEditControlDemo : Form {
        #region Constructors

        public ButtonEditControlDemo() {
            InitializeComponent();

            propertyGrid1.SelectedObject = buttonEdit1.Buttons[0];
            propertyGrid2.SelectedObject = buttonEdit1.Buttons[1];
            propertyGrid3.SelectedObject = buttonEdit1.Buttons[2];

            buttonEdit1.ButtonClick += buttonEdit1_ButtonClick;
        }

        #endregion

        #region Methods

        private void buttonEdit1_ButtonClick(object sender, ButtonPressedEventArgs e) {
            if (richTextBox1.TextLength > 0)
                richTextBox1.AppendText(Environment.NewLine);
            var str = ObjectHelper.GetObjectText(e.Button);
            richTextBox1.AppendText(string.Format("Button {0} Click",
                string.IsNullOrEmpty(str) ? e.Button.Kind.ToString() : str));
        }

        #endregion

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            new ButtonPredefinesDemo().ShowDialog();
        }
    }
}