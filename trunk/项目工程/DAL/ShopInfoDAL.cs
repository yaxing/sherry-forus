////编写者：李开林
////日  期：2009-12-9
////功  能：店面信息数据访问操作

using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using DbCtrl;
using Entity;

namespace DAL
{
    public class ShopInfoDAL
    {
        private string sqlString = string.Empty;
        private DataProvider dp;

        #region 根据地址查询店面信息

        /// <summary>
        /// 根据地址查询店面信息
        /// </summary>
        /// <param name="shopInfo">店面信息实体对象</param>
        /// <returns>操作成功返回true，否则返回false</returns>

        public bool SrchShopInfoByAdd(ref ShopInfo shopInfo)
        {
            sqlString = "select * from shopInfo where area = @area";
            SqlParameter[] pt = new SqlParameter[]{
                                new SqlParameter("@area", SqlDbType.VarChar)
                                };
            pt[0].Value = shopInfo.Area;

            try
            {
                using (dp = new DataProvider())
                {
                    using (SqlDataReader reader = dp.ExecuteReader(sqlString, pt))
                    {
                        while (reader.Read())
                        {
                            shopInfo.ShopID = reader.GetInt32(0);
                            shopInfo.ShopName = reader.GetString(1);
                            shopInfo.ShopDescribe = reader.GetString(3);
                            shopInfo.Area = reader.GetString(4);
                        }
                    }
                }
            }
            catch
            {
                ///////此处可以返回false
                return false;
            }

            return true;
        }

        #endregion


        #region 根据地址查询店面信息

        /// <summary>
        /// 根据地址查询店面信息
        /// </summary>
        /// <param name="allShop">店面信息实体对象</param>
        /// <returns>店面数量,失败返回-1</returns>
         
        public int DisplayAllShop(ref IList<ShopInfo> allShop)
        {
            sqlString = "select shopID,shopName from shopInfo";
            ShopInfo shopInfo = null;

            try
            {
                using (dp = new DataProvider())
                {
                    using (SqlDataReader reader = dp.ExecuteReader(sqlString))
                    {
                        while (reader.Read())
                        {
                            shopInfo = new ShopInfo();
                            shopInfo.ShopID = reader.GetInt32(0);
                            shopInfo.ShopName = reader.GetString(1);
                            allShop.Add(shopInfo);
                        }
                    }
                }
            }
            catch
            {
                ///////此处可以返回false
                return -1;
            }

            return allShop.Count;
        }

        #endregion

        #region 根据省份查询店面列表

        ///<summary>
        ///根据省份查询店面列表
        ///</summary>
        ///<returns>店面数量,失败返回-1</returns>

        public int SrchShopByProvence(ref IList<ShopInfo> shopInfoList , string province)
        {
            sqlString = "select * from shopInfo where area in (select area from areaInfo where province = @province)";
            SqlParameter[] pt = new SqlParameter[]{
                                new SqlParameter("@province", SqlDbType.VarChar)
                                };
            pt[0].Value = province;

            try
            {
                using (dp = new DataProvider())
                {
                    using (SqlDataReader reader = dp.ExecuteReader(sqlString, pt))
                    {
                        ShopInfo shopInfo = null;
                        while (reader.Read())
                        {
                            shopInfo = new ShopInfo();
                            shopInfo.ShopID = reader.GetInt32(0);
                            shopInfo.ShopName = reader.GetString(1);
                            shopInfo.ShopDescribe = reader.GetString(3);
                            shopInfo.Area = reader.GetString(4);
                            shopInfoList.Add(shopInfo);
                        }
                    }
                }
            }
            catch
            {
                ///////此处可以返回false
                return -1;
            }

            return shopInfoList.Count;
        }

        #endregion
    }
}
