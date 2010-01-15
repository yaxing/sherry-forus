using DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject1
{
    
    
    /// <summary>
    ///这是 MarketDecisionDALTest 的测试类，旨在
    ///包含所有 MarketDecisionDALTest 单元测试
    ///</summary>
    [TestClass()]
    public class MarketDecisionDALTest
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
        ///MemberShopSalesAmount 的测试
        ///</summary>
        [TestMethod()]
        public void MemberShopSalesAmountTest()
        {
            MarketDecisionDAL target = new MarketDecisionDAL(); // TODO: 初始化为适当的值
            int sAge = 0; // TODO: 初始化为适当的值
            int eAge = 0; // TODO: 初始化为适当的值
            DateTime sDate = new DateTime(2009,1,1); // TODO: 初始化为适当的值
            DateTime eDate = DateTime.Now; // TODO: 初始化为适当的值            
            int actual;
            actual = target.MemberShopSalesAmount(sAge, eAge, sDate, eDate);
            Assert.IsNotNull(actual);
                        
        }

        /// <summary>
        ///MemberPhoneSalesAmount 的测试
        ///</summary>
        [TestMethod()]
        public void MemberPhoneSalesAmountTest()
        {
            MarketDecisionDAL target = new MarketDecisionDAL(); // TODO: 初始化为适当的值
            int sAge = 0; // TODO: 初始化为适当的值
            int eAge = 100; // TODO: 初始化为适当的值
            DateTime sDate = new DateTime(2009,1,1); // TODO: 初始化为适当的值
            DateTime eDate =DateTime.Now; // TODO: 初始化为适当的值

            int actual;
            actual = target.MemberPhoneSalesAmount(sAge, eAge, sDate, eDate);
            Assert.IsNotNull(actual);
        }

        /// <summary>
        ///MemberOnlineSalesAmount 的测试
        ///</summary>
        [TestMethod()]
        public void MemberOnlineSalesAmountTest()
        {
            MarketDecisionDAL target = new MarketDecisionDAL(); // TODO: 初始化为适当的值
            int sAge = 0; // TODO: 初始化为适当的值
            int eAge = 100; // TODO: 初始化为适当的值
            DateTime sDate = new DateTime(2009, 1, 1); // TODO: 初始化为适当的值
            DateTime eDate = DateTime.Now; // TODO: 初始化为适当的值

            int actual;
            actual = target.MemberOnlineSalesAmount(sAge, eAge, sDate, eDate);
            Assert.IsNotNull(actual);
        }

        /// <summary>
        ///GoodsShopSalesAmount 的测试
        ///</summary>
        [TestMethod()]
        public void GoodsShopSalesAmountTest()
        {
            MarketDecisionDAL target = new MarketDecisionDAL(); // TODO: 初始化为适当的值
            DateTime sDate = new DateTime(2009,1,1); // TODO: 初始化为适当的值
            DateTime eDate = DateTime.Now; // TODO: 初始化为适当的值
            string categoryName = "面部护理"; // TODO: 初始化为适当的值
            
            int actual;
            actual = target.GoodsShopSalesAmount(sDate, eDate, categoryName);
            Assert.IsNotNull(actual);
        }

        /// <summary>
        ///GoodsPhoneSalesAmount 的测试
        ///</summary>
        [TestMethod()]
        public void GoodsPhoneSalesAmountTest()
        {
            
            MarketDecisionDAL target = new MarketDecisionDAL(); // TODO: 初始化为适当的值
            DateTime sDate = new DateTime(2009, 1, 1); // TODO: 初始化为适当的值
            DateTime eDate = DateTime.Now; // TODO: 初始化为适当的值
            string categoryName = "面部护理"; // TODO: 初始化为适当的值

            int actual;
            actual = target.GoodsPhoneSalesAmount(sDate, eDate, categoryName);
            Assert.IsNotNull(actual);
        }

        /// <summary>
        ///GoodsOnlineSalesAmount 的测试
        ///</summary>
        [TestMethod()]
        public void GoodsOnlineSalesAmountTest()
        {
            MarketDecisionDAL target = new MarketDecisionDAL(); // TODO: 初始化为适当的值
            DateTime sDate = new DateTime(2009, 1, 1); // TODO: 初始化为适当的值
            DateTime eDate = DateTime.Now; // TODO: 初始化为适当的值
            string categoryName = "面部护理"; // TODO: 初始化为适当的值

            int actual;
            actual = target.GoodsOnlineSalesAmount(sDate, eDate, categoryName);
            Assert.IsNotNull(actual);
        }

        /// <summary>
        ///CountMembersAgeGroup 的测试
        ///</summary>
        [TestMethod()]
        public void CountMembersAgeGroupTest()
        {
            MarketDecisionDAL target = new MarketDecisionDAL(); // TODO: 初始化为适当的值
            int sAge = 1; // TODO: 初始化为适当的值
            int eAge = 100; // TODO: 初始化为适当的值

            int actual;
            actual = target.CountMembersAgeGroup(sAge, eAge);
            Assert.IsNotNull(actual);
        }
    }
}
