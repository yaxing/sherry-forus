////��д�ߣ�������
////��  �ڣ�2009-12-09
////��  �ܣ���������ģ������ݿ⴦��
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DbCtrl;
using Entity;

namespace DAL
{
    public class CheckoutInfoDAL
    {
        private string sqlString = string.Empty;
        private string sqlStringGetStorage = string.Empty;
        private string sqlStringChangeStorage = string.Empty;
        private DataProvider dp;

        #region �����û�ʵ��
        /// <summary>
        /// �����û�ʵ��
        /// </summary>
        /// <param name="info">���û�ʵ�����</param>
        /// <returns>boolֵ</returns>
        public bool SetUserInfo(ref UserInfo info)
        {
            DataTable dt = new DataTable();
            sqlString = "select userRealName, postAdd, postNum, phoneNum from userInfo where userID=@userID";
            SqlParameter[] pt = new SqlParameter[] { 
                                new SqlParameter("@userID", SqlDbType.UniqueIdentifier)
                                };
            pt[0].Value = info.UserID;

            try
            {
                using (dp = new DataProvider())
                {
                    if ((dt = dp.ExecuteDataTable(sqlString,pt)) == null)
                        return false;
                }
            }
            catch
            {
                return false;
            }

            info.UserRealName = dt.Rows[0][0].ToString();
            info.PostAdd = dt.Rows[0][1].ToString();
            info.PostNum = dt.Rows[0][2].ToString();
            info.PhoneNum = dt.Rows[0][3].ToString();

            return true;
        }
        #endregion

