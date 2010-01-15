using BLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entity;
using System.Collections.Generic;

namespace TestProject1
{
    
    
    /// <summary>
    ///这是 ClientServiceBLLTest 的测试类，旨在
    ///包含所有 ClientServiceBLLTest 单元测试
    ///</summary>
    [TestClass()]
    public class ClientServiceBLLTest
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
        ///AddMessage 的测试
        ///</summary>
        [TestMethod()]
        public void AddMessageTest()
        {
            ClientServiceBLL target = new ClientServiceBLL(); // TODO: 初始化为适当的值
            Message message = new Message(); // TODO: 初始化为适当的值
            message.Topic = "TestMessage";
            message.Messages = "TestMessage";
            bool expected = true; // TODO: 初始化为适当的值
            bool actual;
            actual = target.AddMessage(message);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///AddReply 的测试
        ///</summary>
        [TestMethod()]
        public void AddReplyTest()
        {
            ClientServiceBLL target = new ClientServiceBLL(); // TODO: 初始化为适当的值
            Message message = new Message(); // TODO: 初始化为适当的值
            message.Topic = "TestMessage";
            message.Messages = "TestMessage";
            target.AddMessage(message);
            IList<Message> messages = new List<Message>();
            target.ShowTopN(ref messages, 1, false);
            int messageID = messages[0].MessageID; // TODO: 初始化为适当的值
            string reply = "TestReply"; // TODO: 初始化为适当的值
            bool expected = true; // TODO: 初始化为适当的值
            bool actual;
            actual = target.AddReply(messageID, reply);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///DeleteMessage 的测试
        ///</summary>
        [TestMethod()]
        public void DeleteMessageTest()
        {
            ClientServiceBLL target = new ClientServiceBLL(); // TODO: 初始化为适当的值
            Message message = new Message(); // TODO: 初始化为适当的值
            message.Topic = "TestMessage";
            message.Messages = "TestMessage";
            target.AddMessage(message);
            IList<Message> messages = new List<Message>();
            target.ShowTopN(ref messages, 1, false);
            int messageID = messages[0].MessageID; // TODO: 初始化为适当的值
            bool expected = true; // TODO: 初始化为适当的值
            bool actual;
            actual = target.DeleteMessage(messageID);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///ShowTopN 的测试
        ///</summary>
        [TestMethod()]
        public void ShowTopNTest()
        {
            ClientServiceBLL target = new ClientServiceBLL(); // TODO: 初始化为适当的值
            Message message = new Message(); // TODO: 初始化为适当的值
            message.Topic = "TestMessage";
            message.Messages = "TestMessage";
            target.AddMessage(message);
            message = new Message(); // TODO: 初始化为适当的值
            message.Topic = "TestReply";
            message.Reply = "TestReply";
            target.AddMessage(message);
            IList<Message> messageList = new List<Message>(); // TODO: 初始化为适当的值
            int num = 1; // TODO: 初始化为适当的值
            bool isReply = false; // TODO: 初始化为适当的值
            bool expected = true; // TODO: 初始化为适当的值
            bool actual;
            actual = target.ShowTopN(ref messageList, num, isReply);
            Assert.AreNotEqual(0, messageList.Count);
            Assert.AreEqual(expected, actual);

            isReply = true; // TODO: 初始化为适当的值
            expected = true; // TODO: 初始化为适当的值
            actual = target.ShowTopN(ref messageList, num, isReply);
            Assert.AreNotEqual(0, messageList.Count);
            Assert.AreEqual(expected, actual);
        }
    }
}
