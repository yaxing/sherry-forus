////编写者：李开林
////日  期：2009-12-9
////功  能：店面信息数据访问操作

using System.Data;
using System.Data.SqlClient;
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
            sqlString = "select * from shopInfo where shopAdd = @shopAdd";
            SqlParameter[] pt = new SqlParameter[]{
                                new SqlParameter("@shopAdd", SqlDbType.VarChar)
                                };
            pt[0].Value = shopInfo.ShopAdd;

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
    }
}
