////编写者：陈亚星
////日  期：2009-12-24
////功  能：用户积分管理
using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Entity;
using DbCtrl;
using System.Web;
using System.Web.Security;
using System.Web.UI;

namespace DAL
{
    public class UserScoreDAL
    {
        DataTable dt;
        string sqlString = string.Empty;
        SqlParameter[] sq = null;
        DataProvider dp;

        #region 查询用户等级
        /// <summary>
        /// 查询用户等级
        /// </summary>
        /// <param name="userId,ref userLv">用户ID,用户等级</param>
        /// <returns>操作成功返回true，否则返回false</returns>
        public bool GetUserLv(Guid userId, ref int userLv) 
        {
            sqlString = "select userLv from userInfo where userID=@id";
            SqlParameter[] sp = new SqlParameter[] 
                                  {
                                      new SqlParameter("@id",SqlDbType.UniqueIdentifier)
                                  };
            sp[0].Value = userId;
            try
            {
                using (dp = new DataProvider())
                {
                    if ((dt = dp.ExecuteDataTable(sqlString, sp)) == null || dt.Rows.Count <= 0)
                    {
                        return false;
                    }
                }
            }
            catch
            {
                return false;
            }
            userLv = Convert.ToInt32(dt.Rows[0]["userLv"].ToString());
            return true;
        }
        #endregion

        #region 为用户积分添加积分
        /// <summary>
        /// 增加用户积分
        /// </summary>
        /// <param name="userId,score">用户ID，需要增加的积分或订单号， 判断是订单号(false)还是积分(true)</param>
        /// <returns>操作成功返回true，否则返回false</returns>
        public bool UpdateScore(Guid userId, int score, bool flag) 
        {
            if (!flag) 
            {
                sqlString = "select orderPrice from mainOrderInfo where mainOrderID=@id";
                sq = new SqlParameter[]
                                   {
                                       new SqlParameter("@id",SqlDbType.Int)
                                   };
                sq[0].Value = score;
                score = 0;
                try
                {
                    using (dp = new DataProvider())
                    {
                        if ((dt = dp.ExecuteDataTable(sqlString, sq)) == null || dt.Rows.Count <= 0)
                            return false;
                    }
                }
                catch
                {
                    return false;
                }

                double buffer = Convert.ToDouble(dt.Rows[0]["orderPrice"].ToString());
                score = Convert.ToInt32(buffer);
            }
            //=============================选出原积分===============================//
            sqlString = "select userScore from userInfo where userID=@id";
            sq = new SqlParameter[]
                                   {
                                       new SqlParameter("@id",SqlDbType.UniqueIdentifier)
                                   };
            sq[0].Value = userId;
            try
            {
                using (dp = new DataProvider())
                {
                    if ((dt = dp.ExecuteDataTable(sqlString,sq)) == null||dt.Rows.Count<=0)
                        return false;
                }
            }
            catch
            {
                return false;
            }
            score += Convert.ToInt32(dt.Rows[0]["userScore"].ToString());

            //================================更新积分========================//
            sqlString = "update userInfo set userScore=@s where userID=@id";
            sq = new SqlParameter[]
                                   {
                                       new SqlParameter("@s",SqlDbType.Int),
                                       new SqlParameter("@id",SqlDbType.UniqueIdentifier)
                                   };
            sq[0].Value = score;
            sq[1].Value = userId;

            try
            {
                using (dp = new DataProvider())
                {
                    if (dp.ExecuteNonQuery(sqlString, sq) == 0)
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
