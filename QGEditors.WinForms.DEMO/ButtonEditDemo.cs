using System;
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
    public partial class ButtonEditDemo : Form
    {
        public ButtonEditDemo()
        {
            InitializeComponent();

            EditorButton btn1=new EditorButton(ButtonPredefines.Plus);
            btn1.Shortcut = Keys.F10;

            this.buttonEdit1.Buttons.Add(btn1);

            EditorButton btn2 = new EditorButton();
            this.buttonEdit1.Buttons.Add(btn2);

            EditorButton btn3 = new EditorButton(ButtonPredefines.Glyph);
            btn3.Caption = "ABC";
            this.buttonEdit1.Buttons.Add(btn3);

            EditorButton btn4 = new EditorButton(ButtonPredefines.Undo);
            btn4.IsLeft = true;
            this.buttonEdit1.Buttons.Add(btn4);

            this.buttonEdit1.Text = "Sample Button Edit";

            this.buttonEdit1.KeyUp += buttonEdit1_KeyUp;

            this.appearance1.DataSource = btn1;
            this.appearance2.DataSource = btn2;
            this.appearance3.DataSource = btn3;
            this.appearance4.DataSource = btn4;
        }

        void buttonEdit1_KeyUp(object sender, KeyEventArgs e)
        {
            //this.richTextBox1.Text = string.Format("{0}{1}{2} KeyUp.", this.richTextBox1.Text, Environment.NewLine, e.KeyCode);
            //e.Handled = true;
        }

        private void buttonEdit1_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            //this.richTextBox1.Text = string.Format("{0}{1}{2} Click Kind:{3}.", this.richTextBox1.Text, Environment.NewLine, e.Button,e.Button.Kind);
        }
    }
}
