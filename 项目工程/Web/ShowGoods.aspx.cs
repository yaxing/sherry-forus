using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using BLL;
using Entity;

public partial class Goods_ShowGoods : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int goodsID = Convert.ToInt32(Request.QueryString["goodsID"]);
        GoodsInfo goodsInfo = GoodsInfoBLL.GoodsDetail(goodsID);
        GoodsName.Text = goodsInfo.goodsName;
        GoodsNum.Text = goodsInfo.goodsNum;
        GoodsCategory.SelectedValue = goodsInfo.goodsCategory.ToString();
        GoodsAddTime.Text = goodsInfo.goodsAddTime.ToString();
        GoodsPrice.Text = goodsInfo.goodsPrice.ToString();
        GoodsStorage.Text = goodsInfo.goodsStorage.ToString();
        GoodsAvailable.SelectedValue = goodsInfo.goodsAvailable.ToString();
        GoodsDescribe.Text = goodsInfo.goodsDescribe;
    }
}
