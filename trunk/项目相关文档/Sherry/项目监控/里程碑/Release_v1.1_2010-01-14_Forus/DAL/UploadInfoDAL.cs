using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DbCtrl;
using Entity;

namespace DAL
{
    public class UploadInfoDAL  //上传表DAL
    {
        private string sqlString;
        private DataProvider dp = new DataProvider();

        #region 主表操作

        #region 添加上传表主表

        /// <summary>
        /// 添加上传表主表
        /// </summary>
        /// <param name="mainUpload">上传表主表实体对象</param>
        /// <returns>ID值</returns>

        public int AddMainUpload(MainUpload mainUpload)
        {
            sqlString = "Insert Into MainUpload (sellTime,totalValue,gender,age,shopID,province) Values (@sellTime,@totalValue,@gender,@age,@shopID,@province)";

            SqlParameter[] pt = new SqlParameter[] { 
                                new SqlParameter("@sellTime", SqlDbType.DateTime),
                                new SqlParameter("@totalValue", SqlDbType.Int),
                                new SqlParameter("@gender", SqlDbType.VarChar),
                                new SqlParameter("@age", SqlDbType.Int),
                                new SqlParameter("@shopID", SqlDbType.Int),
                                new SqlParameter("@province", SqlDbType.VarChar),
                                };
            pt[0].Value = mainUpload.SellTime;
            pt[1].Value = mainUpload.TotalValue;
            pt[2].Value = mainUpload.Gender;
            pt[3].Value = mainUpload.Age;
            pt[4].Value = mainUpload.ShopID;
            pt[5].Value = mainUpload.Province;

            try
            {
                using (dp = new DataProvider())
                {
                    mainUpload.MainUploadID= dp.ExecuteInsert(sqlString, pt);
                    if (mainUpload.MainUploadID == 0)
                        return -1;
                }
            }
            catch(Exception e)
            {
                return -1;
            }

            return mainUpload.MainUploadID;
        }
        #endregion

        #endregion

        #region 分表操作

        #region 添加上传表表副表

        /// <summary>
        /// 添加上传表表副表
        /// </summary>
        /// <param name="newSubUpload">上传表副表实体对象</param>
        /// <returns>bool值</returns>

        public bool AddSubUpload(SubUpload newSubUpload)
        {

            sqlString = "Insert Into SubUpload (mainUploadID,goodsID,goodsName,number,price,totalValue) Values (@mainUploadID,@goodsID,@goodsName,@number,@price,@totalValue)";

            SqlParameter[] pt = new SqlParameter[] { 
                                new SqlParameter("@mainUploadID", SqlDbType.Int),
                                new SqlParameter("@goodsID", SqlDbType.Int),
                                new SqlParameter("@goodsName", SqlDbType.VarChar),
                                new SqlParameter("@number", SqlDbType.Int),
                                new SqlParameter("@price", SqlDbType.Float),
                                new SqlParameter("@totalValue", SqlDbType.Float),
                                };
            pt[0].Value = newSubUpload.MainUploadID;
            pt[1].Value = newSubUpload.GoodsID;
            pt[2].Value = newSubUpload.GoodsName;
            pt[3].Value = newSubUpload.Number;
            pt[4].Value = newSubUpload.Price;
            pt[5].Value = newSubUpload.TotalValue;

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

        #endregion

    }
}
