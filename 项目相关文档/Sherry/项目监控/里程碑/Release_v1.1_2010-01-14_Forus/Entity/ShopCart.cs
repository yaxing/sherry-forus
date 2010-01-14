////编写者：陈亚星
////日  期：2009-12-03
////功  能：购物车实体
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Xml;

namespace Entity
{
    public class ShopCart
    {
        private Hashtable dic;
        private String userName;

        public Hashtable curDic
        {
            get { return dic; }
            set { dic = value; }
        }

        public String curUser 
        {
            get { return userName; }
            set { userName = value; }
        }
    }
}
