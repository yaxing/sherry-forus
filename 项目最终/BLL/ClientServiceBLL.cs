using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using Entity;

namespace BLL
{
    public class ClientServiceBLL
    {
        #region �������Ϣ

        /// <summary>
        /// �������Ϣ
        /// </summary>
        /// <param name="message">��Ϣʵ�����</param>
        /// <returns>bool</returns>
       
        public bool AddMessage(Message message)
        {
            ClientServiceDAL addMessage = new ClientServiceDAL();
            return addMessage.AddNewMessage(message);
        }

        #endregion

        #region ��ѯǰN����Ϣ

        /// <summary>
        /// ��ѯǰN����Ϣ
        /// </summary>
        /// <param name="messageList">��Ϣʵ������</param>
        /// <param name="num">��ѯ������</param>
        /// <returns>bool</returns>
        
        public bool ShowTopN(ref IList<Message> messageList, int num, bool isReply)
        {
            ClientServiceDAL showTopN = new ClientServiceDAL();
            return showTopN.ShowTopN(ref messageList, num, isReply);
        }

        #endregion

        #region ��ӹ���Ա�ظ�

        /// <summary>
        /// ��ӹ���Ա�ظ�
        /// </summary>
        /// <param name="messageID">����ID</param>
        /// <param name="reply">�ظ�����</param>
        /// <returns>bool</returns>

        public bool AddReply(int messageID, string reply)
        {
            ClientServiceDAL ClientService = new ClientServiceDAL();
            return ClientService.AddReply(messageID, reply);
        }

        #endregion

        #region ɾ������

        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="messageID">����ID</param>     
        /// <returns>bool</returns>

        public bool DeleteMessage(int messageID)
        {
            ClientServiceDAL ClientService = new ClientServiceDAL();
            return ClientService.DeleteMessage(messageID);
        }

        #endregion
    }
}
