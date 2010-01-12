////编写者：陈亚星
////日  期：2009-12-18
////功  能：母版页的逻辑处理
using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using DAL;
using Entity;

namespace BLL
{
    public class MasterPageBLL
    {
        MasterPageDAL mpData;

        #region 获取特价商品列表
        /// <summary>
        /// 获取特价商品列表
        /// </summary>
        /// <param name="itemList">空列表IList</param>
        /// <returns>bool值</returns>
        public bool GetSpecialOffers(ref IList<ItemEntity> itemList) 
        {
            mpData = new MasterPageDAL();
            if (!mpData.GetItemList(ref itemList)) 
            {
                return false;
            }
            return true;
        }
        #endregion

        #region 获取商品分类列表
        /// <summary>
        /// 获取商品分类列表
        /// </summary>
        /// <param name="itemList">空列表IList</param>
        /// <returns>bool值</returns>
        public bool GetCategoryList(ref IList<ItemEntity> categoryList)
        {
            mpData = new MasterPageDAL();
            if (!mpData.GetCategoryList(ref categoryList))
            {
                return false;
            }
            return true;
        }
        #endregion
    }
}
