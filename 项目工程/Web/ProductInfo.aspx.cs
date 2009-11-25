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
        bool cartExsisted;
        String cartValue = String.Empty;

        #region 构造或选择购物车
        if (System.Web.HttpContext.Current.Request.Cookies["Cart"] != null)
        {
            cartExsisted = true;
            cartValue = System.Web.HttpContext.Current.Request.Cookies["Cart"].Value;
        }
        else 
        {
            cartExsisted = false;
        }
        shopCart = new Cart(cartExsisted, cartValue);
        #endregion

        #region 加入购物车
        ItemEntity info = new ItemEntity(proId, "纪梵希感光皙颜粉底液",1,300);
        Hashtable curCart = shopCart.Add(info);
        SaveCookie(curCart);

        #endregion
    }
    #endregion

    #region 保存购物车
    private void SaveCookie(Hashtable dic)
    {

        string s = string.Empty;
        ItemEntity Info;
        HttpCookie cookie;
        foreach (ItemEntity item in dic.Values)
        {
            Info = item;
            s += Info.id.ToString() + "|" + Info.name + "|" + Info.number.ToString() +"|"+Info.price.ToString()+ "@";
        }
        if (System.Web.HttpContext.Current.Request.Cookies["Cart"] != null)
        {
            cookie = System.Web.HttpContext.Current.Request.Cookies["Cart"];
        }
        else
        {
            cookie = new HttpCookie("Cart");
        }
        cookie.Value = s;
        cookie.Expires.AddDays(30);
        System.Web.HttpContext.Current.Response.Cookies.Add(cookie);

    }
    #endregion


    protected void showCart_Click(object sender, EventArgs e)
    {
        Response.Redirect("CartView.aspx");
    }

    
}
