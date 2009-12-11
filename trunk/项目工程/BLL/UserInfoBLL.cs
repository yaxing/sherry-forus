////编写者：李开林
////日  期：2009-11-25
////功  能：普通用户信息管理的逻辑处理

using System;
using System.Collections.Generic;
using System.Web.Security;
using DAL;
using Entity;

namespace BLL
{
    public class UserInfoBLL
    {
        #region 添加新用户

        /// <summary>
        /// 添加新用户，操作成功返回true，失败返回false
        /// </summary>
        /// <param name="newuser">用户实体对象</param>
        /// <returns>bool值</returns>

        public bool AddUserInfo(UserInfo newuser)
        {
            MembershipUser user = Membership.GetUser(newuser.UserID);
            //------------------------此处用于添加用户的roles------------------------------//
            Roles.AddUserToRole(user.UserName, "普通用户");

            UserInfoDAL userDAL = new UserInfoDAL();
            if (!userDAL.AddUserInfo(newuser))
            {
                ////////此处或者需要将membership中的数据删除
                Membership.DeleteUser(user.UserName);
                return false;
            }
            return true;
        }
        #endregion

        #region 修改用户信息

        /// <summary>
        /// 删除用户，操作成功返回true，失败返回false
        /// </summary>
        /// <param name="user">用户实体对象</param>
        /// <returns>bool</returns>

        public bool ModiUserInfo(UserInfo user)
        {
            UserInfoDAL userDAL = new UserInfoDAL();
            MembershipUser muser = Membership.GetUser(user.UserRealName);
            user.UserID = (Guid)muser.ProviderUserKey;
            return userDAL.ModiUserInfo(user);
        }
        #endregion


        #region 删除用户(用户名)

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns>bool</returns>

        public bool DeleteUserInfo(String userName)
        {
            MembershipUser user = Membership.GetUser(userName);
            Guid userID = (Guid)user.ProviderUserKey;
            UserInfoDAL userDAL = new UserInfoDAL();
            return userDAL.DeleteUserInfo(userID);
        }
        #endregion

        #region 删除用户(id)

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns>bool</returns>

        public bool DeleteUserInfo(Guid userID)
        {
            UserInfoDAL userDAL = new UserInfoDAL();
            return userDAL.DeleteUserInfo(userID);
        }
        #endregion

        #region 冻结用户

        /// <summary>
        /// 冻结用户
        /// </summary>
        /// <param name="userID>用户ID</param>
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

        #region 按用户名查询用户

        /// <summary>
        /// 查询用户
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="userInfo">用户实体对象</param>
        /// <returns>bool</returns>

        public bool SrchUserInfoByUserName(ref UserInfo userInfo, string userName)
        {
            MembershipUser user = Membership.GetUser(userName);
            userInfo.UserID = (Guid)user.ProviderUserKey;
            UserInfoDAL userDAL = new UserInfoDAL();
            return userDAL.SrchUserInfo(ref userInfo);
        }

        #endregion

        # region 显示用户列表

        /// <summary>
        /// 显示用户列表
        /// </summary>
        /// <param name="userList"></param>
        /// <returns>用户个数</returns>

        public int ShowUserInfo(ref IList<UserListInfo> userList)
        {
            string[] usernames = Roles.GetUsersInRole("普通用户");
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
                        userListInfo.Level = "普通会员";
                        break;
                    case 1:
                        userListInfo.Level = "黄金会员";
                        break;
                }
                switch(user.IsApproved)
                {
                    case true:
                        userListInfo.State = "启用";
                        break;
                    case false:
                        userListInfo.State = "冻结";
                        break;
                }
                

                userList.Add(userListInfo);
            }

            return userList.Count;
        }
        # endregion
    }
}
