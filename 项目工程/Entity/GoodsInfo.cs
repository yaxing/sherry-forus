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
            goodsImg = "~/images/1.jpg";
            goodsPrice = 0;
            goodsValidity = DateTime.Now.AddYears(2);
            goodsAvailable = false;
            goodsStorage = 0;
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

        public string CategoryToString()
        {
            switch (goodsCategory)
            {
                case 1: return ("基础");
                case 2: return ("美白");
                case 3: return ("彩妆");
                case 4: return ("洗浴");
                case 5: return ("香品");
                default: return ("其他");
            }
        }
    }
}
