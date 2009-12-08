////编写者：李开林
////日  期：2009-12-4
////功  能：用户信息修改

using System;
using System.Web;
using System.Web.Security;
using DAL;
using Entity;

public partial class ModiUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(HttpContext.Current.User.Identity.Name!="")
        {
            if (!IsPostBack)
            {
                BindSource();
            }
        }
        else
        {
            Response.Write("<script language='javascript'>alert('您还没有登陆,无法修改个人信息.');location.href='Index.aspx';</script>");
        }
    }

    private void BindSource()
    {
        string userName = HttpContext.Current.User.Identity.Name;
        UserInfo userInfo = new UserInfo();
        MembershipUser user = Membership.GetUser(userName);
        userInfo.UserID = (Guid) user.ProviderUserKey;

        UserInfoDAL userInfoDAL = new UserInfoDAL();
        userInfoDAL.SrchUserInfo(ref userInfo);

        this.lblName.Text = userName;
        this.txtRealName.Text = userInfo.UserRealName;
        this.Email.Text = user.Email;
        this.txtPostAdd.Text = userInfo.PostAdd;
        this.txtPhoneNum.Text = userInfo.PhoneNum;
        this.txtUserBirth.Text = userInfo.UserBirth.ToLongDateString();
        this.ddlUserGender.SelectedValue = userInfo.UserGender.ToString();
        this.txtIDCardNum.Text = userInfo.IDCardNum;
        this.txtPostNum.Text = userInfo.PostNum.ToString();
    }
    protected void submit_Click(object sender, EventArgs e)
    {
        string userName = HttpContext.Current.User.Identity.Name;
        UserInfo userInfo = new UserInfo();
        MembershipUser user = Membership.GetUser(userName);
        userInfo.UserID = (Guid)user.ProviderUserKey;

        user.Email = this.Email.Text;
        userInfo.EmailAdd = this.Email.Text;
        userInfo.UserRealName = this.txtRealName.Text;
        userInfo.PostAdd = this.txtPostAdd.Text;
        userInfo.PostNum = this.txtPostNum.Text;
        userInfo.PhoneNum = this.txtPhoneNum.Text;
        userInfo.UserBirth = new DateTime(1986, 10, 8);
        userInfo.UserGender = Convert.ToInt32(this.ddlUserGender.SelectedValue);
        userInfo.IDCardNum = this.txtIDCardNum.Text;
        userInfo.UserAge = 23;

        Membership.UpdateUser(user);
        UserInfoDAL userInfoDAL = new UserInfoDAL();
        if(userInfoDAL.ModiUserInfo(userInfo))
        {
            //操作成功
            Response.Write("<script language='javascript'>alert('用户"+userName+"信息已修改。');</script>");
        }
        else
        {
            //操作失败
            Response.Write("<script language='javascript'>alert('数据操作问题，请重试。');</script>");
        }
    }
}
