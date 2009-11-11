using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DbConnect
{
    public class DbConnector
    {
        SqlConnection sqlConnection;
        SqlCommand commend;
        DataSet ds;

        ////数据库链接函数，server为地址
        public void connDB(string server, string userName, string passWord)
        {
            sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString =
            "Server=" + server + ";Database=shanzhai;User ID=" + userName + ";Password=" + passWord
            + ";Trusted_Connection=False";
            sqlConnection.Open();
        }

        //数据库链接函数，直接传入链接字符串
        public void connDB(String strConn)
        {
            try
            {
                sqlConnection = new SqlConnection(strConn);
                sqlConnection.Open();
            }
            catch (Exception ee)
            {
            }
        }
        //查询函数，传入查询语句，返回结果集
        public DataSet executeQuery(String sql)
        {
            try
            {
                commend = new SqlCommand(sql, sqlConnection);
                SqlDataAdapter MyDataAdapter = new SqlDataAdapter(commend);
                ds = new DataSet();
                MyDataAdapter.Fill(ds);
            }
            catch (Exception ee)
            {
                ds = null;
            }
            return ds;
        }

        //更新函数，传入更新、插入、删除语句，返回影响行数
        public int executeUpdate(String sql)
        {
            int result;
            try
            {
                commend = new SqlCommand(sql, sqlConnection);
                result = commend.ExecuteNonQuery();
            }
            catch (Exception ee)
            {
                result = 0;
            }
            return result;
        }

        //插入函数，返回本条插入的ID
        public int executeUpdate_id(String sql)
        {
            int result;
            try
            {
                commend = new SqlCommand(sql, sqlConnection);
                result = commend.ExecuteNonQuery();
                String ID = "select @@IDENTITY as id";
                SqlDataAdapter MyDataAdapter = new SqlDataAdapter(ID, commend.Connection);
                ds = new DataSet();
                MyDataAdapter.Fill(ds);
                if (ds != null && ds.Tables.Count != 0)
                {
                    int autoID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
                    result = autoID;
                }
            }
            catch (Exception ee)
            {
                result = 0;
            }
            return result;
        }

        //关闭连接
        public void close()
        {
            try
            {
                sqlConnection.Close();
            }
            catch (Exception ee)
            {
            }
        }
    }

}
