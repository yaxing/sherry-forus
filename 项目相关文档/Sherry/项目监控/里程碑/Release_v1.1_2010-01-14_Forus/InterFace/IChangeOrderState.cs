////编写者：李开林
////日  期：2009-11-25
////功  能：修改订单状态接口

using System.Collections.Generic;
using Entity;

namespace InterFace
{
    public interface IChangeOrderState
    {
        bool ChangeOrderState(OrderInfo orderInfo);
        bool SrchOrderInfoByID(ref IList<OrderInfo> orderInfoList);
    }
}
