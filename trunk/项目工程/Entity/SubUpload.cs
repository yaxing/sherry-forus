////��д�ߣ���˼Ȼ
////��  �ڣ�2009-11-25
////��  �ܣ��������ʵ����

using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class SubUpload
    {

        private int subUploadID;
        private int mainUploadID;
        private int goodsID;
        private string goodsName;
        private int number;
        private float price;
        private float totalValue;

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
