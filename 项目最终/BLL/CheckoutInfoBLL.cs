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
using InterFace;

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
        public int GenerateOrder(OrderInfo orderInfo, ref int orderID)
        {
            CheckoutInfoDAL newOrder = new CheckoutInfoDAL();
            MembershipUser curUser = Membership.GetUser(HttpContext.Current.User.Identity.Name.ToString());
            orderInfo.UserID = (Guid)curUser.ProviderUserKey;
            UserScoreDAL getScore = new UserScoreDAL();
            int userScore = 0;
            //插入订单信息
            if (!newOrder.InsertNewOrder(orderInfo, ref orderID)) 
            {
                return 1;
            }
            orderInfo.OrderID = orderID;
            //获取用户现有积分
            if (!getScore.GetUserScore(orderInfo.UserID, ref userScore))
            {
                return 2;
            }
            //根据用户现有积分和此订单可获积分判断是否升级为会员
            if (orderInfo.UserOrderPrice >= 1000.0||Convert.ToDouble(userScore)+orderInfo.UserOrderPrice>=5000.0) 
            {
                if (!newOrder.UpdateToGoldenUser(orderInfo.UserID)) 
                {
                    return 2;
                }
            }
            //如果用户成功付款，为用户添加积分
            if (orderInfo.State == 0) 
            {
                UserScoreBLL addScore = new UserScoreBLL();
                if (!addScore.AddUserScore(Convert.ToInt32(orderInfo.UserOrderPrice),true)) 
                {
                    return 3;
                }
            }
            //启动物流
            IShipping shipping = new LogisticsInfoBLL();
            shipping.StartShipping(orderInfo);
            return 0;
        }
        #endregion
    }
}
