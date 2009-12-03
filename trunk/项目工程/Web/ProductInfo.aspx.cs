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

public partial class ProductInfo : System.Web.UI.Page
{
    int proId;
    Cart shopCart;
    //string CookieName = "ShopCart";

    protected void Page_Load(object sender, EventArgs e)
    {
        proId = Convert.ToInt32(Request.QueryString["ID"]);
    }

    #region 加入购物车
    protected void addToCart_Click(object sender, EventArgs e)
    {
        #region 构造购物车
        shopCart = new Cart();
        #endregion

        #region 加入购物车
        shopCart.Add(proId);
        #endregion
    }
    #endregion

    protected void showCart_Click(object sender, EventArgs e)
    {
        Response.Redirect("CartView.aspx");
    }
}
