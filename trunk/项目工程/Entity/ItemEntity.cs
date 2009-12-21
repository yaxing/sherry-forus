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
        private int id;
        private String name = String.Empty;
        private int number;
        private double price;
        private String imgPath = String.Empty;
        private string discribe = string.Empty;
        private string goodsNum = string.Empty;
        private int goodsStorage;
        private int goodsCategory;
        private string categoryName;

        public ItemEntity() { }

        public ItemEntity(int id) 
        {
            this.id = id;
        }

        public ItemEntity(int id, String name, int number, double price, String imgPath)
        {
            this.id = id;
            this.name = name;
            this.number = number;
            this.price = price;
            this.imgPath = imgPath;
        }

        public String ImgPath 
        {
            get { return imgPath;}
            set { imgPath = value;}
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

        public string GoodsNum 
        {
            get {return  goodsNum; }
            set { goodsNum = value; }
        }

        public string Describe
        {
            get { return discribe; }
            set { discribe = value; }
        }

        public int GoodsStorage
        {
            get { return goodsStorage; }
            set { goodsStorage = value; }
        }

        public int GoodsCategory
        {
            get { return goodsCategory; }
            set { goodsCategory = value; }
        }

        public string CategoryName
        {
            get { return categoryName; }
            set { categoryName = value; }
        }
    }
    #endregion
}
