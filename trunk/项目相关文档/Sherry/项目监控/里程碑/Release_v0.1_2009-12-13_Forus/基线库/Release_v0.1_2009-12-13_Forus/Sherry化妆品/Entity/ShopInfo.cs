////编写者：李开林
////日  期：2009-12-9
////功  能：店面信息实体类

namespace Entity
{
    public class ShopInfo
    {
        private int shopID;
        private string shopName;
        private string shopAdd;
        private string shopDescribe;

        public int ShopID
        {
            get { return shopID; }
            set { shopID = value; }
        }

        public string ShopName
        {
            get { return shopName; }
            set { shopName = value; }
        }

        public string ShopAdd
        {
            get { return shopAdd; }
            set { shopAdd = value; }
        }

        public string ShopDescribe
        {
            get { return shopDescribe; }
            set { shopDescribe = value; }
        }
    }
}
