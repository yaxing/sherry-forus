////编写者：李开林
////日  期：2009-11-18
////功  能：数据库操作驱动程序

using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Caching;
using System.Xml;

namespace DbCtrl
{
    public class DataProvider : IDisposable
    {
        private SqlConnection conn;

        #region

        /// <summary>
        /// 获取数据库连接字符串
        /// </summary>
        /// <returns></returns>

        public string GetConnectionString()
        {
            string connectionString = null;
            string xmlFile = System.Web.HttpContext.Current.Server.MapPath("~/web.config");
            XmlDocument xml = new XmlDocument();
            xml.Load(xmlFile);

            foreach (XmlNode Node in xml["configuration"]["connectionStrings"])
            {
                if (Node.Name == "add")
                {
                    if (Node.Attributes.GetNamedItem("name").Value == "SherryDBConnection")
                    {
                        connectionString = Node.Attributes.GetNamedItem("connectionString").Value;
                        
                    }
                }
            } 

            return connectionString;
        }
        #endregion

        #region 构造函数

        /// <summary>
        /// 构造DataProvider,并打开数据库连接
        /// </summary>

        public DataProvider()
        {
            try
            {
                string connString = GetConnectionString();
                conn = new SqlConnection(connString);
                conn.Open();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        #endregion

        #region 析构函数

        /// <summary>
        /// 释放对象，并关闭数据库连接
        /// </summary>

        public void Dispose()
        {
            try
            {
                conn.Close();
            }
            catch(Exception exception)
            {
                throw exception;
            }
        }
        #endregion

        #region 不带参数查询数据库

        /// <summary>
        /// 查询数据库并返回结果集
        /// </summary>
        /// <param name="sqlString">sql语句</param>
        /// <returns>查询结果的DataTable集合</returns>

        public DataTable ExecuteQuery(string sqlString)
        {
            DataTable dataTable = new DataTable();
            using (SqlDataAdapter adapter = new SqlDataAdapter(sqlString , conn))
            {
                adapter.Fill(dataTable);
            }
            return dataTable;
        }
        #endregion

        #region 带参数查询数据库

        /// <summary>
        /// 查询数据库并返回结果集
        /// </summary>
        /// <param name="sqlString">sql语句</param>
        /// <param name="pt">参数集合</param>
        /// <returns>查询结果的DataTalbe集合</returns>

        public DataTable ExecuteDataTable(string sqlString , SqlParameter[] pt)
        {
            DataTable dataTable = new DataTable();
            using (SqlDataAdapter adapter = new SqlDataAdapter(sqlString , conn))
            {
                foreach (SqlParameter parameter in pt)
                {
                    adapter.SelectCommand.Parameters.Add(parameter);
                }
                adapter.Fill(dataTable);
            }
            return dataTable;
        }
        #endregion

        #region 执行不带参数数据库操作

        /// <summary>
        /// 执行数据库操作并返回影响行数
        /// </summary>
        /// <param name="sqlString">sql语句</param>
        /// <returns>受影响行数</returns>

        public int ExecuteNonQuery(string sqlString)
        {
            using (SqlCommand command = new SqlCommand(sqlString , conn))
            {
                return command.ExecuteNonQuery();
            }
        }
        #endregion

        #region 执行带参数的数据库操作

        /// <summary>
        /// 执行数据库操作并返回影响行数
        /// </summary>
        /// <param name="sqlString">sql语句</param>
        /// <param name="pt">参数集合</param>
        /// <returns>受影响行数</returns>

        public int ExecuteNonQuery(string sqlString , SqlParameter[] pt)
        {
            using (SqlCommand command = new SqlCommand(sqlString , conn))
            {
                foreach (SqlParameter parameter in pt)
                {
                    command.Parameters.Add(parameter);
                }
                return command.ExecuteNonQuery();
            }
        }
        #endregion

        #region 不带参数的数据流读取

        /// <summary>
        /// 利用数据流读取数据
        /// </summary>
        /// <param name="sqlString">sql语句</param>
        /// <returns>数据流读取器</returns>

        public SqlDataReader ExecuteReader(string sqlString)
        {
            using (SqlCommand command = new SqlCommand(sqlString , conn))
            {
                return command.ExecuteReader();
            }
        }
        #endregion

        #region 带参数的数据流读取

        /// <summary>
        /// 利用数据流读取数据
        /// </summary>
        /// <param name="sqlString">sql语句</param>
        /// <param name="pt">参数集合</param>
        /// <returns>数据流读取器</returns>

        public SqlDataReader ExecuteReader(string sqlString , SqlParameter[] pt)
        {
            using (SqlCommand command = new SqlCommand(sqlString , conn))
            {
                foreach (SqlParameter parameter in pt)
                {
                    command.Parameters.Add(parameter);
                }
                return command.ExecuteReader();
            }
        }
        #endregion
    }
}
