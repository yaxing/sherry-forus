using DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entity;
using System;
using System.Collections.Generic;

namespace TestProject1
{
    
    
    /// <summary>
    ///这是 AdminInfoDALTest 的测试类，旨在
    ///包含所有 AdminInfoDALTest 单元测试
    ///</summary>
    [TestClass()]
    public class AdminInfoDALTest
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
        ///SrchAdminInfo 的测试
        ///</summary>
        [TestMethod()]
        public void SrchAdminInfoTest()
        {
            AdminInfoDAL target = new AdminInfoDAL(); // TODO: 初始化为适当的值
            AdminInfo admin = new AdminInfo(); // TODO: 初始化为适当的值
            admin.AdminID = new Guid("375E7926-AA12-4471-AF98-49A5EE90EFB2");
            bool expected = true; // TODO: 初始化为适当的值
            bool actual;
            actual = target.SrchAdminInfo(ref admin);
            Assert.IsNotNull(admin.AdminRealName);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///ShowAdminInfo 的测试
        ///</summary>
        [TestMethod()]
        public void ShowAdminInfoTest()
        {
            AdminInfoDAL target = new AdminInfoDAL(); // TODO: 初始化为适当的值
            IList<AdminInfo> adminList = null; // TODO: 初始化为适当的值
            int actual;
            actual = target.ShowAdminInfo(ref adminList);
            Assert.IsNotNull(actual);
        }

        /// <summary>
        ///ModiAdminLv 的测试
        ///</summary>
        [TestMethod()]
        public void ModiAdminLvTest()
        {
            AdminInfoDAL target = new AdminInfoDAL(); // TODO: 初始化为适当的值
            AdminInfo admin = new AdminInfo(); // TODO: 初始化为适当的值
            admin.AdminID = new Guid("375E7926-AA12-4471-AF98-49A5EE90EFB2");
            admin.AdminLv = 1;
            bool expected = true; // TODO: 初始化为适当的值
            bool actual;
            actual = target.ModiAdminLv(admin);
            Assert.AreEqual(expected, actual);

        }

        /// <summary>
        ///ModiAdminInfo 的测试
        ///</summary>
        [TestMethod()]
        public void ModiAdminInfoTest()
        {
            AdminInfoDAL target = new AdminInfoDAL(); // TODO: 初始化为适当的值
            AdminInfo admin = new AdminInfo(); // TODO: 初始化为适当的值
            admin.AdminID = new Guid("375E7926-AA12-4471-AF98-49A5EE90EFB2");
            admin.AdminRealName = "jinzheyu";
            admin.EmailAdd = "jinzheyu@g.cn";
            admin.AdminPhoneNum = "13269635774";
            admin.AdminLv = 1;
            bool expected = true; // TODO: 初始化为适当的值
            bool actual;
            actual = target.ModiAdminInfo(admin);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///DeleteAdmin 的测试
        ///</summary>
        [TestMethod()]
        public void DeleteAdminTest()
        {
            AdminInfoDAL target = new AdminInfoDAL(); // TODO: 初始化为适当的值
            Guid adminID = new Guid("BFA4152E-14C5-4859-9AC8-6925E107E012"); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.DeleteAdmin(adminID);
            Assert.AreEqual(expected, actual);

        }

        /// <summary>
        ///AddAdmin 的测试
        ///</summary>
        [TestMethod()]
        public void AddAdminTest()
        {
            AdminInfoDAL target = new AdminInfoDAL(); // TODO: 初始化为适当的值
            AdminInfo newadmin = new AdminInfo(); // TODO: 初始化为适当的值
            newadmin.AdminID = new Guid("BFA4152E-14C5-4859-9AC8-6925E107E088");
            newadmin.AdminLv=1;
            newadmin.AdminPhoneNum="13269635774";
            newadmin.AdminRealName="kimzheyu";
            newadmin.AdminEmailAdd = "kim@g.cn";
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.AddAdmin(newadmin);
            Assert.AreEqual(expected, actual);

        }
    }
}
