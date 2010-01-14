using DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Entity;
using System.Collections.Generic;

namespace UTest
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
            admin.AdminID= Guid.NewGuid();
            bool expected = true; // TODO: 初始化为适当的值
            bool actual;
            actual = target.SrchAdminInfo(ref admin);
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
            Assert.IsFalse(actual < 0);            
        }

        /// <summary>
        ///AddAdmin，
        ///</summary>
        [TestMethod()]
        public void AddAdminTest()
        {
            AdminInfoDAL target = new AdminInfoDAL(); // TODO: 初始化为适当的值
            AdminInfo newadmin = new AdminInfo(); // TODO: 初始化为适当的值
            newadmin.AdminID = Guid.NewGuid();
            newadmin.AdminEmailAdd = "kim@g.cn";
            newadmin.AdminLv = 1;
            newadmin.AdminPhoneNum = "13269635774";
            newadmin.AdminRealName = "金哲宇";
            bool expected = true; // TODO: 初始化为适当的值
            bool actual;
            actual = target.AddAdmin(newadmin);
            Assert.AreEqual(expected, actual);

        }

        /// <summary>
        ///DeleteAdmin 的测试
        ///</summary>
        [TestMethod()]
        public void DeleteAdminTest()
        {
            AdminInfoDAL target = new AdminInfoDAL(); // TODO: 初始化为适当的值
            Guid adminID = Guid.NewGuid(); // TODO: 初始化为适当的值
            bool expected = true; // TODO: 初始化为适当的值
            bool actual;
            actual = target.DeleteAdmin(adminID);
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
            admin.AdminID = Guid.NewGuid();
            admin.AdminPhoneNum = "13269635774";
            admin.AdminRealName="金哲宇";
            admin.AdminLv=0;
            admin.AdminEmailAdd = "kim@gmail.com";

            bool expected = true; // TODO: 初始化为适当的值
            bool actual;
            actual = target.ModiAdminInfo(admin);
            Assert.AreEqual(expected, actual);
            
        }


        /// <summary>
        ///ModiAdminLv 的测试
        ///</summary>
        [TestMethod()]
        public void ModiAdminLvTest()
        {
            AdminInfoDAL target = new AdminInfoDAL(); // TODO: 初始化为适当的值
            AdminInfo admin = new AdminInfo(); // TODO: 初始化为适当的值
            admin.AdminID = Guid.NewGuid();
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.ModiAdminLv(admin);
            Assert.AreEqual(expected, actual);
        }

    }
}
