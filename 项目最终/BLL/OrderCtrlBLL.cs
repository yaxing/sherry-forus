////编写者：陈亚星
////日  期：2009-12-13
////功  能：订单管理逻辑处理
using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Entity;
using DAL;
using InterFace;
using System.Web;
using System.Web.Security;
using System.Web.UI;

namespace BLL
{
    public class OrderCtrlBLL:IChangeOrderState
    {
        OrderInfo curOrder;
        #region 单个订单操作构造函数
        /// <summary>
        /// 构造订单处理实体
        /// </summary>
        /// <param name="orderInfo">订单实体对象</param>
        /// <returns>操作成功返回true，否则返回false</returns>
        public bool InitialOrderCtrl(OrderInfo orderInfo) 
        {
            curOrder = orderInfo;
            return true;
        }
        #endregion

        #region 更改订单状态
        /// <summary>
        /// 修改指定订单状态为指定状态
        /// </summary>
        /// <param name="targetState">目标状态</param>
        /// <returns>操作成功返回true，否则返回false</returns>
        public bool ChangeOrderState(int targetState) 
        {
            curOrder.State = targetState;
            OrderCtrlDAL updateOrder = new OrderCtrlDAL();
            if (!updateOrder.ChangeOrderState(curOrder)) 
            {
                return false;
            }
            return true;
        }
        #endregion

        #region 更改订单状态(OrderInfo)
        /// <summary>
        /// 根据新订单实体状态修改订单状态(OrderInfo)
        /// </summary>
        /// <param name="orderInfo">新订单实体</param>
        /// <returns>操作成功返回true，否则返回false</returns>
        public bool ChangeOrderState(OrderInfo orderInfo)
        {
            OrderCtrlDAL updateOrder = new OrderCtrlDAL();
            if (!updateOrder.ChangeOrderState(orderInfo))
            {
                return false;
            }
            return true;
        }
        #endregion

        #region 根据一系列订单ID列表获取主订单列表
        /// <summary>
        /// 根据一系列订单ID查找订单列表
        /// </summary>
        /// <param name="orderInfoList">订单列表容器</param>
        /// <returns>操作成功返回true，否则返回false</returns>
        public bool SrchOrderInfoByID(ref IList<OrderInfo> orderInfoList) 
        {
            OrderCtrlDAL SrchOrders = new OrderCtrlDAL();
            int i = 0;
            for (; i < orderInfoList.Count; i++)
            {
                OrderInfo buffer = orderInfoList[i];
                if (!SrchOrders.SrchOrderInfoByID(ref buffer))
                {
                    return false;
                }
                orderInfoList[i] = buffer;
            }
            return true;
        }
        #endregion

        #region 更新付款状态
        /// <summary>
        /// 更新付款状态为已付款
        /// </summary>
        /// <param name="orderID">订单号</param>
        /// <returns>操作成功返回true，否则返回false</returns>
        public bool ChangePayState(int orderID) 
        {
            OrderCtrlDAL orderCtrl = new OrderCtrlDAL();
            if (!orderCtrl.ChangePayState(orderID)) 
            {
                return false;
            }
            return true;

        }
        #endregion

        #region 根据用户名获取主订单列表
        /// <summary>
        /// 获取订单列表
        /// </summary>
        /// <param name="orders">订单DataTable</param>
        /// <returns>操作成功返回true，否则返回false</returns>
        public bool GetOrderList(ref DataTable orders) 
        {
            MembershipUser curUser = Membership.GetUser(HttpContext.Current.User.Identity.Name.ToString());
            Guid userID = (Guid)curUser.ProviderUserKey;
            OrderCtrlDAL orderCtrl = new OrderCtrlDAL();
            if (!orderCtrl.GetOrderList(ref orders, userID)) 
            {
                return false;
            }
            return true;
        }
        #endregion

        #region 根据用户名获取指定状态的主订单列表
        /// <summary>
        /// 根据用户名获取指定状态的订单列表
        /// </summary>
        /// <param name="orders">订单DataTable</param>
        /// <param name="orderState">指定订单状态</param>
        /// <returns>操作成功返回true，否则返回false</returns>
        public bool GetOrderList(ref DataTable orders, int orderState)
        {
            MembershipUser curUser = Membership.GetUser(HttpContext.Current.User.Identity.Name.ToString());
            Guid userID = (Guid)curUser.ProviderUserKey;
            OrderCtrlDAL orderCtrl = new OrderCtrlDAL();
            if (!orderCtrl.GetOrderList(ref orders, userID, orderState))
            {
                return false;
            }
            return true;
        }
        #endregion

