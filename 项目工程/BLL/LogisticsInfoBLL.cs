////编写者：李开林
////日  期：2009-12-8
////功  能：物流管理部分的逻辑处理

using System;
using System.Collections.Generic;
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

        public bool StartShipping(OrderInfo orderInfo)
        {
            int shippingMode = JudgeMode(orderInfo);

            switch (shippingMode)
            {
                case 1:         //店面方式送货 
                    {
                        ShopInfo shopInfo = new ShopInfo();
                        shopInfo.Area = orderInfo.UserProvince;
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
                            logisticsInfo.MainOrderID = orderInfo.OrderID;
                            logisticsInfo.WorkerID = workerInfo.WorkerID;
                            if (!AddShippingInfo(logisticsInfo , workerInfo))
                                return false;

                            //发送邮件给店面负责人
                            MailBLL mailBLL = new MailBLL();
                            string tomail = shopManager.EmailAdd;
                            string mailTitle = "新订单分配";
                            string mailBody = "订单号为" + orderInfo.OrderID + "的订单已经分配给您所在店面的工作人员："+workerInfo.WorkerRealName;
                            if (!mailBLL.SendEmail(tomail, mailTitle, mailBody))
                                return false;

                            //发送邮件给店面送货人员
                            tomail = workerInfo.EmailAdd;
                            mailTitle = "新订单分配";
                            mailBody = "订单号为" + orderInfo.OrderID + "的订单已经分配给您，请及时处理";
                            if (!mailBLL.SendEmail(tomail, mailTitle, mailBody))
                                return false;

                            /*
                            //修改订单状态为已发货
                            orderInfo.State = 2;
                            IChangeOrderState changeOrderState = new OrderCtrlBLL();
                            changeOrderState.ChangeOrderState(orderInfo);
                            */
                        }
                        else                           //操作失败
                        {
                            return false;
                        }
                    }
                    break;
                case 0:         //邮寄方式送货
                    {
                        //选择邮寄负责人
                        WorkerInfo mailResponser = new WorkerInfo();
                        mailResponser.ShopID = 1;
                        if (!SelectMailResponser(ref mailResponser))
                            return false;

                        //确定市场部负责人
                        WorkerInfo marketResponser = new WorkerInfo();
                        marketResponser.ShopID = 1;
                        if (!SrchMarketResponser(ref marketResponser))
                            return false;

                        //分配订单
                        LogisticsInfo logisticsInfo = new LogisticsInfo();
                        logisticsInfo.LogisticsType = 0;
                        logisticsInfo.MainOrderID = orderInfo.OrderID;
                        logisticsInfo.WorkerID = mailResponser.WorkerID;
                        if (!AddShippingInfo(logisticsInfo, mailResponser))
                            return false;

                        //发送邮件给市场部负责人
                        MailBLL mailBLL = new MailBLL();
                        string tomail = marketResponser.EmailAdd;
                        string mailTitle = "新订单分配";
                        string mailBody = "订单号为" + orderInfo.OrderID + "的订单已经分配给您的工作人员：" + mailResponser.WorkerRealName;
                        if (!mailBLL.SendEmail(tomail, mailTitle, mailBody))
                            return false;

                        //发送邮件给邮寄负责人
                        tomail = mailResponser.EmailAdd;
                        mailTitle = "新订单分配";
                        mailBody = "订单号为" + orderInfo.OrderID + "的订单已经分配给您，请及时处理";
                        if (!mailBLL.SendEmail(tomail, mailTitle, mailBody))
                            return false;

                        /*
                        //修改订单状态为已发货
                        orderInfo.State = 2;
                        IChangeOrderState changeOrderState = new OrderCtrlBLL();
                        changeOrderState.ChangeOrderState(orderInfo);
                        */
                    }
                    break;
                default:
                    return false;
            }

            return true;
        }
        #endregion

        #region 确定送货方式

        /// <summary>
        /// 确定送货方式
        /// </summary>
        /// <returns>1表示店面方式送货，2表示邮寄方式送货</returns>

        private int JudgeMode(OrderInfo orderInfo)
        {
            LogisticsInfoDAL logisticsInfoDAL = new LogisticsInfoDAL();
            int mode = logisticsInfoDAL.JudgeMode(orderInfo);

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
            LogisticsInfoDAL logisticsInfoDAL = new LogisticsInfoDAL();
            return logisticsInfoDAL.SrchShippingInfo(ref logisticsInfo);
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

        #region 发货确认

        /// <summary>
        /// 发货确认处理
        /// </summary>
        /// <param name="orderInfo">订单实体对象</param>
        /// <returns>成功返回true，否则返回false</returns>

        public bool ConfirmPicking(OrderInfo orderInfo)
        {
            orderInfo.State = 2;
            IChangeOrderState changeOrderState = new OrderCtrlBLL();
            return changeOrderState.ChangeOrderState(orderInfo);
        }

        #endregion

        #region 收货确认

        /// <summary>
        /// 收货确认处理
        /// </summary>
        /// <param name="orderInfo">订单实体对象</param>
        /// <returns>成功返回true，否则返回false</returns>

        public bool ConfirmReceiving(OrderInfo orderInfo)
        {
            orderInfo.State = 3;
            IChangeOrderState changeOrderState = new OrderCtrlBLL();
            return changeOrderState.ChangeOrderState(orderInfo);
        }
        #endregion

        #region 申请退货

        /// <summary>
        /// 申请退货处理
        /// </summary>
        /// <param name="orderInfo">订单实体对象</param>
        /// <returns>成功返回true，否则返回false</returns>

        public bool ApplyReturning(OrderInfo orderInfo)
        {
            LogisticsInfoBLL logisticsInfoBLL = new LogisticsInfoBLL();
            LogisticsInfo logisticsInfo = new LogisticsInfo();
            if (!logisticsInfoBLL.SrchShippingInfo(ref logisticsInfo))
                return false;

            WorkerInfo workerInfo = new WorkerInfo();
            workerInfo.WorkerID = logisticsInfo.WorkerID;

            WorkerInfoBLL workerInfoBLL = new WorkerInfoBLL();
            if (!workerInfoBLL.SrchWorkerInfo(ref workerInfo))
                return false;

            //发送邮件给订单负责人
            MailBLL mailBLL = new MailBLL();
            string tomail = workerInfo.EmailAdd;
            string mailTitle = "申请退货";
            string mailBody = "您所负责的订单号为" + orderInfo.OrderID + "的订单申请退货，请尽快处理！";
            if (!mailBLL.SendEmail(tomail, mailTitle, mailBody))
                return false;

            WorkerInfo managerInfo = new WorkerInfo();
            managerInfo.WorkerID = workerInfo.ManageID;

            if (!workerInfoBLL.SrchWorkerInfo(ref managerInfo))
                return false;

            //发送邮件给管理员
            tomail = managerInfo.EmailAdd;
            mailTitle = "申请退货";
            mailBody = "您所负责的员工" + workerInfo.WorkerRealName + "处理的订单号为" + orderInfo.OrderID + "的订单申请退货，请注意！";
            if (!mailBLL.SendEmail(tomail, mailTitle, mailBody))
                return false;

            orderInfo.State = 5;
            IChangeOrderState changeOrderState = new OrderCtrlBLL();
            return changeOrderState.ChangeOrderState(orderInfo);
        }
        #endregion

        #region 退货确认

        /// <summary>
        /// 退货确认处理
        /// </summary>
        /// <param name="orderInfo">订单实体对象</param>
        /// <returns>成功返回true，否则返回false</returns>

        public bool ConfirmReturning(OrderInfo orderInfo)
        {
            LogisticsInfoBLL logisticsInfoBLL = new LogisticsInfoBLL();
            LogisticsInfo logisticsInfo = new LogisticsInfo();
            if (!logisticsInfoBLL.SrchShippingInfo(ref logisticsInfo))
                return false;

            WorkerInfo workerInfo = new WorkerInfo();
            workerInfo.WorkerID = logisticsInfo.WorkerID;

            WorkerInfoBLL workerInfoBLL = new WorkerInfoBLL();
            if (!workerInfoBLL.SrchWorkerInfo(ref workerInfo))
                return false;

            //发送邮件给订单负责人
            MailBLL mailBLL = new MailBLL();
            string tomail = workerInfo.EmailAdd;
            string mailTitle = "确认退货";
            string mailBody = "由于工作失误，您所负责的订单号为" + orderInfo.OrderID + "的订单已经确定退货，请注意！";
            if (!mailBLL.SendEmail(tomail, mailTitle, mailBody))
                return false;

            WorkerInfo managerInfo = new WorkerInfo();
            managerInfo.WorkerID = workerInfo.ManageID;

            if (!workerInfoBLL.SrchWorkerInfo(ref managerInfo))
                return false;

            //发送邮件给管理员
            tomail = managerInfo.EmailAdd;
            mailTitle = "申请退货";
            mailBody = "您所负责的员工" + workerInfo.WorkerRealName + "处理的订单号为" + orderInfo.OrderID + "的订单确定退货，请注意！";
            if (!mailBLL.SendEmail(tomail, mailTitle, mailBody))
                return false;

            orderInfo.State = 4;
            IChangeOrderState changeOrderState = new OrderCtrlBLL();
            return changeOrderState.ChangeOrderState(orderInfo);
        }
        #endregion

        #region 退货驳回

        /// <summary>
        /// 退货驳回处理
        /// </summary>
        /// <param name="orderInfo">订单实体对象</param>
        /// <returns>成功返回true，否则返回false</returns>

        public bool RefuseReturning(OrderInfo orderInfo)
        {
            orderInfo.State = 6;
            IChangeOrderState changeOrderState = new OrderCtrlBLL();
            return changeOrderState.ChangeOrderState(orderInfo);
        }
        #endregion

        #region 选择邮寄负责人

        /// <summary>
        /// 选择邮寄负责人
        /// </summary>
        /// <returns>成功返回true，否则返回false</returns>

        public bool SelectMailResponser(ref WorkerInfo mailResponser)
        {
            WorkerInfoBLL workerInfoBLL = new WorkerInfoBLL();
            return workerInfoBLL.SelectWorkerByShop(ref mailResponser);
        }
        #endregion

        #region 确定市场部负责人

        /// <summary>
        /// 确定市场部负责人
        /// </summary>
        /// <returns>成功返回true，否则返回false</returns>

        public bool SrchMarketResponser(ref WorkerInfo marketResponser)
        {
            WorkerInfoBLL workerInfoBLL = new WorkerInfoBLL();
            return workerInfoBLL.SrchShopManager(ref marketResponser);
        }
        #endregion

        #region 实现根据送货人员ID查询订单列表

        /// <summary>
        /// 实现根据送货人员ID查询订单列表
        /// </summary>
        /// <param name="orderInfoList">订单列表</param>
        /// <param name="workerID">用户ID</param>
        /// <returns></returns>
        public bool SrchOrderListByWorkerID(ref IList<OrderInfo> orderInfoList , Guid workerID)
        {

            LogisticsInfoDAL logisticsInfoDAL = new LogisticsInfoDAL();
            if (logisticsInfoDAL.SrchOrderListByWorkerID(ref orderInfoList, workerID) == -1)
                return false;

            IChangeOrderState orderCtrl = new OrderCtrlBLL();
            if (!orderCtrl.SrchOrderInfoByID(ref orderInfoList))
                return false;

            return true;
        }
        #endregion

        #region 实现根据管理人员ID查询订单列表

        /// <summary>
        /// 实现根据管理人员ID查询订单列表
        /// </summary>
        /// <param name="orderInfoList">订单列表</param>
        /// <param name="managerID">用户ID</param>
        /// <returns></returns>
        public bool SrchOrderListByManagerID(ref IList<OrderInfo> orderInfoList, Guid managerID)
        {
            LogisticsInfoDAL logisticsInfoDAL = new LogisticsInfoDAL();
            if (logisticsInfoDAL.SrchOrderListByManagerID(ref orderInfoList, managerID) == -1)
                return false;

            IChangeOrderState orderCtrl = new OrderCtrlBLL();
            if (!orderCtrl.SrchOrderInfoByID(ref orderInfoList))
                return false;

            return true;
        }
        #endregion
    }
}
