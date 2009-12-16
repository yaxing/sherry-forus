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
        //private OrderInfo curOrder;
        private DataProvider dp;
        private string sqlString = string.Empty;
        private SqlParameter[] sq;

        public OrderCtrlDAL()
        {

        }

        #region 更新订单状态
        /// <summary>
        /// 更新订单状态为目标状态
        /// </summary>
        /// <param name=""></param>
        /// <returns>操作成功返回true，否则返回false</returns
        public bool ChangeOrderState(OrderInfo curOrder) 
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

        #region 按用户ID查询订单
        /// <summary>
        /// 根据用户ID得到所有订单
        /// </summary>
        /// <param name="userID",name="orders">用户ID,订单list</param>
        /// <returns>订单列表</returns>
        public bool GetOrderList(ref List<OrderInfo> orders,Guid userID)
        {
            DataTable dt = null;
            sqlString = "select m.*, s.*, g.goodsImg from mainOrderInfo as m, subOrderInfo as s, goodInfo as g where m.userID=@userID and m.mainOrderID=s.mainOrderID and g.goodsID=s.goodsID";
            sq = new SqlParameter[] { 
                                new SqlParameter("@userID",SqlDbType.UniqueIdentifier)
                                };
            sq[0].Value = userID;

            try
            {
                using (dp = new DataProvider())
                {
                    if ((dt=dp.ExecuteDataTable(sqlString, sq))==null)
                    {
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                return false;
            }
            
            int i = 0;
            int orderID = -1;
            OrderInfo order = null;
            
            //根据datatable构造订单列表
            for (i = 0; i < dt.Rows.Count;i++ )
            {
                int curOrderID = Convert.ToInt32(dt.Rows[i][0].ToString());
                if (curOrderID != orderID)
                {
                    orders.Add(order);
                    orderID = curOrderID;
                    order = new OrderInfo();
                    order.UserRealName = dt.Rows[i][4].ToString();
                    order.UserAdd = dt.Rows[i][2].ToString();
                    order.UserZip = dt.Rows[i][3].ToString();
                    order.UserTel = dt.Rows[i][5].ToString();
                    order.UserProvince = dt.Rows[i][6].ToString();
                    order.UserOrderPrice = Convert.ToDouble(dt.Rows[i][10].ToString());
                    order.State = Convert.ToInt32(dt.Rows[i][11].ToString());
                    order.InvoiceHead = dt.Rows[i][7].ToString();
                    order.InvoiceContent = dt.Rows[i][8].ToString();
                    order.OrderTime = dt.Rows[i][9].ToString();
                    order.UserOrderItems = new List<ItemEntity>();
                }
                ItemEntity ie = new ItemEntity(Convert.ToInt32(dt.Rows[i][14].ToString()), dt.Rows[i][15].ToString(), Convert.ToInt32(dt.Rows[i][16].ToString())
                                               , Convert.ToDouble(dt.Rows[i][17].ToString()), dt.Rows[i][18].ToString());
                order.UserOrderItems.Add(ie);
            }

            return true;
        }
        #endregion
    }
}
