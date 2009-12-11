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
    public class AdminInfoBLL:UserInfoBLL
    {
        #region ��ӹ���Ա

        /// <summary>
        /// ��ӹ���Ա�������ɹ�����true��ʧ�ܷ���false
        /// </summary>
        /// <param name="newadmin">ʵ�����</param>
        /// <returns>boolֵ</returns>

        public bool AddAdmin(AdminInfo newadmin)
        {
            MembershipUser user = Membership.GetUser(newadmin.AdminID);
            //------------------------�˴�������ӹ���Ա��roles------------------------------//
            Roles.AddUserToRole(user.UserName, "����Ա");

            AdminInfoDAL adminDAL = new AdminInfoDAL();
            if (!adminDAL.AddAdmin(newadmin))
            {
                ////////�˴���membership�е�����ɾ��
                Membership.DeleteUser(user.UserName);
                return false;
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

        #region ɾ������Ա(�û���)

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

        #region ɾ������Ա(ID)

        /// <summary>
        /// ɾ������Ա
        /// </summary>
        /// <param name="adminID">����Ա�û���</param>
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

        public int ShowAdminInfo(ref IList<AdminListInfo> adminList)
        {
            string[] adminNames = Roles.GetUsersInRole("����Ա");
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
                        adminListInfo.AdminType = "��Ʒ����Ա";
                        break;
                    case 1:
                        adminListInfo.AdminType = "�г�����Ա";
                        break;
                    case 2:
                        adminListInfo.AdminType = "���¹���Ա";
                        break;
                    case 3:
                        adminListInfo.AdminType = "������";
                        break;
                    case 4:
                        adminListInfo.AdminType = "��������Ա";
                        break;
                }
                switch (user.IsApproved)
                {
                    case true:
                        adminListInfo.State = "����";
                        break;
                    case false:
                        adminListInfo.State = "����";
                        break;
                }


                adminList.Add(adminListInfo);
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
            return adminDAL.ModiAdminLv(admin);
        }
        # endregion
    }
}
