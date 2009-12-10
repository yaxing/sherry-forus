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

        if (!IsPostBack)
        {
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
    }

    #region 修改地址
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
    #endregion

    #region 修改付款方式
    protected void imgbPayNew_Click(object sender, ImageClickEventArgs e)
    {
        pPayChange.Visible = true;
        pAddChange.Visible = false;
        pShippingConfirm.Visible = false;
    }
    #endregion

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

        String province = String.Empty;

        province = ddlUserProvince.SelectedValue.ToString();

        if (province.Equals("0")) 
        {
            Response.Write("<script>alert('请选择您所在省份！');history.go(-1);</script>");
            return;
        }

        province = ddlUserProvince.SelectedItem.Text.ToString();

        //lbProvince.Text = province; 

        ddlUserProvince.Items[Convert.ToInt32(ddlUserProvince.SelectedValue.ToString())].Selected = true;

        checkOutCtrl = new CheckoutCtrl();
        checkOutCtrl.ChangeAdd(ref curUserInfo);

        Response.Redirect("CheckOut.aspx");
    }
    #endregion

    #region 取消修改
    protected void imgbCancelChange_Click(object sender, ImageClickEventArgs e)
    {
        pShippingConfirm.Visible = true;
        pAddChange.Visible = false;
        pPayChange.Visible = false;
    }
    #endregion

    #region 保存付款方式
    protected void imgbSavePay_Click(object sender, ImageClickEventArgs e)
    {
        pShippingConfirm.Visible = true;
        pAddChange.Visible = false;
        pPayChange.Visible = false;
        lbPay.Text = rblPayMethods.SelectedItem.Text;
    }
    #endregion

    #region 修改订单项
    protected void imgbChangeItems_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("CartView.aspx");
    }
    #endregion

    #region 取消订单
    protected void imgbCancelShipping_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("CartView.aspx");
    }
    #endregion

    #region 确认订单
    protected void imgbConfirm_Click(object sender, ImageClickEventArgs e)
    {
        if (cbInvoice.Checked) 
        {
            if (tbInvoiceHead.Text == null || tbInvoiceHead.Text.Length <= 0 || tbInvoiceContent.Text == null || tbInvoiceContent.Text.Length <= 0) 
            {
                Response.Write("<script>alert('发票抬头和内容不能为空！');history.go(-1);</script>");
            }
        }
    }
    #endregion
}
