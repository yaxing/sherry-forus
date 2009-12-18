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
using InterFace;

public partial class IndexMaster : System.Web.UI.MasterPage
{
    CartCtrl curCart;
    protected void Page_Load(object sender, EventArgs e)
    {
        curCart = new CartCtrl();
        lbTotalPrice.Text = curCart.ShowTotalPrice();
        lbTotalQuantity.Text = curCart.GetItemQuantity().ToString();
        this.Page.Title = "Sherry化妆品有限公司";
    }
}
