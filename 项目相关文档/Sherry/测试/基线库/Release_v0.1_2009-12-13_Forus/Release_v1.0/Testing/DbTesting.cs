////��д�ߣ�������
////��  �ڣ�2009-12-16
////��  �ܣ����������ݿ������Բ�����
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using DbCtrl;
using DAL;
using BLL;
using Entity;
using InterFace;

namespace Testing
{
    public class DbTesting
    {
        private string sqlString = string.Empty;
        private DataProvider dp;

        #region adminInfo����Է���

        #region ������û�

        /// <summary>
        /// ��ӹ���Ա
        /// </summary>
        /// <param name="newadmin">���û�ʵ�����</param>
        /// <returns>boolֵ</returns>

        public bool AddAdmin(AdminInfo newadmin)
        {
            sqlString = "Insert Into adminInfo (adminID,adminRealName,emailAdd,phoneNum,adminLv)"
                        + " Values (@adminID,@adminRealName,@emailAdd,@phoneNum,@adminLv)";

            SqlParameter[] pt = new SqlParameter[] { 
                                new SqlParameter("@adminID", SqlDbType.UniqueIdentifier),
                                new SqlParameter("@adminRealName",SqlDbType.VarChar),
                                new SqlParameter("@emailAdd",SqlDbType.VarChar),
                                new SqlParameter("@phoneNum",SqlDbType.VarChar),
                                new SqlParameter("@adminLv",SqlDbType.Int)
                                };
            pt[0].Value = newadmin.AdminID;
            pt[1].Value = newadmin.AdminRealName;
            pt[2].Value = newadmin.AdminEmailAdd;
            pt[3].Value = newadmin.AdminPhoneNum;
            pt[4].Value = newadmin.AdminLv;

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

        #region �޸Ĺ���Ա��Ϣ

        /// <summary>
        /// �޸Ĺ���Ա��Ϣ
        /// </summary>
        /// <param name="admin">ʵ�����</param>
        /// <returns>boolֵ</returns>

        public bool ModiAdminInfo(AdminInfo admin)
        {
            string sqlString = "Update adminInfo Set adminRealName = @adminRealName , emailAdd = @emailAdd , phoneNum = @phoneNum , adminLv = @adminLv "
                                  + "where adminID = @adminID";
            SqlParameter[] pt = new SqlParameter[] { 
                                new SqlParameter("@adminRealName",SqlDbType.VarChar),
                                new SqlParameter("@emailAdd",SqlDbType.VarChar),
                                new SqlParameter("@phoneNum",SqlDbType.VarChar),
                                new SqlParameter("@adminLv",SqlDbType.Int),
                                new SqlParameter("@adminID", SqlDbType.UniqueIdentifier)
                                };
            pt[4].Value = admin.AdminID;
            pt[0].Value = admin.AdminRealName;
            pt[1].Value = admin.AdminEmailAdd;
            pt[2].Value = admin.AdminPhoneNum;
            pt[3].Value = admin.AdminLv;

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

        #region ������Ա�û�����ѯ����Ա��Ϣ

        /// <summary>
        /// ��ѯ����Ա��Ϣ
        /// </summary>
        /// <param name="adminName">����Ա�û���</param>
        /// <param name="adminInfo">ʵ�����</param>
        /// <returns>bool</returns>

        public bool SrchAdminInfoByUserName(ref AdminInfo adminInfo, string adminName)
        {
            //MembershipUser admin = Membership.GetUser(adminName);
            //adminInfo.AdminID = (Guid)admin.ProviderUserKey;
            //AdminInfoDAL adminDAL = new AdminInfoDAL();
            //return adminDAL.SrchAdminInfo(ref adminInfo);
            return true;
        }

        #endregion

        #endregion

        #region mainOrderInfo&subOrderInfo����Է���

        #region �����¶���
        /// <summary>
        /// �����ݿ�����¶���
        /// </summary>
        /// <param name="info">�¶���ʵ�����</param>
        /// <returns>boolֵ</returns>
        public bool InsertNewOrder(OrderInfo info)
        {
            SqlParameter[] pt;
            //DataTable dt = new DataTable();
            //============================================��������������===================================//
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

            //================================��ȡ��������=================================//
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

            //===============================================���붩����Ʒ��Ϣ=========================================//

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

        #region ���û�ID��ѯ����
        /// <summary>
        /// �����û�ID�õ����ж���
        /// </summary>
        /// <param name="userID",name="orders">�û�ID,����list</param>
        /// <returns>�����б�</returns>
        public bool ChangeOrderState(ref List<OrderInfo> orders, Guid userID)
        {
            SqlParameter[] sq;
            DataTable dt = null;
            sqlString = "select m.*, s.*, g.goodsImg from mainOrderInfo as m, subOrderInfo as s, goodInfo as g where m.userID=@userID and m.mainOrderID=s.mainOrderID and g.goodsID=s.goodsID";
            sq = new SqlParameter[] { 
                                new SqlParameter("@userID",SqlDbType.UniqueIdentifier)
                                };
            sq[0].Value = userID;

            try
            {
                using (dp = new DataProvider())
                {
                    if ((dt = dp.ExecuteDataTable(sqlString, sq)) == null)
                    {
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                return false;
            }

            int i = 0;
            int orderID = -1;
            OrderInfo order = null;

            //����datatable���충���б�
            for (i = 0; i < dt.Rows.Count; i++)
            {
                int curOrderID = Convert.ToInt32(dt.Rows[i][0].ToString());
                if (curOrderID != orderID)
                {
                    orders.Add(order);
                    orderID = curOrderID;
                    order = new OrderInfo();
                    order.UserRealName = dt.Rows[i][4].ToString();
                    order.UserAdd = dt.Rows[i][2].ToString();
                    order.UserZip = dt.Rows[i][3].ToString();
                    order.UserTel = dt.Rows[i][5].ToString();
                    order.UserProvince = dt.Rows[i][6].ToString();
                    order.UserOrderPrice = Convert.ToDouble(dt.Rows[i][10].ToString());
                    order.State = Convert.ToInt32(dt.Rows[i][11].ToString());
                    order.InvoiceHead = dt.Rows[i][7].ToString();
                    order.InvoiceContent = dt.Rows[i][8].ToString();
                    order.OrderTime = dt.Rows[i][9].ToString();
                    order.UserOrderItems = new List<ItemEntity>();
                }
                ItemEntity ie = new ItemEntity(Convert.ToInt32(dt.Rows[i][14].ToString()), dt.Rows[i][15].ToString(), Convert.ToInt32(dt.Rows[i][16].ToString())
                                               , Convert.ToDouble(dt.Rows[i][17].ToString()), dt.Rows[i][18].ToString());
                order.UserOrderItems.Add(ie);
            }

            return true;
        }
        #endregion

        #endregion
    }
}
