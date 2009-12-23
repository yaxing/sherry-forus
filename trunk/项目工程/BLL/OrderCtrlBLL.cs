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
    public class OrderCtrlBLL:IOrderCtrl
    {
        OrderInfo curOrder;
        #region 单个订单操作构造函数
        /// <summary>
        /// 构造订单处理实体
        /// </summary>
        /// <param name="orderInfo">订单实体对象</param>
        /// <returns>操作成功返回true，否则返回false</returns
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
        /// <returns>操作成功返回true，否则返回false</returns
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

        #region 根据订单号获取商品列表
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