        #region �޸�����Ϣ
        /// <summary>
        /// �޸����ݿ����û���Ϣ
        /// </summary>
        /// <param name="info">���û�ʵ�����</param>
        /// <returns>boolֵ</returns>
        public bool ChangeUserInfo(UserInfo info) 
        {
            DataTable dt = new DataTable();
            sqlString = "update userInfo set userRealName=@userName, postAdd=@userAdd, postNum=@userZip, phoneNum=@userTel where userID=@userId";
            SqlParameter[] pt = new SqlParameter[] { 
                                new SqlParameter("@userID",SqlDbType.UniqueIdentifier),
                                new SqlParameter("@userName",SqlDbType.VarChar),
                                new SqlParameter("@userAdd",SqlDbType.VarChar),
                                new SqlParameter("@userZip",SqlDbType.VarChar),
                                new SqlParameter("@userTel",SqlDbType.VarChar)
                                //new SqlParameter("@userProvince",SqlDbType.VarChar)
                                };
            pt[0].Value = info.UserID;
            pt[1].Value = info.UserRealName;
            pt[2].Value = info.PostAdd;
            pt[3].Value = info.PostNum;
            pt[4].Value = info.PhoneNum;
            try
            {
                using (dp = new DataProvider())
                {
                    if (dp.ExecuteNonQuery(sqlString, pt) == 0)
                        return false;
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
        #endregion

        #region �����¶���
        /// <summary>
        /// �����ݿ�����¶���
        /// </summary>
        /// <param name="info">�¶���ʵ�����</param>
        /// <returns>boolֵ</returns>
        public bool InsertNewOrder(OrderInfo info, ref int mainOrderID)
        {
            SqlParameter[] pt;
            int orderID;//������
            int goodsStorage;
            DataTable dt = new DataTable();
            //============================================��������������===================================//

            //��Ҫ���뷢Ʊ��Ϣ
            if (info.InvoiceHead != null && info.InvoiceHead.Length > 0 && info.InvoiceContent != null && info.InvoiceContent.Length > 0)
            {
                sqlString = "insert into mainOrderInfo (userId, postAdd, postNum, userRealName, phoneNum, province, invoiceHead, invoiceContent, orderTime, orderPrice, orderState) values (@id,@add,@zip,@name,@tel,@prov,@head,@content,@time,@price,@state)";
                pt = new SqlParameter[] { 
                                new SqlParameter("@id",SqlDbType.UniqueIdentifier),
                                new SqlParameter("@add",SqlDbType.VarChar),
                                new SqlParameter("@zip",SqlDbType.VarChar),
                                new SqlParameter("@name",SqlDbType.VarChar),
                                new SqlParameter("@tel",SqlDbType.VarChar),
                                new SqlParameter("@prov",SqlDbType.VarChar),
                                new SqlParameter("@head",SqlDbType.VarChar),
                                new SqlParameter("@content",SqlDbType.VarChar),
                                new SqlParameter("@time",SqlDbType.DateTime),
                                new SqlParameter("@price",SqlDbType.Money),
                                new SqlParameter("@state",SqlDbType.Int)
                                };
                pt[0].Value = info.UserID;
                pt[1].Value = info.UserAdd;
                pt[2].Value = info.UserZip;
                pt[3].Value = info.UserRealName;
                pt[4].Value = info.UserTel;
                pt[5].Value = info.UserProvince;
                pt[6].Value = info.InvoiceHead;
                pt[7].Value = info.InvoiceContent;
                pt[8].Value = DateTime.Now;
                pt[9].Value = info.UserOrderPrice;
                pt[10].Value = info.State;
            }
            //����Ҫ���뷢Ʊ��Ϣ
            else 
            {
                sqlString = "insert into mainOrderInfo (userId, postAdd, postNum, userRealName, phoneNum, province, orderTime, orderPrice, orderState) values (@id,@add,@zip,@name,@tel,@prov,@time,@price,@state)";
                pt = new SqlParameter[] { 
                                new SqlParameter("@id",SqlDbType.UniqueIdentifier),
                                new SqlParameter("@add",SqlDbType.VarChar),
                                new SqlParameter("@zip",SqlDbType.VarChar),
                                new SqlParameter("@name",SqlDbType.VarChar),
                                new SqlParameter("@tel",SqlDbType.VarChar),
                                new SqlParameter("@prov",SqlDbType.VarChar),
                                new SqlParameter("@time",SqlDbType.DateTime),
                                new SqlParameter("@price",SqlDbType.Money),
                                new SqlParameter("@state",SqlDbType.Int)
                                };
                pt[0].Value = info.UserID;
                pt[1].Value = info.UserAdd;
                pt[2].Value = info.UserZip;
                pt[3].Value = info.UserRealName;
                pt[4].Value = info.UserTel;
                pt[5].Value = info.UserProvince;
                pt[6].Value = DateTime.Now;
                pt[7].Value = info.UserOrderPrice;
                pt[8].Value = info.State;
            }
            try
            {
                using (dp = new DataProvider())
                {
                    if ((orderID = dp.ExecuteInsert(sqlString, pt)) < 0)
                        return false;
                }
            }
            catch
            {
                return false;
            }
            mainOrderID = orderID;
             
            //===============================================���붩����Ʒ��Ϣ=========================================//

            sqlString = "insert into subOrderInfo(mainOrderID, goodsID, goodsName, goodsPrice, goodsNum) values(@mainID,@gID,@name,@price,@num)";
            sqlStringGetStorage = "select goodsStorage from goodsInfo where goodsID=@id";
            sqlStringChangeStorage = "update goodsInfo set goodsStorage=@curS where goodsID=@id";

            foreach (ItemEntity ie in info.UserOrderItems) 
            {
                pt = new SqlParameter[] { 
                                new SqlParameter("@mainID",SqlDbType.Int),
                                new SqlParameter("@gID",SqlDbType.Int),
                                new SqlParameter("@name",SqlDbType.VarChar),
                                new SqlParameter("@price",SqlDbType.Money),
                                new SqlParameter("@num",SqlDbType.Int)
                                };
                pt[0].Value = orderID;
                pt[1].Value = ie.ID;
                pt[2].Value = ie.Name;
                pt[3].Value = ie.Price;
                pt[4].Value = ie.Number;

                try
                {
                    using (dp = new DataProvider())
                    {
                        if (dp.ExecuteNonQuery(sqlString, pt) == 0)
                            return false;
                    }
                }
                catch
                {
                    return false;
                }

                //=========================��ȡ��Ʒ���====================//
                
                pt = new SqlParameter[] { 
                                new SqlParameter("@id",SqlDbType.Int)
                                };
                pt[0].Value = ie.ID;
                try
                {
                    using (dp = new DataProvider())
                    {
                        if ((dt=dp.ExecuteDataTable(sqlStringGetStorage, pt)) == null)
                            return false;
                    }
                }
                catch
                {
                    return false;
                }
                goodsStorage = Convert.ToInt32(dt.Rows[0][0].ToString())-ie.Number;
                
                //======================�޸���Ʒ���========================//

                pt = new SqlParameter[] { 
                                new SqlParameter("@curS",SqlDbType.Int),
                                new SqlParameter("@id",SqlDbType.Int)
                                };
                pt[0].Value = goodsStorage;
                pt[1].Value = ie.ID;
                try
                {
                    using (dp = new DataProvider())
                    {
                        if (dp.ExecuteNonQuery(sqlStringChangeStorage, pt) == 0)
                            return false;
                    }
                }
                catch
                {
                    return false;
                }

            }

            return true;
        }
        #endregion

        #region ����Ϊ���û�
        /// <summary>
        /// ���û�����Ϊ���û�
        /// </summary>
        /// <param name="userId">�û�ID</param>
        /// <returns>boolֵ</returns>
        public bool UpdateToGoldenUser(Guid userId)
        {
            sqlString = "update userInfo set userLv=1 where userID=@userId";
            SqlParameter[] pt = new SqlParameter[] { 
                                new SqlParameter("@userId",SqlDbType.UniqueIdentifier)
                                };
            pt[0].Value = userId;
            try
            {
                using (dp = new DataProvider())
                {
                    if (dp.ExecuteNonQuery(sqlString, pt) == 0)
                        return false;
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
        #endregion

    }
}
