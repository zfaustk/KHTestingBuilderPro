using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KHTestingBuilder
{
    public partial class TestingItemControl : UserControl
    {
        public TestingItemControl()
        {
            InitializeComponent();
            selected = -1;
        }

        public string Title
        {
            set { this.labTitle.Text = value; }
            get { return this.labTitle.Text; }
        }

        public int rightID
        {
            get;
            set;
        }

        public int selected
        {
            get;
            set;
        }

        public int GetHeight()
        {
            return this.panelOption.Height + this.labTitle.Height;
        }

        public event EventHandler Answered;

        public void Add(string strOption, int ID)
        {
            Button btn = new Button();
            btn.Dock = DockStyle.Top;
            btn.Height = 72;
            btn.Text = strOption;
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.Tag = ID;
            btn.Click += new EventHandler(btn_Click);

            this.panelOption.Controls.Add(btn);
            this.panelOption.Height = 2;
            foreach (Control c in this.panelOption.Controls)
            {
                this.panelOption.Height += c.Height;  
            }
            this.Height = this.panelOption.Height + this.labTitle.Height + 32;
            this.Dock = DockStyle.Fill;
        }

        /// <summary>
        /// 当按钮被点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btn_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            foreach (Control c in this.panelOption.Controls)
            {
                selected = (int)((Button)sender).Tag;
            }
            this.Answered(this, e);
        }

        /// <summary>
        /// 重置到四个都未选择的状态
        /// </summary>
        public void ResetState()
        {
            foreach (Control c in this.panelOption.Controls)
            {
                c.Enabled = true;
            }
        }

        /// <summary>
        /// 显示正确答案
        /// </summary>
        public void ShowAnsuer()
        {
            foreach (Control c in this.panelOption.Controls)
            {
                if (c.Tag == null) continue;
                if ((int)c.Tag == rightID)
                    c.Enabled = true;
                else
                    c.Enabled = false;
            }
        }

        /// <summary>
        /// 返回各个选项的字符串
        /// </summary>
        public String returnString()
        {
            string sss = null;
            for (int i = this.panelOption.Controls.Count - 1; i >= 0; i--)
            {
                if (panelOption.Controls[i].Tag == null) continue;
                sss += ("    " + panelOption.Controls[i].Text.Trim() + "\r\n");
            }
            return sss;
        }

        /// <summary>
        /// 获取是正确答案的句子
        /// </summary>
        /// <returns></returns>
        public String returnAnswer()
        {
            string sss = "";
            for (int i = 0; i < this.panelOption.Controls.Count; i++)
            {
                if (panelOption.Controls[i].Tag == null) continue;
                if((int)panelOption.Controls[i].Tag == this.rightID )
                    sss = (panelOption.Controls[i].Text.Trim() + "\r\n\t");
            }
            return sss;
        }
    }
}
