using DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entity;
using System.Collections.Generic;
using System;
using System.Data;

namespace TestProject1
{
    
    
    /// <summary>
    ///这是 OrderCtrlDALTest 的测试类，旨在
    ///包含所有 OrderCtrlDALTest 单元测试
    ///</summary>
    [TestClass()]
    public class OrderCtrlDALTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///获取或设置测试上下文，上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region 附加测试属性
        // 
        //编写测试时，还可使用以下属性:
        //
        //使用 ClassInitialize 在运行类中的第一个测试前先运行代码
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //使用 ClassCleanup 在运行完类中的所有测试后再运行代码
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //使用 TestInitialize 在运行每个测试前先运行代码
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //使用 TestCleanup 在运行完每个测试后运行代码
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///SrchOrderInfoByID 的测试
        ///</summary>
        [TestMethod()]
        public void SrchOrderInfoByIDTest()
        {
            OrderCtrlDAL target = new OrderCtrlDAL(); // TODO: 初始化为适当的值
            OrderInfo orderInfo = new OrderInfo(); // TODO: 初始化为适当的值
            orderInfo.OrderID = 38;
            //OrderInfo orderInfoExpected = new OrderInfo(); // TODO: 初始化为适当的值
            bool expected = true; // TODO: 初始化为适当的值
            bool actual;
            actual = target.SrchOrderInfoByID(ref orderInfo);
            Assert.AreEqual(expected, actual);
            Assert.AreNotEqual(null, orderInfo.UserID);
            
        }

        /// <summary>
        ///GetOrdersByTime_CurCustomer 的测试
        ///</summary>
        [TestMethod()]
        public void GetOrdersByTime_CurCustomerTest()
        {
            OrderCtrlDAL target = new OrderCtrlDAL(); // TODO: 初始化为适当的值
            //插入测试订单
            CheckoutInfoDALTest createNewTestOrder = new CheckoutInfoDALTest();
            createNewTestOrder.InsertNewOrderTest();
            IList<OrderInfo> orders = new List<OrderInfo>(); // TODO: 初始化为适当的值
            Guid userId = new Guid("fb370f30-5579-42aa-8107-a877f4a77829");  // TODO: 初始化为适当的值
            DateTime dateStart = DateTime.Today.AddDays(-1); // TODO: 初始化为适当的值
            DateTime dateEnd = DateTime.Today.AddDays(1); // TODO: 初始化为适当的值
            bool expected = true; // TODO: 初始化为适当的值
            bool actual;
            actual = target.GetOrdersByTime_CurCustomer(ref orders, userId, dateStart, dateEnd);
            Assert.AreEqual(expected, actual);
            Assert.AreNotEqual(0, orders.Count);
            
        }

