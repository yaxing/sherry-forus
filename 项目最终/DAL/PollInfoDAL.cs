////��д�ߣ���˼Ȼ
////��  �ڣ�2009-11-26
////��  �ܣ�ͶƱ����������ݷ���

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DbCtrl;
using Entity;

namespace DAL
{
    public class PollInfoDAL
    {
        private string sqlString;
        private DataProvider dp = new DataProvider();

        #region �������

        #region ���ͶƱ������

        /// <summary>
        /// ���ͶƱ������
        /// </summary>
        /// <param name="newMainPoll">ͶƱ������ʵ�����</param>
        /// <returns>IDֵ</returns>

        public int AddMainPoll(MainPoll newMainPoll)
        {
            sqlString = "Insert Into MainPoll (topic,selectNum,singleMode,colMode) Values (@topic,@selectNum,@singleMode,@colMode)";

            SqlParameter[] pt = new SqlParameter[] { 
                                new SqlParameter("@topic", SqlDbType.VarChar),
                                new SqlParameter("@selectNum", SqlDbType.Int),
                                new SqlParameter("@singleMode", SqlDbType.VarChar),
                                new SqlParameter("@colMode", SqlDbType.VarChar),
                                };
            pt[0].Value = newMainPoll.Topic;
            pt[1].Value = newMainPoll.SelectNum;
            pt[2].Value = newMainPoll.SingleMode;
            pt[3].Value = newMainPoll.ColMode;
            try
            {
                using (dp = new DataProvider())
                {
                    newMainPoll.MainPollID = dp.ExecuteInsert(sqlString, pt);
                    if (newMainPoll.MainPollID == 0)
                        return -1;
                }
            }
            catch
            {
                return -1;
            }

            return newMainPoll.MainPollID;
        }
        #endregion

        #region ɾ������ͶƱ������

        /// <summary>
        /// ɾ������ͶƱ������
        /// </summary>
        /// <param name="mainPollID">ͶƱ������ID</param>
        /// <returns>bool</returns>

