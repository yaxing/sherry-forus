////陈亚星
////2010-01-14
////订单生成模块DAL单元测试代码
using DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entity;
using System;
using System.Collections.Generic;

namespace TestProject1
{
    
    
    /// <summary>
    ///这是 CheckoutInfoDALTest 的测试类，旨在
    ///包含所有 CheckoutInfoDALTest 单元测试
    ///</summary>
    [TestClass()]
    public class CheckoutInfoDALTest
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
        ///UpdateToGoldenUser 的测试
        ///</summary>
        [TestMethod()]
        public void UpdateToGoldenUserTest()
        {
            CheckoutInfoDAL target = new CheckoutInfoDAL(); // TODO: 初始化为适当的值
            Guid userId = new Guid("fb370f30-5579-42aa-8107-a877f4a77829"); // TODO: 初始化为适当的值
            bool expected = true; // TODO: 初始化为适当的值
            bool actual;
            actual = target.UpdateToGoldenUser(userId);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///SetUserInfo 的测试
        ///</summary>
        [TestMethod()]
        public void SetUserInfoTest()
        {
            CheckoutInfoDAL target = new CheckoutInfoDAL(); // TODO: 初始化为适当的值
            UserInfo info = new UserInfo(); // TODO: 初始化为适当的值
            info.UserID = new Guid("fb370f30-5579-42aa-8107-a877f4a77829");
            UserInfo infoExpected = new UserInfo();
            infoExpected.PhoneNum = "13851389138";
            infoExpected.PostAdd = "中关村南大街5#北京理工大学11110601班";
            infoExpected.PostNum = "100081";
            infoExpected.UserRealName = "陈亚星";
            bool expected = true; // TODO: 初始化为适当的值
            bool actual;
            actual = target.SetUserInfo(ref info);
            Assert.AreEqual(infoExpected.PhoneNum, info.PhoneNum);
            Assert.AreEqual(infoExpected.PostAdd, info.PostAdd);
            Assert.AreEqual(infoExpected.PostNum, infoExpected.PostNum);
            Assert.AreEqual(infoExpected.UserRealName, info.UserRealName);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///ChangeUserInfo 的测试
        ///</summary>
        [TestMethod()]
        public void ChangeUserInfoTest()
        {
            CheckoutInfoDAL target = new CheckoutInfoDAL(); // TODO: 初始化为适当的值
            UserInfo info = new UserInfo(); // TODO: 初始化为适当的值
            info.UserID = new Guid("fb370f30-5579-42aa-8107-a877f4a77829");
            info.PhoneNum = "13851389138";
            info.PostAdd = "中关村南大街5#北京理工大学11110601班";
            info.PostNum = "100081";
            info.UserRealName = "陈亚星";
            bool expected = true; // TODO: 初始化为适当的值
            bool actual;
            actual = target.ChangeUserInfo(info);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///InsertNewOrder 的测试
        ///</summary>
        [TestMethod()]
        public void InsertNewOrderTest()
        {
            CheckoutInfoDAL target = new CheckoutInfoDAL(); // TODO: 初始化为适当的值
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
            
            int mainOrderID = 0; // TODO: 初始化为适当的值
            int mainOrderIDExpected = 0; // TODO: 初始化为适当的值
            bool isCallCenter = false; // TODO: 初始化为适当的值
            bool expected = true; // TODO: 初始化为适当的值
            bool actual;
            actual = target.InsertNewOrder(info, ref mainOrderID, isCallCenter);
            Assert.AreNotEqual(mainOrderIDExpected, mainOrderID);
            Assert.AreEqual(expected, actual);

            info.UserID = new Guid("fb370f30-5579-42aa-8107-a877f4a77829");
            info.UserAdd = "北京理工大学";
            info.UserZip = "100081";
            info.UserTel = "13851384138";
            info.UserRealName = "陈亚星";
            info.UserProvince = "海淀区";
            info.UserOrderPrice = 300.0;
            info.InvoiceHead = "个人";
            info.InvoiceContent = "化妆品";
            info.State = 0;
            isCallCenter = true;
            actual = target.InsertNewOrder(info, ref mainOrderID, isCallCenter);
            Assert.AreNotEqual(mainOrderIDExpected, mainOrderID);
            Assert.AreEqual(expected, actual);
        }
    }
}
