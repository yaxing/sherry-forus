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
        /// <param name="newWorker">用户实体对象</param>
        /// <returns>bool值</returns>

        public bool AddWorkerInfo(WorkerInfo newWorker)
        {
            MembershipUser mWorker = Membership.GetUser(newWorker.WorkerID);
            //------------------------此处用于添加用户的roles------------------------------//
            Roles.AddUserToRole(mWorker.UserName, "工作人员");

            if (mWorker == null)
                return false;
            else
            {
                WorkerInfoDAL workerDAL = new WorkerInfoDAL();
                if (!workerDAL.AddWorkerInfo(newWorker))
                {
                    ////////此处或者需要将membership中的数据删除
                    Membership.DeleteUser(mWorker.UserName,true);
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
            WorkerInfoDAL workerDAL = new WorkerInfoDAL();
            return workerDAL.ModiWorkerInfo(user);
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
            userInfo.WorkerID = (Guid)user.ProviderUserKey;
            WorkerInfoDAL userDAL = new WorkerInfoDAL();
            return userDAL.SrchWorkerInfo(ref userInfo);
        }

        #endregion
        
        #region 查询店面负责人员信息

        /// <summary>
        /// 查询店面负责人员信息
        /// </summary>
        /// <param name="shopManager">工作人员实体对象</param>
        /// <returns>操作成功返回true，否则返回false</returns>

        public bool SrchShopManager(ref WorkerInfo shopManager)
        {
            WorkerInfoDAL workerInfoDAL = new WorkerInfoDAL();
            return workerInfoDAL.SrchShopManager(ref shopManager);
        }
        #endregion

        #region 选择店面送货人员

        /// <summary>
        /// 选择店面送货人员
        /// </summary>
        /// <param name="workerInfo">工作人员实体对象</param>
        /// <returns>操作成功返回true，否则返回false</returns>

        public bool SelectWorkerByShop(ref WorkerInfo workerInfo)
        {
            WorkerInfoDAL workerInfoDAL = new WorkerInfoDAL();
            return workerInfoDAL.SelectWorkerByShop(ref workerInfo);
        }

        #endregion

        #region 分配订单给某送货人员

        /// <summary>
        /// 分配订单给某送货人员
        /// </summary>
        /// <param name="workerInfo">工作人员实体对象</param>
        /// <returns>操作成功返回true，否则返回false</returns>

        public bool AssignOrder(WorkerInfo workerInfo)
        {
            WorkerInfoDAL workerInfoDAL = new WorkerInfoDAL();
            return workerInfoDAL.AssignOrder(workerInfo);
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
