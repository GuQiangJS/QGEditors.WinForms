namespace QGEditors.WinForms.DEMO
{
    partial class ButtonEditDemo
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonEdit1 = new QGEditors.WinForms.ButtonEdit();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.appearance1 = new QGEditors.WinForms.DEMO.ButtonEditAppearance();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.appearance2 = new QGEditors.WinForms.DEMO.ButtonEditAppearance();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.appearance3 = new QGEditors.WinForms.DEMO.ButtonEditAppearance();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.appearance4 = new QGEditors.WinForms.DEMO.ButtonEditAppearance();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 12);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(573, 353);
            this.splitContainer1.SplitterDistance = 291;
            this.splitContainer1.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonEdit1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(291, 353);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "General";
            // 
            // buttonEdit1
            // 
            this.buttonEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEdit1.Location = new System.Drawing.Point(6, 142);
            this.buttonEdit1.Name = "buttonEdit1";
            this.buttonEdit1.Size = new System.Drawing.Size(279, 21);
            this.buttonEdit1.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tabControl1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(278, 353);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Appearance";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 17);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(272, 333);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.appearance1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(264, 307);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Button #1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // appearance1
            // 
            this.appearance1.DataSource = null;
            this.appearance1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.appearance1.Location = new System.Drawing.Point(3, 3);
            this.appearance1.Name = "appearance1";
            this.appearance1.Size = new System.Drawing.Size(258, 301);
            this.appearance1.TabIndex = 4;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.appearance2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(264, 307);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Button #2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // appearance2
            // 
            this.appearance2.DataSource = null;
            this.appearance2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.appearance2.Location = new System.Drawing.Point(3, 3);
            this.appearance2.Name = "appearance2";
            this.appearance2.Size = new System.Drawing.Size(186, 68);
            this.appearance2.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.appearance3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(264, 307);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Button #3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // appearance3
            // 
            this.appearance3.DataSource = null;
            this.appearance3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.appearance3.Location = new System.Drawing.Point(0, 0);
            this.appearance3.Name = "appearance3";
            this.appearance3.Size = new System.Drawing.Size(264, 307);
            this.appearance3.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.appearance4);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(264, 307);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Button #4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // appearance4
            // 
            this.appearance4.DataSource = null;
            this.appearance4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.appearance4.Location = new System.Drawing.Point(0, 0);
            this.appearance4.Name = "appearance4";
            this.appearance4.Size = new System.Drawing.Size(264, 307);
            this.appearance4.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 377);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private ButtonEdit buttonEdit1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private ButtonEditAppearance appearance1;
        private System.Windows.Forms.TabPage tabPage2;
        private ButtonEditAppearance appearance2;
        private System.Windows.Forms.TabPage tabPage3;
        private ButtonEditAppearance appearance3;
        private System.Windows.Forms.TabPage tabPage4;
        private ButtonEditAppearance appearance4;

    }
}

