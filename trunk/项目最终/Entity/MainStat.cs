////编写者：林思然
////日  期：2009-11-25
////功  能：导入表主表实体类

using System;

namespace Entity
{
    public class MainStat
    {

        private Guid mainStatID;
        private DateTime time;
        private float value;
        private string gender;
        private int age;
        private int shopID;
        private string province;
        private int soldType;

        public Guid MainStatID
        {
            get { return mainStatID; }
            set { mainStatID = value; }
        }
        public DateTime Time
        {
            get { return time; }
            set { time = value; }
        }
        public float Value
        {
            get { return value; }
            set { value = value; }
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
