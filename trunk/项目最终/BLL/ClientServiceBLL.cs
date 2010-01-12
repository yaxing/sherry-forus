using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using Entity;

namespace BLL
{
    public class ClientServiceBLL
    {
        #region 添加新信息

        /// <summary>
        /// 添加新信息
        /// </summary>
        /// <param name="message">信息实体对象</param>
        /// <returns>bool</returns>
       
        public bool AddMessage(Message message)
        {
            ClientServiceDAL addMessage = new ClientServiceDAL();
            return addMessage.AddNewMessage(message);
        }

        #endregion

        #region 查询前N条信息

        /// <summary>
        /// 查询前N条信息
        /// </summary>
        /// <param name="messageList">信息实体对象表</param>
        /// <param name="num">查询的条数</param>
        /// <returns>bool</returns>
        
        public bool ShowTopN(ref IList<Message> messageList, int num, bool isReply)
        {
            ClientServiceDAL showTopN = new ClientServiceDAL();
            return showTopN.ShowTopN(ref messageList, num, isReply);
        }

        #endregion

        #region 添加管理员回复

        /// <summary>
        /// 添加管理员回复
        /// </summary>
        /// <param name="messageID">留言ID</param>
        /// <param name="reply">回复内容</param>
        /// <returns>bool</returns>

        public bool AddReply(int messageID, string reply)
        {
            ClientServiceDAL ClientService = new ClientServiceDAL();
            return ClientService.AddReply(messageID, reply);
        }

        #endregion

        #region 删除留言

        /// <summary>
        /// 删除留言
        /// </summary>
        /// <param name="messageID">留言ID</param>     
        /// <returns>bool</returns>

        public bool DeleteMessage(int messageID)
        {
            ClientServiceDAL ClientService = new ClientServiceDAL();
            return ClientService.DeleteMessage(messageID);
        }

        #endregion
    }
}
