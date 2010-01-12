using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DbCtrl;
using Entity;

namespace DAL
{
    public static class GoodsInfoDAL
    {
        private static DataProvider dataProvider;

        #region 添加产品

        /// <summary>
        /// 添加产品
        /// </summary>
        /// <param name="newGoods">新产品实体对象</param>
        /// <returns>bool值</returns>

        public static bool AddGoods(GoodsInfo newGoods)
        {
            string sqlString = "Insert Into goodsInfo (goodsCategory, goodsAddTime, goodsValidity, goodsPrice, goodsAvailable, goodsStorage, goodsNum, goodsName, goodsImg, goodsDescribe, goodsSpecialOffer)"
                        + " Values (@goodsCategory, @goodsAddTime, @goodsValidity, @goodsPrice, @goodsAvailable, @goodsStorage, @goodsNum, @goodsName, @goodsImg, @goodsDescribe, @goodsSpecialOffer)";

            SqlParameter[] pt = new SqlParameter[] { 
                                new SqlParameter("@goodsCategory",SqlDbType.Int),
                                new SqlParameter("@goodsAddTime",SqlDbType.DateTime),
                                new SqlParameter("@goodsValidity",SqlDbType.DateTime),
                                new SqlParameter("@goodsPrice",SqlDbType.SmallMoney),
                                new SqlParameter("@goodsAvailable",SqlDbType.Bit),
                                new SqlParameter("@goodsStorage",SqlDbType.Int),
                                new SqlParameter("@goodsNum", SqlDbType.VarChar),
                                new SqlParameter("@goodsName",SqlDbType.VarChar),
                                new SqlParameter("@goodsImg",SqlDbType.VarChar),
                                new SqlParameter("@goodsDescribe",SqlDbType.VarChar),
                                new SqlParameter("@goodsSpecialOffer",SqlDbType.Int)
                                };
            pt[0].Value = newGoods.goodsCategory;
            pt[1].Value = newGoods.goodsAddTime;
            pt[2].Value = newGoods.goodsValidity;
            pt[3].Value = newGoods.goodsPrice;
            pt[4].Value = newGoods.goodsAvailable;
            pt[5].Value = newGoods.goodsStorage;
            pt[6].Value = newGoods.goodsNum;
            pt[7].Value = newGoods.goodsName;
            pt[8].Value = newGoods.goodsImg;
            pt[9].Value = newGoods.goodsDescribe;
            pt[10].Value = 0;

            try
            {
                dataProvider = new DataProvider();
                dataProvider.ExecuteNonQuery(sqlString, pt);
            }
            catch 
            {
                return (false);
            }

            return (true);
        }
        #endregion

        #region 删除产品

        /// <summary>
        /// 删除产品
        /// </summary>
        /// <param name="goodsID">产品索引值</param>
        /// <returns>bool值</returns>

        public static bool DeleteGoods(int goodsID)
        {
            string sqlString = "delete from goodsInfo where goodsID = @goodsID";
            SqlParameter[] pt = new SqlParameter[] { 
                                new SqlParameter("@goodsID", SqlDbType.Int)
                                };
            pt[0].Value = goodsID;

            using (dataProvider = new DataProvider())
            {
                if (dataProvider.ExecuteNonQuery(sqlString, pt) == 0)
                {
                    return (false);
                }
            }
            return (true);
        }
        #endregion

        #region 查找产品

        /// <summary>
        /// <param name="goodsName">产品名称</param>
        /// <param name="goodsNum">产品编号</param>
        /// <param name="goodsCategory">产品类别</param>
        /// <param name="timeFrom">从此时间开始查找产品</param>
        /// <param name="timeFrom">以此时间结束查找产品</param>
        /// <returns>DataTable型的查找结果</returns>

