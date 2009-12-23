////��д�ߣ�������
////��  �ڣ�2009-12-05
////��  �ܣ����ﳵģ������ݿ⴦��
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DbCtrl;
using Entity;

namespace DAL
{
    public class ShopCartInfoDAL
    {
        private string sqlString = string.Empty;
        private DataProvider dp;

        #region ������Ʒʵ��
        /// <summary>
        /// ������Ʒʵ��
        /// </summary>
        /// <param name="info">����Ʒʵ�����</param>
        /// <returns>boolֵ</returns>
        public bool SetItemEntity(ref ItemEntity info) 
        {
            DataTable dt = new DataTable();
            sqlString = "select goodsName, goodsPrice, goodsImg from goodsInfo where goodsID=" + info.ID;
            //SqlParameter sp = new SqlParameter("@id", SqlDbType.Int);
            //sp.Value = info.ID;

            try
            {
                using (dp = new DataProvider())
                {
                    if ((dt=dp.ExecuteQuery(sqlString))==null)
                        return false;
                }
            }
            catch
            {
                return false;
            }

            info.Name = dt.Rows[0][0].ToString();
            info.Number = 1;
            info.Price = Convert.ToDouble(dt.Rows[0][1].ToString());
            info.ImgPath = dt.Rows[0][2].ToString();

            return true;
        }
        #endregion

        #region ��ѯ��Ʒ���
        public bool GetStorage(ref int storage, int id) 
        {
            DataTable dt = new DataTable();
            sqlString = "select goodsStorage from goodsInfo where goodsID=" + id;
            try
            {
                using (dp = new DataProvider())
                {
                    if ((dt = dp.ExecuteQuery(sqlString)) == null)
                    {
                        return false;
                    }
                }
            }
            catch (Exception e) 
            {
                return false;
            }
            storage = Convert.ToInt32(dt.Rows[0][0].ToString());
            return true;
        }
        #endregion
    }
}
