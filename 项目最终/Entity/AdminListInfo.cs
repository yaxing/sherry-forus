using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class AdminListInfo
    {
        private Guid adminID;
        private String adminName;
        private String adminType;
        private String state;
        private DateTime addTime;

        public Guid AdminID
        {
            get { return adminID; }
            set { adminID = value; }
        }

        public String AdminName
        {
            get { return adminName; }
            set { adminName = value; }
        }

        public String AdminType
        {
            get { return adminType; }
            set { adminType = value; }
        }

        public String State
        {
            get { return state; }
            set { state = value; }
        }

        public DateTime AddTime
        {
            get { return addTime; }
            set { addTime = value; }
        }
    }
}
