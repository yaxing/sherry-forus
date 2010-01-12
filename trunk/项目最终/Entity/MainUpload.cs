////编写者：林思然
////日  期：2009-11-25
////功  能：导入表主表实体类

using System;

namespace Entity
{
    public class MainUpload
    {

        private int mainUploadID;
        private DateTime sellTime;
        private float totalValue;
        private string gender;
        private int age;
        private int shopID;
        private string province;
        private int soldType;

        public int MainUploadID
        {
            get { return mainUploadID; }
            set { mainUploadID = value; }
        }
        public DateTime SellTime
        {
            get { return sellTime; }
            set { sellTime = value; }
        }
        public float TotalValue
        {
            get { return totalValue; }
            set { totalValue = value; }
        }
        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        public int ShopID
        {
            get { return shopID; }
            set { shopID = value; }
        }
        public string Province
        {
            get { return province; }
            set { province = value; }
        }
        public int SoldType
        {
            get { return soldType; }
            set { soldType = value; }
        }
    }
}
