////��д�ߣ�������
////��  �ڣ�2009-12-13
////��  �ܣ����������߼�����
using System;
using System.Collections.Generic;
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
        #region ���캯��
        /// <summary>
        /// ���충������ʵ��
        /// </summary>
        /// <param name="orderInfo">����ʵ�����</param>
        /// <returns>�����ɹ�����true�����򷵻�false</returns
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
        /// <returns>�����ɹ�����true�����򷵻�false</returns
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

        #region �����û�����ȡ�����б�
        public bool GetOrderList(ref List<OrderInfo> orders) 
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
    }
}
