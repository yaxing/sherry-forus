////编写者：陈亚星
////日  期：2009-12-12
////功  能：订单实体
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Entity
{
    public class OrderInfo
    {
        private int orderID;
        private Guid userID = Guid.Empty;
        private string userRealName = string.Empty;
        private string userAdd = string.Empty;
        private string userZip = string.Empty;
        private string userTel = string.Empty;
        private string userProvince = string.Empty;
        private double userOrderPrice = 0.0;
        private int userPayState = 0;
        private string invoiceHead = string.Empty;
        private string invoiceContent = string.Empty;
        private string orderTime = string.Empty;
        private int state = 0;
        private IList<ItemEntity> userOrderItems = null;

        public int OrderID 
        {
            get { return orderID; }
            set { orderID = value; }
        }

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
        public string UserAdd
        {
            get { return userAdd; }
            set { userAdd = value; }
        }
        public string UserZip
        {
            get { return userZip; }
            set { userZip = value; }
        }
        public string UserTel
        {
            get { return userTel; }
            set { userTel = value; }
        }
        public string UserProvince
        {
            get { return userProvince; }
            set { userProvince = value; }
        }
        public double UserOrderPrice 
        {
            get { return userOrderPrice; }
            set { userOrderPrice = value; }
        }
        public int UserPayState
        {
            get { return userPayState; }
            set { userPayState = value; }
        }
        public IList<ItemEntity> UserOrderItems
        {
            get { return userOrderItems; }
            set { userOrderItems = value; }
        }
        public string InvoiceHead 
        {
            get { return invoiceHead; }
            set { invoiceHead = value; }
        }
        public string InvoiceContent 
        {
            get { return invoiceContent; }
            set { invoiceContent = value; }
        }
        public int State 
        {
            get { return state; }
            set { state = value; }
        }
        public string OrderTime 
        {
            get { return orderTime; }
            set { orderTime = value; }
        }

        public int GoodsNumber 
        {
            get { return userOrderItems.Count; }
        }
    }
}
