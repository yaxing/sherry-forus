////编写者：李开林
////日  期：2009-1-3
////功  能：区域信息实体

namespace Entity
{
    public class AreaInfo
    {
        private int areaID;
        private string area;
        private string province;

        public int AreaID
        {
            get { return areaID; }
            set { areaID = value; }
        }

        public string Area
        {
            get { return area; }
            set { area = value; }
        }

        public string Province
        {
            get { return province; }
            set { province = value; }
        }
    }
}
