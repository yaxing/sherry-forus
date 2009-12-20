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

public partial class MyAccount : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.Identity.Name != "" && User.Identity.Name != null && User.IsInRole("普通用户"))
        {
            UserInfo oldUser = new UserInfo();
            UserInfoBLL userInfoBLL = new UserInfoBLL();
            MembershipUser user = Membership.GetUser(User.Identity.Name);
            if (!userInfoBLL.SrchUserInfoByUserName(ref oldUser, User.Identity.Name))
            {
                Response.Write("<script language='javascript'>alert('帐号信息读取失败。');</script>");
                return;
            }
            
            Label lblRealName = (Label)this.LoginView.FindControl("lblRealName");
            Label lblEmailAdd = (Label)this.LoginView.FindControl("lblEmailAdd");
            Label lblAddress = (Label)this.LoginView.FindControl("lblAddress");
            Label lblPostCode = (Label)this.LoginView.FindControl("lblPostCode");
            Label lblPhoneNum = (Label)this.LoginView.FindControl("lblPhoneNum");
            Label lblGender = (Label)this.LoginView.FindControl("lblGender");
            Label lblBirth = (Label)this.LoginView.FindControl("lblBirth");
            Label lblIDCardNum = (Label)this.LoginView.FindControl("lblIDCardNum");
            Label lblScore = (Label)this.LoginView.FindControl("lblScore");
            Label lblUserLv = (Label)this.LoginView.FindControl("lblUserLv");

            lblRealName.Text = oldUser.UserRealName;
            lblEmailAdd.Text = user.Email;
            lblAddress.Text = oldUser.PostAdd;
            lblPostCode.Text = oldUser.PostNum;
            lblPhoneNum.Text = oldUser.PhoneNum;
            switch(oldUser.UserGender)
            {
                case 0:
                    lblGender.Text = "保密";
                    break;
                case 1:
                    lblGender.Text = "男";
                    break;
                case 2:
                    lblGender.Text = "女";
                    break;
                case 3:
                    lblGender.Text = "春哥";
                    break;
            }
            lblBirth.Text = oldUser.UserBirth.Date.ToString();
            lblIDCardNum.Text = oldUser.IDCardNum;
            lblScore.Text = oldUser.UserScore.ToString();
            switch(oldUser.UserLv)
            {
                case 0:
                    lblUserLv.Text = "普通会员";
                    break;
                case 1:
                    lblUserLv.Text = "黄金会员";
                    break;
            }
        }
        if (User.Identity.Name != "" && User.Identity.Name != null && !User.IsInRole("普通用户"))
        {
            Response.Redirect("~/Management/Index.html");
        }
    }
}
