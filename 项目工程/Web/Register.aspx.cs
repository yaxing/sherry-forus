using System;
using System.Web.Security;
using System.Web.UI.WebControls;
using BLL;
using Entity;

public partial class _Default : System.Web.UI.Page 
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
        newuser.PostAdd = ((TextBox) CreateUserWizard.CreateUserStep.ContentTemplateContainer.FindControl("txtPostAdd")).Text;
        newuser.PostNum = ((TextBox) CreateUserWizard.CreateUserStep.ContentTemplateContainer.FindControl("txtPostNum")).Text;
        newuser.PhoneNum = ((TextBox) CreateUserWizard.CreateUserStep.ContentTemplateContainer.FindControl("txtPhoneNum")).Text;
        newuser.UserBirth = new DateTime(1986,10,8);
        newuser.UserGender = Convert.ToInt32(((DropDownList) CreateUserWizard.CreateUserStep.ContentTemplateContainer.FindControl("ddlUserGender")).SelectedValue);
        newuser.UserAge = 23;
        newuser.IDCardNum = ((TextBox) CreateUserWizard.CreateUserStep.ContentTemplateContainer.FindControl("txtIDCardNum")).Text;

        UserInfoBLL userInfoBLL = new UserInfoBLL();
        userInfoBLL.AddUserInfo(newuser);
    }
}
