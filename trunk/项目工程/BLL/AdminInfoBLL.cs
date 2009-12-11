/************************************************************************/
/*编写者：张翼鹏                                                        */
/*日  期：2009-11-29                                                    */
/*功  能：管理员信息管理的逻辑处理                                      */
/************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Security;
using DAL;
using Entity;

namespace BLL
{
    public class AdminInfoBLL:UserInfoBLL
    {
        #region 添加管理员

        /// <summary>
        /// 添加管理员，操作成功返回true，失败返回false
        /// </summary>
        /// <param name="newadmin">实体对象</param>
        /// <returns>bool值</returns>

        public bool AddAdmin(AdminInfo newadmin)
        {
            MembershipUser user = Membership.GetUser(newadmin.AdminID);
            //------------------------此处用于添加管理员的roles------------------------------//
            Roles.AddUserToRole(user.UserName, "管理员");

            AdminInfoDAL adminDAL = new AdminInfoDAL();
            if (!adminDAL.AddAdmin(newadmin))
            {
                ////////此处将membership中的数据删除
                Membership.DeleteUser(user.UserName);
                return false;
            }

            return true;
        }
        #endregion

        #region 修改管理员信息

        /// <summary>
        /// 修改管理员信息，操作成功返回true，失败返回false
        /// </summary>
        /// <param name="admin">实体对象</param>
        /// <returns>bool</returns>

        public bool ModiAdminInfo(AdminInfo admin)
        {
            AdminInfoDAL adminDAL = new AdminInfoDAL();
            MembershipUser muser = Membership.GetUser(admin.AdminRealName);
            admin.AdminID = (Guid)muser.ProviderUserKey;
            return adminDAL.ModiAdminInfo(admin);
        }
        #endregion

        #region 删除管理员(用户名)

        /// <summary>
        /// 删除管理员
        /// </summary>
        /// <param name="adminName">管理员用户名</param>
        /// <returns>bool</returns>

        public bool DeleteAdmin(String adminName)
        {
            MembershipUser user = Membership.GetUser(adminName);
            Guid adminID = (Guid)user.ProviderUserKey;
            AdminInfoDAL adminDAL = new AdminInfoDAL();
            return adminDAL.DeleteAdmin(adminID);
        }
        #endregion

        #region 删除管理员(ID)

        /// <summary>
        /// 删除管理员
        /// </summary>
        /// <param name="adminID">管理员用户名</param>
        /// <returns>bool</returns>

        public bool DeleteAdmin(Guid adminID)
        {
            AdminInfoDAL adminDAL = new AdminInfoDAL();
            try
            {
                if (!adminDAL.DeleteAdmin(adminID))
                {
                    return false;
                }
                MembershipUser user = Membership.GetUser(adminID);
                Membership.DeleteUser(user.UserName,true);
            }
            catch
            {
                return false;
            }
            return true;
        }
        #endregion

        #region 按管理员用户名查询管理员信息

        /// <summary>
        /// 查询管理员信息
        /// </summary>
        /// <param name="adminName">管理员用户名</param>
        /// <param name="adminInfo">实体对象</param>
        /// <returns>bool</returns>

        public bool SrchAdminInfoByUserName(ref AdminInfo adminInfo, string adminName)
        {
            MembershipUser admin = Membership.GetUser(adminName);
            adminInfo.AdminID = (Guid)admin.ProviderUserKey;
            AdminInfoDAL adminDAL = new AdminInfoDAL();
            return adminDAL.SrchAdminInfo(ref adminInfo);
        }

        #endregion

        # region 显示管理员列表

        /// <summary>
        /// 显示管理员列表
        /// </summary>
        /// <param name="adminList"></param>
        /// <returns>管理员个数</returns>

        public int ShowAdminInfo(ref IList<AdminListInfo> adminList)
        {
            string[] adminNames = Roles.GetUsersInRole("管理员");
            AdminInfoDAL adminDAL = new AdminInfoDAL();
            AdminInfo adminInfo = null;
            AdminListInfo adminListInfo = null;
            foreach (string adminName in adminNames)
            {
                MembershipUser user = Membership.GetUser(adminName);
                adminInfo = new AdminInfo();
                adminInfo.AdminID = (Guid)user.ProviderUserKey;
                adminDAL.SrchAdminInfo(ref adminInfo);

                adminListInfo = new AdminListInfo();
                adminListInfo.AdminID = (Guid)user.ProviderUserKey;
                adminListInfo.AdminName = adminName;
                adminListInfo.AddTime = user.CreationDate;
                switch (adminInfo.AdminLv)
                {
                    case 0:
                        adminListInfo.AdminType = "商品管理员";
                        break;
                    case 1:
                        adminListInfo.AdminType = "市场管理员";
                        break;
                    case 2:
                        adminListInfo.AdminType = "人事管理员";
                        break;
                    case 3:
                        adminListInfo.AdminType = "管理经理";
                        break;
                    case 4:
                        adminListInfo.AdminType = "顶级管理员";
                        break;
                }
                switch (user.IsApproved)
                {
                    case true:
                        adminListInfo.State = "启用";
                        break;
                    case false:
                        adminListInfo.State = "冻结";
                        break;
                }


                adminList.Add(adminListInfo);
            }

            return adminList.Count;
        }
        # endregion

        # region 修改管理员等级

        /// <summary>
        /// 修改管理员等级，操作成功返回true，失败返回false
        /// </summary>
        /// <param name="admin">实体对象</param>
        /// <returns>bool</returns>

        public bool ModiAdminLv(AdminInfo admin)
        {
            AdminInfoDAL adminDAL = new AdminInfoDAL();
            return adminDAL.ModiAdminLv(admin);
        }
        # endregion
    }
}
