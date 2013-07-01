using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace KHTestingBuilder
{
    public partial class frmGrade : Form
    {
        public frmGrade()
        {
            InitializeComponent();
        }

        private void frmGrade_Load(object sender, EventArgs e)
        {
            //foreach (TestingItemControl tic in TestingList)
            this.listBox.Items.Clear();
            int Max = frmMain.Instance.TestingList.Count;
            int count = 0;
            for (int i = 0; i < Max; i++)
            {
                string lb;
                lb = (i + 1).ToString() + "     :   " + Convert.ToChar(frmMain.Instance.TestingList[i].selected + 'A').ToString() + "  " + Convert.ToChar(frmMain.Instance.TestingList[i].rightID + 'A').ToString() + "\r\n\t";
                if (frmMain.Instance.TestingList[i].selected != frmMain.Instance.TestingList[i].rightID)
                {
                    this.listBox.Items.Add(lb);
                    count++;
                    //this.panelAnswer.Controls.Add(lb);
                    //this.panelAnswer.Height += lb.Height;
                }
            }
            this.txtAccuracy.Text = "Accuracy:" + Convert.ToInt32(100*(Max - count) / Max).ToString() + "%"; 
        }

        //void lb_Click(object sender, EventArgs e)
        //{
        //    int ID = (int)((Label)sender).Tag;
        //    TestingItemControl tic = frmMain.Instance.TestingList[ID];
        //    this.textBox1.Text = "";
        //    this.textBox1.Text = (tic.Title + tic.returnString() + "\n\nYour Answer :  " + Convert.ToChar(tic.selected+'A').ToString() + "\nRight Answer : " + tic.returnAnswer() + "\r\n");
        //}

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string L = ((string)listBox.SelectedItem).Split(new char[]{' '})[0] ;
            int ID = 0;
            int.TryParse(L,out ID);
            ID -= 1;
            try
            {
                TestingItemControl tic = frmMain.Instance.TestingList[ID];
                this.textBox1.Text = "";
                this.textBox1.Text = (tic.Title + tic.returnString() + "\r\n\r\nYour Answer :  " + Convert.ToChar(tic.selected + 'A').ToString() + "\r\nRight Answer : " + tic.returnAnswer() + "\r\n");
            }
            catch
            {
            }
            
        }

        /// <summary>
        /// 重新生成考卷并不弹出提示
        /// </summary>
        private void buttonReset_Click(object sender, EventArgs e)
        {
            frmMain.Instance.TestingList.Clear();
            List<TestingItem> itemList = frmMain.Instance.inputAnalyzer.CreateTestingItem();
            foreach (TestingItem ti in itemList)
            {
                TestingItemControl tic = new TestingItemControl();
                tic.Title = ti.Serial.ToString() + " . " + ti.Title;
                for (int i = ti.Options.Count - 1; i >= 0; i--)
                {
                    tic.Add(Convert.ToChar('A' + i).ToString() + "." + ti.Options[i], i);
                    if (Convert.ToChar('A' + i) == ti.Answer)
                    {
                        tic.rightID = i;
                    }
                }
                frmMain.Instance.TestingList.Add(tic);
                tic.Answered += frmMain.Instance.tic_Answered;
                //考虑到没有题时也不能生成
                frmMain.Instance.IsCreated = true;
            }
            this.listBox.Items.Clear();
            this.textBox1.Text = "\r\n\t   成绩已清除";
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {       
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "保存生成的考试结果";
            sfd.Filter = "文本文件(*.txt)|*.txt";
            sfd.FileName = Regex.Replace(frmMain.Instance.inputAnalyzer.Title, ".[tT][xX][tT][\b]*$", "_") + "Grade.txt";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string WrongNumber = "Wrong Number : ( Your Answer ) ( Right Answer) \r\n\t";
                    //foreach (TestingItemControl tic in TestingList)
                    for (int i = 0; i < frmMain.Instance.TestingList.Count; i++)
                    {
                        if (frmMain.Instance.TestingList[i].selected != frmMain.Instance.TestingList[i].rightID)
                        {
                            WrongNumber += (i + 1).ToString() + "        :   " + Convert.ToChar(frmMain.Instance.TestingList[i].selected + 'A').ToString() + "  " + Convert.ToChar(frmMain.Instance.TestingList[i].rightID + 'A').ToString() + "\r\n\t";
                        }
                    }
                    WrongNumber += (this.txtAccuracy.Text + "\r\n\t");
                    StreamWriter sw = new StreamWriter(sfd.FileName, false);
                    sw.WriteLine(WrongNumber);
                    sw.Close();
                }
                catch
                {
                    MessageBox.Show("生成失败!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
