////陈亚星
////2010-01-15
////单元测试代码
using DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entity;
using System;

namespace TestProject1
{
    
    
    /// <summary>
    ///这是 UploadInfoDALTest 的测试类，旨在
    ///包含所有 UploadInfoDALTest 单元测试
    ///</summary>
    [TestClass()]
    public class UploadInfoDALTest
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
        ///AddMainUpload 的测试
        ///</summary>
        [TestMethod()]
        public void AddMainUploadTest()
        {
            UploadInfoDAL target = new UploadInfoDAL(); // TODO: 初始化为适当的值
            MainUpload mainUpload = new MainUpload(); // TODO: 初始化为适当的值
            mainUpload.ShopID = 1;
            mainUpload.SellTime = DateTime.Today;
            mainUpload.TotalValue = 300;
            mainUpload.Gender = "女";
            mainUpload.Age = 16;
            mainUpload.Province = "北京";
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            actual = target.AddMainUpload(mainUpload);
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///AddSubUpload 的测试
        ///</summary>
        [TestMethod()]
        public void AddSubUploadTest()
        {
            UploadInfoDAL target = new UploadInfoDAL(); // TODO: 初始化为适当的值

            MainUpload mainUpload = new MainUpload(); // TODO: 初始化为适当的值
            mainUpload.ShopID = 1;
            mainUpload.SellTime = DateTime.Today;
            mainUpload.TotalValue = 300;
            mainUpload.Gender = "女";
            mainUpload.Age = 16;
            mainUpload.Province = "北京";
            int expected1 = 0; // TODO: 初始化为适当的值
            int actual1;
            actual1 = target.AddMainUpload(mainUpload);
            Assert.AreNotEqual(expected1, actual1);

            SubUpload newSubUpload = new SubUpload(); // TODO: 初始化为适当的值
            newSubUpload.MainUploadID = mainUpload.MainUploadID;
            newSubUpload.GoodsID = 5;
            newSubUpload.GoodsName = "Test";
            newSubUpload.Number = 1;
            newSubUpload.Price = 300;
            newSubUpload.TotalValue = 300;
            bool expected = true; // TODO: 初始化为适当的值
            bool actual;
            actual = target.AddSubUpload(newSubUpload);
            Assert.AreEqual(expected, actual);
        }
    }
}
