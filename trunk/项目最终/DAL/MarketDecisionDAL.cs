////编写者：金哲宇
////日  期：2009-11-25
////功  能：市场决策模块所需的数据访问操作

using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using DbCtrl;

namespace DAL
{
    static class SoldType
    {
        static public readonly SqlInt32 OnlineSail=new SqlInt32(0);
        static public readonly SqlInt32 PhoneSail=new SqlInt32(1);
    }

    public class MarketDecisionDAL : IDisposable
    {
        private readonly DataProvider dp = new DataProvider();

        #region IDisposable Members

        public void Dispose()
        {
            dp.Dispose();
        }

        #endregion

        /// <summary>
        ///  公共函数，执行查询语句
        /// </summary>
        /// <param name="sqlString">带参数的查询语句</param>
        /// <param name="pt">查询语句参数</param>
        /// <returns>int类型</returns>
        private int doQuery(string sqlString, SqlParameter[] pt)
        {
            DataTable dt;
            DataRow dr;
            string s;
            int num;
            try
            {
                dt = dp.ExecuteDataTable(sqlString, pt);
                dr = dt.Rows[0];
                s = dr[0].ToString();
                num = s.Length == 0 ? 0 : Convert.ToInt32(Convert.ToDouble(s));
            }
            catch (Exception e)
            {
                StreamWriter sw = new StreamWriter("g:\\err.txt");
                string err = e.ToString();
                sw.Write(err);
                sw.Close();
                num = -1;
            }
            return num;
        }

        #region 返回某年龄段中的会员数

        /// <summary>
        /// 返回某年龄段中的会员数
        /// </summary>
        /// <param name="sAge">起始年龄</param>
        /// <param name="eAge">截止年龄</param>
        /// <returns>int值，返回某年龄段中的会员数</returns>
        public int CountMembersAgeGroup(int sAge, int eAge)
        {
            if (eAge < sAge)
            {
                int tmp;
                tmp = sAge;
                sAge = eAge;
                eAge = tmp;
            }

            string sqlString = "select count(*) as 'number' from userinfo where userage >= @sAge and userage <= @eAge";
            SqlParameter[] pt = new SqlParameter[]
                                    {
                                        new SqlParameter("@sAge", SqlDbType.Int),
                                        new SqlParameter("@eAge", SqlDbType.Int)
                                    };

            pt[0].Value = sAge;
            pt[1].Value = eAge;


            return doQuery(sqlString, pt);
        }

        #endregion

        #region 返回某年龄段在电话，网络，店面的消费额。


        /// <summary>
        /// 返回某年龄段会员在一段时间内的店面销售额
        /// </summary>
        /// <param name="sAge">起始年龄</param>
        /// <param name="eAge">截止年龄</param>
        /// <param name="sDate">起始日期</param>
        /// <param name="eDate">截止日期</param>
        /// <returns>返回某年龄段会员在一段时间内的店面销售额</returns>
        public int MemberShopSalesAmount(int sAge, int eAge, DateTime sDate, DateTime eDate)
        {
            string sqlString = "select sum(totalValue) as 'total' from mainUpload "
                               + " where sellTime >= @sDate and sellTime <= @eDate "
                               + " and age >= @sAge and age <= @eAge";

            SqlParameter[] pt = new SqlParameter[]
                                    {
                                        new SqlParameter("@sDate", SqlDbType.DateTime),
                                        new SqlParameter("@eDate", SqlDbType.DateTime),
                                        new SqlParameter("@sAge", SqlDbType.Int),
                                        new SqlParameter("@eAge", SqlDbType.Int),
                                        new SqlParameter("@eAge", SqlDbType.Int),

                                    };

            //SqlDateTime sdt=new SqlDateTime(struct DateTime）;

            pt[0].Value = new SqlDateTime(sDate);
            pt[1].Value = new SqlDateTime(eDate);
            pt[2].Value = sAge;
            pt[3].Value = eAge;


            return doQuery(sqlString, pt);

            
        }