        #region 根据用户名获取历史订单主订单列表
        /// <summary>
        /// 根据用户名获取历史订单列表
        /// </summary>
        /// <param name="orders">订单DataTable</param>
        /// <param name="orderState">指定订单状态</param>
        /// <returns>操作成功返回true，否则返回false</returns>
        public bool GetHistoryOrderList(ref DataTable orders)
        {
            MembershipUser curUser = Membership.GetUser(HttpContext.Current.User.Identity.Name.ToString());
            Guid userID = (Guid)curUser.ProviderUserKey;
            OrderCtrlDAL orderCtrl = new OrderCtrlDAL();
            if (!orderCtrl.GetHistoryOrderList(ref orders, userID))
            {
                return false;
            }
            return true;
        }
        #endregion

        #region 根据用户名获取交易中订单主订单列表(DataTable)
        /// <summary>
        /// 根据用户名获取交易中订单列表
        /// </summary>
        /// <param name="orders">订单DataTable</param>
        /// <param name="orderState">指定订单状态</param>
        /// <returns>操作成功返回true，否则返回false</returns>
        public bool GetCurrentOrderList(ref DataTable orders)
        {
            MembershipUser curUser = Membership.GetUser(HttpContext.Current.User.Identity.Name.ToString());
            Guid userID = (Guid)curUser.ProviderUserKey;
            OrderCtrlDAL orderCtrl = new OrderCtrlDAL();
            if (!orderCtrl.GetCurrentOrderList(ref orders, userID))
            {
                return false;
            }
            return true;
        }
        #endregion

        #region 根据订单号获取商品列表
        /// <summary>
        ///  获取订单详细商品项
        /// </summary>
        /// <param name="items">订单项DataTable</param>
        /// <param name="orderId">订单号</param>
        /// <returns>操作成功返回true，否则返回false</returns>
        public bool GetItemList(ref DataTable items, int orderId)
        {
            OrderCtrlDAL orderCtrl = new OrderCtrlDAL();
            if (!orderCtrl.GetItemList(ref items, orderId))
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
            OrderCtrlDAL orderCtrl = new OrderCtrlDAL();
            if (!orderCtrl.GetAllOrders(ref orders))
            {
                return false;
            }
            return true;
        }
        #endregion

        #region 获取当前用户指定时间段内所有订单列表(IList<OrderInfo>)
        /// <summary>
        ///  获取指定时间段内所有订单列表
        /// </summary>
        /// <param name="orders">订单列表IList</param>
        /// <param name="dateStart">起始日期</param>
        /// <param name="dateEnd">结束日期</param>
        /// <returns>操作成功返回true，否则返回false</returns>
        public bool GetOrdersByTime(ref IList<OrderInfo> orders, DateTime dateStart, DateTime dateEnd)
        {
            OrderCtrlDAL orderCtrl = new OrderCtrlDAL();
            Guid userId = (Guid)Membership.GetUser(HttpContext.Current.User.Identity.Name).ProviderUserKey;
            //如果起始日期与结束日期均为空，则默认查询所有订单
            if ((dateStart == null || dateStart.ToString().Length == 0) && (dateEnd == null || dateEnd.ToString().Length == 0)) 
            {
                if (!orderCtrl.GetAllOrders(ref orders)) 
                {
                    return false;
                }
                return true;
            }
            //如果起始日期为空，默认起始日期为当前日期
            else if (dateStart == null || dateStart.ToString().Length == 0) 
            {
                dateStart = DateTime.Today.Date;
            }
            //如果结束日期为空，默认为当前日期
            else if (dateEnd == null || dateEnd.ToString().Length == 0) 
            {
                dateEnd = DateTime.Today.Date;
            }
            if (!orderCtrl.GetOrdersByTime_CurCustomer(ref orders,userId,dateStart,dateEnd))
            {
                return false;
            }
            return true;
        }
        #endregion

        #region 撤销订单
        /// <summary>
        /// 撤销指定订单
        /// </summary>
        /// <param name="orderId">订单号</param>
        /// <returns>操作成功返回true，否则返回false</returns
        public bool DeleteOrder(int orderId)
        {
            OrderCtrlDAL deleteOrder = new OrderCtrlDAL();
            if (!deleteOrder.DeleteOrder(orderId))
            {
                return false;
            }
            return true;
        }
        #endregion
    }
}
