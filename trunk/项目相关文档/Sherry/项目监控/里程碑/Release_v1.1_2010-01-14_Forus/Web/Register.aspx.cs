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
    string checkOut;
    protected void Page_Load(object sender, EventArgs e)
    {
         checkOut = Request.QueryString["checkOut"];
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
        String birthday = ((TextBox)CreateUserWizard.CreateUserStep.ContentTemplateContainer.FindControl("txtUserBirth")).Text;
        if (birthday != null && birthday != "")
        {
            int year = Convert.ToInt32(birthday.Substring(0, 4));
            int month = Convert.ToInt32(birthday.Substring(5, 2));
            int day = Convert.ToInt32(birthday.Substring(8, 2));
            newuser.UserBirth = new DateTime(year, month, day);
        }
        else
        {
            newuser.UserBirth = new DateTime(1970, 1, 1);
        }
        newuser.UserGender = Convert.ToInt32(((RadioButtonList)CreateUserWizard.CreateUserStep.ContentTemplateContainer.FindControl("rdlUserGender")).SelectedValue);
        newuser.UserAge = DateTime.Now.Year - newuser.UserBirth.Year;
        newuser.IDCardNum = ((TextBox)CreateUserWizard.CreateUserStep.ContentTemplateContainer.FindControl("txtIDCardNum")).Text;
        if (newuser.IDCardNum == "" || newuser.IDCardNum == null)
        {
            newuser.IDCardNum = "000000000000000000";
        }

        UserInfoBLL userInfoBLL = new UserInfoBLL();
        userInfoBLL.AddUserInfo(newuser);

        FormsAuthentication.RedirectFromLoginPage(CreateUserWizard.UserName, true);
        System.Threading.Thread.Sleep(5000);

        if (checkOut != null && checkOut.Equals("1"))
        {
            Response.Redirect("CheckOut.aspx");
        }
        else
        {
            Response.Redirect("~/Index.aspx");
        }
    }
}
