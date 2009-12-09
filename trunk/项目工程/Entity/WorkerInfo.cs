using System;

namespace Entity
{
    public class WorkerInfo
    {
        private Guid workerNum;
        private int shopID;
        private string workerRealName;
        private Guid manageID;
        private string emailAdd;
        private string phoneNum;
        private int workerLv;
        private DateTime userBirth;
        private int userGender;
        private int userAge;
        private int workerState;


        public Guid WorkerNum
        {
            get { return workerNum; }
            set { workerNum = value; }
        }

        public int ShopID
        {
            get { return shopID; }
            set { shopID = value; }
        }

        public string WorkerRealName
        {
            get { return workerRealName; }
            set { workerRealName = value; }
        }

        public Guid ManageID
        {
            get { return manageID; }
            set { manageID = value; }
        }

        public string EmailAdd
        {
            get { return emailAdd; }
            set { emailAdd = value; }
        }

        public string PhoneNum
        {
            get { return phoneNum; }
            set { phoneNum = value; }
        }

        public int WorkerLv
        {
            get { return workerLv; }
            set { workerLv = value; }
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

        public int WorkerState
        {
            get { return workerState; }
            set { workerState = value; }
        }

    }
}
