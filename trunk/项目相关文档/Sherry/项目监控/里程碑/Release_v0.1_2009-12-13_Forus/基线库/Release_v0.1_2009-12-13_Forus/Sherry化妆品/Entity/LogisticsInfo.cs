////编写者：李开林
////日  期：2009-12-8
////功  能：物流部分登记信息实体

using System;

namespace Entity
{
    public class LogisticsInfo
    {
        private int logisticsID;
        private Guid workerID;
        private int mainOrderID;
        private int logisticsType;


        public int LogisticsID
        {
            get { return logisticsID; }
            set { logisticsID = value; }
        }

        public Guid WorkerID
        {
            get { return workerID; }
            set { workerID = value; }
        }

        public int MainOrderID
        {
            get { return mainOrderID; }
            set { mainOrderID = value; }
        }

        public int LogisticsType
        {
            get { return logisticsType; }
            set { logisticsType = value; }
        }
    }
}