        public static DataTable FindGoods(string goodsName, string goodsNum, int goodsCategory, DateTime timeFrom, DateTime timeTo)
        {
            DataTable findResult;
            string sqlString = "select goodsID, goodsName, goodsNum, goodsCategory, goodsAddTime, goodsImg from goodsInfo";
            string sqlStringVary = "";

            SqlParameter[] pt = new SqlParameter[] { 
                                new SqlParameter("@goodsNum", SqlDbType.VarChar),
                                new SqlParameter("@goodsName",SqlDbType.VarChar),
                                new SqlParameter("@goodsCategory",SqlDbType.Int),
                                new SqlParameter("@timeFrom",SqlDbType.DateTime),
                                new SqlParameter("@timeTo",SqlDbType.DateTime)
                                };

            pt[0].Value = goodsNum;
            pt[1].Value = goodsName;
            pt[2].Value = goodsCategory;
            pt[3].Value = DateTime.Now;
            pt[4].Value = pt[3].Value;

            if (!goodsName.Equals(""))
            {
                sqlStringVary += " and goodsName like '%@goodsName%'";
            }
            if (!goodsNum.Equals(""))
            {                
                sqlStringVary += " and goodsNum like '%@goodsNum%'";
            }
            if (goodsCategory != 0)
            {
                sqlStringVary += " and goodsCategory = @goodsCategory";
            }
            if (!timeFrom.Equals(DateTime.MinValue))
            {
                pt[3].Value = timeFrom;
                sqlStringVary += " and goodsAddTime > @timeFrom";
            }
            if (!timeTo.Equals(DateTime.MaxValue))
            {
                pt[4].Value = timeTo;
                sqlStringVary += " and goodsAddTime < @timeTo";
            }
            if (!sqlStringVary.Equals(""))
            {
                sqlString += " where" + sqlStringVary.Substring(4);
            }

            sqlString += " order by goodsID desc";
            using (dataProvider = new DataProvider())
            {
                findResult = dataProvider.ExecuteDataTable(sqlString, pt);
            }
            return (findResult);
        }
        #endregion

        #region 显示产品详细信息

        /// <summary>
        /// 显示产品详细信息
        /// </summary>
        /// <param name="goodsID">产品索引值</param>
        /// <returns>GoodsInfo型的产品信息</returns>

        public static GoodsInfo GoodsDetail(int goodsID)
        {
            GoodsInfo goodsInfo = new GoodsInfo();
            DataTable theGoods;
            string sqlString = "select * from goodsInfo where goodsID = " + goodsID.ToString();

            using (dataProvider = new DataProvider())
            {
                theGoods = dataProvider.ExecuteQuery(sqlString);
            }

            if (theGoods.Rows.Count != 0)
            {
                goodsInfo.goodsID = Convert.ToInt32(theGoods.Rows[0]["goodsID"]);
                goodsInfo.goodsCategory = Convert.ToInt32(theGoods.Rows[0]["goodsCategory"]);
                goodsInfo.goodsAddTime = Convert.ToDateTime(theGoods.Rows[0]["goodsAddTime"]);
                goodsInfo.goodsValidity = Convert.ToDateTime(theGoods.Rows[0]["goodsValidity"]);
                goodsInfo.goodsPrice = Convert.ToDouble(theGoods.Rows[0]["goodsPrice"]);
                goodsInfo.goodsAvailable = Convert.ToBoolean(theGoods.Rows[0]["goodsAvailable"]);
                goodsInfo.goodsStorage = Convert.ToInt32(theGoods.Rows[0]["goodsStorage"]);
                goodsInfo.goodsName = theGoods.Rows[0]["goodsName"].ToString();
                goodsInfo.goodsNum = theGoods.Rows[0]["goodsNum"].ToString();
                goodsInfo.goodsImg = theGoods.Rows[0]["goodsImg"].ToString();
                goodsInfo.goodsDescribe = theGoods.Rows[0]["goodsDescribe"].ToString();
            }
            else
            {
                Exception e = new Exception("没有这个goodsID的产品。");
                throw e;
            }

            return (goodsInfo);
        }
        #endregion

        #region 修改产品

        /// <summary>
        /// 修改产品
        /// </summary>
        /// <param name="goodsID">产品索引值</param>
        /// <param name="goodsInfo">产品信息</param>
        /// <returns>bool值</returns>

