////编写者：陈亚星
////日  期：2009-12-18
////功  能：母版页
using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
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
        if (HttpContext.Current.User.Identity.Name == null||HttpContext.Current.User.Identity.Name.Length<=0)
        {
            lsLogOut.Visible = false;
        }
        else 
        {
            lsLogOut.Visible = true;
        }
        if (!mpDatabind())
        {
            SOfferError.Visible = true;
        }
        else 
        {
            SOfferError.Visible = false;
        }
    }

    public bool mpDatabind() 
    {
        MasterPageBLL mpCtrl = new MasterPageBLL();
        IList<ItemEntity> itemList = new List<ItemEntity>();
        if (!mpCtrl.GetSpecialOffers(ref itemList)) 
        {
            return false;
        }
        RpSpecailOffer.DataSource = itemList;
        RpSpecailOffer.DataBind();
        return true;
    }
}
