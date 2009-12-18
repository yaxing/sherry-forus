////编写者：陈亚星
////日  期：2009-12-18
////功  能：母版页的数据库处理
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DbCtrl;
using Entity;
namespace DAL
{
    public class MasterPageDAL
    {
        private string sqlString = string.Empty;
        private DataProvider dp;

        public MasterPageDAL() { }

        #region 构造特价商品列表
        /// <summary>
        /// 构造特价商品列表
        /// </summary>
        /// <param name="itemList">空列表IList</param>
        /// <returns>bool值</returns>
        public bool GetItemList(ref IList<ItemEntity> itemList)
        {
            DataTable dt = new DataTable();
            sqlString = "select top 3 * from goodsInfo where goodsSpecialOffer=1 order by goodsValidity";
            //SqlParameter sp = new SqlParameter("@id", SqlDbType.Int);
            //sp.Value = info.ID;

            try
            {
                using (dp = new DataProvider())
                {
                    if ((dt = dp.ExecuteQuery(sqlString)) == null)
                        return false;
                }
            }
            catch
            {
                return false;
            }

            int i = 0;
            ItemEntity ie = null;
            //根据datatable构造特价商品列表
            for (i = 0; i < dt.Rows.Count; i++)
            {
                ie = new ItemEntity(Convert.ToInt32(dt.Rows[i][0].ToString()));
                ie.Name = dt.Rows[i][2].ToString();
                ie.ImgPath = dt.Rows[i][5].ToString();
                itemList.Add(ie);
            }
            return true;
        }
        #endregion
    }
}
