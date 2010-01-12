////编写者：陈亚星
////日  期：2009-12-05
////功  能：购物车模块的数据库处理
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DbCtrl;
using Entity;
using System.Web;
using System.Web.Security;
using System.Web.UI;

namespace DAL
{
    public class ShopCartInfoDAL
    {
        private static string sqlString = string.Empty;
        private static DataProvider dp;

        #region 构造商品实体
        /// <summary>
        /// 添构造商品实体
        /// </summary>
        /// <param name="info">新商品实体对象</param>
        /// <returns>bool值</returns>
        public bool SetItemEntity(ref ItemEntity info) 
        {
            //=====================================获取商品基本信息==================================//
            DataTable dt = new DataTable();
            sqlString = "select goodsName, goodsPrice, goodsImg from goodsInfo where goodsID=" + info.ID;
            //SqlParameter sp = new SqlParameter("@id", SqlDbType.Int);
            //sp.Value = info.ID;

            try
            {
                using (dp = new DataProvider())
                {
                    if ((dt=dp.ExecuteQuery(sqlString))==null||dt.Rows.Count<=0)
                        return false;
                }
            }
            catch
            {
                return false;
            }

            info.Name = dt.Rows[0]["goodsName"].ToString();
            info.Number = 1;
            info.Price = Convert.ToDouble(dt.Rows[0]["goodsPrice"].ToString());
            info.ImgPath = dt.Rows[0]["goodsImg"].ToString();

            //===================================根据用户等级判断优惠价格========================//
            MembershipUser curUser =  Membership.GetUser(HttpContext.Current.User.Identity.Name);
            if (curUser == null) 
            {
                info.Discount = 0.95;
                return true;
            }
            Guid userId = (Guid)curUser.ProviderUserKey;
            int userLv = 0;
            UserScoreDAL getLv = new UserScoreDAL();
            getLv.GetUserLv(userId,ref userLv);
            if (userLv == 0)
            {
                info.Discount = 0.95;
            }
            else if (userLv == 1)
            {
                info.Discount = 0.9;
            }
            else 
            {
                info.Discount = 1;
            }
            return true;
        }
        #endregion

        #region 查询商品库存
        public static bool GetStorage(ref int storage, int id) 
        {
            DataTable dt = new DataTable();
            sqlString = "select goodsStorage from goodsInfo where goodsID=" + id;
            try
            {
                using (dp = new DataProvider())
                {
                    if ((dt = dp.ExecuteQuery(sqlString)) == null)
                    {
                        return false;
                    }
                }
            }
            catch (Exception e) 
            {
                return false;
            }
            storage = Convert.ToInt32(dt.Rows[0]["goodsStorage"].ToString());
            return true;
        }
        #endregion
    }
}
