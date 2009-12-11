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

public partial class Management_AdminCtrl : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void CreateUserWizard_CreatedUser(object sender, EventArgs e)
    {
        AdminInfo newAdmin = new AdminInfo();
        MembershipUser user = Membership.FindUsersByName(CreateUserWizard.UserName)[CreateUserWizard.UserName];
        newAdmin.AdminID = (Guid)user.ProviderUserKey;
        newAdmin.AdminRealName = ((TextBox)CreateUserWizard.CreateUserStep.ContentTemplateContainer.FindControl("txtRealName")).Text;
        newAdmin.AdminEmailAdd = ((TextBox)CreateUserWizard.CreateUserStep.ContentTemplateContainer.FindControl("Email")).Text;
        newAdmin.AdminPhoneNum = ((TextBox)CreateUserWizard.CreateUserStep.ContentTemplateContainer.FindControl("txtPhoneNum")).Text;
        newAdmin.AdminLv = Convert.ToInt32(((DropDownList)CreateUserWizard.CreateUserStep.ContentTemplateContainer.FindControl("DDLAdminLv")).SelectedValue);

        AdminInfoBLL adminInfoBLL = new AdminInfoBLL();
        adminInfoBLL.AddAdmin(newAdmin);
    }
}
