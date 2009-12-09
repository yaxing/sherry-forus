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

        #region 添加新用户

        /// <summary>
        /// 添加新用户
        /// </summary>
        /// <param name="newuser">新用户实体对象</param>
        /// <returns>bool值</returns>

        public bool AddWorkerInfo(WorkerInfo newuser)
        {
            sqlString = "Insert Into workerInfo (id) Values (@userID)";

            SqlParameter[] pt = new SqlParameter[] { 
                                new SqlParameter("@userID", SqlDbType.UniqueIdentifier)
                                };
            pt[0].Value = newuser.WorkerNum;

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
            string preSqlString = "Update workerInfo Set name = @userName";
            SqlParameter[] pt = new SqlParameter[] { 
                                new SqlParameter("@userName", SqlDbType.VarChar)
                                };
            pt[0].Value = user.WorkerRealName;

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

            }

            return true;
        }
        #endregion

        #region 显示所有用户

        /// <summary>
        /// 显示用户列表
        /// </summary>
        /// <param name="userList">用户实体对象集合</param>
        /// <returns>集合元素个数</returns>
       
        public int ShowWorkerInfo (ref IList<WorkerInfo> userList)
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

                            user.WorkerNum = reader.GetGuid(0);
                            user.WorkerRealName = reader.GetString(1);

                            userList.Add(user);
                        }
                    }
                }
            }
            catch
            {

            }

            return userList.Count;
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
            sqlString = "select * from workerInfo where id = @userID";
            SqlParameter[] pt = new SqlParameter[]{
                                new SqlParameter("@userID", SqlDbType.UniqueIdentifier)
                                };
            pt[0].Value = user.WorkerNum;

            try
            {
                using (dp = new DataProvider())
                {
                    using (SqlDataReader reader = dp.ExecuteReader(sqlString, pt))
                    {
                        while (reader.Read())
                        {
                            user.WorkerNum = reader.GetGuid(0);
                            user.WorkerRealName = reader.GetString(1);
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
        # endregion

        #region 查询店面负责人员信息

        /// <summary>
        /// 查询店面负责人员信息
        /// </summary>
        /// <param name="shopManager">工作人员实体对象</param>
        /// <returns>操作成功返回true，否则返回false</returns>

        public bool SrchShopManager(ref WorkerInfo shopManager)
        {
            sqlString = "select * from workerInfo where shipID = @shopID and manageID = workerNum";
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
                            shopManager.WorkerNum = reader.GetGuid(0);
                            shopManager.ShopID = reader.GetInt32(1);
                            shopManager.WorkerRealName = reader.GetString(2);
                            shopManager.ManageID = reader.GetGuid(3);
                            shopManager.EmailAdd = reader.GetString(4);
                            shopManager.PhoneNum = reader.GetString(5);
                            shopManager.WorkerLv = reader.GetInt32(6);
                            shopManager.UserBirth = reader.GetDateTime(7);
                            shopManager.UserGender = reader.GetInt32(8);
                            shopManager.UserAge = reader.GetInt32(9);
                            shopManager.WorkerState = reader.GetInt32(10);
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
            sqlString = "select top 1 from workerInfo where shipID = @shopID order by workerState ASC";
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
                            workerInfo.WorkerNum = reader.GetGuid(0);
                            workerInfo.ShopID = reader.GetInt32(1);
                            workerInfo.WorkerRealName = reader.GetString(2);
                            workerInfo.ManageID = reader.GetGuid(3);
                            workerInfo.EmailAdd = reader.GetString(4);
                            workerInfo.PhoneNum = reader.GetString(5);
                            workerInfo.WorkerLv = reader.GetInt32(6);
                            workerInfo.UserBirth = reader.GetDateTime(7);
                            workerInfo.UserGender = reader.GetInt32(8);
                            workerInfo.UserAge = reader.GetInt32(9);
                            workerInfo.WorkerState = reader.GetInt32(10);
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
            string preSqlString = "Update workerInfo Set workerState = @workerState where workerNum = @workerNum";
            SqlParameter[] pt = new SqlParameter[] { 
                                new SqlParameter("@workerNum", SqlDbType.UniqueIdentifier),
                                new SqlParameter("@workerState", SqlDbType.Int) 
                                };
            pt[0].Value = workerInfo.WorkerNum;
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
