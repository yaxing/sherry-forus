////��д�ߣ�������
////��  �ڣ�2009-12-09
////��  �ܣ���������ģ����߼�����
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
        #region ������������
        /// <summary>
        /// ���������������̣�ȡ���û�Ĭ����Ϣ�������ɹ�����true��ʧ�ܷ���false
        /// </summary>
        /// <param name="curUserInfo">�û�ʵ��</param>
        /// <returns>boolֵ</returns>
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

        #region ����������Ϣ
        /// <summary>
        /// ����������Ϣ�������ɹ�����true��ʧ�ܷ���false
        /// </summary>
        /// <param name="newInfo">�û�ʵ��</param>
        /// <returns>boolֵ</returns>
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

        #region �û�ȷ�϶��������ɶ���
        /// <summary>
        /// ���ɶ����������ɹ�����true��ʧ�ܷ���false
        /// </summary>
        /// <param name="orderInfo">����ʵ��</param>
        /// <returns>boolֵ</returns>
        public int GenerateOrder(OrderInfo orderInfo, ref int orderID)
        {
            CheckoutInfoDAL newOrder = new CheckoutInfoDAL();
            MembershipUser curUser = Membership.GetUser(HttpContext.Current.User.Identity.Name.ToString());
            orderInfo.UserID = (Guid)curUser.ProviderUserKey;
            UserScoreDAL getScore = new UserScoreDAL();
            int userScore = 0;
            //���붩����Ϣ
            if (!newOrder.InsertNewOrder(orderInfo, ref orderID)) 
            {
                return 1;
            }
            orderInfo.OrderID = orderID;
            //��ȡ�û����л���
            if (!getScore.GetUserScore(orderInfo.UserID, ref userScore))
            {
                return 2;
            }
            //�����û����л��ֺʹ˶����ɻ�����ж��Ƿ�����Ϊ��Ա
            if (orderInfo.UserOrderPrice >= 1000.0||Convert.ToDouble(userScore)+orderInfo.UserOrderPrice>=5000.0) 
            {
                if (!newOrder.UpdateToGoldenUser(orderInfo.UserID)) 
                {
                    return 2;
                }
            }
            //����û��ɹ����Ϊ�û���ӻ���
            if (orderInfo.State == 0) 
            {
                UserScoreBLL addScore = new UserScoreBLL();
                if (!addScore.AddUserScore(Convert.ToInt32(orderInfo.UserOrderPrice),true)) 
                {
                    return 3;
                }
            }
            //��������
            IShipping shipping = new LogisticsInfoBLL();
            shipping.StartShipping(orderInfo);
            return 0;
        }
        #endregion
    }
}
