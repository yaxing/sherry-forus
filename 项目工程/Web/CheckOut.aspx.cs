////编写者：陈亚星
////日  期：2009-12-05
////功  能：用户订单信息确认，订单生成
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
        UserInfo curUserInfo = new UserInfo();
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

                lbName.Text = curUserInfo.UserRealName;
                lbAdd.Text = curUserInfo.PostAdd;
                lbZip.Text = curUserInfo.PostNum;
                lbTel.Text = curUserInfo.PhoneNum;
                lbPay.Text = rblPayMethods.SelectedItem.Text;
                lbProvince.Text = "[省份]";
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

        UserInfo curUserInfo = new UserInfo();

        checkOutCtrl = new CheckoutCtrl();
        checkOutCtrl.StartCheckOut(ref curUserInfo);

        tbNewName.Text = curUserInfo.UserRealName;
        tbNewAdd.Text = curUserInfo.PostAdd;
        tbNewZip.Text = curUserInfo.PostNum;
        tbNewTel.Text = curUserInfo.PhoneNum;
        

        //ddlUserProvince.SelectedItem.Selected = false;

        //foreach (ListItem lt in ddlUserProvince.Items)
        //{
        //    if (lt.Text.Equals(curUserInfo.Province))
        //    {
        //        lt.Selected = true;
        //        break;
        //    }
        //} 

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
        

        UserInfo userInfo = new UserInfo();
        userInfo.UserRealName = tbNewName.Text;
        userInfo.PostAdd = tbNewAdd.Text;
        userInfo.PostNum = tbNewZip.Text;
        userInfo.PhoneNum = tbNewTel.Text;
        userInfo.Province = ddlUserProvince.SelectedItem.Text.ToString();

        if (ddlUserProvince.SelectedValue.ToString().Equals("0")) 
        {
            Response.Write("<script>alert('请选择您所在省份！');history.go(-1);</script>");
            return;
        }

        //ddlUserProvince.Items[Convert.ToInt32(ddlUserProvince.SelectedValue.ToString())].Selected = true;

        checkOutCtrl = new CheckoutCtrl();
        if (!checkOutCtrl.ChangeAdd(userInfo)) 
        {
            Response.Write("<script>alert('保存失败，请重新操作！');history.go(-1);</script>");
        }
        lbProvince.Text = ddlUserProvince.SelectedItem.Text.ToString();

        lbName.Text = userInfo.UserRealName;
        lbAdd.Text = userInfo.PostAdd;
        lbTel.Text = userInfo.PhoneNum;
        lbZip.Text = userInfo.PostNum;
        lbProvince.Text = userInfo.Province;

        pShippingConfirm.Visible = true;
        pAddChange.Visible = false;
        pPayChange.Visible = false;
        //Response.Redirect("CheckOut.aspx");
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
                return;
            }
        }
        if (ddlUserProvince.SelectedValue.ToString().Equals("0"))
        {
            Response.Write("<script>alert('请选择您的省份！');history.go(-1);</script>");
            return; 
        }
        else 
        {
            CheckoutCtrl newOrder = new CheckoutCtrl();
            CartCtrl userCart = new CartCtrl();
            OrderInfo userOrderInfo = new OrderInfo();
            userOrderInfo.UserRealName = lbName.Text;
            userOrderInfo.UserAdd = lbAdd.Text;
            userOrderInfo.UserProvince = lbProvince.Text;
            userOrderInfo.UserZip = lbZip.Text;
            userOrderInfo.UserTel = lbTel.Text;
            userOrderInfo.UserOrderPrice = userCart.GetTotalPrice();
            userOrderInfo.UserOrderItems = userCart.GetList();

            if (rblPayMethods.SelectedValue.Equals("3")) 
            {
                userOrderInfo.State = 0;
            }

            else if (!rblPayMethods.SelectedValue.Equals("3")) 
            {
                userOrderInfo.State = 1;
            }
            
            if (cbInvoice.Checked) 
            {
                userOrderInfo.InvoiceHead = tbInvoiceHead.Text.ToString();
                userOrderInfo.InvoiceContent = tbInvoiceContent.Text.ToString();
            }

            if (newOrder.GenerateOrder(userOrderInfo)) 
            {
                CartCtrl removeCart = new CartCtrl();
                if(!removeCart.RemoveCart())
                {
                    Response.Write("<script>alert('购物车清空失败，请手动清空购物车');location.href('CartView.aspx');</script>");
                }
                Response.Write("<script>alert('订单保存成功！');location.href('CartView.aspx');</script>");
            }
            else
            {
                Response.Write("<script>alert('订单保存失败！');history.go(-1);</script>");
            }
        }
    }
    #endregion
}
