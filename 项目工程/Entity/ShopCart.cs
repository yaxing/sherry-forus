////��д�ߣ�������
////��  �ڣ�2009-12-03
////��  �ܣ����ﳵʵ��
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
