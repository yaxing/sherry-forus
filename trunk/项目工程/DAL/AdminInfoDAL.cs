/************************************************************************/
/*��д�ߣ�������                                                        */
/*��  �ڣ�2009-11-29                                                    */
/*��  �ܣ�����Ա��Ϣ���ݷ��ʲ���                                        */
/************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DbCtrl;
using Entity;

namespace DAL
{
    public class AdminInfoDAL:UserInfoDAL
    {
        private string sqlString = string.Empty;
        private DataProvider dp;

        #region ������û�

        /// <summary>
        /// ��ӹ���Ա
        /// </summary>
        /// <param name="newadmin">���û�ʵ�����</param>
        /// <returns>boolֵ</returns>

        public bool AddAdmin(AdminInfo newadmin)
        {
            sqlString = "Insert Into adminInfo (adminID,adminRealName,emailAdd,phoneNum,adminLv)"
                        + " Values (@adminID,@adminRealName,@emailAdd,@phoneNum,@adminLv)";

            SqlParameter[] pt = new SqlParameter[] { 
                                new SqlParameter("@adminID", SqlDbType.UniqueIdentifier),
                                new SqlParameter("@adminRealName",SqlDbType.VarChar),
                                new SqlParameter("@emailAdd",SqlDbType.VarChar),
                                new SqlParameter("@phoneNum",SqlDbType.VarChar),
                                new SqlParameter("@adminLv",SqlDbType.Int)
                                };
            pt[0].Value = newadmin.AdminID;
            pt[1].Value = newadmin.AdminRealName;
            pt[2].Value = newadmin.AdminEmailAdd;
            pt[3].Value = newadmin.AdminPhoneNum;
            pt[4].Value = newadmin.AdminLv;

            try
            {
                using (dp = new DataProvider())
                {
                    if (dp.ExecuteNonQuery(sqlString, pt) == 0)
                        return false;
                }
            }
            catch
            {
                return false;
            }

            return true;
        }
        #endregion

        #region ɾ����������Ա

        /// <summary>
        /// ɾ����������Ա
        /// </summary>
        /// <param name="adminID">����Աidֵ</param>
        /// <returns>bool</returns>

        public bool DeleteAdmin(Guid adminID)
        {
            sqlString = "Delete from adminInfo where adminID = @adminID";
            SqlParameter[] pt = new SqlParameter[] { 
                                new SqlParameter("@adminID", SqlDbType.UniqueIdentifier)
                                };
            pt[0].Value = adminID;

            try
            {
                using (dp = new DataProvider())
                {
                    if (dp.ExecuteNonQuery(sqlString, pt) == 0)
                        return false;
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        #endregion

        #region �޸Ĺ���Ա��Ϣ

        /// <summary>
        /// �޸Ĺ���Ա��Ϣ
        /// </summary>
        /// <param name="admin">ʵ�����</param>
        /// <returns>boolֵ</returns>

        public bool ModiAdminInfo(AdminInfo admin)
        {
            string preSqlString = "Update adminInfo Set adminRealName = @adminRealName , emailAdd = @emailAdd , phoneNum = @phoneNum , adminLv = @adminLv "
                                  + "where adminID = @adminID";
            SqlParameter[] pt = new SqlParameter[] { 
                                new SqlParameter("@adminID", SqlDbType.UniqueIdentifier),
                                new SqlParameter("@adminRealName",SqlDbType.VarChar),
                                new SqlParameter("@emailAdd",SqlDbType.VarChar),
                                new SqlParameter("@phoneNum",SqlDbType.VarChar),
                                new SqlParameter("@adminLv",SqlDbType.Int)
                                };
            pt[0].Value = admin.AdminID;
            pt[1].Value = admin.AdminRealName;
            pt[2].Value = admin.AdminEmailAdd;
            pt[3].Value = admin.AdminPhoneNum;
            pt[4].Value = admin.AdminLv;

            try
            {
                using (dp = new DataProvider())
                {
                    if (dp.ExecuteNonQuery(sqlString, pt) == 0)
                        return false;
                }
            }
            catch
            {
                return false;
            }

            return true;
        }
        #endregion

        #region ��ʾ����Ա

        /// <summary>
        /// ��ʾ����Ա�б�
        /// </summary>
        /// <param name="adminList">ʵ����󼯺�</param>
        /// <returns>����Ԫ�ظ���</returns>

        public int ShowAdminInfo(ref IList<AdminInfo> adminList)
        {
            sqlString = "select * from adminInfo";

            try
            {
                using (dp = new DataProvider())
                {
                    using (SqlDataReader reader = dp.ExecuteReader(sqlString))
                    {
                        AdminInfo admin = null;
                        while (reader.Read())
                        {
                            admin = new AdminInfo();

                            admin.AdminID = reader.GetGuid(0);
                            admin.AdminRealName = reader.GetString(1);
                            admin.AdminEmailAdd = reader.GetString(2);
                            admin.AdminPhoneNum = reader.GetString(3);
                            admin.AdminLv = reader.GetInt32(4);

                            adminList.Add(admin);
                        }
                    }
                }
            }
            catch
            {
                return 0;
            }

            return adminList.Count;
        }

        #endregion

        # region ����id��ѯ����Ա

        /// <summary>
        /// ��ѯ����Ա��Ϣ
        /// </summary>
        /// <param name="admin">ʵ�����</param>
        /// <returns>boolֵ</returns>

        public bool SrchAdminInfo(ref AdminInfo admin)
        {
            sqlString = "select * from adminInfo where adminID = @adminID";
            SqlParameter[] pt = new SqlParameter[]{
                                new SqlParameter("@adminID", SqlDbType.UniqueIdentifier)
                                };
            pt[0].Value = admin.AdminID;

            try
            {
                using (dp = new DataProvider())
                {
                    using (SqlDataReader reader = dp.ExecuteReader(sqlString, pt))
                    {
                        while (reader.Read())
                        {
                            admin.AdminID = reader.GetGuid(0);
                            admin.AdminRealName = reader.GetString(1);
                            admin.AdminEmailAdd = reader.GetString(2);
                            admin.AdminPhoneNum = reader.GetString(3);
                            admin.AdminLv = reader.GetInt32(4);
                        }
                    }
                }
            }
            catch
            {
                ///////�˴����Է���false
                return false;
            }

            return true;
        }
        # endregion

        #region ����Ա�������

        /// <summary>
        /// ��������Ա����
        /// </summary>
        /// <param name="admin">ʵ�����</param>
        /// <returns>boolֵ</returns> 

        public bool ModiAdminLv(AdminInfo admin)
        {
            sqlString = "Update adminInfo Set adminLv = @adminLv where adminID = @adminID";
            SqlParameter[] pt = new SqlParameter[]{
                                new SqlParameter("@adminLv", SqlDbType.Int),
                                new SqlParameter("@adminID", SqlDbType.UniqueIdentifier)
                                };
            pt[1].Value = admin.AdminID;
            pt[0].Value = admin.AdminLv;

            try
            {
                using (dp = new DataProvider())
                {
                    if (dp.ExecuteNonQuery(sqlString, pt) == 0)
                        return false;
                }
            }
            catch
            {
                return false;
            }

            return true;

        }

        #endregion
    }
}
