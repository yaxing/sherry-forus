using BLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace TestProject1
{
    
    
    /// <summary>
    ///这是 SecurityServiceTest 的测试类，旨在
    ///包含所有 SecurityServiceTest 单元测试
    ///</summary>
    [TestClass()]
    public class SecurityServiceTest
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
        ///EncryptDES 的测试
        ///</summary>
        [TestMethod()]
        public void EncryptDESTest1()
        {
            string encryptString = "TestString"; // TODO: 初始化为适当的值
            bool expected = true; // TODO: 初始化为适当的值
            bool actual;
            actual = SecurityService.EncryptDES(ref encryptString);
            Assert.AreNotEqual(null, encryptString);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///EncryptDES 的测试
        ///</summary>
        [TestMethod()]
        public void EncryptDESTest()
        {
            string encryptString = "TestString"; // TODO: 初始化为适当的值
            SecurityService.EncryptDES(ref encryptString);
            string encryptKey = "11111111"; // TODO: 初始化为适当的值
            bool expected = true; // TODO: 初始化为适当的值
            bool actual;
            actual = SecurityService.EncryptDES(ref encryptString, encryptKey);
            Assert.AreNotEqual(null, encryptString);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///DecryptDES 的测试
        ///</summary>
        [TestMethod()]
        public void DecryptDESTest1()
        {
            string decryptString = "TestString"; // TODO: 初始化为适当的值
            SecurityService.EncryptDES(ref decryptString, "11111111");
            string decryptStringExpected = "TestString"; // TODO: 初始化为适当的值
            string decryptKey = "11111111"; // TODO: 初始化为适当的值
            bool expected = true; // TODO: 初始化为适当的值
            bool actual;
            actual = SecurityService.DecryptDES(ref decryptString, decryptKey);
            Assert.AreEqual(decryptStringExpected, decryptString);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///DecryptDES 的测试
        ///</summary>
        [TestMethod()]
        public void DecryptDESTest()
        {
            string decryptString = "TestString"; // TODO: 初始化为适当的值
            SecurityService.EncryptDES(ref decryptString);
            string decryptStringExpected = "TestString"; // TODO: 初始化为适当的值
            bool expected = true; // TODO: 初始化为适当的值
            bool actual;
            actual = SecurityService.DecryptDES(ref decryptString);
            Assert.AreEqual(decryptStringExpected, decryptString);
            Assert.AreEqual(expected, actual);
        }
    }
}
