/************************************************************************/
/*编写者：张翼鹏                                                        */
/*日  期：2009-11-29                                                    */
/*功  能：商品评论信息数据访问操作                                      */
/************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using Entity;

namespace BLL
{
    public class GoodsCommentBLL
    {
        #region 根据商品ID查询总评价

        /// <summary>
        /// 根据商品ID查询总评价
        /// </summary>
        /// <param name="goodsComment"></param>
        /// <returns>bool</returns>

        public bool ShowCountOfGood(ref GoodsComment goodComment)
        {
            GoodsCommentDAL commentDAL = new GoodsCommentDAL();
            try
            {
                if (!commentDAL.ShowCountOfGood(ref goodComment))
                    return false;
            }
            catch
            {
                return false;
            }

            return true;
        }

        #endregion

        #region 添加商品评价

        /// <summary>
        /// 添加商品评价
        /// </summary>
        /// <param name="goodsComment"></param>
        /// <returns>bool</returns>
        
        public bool AddComment(GoodsComment goodsComment)
        {
            GoodsCommentDAL commentDAL = new GoodsCommentDAL();
            try
            {
                if (!commentDAL.AddComment(goodsComment))
                    return false;
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

        public int ShowCommentOfGood(ref IList<GoodsComment> CommentList, GoodsInfo goodsInfo)
        {
            GoodsCommentDAL commentDAL = new GoodsCommentDAL();
            try
            {
                if (commentDAL.ShowCommentOfGood(ref CommentList,goodsInfo) == -1)
                    return -1;
            }
            catch
            {
                return -1;
            }
            return CommentList.Count;
        }

        #endregion

        #region 根据商品ID查询评论

        /// <summary>
        /// 根据商品ID查询评论
        /// </summary>
        /// <param name="goodsID">商品ID</param>
        /// <returns>int</returns>

        public int ShowFiveCommentOfGood(ref IList<GoodsComment> CommentList, GoodsInfo goodsInfo)
        {
            GoodsCommentDAL commentDAL = new GoodsCommentDAL();
            try
            {
                if (commentDAL.ShowFiveCommentOfGood(ref CommentList, goodsInfo) == -1)
                    return -1;
            }
            catch
            {
                return -1;
            }
            return CommentList.Count;
        }

        #endregion
    }
}
