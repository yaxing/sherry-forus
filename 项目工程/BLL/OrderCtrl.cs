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
