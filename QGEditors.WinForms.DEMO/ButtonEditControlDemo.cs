﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QGEditors.WinForms.DEMO
{
    public partial class ButtonEditControlDemo : Form
    {
        #region Constructors

        public ButtonEditControlDemo()
        {
            InitializeComponent();

            this.propertyGrid1.SelectedObject = this.buttonEdit1.Buttons[0];
            this.propertyGrid2.SelectedObject = this.buttonEdit1.Buttons[1];
            this.propertyGrid3.SelectedObject = this.buttonEdit1.Buttons[2];

            this.buttonEdit1.ButtonClick += buttonEdit1_ButtonClick;
        }

        #endregion

        #region Methods

        void buttonEdit1_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (this.richTextBox1.TextLength > 0)
            {
                this.richTextBox1.AppendText(System.Environment.NewLine);
            }
            string str = ObjectHelper.GetObjectText(e.Button);
            this.richTextBox1.AppendText(string.Format("Button {0} Click",(string.IsNullOrEmpty(str) ? e.Button.Kind.ToString() : str)));
        }

        #endregion

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new ButtonPredefinesDemo().ShowDialog();
        }
    }
}
