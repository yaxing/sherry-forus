////编写者：陈亚星
////日  期：2010-01-12
////功  能：后台电话销售订单生成
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using BLL;
using DAL;
using Entity;

public partial class Management_AddOrder : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) 
        {
            DataTable category = new DataTable();
            GoodsInfoBLL.GetCategory(ref category);
            ddlGoodsCategory.DataSource = category;
            ddlGoodsCategory.DataValueField = "ID";
            ddlGoodsCategory.DataTextField = "name";
            ddlGoodsCategory.DataBind();
        }
    }
    #region 更新区域列表
    protected void ddlUserProvince_SelectedIndexChanged(object sender, EventArgs e)
    {
        IList<ShopInfo> shopInfoList = new List<ShopInfo>();
        string province = ddlUserProvince.SelectedItem.Text.ToString();
        ShopInfoBLL updateArea = new ShopInfoBLL();
        if (updateArea.SrchShopByProvince(ref shopInfoList, province) == -1)
        {
            Response.Write("<script>alert('区域数据更新失败，请重新选择！');history.go(-1);</script>");
            return;
        }
        int i = 0;
        ddlUserArea.Items.Clear();
        for (; i < shopInfoList.Count; i++)
        {
            ListItem it = new ListItem(shopInfoList[i].Area.ToString(), shopInfoList[i].ShopID.ToString());
            ddlUserArea.Items.Add(it);
        }
    }
    #endregion

    #region 更新商品列表
    protected void ddlGoodsCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable goods = new DataTable();
        goods = GoodsInfoBLL.FindGoods(Convert.ToInt32(ddlGoodsCategory.SelectedItem.Value));
        ddlGoods.Items.Clear();
        ddlGoods.DataSource = goods;
        ddlGoods.DataTextField = "goodsName";
        ddlGoods.DataValueField = "goodsID";
        ddlGoods.DataBind();
    }
    #endregion
}