        public bool DeleteMainPoll(Guid mainPollID)
        {
            sqlString = "delete from MainPoll where id = @mainPollID";
            SqlParameter[] pt = new SqlParameter[] { 
                                new SqlParameter("@mainPollID", SqlDbType.UniqueIdentifier)
                                };
            pt[0].Value = mainPollID;

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

        #region ����ID��ͶƱ������

        /// <summary>
        /// ����ID��ͶƱ������
        /// </summary>
        /// <param name="mainPoll">ͶƱ������ʵ��</param>
        /// <returns>����Ԫ�ظ���</returns>

        public bool SelectByID(ref MainPoll mainPoll)
        {
            sqlString = "select * from MainPoll where mainPollID = " + mainPoll.MainPollID;

            try
            {
                using (dp = new DataProvider())
                {
                    using (SqlDataReader reader = dp.ExecuteReader(sqlString))
                    {
                        reader.Read();

                        mainPoll.Topic = reader.GetString(1);
                        mainPoll.SelectNum = reader.GetInt32(2);
                        mainPoll.SingleMode = reader.GetString(3);
                        mainPoll.ColMode = reader.GetString(4);
                    }
                }
            }
            catch
            {

            }

            return true;
        }

        #endregion

        #region ��ѯ����ͶƱ������

        /// <summary>
        /// ��ѯ����ͶƱ������
        /// </summary>
        /// <param name="mainPollList">ͶƱ������ʵ����󼯺�</param>
        /// <returns>����Ԫ�ظ���</returns>

        public int ShowMainPoll(ref IList<MainPoll> mainPollList)
        {
            sqlString = "select * from MainPoll";

            try
            {
                using (dp = new DataProvider())
                {
                    using (SqlDataReader reader = dp.ExecuteReader(sqlString))
                    {
                        MainPoll mainPoll = null;
                        while (reader.Read())
                        {
                            mainPoll = new MainPoll();

                            mainPoll.MainPollID = reader.GetInt32(0);
                            mainPoll.Topic = reader.GetString(1);

                            mainPollList.Add(mainPoll);
                        }
                    }
                }
            }
            catch
            {

            }

            return mainPollList.Count;
        }

        #endregion

        #region ��ѯͶƱ������

        /// <summary>
        /// ��ѯͶƱ������
        /// </summary>
        /// <returns>ͶƱ���������</returns>

        public int NumOfMainPoll()
        {
            sqlString = "select count(*) from MainPoll";

            try
            {
                using (dp = new DataProvider())
                {
                    using (SqlDataReader reader = dp.ExecuteReader(sqlString))
                    {
                        reader.Read();
                        return reader.GetInt32(0);
                    }
                }
            }
            catch
            {

            }
            return 0;
        }

        #endregion

        #region ��ѯ�����ǰN����

        /// <summary>
        /// ��ѯ�����ǰN����
        /// </summary>
        /// <param name="num">����N</param>
        /// <returns>bool</returns>

        public bool SelectTopN(ref IList<MainPoll>mainPoll, int num)
        {
            sqlString = "select top " + num + " * from MainPoll";

            try
            {
                using (dp = new DataProvider())
                {
                    MainPoll newMainPoll = new MainPoll();
                    using (SqlDataReader reader = dp.ExecuteReader(sqlString))
                    {
                        while (reader.Read())
                        {
                            newMainPoll.MainPollID = reader.GetInt32(0);
                            newMainPoll.Topic = reader.GetString(1);
                            newMainPoll.SelectNum = reader.GetInt32(2);
                            newMainPoll.SingleMode = reader.GetString(3);
                            newMainPoll.ColMode = reader.GetString(4);

                            mainPoll.Add(newMainPoll);
                        }
                    }
                }
            }
            catch
            {

            }
            return true;
        }

        #endregion

        #region ��ѯ����ķǵ�һ����

        /// <summary>
        /// ��ѯ����ķǵ�һ����
        /// </summary>
        /// <param name="mainPoll">��ѯ�����ݼ���</param>
        /// <param name="num">����N</param>
        /// <param name="currentPage">����N</param>
        /// <returns>bool</returns>

        public bool SelectTopMNotN(ref IList<MainPoll> mainPoll, int num, int currentPage)
        {
            sqlString = "select top " + num + " * from MainPoll where mainPollID not in (select top " + num * currentPage + " mainPollID from MainPoll)";

            try
            {
                using (dp = new DataProvider())
                {
                    MainPoll newMainPoll = new MainPoll();
                    using (SqlDataReader reader = dp.ExecuteReader(sqlString))
                    {
                        reader.Read();
                        newMainPoll.MainPollID = reader.GetInt32(0);
                        newMainPoll.Topic = reader.GetString(1);
                        newMainPoll.SelectNum = reader.GetInt32(2);
                        newMainPoll.SingleMode = reader.GetString(3);
                        newMainPoll.ColMode = reader.GetString(4);

                        mainPoll.Add(newMainPoll);
                    }
                }
            }
            catch
            {

            }
            return true;
        }

        #endregion

        #region ��������

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="mainPoll">����ʵ��</param>
        /// <returns>bool</returns>

        public bool UpdateMainPoll(MainPoll mainPoll)
        {
            sqlString = "update MainPoll set topic = " + mainPoll.Topic + " selectNum = " + mainPoll.SelectNum + " singleMode = " + mainPoll.SingleMode + " colMode = " + mainPoll.ColMode + " where mainPollID = " + mainPoll.MainPollID;
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

        #endregion

        #region �ֱ����

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

        public bool UpdateSubPoll(SubPoll subPoll)
        {
            string subString = "set ";
            if (subPoll.Description.Length != 0)
            {
                subString += "description = " + subPoll.Description;
            }
            if (subPoll.Num != null)
            {
                if (subString.Length != 4)
                    subString += ",";
                subString += " num = " + subPoll.Num;
            }
            if (subPoll.Color.Length != 0)
            {
                if (subString.Length != 4)
                    subString += ",";
                subString += " color = " + subPoll.Color;
            }

            sqlString = "Update SubPoll " + subString + " where subPollID = " + subPoll.SubPollID;

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

        #endregion

        #region ɾ��ͶƱ��

        /// <summary>
        /// ��������IDɾ��ͶƱ��
        /// </summary>
        /// 

        public bool DeletePoll(int mainPollID)
        {
            sqlString = "delete from MainPoll where mainID = " + mainPollID + "delete from SubPoll where mainPollID = " + mainPollID;

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
