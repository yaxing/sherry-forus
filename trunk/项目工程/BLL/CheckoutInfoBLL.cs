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

namespace BLL
{
    public class CheckoutCtrl
    {
        public CheckoutCtrl()
        {

        }

        public bool StartCheckOut(ref String[] curUserInfo) 
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
            curUserInfo[0] = userInfo.UserRealName.ToString();
            curUserInfo[1] = userInfo.PostAdd.ToString();
            curUserInfo[2] = userInfo.PostNum.ToString();
            curUserInfo[3] = userInfo.PhoneNum.ToString();
            return flag;
        }

        #region ����������Ϣ
        public bool ChangeAdd(ref String[] newInfo) 
        {
            bool flag = true;
            CheckoutInfoDAL userData = new CheckoutInfoDAL();
            MembershipUser curUser = Membership.GetUser(HttpContext.Current.User.Identity.Name.ToString());
            UserInfo userInfo = new UserInfo();
            userInfo.UserID = (Guid)curUser.ProviderUserKey;
            userInfo.UserRealName = newInfo[0];
            userInfo.PostAdd = newInfo[1];
            userInfo.PostNum = newInfo[2];
            userInfo.PhoneNum = newInfo[3];
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
