////��д�ߣ���˼Ȼ
////��  �ڣ�2009-11-25
////��  �ܣ�ͶƱ������ʵ����

using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class MainPoll
    {

        private int mainPollID;
        private string topic;
        private int selectNum;
        private string singleMode;
        private string colMode;

        public int MainPollID
        {
            get { return mainPollID; }
            set { mainPollID = value; }
        }

        public string Topic
        {
            get { return topic; }
            set { topic = value; }
        }

        public int SelectNum
        {
            get { return selectNum; }
            set { selectNum = value; }
        }
        public string SingleMode
        {
            get { return singleMode; }
            set { singleMode = value; }
        }
        public string ColMode
        {
            get { return colMode; }
            set { colMode = value; }
        }
    }
}
