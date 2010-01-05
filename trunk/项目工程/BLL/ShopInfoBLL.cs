////编写者：李开林
////日  期：2009-12-9
////功  能：店面信息管理的逻辑处理

using System.Collections.Generic;
using DAL;
using Entity;

namespace BLL
{
    public class ShopInfoBLL
    {

        #region 根据地址查询店面信息

        /// <summary>
        /// 根据地址查询店面信息
        /// </summary>
        /// <param name="shopInfo">店面信息实体对象</param>
        /// <returns>操作成功返回true，否则返回false</returns>

        public bool SrchShopInfoByAdd(ref ShopInfo shopInfo)
        {
            ShopInfoDAL shopInfoDAL = new ShopInfoDAL();
            return shopInfoDAL.SrchShopInfoByAdd(ref shopInfo);
        }

        #endregion

        #region 显示所有店面名称

        ///<summary>
        ///显示所有店面名称
        ///</summary>
        ///<returns>店面数量,失败返回-1</returns>
        
        public int DisplayAllShop(ref IList<ShopInfo> allShop)
        {
            ShopInfoDAL shopInfoDAL = new ShopInfoDAL();
            return shopInfoDAL.DisplayAllShop(ref allShop);
        }

        #endregion

        #region 根据省份查询店面列表

        ///<summary>
        ///根据省份查询店面列表
        ///</summary>
        ///<returns>店面数量,失败返回-1</returns>

        public int SrchShopByProvence(ref IList<ShopInfo> shopInfoList , string province)
        {
            ShopInfoDAL shopInfoDAL = new ShopInfoDAL();
            return shopInfoDAL.SrchShopByProvence(ref shopInfoList , province);
        }

        #endregion
    }
}
