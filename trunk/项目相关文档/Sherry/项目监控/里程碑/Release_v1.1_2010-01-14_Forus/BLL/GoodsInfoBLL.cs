using System;
using System.Collections.Generic;
using System.Web.Security;
using System.Data;
using System.Data.SqlClient;
using DAL;
using Entity;

namespace BLL
{
    public static class GoodsInfoBLL
    {
        #region 添加产品

        /// <summary>
        /// 添加产品
        /// </summary>
        /// <param name="newGoods">新产品实体对象</param>
        /// <returns>bool值</returns>

        public static bool AddGoods(GoodsInfo newGoods)
        {
            return (GoodsInfoDAL.AddGoods(newGoods));
        }
        #endregion

        #region 删除产品

        /// <summary>
        /// 删除产品
        /// </summary>
        /// <param name="goodsID">产品索引值</param>
        /// <returns>bool值</returns>

        public static bool DeleteGoods(int goodsID)
        {
            //还缺有未处理订单不能删除的逻辑
            return (GoodsInfoDAL.DeleteGoods(goodsID));
        }
        #endregion

        #region 查找产品

        /// <summary>
        /// 查找产品
        /// </summary>
        /// <param name="goodsName">产品名称</param>
        /// <param name="goodsNUM">产品编号</param>
        /// <param name="goodsCategory">产品类别</param>
        /// <param name="timeFrom">从此时间开始查找产品</param>
        /// <param name="timeFrom">以此时间结束查找产品</param>
        /// <returns>DataTable型的查找结果</returns>

        public static DataTable FindGoods(int goodsCategory)
        {
            return (FindGoods("", "", goodsCategory, DateTime.MinValue, DateTime.MaxValue));
        }

        public static DataTable FindGoods(string goodsName)
        {
            return (FindGoods(goodsName, "", 0, DateTime.MinValue, DateTime.MaxValue));
        }

        public static DataTable FindGoods(string goodsName, string goodsNUM, int goodsCategory, DateTime timeFrom, DateTime timeTo)
        {
            return (GoodsInfoDAL.FindGoods(goodsName, goodsNUM, goodsCategory, timeFrom, timeTo));
        }
        #endregion

        #region 显示产品详细信息

        /// <summary>
        /// 显示产品详细信息
        /// </summary>
        /// <param name="goodsID">产品索引值</param>
        /// <returns>GoodsInfo型的产品信息</returns>

        public static GoodsInfo GoodsDetail(int goodsID)
        {
            return (GoodsInfoDAL.GoodsDetail(goodsID));
        }
        #endregion

        #region 修改产品

        /// <summary>
        /// 修改产品
        /// </summary>
        /// <param name="goodsID">产品索引值</param>
        /// <param name="goodsInfo">产品信息</param>
        /// <returns>bool值</returns>

        public static bool ChangeGoods(int goodsID, GoodsInfo goodsInfo)
        {
            return (GoodsInfoDAL.ChangeGoods(goodsID, goodsInfo));
        }
        #endregion

        #region 修改产品状态

        /// <summary>
        /// 修改产品状态
        /// </summary
        /// <param name="goodsID">产品索引值</param>
        /// <param name="goodsAvailable">产品上下架状态</param>
        /// <param name="goodsStorage">产品库存</param>
        /// <returns>bool值</returns>

        public static bool ChangeGoodsStat(int goodsID, bool goodsAvailable, int goodsStorage)
        {
            return (GoodsInfoDAL.ChangeGoodsStat(goodsID, goodsAvailable, goodsStorage));
        }
        #endregion       

        #region 查找所有的特价产品

        /// <summary>
        /// 查找所有的特价产品
        /// </summary>
        /// <returns>DataTable型的查找结果</returns>

        public static DataTable FindSpecialGoods()
        {
            return (GoodsInfoDAL.FindSpecialGoods());
        }
        #endregion

        #region 查找最近添加的（num个）产品

        /// <summary>
        /// 查找最近添加的（num个）产品
        /// </summary>
        /// <param name="num">产品个数</param>
        /// <param name="orderByVolume">是否按照销量排序</param>
        /// <returns>DataTable型的查找结果</returns>

        public static DataTable LatestGoods(int num)
        {
            return (GoodsInfoDAL.LatestGoods(num, false));
        }

        public static DataTable LatestGoods(int num, bool orderByVolume)
        {
            return (GoodsInfoDAL.LatestGoods(num, orderByVolume));
        }
        #endregion

        #region 获取分类列表

        /// <summary>
        /// 获取分类列表
        /// </summary>
        /// <param name="category">商品分类datatable</param>
        /// <returns>bool值</returns>

        public static bool GetCategory(ref DataTable category)
        {
            return (GoodsInfoDAL.GetCategory(ref category));
        }
        #endregion
    }
}
