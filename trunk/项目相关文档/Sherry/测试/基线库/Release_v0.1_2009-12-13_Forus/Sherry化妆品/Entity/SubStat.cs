using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class SubStat
    {

        private Guid subStatID;
        private int mainStatID;
        private int goodsID;
        private string goodsName;
        private int number;
        private float price;
        private float sum;

        public Guid SubStatID
        {
            get { return subStatID; }
            set { subStatID = value; }
        }

        public int MainStatID
        {
            get { return mainStatID; }
            set { mainStatID = value; }
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
        public float Sum
        {
            get { return sum; }
            set { sum = value; }
        }
    }
}
