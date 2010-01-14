////编写者：林思然
////日  期：2009-11-25
////功  能：导入表副表实体类

using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class SubUpload  //上传表副表
    {

        private int subUploadID;    //副表ID
        private int mainUploadID;   //对应主表ID
        private int goodsID;        //商品ID
        private string goodsName;   //商品名
        private int number;         //商品数量
        private float price;        //商品价格
        private float totalValue;   //商品总价

        public int SubUploadID
        {
            get { return subUploadID; }
            set { subUploadID = value; }
        }

        public int MainUploadID
        {
            get { return mainUploadID; }
            set { mainUploadID = value; }
        }
        public int GoodsID
        {
            get { return goodsID; }
            set { goodsID = value; }
        }
        public string GoodsName
        {
            get { return goodsName; }
            set { goodsName = value; }
        }
        public int Number
        {
            get { return number; }
            set { number = value; }
        }
        public float Price
        {
            get { return price; }
            set { price = value; }
        }
        public float TotalValue
        {
            get { return totalValue; }
            set { totalValue = value; }
        }
    }
}
