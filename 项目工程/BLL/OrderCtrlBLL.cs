////��д�ߣ�������
////��  �ڣ�2009-12-13
////��  �ܣ����������߼�����
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
        #region ���������������캯��
        /// <summary>
        /// ���충������ʵ��
        /// </summary>
        /// <param name="orderInfo">����ʵ�����</param>
        /// <returns>�����ɹ�����true�����򷵻�false</returns>
        public bool InitialOrderCtrl(OrderInfo orderInfo) 
        {
            curOrder = orderInfo;
            return true;
        }
        #endregion

        #region ���Ķ���״̬
        /// <summary>
        /// �޸�ָ������״̬Ϊָ��״̬
        /// </summary>
        /// <param name="targetState">Ŀ��״̬</param>
        /// <returns>�����ɹ�����true�����򷵻�false</returns>
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

        #region ���Ķ���״̬(OrderInfo)
        /// <summary>
        /// �����¶���ʵ��״̬�޸Ķ���״̬(OrderInfo)
        /// </summary>
        /// <param name="orderInfo">�¶���ʵ��</param>
        /// <returns>�����ɹ�����true�����򷵻�false</returns>
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

        #region ����һϵ�ж���ID�б��ȡ�������б�
        /// <summary>
        /// ����һϵ�ж���ID���Ҷ����б�
        /// </summary>
        /// <param name="orderInfoList">�����б�����</param>
        /// <returns>�����ɹ�����true�����򷵻�false</returns>
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

        #region ���¸���״̬
        /// <summary>
        /// ���¸���״̬Ϊ�Ѹ���
        /// </summary>
        /// <param name="orderID">������</param>
        /// <returns>�����ɹ�����true�����򷵻�false</returns>
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

        #region �����û�����ȡ�������б�
        /// <summary>
        /// ��ȡ�����б�
        /// </summary>
        /// <param name="orders">����DataTable</param>
        /// <returns>�����ɹ�����true�����򷵻�false</returns>
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

        #region �����û�����ȡָ��״̬���������б�
        /// <summary>
        /// �����û�����ȡָ��״̬�Ķ����б�
        /// </summary>
        /// <param name="orders">����DataTable</param>
        /// <param name="orderState">ָ������״̬</param>
        /// <returns>�����ɹ�����true�����򷵻�false</returns>
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

        #region �����û�����ȡ��ʷ�����������б�
        /// <summary>
        /// �����û�����ȡ��ʷ�����б�
        /// </summary>
        /// <param name="orders">����DataTable</param>
        /// <param name="orderState">ָ������״̬</param>
        /// <returns>�����ɹ�����true�����򷵻�false</returns>
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

        #region �����û�����ȡ�����ж����������б�(DataTable)
        /// <summary>
        /// �����û�����ȡ�����ж����б�
        /// </summary>
        /// <param name="orders">����DataTable</param>
        /// <param name="orderState">ָ������״̬</param>
        /// <returns>�����ɹ�����true�����򷵻�false</returns>
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

        #region ���ݶ����Ż�ȡ��Ʒ�б�
        /// <summary>
        ///  ��ȡ������ϸ��Ʒ��
        /// </summary>
        /// <param name="items">������DataTable</param>
        /// <param name="orderId">������</param>
        /// <returns>�����ɹ�����true�����򷵻�false</returns>
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

        #region ��ȡ���ж����б�(IList<OrderInfo>)
        /// <summary>
        ///  ��ȡ���ж����б�
        /// </summary>
        /// <param name="orders">�����б�IList</param>
        /// <returns>�����ɹ�����true�����򷵻�false</returns>
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

        #region ��ȡ��ǰ�û�ָ��ʱ��������ж����б�(IList<OrderInfo>)
        /// <summary>
        ///  ��ȡָ��ʱ��������ж����б�
        /// </summary>
        /// <param name="orders">�����б�IList</param>
        /// <param name="dateStart">��ʼ����</param>
        /// <param name="dateEnd">��������</param>
        /// <returns>�����ɹ�����true�����򷵻�false</returns>
        public bool GetOrdersByTime(ref IList<OrderInfo> orders, DateTime dateStart, DateTime dateEnd)
        {
            OrderCtrlDAL orderCtrl = new OrderCtrlDAL();
            Guid userId = (Guid)Membership.GetUser(HttpContext.Current.User.Identity.Name).ProviderUserKey;
            //�����ʼ������������ھ�Ϊ�գ���Ĭ�ϲ�ѯ���ж���
            if ((dateStart == null || dateStart.ToString().Length == 0) && (dateEnd == null || dateEnd.ToString().Length == 0)) 
            {
                if (!orderCtrl.GetAllOrders(ref orders)) 
                {
                    return false;
                }
                return true;
            }
            //�����ʼ����Ϊ�գ�Ĭ����ʼ����Ϊ��ǰ����
            else if (dateStart == null || dateStart.ToString().Length == 0) 
            {
                dateStart = DateTime.Today.Date;
            }
            //�����������Ϊ�գ�Ĭ��Ϊ��ǰ����
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

        #region ��������
        /// <summary>
        /// ����ָ������
        /// </summary>
        /// <param name="orderId">������</param>
        /// <returns>�����ɹ�����true�����򷵻�false</returns
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
