////编写者：李开林
////日  期：2009-11-18
////功  能：用户信息管理的数据访问

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DbCtrl;
using Entity;

namespace DAL
{
    public class WorkerInfoDAL
    {
        private string sqlString;
        private DataProvider dp = new DataProvider();

        #region 添加新工作人员

        /// <summary>
        /// 添加新用户
        /// </summary>
        /// <param name="newWorker">新实体对象</param>
        /// <returns>bool值</returns>

        public bool AddWorkerInfo(WorkerInfo newWorker)
        {
            sqlString = "Insert Into workerInfo (workerID,workerNum,shopID,workerRealName,manageID,emailAdd,phoneNum,workerLv,workerState)"
                        + "Values (@workerID,@workerNum,@shopID,@workerRealName,@manageID,@emailAdd,@phoneNum,@workerLv,@workerState)";

            SqlParameter[] pt = new SqlParameter[] { 
                                new SqlParameter("@workerID", SqlDbType.UniqueIdentifier),
                                new SqlParameter("@workerNum",SqlDbType.Int),
                                new SqlParameter("@shopID",SqlDbType.Int),
                                new SqlParameter("@workerRealName",SqlDbType.VarChar),
                                new SqlParameter("@manageID",SqlDbType.UniqueIdentifier),
                                new SqlParameter("@emailAdd",SqlDbType.VarChar),
                                new SqlParameter("@phoneNum",SqlDbType.VarChar),
                                new SqlParameter("@workerLv",SqlDbType.Int),
                                new SqlParameter("@workerState",SqlDbType.Int),
                                };
            pt[0].Value = newWorker.WorkerID;
            pt[1].Value = newWorker.WorkerNum;
            pt[2].Value = newWorker.ShopID;
            pt[3].Value = newWorker.WorkerRealName;
            pt[4].Value = newWorker.ManageID;
            pt[5].Value = newWorker.EmailAdd;
            pt[6].Value = newWorker.PhoneNum;
            pt[7].Value = newWorker.WorkerLv;
            pt[8].Value = 0;

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

        #region 删除单个用户

        /// <summary>
        /// 删除单个用户
        /// </summary>
        /// <param name="userID">用户的id值</param>
        /// <returns>bool</returns>

        public bool DeleteWorkerInfo(Guid userID)////////////////数据字段需要更改
        {
            sqlString = "delete from workerInfo where id = @userID";
            SqlParameter[] pt = new SqlParameter[] { 
                                new SqlParameter("@userID", SqlDbType.UniqueIdentifier)
                                };
            pt[0].Value = userID;

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

            }
            return true;
        }

        #endregion

        #region 修改用户信息

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="user">用户实体对象</param>
        /// <returns>bool值</returns>
        
