////编写者：陈亚星
////日  期：2009-12-09
////功  能：订单生成模块的数据库处理
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
        private DataProvider dp;

        #region 构造用户实体
        /// <summary>
        /// 构造用户实体
        /// </summary>
        /// <param name="info">新用户实体对象</param>
        /// <returns>bool值</returns>
        public bool SetUserInfo(ref UserInfo info)
        {
            DataTable dt = new DataTable();
            sqlString = "select * from userInfo where userID=@userID";
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

            info.UserRealName = dt.Rows[0][1].ToString();
            info.PostAdd = dt.Rows[0][2].ToString();
            info.PostNum = dt.Rows[0][3].ToString();
            info.PhoneNum = dt.Rows[0][4].ToString();

            return true;
        }
        #endregion

        #region 修改新信息
        /// <summary>
        /// 修改数据库中用户信息
        /// </summary>
        /// <param name="info">新用户实体对象</param>
        /// <returns>bool值</returns>
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

        #region 插入新订单
        /// <summary>
        /// 向数据库插入新订单
        /// </summary>
        /// <param name="info">新订单实体对象</param>
        /// <returns>bool值</returns>
        public bool InsertNewOrder(OrderInfo info)
        {
            SqlParameter[] pt;
            //DataTable dt = new DataTable();
            //============================================插入主订单数据===================================//
            if (info.InvoiceHead != null && info.InvoiceHead.Length > 0 && info.InvoiceContent != null && info.InvoiceContent.Length > 0)
            {
                sqlString = "insert into mainOrderInfo (userId, postAdd, postNum, userRealName, phoneNum, province, invoiceHead, invoiceContent, orderTime, orderPrice, orderState) values (@id,@add,@zip,@name,@tel,@prov,@head,@content,@time,@price,0)";
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
            }
            else 
            {
                sqlString = "insert into mainOrderInfo (userId, postAdd, postNum, userRealName, phoneNum, province, orderTime, orderPrice, orderState) values (@id,@add,@zip,@name,@tel,@prov,@time,@price,0)";
                pt = new SqlParameter[] { 
                                new SqlParameter("@id",SqlDbType.UniqueIdentifier),
                                new SqlParameter("@add",SqlDbType.VarChar),
                                new SqlParameter("@zip",SqlDbType.VarChar),
                                new SqlParameter("@name",SqlDbType.VarChar),
                                new SqlParameter("@tel",SqlDbType.VarChar),
                                new SqlParameter("@prov",SqlDbType.VarChar),
                                new SqlParameter("@time",SqlDbType.DateTime),
                                new SqlParameter("@price",SqlDbType.Money),
                                };
                pt[0].Value = info.UserID;
                pt[1].Value = info.UserAdd;
                pt[2].Value = info.UserZip;
                pt[3].Value = info.UserRealName;
                pt[4].Value = info.UserTel;
                pt[5].Value = info.UserProvince;
                pt[6].Value = DateTime.Now;
                pt[7].Value = info.UserOrderPrice;
            }
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

            //================================获取主订单号=================================//
            sqlString = "select * from mainOrderInfo where userID=@id order by orderTime desc";

            SqlParameter[] pt2 = new SqlParameter[] { 
                                new SqlParameter("@id",SqlDbType.UniqueIdentifier)
                                };
            pt2[0].Value = info.UserID;
            DataTable dt = new DataTable();

            try
            {
                using (dp = new DataProvider())
                {
                    if ((dt = dp.ExecuteDataTable(sqlString, pt2)) == null)
                        return false;
                }
            }
            catch
            {
                return false;
            }

            int orderID = Convert.ToInt32(dt.Rows[0][0].ToString());
             
            //===============================================插入订单商品信息=========================================//

            sqlString = "insert into subOrderInfo(mainOrderID, goodsID, goodsName, goodsPrice, goodsNum) values(@mainID,@gID,@name,@price,@num)";

            foreach (ItemEntity ie in info.UserOrderItems) 
            {
                SqlParameter[] pt3 = new SqlParameter[] { 
                                new SqlParameter("@mainID",SqlDbType.Int),
                                new SqlParameter("@gID",SqlDbType.Int),
                                new SqlParameter("@name",SqlDbType.VarChar),
                                new SqlParameter("@price",SqlDbType.Money),
                                new SqlParameter("@num",SqlDbType.Int)
                                };
                pt3[0].Value = orderID;
                pt3[1].Value = ie.ID;
                pt3[2].Value = ie.Name;
                pt3[3].Value = ie.Price;
                pt3[4].Value = ie.Number;

                try
                {
                    using (dp = new DataProvider())
                    {
                        if (dp.ExecuteNonQuery(sqlString, pt3) == 0)
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
    }
}
