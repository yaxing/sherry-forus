﻿using DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Entity;
using System.Collections.Generic;
namespace TestProject1
{
    
    
    /// <summary>
    ///这是 UserScoreDALTest 的测试类，旨在
    ///包含所有 UserScoreDALTest 单元测试
    ///</summary>
    [TestClass()]
    public class UserScoreDALTest
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
        ///UpdateScore 的测试
        ///</summary>
        [TestMethod()]
        public void UpdateScoreTest()
        {
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
            actual1 = insertEg.InsertNewOrder(info, ref orderId, false);

            UserScoreDAL target = new UserScoreDAL(); // TODO: 初始化为适当的值
            Guid userId = new Guid("fb370f30-5579-42aa-8107-a877f4a77829"); // TODO: 初始化为适当的值
            int score = orderId; // TODO: 初始化为适当的值
            bool flag = false; // TODO: 初始化为适当的值
            actual = target.UpdateScore(userId, score, flag);
            Assert.AreEqual(expected, actual1);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///GetUserScore 的测试
        ///</summary>
        [TestMethod()]
        public void GetUserScoreTest()
        {
            UserScoreDAL target = new UserScoreDAL(); // TODO: 初始化为适当的值
            Guid userId = new Guid("fb370f30-5579-42aa-8107-a877f4a77829"); // TODO: 初始化为适当的值
            int userScore = 0; // TODO: 初始化为适当的值
            bool expected = true; // TODO: 初始化为适当的值
            bool actual;
            actual = target.GetUserScore(userId, ref userScore);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///GetUserLv 的测试
        ///</summary>
        [TestMethod()]
        public void GetUserLvTest()
        {
            UserScoreDAL target = new UserScoreDAL(); // TODO: 初始化为适当的值
            Guid userId = new Guid("fb370f30-5579-42aa-8107-a877f4a77829"); // TODO: 初始化为适当的值
            int userLv = 0; // TODO: 初始化为适当的值
            bool expected = true; // TODO: 初始化为适当的值
            bool actual;
            actual = target.GetUserLv(userId, ref userLv);
            Assert.AreEqual(expected, actual);
        }
    }
}
