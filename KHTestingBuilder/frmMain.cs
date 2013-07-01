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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// frmMain的唯一实例Instance
        /// </summary>
        private static volatile frmMain instance;

        /// <summary>
        /// 获取frmMain实例
        /// </summary>
        public static frmMain Instance
        {
            get { InitialInstance(); return instance; }
        }

        private static void InitialInstance()
        {
            if (instance == null)
            {
                instance = new frmMain();
            }
        }

        public List<TestingItemControl> TestingList = new List<TestingItemControl>();

        public InputAnalyzer inputAnalyzer = new InputAnalyzer();

        public bool IsCreated = false;

        private void tsmiOpenFromFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Title = "读取源文件";
            fd.Filter = "文本文件(*.txt)|*.txt";
            

            if (fd.ShowDialog() == DialogResult.OK)
            {
                inputAnalyzer = new InputAnalyzer();
                inputAnalyzer.GetText(fd.FileName);
                IsCreated = false;
                tsmiNewExam_Click(sender, e);
            }

        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
            foreach (TestingItem ti in ia.CreateTestingItem())
            {
                string sss = ti.Serial.ToString() + ". " + ti.Title + "\n";
                foreach (string s in ti.Options)
                {
                    sss += s;
                    sss += "\n";
                }          
                MessageBox.Show(sss);
            }
             */
        }

        /// <summary>
        /// 考卷生成
        /// </summary>
        private void tsmiNewExam_Click(object sender, EventArgs e)
        {
            TestingList.Clear();
            List<TestingItem> itemList = inputAnalyzer.CreateTestingItem();
            foreach (TestingItem ti in itemList)
            {
                TestingItemControl tic = new TestingItemControl();
                tic.Title = ti.Serial.ToString() + " . " + ti.Title;
                for(int i = ti.Options.Count-1 ; i >= 0  ; i-- )
                {
                    tic.Add(Convert.ToChar('A' + i).ToString() + "." + ti.Options[i],i);
                    if (Convert.ToChar('A' + i) == ti.Answer)
                    {
                        tic.rightID = i;
                    }
                }
                TestingList.Add(tic);
                tic.Answered += new EventHandler(tic_Answered);
                //考虑到没有题时也不能生成
                IsCreated = true;
            }
            if (!IsCreated)
            {
                if (DialogResult.OK == MessageBox.Show("请确定输入的源文件格式正确", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error))
                {
                    tsmiOpenFromFile_Click(sender, e);
                }
            }
            else
            {
                MessageBox.Show("考卷生成成功", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// 开始测试
        /// </summary>
        private void tsmiMessExam_Click(object sender, EventArgs e)
        {
            if (!IsCreated)
            {
                if (DialogResult.OK == MessageBox.Show("请先生成考卷\n是否需要自动生成？", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error))
                {
                    tsmiNewExam_Click(sender, e);
                }
                return;
            }
            if (TestingList.Count > 0)
            {
                this.panelTesting.Controls.Clear();
                this.panelTesting.Controls.Add(TestingList[0]);
                this.panelTesting.Height = TestingList[0].Height;
                this.Height = TestingList[0].GetHeight() + 110;
            }
        }

        /// <summary>
        /// 作答
        /// </summary>
        public void tic_Answered(object sender, EventArgs e)
        {
            int ID = 0;
            for(int i = 0 ; i < TestingList.Count; i++ )
            {
                if (TestingList[i] == (TestingItemControl)sender)
                {
                    ID = i + 1;
                }
            }
            this.panelTesting.Controls.Clear();
            if (ID != TestingList.Count)
            {
                this.panelTesting.Controls.Add(TestingList[ID]);
                //注意这里高度的获取！
                this.panelTesting.Height = TestingList[ID].Height;
                this.Height = TestingList[ID].GetHeight() + 110 ;
                //this.Height = TestingList[ID].Height + 70;
            }
            else TestEnd();
        }

        /// <summary>
        /// 转存考卷
        /// </summary>
        private void tsmiCreateTxt_Click(object sender, EventArgs e)
        {
            if (!IsCreated)
            {
                if (DialogResult.OK == MessageBox.Show("请先生成考卷\n是否需要自动生成？", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error))
                {
                    tsmiNewExam_Click(sender, e);
                }
                return;
            }
            string file = null;
            file = inputAnalyzer.Title + "\r\n\t";
            for (int i = 0; i < TestingList.Count; i++)
            {
                file += ( TestingList[i].Title + TestingList[i].returnString() + "\r\n\t");
            }
            file += "\r\n\t\r\n\t\r\nAnswer:\r\n\t";
            for (int i = 0; i < TestingList.Count; i++)
            {
                file += (Convert.ToString(i) + ": " + TestingList[i].returnAnswer().Split(new char[] { '\n' })[0] + "\r\n\t");
            }
            file += "\r\n\t";
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "保存生成的考卷";
            sfd.Filter = "文本文件(*.txt)|*.txt";
            sfd.FileName = Regex.Replace(inputAnalyzer.Title,".[tT][xX][tT][\b]*$","_") + "Test.txt";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamWriter sw = new StreamWriter(sfd.FileName,false);
                    sw.WriteLine(file);
                    sw.Close();
                }
                catch
                {
                    MessageBox.Show("生成失败!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }

        }

        public void TestEnd(){
            //string WrongNumber = "Wrong Number : ( Your Answer ) ( Right Answer) \r\n\t";
            ////foreach (TestingItemControl tic in TestingList)
            //for(int i = 0 ; i < TestingList.Count ; i++ )
            //{
            //    if (TestingList[i].selected != TestingList[i].rightID)
            //    {
            //        WrongNumber += (i+1).ToString() + "        :   " + Convert.ToChar(TestingList[i].selected + 'A').ToString() + "  "+ Convert.ToChar(TestingList[i].rightID + 'A').ToString() + "\r\n\t";
            //    }
            //}
            //MessageBox.Show(WrongNumber);
            frmGrade fg = new frmGrade();
            fg.ShowDialog();
        }

        private void 查看成绩ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!IsCreated)
            {
                if (DialogResult.OK == MessageBox.Show("请先生成考卷\n是否需要自动生成？", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error))
                {
                    tsmiNewExam_Click(sender, e);
                }
                return;
            }
            frmGrade fg = new frmGrade();
            fg.ShowDialog();
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsmiOpenInput_Click(object sender, EventArgs e)
        {
            frmSource fs = new frmSource();
            if (DialogResult.OK == fs.ShowDialog())
            {
                inputAnalyzer = new InputAnalyzer();
                inputAnalyzer.Text = fs.Value;
                IsCreated = false;
                tsmiNewExam_Click(sender, e);
            }
        }

        /// <summary>
        /// 查看考卷
        /// </summary>
        private void tsmiCheck_Click(object sender, EventArgs e)
        {
            if (!IsCreated)
            {
                if (DialogResult.OK == MessageBox.Show("请先生成考卷\n是否需要自动生成？", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error))
                {
                    tsmiNewExam_Click(sender, e);
                }
                return;
            }
            string file = null;
            file = inputAnalyzer.Title + "\r\n\t";
            for (int i = 0; i < TestingList.Count; i++)
            {
                file += (TestingList[i].Title + TestingList[i].returnString() + "\r\n\t");
            }
            file += "\r\n\t\r\n\t\r\nAnswer:\r\n\t";
            for (int i = 0; i < TestingList.Count; i++)
            {
                file += (Convert.ToString(i) + ": " + TestingList[i].returnAnswer().Split(new char[] { '\n' })[0] + "\r\n\t");
            }
            file += "\r\n\t";
            frmSource fs = new frmSource();
            fs.Value = file;
            fs.Text = "查看考卷";
            fs.Unable();
            fs.Show();
        }

        private void tsmiChange_Click(object sender, EventArgs e)
        {
            frmSource fs = new frmSource();
            fs.Value = inputAnalyzer.Text;
            fs.Text = "修改源文件";
            if (DialogResult.OK == fs.ShowDialog())
            {
                inputAnalyzer = new InputAnalyzer();
                inputAnalyzer.Text = fs.Value;
                IsCreated = false;
            }
        }

        private void tsmiHelpType_Click(object sender, EventArgs e)
        {
            frmHelpType fht = new frmHelpType();
            fht.ShowDialog();
        }

        private void 保存SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "保存生成的考卷";
            sfd.Filter = "文本文件(*.txt)|*.txt";
            sfd.FileName = inputAnalyzer.Title;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamWriter sw = new StreamWriter(sfd.FileName, false);
                    sw.WriteLine(inputAnalyzer.Text);
                    sw.Close();
                }
                catch
                {
                    MessageBox.Show("生成失败!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tsmiHelpEdition_Click(object sender, EventArgs e)
        {
            HelpEdition he = new HelpEdition();
            he.ShowDialog();
        }

        

        

       


    }
}
