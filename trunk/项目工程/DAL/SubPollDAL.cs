////编写者：林思然
////日  期：2009-11-26
////功  能：投票表副表的数据访问

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DbCtrl;
using Entity;

namespace DAL
{
    public class SubPollDAL
    {
        private string sqlString;
        private DataProvider dp = new DataProvider();

        #region 添加投票表副表

        /// <summary>
        /// 添加投票表副表
        /// </summary>
        /// <param name="newSubPoll">投票表副表实体对象</param>
        /// <returns>bool值</returns>

        public bool AddSubPoll(SubPoll newSubPoll)
        {

            sqlString = "Insert Into SubPoll (mainPollID,description,num,color) Values (@mainPollID,@description,@num,@color)";

            SqlParameter[] pt = new SqlParameter[] { 
                                new SqlParameter("@mainPollID", SqlDbType.Int),
                                new SqlParameter("@description", SqlDbType.VarChar),
                                new SqlParameter("@num", SqlDbType.Int),
                                new SqlParameter("@color", SqlDbType.VarChar),
                                };
            pt[0].Value = newSubPoll.MainPollID;
            pt[1].Value = newSubPoll.Description;
            pt[2].Value = newSubPoll.Num;
            pt[3].Value = newSubPoll.Color;

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

        #region 删除单个投票表副表

        /// <summary>
        /// 删除单个投票表副表
        /// </summary>
        /// <param name="subPollID">投票表副表ID</param>
        /// <returns>bool</returns>

        public bool DeleteSubPoll(Guid subPollID)
        {
            sqlString = "delete from SubPoll where id = @subPollID";
            SqlParameter[] pt = new SqlParameter[] { 
                                new SqlParameter("@subPollID", SqlDbType.UniqueIdentifier)
                                };
            pt[0].Value = subPollID;

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

        #region 查询一个投票表主表的所有投票表副表

        /// <summary>
        /// 查询一个投票表主表的所有投票表副表
        /// </summary>
        /// <param name="subPollList">投票表副表实体对象集合</param>
        /// <returns>集合元素个数</returns>

        public int ShowSubPoll(ref IList<SubPoll> subPollList, int mainPollID)
        {
            sqlString = "select * from SubPoll where mainPollID = " + mainPollID;

            //try
            //{
                using (dp = new DataProvider())
                {
                    using (SqlDataReader reader = dp.ExecuteReader(sqlString))
                    {
                        SubPoll subPoll = null;
                        while (reader.Read())
                        {
                            subPoll = new SubPoll();

                            subPoll.SubPollID = reader.GetInt32(0);
                            subPoll.MainPollID = reader.GetInt32(1);
                            subPoll.Description = reader.GetString(2);
                            subPoll.Num = reader.GetInt32(3);
                            subPoll.Color = reader.GetString(4);

                            subPollList.Add(subPoll);
                        }
                    }
                }
            //}
            //catch
            //{

            //}

            return subPollList.Count;
        }

        #endregion

        #region 更新投票数

        /// <summary>
        /// 更新投票数
        /// </summary>
        /// <param name="subPoll">更新的分表</param>
        /// <returns>bool</returns>

        public bool UpdatePollNum(SubPoll subPoll)
        {
            sqlString = "update SubPoll set num = num + 1 where subPollID = " + subPoll.SubPollID;

            try
            {
                using (dp = new DataProvider())
                {
                    if (dp.ExecuteNonQuery(sqlString) == 0)
                        return false;
                }
            }
            catch
            {

            }

            return true;
        }

        #endregion

    }
}
