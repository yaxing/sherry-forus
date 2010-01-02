////编写者：陈亚星
////日  期：2009-12-23
////功  能：付款
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

public partial class Pay : System.Web.UI.Page
{
    int id;
    protected void Page_Load(object sender, EventArgs e)
    {
        id = Convert.ToInt32(Request.QueryString["ID"]);
    }
    protected void bPay_Click(object sender, EventArgs e)
    {
        OrderCtrlBLL payOrder = new OrderCtrlBLL();
        UserScoreBLL addScore = new UserScoreBLL();
        if (!payOrder.ChangePayState(id))
        {
            Response.Write("<script>alert('付款失败，请重新操作！');location.href('Pay.aspx?ID=" + id + "');</script>");
        }
        else if (!addScore.AddUserScore(id, false)) 
        {
            Response.Write("<script>alert('付款成功，积分添加失败，请联系管理员！');location.href('OrderManage.aspx?ID=" + id + "');</script>"); 
        }
        else
        {
            Response.Write("<script>alert('付款成功，您的积分已经顺利添加！');location.href('OrderManage.aspx?ID=" + id + "');</script>");
        }
    }
}
