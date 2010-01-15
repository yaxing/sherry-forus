/************************************************************************/
/*编写者：张翼鹏                                                        */
/*日  期：2009-12-27                                                    */
/*功  能：商品评论数据实体                                              */
/************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class GoodsComment
    {
        private int commentID;
        private int goodsID;
        private Guid userID;
        private String goodsCom;
        private int commentLevel;
        private String commentLv;
        private int goodsVolume;
        private int goodsGC;
        private int goodsMC;
        private int goodsBC;
        private String userName;
        private int userScore;
        private int userLv;
        private String userLevel;
        private DateTime commentTime;

        public int CommentID
        {
            get { return commentID; }
            set { commentID = value; }
        }

        public int GoodsID
        {
            get { return goodsID; }
            set { goodsID = value; }
        }

        public Guid UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        public String GoodsCom
        {
            get { return goodsCom; }
            set { goodsCom = value; }
        }

        public int CommentLevel
        {
            get { return commentLevel; }
            set { commentLevel = value; }
        }


        public System.String CommentLv
        {
            get { return commentLv; }
            set { commentLv = value; }
        }

        public int GoodsVolume
        {
            get { return goodsVolume; }
            set { goodsVolume = value; }
        }

        public int GoodsGC
        {
            get { return goodsGC; }
            set { goodsGC = value; }
        }

        public int GoodsMC
        {
            get { return goodsMC; }
            set { goodsMC = value; }
        }

        public int GoodsBC
        {
            get { return goodsBC; }
            set { goodsBC = value; }
        }

        public System.String UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public int UserScore
        {
            get { return userScore; }
            set { userScore = value; }
        }

        public int UserLv
        {
            get { return userLv; }
            set { userLv = value; }
        }

        public System.String UserLevel
        {
            get { return userLevel; }
            set { userLevel = value; }
        }

        public System.DateTime CommentTime
        {
            get { return commentTime; }
            set { commentTime = value; }
        }
    }
}
