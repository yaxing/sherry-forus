////编写者：陈亚星
////日  期：2009-12-03
////功  能：购物车商品实体
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    #region 商品信息实体
    public class ItemEntity
    {
        public int id;
        public String name;
        public int number;
        public double price;

        public ItemEntity(int id, String name, int number, double price)
        {
            this.id = id;
            this.name = name;
            this.number = number;
            this.price = price;
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Number
        {
            get { return number; }
            set { number = value; }
        }

        public String ShowPrice
        {
            get { return String.Format("{0:C}", price); }
        }

        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        public String CurItemTotalPrice
        {
            get { return String.Format("{0:C}", price * number); }
        }
    }
    #endregion
}
