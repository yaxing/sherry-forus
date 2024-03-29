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

        #region 更新付款状态
        /// <summary>
        /// 更新付款状态为已付款
        /// </summary>
        /// <param name=""></param>
        /// <returns>操作成功返回true，否则返回false</returns>
        public bool ChangePayState(int orderID)
        {
            sqlString = "update mainOrderInfo set isPaid=1 where mainOrderID=@id";
            sq = new SqlParameter[] { 
                                new SqlParameter("@id",SqlDbType.Int)
                                };
            sq[0].Value = orderID;
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

            sqlString = "update mainOrderInfo set orderState=0 where mainOrderID=@id";
            sq = new SqlParameter[] { 
                                new SqlParameter("@id",SqlDbType.Int)
                                };
            sq[0].Value = orderID;
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

        #region 更新订单状态
        /// <summary>
        /// 更新订单状态为目标状态
        /// </summary>
        /// <param name=""></param>
        /// <returns>操作成功返回true，否则返回false</returns>
        public bool ChangeOrderState(OrderInfo curOrder)
        {
            sqlString = "update mainOrderInfo set orderState=@targetState where mainOrderID=@id";
            //sqlString = "update mainOrderInfo set state="+curOrder.State+" where mainOrderID="+curOrder.OrderID;
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

        #region 按用户ID查询主订单(DataTable)
        /// <summary>
        /// 根据用户ID得到所有订单(DataTable)
        /// </summary>
        /// <param name="userID",name="orders">用户ID,订单list</param>
        /// <returns>订单列表</returns>
        public bool GetOrderList(ref DataTable orders, Guid userID)
        {
            DataTable dt = null;
            //sqlString = "select m.*, s.*, g.goodsImg from mainOrderInfo as m, subOrderInfo as s, goodsInfo as g where m.userID=@userID and m.mainOrderID=s.mainOrderID and g.goodsID=s.goodsID";
            sqlString = "select * from mainOrderInfo where userID=@userID order by orderTime desc";
            sq = new SqlParameter[] { 
                                new SqlParameter("@userID",SqlDbType.UniqueIdentifier)
                                };
            sq[0].Value = userID;

            try
            {
                using (dp = new DataProvider())
                {
                    if ((dt = dp.ExecuteDataTable(sqlString, sq)) == null)
                    {
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                return false;
            }
            orders = dt;

            //int i = 0;
            //int orderID = -1;
            //OrderInfo order = null;

            //根据datatable构造订单列表
            //for (i = 0; i < dt.Rows.Count;i++ )
            //{
            //    int curOrderID = Convert.ToInt32(dt.Rows[i][0].ToString());
            //    if (curOrderID != orderID)
            //    {
            //        orders.Add(order);
            //        orderID = curOrderID;
            //        order = new OrderInfo();
            //        order.UserRealName = dt.Rows[i]["userRealName"].ToString();
            //        order.UserAdd = dt.Rows[i]["postAdd"].ToString();
            //        order.UserZip = dt.Rows[i]["postNum"].ToString();
            //        order.UserTel = dt.Rows[i]["phoneNum"].ToString();
            //        order.UserProvince = dt.Rows[i]["province"].ToString();
            //        order.UserOrderPrice = Convert.ToDouble(dt.Rows[i]["orderPrice"].ToString());
            //        order.State = Convert.ToInt32(dt.Rows[i]["orderState"].ToString());
            //        order.InvoiceHead = dt.Rows[i]["invoiceHead"].ToString();
            //        order.InvoiceContent = dt.Rows[i]["invoiceContent"].ToString();
            //        order.OrderTime = dt.Rows[i]["orderTime"].ToString();
            //        order.UserOrderItems = new List<ItemEntity>();
            //    }

            //    ItemEntity ie = new ItemEntity();
            //    ie.ID = Convert.ToInt32(dt.Rows[i]["goodsID"].ToString());
            //    ie.Name = dt.Rows[i]["goodsName"].ToString();
            //    ie.Number = Convert.ToInt32(dt.Rows[i]["goodsNum"].ToString());
            //    ie.Price = Convert.ToDouble(dt.Rows[i]["goodsPrice"].ToString());
            //    ie.ImgPath = dt.Rows[i]["goodsImg"].ToString();
            //    order.UserOrderItems.Add(ie);
            //}
            return true;
        }
        #endregion

        #region 按用户ID查询主订单(IList<OrderInfo>)
        /// <summary>
        ///  按用户ID查询主订单(IList<OrderInfo>)
        /// </summary>
        /// <param name="orders">订单列表IList</param>
        /// <param name="userId">用户ID</param>
        /// <returns>操作成功返回true，否则返回false</returns>
        public bool GetAllOrders(ref IList<OrderInfo> orders, Guid userId)
        {
            DataTable bufferDt;
            sqlString = "select * from mainOrderInfo where userID=@userID order by orderTime desc";
            sq = new SqlParameter[] { 
                                new SqlParameter("@userID",SqlDbType.UniqueIdentifier)
                                };
            sq[0].Value = userId;

            try
            {
                using (dp = new DataProvider())
                {
                    if ((bufferDt = dp.ExecuteDataTable(sqlString, sq)) == null)
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
            try
            {
                for (; i < bufferDt.Rows.Count; i++)
                {
                    OrderInfo orderInfo = new OrderInfo();
                    orderInfo.OrderID = Convert.ToInt32(bufferDt.Rows[i]["mainOrderID"].ToString());
                    orderInfo.UserID = (Guid)bufferDt.Rows[i]["userID"];
                    orderInfo.UserRealName = bufferDt.Rows[i]["userRealName"].ToString();
                    orderInfo.UserTel = bufferDt.Rows[i]["phoneNum"].ToString();
                    orderInfo.UserZip = bufferDt.Rows[i]["postNum"].ToString();
                    orderInfo.UserAdd = bufferDt.Rows[i]["postAdd"].ToString();
                    orderInfo.UserProvince = bufferDt.Rows[i]["province"].ToString();
                    orderInfo.UserOrderPrice = Convert.ToDouble(bufferDt.Rows[i]["orderPrice"].ToString());
                    orderInfo.UserPayState = Convert.ToInt32(bufferDt.Rows[i]["isPaid"].ToString());
                    orderInfo.State = Convert.ToInt32(bufferDt.Rows[i]["orderState"].ToString());
                    orderInfo.OrderTime = bufferDt.Rows[i]["orderTime"].ToString();
                    orderInfo.InvoiceHead = bufferDt.Rows[i]["invoiceHead"].ToString();
                    orderInfo.InvoiceContent = bufferDt.Rows[i]["invoiceContent"].ToString();
                    orders.Add(orderInfo);
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
        #endregion

        #region 按用户ID以及指定订单状态查询主订单
        /// <summary>
        /// 根据用户ID以及指定订单状态获取订单
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="orders">订单datatable</param>
        /// <param name="orderState">订单指定状态</param>
        /// <returns>成功true，失败false</returns>
        public bool GetOrderList(ref DataTable orders, Guid userID, int orderState)
        {
            DataTable dt = null;
            sqlString = "select * from mainOrderInfo where userID=@userID and orderState=@orderState order by orderTime desc";
            sq = new SqlParameter[] { 
                                new SqlParameter("@userID",SqlDbType.UniqueIdentifier),
                                new SqlParameter("@orderState",SqlDbType.Int)
                                };
            sq[0].Value = userID;
            sq[1].Value = orderState;

            try
            {
                using (dp = new DataProvider())
                {
                    if ((dt = dp.ExecuteDataTable(sqlString, sq)) == null)
                    {
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                return false;
            }
            orders = dt;
            return true;
        }
        #endregion

        #region 按用户ID查询历史订单
        /// <summary>
        /// 根据用户ID获取历史订单
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="orders">订单datatable</param>
        /// <returns>成功true，失败false</returns>
        public bool GetHistoryOrderList(ref DataTable orders, Guid userID)
        {
            DataTable dt = null;
            sqlString = "select * from mainOrderInfo where userID=@userID and (orderState=3 or orderState=4) order by orderTime desc";
            sq = new SqlParameter[] { 
                                new SqlParameter("@userID",SqlDbType.UniqueIdentifier)
                                };
            sq[0].Value = userID;

            try
            {
                using (dp = new DataProvider())
                {
                    if ((dt = dp.ExecuteDataTable(sqlString, sq)) == null)
                    {
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                return false;
            }
            orders = dt;
            return true;
        }
        #endregion

        #region 按用户ID查询交易中订单
        /// <summary>
        /// 根据用户ID获取交易中订单
        /// </summary>
        /// <param name="orders">订单datatable</param>
        /// <param name="userID">用户ID</param>
        /// <returns>成功true，失败false</returns>
        public bool GetCurrentOrderList(ref DataTable orders, Guid userID)
        {
            DataTable dt = null;
            sqlString = "select * from mainOrderInfo where userID=@userID and (orderState=0 or orderState=1 or orderState=2 or orderState=5) order by orderTime desc";
            sq = new SqlParameter[] { 
                                new SqlParameter("@userID",SqlDbType.UniqueIdentifier)
                                };
            sq[0].Value = userID;

            try
            {
                using (dp = new DataProvider())
                {
                    if ((dt = dp.ExecuteDataTable(sqlString, sq)) == null)
                    {
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                return false;
            }
            orders = dt;
            return true;
        }
        #endregion

        #region 按订单ID查询订单项详细信息(DataTable)
        /// <summary>
        /// 根据订单号得到订单项(返回DataTable)
        /// </summary>
        /// <param name="items",name="orderId">订单项容器,订单号</param>
        /// <returns>订单项列表</returns>
        public bool GetItemList(ref DataTable items, int orderId)
        {
            DataTable dt = null;
            //sqlString = "select m.*, s.*, g.goodsImg from mainOrderInfo as m, subOrderInfo as s, goodsInfo as g where m.userID=@userID and m.mainOrderID=s.mainOrderID and g.goodsID=s.goodsID";
            sqlString = "select m.*, s.*, g.goodsImg from mainOrderInfo as m, subOrderInfo as s, goodsInfo as g where s.mainOrderID=" + orderId + " and m.mainOrderID=" + orderId + " and s.goodsID=g.goodsID";
            sq = new SqlParameter[] { 
                                new SqlParameter("@orderID",SqlDbType.UniqueIdentifier)
                                };
            sq[0].Value = orderId;

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
            items = dt;
            return true;
        }
        #endregion

        #region 按订单ID查询主订单详细信息(OrderInfo)
        /// <summary>
        /// 根据订单号得到主订单信息(OrderInfo)
        /// </summary>
        /// <param name="orderInfo">订单实体</param>
        /// <returns>成功返回true，否则返回false</returns>
        public bool SrchOrderInfoByID(ref OrderInfo orderInfo)
        {
            DataTable dt = null;
            sqlString = "select * from mainOrderInfo where mainOrderID=@orderID";
            sq = new SqlParameter[] { 
                                new SqlParameter("@orderID",SqlDbType.Int)
                                };
            sq[0].Value = orderInfo.OrderID;

            try
            {
                using (dp = new DataProvider())
                {
                    if ((dt = dp.ExecuteDataTable(sqlString,sq)) == null)
                    {
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                return false;
            }
            try
            {
                orderInfo.UserID = (Guid) dt.Rows[0]["userID"];
                orderInfo.UserRealName = dt.Rows[0]["userRealName"].ToString();
                orderInfo.UserTel = dt.Rows[0]["phoneNum"].ToString();
                orderInfo.UserZip = dt.Rows[0]["postNum"].ToString();
                orderInfo.UserAdd = dt.Rows[0]["postAdd"].ToString();
                orderInfo.UserProvince = dt.Rows[0]["province"].ToString();
                orderInfo.UserOrderPrice = Convert.ToDouble(dt.Rows[0]["orderPrice"].ToString());
                orderInfo.UserPayState = Convert.ToInt32(dt.Rows[0]["isPaid"].ToString());
                orderInfo.State = Convert.ToInt32(dt.Rows[0]["orderState"].ToString());
                orderInfo.OrderTime = dt.Rows[0]["orderTime"].ToString();
                orderInfo.InvoiceHead = dt.Rows[0]["invoiceHead"].ToString();
                orderInfo.InvoiceContent = dt.Rows[0]["invoiceContent"].ToString();
            }
            catch
            {
                return false;
            }
            return true;
        }
        #endregion

        #region 获取所有订单列表(IList<OrderInfo>)
        /// <summary>
        ///  获取所有订单列表
        /// </summary>
        /// <param name="orders">订单列表IList</param>
        /// <returns>操作成功返回true，否则返回false</returns>
        public bool GetAllOrders(ref IList<OrderInfo> orders) 
        {
            DataTable bufferDt;
            sqlString = "select * from mainOrderInfo order by orderTime desc";
            try
            {
                using (dp = new DataProvider())
                {
                    if ((bufferDt = dp.ExecuteQuery(sqlString)) == null)
                    {
                        return false;
                    }
                }
            }
            catch 
            {
                return false;
            }
            int i = 0;
            try
            {
                for (; i < bufferDt.Rows.Count; i++)
                {
                    OrderInfo orderInfo = new OrderInfo();
                    orderInfo.OrderID = Convert.ToInt32(bufferDt.Rows[i]["mainOrderID"].ToString());
                    orderInfo.UserID = (Guid)bufferDt.Rows[i]["userID"];
                    orderInfo.UserRealName = bufferDt.Rows[i]["userRealName"].ToString();
                    orderInfo.UserTel = bufferDt.Rows[i]["phoneNum"].ToString();
                    orderInfo.UserZip = bufferDt.Rows[i]["postNum"].ToString();
                    orderInfo.UserAdd = bufferDt.Rows[i]["postAdd"].ToString();
                    orderInfo.UserProvince = bufferDt.Rows[i]["province"].ToString();
                    orderInfo.UserOrderPrice = Convert.ToDouble(bufferDt.Rows[i]["orderPrice"].ToString());
                    orderInfo.UserPayState = Convert.ToInt32(bufferDt.Rows[i]["isPaid"].ToString());
                    orderInfo.State = Convert.ToInt32(bufferDt.Rows[i]["orderState"].ToString());
                    orderInfo.OrderTime = bufferDt.Rows[i]["orderTime"].ToString();
                    orderInfo.InvoiceHead = bufferDt.Rows[i]["invoiceHead"].ToString();
                    orderInfo.InvoiceContent = bufferDt.Rows[i]["invoiceContent"].ToString();
                    orders.Add(orderInfo);
                }
            }
            catch 
            {
                return false;
            }
            return true;
        }
        #endregion

        #region 获取指定时间段内当前用户所有订单列表(IList<OrderInfo>)
        /// <summary>
        ///  获取指定时间段内当前用户所有订单列表
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="orders">订单列表IList</param>
        /// <param name="dateStart">起始日期</param>
        /// <param name="dateEnd">结束日期</param>
        /// <returns>操作成功返回true，否则返回false</returns>
        public bool GetOrdersByTime_CurCustomer(ref IList<OrderInfo> orders, Guid userId, DateTime dateStart, DateTime dateEnd)
        {
            DataTable bufferDt;
            sqlString = "select * from mainOrderInfo where userID=@userID and orderTime>@dateStart and orderTime<@dateEnd order by orderTime desc";
            sq = new SqlParameter[] 
                                 {
                                     new SqlParameter("@dateStart",SqlDbType.DateTime),
                                     new SqlParameter("@dateEnd",SqlDbType.DateTime),
                                     new SqlParameter("@userID",SqlDbType.UniqueIdentifier)
                                 };
            sq[0].Value = dateStart;
            sq[1].Value = dateEnd;
            sq[2].Value = userId;
            try
            {
                using (dp = new DataProvider())
                {
                    if ((bufferDt = dp.ExecuteDataTable(sqlString,sq)) == null)
                    {
                        return false;
                    }
                }
            }
            catch
            {
                return false;
            }
            int i = 0;
            try
            {
                for (; i < bufferDt.Rows.Count; i++)
                {
                    OrderInfo orderInfo = new OrderInfo();
                    orderInfo.OrderID = Convert.ToInt32(bufferDt.Rows[i]["mainOrderID"].ToString());
                    orderInfo.UserID = (Guid)bufferDt.Rows[i]["userID"];
                    orderInfo.UserRealName = bufferDt.Rows[i]["userRealName"].ToString();
                    orderInfo.UserTel = bufferDt.Rows[i]["phoneNum"].ToString();
                    orderInfo.UserZip = bufferDt.Rows[i]["postNum"].ToString();
                    orderInfo.UserAdd = bufferDt.Rows[i]["postAdd"].ToString();
                    orderInfo.UserProvince = bufferDt.Rows[i]["province"].ToString();
                    orderInfo.UserOrderPrice = Convert.ToDouble(bufferDt.Rows[i]["orderPrice"].ToString());
                    orderInfo.UserPayState = Convert.ToInt32(bufferDt.Rows[i]["isPaid"].ToString());
                    orderInfo.State = Convert.ToInt32(bufferDt.Rows[i]["orderState"].ToString());
                    orderInfo.OrderTime = bufferDt.Rows[i]["orderTime"].ToString();
                    orderInfo.InvoiceHead = bufferDt.Rows[i]["invoiceHead"].ToString();
                    orderInfo.InvoiceContent = bufferDt.Rows[i]["invoiceContent"].ToString();
                    orders.Add(orderInfo);
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
        #endregion

        #region 撤销,删除订单
        /// <summary>
        /// 撤销,删除订单
        /// </summary>
        /// <param name="orderId">订单号</param>
        /// <returns>操作成功返回true，否则返回false</returns>
        public bool DeleteOrder(int orderId)
        {
            DataTable dt = null;
            if (!GetItemList(ref dt, orderId)) 
            {
                return false;
            }
            int i = 0;
            int curStorage = 0;
            int curVolume = 0;

            //===================清空子订单项，重新计算库存量以及销量=======================//
            for (; i < dt.Rows.Count; i++) 
            {
                DataTable buffer = null;
                
                //======================获取商品库存量，销量===================================//
                sqlString = "select goodsStorage, goodsVolume from goodsInfo where goodsID=@id";
                sq = new SqlParameter[] { 
                                new SqlParameter("@id",SqlDbType.Int)
                                };
                sq[0].Value = Convert.ToInt32(dt.Rows[i]["goodsID"].ToString());
                try
                {
                    using (dp = new DataProvider())
                    {
                        if ((buffer = dp.ExecuteDataTable(sqlString, sq)) == null)
                            return false;
                    }
                }
                catch
                {
                    return false;
                }
                curStorage = Convert.ToInt32(buffer.Rows[0]["goodsStorage"].ToString());
                curVolume = Convert.ToInt32(buffer.Rows[0]["goodsVolume"].ToString());

                //==============================更新商品库存量为 现有存量+撤销订单内商品数；更新销量为 当前销量-订单商品数量 ==========================//
                sqlString = "update goodsInfo set goodsStorage=@number, goodsVolume=@volume where goodsID=@id";
                sq = new SqlParameter[]
                                      {
                                        new SqlParameter("@number", SqlDbType.Int),
                                        new SqlParameter("@volume", SqlDbType.Int),
                                        new SqlParameter("id",SqlDbType.Int)
                                      };
                sq[0].Value = Convert.ToInt32(dt.Rows[i]["goodsNum"].ToString())+curStorage;
                sq[1].Value = curVolume - Convert.ToInt32(dt.Rows[i]["goodsNum"].ToString());
                sq[2].Value = Convert.ToInt32(dt.Rows[i]["goodsID"].ToString());
                try
                {
                    using (dp = new DataProvider())
                    {
                        if (dp.ExecuteNonQuery(sqlString,sq) == 0)
                        {
                            return false;
                        }
                    }
                }
                catch (Exception e)
                {
                    return false;
                }

                //===========================删除子订单表中对应商品================================//
                sqlString = "delete from subOrderInfo where mainOrderID=@orderId and goodsID=@id";
                sq = new SqlParameter[]
                                      {
                                        new SqlParameter("@orderId", SqlDbType.Int),
                                        new SqlParameter("id",SqlDbType.Int)
                                      };
                sq[0].Value = orderId;
                sq[1].Value = Convert.ToInt32(dt.Rows[i]["goodsID"].ToString());
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
            }

            //===============================================从主订单表中删除订单=================================//
            sqlString = "delete from mainOrderInfo where mainOrderID=@orderId";
            sq = new SqlParameter[]
                                      {
                                        new SqlParameter("@orderId", SqlDbType.Int)
                                      };
            sq[0].Value = orderId;
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
