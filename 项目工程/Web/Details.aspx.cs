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
        goodsID = Convert.ToInt32(Request.QueryString["GoodsID"]);
        GoodsInfo goodsInfo = GoodsInfoBLL.GoodsDetail(goodsID);
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
        #region 构造购物车
        shopCart = new CartCtrl();
        #endregion

        #region 加入购物车
        shopCart.Add(goodsID);
        #endregion
        Response.Redirect("Details.aspx?goodsID=" + goodsID);
    }
    #endregion

    protected void showCart_Click(object sender, EventArgs e)
    {
        Response.Redirect("CartView.aspx");
    }
}
