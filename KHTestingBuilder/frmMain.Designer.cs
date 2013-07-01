namespace KHTestingBuilder
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpenFromFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpenInput = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMethod = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiChange = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiNewExam = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMessExam = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCheck = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCreateTxt = new System.Windows.Forms.ToolStripMenuItem();
            this.查看成绩ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHelpType = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHelpEdition = new System.Windows.Forms.ToolStripMenuItem();
            this.panelTesting = new System.Windows.Forms.Panel();
            this.保存SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFile,
            this.tsmiMethod,
            this.tsmiHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(323, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmiFile
            // 
            this.tsmiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiOpen,
            this.保存SToolStripMenuItem,
            this.tsmiExit});
            this.tsmiFile.Name = "tsmiFile";
            this.tsmiFile.Size = new System.Drawing.Size(58, 21);
            this.tsmiFile.Text = "文件(&F)";
            // 
            // tsmiOpen
            // 
            this.tsmiOpen.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiOpenFromFile,
            this.tsmiOpenInput});
            this.tsmiOpen.Name = "tsmiOpen";
            this.tsmiOpen.Size = new System.Drawing.Size(154, 22);
            this.tsmiOpen.Text = "打开源文件(&O)";
            this.tsmiOpen.Click += new System.EventHandler(this.打开ToolStripMenuItem_Click);
            // 
            // tsmiOpenFromFile
            // 
            this.tsmiOpenFromFile.Name = "tsmiOpenFromFile";
            this.tsmiOpenFromFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.tsmiOpenFromFile.Size = new System.Drawing.Size(155, 22);
            this.tsmiOpenFromFile.Text = "从文件";
            this.tsmiOpenFromFile.Click += new System.EventHandler(this.tsmiOpenFromFile_Click);
            // 
            // tsmiOpenInput
            // 
            this.tsmiOpenInput.Name = "tsmiOpenInput";
            this.tsmiOpenInput.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.tsmiOpenInput.Size = new System.Drawing.Size(155, 22);
            this.tsmiOpenInput.Text = "输入";
            this.tsmiOpenInput.Click += new System.EventHandler(this.tsmiOpenInput_Click);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(154, 22);
            this.tsmiExit.Text = "退出(&E)";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // tsmiMethod
            // 
            this.tsmiMethod.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiChange,
            this.toolStripSeparator1,
            this.tsmiNewExam,
            this.tsmiMessExam,
            this.tsmiCheck,
            this.tsmiCreateTxt,
            this.查看成绩ToolStripMenuItem});
            this.tsmiMethod.Name = "tsmiMethod";
            this.tsmiMethod.Size = new System.Drawing.Size(59, 21);
            this.tsmiMethod.Text = "操作(&S)";
            // 
            // tsmiChange
            // 
            this.tsmiChange.Name = "tsmiChange";
            this.tsmiChange.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.tsmiChange.Size = new System.Drawing.Size(180, 22);
            this.tsmiChange.Text = "修改源文件";
            this.tsmiChange.Click += new System.EventHandler(this.tsmiChange_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // tsmiNewExam
            // 
            this.tsmiNewExam.Name = "tsmiNewExam";
            this.tsmiNewExam.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.tsmiNewExam.Size = new System.Drawing.Size(180, 22);
            this.tsmiNewExam.Text = "生成考卷";
            this.tsmiNewExam.Click += new System.EventHandler(this.tsmiNewExam_Click);
            // 
            // tsmiMessExam
            // 
            this.tsmiMessExam.Name = "tsmiMessExam";
            this.tsmiMessExam.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.tsmiMessExam.Size = new System.Drawing.Size(180, 22);
            this.tsmiMessExam.Text = "开始测试";
            this.tsmiMessExam.Click += new System.EventHandler(this.tsmiMessExam_Click);
            // 
            // tsmiCheck
            // 
            this.tsmiCheck.Name = "tsmiCheck";
            this.tsmiCheck.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.tsmiCheck.Size = new System.Drawing.Size(180, 22);
            this.tsmiCheck.Text = "查看考卷";
            this.tsmiCheck.Click += new System.EventHandler(this.tsmiCheck_Click);
            // 
            // tsmiCreateTxt
            // 
            this.tsmiCreateTxt.Name = "tsmiCreateTxt";
            this.tsmiCreateTxt.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.tsmiCreateTxt.Size = new System.Drawing.Size(180, 22);
            this.tsmiCreateTxt.Text = "转存考卷";
            this.tsmiCreateTxt.Click += new System.EventHandler(this.tsmiCreateTxt_Click);
            // 
            // 查看成绩ToolStripMenuItem
            // 
            this.查看成绩ToolStripMenuItem.Name = "查看成绩ToolStripMenuItem";
            this.查看成绩ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.查看成绩ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.查看成绩ToolStripMenuItem.Text = "查看成绩";
            this.查看成绩ToolStripMenuItem.Click += new System.EventHandler(this.查看成绩ToolStripMenuItem_Click);
            // 
            // tsmiHelp
            // 
            this.tsmiHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiHelpType,
            this.tsmiHelpEdition});
            this.tsmiHelp.Name = "tsmiHelp";
            this.tsmiHelp.Size = new System.Drawing.Size(61, 21);
            this.tsmiHelp.Text = "帮助(&H)";
            // 
            // tsmiHelpType
            // 
            this.tsmiHelpType.Name = "tsmiHelpType";
            this.tsmiHelpType.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.tsmiHelpType.Size = new System.Drawing.Size(160, 22);
            this.tsmiHelpType.Text = "使用说明(&T)";
            this.tsmiHelpType.Click += new System.EventHandler(this.tsmiHelpType_Click);
            // 
            // tsmiHelpEdition
            // 
            this.tsmiHelpEdition.Name = "tsmiHelpEdition";
            this.tsmiHelpEdition.Size = new System.Drawing.Size(160, 22);
            this.tsmiHelpEdition.Text = "版本说明(&B)";
            this.tsmiHelpEdition.Click += new System.EventHandler(this.tsmiHelpEdition_Click);
            // 
            // panelTesting
            // 
            this.panelTesting.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTesting.Location = new System.Drawing.Point(13, 29);
            this.panelTesting.Name = "panelTesting";
            this.panelTesting.Size = new System.Drawing.Size(293, 238);
            this.panelTesting.TabIndex = 1;
            // 
            // 保存SToolStripMenuItem
            // 
            this.保存SToolStripMenuItem.Name = "保存SToolStripMenuItem";
            this.保存SToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.保存SToolStripMenuItem.Text = "保存源文件(&S)";
            this.保存SToolStripMenuItem.Click += new System.EventHandler(this.保存SToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 279);
            this.Controls.Add(this.panelTesting);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Opacity = 0.99D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "测试生成器 @by Kinghand";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpen;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenFromFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenInput;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.ToolStripMenuItem tsmiMethod;
        private System.Windows.Forms.ToolStripMenuItem tsmiCheck;
        private System.Windows.Forms.ToolStripMenuItem tsmiChange;
        private System.Windows.Forms.ToolStripMenuItem tsmiCreateTxt;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewExam;
        private System.Windows.Forms.ToolStripMenuItem tsmiMessExam;
        private System.Windows.Forms.ToolStripMenuItem tsmiHelp;
        private System.Windows.Forms.ToolStripMenuItem tsmiHelpType;
        private System.Windows.Forms.ToolStripMenuItem tsmiHelpEdition;
        private System.Windows.Forms.Panel panelTesting;
        private System.Windows.Forms.ToolStripMenuItem 查看成绩ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存SToolStripMenuItem;
    }
}

