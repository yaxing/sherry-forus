using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DbCtrl;
using Entity;

namespace DAL
{
    public class ClientServiceDAL   //客户服务DAL
    {

        private string sqlString;   //数据库查询字符串
        private DataProvider dp = new DataProvider();   //数据库查询类

        #region 添加新信息

        /// <summary>
        /// 添加新信息
        /// </summary>
        /// <param name="newMessage">信息实体对象</param>
        /// <returns>bool</returns>

        public bool AddNewMessage(Message newMessage)   //添加新留言
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

        #region 查询前N条信息

        /// <summary>
        /// 查询前N条信息
        /// </summary>
        /// <param name="messageList">信息实体对象表</param>
        /// <param name="num">查询的条数</param>
        /// <param name="isReply">是否需要reply</param>
        /// <returns>bool</returns>

        public bool ShowTopN(ref IList<Message> messageList, int num, bool isReply) //查询前N条留言
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

        #region 添加管理员回复

        /// <summary>
        /// 添加管理员回复
        /// </summary>
        /// <param name="message">消息实体</param>
        /// <param name="reply">回复内容</param>
        /// <returns>bool</returns>

        public bool AddReply(int messageID, string reply)   //添加管理员回复
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

        #region 删除留言

        /// <summary>
        /// 删除留言
        /// </summary>
        /// <param name="messageID">留言ID</param>     
        /// <returns>bool</returns>

        public bool DeleteMessage(int messageID)    //删除留言
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
