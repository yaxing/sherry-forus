////编写者：金哲宇
////日  期：2009-11-25
////功  能：市场决策模块所需的数据访问操作

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DbCtrl;
using Entity;

namespace DAL
{
    class MarketDecisionDAL
    {
        private string sqlString = string.Empty;
        private DataProvider dp;

        #region 返回某年龄段中的会员数
        /// <summary>
        /// 返回某年龄段中的会员数
        /// </summary>
        /// <param name="startingAge">起始年龄</param>
        /// <param name="endingAge">截止年龄</param>
        /// <returns>int值，返回某年龄段中的会员数</returns>
        public int CountMembersAgeGroup(int startingAge, int endingAge)
        {
            int num=0;
            if (endingAge < startingAge)
            {
                int tmp;
                tmp = startingAge;
                startingAge = endingAge;
                endingAge = tmp;
            }

            sqlString = "count * from userinfo where userage between @staringAge and @endingAge";
            SqlParameter[] pt = new SqlParameter[] { 
                                new SqlParameter("@staringAge", SqlDbType.Int),
                                new SqlParameter("@endingAge", SqlDbType.Int)
            };

            pt[0].Value=startingAge;
            pt[1].Value = endingAge;

            try
            {
                using (dp = new DataProvider())
                {
                    num=dp.ExecuteQuery(sqlString, pt);
                }
            }
            catch
            {
                return 0;
            }
            return num ;
        }
        #endregion


        #region 返回某年龄段中的会员在一定时间段内的消费额
        /// <summary>
        /// 返回某年龄段中的会员在一定时间段内的消费额
        /// </summary>
        /// <param name="startingDate">起始时间</param>
        /// <param name="endingDate">截止时间</param>
        /// <param name="startingAge">起始年龄</param>
        /// <param name="endingAge">截止年龄</param>
        /// <returns>double值，返回某年龄段中的会员在一定时间段内的消费额</returns>

        public double SumAgeGroupExpenditure(DateTime startingDate, DateTime endingDate, int startingAge, int endingAge)
        {
            sqlString = "select userID,userAge from userinfo as usertb where userage between staringAge and endingAge";
        }
        #endregion

    }
}
