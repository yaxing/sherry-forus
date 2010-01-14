/************************************************************************/
/*编写人：张翼鹏                                                        */
/*日期：2009-12-10                                                      */
/*功能：管理员个人信息修改                                              */
/************************************************************************/

using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DAL;
using BLL;
using Entity;

public partial class Management_ModiAdminSelf : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindInfo();
        }
    }
    protected void btnSub_Click(object sender, EventArgs e)
    {
        String adminName = HttpContext.Current.User.Identity.Name;
        if(Membership.GetUserNameByEmail(this.txtAdminEmail.Text)!=adminName&&Membership.GetUserNameByEmail(this.txtAdminEmail.Text)!=null)
        {
            Response.Write("<script language='javascript'>alert('此邮箱已被使用。请更换。');</script>");
            return;
        }
        AdminInfo admin = new AdminInfo();
        AdminInfoDAL adminDAL = new AdminInfoDAL();

        MembershipUser mAdmin = Membership.GetUser(adminName);
        admin.AdminID = (Guid)mAdmin.ProviderUserKey;
        adminDAL.SrchAdminInfo(ref admin);
        admin.AdminRealName = this.txtAdminRealName.Text;
        admin.AdminPhoneNum = this.txtPhoneNum.Text;
        admin.AdminEmailAdd = this.txtAdminEmail.Text;
        mAdmin.Email = this.txtAdminEmail.Text;

        Membership.UpdateUser(mAdmin);
        AdminInfoBLL adminBLL = new AdminInfoBLL();

        if (adminBLL.ModiAdminInfo(admin))
        {
            Response.Write("<script language='javascript'>alert('您的信息已修改成功。');</script>");
        }
        else
        {
            Response.Write("<script language='javascript'>alert('数据操作问题，请重试。');</script>");
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        BindInfo();
    }
    void BindInfo()
    {
        String adminName = HttpContext.Current.User.Identity.Name;
        AdminInfo admin = new AdminInfo();
        AdminInfoDAL adminDAL = new AdminInfoDAL();

        MembershipUser mAdmin = Membership.GetUser(adminName);
        admin.AdminID = (Guid)mAdmin.ProviderUserKey;
        adminDAL.SrchAdminInfo(ref admin);

        this.lblAdminName.Text = adminName;
        switch(admin.AdminLv)
        {
            case 0:
                this.lblType.Text = "商品管理员";
                break;
            case 1:
                this.lblType.Text = "市场管理员";
                break;
            case 2:
                this.lblType.Text = "人事管理员";
                break;
            case 3:
                this.lblType.Text = "管理经理";
                break;
            case 4:
                this.lblType.Text = "顶级管理员";
                break;
        }
        this.txtAdminEmail.Text = mAdmin.Email;
        this.txtAdminRealName.Text = admin.AdminRealName;
        this.txtPhoneNum.Text = admin.AdminPhoneNum;
        
    }
    protected void btnPassword_Click(object sender, EventArgs e)
    {
        MembershipUser oldUser = Membership.GetUser(User.Identity.Name);
        if (!oldUser.ChangePassword(this.txtPassword.Text, this.txtNewPwd.Text))
        {
            Response.Write("<script language='javascript'>alert('您的密码输入错误。');location.href='ModiAdminSelf.aspx';</script>");
        }
        else
        {
            Response.Write("<script language='javascript'>alert('密码修改成功。');location.href='ModiAdminSelf.aspx';</script>");
        }
    }
}
