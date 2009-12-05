////��д�ߣ���˼Ȼ
////��  �ڣ�2009-11-25
////��  �ܣ����������������

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DbCtrl;
using Entity;

namespace DAL
{
    public class MainStatDAL
    {
        private string sqlString = string.Empty;
        private DataProvider dp;

        #region ��ӵ��������

        /// <summary>
        /// ����µ��������
        /// </summary>
        /// <param name="newStat">�µ��������ʵ�����</param>
        /// <returns>boolֵ</returns>


        public bool AddMainStat(MainStat newStat)
        {
            sqlString = "Insert Into mainStat (mainStatID,Time,Value,Gender,Age,shopID,Province,soldType)"
                        + " Values (@mainStatID,@Time,@Value,@Gender,@Age,@shopID,@Province,@soldType)";

            SqlParameter[] pt = new SqlParameter[] { 
                                new SqlParameter("@mainStatID", SqlDbType.UniqueIdentifier),
                                new SqlParameter("@Time",SqlDbType.VarChar),
                                new SqlParameter("@Value",SqlDbType.VarChar),
                                new SqlParameter("@Gender",SqlDbType.VarChar),
                                new SqlParameter("@Age",SqlDbType.VarChar),
                                new SqlParameter("@shopID",SqlDbType.VarChar),
                                new SqlParameter("@Province",SqlDbType.Int),
                                new SqlParameter("@soldType",SqlDbType.Int),
                                };
            pt[0].Value = newStat.mainStatID;
            pt[1].Value = newStat.Time;
            pt[2].Value = newStat.Value;
            pt[3].Value = newStat.Gender;
            pt[4].Value = newStat.Age;
            pt[5].Value = newStat.shopID;
            pt[6].Value = newStat.Province;
            pt[7].Value = newStat.soldType;

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

        #region ɾ�����������

        /// <summary>
        /// ɾ�����������
        /// </summary>
        /// <param name="userID">����������idֵ</param>
        /// <returns>bool</returns>

        public bool DeleteMainStat(Guid mainStatID)////////////////�����ֶ���Ҫ����
        {
            sqlString = "delete from mainStat where id = @mainStatID";
            SqlParameter[] pt = new SqlParameter[] { 
                                new SqlParameter("@mainStatID", SqlDbType.UniqueIdentifier)
                                };
            pt[0].Value = mainStatID;

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

        #region ��ѯ���е��������

        /// <summary>
        /// ��ѯ���е��������
        /// </summary>
        /// <param name="mainStatList">���������ʵ����󼯺�</param>
        /// <returns>����Ԫ�ظ���</returns>

        public int ShowUserInfo(ref IList<MainStat> mainStatList)
        {
            sqlString = "select * from mainStat";

            try
            {
                using (dp = new DataProvider())
                {
                    using (SqlDataReader reader = dp.ExecuteReader(sqlString))
                    {
                        MainStat mainStat = null;
                        while (reader.Read())
                        {
                            mainStat = new MainStat();

                            mainStat.mainStatID = reader.GetGuid(0);
                            mainStat.Time = reader.GetString(1);
                            mainStat.Value = reader.GetString(2);
                            mainStat.Gender = reader.GetString(3);
                            mainStat.Age = reader.GetString(4);
                            mainStat.shopID = reader.GetString(5);
                            mainStat.Province = reader.GetInt32(6);
                            mainStat.soldType = reader.GetInt32(7);

                            mainStatList.Add(mainStat);
                        }
                    }
                }
            }
            catch
            {
                return 0;
            }

            return mainStatList.Count;
        }

        #endregion

    }
}
