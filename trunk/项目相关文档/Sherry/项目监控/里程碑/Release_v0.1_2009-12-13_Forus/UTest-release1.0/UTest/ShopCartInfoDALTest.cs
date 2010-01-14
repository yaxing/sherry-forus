using DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entity;

namespace UTest
{
    
    
    /// <summary>
    ///这是 ShopCartInfoDALTest 的测试类，旨在
    ///包含所有 ShopCartInfoDALTest 单元测试
    ///</summary>
    [TestClass()]
    public class ShopCartInfoDALTest
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
        ///GetStorage 的测试
        ///</summary>
        [TestMethod()]
        public void GetStorageTest()
        {
            ShopCartInfoDAL target = new ShopCartInfoDAL(); // TODO: 初始化为适当的值
            int storage = 0; // TODO: 初始化为适当的值
            int storageExpected = 92; // TODO: 初始化为适当的值
            int id = 5; // TODO: 初始化为适当的值
            bool expected = true; // TODO: 初始化为适当的值
            bool actual;
            actual = target.GetStorage(ref storage, id);
            Assert.AreEqual(storageExpected, storage);
            Assert.AreEqual(expected, actual);
            
            //Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///SetItemEntity 的测试
        ///</summary>
        [TestMethod()]
        public void SetItemEntityTest()
        {
            ShopCartInfoDAL target = new ShopCartInfoDAL(); // TODO: 初始化为适当的值
            ItemEntity info = new ItemEntity(5); // TODO: 初始化为适当的值
            ItemEntity infoExpected = new ItemEntity(5); // TODO: 初始化为适当的值
            infoExpected.Name = "纪梵希感光面膜";
            infoExpected.Number = 1;
            infoExpected.Price = 300;
            infoExpected.ImgPath = "images/eg1.jpg";
            bool expected = true; // TODO: 初始化为适当的值
            bool actual;

            actual = target.SetItemEntity(ref info);
            Assert.AreEqual(infoExpected.Name, info.Name);
            Assert.AreEqual(infoExpected.Number,info.Number);
            Assert.AreEqual(infoExpected.Price, info.Price);
            Assert.AreEqual(infoExpected.ImgPath, info.ImgPath);
            Assert.AreEqual(expected, actual);
           // Assert.Inconclusive("验证此测试方法的正确性。");
        }
    }
}