        /// <summary>
        /// 返回某年龄段会员在一段时间内的网上销售额
        /// </summary>
        /// <param name="sAge">起始年龄</param>
        /// <param name="eAge">截止年龄</param>
        /// <param name="sDate">起始日期</param>
        /// <param name="eDate">截止日期</param>
        /// <returns>返回某年龄段会员在一段时间内的网上销售额</returns>
        public int MemberOnlineSalesAmount(int sAge, int eAge, DateTime sDate, DateTime eDate)
        {
            string sqlString = "select sum(orderPrice)  as 'total' from mainOrderInfo"
                               + " where sellway= @type and orderTime >= @sDate and ordertime <= @eDate and userID"
                               + " in (select userID from userInfo where userAge >= @sAge and userAge <= @eAge )";

            if (sAge > eAge)
            {
                int tmp = eAge;
                eAge = sAge;
                sAge = tmp;
            }

            SqlParameter[] pt = new SqlParameter[]
                                    {
                                        new SqlParameter("@sAge", SqlDbType.Int),
                                        new SqlParameter("@eAge", SqlDbType.Int),
                                        new SqlParameter("@sDate", SqlDbType.DateTime),
                                        new SqlParameter("@eDate", SqlDbType.DateTime),
                                        new SqlParameter("@type", SqlDbType.Int),
                                    };

            pt[0].Value = sAge;
            pt[1].Value = eAge;
            pt[2].Value = new SqlDateTime(sDate);
            pt[3].Value = new SqlDateTime(eDate);
            pt[4].Value = SoldType.OnlineSail;
            return doQuery(sqlString, pt);
        }

        /// <summary>
        /// 返回某年龄段会员在一段时间内的电话销售额
        /// </summary>
        /// <param name="sAge">起始年龄</param>
        /// <param name="eAge">截止年龄</param>
        /// <param name="sDate">起始日期</param>
        /// <param name="eDate">截止日期</param>
        /// <returns>返回某年龄段会员在一段时间内的电话销售额</returns>
        public int MemberPhoneSalesAmount(int sAge, int eAge, DateTime sDate, DateTime eDate)
        {
            string sqlString = "select sum(orderPrice)  as 'total' from mainOrderInfo"
                   + " where sellway= @type and orderTime >= @sDate and ordertime <= @eDate and userID"
                   + " in (select userID from userInfo where userAge >= @sAge and userAge <= @eAge )";

            if (sAge > eAge)
            {
                int tmp = eAge;
                eAge = sAge;
                sAge = tmp;
            }

            SqlParameter[] pt = new SqlParameter[]
                                    {
                                        new SqlParameter("@sAge", SqlDbType.Int),
                                        new SqlParameter("@eAge", SqlDbType.Int),
                                        new SqlParameter("@sDate", SqlDbType.DateTime),
                                        new SqlParameter("@eDate", SqlDbType.DateTime),
                                        new SqlParameter("@type", SqlDbType.Int),
                                    };

            pt[0].Value = sAge;
            pt[1].Value = eAge;
            pt[2].Value = new SqlDateTime(sDate);
            pt[3].Value = new SqlDateTime(eDate);
            pt[4].Value = SoldType.PhoneSail;

            return doQuery(sqlString, pt);
        }


        #endregion

        #region

