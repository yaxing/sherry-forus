using DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entity;
using System;
using System.Collections.Generic;

namespace TestProject1
{
    
    
    /// <summary>
    ///这是 PollInfoDALTest 的测试类，旨在
    ///包含所有 PollInfoDALTest 单元测试
    ///</summary>
    [TestClass()]
    public class PollInfoDALTest
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
        ///UpdateSubPoll 的测试
        ///</summary>
        [TestMethod()]
        public void UpdateSubPollTest()
        {
            PollInfoDAL target = new PollInfoDAL(); // TODO: 初始化为适当的值
            SubPoll subPoll = new SubPoll(); // TODO: 初始化为适当的值
            subPoll.Description = "test";
            subPoll.Color = "white";
            subPoll.MainPollID = 1;
            subPoll.Num = 1;
            subPoll.SubPollID = 1;
            
            bool expected = true; // TODO: 初始化为适当的值
            bool actual;
            actual = target.UpdateSubPoll(subPoll);
            Assert.AreEqual(expected, actual);
           
        }

        /// <summary>
        ///UpdatePollNum 的测试
        ///</summary>
        [TestMethod()]
        public void UpdatePollNumTest()
        {
            PollInfoDAL target = new PollInfoDAL(); // TODO: 初始化为适当的值
            SubPoll subPoll = new SubPoll(); // TODO: 初始化为适当的值
            subPoll.Description = "test";
            subPoll.Color = "white";
            subPoll.MainPollID = 1;
            subPoll.Num = 1;
            subPoll.SubPollID = 1;

            bool expected = true; // TODO: 初始化为适当的值
            bool actual;
            actual = target.UpdateSubPoll(subPoll);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///UpdateMainPoll 的测试
        ///</summary>
        [TestMethod()]
        public void UpdateMainPollTest()
        {
            PollInfoDAL target = new PollInfoDAL(); // TODO: 初始化为适当的值
            MainPoll mainPoll =new MainPoll(); // TODO: 初始化为适当的值
            mainPoll.ColMode = "true";
            mainPoll.MainPollID = 1;
            mainPoll.SelectNum = 1;
            mainPoll.SingleMode = "false";
            mainPoll.Topic = "test topic";

            bool expected = true; // TODO: 初始化为适当的值
            bool actual;
            actual = target.UpdateMainPoll(mainPoll);
            Assert.AreEqual(expected, actual);

        }





        /// <summary>
        ///SelectByID 的测试
        ///</summary>
        [TestMethod()]
        public void SelectByIDTest()
        {
            PollInfoDAL target = new PollInfoDAL(); // TODO: 初始化为适当的值
            MainPoll mainPoll = new MainPoll(); // TODO: 初始化为适当的值

            mainPoll.MainPollID = 1;

            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.SelectByID(ref mainPoll);

            Assert.IsTrue(actual);

        }

        /// <summary>
        ///NumOfMainPoll 的测试
        ///</summary>
        [TestMethod()]
        public void NumOfMainPollTest()
        {
            PollInfoDAL target = new PollInfoDAL(); // TODO: 初始化为适当的值
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            actual = target.NumOfMainPoll();
            Assert.IsTrue(actual >= 0);

        }

        /// <summary>
        ///DeleteSubPoll 的测试
        ///</summary>
        [TestMethod()]
        public void DeleteSubPollTest()
        {
            PollInfoDAL target = new PollInfoDAL(); // TODO: 初始化为适当的值
            Guid subPollID = new Guid(); // TODO: 初始化为适当的值
            bool expected = true; // TODO: 初始化为适当的值
            bool actual;
            actual = target.DeleteSubPoll(subPollID);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///DeletePoll 的测试
        ///</summary>
        [TestMethod()]
        public void DeletePollTest()
        {
            PollInfoDAL target = new PollInfoDAL(); // TODO: 初始化为适当的值
            int mainPollID = 0; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.DeletePoll(mainPollID);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///DeleteMainPoll 的测试
        ///</summary>
        [TestMethod()]
        public void DeleteMainPollTest()
        {
            PollInfoDAL target = new PollInfoDAL(); // TODO: 初始化为适当的值
            Guid mainPollID = new Guid(); // TODO: 初始化为适当的值
            bool expected = true; // TODO: 初始化为适当的值
            bool actual;
            actual = target.DeleteMainPoll(mainPollID);
            Assert.AreEqual(expected, actual);
        }



        /// <summary>
        ///AddMainPoll 的测试
        ///</summary>
        [TestMethod()]
        public void AddMainPollTest()
        {
            PollInfoDAL target = new PollInfoDAL(); // TODO: 初始化为适当的值
            MainPoll newMainPoll = new MainPoll(); // TODO: 初始化为适当的值
            newMainPoll.ColMode = "true";
            newMainPoll.MainPollID = 2;
            newMainPoll.SelectNum = 5;
            newMainPoll.SingleMode = "false";
            newMainPoll.Topic = "another test main poll";

            int notExpected = -1; // TODO: 初始化为适当的值
            int actual;
            actual = target.AddMainPoll(newMainPoll);
            Assert.IsTrue(actual!=notExpected);

        }
    }
}
