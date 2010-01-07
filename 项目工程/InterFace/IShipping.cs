////编写者：李开林
////日  期：2009-11-25
////功  能：物流部分启动接口

using System;
using System.Collections.Generic;
using Entity;

namespace InterFace
{
    public interface IShipping
    {
       bool StartShipping(OrderInfo orderInfo);
       bool SrchOrderListByWorkerID(ref IList<OrderInfo> orderInfoList , Guid workerID);
       bool SrchOrderListByManagerID(ref IList<OrderInfo> orderInfoList, Guid managerID);
       bool ApplyReturning(OrderInfo orderInfo);
       bool ConfirmPicking(OrderInfo orderInfo);
       bool ConfirmReceiving(OrderInfo orderInfo);
       bool ConfirmReturning(OrderInfo orderInfo);
       bool RefuseReturning(OrderInfo orderInfo);
    }
}
