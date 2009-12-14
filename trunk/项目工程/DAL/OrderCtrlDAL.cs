////编写者：陈亚星
////日  期：2009-12-14
////功  能：订单管理数据访问操作
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

        #region 更新订单状态
        /// <summary>
        /// 更新订单状态为目标状态
        /// </summary>
        /// <param name=""></param>
        /// <returns>操作成功返回true，否则返回false</returns
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
