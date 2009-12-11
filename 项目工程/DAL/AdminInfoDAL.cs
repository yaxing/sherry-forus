/************************************************************************/
/*编写者：张翼鹏                                                        */
/*日  期：2009-11-29                                                    */
/*功  能：管理员信息数据访问操作                                        */
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

        #region 添加新用户

        /// <summary>
        /// 添加管理员
        /// </summary>
        /// <param name="newadmin">新用户实体对象</param>
        /// <returns>bool值</returns>

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

        #region 删除单个管理员

        /// <summary>
        /// 删除单个管理员
        /// </summary>
        /// <param name="adminID">管理员id值</param>
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

        #region 修改管理员信息

        /// <summary>
        /// 修改管理员信息
        /// </summary>
        /// <param name="admin">实体对象</param>
        /// <returns>bool值</returns>

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

        #region 显示管理员

        /// <summary>
        /// 显示管理员列表
        /// </summary>
        /// <param name="adminList">实体对象集合</param>
        /// <returns>集合元素个数</returns>

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

        # region 根据id查询管理员

        /// <summary>
        /// 查询管理员信息
        /// </summary>
        /// <param name="admin">实体对象</param>
        /// <returns>bool值</returns>

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
                ///////此处可以返回false
                return false;
            }

            return true;
        }
        # endregion

        #region 管理员级别调整

        /// <summary>
        /// 调整管理员级别
        /// </summary>
        /// <param name="admin">实体对象</param>
        /// <returns>bool值</returns> 

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
