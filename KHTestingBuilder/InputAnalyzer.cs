using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace KHTestingBuilder
{
    public class InputAnalyzer
    {
        public string Title
        {
            get;
            private set;
        }

        /// <summary>
        /// 设置和获取原文
        /// </summary>
        public string Text
        {
            get { return text; }
            set { text = value; }
        }
        protected string text = null;

        public void GetText(string strFilePath )
        {
            /**
            //读取文件到字节流data
            FileStream fs = new FileStream(strFilePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            byte[] data = new byte[fs.Length];
            int offset = 0;
            int remaining = data.Length;
            while (remaining > 0)
            {
                int read = fs.Read(data, offset, remaining);
                if(read <= 0 )
                {
                    throw new EndOfStreamException("文件读取到" + read.ToString() + "时失败"); 
                }
                remaining -= read;
                offset += read;
            }
            */

            Title = Path.GetFileName(strFilePath);
            StreamReader fm = new StreamReader(strFilePath);
            
            text = fm.ReadToEnd();
            fm.Close();
        }

        public List<List<string>> Analyze()
        {
            List<List<string>> result = new List<List<string>>();
            try
            {
                string[] analyze = Regex.Split(text, "[\b]*[0-9]{1,9}[.、．][\b]*");
                //char[] { '\n' },StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < analyze.Length; i++)
                {
                    if (analyze[i] == "" || Regex.IsMatch(analyze[i], "%\r\n\t")) continue;
                    result.Add(new List<string>());
                    foreach (string s in FindItem(analyze[i]))
                    {
                        result[result.Count - 1].Add(s);
                    }
                }
                
            }
            catch(ArgumentNullException)
            {
                //MessageBox.Show("请先打开或者输入一个文件");
            }
            return result;          
        }

        private string[] FindItem(string sentence)
        {
            return Regex.Split(sentence, "[A-Za-z][.、．][\b]*");    // r.Split(sentence);
        }

        public List<TestingItem> CreateTestingItem()
        {
            List<TestingItem> lti = new List<TestingItem>();
            List<List<string>> analyze = Analyze();
            int SCount = 1;
            for (int i = 0; i < analyze.Count; i++)
            {
                try
                {
                    Char answer ;
                    //if(Regex.IsMatch(analyze[i][0], "[(（【][\b]*[A-Za-z][\b]*[)）】]"))
                    //    answer = Regex.Match(Regex.Match(analyze[i][0], "[(（【][\b]*[A-Za-z][\b]*[)）】]").Value, "[A-Za-z]").Value[0];
                    //else 
                        //if(Regex.IsMatch(analyze[i][0], "[^A-Za-z][A-Za-z][^A-Za-z]"))
                    answer = Regex.Match(Regex.Match(analyze[i][0], "[^A-Za-z][A-Za-z][^A-Za-z]").Value, "[A-Za-z]").Value[0];
                    //analyze[i][0] = Regex.Replace(analyze[i][0], "[(（【][\b]*[A-Za-z][\b]*[)）】]", "( )");
                    analyze[i][0] = Regex.Replace(analyze[i][0], "[(（【][^A-Za-z(（【】）)]*[A-Za-z][^A-Za-z(（【】）)]*[)）】]", "( )");//不知道为啥[\b]*不行，郁闷
                    analyze[i][0] = Regex.Replace(analyze[i][0], "[^A-Za-z][\b]*" + Convert.ToString(answer) + "[\b]*[^A-Za-z]", "( )");
                    //MessageBox.Show(analyze[i][0]);
                    TestingItem ti = new TestingItem(analyze[i], answer);
                    if (ti.Options.Count > 0)
                    {
                        ti.Serial = SCount ++;
                        lti.Add(ti);
                    }
                }
                catch (IndexOutOfRangeException)
                {
                }
            }
            return lti;
        }
        
    }
}
