/************************************************************************/
/*��д�ߣ�������                                                        */
/*��  �ڣ�2009-11-29                                                    */
/*��  �ܣ���Ʒ������Ϣ���ݷ��ʲ���                                      */
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
        #region ������ƷID��ѯ������

        /// <summary>
        /// ������ƷID��ѯ������
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

        #region �����Ʒ����

        /// <summary>
        /// �����Ʒ����
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

        #region ������ƷID��ѯ����

        /// <summary>
        /// ������ƷID��ѯ����
        /// </summary>
        /// <param name="goodsID">��ƷID</param>
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

        #region ������ƷID��ѯ����

        /// <summary>
        /// ������ƷID��ѯ����
        /// </summary>
        /// <param name="goodsID">��ƷID</param>
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
