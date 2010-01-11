using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class GoodsInfo
    {
        public GoodsInfo()
        {
            goodsID = 0;
            goodsDescribe = "暂无产品描述。";
            goodsImg = "images/logo.jpg";
            goodsPrice = 0;
            goodsAvailable = false;
            goodsStorage = 0;
            goodsSpecialOffer = 0;
        }
        public int goodsID;
        public int goodsCategory;
        public DateTime goodsAddTime;
        public DateTime goodsValidity;
        public double goodsPrice;
        public bool goodsAvailable;
        public int goodsStorage;
        public string goodsNum;
        public string goodsName;
        public string goodsImg;
        public string goodsDescribe;
        public int goodsSpecialOffer;
    }
}
