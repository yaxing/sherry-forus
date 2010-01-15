using BLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entity;
using System.Collections.Generic;

namespace TestProject1
{
    
    
    /// <summary>
    ///这是 MasterPageBLLTest 的测试类，旨在
    ///包含所有 MasterPageBLLTest 单元测试
    ///</summary>
    [TestClass()]
    public class MasterPageBLLTest
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
        ///GetSpecialOffers 的测试
        ///</summary>
        [TestMethod()]
        public void GetSpecialOffersTest()
        {
            MasterPageBLL target = new MasterPageBLL(); // TODO: 初始化为适当的值
            IList<ItemEntity> itemList = new List<ItemEntity>(); // TODO: 初始化为适当的值
            bool expected = true; // TODO: 初始化为适当的值
            bool actual;
            actual = target.GetSpecialOffers(ref itemList);
            Assert.AreNotEqual(0, itemList.Count);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///GetCategoryList 的测试
        ///</summary>
        [TestMethod()]
        public void GetCategoryListTest()
        {
            MasterPageBLL target = new MasterPageBLL(); // TODO: 初始化为适当的值
            IList<ItemEntity> categoryList = new List<ItemEntity>(); // TODO: 初始化为适当的值
            bool expected = true; // TODO: 初始化为适当的值
            bool actual;
            actual = target.GetCategoryList(ref categoryList);
            Assert.AreNotEqual(0, categoryList.Count);
            Assert.AreEqual(expected, actual);
        }
    }
}
