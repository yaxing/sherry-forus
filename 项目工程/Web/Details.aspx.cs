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
    int proId;
    CartCtrl shopCart;
    //string CookieName = "ShopCart";

    protected void Page_Load(object sender, EventArgs e)
    {
        proId = Convert.ToInt32(Request.QueryString["ID"]);
    }

    #region ���빺�ﳵ
    protected void addToCart_Click(object sender, EventArgs e)
    {
        #region ���칺�ﳵ
        shopCart = new CartCtrl();
        #endregion

        #region ���빺�ﳵ
        shopCart.Add(proId);
        #endregion
    }
    #endregion

    protected void showCart_Click(object sender, EventArgs e)
    {
        Response.Redirect("CartView.aspx");
    }
}
