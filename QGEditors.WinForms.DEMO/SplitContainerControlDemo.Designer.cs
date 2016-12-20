namespace QGEditors.WinForms.DEMO
{
    partial class SplitContainerControlDemo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            QGEditors.WinForms.EditorButton editorButton1 = new QGEditors.WinForms.EditorButton();
            this.splitContainerControl2 = new QGEditors.WinForms.SplitContainerControl();
            this.splitContainerControl1 = new QGEditors.WinForms.SplitContainerControl();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonTextBoxControl1 = new QGEditors.WinForms.ButtonTextBoxControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            this.splitContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.Panel2.SuspendLayout();
            this.splitContainerControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerControl2.Location = new System.Drawing.Point(0, 138);
            this.splitContainerControl2.Name = "splitContainerControl2";
            this.splitContainerControl2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.splitContainerControl2.Size = new System.Drawing.Size(284, 125);
            this.splitContainerControl2.SplitterDistance = 62;
            this.splitContainerControl2.TabIndex = 1;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            // 
            // splitContainerControl1.Panel2
            // 
            this.splitContainerControl1.Panel2.Controls.Add(this.buttonTextBoxControl1);
            this.splitContainerControl1.Panel2.Controls.Add(this.textBox1);
            this.splitContainerControl1.Size = new System.Drawing.Size(284, 132);
            this.splitContainerControl1.SplitterDistance = 92;
            this.splitContainerControl1.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(54, 58);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 0;
            // 
            // buttonTextBoxControl1
            // 
            editorButton1.IsLeft = true;
            this.buttonTextBoxControl1.Buttons.Add(editorButton1);
            this.buttonTextBoxControl1.Location = new System.Drawing.Point(31, 12);
            this.buttonTextBoxControl1.Name = "buttonTextBoxControl1";
            this.buttonTextBoxControl1.Size = new System.Drawing.Size(100, 21);
            this.buttonTextBoxControl1.TabIndex = 1;
            // 
            // SplitContainerControlDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.splitContainerControl2);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "SplitContainerControlDemo";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            this.splitContainerControl1.Panel2.ResumeLayout(false);
            this.splitContainerControl1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private SplitContainerControl splitContainerControl1;
        private SplitContainerControl splitContainerControl2;
        private System.Windows.Forms.TextBox textBox1;
        private ButtonTextBoxControl buttonTextBoxControl1;
    }
}