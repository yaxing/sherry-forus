////��д�ߣ���˼Ȼ
////��  �ڣ�2009-11-25
////��  �ܣ�ͶƱ������ʵ����

using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class SubPoll
    {

        private int subPollID;
        private int mainPollID;
        private string description;
        private string color;
        private int num;

        public int SubPollID
        {
            get { return subPollID; }
            set { subPollID = value; }
        }
        public int MainPollID
        {
            get { return mainPollID; }
            set { mainPollID = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public string Color
        {
            get { return color; }
            set { color = value; }
        }
        public int Num
        {
            get { return num; }
            set { num = value; }
        }
    }
}
