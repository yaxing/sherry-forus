////编写者：李开林
////日  期：2009-12-8
////功  能：物流管理部分的逻辑处理

using DAL;
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
                    {
                        ShopInfo shopInfo = new ShopInfo();
                        if(SelectShop(ref shopInfo))   //操作成功
                        {
                            //查询店面负责人信息
                            WorkerInfo shopManager = new WorkerInfo();
                            shopManager.ShopID = shopInfo.ShopID;
                            if (!SrchShopManager(ref shopManager))
                                return false;

                            //选择合适的店面送货人员
                            WorkerInfo workerInfo = new WorkerInfo();
                            workerInfo.ShopID = shopInfo.ShopID;
                            if (!SelectWorkerByShop(ref workerInfo))
                                return false;

                            //分配订单
                            LogisticsInfo logisticsInfo = new LogisticsInfo();
                            logisticsInfo.LogisticsType = 0;
                            logisticsInfo.MainOrderID = 123;
                            logisticsInfo.WorkerID = workerInfo.WorkerID;
                            if (!AddShippingInfo(logisticsInfo , workerInfo))
                                return false;

                            //发送邮件给店面负责人
                            MailBLL mailBLL = new MailBLL();
                            string tomail = shopManager.EmailAdd;
                            string mailTitle = "新订单分配";
                            string mailBody = "订单号为****的订单已经分配给您所在店面的工作人员："+workerInfo.WorkerRealName;
                            if (!mailBLL.SendEmail(tomail, mailTitle, mailBody))
                                return false;

                            //发送邮件给店面送货人员
                            tomail = workerInfo.EmailAdd;
                            mailTitle = "新订单分配";
                            mailBody = "订单号为****的订单已经分配给您，请及时处理";
                            if (!mailBLL.SendEmail(tomail, mailTitle, mailBody))
                                return false;

                            //修改订单状态为正在送货
                        }
                        else                           //操作失败
                        {
                            return false;
                        }
                    }
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
            int mode = 1;

            //判断邮寄地址是否包含在店面负责的范围之内

            return mode;
        }
        #endregion

        #region 选择送货店面

        /// <summary>
        /// 选择送货店面
        /// </summary>
        /// <returns>返回店面信息</returns>

        private bool SelectShop(ref ShopInfo shopInfo)
        {
            shopInfo.ShopAdd = "山东省";
            ShopInfoBLL shopInfoBLL = new ShopInfoBLL();
            return shopInfoBLL.SrchShopInfoByAdd(ref shopInfo);
        }

        #endregion

        #region 查询店面负责人员信息

        /// <summary>
        /// 查询店面负责人员信息
        /// </summary>
        /// <param name="shopManager">工作人员实体对象</param>
        /// <returns>操作成功返回true，否则返回false</returns>

        private bool SrchShopManager(ref WorkerInfo shopManager)
        {
            WorkerInfoBLL workerInfoBLL = new WorkerInfoBLL();
            return workerInfoBLL.SrchShopManager(ref shopManager);
        }

        #endregion

        #region 选择店面送货人员

        /// <summary>
        /// 选择店面送货人员
        /// </summary>
        /// <param name="workerInfo">工作人员实体对象</param>
        /// <returns>操作成功返回true，否则返回false</returns>

        private bool SelectWorkerByShop(ref WorkerInfo workerInfo)
        {
            WorkerInfoBLL workerInfoBLL = new WorkerInfoBLL();
            return workerInfoBLL.SelectWorkerByShop(ref workerInfo);
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
        /// <param name="workerInfo">送货人员实体对象</param>
        /// <returns>成功返回true，否则返回false</returns>

        private bool AddShippingInfo(LogisticsInfo logisticsInfo , WorkerInfo workerInfo)
        {
            LogisticsInfoDAL logisticsInfoDAL = new LogisticsInfoDAL();
            if (!logisticsInfoDAL.AddShippingInfo(logisticsInfo))
                return false;
            
            WorkerInfoBLL workerInfoBLL = new WorkerInfoBLL();
            if (!workerInfoBLL.AssignOrder(workerInfo))
                return false;

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
