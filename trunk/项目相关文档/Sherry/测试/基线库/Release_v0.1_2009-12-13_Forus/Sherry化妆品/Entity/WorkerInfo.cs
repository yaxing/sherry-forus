using System;

namespace Entity
{
    public class WorkerInfo
    {
        private Guid workerID;
        private int workerNum;
        private int shopID;
        private string workerRealName;
        private Guid manageID;
        private string emailAdd;
        private string phoneNum;
        private int workerLv;
        private int workerState;


        public Guid WorkerID
        {
            get { return workerID; }
            set { workerID = value; }
        }

        public int WorkerNum
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

        public int WorkerState
        {
            get { return workerState; }
            set { workerState = value; }
        }

    }
}