        /// <summary>
        ///GetOrderList 的测试
        ///</summary>
        [TestMethod()]
        public void GetOrderListTest()
        {
            OrderCtrlDAL target = new OrderCtrlDAL(); // TODO: 初始化为适当的值
            DataTable orders = new DataTable(); // TODO: 初始化为适当的值
            Guid userId = new Guid("fb370f30-5579-42aa-8107-a877f4a77829"); // TODO: 初始化为适当的值
            bool expected = true; // TODO: 初始化为适当的值
            bool actual;
            actual = target.GetOrderList(ref orders, userId);
            Assert.AreNotEqual(0, orders.Rows.Count);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///GetItemList 的测试
        ///</summary>
        [TestMethod()]
        public void GetItemListTest()
        {
            OrderCtrlDAL target = new OrderCtrlDAL(); // TODO: 初始化为适当的值
            DataTable items = new DataTable(); // TODO: 初始化为适当的值
            int orderId = 52; // TODO: 初始化为适当的值
            bool expected = true; // TODO: 初始化为适当的值
            bool actual;
            actual = target.GetItemList(ref items, orderId);
            Assert.AreNotEqual(0, items.Rows.Count);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///GetHistoryOrderList 的测试
        ///</summary>
        [TestMethod()]
        public void GetHistoryOrderListTest()
        {
            OrderCtrlDAL target = new OrderCtrlDAL(); // TODO: 初始化为适当的值
            DataTable orders = new DataTable(); // TODO: 初始化为适当的值
            Guid userId = new Guid("fb370f30-5579-42aa-8107-a877f4a77829"); // TODO: 初始化为适当的值
            bool expected = true; // TODO: 初始化为适当的值
            bool actual;
            actual = target.GetHistoryOrderList(ref orders, userId);
            Assert.AreNotEqual(0, orders.Rows.Count);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///GetCurrentOrderList 的测试
        ///</summary>
        [TestMethod()]
        public void GetCurrentOrderListTest()
        {
            OrderCtrlDAL target = new OrderCtrlDAL(); // TODO: 初始化为适当的值
            DataTable orders = new DataTable(); // TODO: 初始化为适当的值
            Guid userId = new Guid("fb370f30-5579-42aa-8107-a877f4a77829"); // TODO: 初始化为适当的值
            bool expected = true; // TODO: 初始化为适当的值
            bool actual;
            actual = target.GetCurrentOrderList(ref orders, userId);
            Assert.AreNotEqual(0, orders.Rows.Count);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///GetAllOrders 的测试
        ///</summary>
        [TestMethod()]
        public void GetAllOrdersTest()
        {
            OrderCtrlDAL target = new OrderCtrlDAL(); // TODO: 初始化为适当的值
            IList<OrderInfo> orders = new List<OrderInfo>(); // TODO: 初始化为适当的值
            bool expected = true; // TODO: 初始化为适当的值
            bool actual;
            actual = target.GetAllOrders(ref orders);
            Assert.AreNotEqual(0, orders.Count);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///DeleteOrder 的测试
        ///</summary>
        [TestMethod()]
        public void DeleteOrderTest()
        {
            OrderCtrlDAL target = new OrderCtrlDAL(); // TODO: 初始化为适当的值
            OrderInfo info = new OrderInfo(); // TODO: 初始化为适当的值
            info.UserID = new Guid("fb370f30-5579-42aa-8107-a877f4a77829");
            info.UserAdd = "北京理工大学";
            info.UserZip = "100081";
            info.UserTel = "13851384138";
            info.UserRealName = "陈亚星";
            info.UserProvince = "海淀区";
            info.UserOrderPrice = 300.0;
            info.InvoiceHead = "";
            info.InvoiceContent = "";
            info.State = 0;
            info.UserOrderItems = new List<ItemEntity>();
            ItemEntity ie = new ItemEntity();
            ie.ID = 5;
            ie.Name = "纪梵希感光面膜";
            ie.Price = 300;
            ie.Discount = 0.9;
            ie.Number = 1;
            info.UserOrderItems.Add(ie);

            bool expected = true; // TODO: 初始化为适当的值
            bool actual;
            bool actual1;
            int orderId = 0; // TODO: 初始化为适当的值
            CheckoutInfoDAL insertEg = new CheckoutInfoDAL();
            actual1 = insertEg.InsertNewOrder(info,ref orderId, false);
            actual = target.DeleteOrder(orderId);
            Assert.AreEqual(expected, actual1);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///ChangePayState 的测试
        ///</summary>
        [TestMethod()]
        public void ChangePayStateTest()
        {
            OrderCtrlDAL target = new OrderCtrlDAL(); // TODO: 初始化为适当的值
            OrderInfo info = new OrderInfo(); // TODO: 初始化为适当的值
            info.UserID = new Guid("fb370f30-5579-42aa-8107-a877f4a77829");
            info.UserAdd = "北京理工大学";
            info.UserZip = "100081";
            info.UserTel = "13851384138";
            info.UserRealName = "陈亚星";
            info.UserProvince = "海淀区";
            info.UserOrderPrice = 300.0;
            info.InvoiceHead = "";
            info.InvoiceContent = "";
            info.State = 0;
            info.UserOrderItems = new List<ItemEntity>();
            ItemEntity ie = new ItemEntity();
            ie.ID = 5;
            ie.Name = "纪梵希感光面膜";
            ie.Price = 300;
            ie.Discount = 0.9;
            ie.Number = 1;
            info.UserOrderItems.Add(ie);

            bool expected = true; // TODO: 初始化为适当的值
            bool actual;
            bool actual1;
            int orderID = 0; // TODO: 初始化为适当的值
            CheckoutInfoDAL insertEg = new CheckoutInfoDAL();
            actual1 = insertEg.InsertNewOrder(info, ref orderID, false);
            actual = target.ChangePayState(orderID);
            Assert.AreEqual(expected,actual1);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///ChangeOrderState 的测试
        ///</summary>
        [TestMethod()]
        public void ChangeOrderStateTest()
        {
            OrderCtrlDAL target = new OrderCtrlDAL(); // TODO: 初始化为适当的值
            OrderInfo info = new OrderInfo(); // TODO: 初始化为适当的值
            info.UserID = new Guid("fb370f30-5579-42aa-8107-a877f4a77829");
            info.UserAdd = "北京理工大学";
            info.UserZip = "100081";
            info.UserTel = "13851384138";
            info.UserRealName = "陈亚星";
            info.UserProvince = "海淀区";
            info.UserOrderPrice = 300.0;
            info.InvoiceHead = "";
            info.InvoiceContent = "";
            info.State = 0;
            info.UserOrderItems = new List<ItemEntity>();
            ItemEntity ie = new ItemEntity();
            ie.ID = 5;
            ie.Name = "纪梵希感光面膜";
            ie.Price = 300;
            ie.Discount = 0.9;
            ie.Number = 1;
            info.UserOrderItems.Add(ie);

            bool expected = true; // TODO: 初始化为适当的值
            bool actual;
            bool actual1;
            int orderID = 0; // TODO: 初始化为适当的值
            CheckoutInfoDAL insertEg = new CheckoutInfoDAL();
            actual1 = insertEg.InsertNewOrder(info, ref orderID, false);

            OrderInfo curOrder = new OrderInfo();
            curOrder.OrderID = orderID;
            curOrder.State = 1;
            actual = target.ChangeOrderState(curOrder);
            Assert.AreEqual(expected, actual1);
            Assert.AreEqual(expected, actual);
        }


    }
}
