using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace KHTestingBuilder
{
    public class TestingItem
    {
        public TestingItem(List<string> ls, char answer)
            : base()
        {
            Title = ls[0];
            for (int i = 1; i < ls.Count; i++)
            {
                
                options.Add(Regex.Replace(ls[i], "\r\n\t$", "") );
            }

            Serial = 0;

            if ('a' <= answer && answer <= 'z')
            {
                Answer = (char)(answer - 'a' + 'A');
            }
            else Answer = answer;
        }

        /// <summary>
        /// 获取项目在测试中的题号
        /// </summary>
        public int Serial { get; set; }

        /// <summary>
        /// 获取和设置项目的标题
        /// </summary>
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        protected string title;

        /// <summary>
        /// 获取选项的列表
        /// </summary>
        public List<string> Options
        {
            set { options = value; }
            get { return options; }
        }
        protected List<string> options = new List<string>();

        /// <summary>
        /// 获取答案对应的项的序号
        /// </summary>
        public Char Answer { get; private set; }

        


    }
}
