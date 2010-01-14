using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class Message    //留言类
    {
        private int messageID;  //留言ID
        private string topic;   //留言主题
        private string message; //留言内容
        private string reply;   //管理员回复

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
