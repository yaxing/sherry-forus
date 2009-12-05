////��д�ߣ�������
////��  �ڣ�2009-11-25
////��  �ܣ��г�����ģ����������ݷ��ʲ���

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DbCtrl;
using Entity;

namespace DAL
{
    class MarketDecisionDAL
    {
        private string sqlString = string.Empty;
        private DataProvider dp;

        #region ����ĳ������еĻ�Ա��
        /// <summary>
        /// ����ĳ������еĻ�Ա��
        /// </summary>
        /// <param name="startingAge">��ʼ����</param>
        /// <param name="endingAge">��ֹ����</param>
        /// <returns>intֵ������ĳ������еĻ�Ա��</returns>
        public int CountMembersAgeGroup(int startingAge, int endingAge)
        {
            int num=0;
            if (endingAge < startingAge)
            {
                int tmp;
                tmp = startingAge;
                startingAge = endingAge;
                endingAge = tmp;
            }

            sqlString = "count * from userinfo where userage between @staringAge and @endingAge";
            SqlParameter[] pt = new SqlParameter[] { 
                                new SqlParameter("@staringAge", SqlDbType.Int),
                                new SqlParameter("@endingAge", SqlDbType.Int)
            };

            pt[0].Value=startingAge;
            pt[1].Value = endingAge;

            try
            {
                using (dp = new DataProvider())
                {
                    num=dp.ExecuteQuery(sqlString, pt);
                }
            }
            catch
            {
                return 0;
            }
            return num ;
        }
        #endregion


        #region ����ĳ������еĻ�Ա��һ��ʱ����ڵ����Ѷ�
        /// <summary>
        /// ����ĳ������еĻ�Ա��һ��ʱ����ڵ����Ѷ�
        /// </summary>
        /// <param name="startingDate">��ʼʱ��</param>
        /// <param name="endingDate">��ֹʱ��</param>
        /// <param name="startingAge">��ʼ����</param>
        /// <param name="endingAge">��ֹ����</param>
        /// <returns>doubleֵ������ĳ������еĻ�Ա��һ��ʱ����ڵ����Ѷ�</returns>

        public double SumAgeGroupExpenditure(DateTime startingDate, DateTime endingDate, int startingAge, int endingAge)
        {
            sqlString = "select userID,userAge from userinfo as usertb where userage between staringAge and endingAge";
        }
        #endregion

    }
}
