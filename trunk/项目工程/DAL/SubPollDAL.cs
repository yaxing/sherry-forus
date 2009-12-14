////��д�ߣ���˼Ȼ
////��  �ڣ�2009-11-26
////��  �ܣ�ͶƱ��������ݷ���

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DbCtrl;
using Entity;

namespace DAL
{
    public class SubPollDAL
    {
        private string sqlString;
        private DataProvider dp = new DataProvider();

        #region ���ͶƱ����

        /// <summary>
        /// ���ͶƱ����
        /// </summary>
        /// <param name="newSubPoll">ͶƱ����ʵ�����</param>
        /// <returns>boolֵ</returns>

        public bool AddSubPoll(SubPoll newSubPoll)
        {

            sqlString = "Insert Into SubPoll (mainPollID,description,num,color) Values (@mainPollID,@description,@num,@color)";

            SqlParameter[] pt = new SqlParameter[] { 
                                new SqlParameter("@mainPollID", SqlDbType.Int),
                                new SqlParameter("@description", SqlDbType.VarChar),
                                new SqlParameter("@num", SqlDbType.Int),
                                new SqlParameter("@color", SqlDbType.VarChar),
                                };
            pt[0].Value = newSubPoll.MainPollID;
            pt[1].Value = newSubPoll.Description;
            pt[2].Value = newSubPoll.Num;
            pt[3].Value = newSubPoll.Color;

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

        #region ɾ������ͶƱ����

        /// <summary>
        /// ɾ������ͶƱ����
        /// </summary>
        /// <param name="subPollID">ͶƱ����ID</param>
        /// <returns>bool</returns>

        public bool DeleteSubPoll(Guid subPollID)
        {
            sqlString = "delete from SubPoll where id = @subPollID";
            SqlParameter[] pt = new SqlParameter[] { 
                                new SqlParameter("@subPollID", SqlDbType.UniqueIdentifier)
                                };
            pt[0].Value = subPollID;

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

            }
            return true;
        }

        #endregion

        #region ��ѯһ��ͶƱ�����������ͶƱ����

        /// <summary>
        /// ��ѯһ��ͶƱ�����������ͶƱ����
        /// </summary>
        /// <param name="subPollList">ͶƱ����ʵ����󼯺�</param>
        /// <returns>����Ԫ�ظ���</returns>

        public int ShowSubPoll(ref IList<SubPoll> subPollList, int mainPollID)
        {
            sqlString = "select * from SubPoll where mainPollID = " + mainPollID;

            //try
            //{
                using (dp = new DataProvider())
                {
                    using (SqlDataReader reader = dp.ExecuteReader(sqlString))
                    {
                        SubPoll subPoll = null;
                        while (reader.Read())
                        {
                            subPoll = new SubPoll();

                            subPoll.SubPollID = reader.GetInt32(0);
                            subPoll.MainPollID = reader.GetInt32(1);
                            subPoll.Description = reader.GetString(2);
                            subPoll.Num = reader.GetInt32(3);
                            subPoll.Color = reader.GetString(4);

                            subPollList.Add(subPoll);
                        }
                    }
                }
            //}
            //catch
            //{

            //}

            return subPollList.Count;
        }

        #endregion

        #region ����ͶƱ��

        /// <summary>
        /// ����ͶƱ��
        /// </summary>
        /// <param name="subPoll">���µķֱ�</param>
        /// <returns>bool</returns>

        public bool UpdatePollNum(SubPoll subPoll)
        {
            sqlString = "update SubPoll set num = num + 1 where subPollID = " + subPoll.SubPollID;

            try
            {
                using (dp = new DataProvider())
                {
                    if (dp.ExecuteNonQuery(sqlString) == 0)
                        return false;
                }
            }
            catch
            {

            }

            return true;
        }

        #endregion

    }
}
