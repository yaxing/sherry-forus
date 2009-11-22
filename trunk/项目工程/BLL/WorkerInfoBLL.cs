////编写者：李开林
////日  期：2009-11-18
////功  能：用户信息管理的逻辑处理

using System;
using System.Collections.Generic;
using System.Web.Security;
using DAL;
using Entity;

namespace BLL
{
    public class WorkerInfoBLL
    {
        #region 添加新用户

        /// <summary>
        /// 添加新用户，操作成功返回true，失败返回false
        /// </summary>
        /// <param name="newuser">用户实体对象</param>
        /// <returns>bool值</returns>

        public bool AddWorkerInfo(WorkerInfo newuser)
        {

            MembershipUser user = Membership.CreateUser(newuser.Name, newuser.Name, newuser.Name);

            //------------------------此处用于添加用户的roles------------------------------//
            Roles.AddUserToRole(newuser.Name, "工作人员");


            newuser.Id = (Guid)user.ProviderUserKey;
            if (user == null)
                return false;
            else
            {
                WorkerInfoDAL userDAL = new WorkerInfoDAL();
                if (!userDAL.AddWorkerInfo(newuser))
                {
                    ////////此处或者需要将membership中的数据删除
                    return false;
                }
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

        public bool ModiWorkerInfo(WorkerInfo user)
        {
            WorkerInfoDAL userDAL = new WorkerInfoDAL();
            MembershipUser muser = Membership.GetUser(user.Name);
            user.Id = (Guid)muser.ProviderUserKey;
            return userDAL.ModiWorkerInfo(user);
        }
        #endregion


        #region 删除用户

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns>bool</returns>

        public bool DeleteWorkerInfo(String userName)
        {
            MembershipUser user = Membership.GetUser(userName);
            Guid userID = (Guid)user.ProviderUserKey;
            WorkerInfoDAL userDAL = new WorkerInfoDAL();
            return userDAL.DeleteWorkerInfo(userID);
        }
        #endregion

        #region 按用户名查询用户

        /// <summary>
        /// 查询用户
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="userInfo">用户实体对象</param>
        /// <returns>bool</returns>

        public bool SrchComNetUserByEmail(ref WorkerInfo userInfo, string userName)
        {
            MembershipUser user = Membership.GetUser(userName);
            userInfo.Id = (Guid)user.ProviderUserKey;
            WorkerInfoDAL userDAL = new WorkerInfoDAL();
            return userDAL.SrchWorkerInfo(ref userInfo);
        }

        #endregion

        # region 显示用户列表

        /// <summary>
        /// 显示用户列表
        /// </summary>
        /// <param name="userList"></param>
        /// <returns>用户个数</returns>

        public int ShowComNetUser(ref IList<WorkerInfo> userList)
        {
            WorkerInfoDAL userDAL = new WorkerInfoDAL();
            return userDAL.ShowWorkerInfo(ref userList);
        }
        # endregion
    }
}
