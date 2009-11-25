////编写者：李开林
////日  期：2009-11-25
////功  能：普通用户信息实体类

using System;

namespace Entity
{
    public class UserInfo
    {
        private Guid userID;
        private string userRealName;
        private string emailAdd;
        private string postAdd;
        private string postNum;
        private string phoneNum;
        private int userScore;
        private int userLv;
        private DateTime userBirth;
        private int userGender;
        private int userAge;
        private string iDCardNum;

        public Guid UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        public string UserRealName
        {
            get { return userRealName; }
            set { userRealName = value; }
        }

        public string EmailAdd
        {
            get { return emailAdd; }
            set { emailAdd = value; }
        }

        public string PostAdd
        {
            get { return postAdd; }
            set { postAdd = value; }
        }

        public string PostNum
        {
            get { return postNum; }
            set { postNum = value; }
        }

        public string PhoneNum
        {
            get { return phoneNum; }
            set { phoneNum = value; }
        }

        public int UserScore
        {
            get { return userScore; }
            set { userScore = value; }
        }

        public int UserLv
        {
            get { return userLv; }
            set { userLv = value; }
        }

        public DateTime UserBirth
        {
            get { return userBirth; }
            set { userBirth = value; }
        }

        public int UserGender
        {
            get { return userGender; }
            set { userGender = value; }
        }

        public int UserAge
        {
            get { return userAge; }
            set { userAge = value; }
        }

        public string IDCardNum
        {
            get { return iDCardNum; }
            set { iDCardNum = value; }
        }
    }
}
