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
            MembershipUser user = Membership.GetUser(newuser.UserID);
            //------------------------�˴���������û���roles------------------------------//
            Roles.AddUserToRole(user.UserName, "��ͨ�û�");

            UserInfoDAL userDAL = new UserInfoDAL();
            if (!userDAL.AddUserInfo(newuser))
            {
                ////////�˴�������Ҫ��membership�е�����ɾ��
                Membership.DeleteUser(user.UserName);
                return false;
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


        #region ɾ���û�(�û���)

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

        #region ɾ���û�(id)

        /// <summary>
        /// ɾ���û�
        /// </summary>
        /// <param name="userID">�û�ID</param>
        /// <returns>bool</returns>

        public bool DeleteUserInfo(Guid userID)
        {
            UserInfoDAL userDAL = new UserInfoDAL();
            return userDAL.DeleteUserInfo(userID);
        }
        #endregion

        #region �����û�

        /// <summary>
        /// �����û�
        /// </summary>
        /// <param name="userID>�û�ID</param>
        /// <returns>bool</returns>

        public bool ModiUserLv(Guid userID)
        {
            MembershipUser user = Membership.GetUser(userID);
            if (user.IsApproved == true)
                user.IsApproved = false;
            else
                user.IsApproved = true;
            try
            {
                Membership.UpdateUser(user);
            }
            catch
            {
            	return false;
            }
            return true;
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

        public int ShowUserInfo(ref IList<UserListInfo> userList)
        {
            string[] usernames = Roles.GetUsersInRole("��ͨ�û�");
            UserInfoDAL userDAL = new UserInfoDAL();
            UserInfo userInfo = null;
            UserListInfo userListInfo = null;
            foreach(string username in usernames)
            {
                MembershipUser user = Membership.GetUser(username);
                userInfo = new UserInfo();
                userInfo.UserID = (Guid)user.ProviderUserKey;
                userDAL.SrchUserInfo(ref userInfo);
                
                userListInfo = new UserListInfo();
                userListInfo.UserID = (Guid)user.ProviderUserKey;
                userListInfo.UserName = username;
                userListInfo.Score = userInfo.UserScore;
                userListInfo.RegTime = user.CreationDate;
                switch(userInfo.UserLv)
                {
                    case 0:
                        userListInfo.Level = "��ͨ��Ա";
                        break;
                    case 1:
                        userListInfo.Level = "�ƽ��Ա";
                        break;
                }
                switch(user.IsApproved)
                {
                    case true:
                        userListInfo.State = "����";
                        break;
                    case false:
                        userListInfo.State = "����";
                        break;
                }
                

                userList.Add(userListInfo);
            }

            return userList.Count;
        }
        # endregion
    }
}
