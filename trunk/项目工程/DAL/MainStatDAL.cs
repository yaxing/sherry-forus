////编写者：林思然
////日  期：2009-11-25
////功  能：导入数据主表操作

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DbCtrl;
using Entity;

namespace DAL
{
    public class MainStatDAL
    {
        private string sqlString = string.Empty;
        private DataProvider dp;

        #region 添加导入表主表

        /// <summary>
        /// 添加新导入表主表
        /// </summary>
        /// <param name="newStat">新导入表主表实体对象</param>
        /// <returns>bool值</returns>


        public bool AddMainStat(MainStat newStat)
        {
            sqlString = "Insert Into mainStat (mainStatID,Time,Value,Gender,Age,shopID,Province,soldType)"
                        + " Values (@mainStatID,@Time,@Value,@Gender,@Age,@shopID,@Province,@soldType)";

            SqlParameter[] pt = new SqlParameter[] { 
                                new SqlParameter("@mainStatID", SqlDbType.UniqueIdentifier),
                                new SqlParameter("@Time",SqlDbType.VarChar),
                                new SqlParameter("@Value",SqlDbType.VarChar),
                                new SqlParameter("@Gender",SqlDbType.VarChar),
                                new SqlParameter("@Age",SqlDbType.VarChar),
                                new SqlParameter("@shopID",SqlDbType.VarChar),
                                new SqlParameter("@Province",SqlDbType.Int),
                                new SqlParameter("@soldType",SqlDbType.Int),
                                };
            pt[0].Value = newStat.mainStatID;
            pt[1].Value = newStat.Time;
            pt[2].Value = newStat.Value;
            pt[3].Value = newStat.Gender;
            pt[4].Value = newStat.Age;
            pt[5].Value = newStat.shopID;
            pt[6].Value = newStat.Province;
            pt[7].Value = newStat.soldType;

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

        #region 删除导入表主表

        /// <summary>
        /// 删除导入表主表
        /// </summary>
        /// <param name="userID">导入表主表的id值</param>
        /// <returns>bool</returns>

        public bool DeleteMainStat(Guid mainStatID)////////////////数据字段需要更改
        {
            sqlString = "delete from mainStat where id = @mainStatID";
            SqlParameter[] pt = new SqlParameter[] { 
                                new SqlParameter("@mainStatID", SqlDbType.UniqueIdentifier)
                                };
            pt[0].Value = mainStatID;

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

        #region 查询所有导入表主表

        /// <summary>
        /// 查询所有导入表主表
        /// </summary>
        /// <param name="mainStatList">导入表主表实体对象集合</param>
        /// <returns>集合元素个数</returns>

        public int ShowUserInfo(ref IList<MainStat> mainStatList)
        {
            sqlString = "select * from mainStat";

            try
            {
                using (dp = new DataProvider())
                {
                    using (SqlDataReader reader = dp.ExecuteReader(sqlString))
                    {
                        MainStat mainStat = null;
                        while (reader.Read())
                        {
                            mainStat = new MainStat();

                            mainStat.mainStatID = reader.GetGuid(0);
                            mainStat.Time = reader.GetString(1);
                            mainStat.Value = reader.GetString(2);
                            mainStat.Gender = reader.GetString(3);
                            mainStat.Age = reader.GetString(4);
                            mainStat.shopID = reader.GetString(5);
                            mainStat.Province = reader.GetInt32(6);
                            mainStat.soldType = reader.GetInt32(7);

                            mainStatList.Add(mainStat);
                        }
                    }
                }
            }
            catch
            {
                return 0;
            }

            return mainStatList.Count;
        }

        #endregion

    }
}
