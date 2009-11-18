////编写者：李开林
////日  期：2009-11-18
////功  能：数据库操作驱动程序

using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DbCtrl
{
    public class DataProvider
    {
        private SqlConnection conn;

        #region 构造函数

        /// <summary>
        /// 构造DataProvider,并打开数据库连接
        /// </summary>

        public DataProvider()
        {
            try
            {
                string connString = ConfigurationManager.ConnectionStrings["SherryConnectionString"].ToString();
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
    }
}
