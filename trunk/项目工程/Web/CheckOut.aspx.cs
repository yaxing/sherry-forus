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
using DAL;
using Entity;

public partial class CheckOut : System.Web.UI.Page
{
    CartCtrl shopCart;
    CheckoutCtrl checkOutCtrl;

    protected void Page_Load(object sender, EventArgs e)
    {
        String userName = HttpContext.Current.User.Identity.Name.ToString();
        MembershipUser user = null;
        String userID = null;
        String[] curUserInfo = new String[10];
            if (userName != null && userName.Length > 0)
            {
                user = Membership.GetUser(userName);
                userID = user.ProviderUserKey.ToString();
                pLoggedIn.Visible = true;
                pShippingConfirm.Visible = true;
                pAddChange.Visible = false;
                pPayChange.Visible = false;
                pAnonymous.Visible = false;
                shopCart = new CartCtrl();

                lbTotalPrice.Text = shopCart.ShowTotalPrice();
                lbTotalQuantity.Text = shopCart.GetItemQuantity().ToString();

                checkOutCtrl = new CheckoutCtrl();
                checkOutCtrl.StartCheckOut(ref curUserInfo);

                lbName.Text = curUserInfo[0];
                lbAdd.Text = curUserInfo[1];
                lbZip.Text = curUserInfo[2];
                lbTel.Text = curUserInfo[3];

                lbPay.Text = rblPayMethods.SelectedItem.Text;
            }
            else
            {
                pLoggedIn.Visible = false;
                pAnonymous.Visible = true;
            }
    }
    protected void imgbAddNew_Click(object sender, ImageClickEventArgs e)
    {
        pAddChange.Visible = true;
        pPayChange.Visible = false;
        pShippingConfirm.Visible = false;

        String[] curUserInfo = new String[10];

        checkOutCtrl = new CheckoutCtrl();
        checkOutCtrl.StartCheckOut(ref curUserInfo);

        tbNewName.Text = curUserInfo[0];
        tbNewAdd.Text = curUserInfo[1];
        tbNewZip.Text = curUserInfo[2];
        tbNewTel.Text = curUserInfo[3];

    }

    protected void imgbPayNew_Click(object sender, ImageClickEventArgs e)
    {
        pPayChange.Visible = true;
        pAddChange.Visible = false;
        pShippingConfirm.Visible = false;
    }

    #region 保存新配送地址
    protected void imgbSaveAddChange_Click(object sender, ImageClickEventArgs e)
    {
        //pShippingConfirm.Visible = true;
        //pAddChange.Visible = false;
        //pPayChange.Visible = false;

        String[] curUserInfo = new String[10];

        curUserInfo[0] = tbNewName.Text;
        curUserInfo[1] = tbNewAdd.Text;
        curUserInfo[2] = tbNewZip.Text;
        curUserInfo[3] = tbNewTel.Text;

        checkOutCtrl = new CheckoutCtrl();
        checkOutCtrl.ChangeAdd(ref curUserInfo);

        Response.Redirect("CheckOut.aspx");
    }
    #endregion

    protected void imgbCancelChange_Click(object sender, ImageClickEventArgs e)
    {
        pShippingConfirm.Visible = true;
        pAddChange.Visible = false;
        pPayChange.Visible = false;
    }
    protected void imgbSavePay_Click(object sender, ImageClickEventArgs e)
    {
        pShippingConfirm.Visible = true;
        pAddChange.Visible = false;
        pPayChange.Visible = false;
        lbPay.Text = rblPayMethods.SelectedItem.Text;
    }
    protected void imgbChangeItems_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("CartView.aspx");
    }
    protected void imgbCancelShipping_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("CartView.aspx");
    }
    protected void imgbConfirm_Click(object sender, ImageClickEventArgs e)
    {

    }
}
