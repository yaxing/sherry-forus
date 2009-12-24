////��д�ߣ�������
////��  �ڣ�2009-12-24
////��  �ܣ��û����ֹ���
using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Entity;
using DbCtrl;
using System.Web;
using System.Web.Security;
using System.Web.UI;

namespace DAL
{
    public class UserScoreDAL
    {
        DataTable dt;
        string sqlString = string.Empty;
        SqlParameter[] sq = null;
        DataProvider dp;

        #region Ϊ�û��������score��
        /// <summary>
        /// �����û�����
        /// </summary>
        /// <param name="userId,score">�û�ID����Ҫ���ӵĻ��ֻ򶩵��ţ� �ж��Ƕ�����(false)���ǻ���(true)</param>
        /// <returns>�����ɹ�����true�����򷵻�false</returns>
        public bool UpdateScore(Guid userId, int score, bool flag) 
        {
            if (!flag) 
            {
                sqlString = "select orderPrice from mainOrderInfo where mainOrderID=@id";
                sq = new SqlParameter[]
                                   {
                                       new SqlParameter("@id",SqlDbType.Int)
                                   };
                sq[0].Value = score;
                score = 0;
                try
                {
                    using (dp = new DataProvider())
                    {
                        if ((dt = dp.ExecuteDataTable(sqlString, sq)) == null || dt.Rows.Count <= 0)
                            return false;
                    }
                }
                catch
                {
                    return false;
                }

                double buffer = Convert.ToDouble(dt.Rows[0]["orderPrice"].ToString());
                score = Convert.ToInt32(buffer);
            }
            //=============================ѡ��ԭ����===============================//
            sqlString = "select userScore from userInfo where userID=@id";
            sq = new SqlParameter[]
                                   {
                                       new SqlParameter("@id",SqlDbType.UniqueIdentifier)
                                   };
            sq[0].Value = userId;
            try
            {
                using (dp = new DataProvider())
                {
                    if ((dt = dp.ExecuteDataTable(sqlString,sq)) == null||dt.Rows.Count<=0)
                        return false;
                }
            }
            catch
            {
                return false;
            }
            score += Convert.ToInt32(dt.Rows[0]["userScore"].ToString());

            //================================���»���========================//
            sqlString = "update userInfo set userScore=@s where userID=@id";
            sq = new SqlParameter[]
                                   {
                                       new SqlParameter("@s",SqlDbType.Int),
                                       new SqlParameter("@id",SqlDbType.UniqueIdentifier)
                                   };
            sq[0].Value = score;
            sq[1].Value = userId;

            try
            {
                using (dp = new DataProvider())
                {
                    if (dp.ExecuteNonQuery(sqlString, sq) == 0)
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
