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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplitContainerControlDemo));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.splitContainerControl1 = new QGEditors.WinForms.SplitContainerControl();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.splitContainerControl2 = new QGEditors.WinForms.SplitContainerControl();
            this.splitContainerControl3 = new QGEditors.WinForms.SplitContainerControl();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            this.splitContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl3)).BeginInit();
            this.splitContainerControl3.Panel1.SuspendLayout();
            this.splitContainerControl3.Panel2.SuspendLayout();
            this.splitContainerControl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.splitContainerControl1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(575, 218);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Default SplitterImage";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(3, 18);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Size = new System.Drawing.Size(569, 197);
            this.splitContainerControl1.SplitterDistance = 183;
            this.splitContainerControl1.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.splitContainerControl2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(575, 215);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Customer SplitterImage";
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl2.Location = new System.Drawing.Point(3, 18);
            this.splitContainerControl2.Name = "splitContainerControl2";
            this.splitContainerControl2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.splitContainerControl2.Size = new System.Drawing.Size(569, 194);
            this.splitContainerControl2.SplitterDistance = 95;
            this.splitContainerControl2.SplitterImage = ((System.Drawing.Image)(resources.GetObject("splitContainerControl2.SplitterImage")));
            this.splitContainerControl2.TabIndex = 2;
            // 
            // splitContainerControl3
            // 
            this.splitContainerControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl3.Location = new System.Drawing.Point(5, 5);
            this.splitContainerControl3.Name = "splitContainerControl3";
            this.splitContainerControl3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerControl3.Panel1
            // 
            this.splitContainerControl3.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainerControl3.Panel2
            // 
            this.splitContainerControl3.Panel2.Controls.Add(this.groupBox2);
            this.splitContainerControl3.Size = new System.Drawing.Size(575, 437);
            this.splitContainerControl3.SplitterDistance = 218;
            this.splitContainerControl3.TabIndex = 4;
            // 
            // SplitContainerControlDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 447);
            this.Controls.Add(this.splitContainerControl3);
            this.Name = "SplitContainerControlDemo";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SplitContainerControlDemo";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            this.splitContainerControl3.Panel1.ResumeLayout(false);
            this.splitContainerControl3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl3)).EndInit();
            this.splitContainerControl3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private SplitContainerControl splitContainerControl1;
        private System.Windows.Forms.GroupBox groupBox2;
        private SplitContainerControl splitContainerControl2;
        private SplitContainerControl splitContainerControl3;
    }
}