////��д�ߣ����
////��  �ڣ�2009-11-25
////��  �ܣ���ͨ�û���Ϣ���ݷ��ʲ���

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

        #region ������û�

        /// <summary>
        /// ������û�
        /// </summary>
        /// <param name="newuser">���û�ʵ�����</param>
        /// <returns>boolֵ</returns>

        public bool AddUserInfo(UserInfo newuser)
        {
            sqlString = "Insert Into userInfo (userID,userRealName,postAdd,postNum,phoneNum,userScore,userLv,userBirth,userGender,userAge,IDCardNum)"
                        + " Values (@userID,@userRealName,@postAdd,@postNum,@phoneNum,@userScore,@userLv,@userBirth,@userGender,@userAge,@IDCardNum)";

            SqlParameter[] pt = new SqlParameter[] { 
                                new SqlParameter("@userID", SqlDbType.UniqueIdentifier),
                                new SqlParameter("@userRealName",SqlDbType.VarChar),
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
            pt[2].Value = newuser.PostAdd;
            pt[3].Value = newuser.PostNum;
            pt[4].Value = newuser.PhoneNum;
            pt[5].Value = 0;
            pt[6].Value = 1;
            pt[7].Value = newuser.UserBirth;
            pt[8].Value = newuser.UserGender;
            pt[9].Value = newuser.UserAge;
            pt[9].Value = newuser.UserAge;
            pt[10].Value = newuser.IDCardNum;

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

        #region ɾ�������û�

        /// <summary>
        /// ɾ�������û�
        /// </summary>
        /// <param name="userID">�û���idֵ</param>
        /// <returns>bool</returns>

        public bool DeleteUserInfo(Guid userID)////////////////�����ֶ���Ҫ����
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

        #region �޸��û���Ϣ

        /// <summary>
        /// �޸��û���Ϣ
        /// </summary>
        /// <param name="user">�û�ʵ�����</param>
        /// <returns>boolֵ</returns>

        public bool ModiUserInfo(UserInfo user)
        {
            string sqlString = "Update userInfo Set userRealName = @userRealName , postAdd = @postAdd , postNum = @postNum , phoneNum = @phoneNum , "
                                  + "userBirth = @userBirth , userGender = @userGender , userAge = @userAge , IDCardNum = @IDCardNum "
                                  + "where userID = @userID";//userScore = @userScore , userLv = @userLv , 
            SqlParameter[] pt = new SqlParameter[] { 
                                new SqlParameter("@userRealName",SqlDbType.VarChar),
                                new SqlParameter("@postAdd",SqlDbType.VarChar),
                                new SqlParameter("@postNum",SqlDbType.VarChar),
                                new SqlParameter("@phoneNum",SqlDbType.VarChar),
                                //new SqlParameter("@userScore",SqlDbType.Int),
                                //new SqlParameter("@userLv",SqlDbType.Int),
                                new SqlParameter("@userBirth",SqlDbType.DateTime),
                                new SqlParameter("@userGender",SqlDbType.Int),
                                new SqlParameter("@userAge",SqlDbType.Int),
                                new SqlParameter("@IDCardNum",SqlDbType.VarChar),
                                new SqlParameter("@userID", SqlDbType.UniqueIdentifier)
                                };
            pt[8].Value = user.UserID;
            pt[0].Value = user.UserRealName;
            pt[1].Value = user.PostAdd;
            pt[2].Value = user.PostNum;
            pt[3].Value = user.PhoneNum;
            //pt[5].Value = user.UserScore;
            //pt[6].Value = user.UserLv;
            pt[4].Value = user.UserBirth;
            pt[5].Value = user.UserGender;
            pt[6].Value = user.UserAge;
            pt[7].Value = user.IDCardNum;

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

        #region ��ʾ�����û�

        /// <summary>
        /// ��ʾ�û��б�
        /// </summary>
        /// <param name="userList">�û�ʵ����󼯺�</param>
        /// <returns>����Ԫ�ظ���</returns>

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
                            user.PostAdd = reader.GetString(2);
                            user.PostNum = reader.GetString(3);
                            user.PhoneNum = reader.GetString(4);
                            user.UserScore = reader.GetInt32(5);
                            user.UserLv = reader.GetInt32(6);
                            user.UserBirth = reader.GetDateTime(7);
                            user.UserGender = reader.GetInt32(8);
                            user.UserAge = reader.GetInt32(9);
                            user.IDCardNum = reader.GetString(10);

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

        # region �����û�id��ѯ�û�

        /// <summary>
        /// ��ѯ�û���Ϣ
        /// </summary>
        /// <param name="user">�û�ʵ�����</param>
        /// <returns>boolֵ</returns>

        public bool SrchUserInfo(ref UserInfo user)
        {
            sqlString = "select * from userInfo where userID = @userID";
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
                            user.PostAdd = reader.GetString(2);
                            user.PostNum = reader.GetString(3);
                            user.PhoneNum = reader.GetString(4);
                            user.UserScore = reader.GetInt32(5);
                            user.UserLv = reader.GetInt32(6);
                            user.UserBirth = reader.GetDateTime(7);
                            user.UserGender = reader.GetInt32(8);
                            user.UserAge = reader.GetInt32(9);
                            user.IDCardNum = reader.GetString(10);
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
    }
}
