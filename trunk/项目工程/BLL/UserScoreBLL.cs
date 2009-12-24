////编写者：陈亚星
////日  期：2009-12-24
////功  能：用户积分管理
using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Entity;
using DAL;
using InterFace;
using System.Web;
using System.Web.Security;
using System.Web.UI;

namespace BLL
{
    public class UserScoreBLL
    {
        #region 增加用户积分
        /// <summary>
        /// 增加用户积分
        /// </summary>
        /// <param name="score">需要增加的积分,传进的参数是积分还是订单号(true:积分; false:订单号)</param>
        /// <returns>操作成功返回true，否则返回false</returns>
        public bool AddUserScore(int score, bool flag)
        {
            MembershipUser curUser = Membership.GetUser(HttpContext.Current.User.Identity.Name.ToString());
            Guid userId = (Guid)curUser.ProviderUserKey;
            UserScoreDAL addScore = new UserScoreDAL();
            if (!addScore.UpdateScore(userId,score,flag)) 
            {
                return false;
            }
            return true;
        }
        #endregion
    }
}
