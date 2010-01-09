/************************************************************************/
/*��д�ˣ�������                                                        */
/*���ڣ�2009-12-10                                                      */
/*���ܣ�����Ա������Ϣ�޸�                                              */
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
            Response.Write("<script language='javascript'>alert('�������ѱ�ʹ�á��������');</script>");
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
            Response.Write("<script language='javascript'>alert('������Ϣ���޸ĳɹ���');</script>");
        }
        else
        {
            Response.Write("<script language='javascript'>alert('���ݲ������⣬�����ԡ�');</script>");
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
                this.lblType.Text = "��Ʒ����Ա";
                break;
            case 1:
                this.lblType.Text = "�г�����Ա";
                break;
            case 2:
                this.lblType.Text = "���¹���Ա";
                break;
            case 3:
                this.lblType.Text = "������";
                break;
            case 4:
                this.lblType.Text = "��������Ա";
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
            Response.Write("<script language='javascript'>alert('���������������');location.href='ModiAdminSelf.aspx';</script>");
        }
        else
        {
            Response.Write("<script language='javascript'>alert('�����޸ĳɹ���');location.href='ModiAdminSelf.aspx';</script>");
        }
    }
}
