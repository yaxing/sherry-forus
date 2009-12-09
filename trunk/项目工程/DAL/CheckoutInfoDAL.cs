////编写者：陈亚星
////日  期：2009-12-09
////功  能：订单生成模块的数据库处理
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DbCtrl;
using Entity;

namespace DAL
{
    public class CheckoutInfoDAL
    {
        private string sqlString = string.Empty;
        private DataProvider dp;

        #region 构造用户实体
        /// <summary>
        /// 构造用户实体
        /// </summary>
        /// <param name="info">新用户实体对象</param>
        /// <returns>bool值</returns>
        public bool SetUserInfo(ref UserInfo info)
        {
            DataTable dt = new DataTable();
            sqlString = "select * from userInfo where userID=@userID";
            SqlParameter[] pt = new SqlParameter[] { 
                                new SqlParameter("@userID", SqlDbType.UniqueIdentifier)
                                };
            pt[0].Value = info.UserID;

            try
            {
                using (dp = new DataProvider())
                {
                    if ((dt = dp.ExecuteDataTable(sqlString,pt)) == null)
                        return false;
                }
            }
            catch
            {
                return false;
            }

            info.UserRealName = dt.Rows[0][1].ToString();
            info.PostAdd = dt.Rows[0][2].ToString();
            info.PostNum = dt.Rows[0][3].ToString();
            info.PhoneNum = dt.Rows[0][4].ToString();

            return true;
        }
        #endregion

        #region 修改新信息
        public bool ChangeUserInfo(UserInfo info) 
        {
            DataTable dt = new DataTable();
            sqlString = "update userInfo set userRealName=@userName, postAdd=@userAdd, postNum=@userZip, phoneNum=@userTel where userID=@userId";
            SqlParameter[] pt = new SqlParameter[] { 
                                new SqlParameter("@userID",SqlDbType.UniqueIdentifier),
                                new SqlParameter("@userName",SqlDbType.VarChar),
                                new SqlParameter("@userAdd",SqlDbType.VarChar),
                                new SqlParameter("@userZip",SqlDbType.VarChar),
                                new SqlParameter("@userTel",SqlDbType.VarChar),
                                };
            pt[0].Value = info.UserID;
            pt[1].Value = info.UserRealName;
            pt[2].Value = info.PostAdd;
            pt[3].Value = info.PostNum;
            pt[4].Value = info.PhoneNum;
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