        public bool ModiWorkerInfo(WorkerInfo user)
        {
            string sqlString = "Update workerInfo Set shopID = @shopID , manageID = @manageID , emailAdd = @emailAdd , phoneNum = @phoneNum , workerLv = @workerLv where workerID = @workerID";
            SqlParameter[] pt = new SqlParameter[] { 
                                new SqlParameter("@shopID", SqlDbType.Int),
                                new SqlParameter("@manageID", SqlDbType.UniqueIdentifier),
                                new SqlParameter("@emailAdd", SqlDbType.VarChar),
                                new SqlParameter("@phoneNum", SqlDbType.VarChar),
                                new SqlParameter("@workerLv", SqlDbType.Int),
                                new SqlParameter("@workerID", SqlDbType.UniqueIdentifier)
                                };
            pt[0].Value = user.ShopID;
            pt[1].Value = user.ManageID;
            pt[2].Value = user.EmailAdd;
            pt[3].Value = user.PhoneNum;
            pt[4].Value = user.WorkerLv;
            pt[5].Value = user.WorkerID;

            try
            {
                using (dp = new DataProvider())
                {
                    if (dp.ExecuteNonQuery(sqlString , pt) == 0)
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

        #region 显示所有工作人员

        /// <summary>
        /// 显示工作人员列表
        /// </summary>
        /// <param name="workerList">工作人员实体对象集合</param>
        /// <returns>集合元素个数</returns>
       
        public int ShowWorkerInfo (ref IList<WorkerInfo> workerList)
        {
            sqlString = "select * from workerInfo";
            
            try
            {
                using (dp = new DataProvider())
                {
                    using (SqlDataReader reader = dp.ExecuteReader(sqlString))
                    {
                        WorkerInfo user = null;
                        while (reader.Read())
                        {
                            user = new WorkerInfo();

                            user.WorkerID = reader.GetGuid(0);
                            user.WorkerRealName = reader.GetString(3);

                            workerList.Add(user);
                        }
                    }
                }
            }
            catch
            {

            }

            return workerList.Count;
        }

        #endregion

        #region 显示所有工作人员列表

        /// <summary>
        /// 显示所有工作人员列表
        /// </summary>
        /// <param name="workerList">工作人员实体对象集合</param>
        /// <returns>集合元素个数</returns>

        public bool ShowAllWorkerInfo(ref WorkerInfo user)
        {
            sqlString = "select * from workerInfo,shopInfo where workerInfo.shopID = shopInfo.shopID and workerInfo.workerID = @workerID";
            SqlParameter[] pt = new SqlParameter[]{
                                new SqlParameter("@workerID", SqlDbType.UniqueIdentifier)
                                };
            pt[0].Value = user.WorkerID;
            try
            {
                using (dp = new DataProvider())
                {
                    using (SqlDataReader reader = dp.ExecuteReader(sqlString, pt))
                    {
                        while (reader.Read())
                        {
                            user.WorkerID = reader.GetGuid(0);
                            user.WorkerNum = reader.GetInt32(1);
                            user.ShopID = reader.GetInt32(2);
                            user.WorkerRealName = reader.GetString(3);
                            user.ManageID = reader.GetGuid(4);
                            user.EmailAdd = reader.GetString(5);
                            user.PhoneNum = reader.GetString(6);
                            user.WorkerLv = reader.GetInt32(7);
                            user.WorkerState = reader.GetInt32(8);
                            user.ShopName = reader.GetString(10);
                        }
                    }
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        #endregion

        #region 显示所有工作人员列表

        /// <summary>
        /// 显示所有工作人员列表
        /// </summary>
        /// <param name="workerList">工作人员实体对象集合</param>
        /// <returns>集合元素个数</returns>

        public bool ShowWorkerOfManager(ref WorkerInfo user, Guid manageID)
        {
            sqlString = "select * from workerInfo,shopInfo where workerInfo.shopID = shopInfo.shopID and workerInfo.workerID = @workerID and workerInfo.manageID = @manageID";
            SqlParameter[] pt = new SqlParameter[]{
                                new SqlParameter("@workerID", SqlDbType.UniqueIdentifier),
                                new SqlParameter("@manageID",SqlDbType.UniqueIdentifier)
                                };
            pt[0].Value = user.WorkerID;
            pt[1].Value = manageID;
            try
            {
                using (dp = new DataProvider())
                {
                    using (SqlDataReader reader = dp.ExecuteReader(sqlString, pt))
                    {
                        while (reader.Read())
                        {
                            user.WorkerID = reader.GetGuid(0);
                            user.WorkerNum = reader.GetInt32(1);
                            user.ShopID = reader.GetInt32(2);
                            user.WorkerRealName = reader.GetString(3);
                            user.ManageID = reader.GetGuid(4);
                            user.EmailAdd = reader.GetString(5);
                            user.PhoneNum = reader.GetString(6);
                            user.WorkerLv = reader.GetInt32(7);
                            user.WorkerState = reader.GetInt32(8);
                            user.ShopName = reader.GetString(10);
                        }
                    }
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        #endregion

        # region 根据用户id查询用户

        /// <summary>
        /// 查询用户信息
        /// </summary>
        /// <param name="user">用户实体对象</param>
        /// <returns>bool值</returns>

        public bool SrchWorkerInfo(ref WorkerInfo user)
        {
            sqlString = "select * from workerInfo where workerID = @userID";
            SqlParameter[] pt = new SqlParameter[]{
                                new SqlParameter("@userID", SqlDbType.UniqueIdentifier)
                                };
            pt[0].Value = user.WorkerID;

            try
            {
                using (dp = new DataProvider())
                {
                    using (SqlDataReader reader = dp.ExecuteReader(sqlString, pt))
                    {
                        while (reader.Read())
                        {
                            user.WorkerID = reader.GetGuid(0);
                            user.WorkerNum = reader.GetInt32(1);
                            user.ShopID = reader.GetInt32(2);
                            user.WorkerRealName = reader.GetString(3);
                            user.ManageID = reader.GetGuid(4);
                            user.EmailAdd = reader.GetString(5);
                            user.PhoneNum = reader.GetString(6);
                            user.WorkerLv = reader.GetInt32(7);
                            user.WorkerState = reader.GetInt32(8);
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
        # endregion

        #region 显示所有负责人

        /// <summary>
        /// 显示负责人列表
        /// </summary>
        /// <param name="workerList">负责人实体对象集合</param>
        /// <returns>集合元素个数</returns>

        public int ShowWorkerInfo(ref IList<WorkerInfo> workerList,ShopInfo shopInfo)
        {
            sqlString = "select * from workerInfo where workerLv = 1 and shopID = @shopID";
            SqlParameter[] pt = new SqlParameter[]{
                                new SqlParameter("@shopID", SqlDbType.Int)
                                };
            pt[0].Value = shopInfo.ShopID;

            try
            {
                using (dp = new DataProvider())
                {
                    using (SqlDataReader reader = dp.ExecuteReader(sqlString,pt))
                    {
                        WorkerInfo user = null;
                        while (reader.Read())
                        {
                            user = new WorkerInfo();

                            user.WorkerID = reader.GetGuid(0);
                            user.WorkerRealName = reader.GetString(3);

                            workerList.Add(user);
                        }
                    }
                }
            }
            catch
            {
                return -1;
            }

            return workerList.Count;
        }

        #endregion

        #region 查询店面负责人员信息

        /// <summary>
        /// 查询店面负责人员信息
        /// </summary>
        /// <param name="shopManager">工作人员实体对象</param>
        /// <returns>操作成功返回true，否则返回false</returns>

        public bool SrchShopManager(ref WorkerInfo shopManager)
        {
            sqlString = "select * from workerInfo where shopID = @shopID and workerLv = 1";
            SqlParameter[] pt = new SqlParameter[]{
                                new SqlParameter("@shopID", SqlDbType.Int)
                                };
            pt[0].Value = shopManager.ShopID;

            try
            {
                using (dp = new DataProvider())
                {
                    using (SqlDataReader reader = dp.ExecuteReader(sqlString, pt))
                    {
                        while (reader.Read())
                        {
                            shopManager.WorkerID = reader.GetGuid(0);
                            shopManager.WorkerNum = reader.GetInt32(1);
                            shopManager.ShopID = reader.GetInt32(2);
                            shopManager.WorkerRealName = reader.GetString(3);
                            shopManager.ManageID = reader.GetGuid(4);
                            shopManager.EmailAdd = reader.GetString(5);
                            shopManager.PhoneNum = reader.GetString(6);
                            shopManager.WorkerLv = reader.GetInt32(7);
                            shopManager.WorkerState = reader.GetInt32(8);
                        }
                    }
                }
            }
            catch
            {
                ///////此处可以返回false
            }

            return true;
        }
        #endregion

        #region 选择店面送货人员

        /// <summary>
        /// 选择店面送货人员
        /// </summary>
        /// <param name="workerInfo">工作人员实体对象</param>
        /// <returns>操作成功返回true，否则返回false</returns>

        public bool SelectWorkerByShop(ref WorkerInfo workerInfo)
        {
            sqlString = "select top 1 * from workerInfo where shopID = @shopID and workerLv = 0 order by workerState ASC";
            SqlParameter[] pt = new SqlParameter[]{
                                new SqlParameter("@shopID", SqlDbType.Int)
                                };
            pt[0].Value = workerInfo.ShopID;

            try
            {
                using (dp = new DataProvider())
                {
                    using (SqlDataReader reader = dp.ExecuteReader(sqlString, pt))
                    {
                        while (reader.Read())
                        {
                            workerInfo.WorkerID = reader.GetGuid(0);
                            workerInfo.WorkerNum = reader.GetInt32(1);
                            workerInfo.ShopID = reader.GetInt32(2);
                            workerInfo.WorkerRealName = reader.GetString(3);
                            workerInfo.ManageID = reader.GetGuid(4);
                            workerInfo.EmailAdd = reader.GetString(5);
                            workerInfo.PhoneNum = reader.GetString(6);
                            workerInfo.WorkerLv = reader.GetInt32(7);
                            workerInfo.WorkerState = reader.GetInt32(8);
                        }
                    }
                }
            }
            catch
            {
                ///////此处可以返回false
            }

            return true;
        }

        #endregion

        #region 分配订单给某送货人员

        /// <summary>
        /// 分配订单给某送货人员
        /// </summary>
        /// <param name="workerInfo">工作人员实体对象</param>
        /// <returns>操作成功返回true，否则返回false</returns>

        public bool AssignOrder(WorkerInfo workerInfo)
        {
            string sqlString = "Update workerInfo Set workerState = @workerState where workerID = @workerID";
            SqlParameter[] pt = new SqlParameter[] { 
                                new SqlParameter("@workerID", SqlDbType.UniqueIdentifier),
                                new SqlParameter("@workerState", SqlDbType.Int) 
                                };
            pt[0].Value = workerInfo.WorkerID;
            pt[1].Value = workerInfo.WorkerState + 1;

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
    }
}
