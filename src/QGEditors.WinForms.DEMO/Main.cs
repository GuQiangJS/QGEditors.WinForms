// QGEditor
// Copyright (c) 2014-2016 GuQiang - <guqiangjs@gmail.com>
// ALL RIGHTS RESERVED

#region

using System.Windows.Forms;

#endregion

namespace QGEditors.WinForms.DEMO {
    public partial class Main : Form {
        public Main() {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            new ButtonEditControlDemo().Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            new SplitContainerControlDemo().ShowDialog();
        }
    }
}