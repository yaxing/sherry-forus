////编写者：林思然
////日  期：2009-11-26
////功  能：投票表主表的数据访问

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DbCtrl;
using Entity;

namespace DAL
{
    public class MainPollDAL
    {
        private string sqlString;
        private DataProvider dp = new DataProvider();

        #region 添加投票表主表

        /// <summary>
        /// 添加投票表主表
        /// </summary>
        /// <param name="newMainPoll">投票表主表实体对象</param>
        /// <returns>ID值</returns>

        public int AddMainPoll(MainPoll newMainPoll)
        {
            sqlString = "Insert Into MainPoll (topic,selectNum,singleMode,colMode) Values (@topic,@selectNum,@singleMode,@colMode)";

            SqlParameter[] pt = new SqlParameter[] { 
                                new SqlParameter("@topic", SqlDbType.VarChar),
                                new SqlParameter("@selectNum", SqlDbType.Int),
                                new SqlParameter("@singleMode", SqlDbType.VarChar),
                                new SqlParameter("@colMode", SqlDbType.VarChar),
                                };
            pt[0].Value = newMainPoll.Topic;
            pt[1].Value = newMainPoll.SelectNum;
            pt[2].Value = newMainPoll.SingleMode;
            pt[3].Value = newMainPoll.ColMode;
            try
            {
                using (dp = new DataProvider())
                {
                    newMainPoll.MainPollID = dp.ExecuteInsert(sqlString, pt);
                    if (newMainPoll.MainPollID == 0)
                        return -1;
                }
            }
            catch
            {
                return -1;
            }

            return newMainPoll.MainPollID;
        }
        #endregion

        #region 删除单个投票表主表

        /// <summary>
        /// 删除单个投票表主表
        /// </summary>
        /// <param name="mainPollID">投票表主表ID</param>
        /// <returns>bool</returns>

        public bool DeleteMainPoll(Guid mainPollID)
        {
            sqlString = "delete from MainPoll where id = @mainPollID";
            SqlParameter[] pt = new SqlParameter[] { 
                                new SqlParameter("@mainPollID", SqlDbType.UniqueIdentifier)
                                };
            pt[0].Value = mainPollID;

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

        #region 根据ID查投票表主表

        /// <summary>
        /// 根据ID查投票表主表
        /// </summary>
        /// <param name="mainPoll">投票表主表实体</param>
        /// <returns>集合元素个数</returns>

        public bool SelectByID(ref MainPoll mainPoll)
        {
            sqlString = "select * from MainPoll where mainPollID = " + mainPoll.MainPollID;

            try
            {
                using (dp = new DataProvider())
                {
                    using (SqlDataReader reader = dp.ExecuteReader(sqlString))
                    {
                        reader.Read();

                        mainPoll.Topic = reader.GetString(1);
                        mainPoll.SelectNum = reader.GetInt32(2);
                        mainPoll.SingleMode = reader.GetString(3);
                        mainPoll.ColMode = reader.GetString(4);
                    }
                }
            }
            catch
            {

            }

            return true;
        }

        #endregion

        #region 查询所有投票表主表

        /// <summary>
        /// 查询所有投票表主表
        /// </summary>
        /// <param name="mainPollList">投票表主表实体对象集合</param>
        /// <returns>集合元素个数</returns>

        public int ShowMainPoll(ref IList<MainPoll> mainPollList)
        {
            sqlString = "select * from MainPoll";

            try
            {
                using (dp = new DataProvider())
                {
                    using (SqlDataReader reader = dp.ExecuteReader(sqlString))
                    {
                        MainPoll mainPoll = null;
                        while (reader.Read())
                        {
                            mainPoll = new MainPoll();

                            mainPoll.MainPollID = reader.GetInt32(0);
                            mainPoll.Topic = reader.GetString(1);

                            mainPollList.Add(mainPoll);
                        }
                    }
                }
            }
            catch
            {

            }

            return mainPollList.Count;
        }

        #endregion

        #region 查询投票主表数

        /// <summary>
        /// 查询投票主表数
        /// </summary>
        /// <returns>投票表主表个数</returns>

        public int NumOfMainPoll()
        {
            sqlString = "select count(*) from MainPoll";

            try
            {
                using (dp = new DataProvider())
                {
                    using (SqlDataReader reader = dp.ExecuteReader(sqlString))
                    {
                        reader.Read();
                        return reader.GetInt32(0);
                    }
                }
            }
            catch
            {

            }
            return 0;
        }

        #endregion

        #region 查询主表的前N个表

        /// <summary>
        /// 查询主表的前N个表
        /// </summary>
        /// <param name="num">数量N</param>
        /// <returns>bool</returns>

        public bool SelectTopN(ref IList<MainPoll>mainPoll, int num)
        {
            sqlString = "select top " + num + " * from MainPoll";

            try
            {
                using (dp = new DataProvider())
                {
                    MainPoll newMainPoll = new MainPoll();
                    using (SqlDataReader reader = dp.ExecuteReader(sqlString))
                    {
                        while (reader.Read())
                        {
                            newMainPoll.MainPollID = reader.GetInt32(0);
                            newMainPoll.Topic = reader.GetString(1);
                            newMainPoll.SelectNum = reader.GetInt32(2);
                            newMainPoll.SingleMode = reader.GetString(3);
                            newMainPoll.ColMode = reader.GetString(4);

                            mainPoll.Add(newMainPoll);
                        }
                    }
                }
            }
            catch
            {

            }
            return true;
        }

        #endregion

        #region 查询主表的非第一个表

        /// <summary>
        /// 查询主表的非第一个表
        /// </summary>
        /// <param name="mainPoll">查询的数据集合</param>
        /// <param name="num">数量N</param>
        /// <param name="currentPage">数量N</param>
        /// <returns>bool</returns>

        public bool SelectTopMNotN(ref IList<MainPoll> mainPoll, int num, int currentPage)
        {
            sqlString = "select top " + num + " * from MainPoll where mainPollID not in (select top " + num * currentPage + " mainPollID from MainPoll)";

            try
            {
                using (dp = new DataProvider())
                {
                    MainPoll newMainPoll = new MainPoll();
                    using (SqlDataReader reader = dp.ExecuteReader(sqlString))
                    {
                        reader.Read();
                        newMainPoll.MainPollID = reader.GetInt32(0);
                        newMainPoll.Topic = reader.GetString(1);
                        newMainPoll.SelectNum = reader.GetInt32(2);
                        newMainPoll.SingleMode = reader.GetString(3);
                        newMainPoll.ColMode = reader.GetString(4);

                        mainPoll.Add(newMainPoll);
                    }
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
