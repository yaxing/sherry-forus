////编写者：李开林
////日  期：2009-12-8
////功  能：物流信息登记数据访问操作

using System;
using System.Collections.Generic;
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
            sqlString = "Insert Into logisticsInfo (workerID,mainOrderID,logisticsType)"
                        + " Values (@workerID,@mainOrderID,@logisticsType)";

            SqlParameter[] pt = new SqlParameter[] { 
                                new SqlParameter("@workerID",SqlDbType.UniqueIdentifier),
                                new SqlParameter("@mainOrderID",SqlDbType.Int),
                                new SqlParameter("@logisticsType",SqlDbType.Int)
                                };
            pt[0].Value = logisticsInfo.WorkerID;
            pt[1].Value = logisticsInfo.MainOrderID;
            pt[2].Value = logisticsInfo.LogisticsType;

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

        #region 确定送货方式

        /// <summary>
        /// 确定送货方式
        /// </summary>
        /// <returns>1表示店面方式送货，2表示邮寄方式送货</returns>

        public int JudgeMode(OrderInfo orderInfo)
        {
            int mode = 2;
            int count = 0;
            sqlString = "select count(*) from shopInfo where area = @area";
            SqlParameter[] pt = new SqlParameter[] { 
                                new SqlParameter("@area",SqlDbType.VarChar)
                                };
            pt[0].Value = orderInfo.UserProvince;

            try
            {
                using (dp = new DataProvider())
                {
                    using (SqlDataReader reader = dp.ExecuteReader(sqlString, pt))
                    {
                        while (reader.Read())
                        {
                            count = reader.GetInt32(0);
                        }
                    }
                }
            }
            catch
            {
                return -1;
            }
            if (count > 0)
                mode = 1;
            return mode;
        }
        #endregion

        #region 实现根据送货人员ID查询订单列表ID

        /// <summary>
        /// 实现根据送货人员ID查询订单列表ID
        /// </summary>
        /// <param name="orderInfoList">订单列表</param>
        /// <param name="workerID">用户ID</param>
        /// <returns>返回列表个数，失败返回-1</returns>
        
        public int SrchOrderListByWorkerID(ref IList<OrderInfo> orderInfoList, Guid workerID)
        {
            sqlString = "select * from logisticsInfo where workerID = @workerID";

            SqlParameter[] pt = new SqlParameter[] { 
                                new SqlParameter("@workerID",SqlDbType.UniqueIdentifier)
                                };
            pt[0].Value = workerID;

            try
            {
                using (dp = new DataProvider())
                {
                    using (SqlDataReader reader = dp.ExecuteReader(sqlString, pt))
                    {
                        OrderInfo orderInfo = null;
                        while (reader.Read())
                        {
                            orderInfo = new OrderInfo();
                            orderInfo.OrderID = reader.GetInt32(2);
                            orderInfoList.Add(orderInfo);
                        }
                    }
                }
            }
            catch
            {
                return -1;
            }

            return orderInfoList.Count;
        }
        #endregion

        #region 实现根据管理人员ID查询订单列表ID

        /// <summary>
        /// 实现根据管理人员ID查询订单列表ID
        /// </summary>
        /// <param name="orderInfoList">订单列表</param>
        /// <param name="managerID">用户ID</param>
        /// <returns>返回列表个数，失败返回-1</returns>

        public int SrchOrderListByManagerID(ref IList<OrderInfo> orderInfoList, Guid managerID)
        {
            sqlString = "select * from logisticsInfo where workerID in (select workerID from workerInfo where manageID = @managerID) order by workerID";

            SqlParameter[] pt = new SqlParameter[] { 
                                new SqlParameter("@managerID",SqlDbType.UniqueIdentifier)
                                };
            pt[0].Value = managerID;

            try
            {
                using (dp = new DataProvider())
                {
                    using (SqlDataReader reader = dp.ExecuteReader(sqlString, pt))
                    {
                        OrderInfo orderInfo;
                        while (reader.Read())
                        {
                            orderInfo = new OrderInfo();
                            orderInfo.OrderID = reader.GetInt32(2);
                            orderInfoList.Add(orderInfo);
                        }
                    }
                }
            }
            catch
            {
                return -1;
            }

            return orderInfoList.Count;
        }
        #endregion
    }
}
