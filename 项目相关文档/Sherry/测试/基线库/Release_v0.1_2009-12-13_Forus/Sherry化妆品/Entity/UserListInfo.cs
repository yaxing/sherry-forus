////编写者：李开林
////日  期：2009-11-25
////功  能：普通用户列表显示的实体类

using System;

namespace Entity
{
    public class UserListInfo
    {
        private Guid userID;
        private string userName;
        private int score;
        private string level;
        private string state;
        private DateTime regTime;

        public Guid UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public int Score
        {
            get { return score; }
            set { score = value; }
        }

        public string Level
        {
            get { return level; }
            set { level = value; }
        }

        public string State
        {
            get { return state; }
            set { state = value; }
        }

        public DateTime RegTime
        {
            get { return regTime; }
            set { regTime = value; }
        }
    }
}
