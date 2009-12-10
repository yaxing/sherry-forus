////编写者：陈亚星
////日  期：2009-12-09
////功  能：订单生成模块的逻辑处理
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using DAL;
using Entity;

namespace BLL
{
    public class CheckoutCtrl
    {
        #region 启动订单确认
        /// <summary>
        /// 启动订单确认流程，取出用户默认信息，操作成功返回true，失败返回false
        /// </summary>
        /// <param name="newInfo">用户实体</param>
        /// <returns>bool值</returns>
        public bool StartCheckOut(ref UserInfo curUserInfo) 
        {
            bool flag = true;
            CheckoutInfoDAL userData = new CheckoutInfoDAL();
            MembershipUser curUser = Membership.GetUser(HttpContext.Current.User.Identity.Name.ToString());
            UserInfo userInfo = new UserInfo();
            userInfo.UserID = (Guid)curUser.ProviderUserKey;
            flag = userData.SetUserInfo(ref userInfo);
            if (!flag) 
            {
                return flag;
            }
            curUserInfo.UserRealName = userInfo.UserRealName.ToString();
            curUserInfo.PostAdd = userInfo.PostAdd.ToString();
            curUserInfo.PostNum = userInfo.PostNum.ToString();
            curUserInfo.PhoneNum = userInfo.PhoneNum.ToString();
            curUserInfo.Province = userInfo.Province.ToString();
            return flag;
        }
        #endregion

        #region 更新配送信息
        /// <summary>
        /// 更新配送信息，操作成功返回true，失败返回false
        /// </summary>
        /// <param name="newInfo">用户实体</param>
        /// <returns>bool值</returns>
        public bool ChangeAdd(UserInfo newInfo) 
        {
            bool flag = true;
            CheckoutInfoDAL userData = new CheckoutInfoDAL();
            MembershipUser curUser = Membership.GetUser(HttpContext.Current.User.Identity.Name.ToString());
            UserInfo userInfo = new UserInfo();
            userInfo.UserID = (Guid)curUser.ProviderUserKey;
            userInfo.UserRealName = newInfo.UserRealName;
            userInfo.PostAdd = newInfo.PostAdd;
            userInfo.PostNum = newInfo.PostNum;
            userInfo.PhoneNum = newInfo.PhoneNum;
            userInfo.Province = newInfo.Province;
            flag = userData.ChangeUserInfo(userInfo);
            if (!flag)
            {
                return flag;
            }
            return flag;
        }
        #endregion
    }
}
