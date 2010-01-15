using DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entity;
using System.Collections.Generic;

namespace TestProject1
{
    
    
    /// <summary>
    ///这是 ShopInfoDALTest 的测试类，旨在
    ///包含所有 ShopInfoDALTest 单元测试
    ///</summary>
    [TestClass()]
    public class ShopInfoDALTest
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
        ///SrchShopInfoByAdd 的测试
        ///</summary>
        [TestMethod()]
        public void SrchShopInfoByAddTest()
        {
            ShopInfoDAL target = new ShopInfoDAL(); // TODO: 初始化为适当的值
            ShopInfo shopInfo = new ShopInfo(); // TODO: 初始化为适当的值
            shopInfo.Area = "海淀区";
            bool expected = true; // TODO: 初始化为适当的值
            bool actual;
            actual = target.SrchShopInfoByAdd(ref shopInfo);
            Assert.AreNotEqual(null, shopInfo.ShopID);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///SrchShopByProvence 的测试
        ///</summary>
        [TestMethod()]
        public void SrchShopByProvenceTest()
        {
            ShopInfoDAL target = new ShopInfoDAL(); // TODO: 初始化为适当的值
            IList<ShopInfo> shopInfoList = new List<ShopInfo>(); // TODO: 初始化为适当的值
            string province = "北京"; // TODO: 初始化为适当的值
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            actual = target.SrchShopByProvence(ref shopInfoList, province);
            Assert.AreNotEqual(0, shopInfoList.Count);
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///DisplayAllShop 的测试
        ///</summary>
        [TestMethod()]
        public void DisplayAllShopTest()
        {
            ShopInfoDAL target = new ShopInfoDAL(); // TODO: 初始化为适当的值
            IList<ShopInfo> allShop = new List<ShopInfo>(); // TODO: 初始化为适当的值
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            actual = target.DisplayAllShop(ref allShop);
            Assert.AreNotEqual(0, allShop.Count);
            Assert.AreNotEqual(expected, actual);
        }

    }
}
