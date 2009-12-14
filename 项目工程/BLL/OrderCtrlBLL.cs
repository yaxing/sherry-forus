////编写者：陈亚星
////日  期：2009-12-13
////功  能：订单管理逻辑处理
using System;
using System.Collections.Generic;
using System.Text;
using Entity;
using DAL;
using InterFace;

namespace BLL
{
    public class OrderCtrlBLL:IOrderCtrl
    {
        OrderInfo curOrder;
        #region 构造函数
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
            OrderCtrlDAL updateOrder = new OrderCtrlDAL(curOrder);
            if (!updateOrder.ChangeOrderState()) 
            {
                return false;
            }
            return true;
        }
        #endregion
    }
}
