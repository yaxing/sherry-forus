////��д�ߣ�������
////��  �ڣ�2009-12-13
////��  �ܣ����������߼�����
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
