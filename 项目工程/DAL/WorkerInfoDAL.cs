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
            pt[0].Value = newuser.Id;

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
            pt[0].Value = user.Name;

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

                            user.Id = reader.GetGuid(0);
                            user.Name = reader.GetString(1);

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
                                new SqlParameter("@userID", SqlDbType.UniqueIdentifier),
                                };
            pt[0].Value = user.Id;

            try
            {
                using (dp = new DataProvider())
                {
                    using (SqlDataReader reader = dp.ExecuteReader(sqlString, pt))
                    {
                        while (reader.Read())
                        {
                            user.Id = reader.GetGuid(0);
                            user.Name = reader.GetString(1);
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
    }
}
