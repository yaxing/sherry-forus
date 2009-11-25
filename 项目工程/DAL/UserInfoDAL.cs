////编写者：李开林
////日  期：2009-11-25
////功  能：普通用户信息数据访问操作

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DbCtrl;
using Entity;

namespace DAL
{
    public class UserInfoDAL
    {
        private string sqlString = string.Empty;
        private DataProvider dp;

        #region 添加新用户

        /// <summary>
        /// 添加新用户
        /// </summary>
        /// <param name="newuser">新用户实体对象</param>
        /// <returns>bool值</returns>

        public bool AddUserInfo(UserInfo newuser)
        {
            sqlString = "Insert Into userInfo (userID,userRealName,emailAdd,postAdd,postNum,userScore,userLv,userBirth,userGender,userAge,IDCardNum)"
                        + " Values (@userID,@userRealName,@emailAdd,@postAdd,@postNum,@userScore,@userLv,@userBirth,@userGender,@userAge,@IDCardNum)";

            SqlParameter[] pt = new SqlParameter[] { 
                                new SqlParameter("@userID", SqlDbType.UniqueIdentifier),
                                new SqlParameter("@userRealName",SqlDbType.VarChar),
                                new SqlParameter("@emailAdd",SqlDbType.VarChar),
                                new SqlParameter("@postAdd",SqlDbType.VarChar),
                                new SqlParameter("@postNum",SqlDbType.VarChar),
                                new SqlParameter("@phoneNum",SqlDbType.VarChar),
                                new SqlParameter("@userScore",SqlDbType.Int),
                                new SqlParameter("@userLv",SqlDbType.Int),
                                new SqlParameter("@userBirth",SqlDbType.DateTime),
                                new SqlParameter("@userGender",SqlDbType.Int),
                                new SqlParameter("@userAge",SqlDbType.Int),
                                new SqlParameter("@IDCardNum",SqlDbType.VarChar) 
                                };
            pt[0].Value = newuser.UserID;
            pt[1].Value = newuser.UserRealName;
            pt[2].Value = newuser.EmailAdd;
            pt[3].Value = newuser.PostAdd;
            pt[4].Value = newuser.PostNum;
            pt[5].Value = newuser.PhoneNum;
            pt[6].Value = newuser.UserScore;
            pt[7].Value = newuser.UserLv;
            pt[8].Value = newuser.UserBirth;
            pt[9].Value = newuser.UserGender;
            pt[10].Value = newuser.UserAge;
            pt[11].Value = newuser.IDCardNum;

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

        #region 删除单个用户

        /// <summary>
        /// 删除单个用户
        /// </summary>
        /// <param name="userID">用户的id值</param>
        /// <returns>bool</returns>

        public bool DeleteUserInfo(Guid userID)////////////////数据字段需要更改
        {
            sqlString = "delete from userInfo where id = @userID";
            SqlParameter[] pt = new SqlParameter[] { 
                                new SqlParameter("@userID", SqlDbType.UniqueIdentifier)
                                };
            pt[0].Value = userID;

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

        #region 修改用户信息

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="user">用户实体对象</param>
        /// <returns>bool值</returns>

        public bool ModiUserInfo(UserInfo user)
        {
            string preSqlString = "Update userInfo Set userRealName = @userRealName , emailAdd = @emailAdd , postAdd = @postAdd , postNum = @postNum , phoneNum = @phoneNum , "
                                  + "userScore = @userScore , userLv = @userLv , userBirth = @userBirth , userGender = @userGender , userAge = @userAge , IDCardNum = @IDCardNum "
                                  + "where userID = @userID";
            SqlParameter[] pt = new SqlParameter[] { 
                                new SqlParameter("@userID", SqlDbType.UniqueIdentifier),
                                new SqlParameter("@userRealName",SqlDbType.VarChar),
                                new SqlParameter("@emailAdd",SqlDbType.VarChar),
                                new SqlParameter("@postAdd",SqlDbType.VarChar),
                                new SqlParameter("@postNum",SqlDbType.VarChar),
                                new SqlParameter("@phoneNum",SqlDbType.VarChar),
                                new SqlParameter("@userScore",SqlDbType.Int),
                                new SqlParameter("@userLv",SqlDbType.Int),
                                new SqlParameter("@userBirth",SqlDbType.DateTime),
                                new SqlParameter("@userGender",SqlDbType.Int),
                                new SqlParameter("@userAge",SqlDbType.Int),
                                new SqlParameter("@IDCardNum",SqlDbType.VarChar)
                                };
            pt[0].Value = user.UserRealName;

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

        #region 显示所有用户

        /// <summary>
        /// 显示用户列表
        /// </summary>
        /// <param name="userList">用户实体对象集合</param>
        /// <returns>集合元素个数</returns>

        public int ShowUserInfo(ref IList<UserInfo> userList)
        {
            sqlString = "select * from userInfo";

            try
            {
                using (dp = new DataProvider())
                {
                    using (SqlDataReader reader = dp.ExecuteReader(sqlString))
                    {
                        UserInfo user = null;
                        while (reader.Read())
                        {
                            user = new UserInfo();

                            user.UserID = reader.GetGuid(0);
                            user.UserRealName = reader.GetString(1);
                            user.EmailAdd = reader.GetString(2);
                            user.PostAdd = reader.GetString(3);
                            user.PostNum = reader.GetString(4);
                            user.PhoneNum = reader.GetString(5);
                            user.UserScore = reader.GetInt32(6);
                            user.UserLv = reader.GetInt32(7);
                            user.UserBirth = reader.GetDateTime(8);
                            user.UserGender = reader.GetInt32(9);
                            user.UserAge = reader.GetInt32(10);
                            user.IDCardNum = reader.GetString(11);

                            userList.Add(user);
                        }
                    }
                }
            }
            catch
            {
                return 0;
            }

            return userList.Count;
        }

        #endregion

        # region 根据用户id查询用户

        /// <summary>
        /// 查询用户信息
        /// </summary>
        /// <param name="user">用户实体对象</param>
        /// <returns>bool值</returns>

        public bool SrchUserInfo(ref UserInfo user)
        {
            sqlString = "select * from userInfo where id = @userID";
            SqlParameter[] pt = new SqlParameter[]{
                                new SqlParameter("@userID", SqlDbType.UniqueIdentifier),
                                };
            pt[0].Value = user.UserID;

            try
            {
                using (dp = new DataProvider())
                {
                    using (SqlDataReader reader = dp.ExecuteReader(sqlString, pt))
                    {
                        while (reader.Read())
                        {
                            user.UserID = reader.GetGuid(0);
                            user.UserRealName = reader.GetString(1);
                            user.EmailAdd = reader.GetString(2);
                            user.PostAdd = reader.GetString(3);
                            user.PostNum = reader.GetString(4);
                            user.PhoneNum = reader.GetString(5);
                            user.UserScore = reader.GetInt32(6);
                            user.UserLv = reader.GetInt32(7);
                            user.UserBirth = reader.GetDateTime(8);
                            user.UserGender = reader.GetInt32(9);
                            user.UserAge = reader.GetInt32(10);
                            user.IDCardNum = reader.GetString(11);
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
    }
}
