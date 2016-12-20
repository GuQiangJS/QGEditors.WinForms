namespace QGEditors.WinForms.DEMO
{
    partial class ButtonEditDemo
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
            QGEditors.WinForms.EditorButton editorButton2 = new QGEditors.WinForms.EditorButton();
            QGEditors.WinForms.EditorButton editorButton3 = new QGEditors.WinForms.EditorButton();
            this.splitContainerControl1 = new QGEditors.WinForms.SplitContainerControl();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonEdit1 = new QGEditors.WinForms.ButtonTextBoxControl();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.buttonEditAppearance1 = new QGEditors.WinForms.DEMO.ButtonEditAppearance();
            this.buttonEditAppearance2 = new QGEditors.WinForms.DEMO.ButtonEditAppearance();
            this.buttonEditAppearance3 = new QGEditors.WinForms.DEMO.ButtonEditAppearance();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.Panel1.SuspendLayout();
            this.splitContainerControl1.Panel2.SuspendLayout();
            this.splitContainerControl1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            // 
            // splitContainerControl1.Panel1
            // 
            this.splitContainerControl1.Panel1.Controls.Add(this.groupBox3);
            this.splitContainerControl1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainerControl1.Panel1.Padding = new System.Windows.Forms.Padding(5);
            // 
            // splitContainerControl1.Panel2
            // 
            this.splitContainerControl1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainerControl1.Panel2.Padding = new System.Windows.Forms.Padding(5);
            this.splitContainerControl1.Size = new System.Drawing.Size(530, 352);
            this.splitContainerControl1.SplitterDistance = 273;
            this.splitContainerControl1.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.richTextBox1);
            this.groupBox3.Location = new System.Drawing.Point(6, 102);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(262, 242);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "ButtonEvent";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(3, 17);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(256, 222);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.buttonEdit1);
            this.groupBox1.Location = new System.Drawing.Point(5, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(263, 91);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sample ButtonEdit";
            // 
            // buttonEdit1
            // 
            this.buttonEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            editorButton1.CaptionFont = new System.Drawing.Font("Arial Black", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            editorButton2.IsLeft = true;
            editorButton2.Kind = QGEditors.WinForms.ButtonPredefines.Undo;
            editorButton3.Caption = "ABC";
            editorButton3.CaptionFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            editorButton3.Kind = QGEditors.WinForms.ButtonPredefines.Glyph;
            editorButton3.Width = 31;
            this.buttonEdit1.Buttons.Add(editorButton1);
            this.buttonEdit1.Buttons.Add(editorButton2);
            this.buttonEdit1.Buttons.Add(editorButton3);
            this.buttonEdit1.Location = new System.Drawing.Point(22, 42);
            this.buttonEdit1.Name = "buttonEdit1";
            this.buttonEdit1.Size = new System.Drawing.Size(218, 21);
            this.buttonEdit1.TabIndex = 1;
            this.buttonEdit1.Text = "Sample Button Editor";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tabControl1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(5, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(243, 342);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Appearance";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 17);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(237, 322);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.buttonEditAppearance1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(229, 296);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Button #1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.buttonEditAppearance2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(229, 296);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Button #2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.buttonEditAppearance3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(229, 296);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Button #3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // buttonEditAppearance1
            // 
            this.buttonEditAppearance1.DataSource = null;
            this.buttonEditAppearance1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonEditAppearance1.Location = new System.Drawing.Point(3, 3);
            this.buttonEditAppearance1.Name = "buttonEditAppearance1";
            this.buttonEditAppearance1.Size = new System.Drawing.Size(223, 290);
            this.buttonEditAppearance1.TabIndex = 0;
            // 
            // buttonEditAppearance2
            // 
            this.buttonEditAppearance2.DataSource = null;
            this.buttonEditAppearance2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonEditAppearance2.Location = new System.Drawing.Point(3, 3);
            this.buttonEditAppearance2.Name = "buttonEditAppearance2";
            this.buttonEditAppearance2.Size = new System.Drawing.Size(223, 290);
            this.buttonEditAppearance2.TabIndex = 0;
            // 
            // buttonEditAppearance3
            // 
            this.buttonEditAppearance3.DataSource = null;
            this.buttonEditAppearance3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonEditAppearance3.Location = new System.Drawing.Point(3, 3);
            this.buttonEditAppearance3.Name = "buttonEditAppearance3";
            this.buttonEditAppearance3.Size = new System.Drawing.Size(223, 290);
            this.buttonEditAppearance3.TabIndex = 0;
            // 
            // ButtonEditDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 352);
            this.Controls.Add(this.splitContainerControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ButtonEditDemo";
            this.Text = "ButtonEditDemo";
            this.splitContainerControl1.Panel1.ResumeLayout(false);
            this.splitContainerControl1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private SplitContainerControl splitContainerControl1;
        private System.Windows.Forms.GroupBox groupBox1;
        private ButtonTextBoxControl buttonEdit1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private ButtonEditAppearance buttonEditAppearance1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TabPage tabPage2;
        private ButtonEditAppearance buttonEditAppearance2;
        private System.Windows.Forms.TabPage tabPage3;
        private ButtonEditAppearance buttonEditAppearance3;
    }
}