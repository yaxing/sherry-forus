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
using Entity;
using BLL:

public partial class CartView : System.Web.UI.Page
{
    Cart shopCart;
    protected void Page_Load(object sender, EventArgs e)
    {
        bool cartExsisted = false;
        String cartValue = String.Empty;

        #region 选择购物车
        if (System.Web.HttpContext.Current.Request.Cookies["Cart"] != null)
        {
            cartExsisted = true;
            cartValue = System.Web.HttpContext.Current.Request.Cookies["Cart"].Value;
            shopCart = new Cart(cartExsisted, cartValue);
        }
        else
        {
            shopCart = new Cart(cartExsisted, cartValue);
        }
        #endregion

        gvItems.DataSource = shopCart.GetItems();
        gvItems.DataBind();
    }

    protected void gvItems_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        String index = Convert.ToString(e.CommandArgument);
        bool cartExsisted = false;
        String cartValue = String.Empty;

        cartExsisted = true;
        cartValue = System.Web.HttpContext.Current.Request.Cookies["Cart"].Value;
        shopCart = new Cart(cartExsisted, cartValue);

        if (e.CommandName == "AddItemOne")
        {

            if (shopCart != null)
            {
                Hashtable curItemsList = null;
                if ((curItemsList = shopCart.Edit(Convert.ToInt32(index), shopCart.GetItem(Convert.ToInt32(index)).number + 1)) != null)
                {
                    SaveCookie(curItemsList);
                }
                else
                {
                    return;
                }
            }
        }
        else if (e.CommandName == "DelItemOne")
        {

            Hashtable curItemsList = null;
            curItemsList = shopCart.Edit(Convert.ToInt32(index), shopCart.GetItem(Convert.ToInt32(index)).number - 1);
            if (curItemsList != null)
            {
                SaveCookie(curItemsList);
            }
            else
            {
                return;
            }
        }
        else if (e.CommandName == "DelFromCart")
        {
            Hashtable curItemsList = null;
            curItemsList = shopCart.Remove(Convert.ToInt32(index));
            if (curItemsList != null)
            {
                SaveCookie(curItemsList);
            }
            else
            {
                return;
            }

        }
        Response.Redirect("CartView.aspx");
    }

    #region 保存购物车
    private void SaveCookie(Hashtable dic)
    {

        string s = string.Empty;
        ItemEntity Info;
        HttpCookie cookie;
        foreach (ItemEntity item in dic.Values)
        {
            Info = item;
            s += Info.id.ToString() + "|" + Info.name + "|" + Info.number.ToString() + "|" + Info.price.ToString() + "@";
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
}
