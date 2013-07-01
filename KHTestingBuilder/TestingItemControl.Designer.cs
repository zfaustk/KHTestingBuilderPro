namespace KHTestingBuilder
{
    partial class TestingItemControl
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panelOption = new System.Windows.Forms.Panel();
            this.labTitle = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // panelOption
            // 
            this.panelOption.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelOption.Location = new System.Drawing.Point(12, 51);
            this.panelOption.Name = "panelOption";
            this.panelOption.Size = new System.Drawing.Size(306, 211);
            this.panelOption.TabIndex = 1;
            // 
            // labTitle
            // 
            this.labTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labTitle.Location = new System.Drawing.Point(12, 3);
            this.labTitle.Multiline = true;
            this.labTitle.Name = "labTitle";
            this.labTitle.ReadOnly = true;
            this.labTitle.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.labTitle.Size = new System.Drawing.Size(306, 42);
            this.labTitle.TabIndex = 2;
            // 
            // TestingItemControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.labTitle);
            this.Controls.Add(this.panelOption);
            this.Name = "TestingItemControl";
            this.Size = new System.Drawing.Size(336, 265);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelOption;
        private System.Windows.Forms.TextBox labTitle;
    }
}
