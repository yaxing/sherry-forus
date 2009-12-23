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

using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Text;
using BLL;
using DAL;
using Entity;

public partial class Details : System.Web.UI.Page
{
    int goodsID;
    CartCtrl shopCart;
    //string CookieName = "ShopCart";

    protected void Page_Load(object sender, EventArgs e)
    {
        GoodsInfo goodsInfo = new GoodsInfo();
        try
        {
            goodsID = Convert.ToInt32(Request.QueryString["GoodsID"]);
            goodsInfo = GoodsInfoBLL.GoodsDetail(goodsID);
        }
        catch
        {
            Response.Redirect("Index.aspx");
        }
        GoodsImg.ImageUrl = goodsInfo.goodsImg;
        GoodsName.Text = goodsInfo.goodsName;
        GoodsPrice.Text = goodsInfo.goodsPrice.ToString();
        GoodsDescribe.Text = goodsInfo.goodsDescribe;

        SameCategory.DataSource = GoodsInfoBLL.FindGoods(goodsInfo.goodsCategory);
        SameCategory.DataBind();
    }

    #region 加入购物车
    protected void addToCart_Click(object sender, EventArgs e)
    {
        shopCart = new CartCtrl();

        shopCart.Add(goodsID);
        Response.Redirect("Details.aspx?GoodsID=" + goodsID);
    }
    #endregion
}
