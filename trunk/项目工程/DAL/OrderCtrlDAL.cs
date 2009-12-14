////��д�ߣ�������
////��  �ڣ�2009-12-14
////��  �ܣ������������ݷ��ʲ���
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Entity;
using DbCtrl;

namespace DAL
{
    public class OrderCtrlDAL
    {
        private OrderInfo curOrder;
        private DataProvider dp;
        private string sqlString = string.Empty;
        private SqlParameter[] sq;

        public OrderCtrlDAL(OrderInfo curOrder)
        {
            this.curOrder = curOrder;
        }

        #region ���¶���״̬
        /// <summary>
        /// ���¶���״̬ΪĿ��״̬
        /// </summary>
        /// <param name=""></param>
        /// <returns>�����ɹ�����true�����򷵻�false</returns
        public bool ChangeOrderState() 
        {
            sqlString = "update mainOrderInfo set state=@targetState where mainOrderID=@id";
            sq = new SqlParameter[] { 
                                new SqlParameter("@targetState",SqlDbType.Int),
                                new SqlParameter("@id",SqlDbType.Int)
                                };
            sq[0].Value = curOrder.State;
            sq[1].Value = curOrder.OrderID;

            try
            {
                using (dp = new DataProvider())
                {
                    if (dp.ExecuteNonQuery(sqlString, sq) == 0)
                    {
                        return false;
                    }
                }
            }
            catch (Exception e) 
            {
                return false;
            }
            return true;
        }
        #endregion
    }
}
