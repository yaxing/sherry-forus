using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class AdminInfo:UserInfo
    {
        private Guid adminID;
        private string adminRealName;
        private string adminEmailAdd;
        private string adminPhoneNum;
        private int adminLv;

        public Guid AdminID
        {
            get { return adminID; }
            set { adminID = value; }
        }

        public string AdminRealName
        {
            get { return adminRealName; }
            set { adminRealName = value; }
        }

        public string AdminEmailAdd
        {
            get { return adminEmailAdd; }
            set { adminEmailAdd = value; }
        }

        public string AdminPhoneNum
        {
            get { return adminPhoneNum; }
            set { adminPhoneNum = value; }
        }

        public int AdminLv
        {
            get { return adminLv; }
            set { adminLv = value; }
        }
    }
}