        //TODO  where is the info saved?
        /// <summary>
        /// 返回某类化妆品在某段时间内的电话销售额
        /// </summary>
        /// <param name="sDate">起始日期</param>
        /// <param name="eDate">截止日期</param>
        /// <param name="categoryName">化妆品类别名</param>
        /// <returns>返回某类化妆品在某段时间内的电话销售额</returns>
        public int GoodsPhoneSalesAmount(DateTime sDate, DateTime eDate, string categoryName)
        {
            string sqlString =
                "select sum(mainorderInfo.orderPrice) as 'total' from mainOrderInfo " +
                " where sellway = @type and orderTime>= @sDate and ordertime<= @eDate and mainOrderID " +
                " in (Select mainOrderID from mainOrderInfo where mainOrderID " +
                " in (select mainOrderID from subOrderInfo where goodsID " +
                " in (Select goodsID from goodsInfo where goodsCategory " +
                " in (select ID from category where name=@categoryName))))";

            //装配SQL变量
            SqlParameter[] pt = new SqlParameter[]
                                    {
                                        new SqlParameter("@sDate", SqlDbType.DateTime),
                                        new SqlParameter("@eDate", SqlDbType.DateTime),
                                        new SqlParameter("@type",SqlDbType.Int), 
                                        new SqlParameter("@categoryName", SqlDbType.VarChar)
                                    };
            pt[0].Value = new SqlDateTime(sDate);
            pt[1].Value = new SqlDateTime(eDate);
            pt[2].Value = SoldType.PhoneSail;
            pt[3].Value = new SqlString(categoryName);

            return doQuery(sqlString, pt);
        }

        /// <summary>
        /// 返回某类化妆品在某段时间内的网上销售额
        /// </summary>
        /// <param name="sDate">起始日期</param>
        /// <param name="eDate">截止日期</param>
        /// <param name="categoryName">化妆品类别名</param>
        /// <returns>返回某类化妆品在某段时间内的网上销售额</returns>
        public int GoodsOnlineSalesAmount(DateTime sDate, DateTime eDate, string categoryName)
        {
            string sqlString =
                "select sum(mainorderInfo.orderPrice) as 'total' from mainOrderInfo " +
                " where sellway = @type and orderTime>= @sDate and ordertime<= @eDate and mainOrderID " +
                " in (Select mainOrderID from mainOrderInfo where mainOrderID " +
                " in (select mainOrderID from subOrderInfo where goodsID " +
                " in (Select goodsID from goodsInfo where goodsCategory " +
                " in (select ID from category where name=@categoryName))))";

            //装配SQL变量
            SqlParameter[] pt = new SqlParameter[]
                                    {
                                        new SqlParameter("@sDate", SqlDbType.DateTime),
                                        new SqlParameter("@eDate", SqlDbType.DateTime),
                                        new SqlParameter("@type",SqlDbType.Int), 
                                        new SqlParameter("@categoryName", SqlDbType.VarChar)
                                    };
            pt[0].Value = new SqlDateTime(sDate);
            pt[1].Value = new SqlDateTime(eDate);
            pt[2].Value = SoldType.OnlineSail;
            pt[3].Value = new SqlString(categoryName);

            return doQuery(sqlString, pt);
        }

        /// <summary>
        /// 返回某类化妆品在某段时间内的店面销售额
        /// </summary>
        /// <param name="sDate">起始日期</param>
        /// <param name="eDate">截止日期</param>
        /// <param name="categoryName">化妆品类别名</param>
        /// <returns>返回某类化妆品在某段时间内的店面销售额</returns>
        public int GoodsShopSalesAmount(DateTime sDate, DateTime eDate, string categoryName)
        {
            string sqlString =
                "select sum(totalValue) as 'total' from MainUpload " +
                " where sellTime >= @sDate and sellTime<=@eDate and mainUploadID " +
                " in (select mainUploadID from subUpload where goodsID " +
                " in (Select goodsID from goodsInfo where goodsCategory " +
                " in (select ID from category where name=@categoryName)))";

            //装配SQL变量
            SqlParameter[] pt = new SqlParameter[]
                                    {
                                        new SqlParameter("@sDate", SqlDbType.DateTime),
                                        new SqlParameter("@eDate", SqlDbType.DateTime),
                                        new SqlParameter("@categoryName", SqlDbType.VarChar)
                                    };
            pt[0].Value = new SqlDateTime(sDate);
            pt[1].Value = new SqlDateTime(eDate);
            pt[2].Value = new SqlString(categoryName);
            return doQuery(sqlString, pt);
        }

        #endregion
    }
}