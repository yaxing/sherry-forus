////��д�ߣ�������
////��  �ڣ�2009-12-23
////��  �ܣ�����
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
            Response.Write("<script>alert('����ʧ�ܣ������²�����');location.href('Pay.aspx?ID=" + id + "');</script>");
        }
        else if (!addScore.AddUserScore(id, false)) 
        {
            Response.Write("<script>alert('����ɹ����������ʧ�ܣ�����ϵ����Ա��');location.href('OrderManage.aspx?ID=" + id + "');</script>"); 
        }
        else
        {
            Response.Write("<script>alert('����ɹ������Ļ����Ѿ�˳����ӣ�');location.href('OrderManage.aspx?ID=" + id + "');</script>");
        }
    }
}
