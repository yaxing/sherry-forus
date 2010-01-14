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
        int shortDescribeLength = 20;
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
        if (goodsInfo.goodsDescribe.Length <= shortDescribeLength)
        {
            ShortGoodsDescribe.Text = goodsInfo.goodsDescribe;
        }
        else
        {
            ShortGoodsDescribe.Text = goodsInfo.goodsDescribe.Substring(0, shortDescribeLength) + "...";
        }
        GoodsDescribe.Text = goodsInfo.goodsDescribe;

        if (goodsInfo.goodsSpecialOffer == 0 && User.Identity.Name.ToString().Length == 0)
        {
            Discount.Text = "9.5折";
        }
        else
        {
            Discount.Text = "9.0折";
        }

        Storage.Text = goodsInfo.goodsStorage.ToString();
        SameCategory.DataSource = GoodsInfoBLL.FindGoodsByCategory(goodsInfo.goodsCategory);
        SameCategory.DataBind();
    }

    #region 加入购物车
    protected void addToCart_Click(object sender, EventArgs e)
    {
        shopCart = new CartCtrl();

        if (!shopCart.Add(goodsID))
        {
            Response.Write("<script>alert('添加商品失败，请重新操作！');history.go(-1);</script>");
        }
        else
        {
            Response.Write("<script>alert('商品已成功加入购物车！');location.href('Details.aspx?GoodsID="+goodsID+"');</script>");
            //Response.Redirect("Details.aspx?GoodsID=" + goodsID);
        }
    }
    #endregion
}
