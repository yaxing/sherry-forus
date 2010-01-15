/************************************************************************/
/*��д�ߣ�������                                                        */
/*��  �ڣ�2009-11-29                                                    */
/*��  �ܣ���Ʒ������Ϣ���ݷ��ʲ���                                      */
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

        #region ������ƷID��ѯ������

        /// <summary>
        /// ������ƷID��ѯ������
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

        #region ������ƷID��ѯ����

        /// <summary>
        /// ������ƷID��ѯ����
        /// </summary>
        /// <param name="goodsID">��ƷID</param>
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
                                    goodsComment.CommentLv = "��ϲ��";
                                    break;
                                case 1:
                                    goodsComment.CommentLv = "һ��";
                                    break;
                                case 2:
                                    goodsComment.CommentLv = "ϲ��";
                                    break;
                            }

                            switch (goodsComment.UserLv)
                            {
                                case 0:
                                    goodsComment.UserLevel = "��ͨ��Ա";
                                    break;
                                case 1:
                                    goodsComment.UserLevel = "�ƽ��Ա";
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

        #region ������ƷID��ѯ���µ�5������

        /// <summary>
        /// ������ƷID��ѯ���µ�5������
        /// </summary>
        /// <param name="goodsID">��ƷID</param>
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
                                    goodsComment.CommentLv = "��ϲ��";
                                    break;
                                case 1:
                                    goodsComment.CommentLv = "һ��";
                                    break;
                                case 2:
                                    goodsComment.CommentLv = "ϲ��";
                                    break;
                            }

                            switch (goodsComment.UserLv)
                            {
                                case 0:
                                    goodsComment.UserLevel = "��ͨ��Ա";
                                    break;
                                case 1:
                                    goodsComment.UserLevel = "�ƽ��Ա";
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

        #region  �������

        /// <summary>
        /// �������
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
