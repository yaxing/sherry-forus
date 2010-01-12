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

public partial class ChangePwd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnCommit_Click(object sender, EventArgs e)
    {
        MembershipUser oldUser = Membership.GetUser(User.Identity.Name);
        if(!oldUser.ChangePassword(this.txtUserPwd.Text,this.txtNewPwd.Text))
        {
            Response.Write("<script language='javascript'>alert('您的密码输入错误。');location.href='ChangePwd.aspx';</script>");
        }
        else
        {
            Response.Write("<script language='javascript'>alert('密码修改成功。');location.href='ChangePwd.aspx';</script>");
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("MyAccount.aspx");
    }
}
