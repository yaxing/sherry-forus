using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DbCtrl;
using Entity;

namespace DAL
{
    public class ClientServiceDAL   //�ͻ�����DAL
    {

        private string sqlString;   //���ݿ��ѯ�ַ���
        private DataProvider dp = new DataProvider();   //���ݿ��ѯ��

        #region �������Ϣ

        /// <summary>
        /// �������Ϣ
        /// </summary>
        /// <param name="newMessage">��Ϣʵ�����</param>
        /// <returns>bool</returns>

        public bool AddNewMessage(Message newMessage)   //���������
        {
            sqlString = "Insert into Messages (topic, messages) Values (@topic, @messages)";
            
            SqlParameter[] pt = new SqlParameter[]{
                                new SqlParameter("@topic",SqlDbType.VarChar),
                                new SqlParameter("@messages",SqlDbType.VarChar),
                                };

            pt[0].Value = newMessage.Topic;
            pt[1].Value = newMessage.Messages;

            try
            {
                using(dp = new DataProvider())
                {
                    if (dp.ExecuteNonQuery(sqlString,pt) == 0)
                        return false;
                }
            }
            catch
            {
            }

            return true;
        }

        #endregion

        #region ��ѯǰN����Ϣ

        /// <summary>
        /// ��ѯǰN����Ϣ
        /// </summary>
        /// <param name="messageList">��Ϣʵ������</param>
        /// <param name="num">��ѯ������</param>
        /// <param name="isReply">�Ƿ���Ҫreply</param>
        /// <returns>bool</returns>

        public bool ShowTopN(ref IList<Message> messageList, int num, bool isReply) //��ѯǰN������
        {
            if (isReply)
                sqlString = "Select Top " + num + " * from Messages where reply is not null";
            else
                sqlString = "Select Top " + num + " * from Messages where reply is null";

            SqlParameter[] pt = new SqlParameter[]{
                                new SqlParameter("@num",SqlDbType.Int),
                                };

            pt[0].Value = num;

            try
            {
                using (dp = new DataProvider())
                {
                    using (SqlDataReader reader = dp.ExecuteReader(sqlString, pt))
                    {
                        while (reader.Read())
                        {
                            Message newMessage = new Message();
                            newMessage.MessageID = reader.GetInt32(0);
                            newMessage.Topic = reader.GetString(1);
                            newMessage.Messages = reader.GetString(2);
                            if (isReply)
                                newMessage.Reply = reader.GetString(3);

                            messageList.Add(newMessage);
                        }
                    }
                }
            }
            catch
            {
            }

            return true;
        }

        #endregion

        #region ��ӹ���Ա�ظ�

        /// <summary>
        /// ��ӹ���Ա�ظ�
        /// </summary>
        /// <param name="message">��Ϣʵ��</param>
        /// <param name="reply">�ظ�����</param>
        /// <returns>bool</returns>

        public bool AddReply(int messageID, string reply)   //��ӹ���Ա�ظ�
        {
            sqlString = "update Messages set reply = '" + reply + "' where messageID = " + messageID;

            try
            {
                using (dp = new DataProvider())
                {
                    if (dp.ExecuteNonQuery(sqlString) == 0)
                        return false;
                }
            }
            catch
            {

            }

            return true;
        }

        #endregion

        #region ɾ������

        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="messageID">����ID</param>     
        /// <returns>bool</returns>

        public bool DeleteMessage(int messageID)    //ɾ������
        {
            sqlString = "delete from Messages where messageID = " + messageID;

            try
            {
                using (dp = new DataProvider())
                {
                    if (dp.ExecuteNonQuery(sqlString) == 0)
                        return false;
                }
            }
            catch
            {

            }

            return true;
        }

        #endregion
    }
}
