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
    public class OrderCtrl:IOrderCtrl
    {
        OrderInfo curOrder;
        public bool InitialOrderCtrl(OrderInfo orderInfo) 
        {
            curOrder = orderInfo;
            return true;
        }
    }
}
