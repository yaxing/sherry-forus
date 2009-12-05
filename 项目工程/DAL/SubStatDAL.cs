////编写者：林思然
////日  期：2009-11-26
////功  能：导入表分表的数据访问

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DbCtrl;
using Entity;

namespace DAL
{
    public class SubStatDAL
    {
        private string sqlString;
        private DataProvider dp = new DataProvider();

        #region 添加新导入表分表

        /// <summary>
        /// 添加新导入表分表
        /// </summary>
        /// <param name="newSubStat">新导入表分表实体对象</param>
        /// <returns>bool值</returns>

        public bool AddSubStat(SubStat newSubStat)
        {

            sqlString = "Insert Into SubStat (subStatID,mainStatID,goodsID,goodsName,Number,Price,Value) Values (@subStatID,@mainStatID,@goodsID,@goodsName,@Number,@Price,@Value)";

            SqlParameter[] pt = new SqlParameter[] { 
                                new SqlParameter("@subStatID", SqlDbType.UniqueIdentifier),
                                new SqlParameter("@mainStatID", SqlDbType.VarChar),
                                new SqlParameter("@goodsID", SqlDbType.VarChar),
                                new SqlParameter("@goodsName", SqlDbType.VarChar),
                                new SqlParameter("@Number", SqlDbType.Int),
                                new SqlParameter("@Price", SqlDbType.Float),
                                new SqlParameter("@Value", SqlDbType.Float),
                                };
            pt[0].Value = newSubStat.Id;
            pt[1].Value = newSubStat.mainStatID;
            pt[2].Value = newSubStat.goodsID;
            pt[3].Value = newSubStat.goodsName;
            pt[4].Value = newSubStat.number;
            pt[5].Value = newSubStat.price;
            pt[6].Value = newSubStat.value;

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

        #region 删除单个导入表分表

        /// <summary>
        /// 删除单个导入表分表
        /// </summary>
        /// <param name="subStatID">导入表分表ID</param>
        /// <returns>bool</returns>

        public bool DeleteSubStat(Guid subStatID)////////////////数据字段需要更改
        {
            sqlString = "delete from subStat where id = @subStatID";
            SqlParameter[] pt = new SqlParameter[] { 
                                new SqlParameter("@subStatID", SqlDbType.UniqueIdentifier)
                                };
            pt[0].Value = subStatID;

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

        #region 查询所有导入表分表

        /// <summary>
        /// 查询所有导入表分表
        /// </summary>
        /// <param name="subStatList">导入表分表实体对象集合</param>
        /// <returns>集合元素个数</returns>

        public int ShowWorkerInfo(ref IList<SubStat> subStatList)
        {
            sqlString = "select * from subStat";

            try
            {
                using (dp = new DataProvider())
                {
                    using (SqlDataReader reader = dp.ExecuteReader(sqlString))
                    {
                        SubStat subStat = null;
                        while (reader.Read())
                        {
                            subStat = new SubStat();

                            subStat.Id = reader.GetGuid(0);
                            subStat.mainStatID = reader.GetInt32(1);
                            subStat.goodsID = reader.GetInt32(2);
                            subStat.goodsName = reader.GetString(3);
                            subStat.number = reader.GetInt32(4);
                            subStat.price = reader.GetFloat(5);
                            subStat.value = reader.GetFloat(6);

                            subStatList.Add(subStat);
                        }
                    }
                }
            }
            catch
            {

            }

            return subStatList.Count;
        }

        #endregion

    }
}
