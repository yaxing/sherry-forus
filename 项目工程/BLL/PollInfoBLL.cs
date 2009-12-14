////编写者：林思然
////日  期：2009-12-11
////功  能：投票信息的逻辑处理

using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using Entity;

namespace BLL
{
    public class PollInfoBLL
    {
        #region 添加新投票主表

        /// <summary>
        /// 添加新投票主表
        /// </summary>
        /// <param name="newMainPoll">投票主表实体对象</param>
        /// <returns>ID值</returns>

        public int AddMainPollInfo(MainPoll newMainPoll)
        {

            MainPollDAL mainPollDAL = new MainPollDAL();
            return mainPollDAL.AddMainPoll(newMainPoll);
        }
        #endregion

        
        #region 添加新投票副表

        /// <summary>
        /// 添加新投票副表，操作成功返回true，失败返回false
        /// </summary>
        /// <param name="newMainPoll">投票副表实体对象</param>
        /// <returns>bool值</returns>

        public bool AddSubPollInfo(SubPoll newSubPoll)
        {

            SubPollDAL subPollDAL = new SubPollDAL();
            return subPollDAL.AddSubPoll(newSubPoll);
        }
        #endregion

        /*#region 修改用户信息

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


        #region 删除用户

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
        */
        #region 按投票ID查询

        /// <summary>
        /// 查询投票
        /// </summary>
        /// <param name="mainPoll">投票主表</param>
        /// <returns>bool</returns>

        public bool SelectByID(ref MainPoll mainPoll)
        {
            MainPollDAL mainPollDAL = new MainPollDAL();
            return mainPollDAL.SelectByID(ref mainPoll);
        }

        #endregion

        #region 根据主表ID查询投票分表

        /// <summary>
        /// 查询投票分表
        /// </summary>
        /// <param name="mainPoll">主表</param>
        /// <param name="subPollList">分表集合</param>
        /// <returns>bool</returns>

        public int SelectSubPollByID(ref IList<SubPoll> subPollList, MainPoll mainPoll)
        {
            SubPollDAL subPoll = new SubPollDAL();
            return subPoll.ShowSubPoll(ref subPollList,mainPoll.MainPollID);
        }

        #endregion

        #region 查询投票主表数

        /// <summary>
        /// 查询投票主表数
        /// </summary>
        /// <returns>int</returns>

        public int NumOfMainPoll()
        {
            MainPollDAL pollNum = new MainPollDAL();
            return pollNum.NumOfMainPoll();
        }

        #endregion

        #region 页面显示查询

        /// <summary>
        /// 页面显示查询
        /// </summary>
        /// <param name="currentPage">当前页面</param>
        /// <returns>int</returns>

        public bool GetPageShow(ref IList<MainPoll> ds, int currentPage)
        {
            MainPollDAL pollNum = new MainPollDAL();
            if (currentPage == 0)
            {
                return pollNum.SelectTopN(ref ds, 1);
            }
            else
            {
                return pollNum.SelectTopMNotN(ref ds, 1, currentPage);
            }
        }

        #endregion

        #region 更新投票数

        /// <summary>
        /// 更新投票数
        /// </summary>
        /// <param name="subPoll">投票分表</param>
        /// <returns>bool</returns>

        public bool UpdatePollNum(SubPoll subPoll)
        {
            SubPollDAL subPollDAL = new SubPollDAL();
            return subPollDAL.UpdatePollNum(subPoll);
        }

        #endregion


        /*# region 显示用户列表

        /// <summary>
        /// 显示用户列表
        /// </summary>
        /// <param name="userList"></param>
        /// <returns>用户个数</returns>

        public int ShowUserInfo(ref IList<UserInfo> userList)
        {
            string[] usernames = Roles.GetUsersInRole("普通用户");
            UserInfoDAL userDAL = new UserInfoDAL();
            UserInfo userInfo = null;
            foreach (string username in usernames)
            {
                MembershipUser user = Membership.GetUser(username);
                userInfo.UserID = (Guid)user.ProviderUserKey;
                userDAL.SrchUserInfo(ref userInfo);
                userList.Add(userInfo);
            }

            return userList.Count;
        }
        # endregion*/
    }
}
