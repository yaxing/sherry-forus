/************************************************************************/
/*��д�ߣ�������                                                        */
/*��  �ڣ�2009-11-29                                                    */
/*��  �ܣ�����Ա��Ϣ������߼�����                                      */
/************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Security;
using DAL;
using Entity;

namespace BLL
{
    class AdminInfoBLL
    {
        #region ��ӹ���Ա

        /// <summary>
        /// ��ӹ���Ա�������ɹ�����true��ʧ�ܷ���false
        /// </summary>
        /// <param name="newadmin">ʵ�����</param>
        /// <returns>boolֵ</returns>

        public bool AddAdmin(AdminInfo newadmin)
        {

            MembershipUser admin = Membership.CreateUser(newadmin.AdminRealName, newadmin.AdminRealName, newadmin.AdminEmailAdd);

            //------------------------�˴�������ӹ���Ա��roles------------------------------//
            Roles.AddUserToRole(newadmin.AdminRealName, "����Ա");


            newadmin.AdminID = (Guid)admin.ProviderUserKey;
            if (admin == null)
                return false;
            else
            {
                AdminInfoDAL adminDAL = new AdminInfoDAL();
                if (!adminDAL.AddAdmin(newadmin))
                {
                    ////////�˴���membership�е�����ɾ��
                    Membership.DeleteUser(newadmin.AdminRealName);
                    return false;
                }
            }

            return true;
        }
        #endregion

        #region �޸Ĺ���Ա��Ϣ

        /// <summary>
        /// �޸Ĺ���Ա��Ϣ�������ɹ�����true��ʧ�ܷ���false
        /// </summary>
        /// <param name="admin">ʵ�����</param>
        /// <returns>bool</returns>

        public bool ModiAdminInfo(AdminInfo admin)
        {
            AdminInfoDAL adminDAL = new AdminInfoDAL();
            MembershipUser muser = Membership.GetUser(admin.AdminRealName);
            admin.AdminID = (Guid)muser.ProviderUserKey;
            return adminDAL.ModiAdminInfo(admin);
        }
        #endregion


        #region ɾ������Ա

        /// <summary>
        /// ɾ������Ա
        /// </summary>
        /// <param name="adminName">����Ա�û���</param>
        /// <returns>bool</returns>

        public bool DeleteAdmin(String adminName)
        {
            MembershipUser user = Membership.GetUser(adminName);
            Guid adminID = (Guid)user.ProviderUserKey;
            AdminInfoDAL adminDAL = new AdminInfoDAL();
            return adminDAL.DeleteAdmin(adminID);
        }
        #endregion

        #region ������Ա�û�����ѯ����Ա��Ϣ

        /// <summary>
        /// ��ѯ����Ա��Ϣ
        /// </summary>
        /// <param name="adminName">����Ա�û���</param>
        /// <param name="adminInfo">ʵ�����</param>
        /// <returns>bool</returns>

        public bool SrchAdminInfoByUserName(ref AdminInfo adminInfo, string adminName)
        {
            MembershipUser admin = Membership.GetUser(adminName);
            adminInfo.AdminID = (Guid)admin.ProviderUserKey;
            AdminInfoDAL adminDAL = new AdminInfoDAL();
            return adminDAL.SrchAdminInfo(ref adminInfo);
        }

        #endregion

        # region ��ʾ����Ա�б�

        /// <summary>
        /// ��ʾ����Ա�б�
        /// </summary>
        /// <param name="adminList"></param>
        /// <returns>����Ա����</returns>

        public int ShowUserInfo(ref IList<AdminInfo> adminList)
        {
            string[] usernames = Roles.GetUsersInRole("����Ա");
            AdminInfoDAL adminDAL = new AdminInfoDAL();
            AdminInfo adminInfo = null;
            foreach (string username in usernames)
            {
                MembershipUser user = Membership.GetUser(username);
                adminInfo.UserID = (Guid)user.ProviderUserKey;
                adminDAL.SrchAdminInfo(ref adminInfo);
                adminList.Add(adminInfo);
            }

            return adminList.Count;
        }
        # endregion

        # region �޸Ĺ���Ա�ȼ�

        /// <summary>
        /// �޸Ĺ���Ա�ȼ��������ɹ�����true��ʧ�ܷ���false
        /// </summary>
        /// <param name="admin">ʵ�����</param>
        /// <returns>bool</returns>

        public bool ModiAdminLv(AdminInfo admin)
        {
            AdminInfoDAL adminDAL = new AdminInfoDAL();
            MembershipUser muser = Membership.GetUser(admin.AdminRealName);
            admin.AdminID = (Guid)muser.ProviderUserKey;
            return adminDAL.ModiAdminLv(admin);
        }
        # endregion
    }
}
