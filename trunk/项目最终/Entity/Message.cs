using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class Message    //������
    {
        private int messageID;  //����ID
        private string topic;   //��������
        private string message; //��������
        private string reply;   //����Ա�ظ�

        public int MessageID
        {
            get { return messageID; }
            set { messageID = value; }
        }

        public string Topic
        {
            get { return topic; }
            set { topic = value; }
        }

        public string Messages
        {
            get { return message; }
            set { message = value; }
        }

        public string Reply
        {
            get { return reply; }
            set { reply = value; }
        }
    }
}
