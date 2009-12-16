////编写者：李开林
////日  期：2009-12-9
////功  能：订单管理部分的逻辑处理

using Entity;
using InterFace;

namespace BLL
{
    public class OrderInfoBLL:IChangeOrderState
    {
        #region 实现IChangeOrderState接口

        /// <summary>
        /// 实现IChangeOrderState接口
        /// </summary>
        /// <param name="orderInfo">订单状态</param>
        /// <returns>操作成功返回true，否则返回false</returns>

        public bool ChangeOrderState(OrderInfo orderInfo)
        {
            return true;
        }
        #endregion
    }
}
