////编写者：李开林
////日  期：2009-12-8
////功  能：物流信息登记数据访问操作

using System.Data;
using System.Data.SqlClient;
using DbCtrl;
using Entity;

namespace DAL
{
    public class LogisticsInfoDAL
    {
        private string sqlString = string.Empty;
        private DataProvider dp;

        #region 添加新记录

        /// <summary>
        /// 添加新记录
        /// </summary>
        /// <param name="logisticsInfo">新记录实体对象</param>
        /// <returns>bool值</returns>

        public bool AddShippingInfo(LogisticsInfo logisticsInfo)
        {
            sqlString = "Insert Into logisticsInfo (logisticsID,workerID,mainOrderID,logisticsType)"
                        + " Values (@logisticsID,@workerID,@mainOrderID,@logisticsType)";

            SqlParameter[] pt = new SqlParameter[] { 
                                new SqlParameter("@logisticsID", SqlDbType.Int),
                                new SqlParameter("@workerID",SqlDbType.Int),
                                new SqlParameter("@mainOrderID",SqlDbType.Int),
                                new SqlParameter("@logisticsType",SqlDbType.Int)
                                };
            pt[0].Value = logisticsInfo.LogisticsID;
            pt[1].Value = logisticsInfo.WorkerID;
            pt[2].Value = logisticsInfo.MainOrderID;
            pt[3].Value = logisticsInfo.LogisticsType;

            try
            {
                using (dp = new DataProvider())
                {
                    if (dp.ExecuteNonQuery(sqlString, pt) == 0)
                        return false;
                }
            }
            catch
            {
                return false;
            }

            return true;
        }
        #endregion

        #region 查看送货信息

        /// <summary>
        /// 查询送货信息
        /// </summary>
        /// <param name="logisticsInfo">送货信息实体对象</param>
        /// <returns>成功返回true，否则返回false</returns>

        public bool SrchShippingInfo(ref LogisticsInfo logisticsInfo)
        {
            return true;
        }
        #endregion
    }
}
