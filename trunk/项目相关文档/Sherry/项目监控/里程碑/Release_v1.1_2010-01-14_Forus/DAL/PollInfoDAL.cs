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
    public class PollInfoDAL
    {
        private string sqlString;
        private DataProvider dp = new DataProvider();

        #region 主表操作

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

        #region 更新主表

        /// <summary>
        /// 更新主表
        /// </summary>
        /// <param name="mainPoll">主表实体</param>
        /// <returns>bool</returns>

        public bool UpdateMainPoll(MainPoll mainPoll)
        {
            sqlString = "update MainPoll set topic = " + mainPoll.Topic + " selectNum = " + mainPoll.SelectNum + " singleMode = " + mainPoll.SingleMode + " colMode = " + mainPoll.ColMode + " where mainPollID = " + mainPoll.MainPollID;
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

        #endregion

        #region 分表操作

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

        public bool UpdateSubPoll(SubPoll subPoll)
        {
            string subString = "set ";
            if (subPoll.Description.Length != 0)
            {
                subString += "description = " + subPoll.Description;
            }
            if (subPoll.Num != null)
            {
                if (subString.Length != 4)
                    subString += ",";
                subString += " num = " + subPoll.Num;
            }
            if (subPoll.Color.Length != 0)
            {
                if (subString.Length != 4)
                    subString += ",";
                subString += " color = " + subPoll.Color;
            }

            sqlString = "Update SubPoll " + subString + " where subPollID = " + subPoll.SubPollID;

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

        #endregion

        #region 删除投票表

        /// <summary>
        /// 根据主表ID删除投票表
        /// </summary>
        /// 

        public bool DeletePoll(int mainPollID)
        {
            sqlString = "delete from MainPoll where mainID = " + mainPollID + "delete from SubPoll where mainPollID = " + mainPollID;

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
