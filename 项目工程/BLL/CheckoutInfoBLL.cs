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
        #region 启动订单生成
        /// <summary>
        /// 启动订单生成流程，取出用户默认信息，操作成功返回true，失败返回false
        /// </summary>
        /// <param name="curUserInfo">用户实体</param>
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
            newInfo.UserID = (Guid)curUser.ProviderUserKey;
            flag = userData.ChangeUserInfo(newInfo);
            if (!flag)
            {
                return flag;
            }
            return flag;
        }
        #endregion

        #region 用户确认订单，生成订单
        /// <summary>
        /// 生成订单，操作成功返回true，失败返回false
        /// </summary>
        /// <param name="orderInfo">订单实体</param>
        /// <returns>bool值</returns>
        public bool GenerateOrder(OrderInfo orderInfo, ref int orderID)
        {
            CheckoutInfoDAL newOrder = new CheckoutInfoDAL();
            MembershipUser curUser = Membership.GetUser(HttpContext.Current.User.Identity.Name.ToString());
            orderInfo.UserID = (Guid)curUser.ProviderUserKey;
            return newOrder.InsertNewOrder(orderInfo, ref orderID);
        }
        #endregion
    }
}
