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

public partial class Management_AddAdmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminInfo admin = new AdminInfo();
        AdminInfoBLL adminBLL = new AdminInfoBLL();
        if (!adminBLL.SrchAdminInfoByUserName(ref admin, User.Identity.Name))
        {
            Response.Write("<script language='javascript'>alert('数据读取失败，请重试或联系管理员。');location.href='../bgIndex.aspx'</script>");
            return;
        }

        if (admin.AdminLv < 3)
        {
            Response.Write("<script language='javascript'>alert('您无权使用此页面。');location.href='../bgIndex.aspx'</script>");
        }
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
