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

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void CreateUserWizard_CreatedUser(object sender, EventArgs e)
    {
        UserInfo newuser = new UserInfo();
        MembershipUser user = Membership.FindUsersByName(CreateUserWizard.UserName)[CreateUserWizard.UserName];
        newuser.UserID = (Guid)user.ProviderUserKey;
        newuser.UserRealName = ((TextBox)CreateUserWizard.CreateUserStep.ContentTemplateContainer.FindControl("txtRealName")).Text;
        newuser.PostAdd = ((TextBox)CreateUserWizard.CreateUserStep.ContentTemplateContainer.FindControl("txtPostAdd")).Text;
        newuser.PostNum = ((TextBox)CreateUserWizard.CreateUserStep.ContentTemplateContainer.FindControl("txtPostNum")).Text;
        newuser.PhoneNum = ((TextBox)CreateUserWizard.CreateUserStep.ContentTemplateContainer.FindControl("txtPhoneNum")).Text;
        newuser.UserBirth = new DateTime(1986, 10, 8);
        newuser.UserGender = Convert.ToInt32(((RadioButtonList)CreateUserWizard.CreateUserStep.ContentTemplateContainer.FindControl("rdlUserGender")).SelectedValue);
        newuser.UserAge = 23;
        newuser.IDCardNum = ((TextBox)CreateUserWizard.CreateUserStep.ContentTemplateContainer.FindControl("txtIDCardNum")).Text;

        UserInfoBLL userInfoBLL = new UserInfoBLL();
        userInfoBLL.AddUserInfo(newuser);

        FormsAuthentication.RedirectFromLoginPage(CreateUserWizard.UserName,true);
        System.Threading.Thread.Sleep(5000);
        Response.Redirect("~/Index.aspx");
    }
}