        public static bool ChangeGoods(int goodsID, GoodsInfo goodsInfo)
        {
            string sqlString = "update goodsInfo set goodsCategory = @goodsCategory, goodsValidity = @goodsValidity, "
                + "goodsPrice = @goodsPrice, goodsAvailable = @goodsAvailable, goodsStorage = @goodsStorage, "
                + "goodsNum = @goodsNum, goodsName = @goodsName, goodsImg = @goodsImg, goodsDescribe = @goodsDescribe "
                + "where goodsID = @goodsID";

            SqlParameter[] pt = new SqlParameter[] { 
                                new SqlParameter("@goodsCategory",SqlDbType.Int),
                                new SqlParameter("@goodsValidity",SqlDbType.DateTime),
                                new SqlParameter("@goodsPrice",SqlDbType.SmallMoney),
                                new SqlParameter("@goodsAvailable",SqlDbType.Bit),
                                new SqlParameter("@goodsStorage",SqlDbType.Int),
                                new SqlParameter("@goodsNum", SqlDbType.VarChar),
                                new SqlParameter("@goodsName",SqlDbType.VarChar),
                                new SqlParameter("@goodsImg",SqlDbType.VarChar),
                                new SqlParameter("@goodsDescribe",SqlDbType.VarChar),
                                new SqlParameter("@goodsID",SqlDbType.Int)
                                };
            pt[0].Value = goodsInfo.goodsCategory;
            pt[1].Value = goodsInfo.goodsValidity;
            pt[2].Value = goodsInfo.goodsPrice;
            pt[3].Value = goodsInfo.goodsAvailable;
            pt[4].Value = goodsInfo.goodsStorage;
            pt[5].Value = goodsInfo.goodsNum;
            pt[6].Value = goodsInfo.goodsName;
            pt[7].Value = goodsInfo.goodsImg;
            pt[8].Value = goodsInfo.goodsDescribe;
            pt[9].Value = goodsInfo.goodsID;

            using (dataProvider = new DataProvider())
            {
                if (dataProvider.ExecuteNonQuery(sqlString, pt) == 0)
                {
                    return (false);
                }
            }

            return (true);
        }
        #endregion

        #region 修改产品状态

        /// <summary>
        /// 修改产品状态
        /// </summary>
        /// <param name="goodsID">产品索引值</param>
        /// <param name="goodsAvailable">产品上下架状态</param>
        /// <param name="goodsStorage">产品库存</param>
        /// <returns>bool值</returns>

        public static bool ChangeGoodsStat(int goodsID, bool goodsAvailable, int goodsStorage)
        {
            string sqlString = "update goodsInfo set goodsAvailable = " + goodsAvailable.ToString() 
                + ", goodsStorage" + goodsStorage.ToString() + " where goodsID = " + goodsID.ToString();

            using (dataProvider = new DataProvider())
            {
                if (dataProvider.ExecuteNonQuery(sqlString) == 0)
                {
                    return (false);
                }
            }
            return (true);
        }
        #endregion

        #region 查找所有的特价产品

        /// <summary>
        /// 查找所有的特价产品
        /// </summary>
        /// <returns>DataTable型的查找结果</returns>

        public static DataTable FindSpecialGoods()
        {
            DataTable findResult;
            string sqlString = "select goodsID, goodsName, goodsImg from goodsInfo where goodsSpecialOffer = 1 order by goodsID desc";

            using (dataProvider = new DataProvider())
            {
                findResult = dataProvider.ExecuteQuery(sqlString);
            }
            return (findResult);
        }
        #endregion

        #region 查找最近添加的（num个）产品

        /// <summary>
        /// 查找最近添加的（num个）产品
        /// </summary>
        /// <param name="num">产品个数</param>
        /// <param name="orderByVolume">是否按照销量排序</param>
        /// <returns>DataTable型的查找结果</returns>

        public static DataTable LatestGoods(int num, bool orderByVolume)
        {
            string sqlString = "select top " + num.ToString() + " goodsID, goodsName, goodsImg";
            DataTable latestGoods;

            if (orderByVolume)
            {
                sqlString += ", goodsDescribe";
            }
            sqlString += " from goodsInfo order by ";
            if (orderByVolume)
            {
                sqlString += "goodsVolume, ";
            }
            sqlString += "goodsID desc";
            using (dataProvider = new DataProvider())
            {
                latestGoods = dataProvider.ExecuteQuery(sqlString);
            }
            if (orderByVolume)
            {
                int shortDescribeLength = 20;

                for (int i = 0; i < latestGoods.Rows.Count; ++i)
                {
                    if (latestGoods.Rows[i]["goodsDescribe"].ToString().Length > shortDescribeLength)
                    {
                        latestGoods.Rows[i]["goodsDescribe"] = latestGoods.Rows[i]["goodsDescribe"].ToString().Substring(0, shortDescribeLength) + "...";
                    }
                }
            }
            return (latestGoods);
        }
        #endregion

        #region 获取分类列表

        /// <summary>
        /// 获取分类列表
        /// </summary>
        /// <param name="category">商品分类datatable</param>
        /// <returns>bool值</returns>

        public static bool GetCategory(ref DataTable category)
        {
            string sqlString = "select * from category";
            try
            {
                using (dataProvider = new DataProvider())
                {
                    if ((category = dataProvider.ExecuteQuery(sqlString)) == null)
                    {
                        return false;
                    }
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
