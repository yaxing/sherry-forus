////编写者：李开林
////日  期：2009-11-25
////功  能：物流管理部分的逻辑处理

using Entity;
using InterFace;

namespace BLL
{
    public class LogisticsInfoBLL:IShipping
    {
        #region 实现物流接口方法

        /// <summary>
        /// 物流部分启动方法
        /// </summary>
        /// <returns>操作成功返回true，否则返回false</returns>

        public bool StartShipping()
        {
            int shippingMode = JudgeMode();

            switch (shippingMode)
            {
                case 1:         //店面方式送货   
                    SelectShop();
                    break;
                case 2:         //邮寄方式送货
                    break;
            }

            return true;
        }
        #endregion

        #region 确定送货方式

        /// <summary>
        /// 确定送货方式
        /// </summary>
        /// <returns>1表示店面方式送货，2表示邮寄方式送货</returns>

        private int JudgeMode()
        {
            int mode = 0;

            return mode;
        }
        #endregion

        #region 选择送货店面

        /// <summary>
        /// 选择送货店面
        /// </summary>
        /// <returns>返回店面信息</returns>

        private int SelectShop()
        {
            return 0;
        }

        #endregion

        #region 发送邮件

        /// <summary>
        /// 发送邮件方法
        /// </summary>
        /// <returns>操作成功返回true，否则返回false</returns>

        private bool SendEmail()
        {
            return true;
        }
        #endregion

        #region 查询送货信息

        /// <summary>
        /// 查询送货信息
        /// </summary>
        /// <param name="logisticsInfo">送货信息实体对象</param>
        /// <returns>成功返回true，否则返回false</returns>

        public bool SrchShippingInfo(ref LogisticsInfo logisticsInfo)
        {

            return true;
        }

        #endregion

        #region 登记送货信息

        /// <summary>
        /// 登记送货信息
        /// </summary>
        /// <param name="logisticsInfo">送货信息实体对象</param>
        /// <returns>成功返回true，否则返回false</returns>

        public bool AddShippingInfo(LogisticsInfo logisticsInfo)
        {
            return true;
        }
        #endregion

        #region 取货确认

        /// <summary>
        /// 取货确认处理
        /// </summary>
        /// <returns>成功返回true，否则返回false</returns>

        public bool ConfirmPicking()
        {
            return true;
        }

        #endregion

        #region 收货确认

        /// <summary>
        /// 收货确认处理
        /// </summary>
        /// <returns>成功返回true，否则返回false</returns>

        public bool ConfirmReceiving()
        {
            return true;
        }
        #endregion

        #region 申请退货

        /// <summary>
        /// 申请退货处理
        /// </summary>
        /// <returns>成功返回true，否则返回false</returns>

        public bool ApplyReturning()
        {
            return true;
        }
        #endregion

        #region 退货确认

        /// <summary>
        /// 退货确认处理
        /// </summary>
        /// <returns>成功返回true，否则返回false</returns>

        public bool ConfirmReturning()
        {
            return true;
        }
        #endregion

        #region 退货驳回

        /// <summary>
        /// 退货驳回处理
        /// </summary>
        /// <returns>成功返回true，否则返回false</returns>

        public bool RefuseReturning()
        {
            return true;
        }
        #endregion
    }
}
