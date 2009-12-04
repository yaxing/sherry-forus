////��д�ߣ����
////��  �ڣ�2009-11-25
////��  �ܣ���ͨ�û���Ϣ������߼�����

using System;
using System.Collections.Generic;
using System.Web.Security;
using DAL;
using Entity;

namespace BLL
{
    public class UserInfoBLL
    {
        #region ������û�

        /// <summary>
        /// ������û��������ɹ�����true��ʧ�ܷ���false
        /// </summary>
        /// <param name="newuser">�û�ʵ�����</param>
        /// <returns>boolֵ</returns>

        public bool AddUserInfo(UserInfo newuser)
        {

            MembershipUser user = Membership.CreateUser(newuser.UserRealName, newuser.UserRealName, newuser.EmailAdd);

            //------------------------�˴���������û���roles------------------------------//
            Roles.AddUserToRole(newuser.UserRealName, "��ͨ�û�");


            newuser.UserID = (Guid)user.ProviderUserKey;
            if (user == null)
                return false;
            else
            {
                UserInfoDAL userDAL = new UserInfoDAL();
                if (!userDAL.AddUserInfo(newuser))
                {
                    ////////�˴�������Ҫ��membership�е�����ɾ��
                    Membership.DeleteUser(newuser.UserRealName);
                    return false;
                }
            }

            return true;
        }
        #endregion

        #region �޸��û���Ϣ

        /// <summary>
        /// ɾ���û��������ɹ�����true��ʧ�ܷ���false
        /// </summary>
        /// <param name="user">�û�ʵ�����</param>
        /// <returns>bool</returns>

        public bool ModiUserInfo(UserInfo user)
        {
            UserInfoDAL userDAL = new UserInfoDAL();
            MembershipUser muser = Membership.GetUser(user.UserRealName);
            user.UserID = (Guid)muser.ProviderUserKey;
            return userDAL.ModiUserInfo(user);
        }
        #endregion


        #region ɾ���û�

        /// <summary>
        /// ɾ���û�
        /// </summary>
        /// <param name="userName">�û���</param>
        /// <returns>bool</returns>

        public bool DeleteUserInfo(String userName)
        {
            MembershipUser user = Membership.GetUser(userName);
            Guid userID = (Guid)user.ProviderUserKey;
            UserInfoDAL userDAL = new UserInfoDAL();
            return userDAL.DeleteUserInfo(userID);
        }
        #endregion

        #region ���û�����ѯ�û�

        /// <summary>
        /// ��ѯ�û�
        /// </summary>
        /// <param name="userName">�û���</param>
        /// <param name="userInfo">�û�ʵ�����</param>
        /// <returns>bool</returns>

        public bool SrchUserInfoByUserName(ref UserInfo userInfo, string userName)
        {
            MembershipUser user = Membership.GetUser(userName);
            userInfo.UserID = (Guid)user.ProviderUserKey;
            UserInfoDAL userDAL = new UserInfoDAL();
            return userDAL.SrchUserInfo(ref userInfo);
        }

        #endregion

        # region ��ʾ�û��б�

        /// <summary>
        /// ��ʾ�û��б�
        /// </summary>
        /// <param name="userList"></param>
        /// <returns>�û�����</returns>

        public int ShowUserInfo(ref IList<UserInfo> userList)
        {
            UserInfoDAL userDAL = new UserInfoDAL();
            return userDAL.ShowUserInfo(ref userList);
        }
        # endregion
    }
}
