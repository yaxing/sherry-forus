/************************************************************************/
/*编写者：张翼鹏                                                        */
/*日  期：2009-11-29                                                    */
/*功  能：商品评论信息数据访问操作                                      */
/************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DbCtrl;
using Entity;

namespace DAL
{
    public class GoodsCommentDAL
    {

        private DataProvider dp = new DataProvider();

        #region 根据商品ID查询总评价

        /// <summary>
        /// 根据商品ID查询总评价
        /// </summary>
        /// <param name="goodsComment"></param>
        /// <returns>bool</returns>
        
        public bool ShowCountOfGood(ref GoodsComment goodComment)
        {
            String sqlString = "select * from goodsInfo where goodsID = @goodsID";
            SqlParameter[] pt = new SqlParameter[]{
                                new SqlParameter("@goodsID", SqlDbType.Int)
                                };
            pt[0].Value = goodComment.GoodsID;

            try
            {
                using (dp = new DataProvider())
                {
                    using (SqlDataReader reader = dp.ExecuteReader(sqlString, pt))
                    {
                        while (reader.Read())
                        {
                            goodComment.GoodsVolume = reader.GetInt32(10);
                            goodComment.GoodsGC = reader.GetInt32(12);
                            goodComment.GoodsMC = reader.GetInt32(13);
                            goodComment.GoodsBC = reader.GetInt32(14);
                        }
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

        #region 根据商品ID查询评论

        /// <summary>
        /// 根据商品ID查询评论
        /// </summary>
        /// <param name="goodsID">商品ID</param>
        /// <returns>int</returns>

        public int ShowCommentOfGood(ref IList<GoodsComment> CommentList,GoodsInfo goodsInfo)
        {
            String sqlString = "select * from goodsComment,userInfo where goodsID = @goodsID and goodsComment.userID = userInfo.userID order by commentTime DESC";
            SqlParameter[] pt = new SqlParameter[]{
                                new SqlParameter("@goodsID", SqlDbType.Int)
                                };
            pt[0].Value = goodsInfo.goodsID;

            try
            {
                using (dp = new DataProvider())
                {
                    using (SqlDataReader reader = dp.ExecuteReader(sqlString,pt))
                    {
                        GoodsComment goodsComment = null;
                        while (reader.Read())
                        {
                            goodsComment = new GoodsComment();

                            goodsComment.CommentID = reader.GetInt32(0);
                            goodsComment.GoodsID = reader.GetInt32(1);
                            goodsComment.UserID = reader.GetGuid(2);
                            goodsComment.GoodsCom = reader.GetString(3);
                            goodsComment.CommentLevel = reader.GetInt32(4);
                            goodsComment.CommentTime = reader.GetDateTime(5);
                            goodsComment.UserName = reader.GetString(7);
                            goodsComment.UserScore = reader.GetInt32(11);
                            goodsComment.UserLv = reader.GetInt32(12);

                            switch (goodsComment.CommentLevel)
                            {
                                case 0:
                                    goodsComment.CommentLv = "不喜欢";
                                    break;
                                case 1:
                                    goodsComment.CommentLv = "一般";
                                    break;
                                case 2:
                                    goodsComment.CommentLv = "喜欢";
                                    break;
                            }

                            switch (goodsComment.UserLv)
                            {
                                case 0:
                                    goodsComment.UserLevel = "普通会员";
                                    break;
                                case 1:
                                    goodsComment.UserLevel = "黄金会员";
                                    break;
                            }

                            CommentList.Add(goodsComment);
                        }
                    }
                }
            }
            catch
            {
                return -1;
            }

            return CommentList.Count;
        }

        #endregion

        #region 根据商品ID查询最新的5条评论

        /// <summary>
        /// 根据商品ID查询最新的5条评论
        /// </summary>
        /// <param name="goodsID">商品ID</param>
        /// <returns>int</returns>

        public int ShowFiveCommentOfGood(ref IList<GoodsComment> CommentList, GoodsInfo goodsInfo)
        {
            String sqlString = "select top 5 * from goodsComment,userInfo where goodsID = @goodsID and goodsComment.userID = userInfo.userID order by commentTime DESC";
            SqlParameter[] pt = new SqlParameter[]{
                                new SqlParameter("@goodsID", SqlDbType.Int)
                                };
            pt[0].Value = goodsInfo.goodsID;

            try
            {
                using (dp = new DataProvider())
                {
                    using (SqlDataReader reader = dp.ExecuteReader(sqlString, pt))
                    {
                        GoodsComment goodsComment = null;
                        while (reader.Read())
                        {
                            goodsComment = new GoodsComment();

                            goodsComment.CommentID = reader.GetInt32(0);
                            goodsComment.GoodsID = reader.GetInt32(1);
                            goodsComment.UserID = reader.GetGuid(2);
                            goodsComment.GoodsCom = reader.GetString(3);
                            goodsComment.CommentLevel = reader.GetInt32(4);
                            goodsComment.CommentTime = reader.GetDateTime(5);
                            goodsComment.UserName = reader.GetString(7);
                            goodsComment.UserScore = reader.GetInt32(11);
                            goodsComment.UserLv = reader.GetInt32(12);

                            switch (goodsComment.CommentLevel)
                            {
                                case 0:
                                    goodsComment.CommentLv = "不喜欢";
                                    break;
                                case 1:
                                    goodsComment.CommentLv = "一般";
                                    break;
                                case 2:
                                    goodsComment.CommentLv = "喜欢";
                                    break;
                            }

                            switch (goodsComment.UserLv)
                            {
                                case 0:
                                    goodsComment.UserLevel = "普通会员";
                                    break;
                                case 1:
                                    goodsComment.UserLevel = "黄金会员";
                                    break;
                            }

                            CommentList.Add(goodsComment);
                        }
                    }
                }
            }
            catch
            {
                return -1;
            }

            return CommentList.Count;
        }

        #endregion

        #region  添加评价

        /// <summary>
        /// 添加评价
        /// </summary>
        /// <param name="goodsComment"></param>
        /// <returns>bool</returns>
        
        public bool AddComment(GoodsComment goodsComment)
        {
            String sqlString = "Insert Into goodsComment (goodsID,userID,goodsComment,commentLevel)"
                        + " Values (@goodsID,@userID,@goodsComment,@commentLevel)";
            SqlParameter[] pt = new SqlParameter[]{
                                new SqlParameter("@goodsID", SqlDbType.Int),
                                new SqlParameter("@userID", SqlDbType.UniqueIdentifier),
                                new SqlParameter("@goodsComment", SqlDbType.VarChar),
                                new SqlParameter("@commentLevel", SqlDbType.Int)
                                };
            pt[0].Value = goodsComment.GoodsID;
            pt[1].Value = goodsComment.UserID;
            pt[2].Value = goodsComment.GoodsCom;
            pt[3].Value = goodsComment.CommentLevel;

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

            switch (goodsComment.CommentLevel)
            {
                case 0:
                    sqlString = "Update goodsInfo Set goodsBC = goodsBC + 1 where goodsID = @goodsID";
                    break;
                case 1:
                    sqlString = "Update goodsInfo Set goodsMC = goodsMC + 1 where goodsID = @goodsID";
                    break;
                case 2:
                    sqlString = "Update goodsInfo Set goodsGC = goodsGC + 1 where goodsID = @goodsID";
                    break;
            }
            SqlParameter[] ptr = new SqlParameter[]{
                                 new SqlParameter("@goodsID", SqlDbType.Int)
                                 };
            ptr[0].Value = goodsComment.GoodsID;

            try
            {
                using (dp = new DataProvider())
                {
                    if (dp.ExecuteNonQuery(sqlString, ptr) == 0)
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
