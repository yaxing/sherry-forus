using DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entity;
using System;
using System.Data;

namespace TestProject1
{
    
    
    /// <summary>
    ///这是 GoodsInfoDALTest 的测试类，旨在
    ///包含所有 GoodsInfoDALTest 单元测试
    ///</summary>
    [TestClass()]
    public class GoodsInfoDALTest
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
        ///LatestGoods 的测试
        ///</summary>
        [TestMethod()]
        public void LatestGoodsTest()
        {
            int num = 5; // TODO: 初始化为适当的值
            bool orderByVolume = false; // TODO: 初始化为适当的值
            DataTable actual;
            actual = GoodsInfoDAL.LatestGoods(num, orderByVolume);
            Assert.IsNotNull(actual);
            
        }

        /// <summary>
        ///GoodsDetail 的测试
        ///</summary>
        [TestMethod()]
        public void GoodsDetailTest()
        {
            int goodsID = 5; // TODO: 初始化为适当的值
            GoodsInfo actual;
            actual = GoodsInfoDAL.GoodsDetail(goodsID);
            Assert.IsNotNull(actual);
        }

        /// <summary>
        ///GetCategory 的测试
        ///</summary>
        [TestMethod()]
        public void GetCategoryTest()
        {
            DataTable category = null; // TODO: 初始化为适当的值
            DataTable categoryExpected = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = GoodsInfoDAL.GetCategory(ref category);
            Assert.IsNotNull(actual);
        }

        /// <summary>
        ///FindSpecialGoods 的测试
        ///</summary>
        [TestMethod()]
        public void FindSpecialGoodsTest()
        {
            DataTable expected = null; // TODO: 初始化为适当的值
            DataTable actual;
            actual = GoodsInfoDAL.FindSpecialGoods();
            Assert.IsNotNull(actual);
                
        }

        /// <summary>
        ///FindGoods 的测试
        ///</summary>
        [TestMethod()]
        public void FindGoodsTest()
        {
            string goodsName = "test"; // TODO: 初始化为适当的值
            string goodsNum = "1"; // TODO: 初始化为适当的值
            int goodsCategory = 1; // TODO: 初始化为适当的值
            DateTime timeFrom = new DateTime(2009,1,1); // TODO: 初始化为适当的值
            DateTime timeTo = new DateTime(2009,12,30); // TODO: 初始化为适当的值
            DataTable actual;
            actual = GoodsInfoDAL.FindGoods(goodsName, goodsNum, goodsCategory, timeFrom, timeTo);
            Assert.IsNotNull(actual);
        }

        /// <summary>
        ///DeleteGoods 的测试
        ///</summary>
        [TestMethod()]
        public void DeleteGoodsTest()
        {
            int goodsID = 99999; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = GoodsInfoDAL.DeleteGoods(goodsID);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///ChangeGoods 的测试
        ///</summary>
        [TestMethod()]
        public void ChangeGoodsTest()
        {
            int goodsID = 0; // TODO: 初始化为适当的值
            GoodsInfo goodsInfo = new GoodsInfo(); // TODO: 初始化为适当的值
            goodsInfo.goodsAddTime = DateTime.Now;
            goodsInfo.goodsAvailable = true;
            goodsInfo.goodsCategory = 1;
            goodsInfo.goodsDescribe="test again";
            goodsInfo.goodsName="test again";
            goodsInfo.goodsNum="100";
            goodsInfo.goodsPrice=100;
            goodsInfo.goodsSpecialOffer=1;
            goodsInfo.goodsStorage=100;
            goodsInfo.goodsValidity=new DateTime(2012,12,26);
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = GoodsInfoDAL.ChangeGoods(goodsID, goodsInfo);
            Assert.AreEqual(expected, actual);

        }
    }
}
