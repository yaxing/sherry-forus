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
        BindSource();
    }

    private void BindSource()
    {
        string userName = HttpContext.Current.User.Identity.Name;
        UserInfo userInfo = new UserInfo();
        MembershipUser user = Membership.GetUser(userName);
        userInfo.UserID = (Guid) user.ProviderUserKey;

        UserInfoDAL userInfoDAL = new UserInfoDAL();
        userInfoDAL.SrchUserInfo(ref userInfo);

        lblName.Text = userName;
        txtRealName.Text = userInfo.UserRealName;
        Email.Text = user.Email;
        txtPostAdd.Text = userInfo.PostAdd;
        txtPhoneNum.Text = userInfo.PhoneNum;
        txtUserBirth.Text = userInfo.UserBirth.ToLongDateString();
        ddlUserGender.SelectedValue = userInfo.UserGender.ToString();
        lblIDCardNum.Text = userInfo.IDCardNum;
    }
    protected void submit_Click(object sender, EventArgs e)
    {

        string userName = HttpContext.Current.User.Identity.Name;
        UserInfo userInfo = new UserInfo();
        MembershipUser user = Membership.GetUser(userName);
        userInfo.UserID = (Guid)user.ProviderUserKey;

        user.Email = Email.Text;
        userInfo.UserRealName = txtRealName.Text;
        userInfo.PostAdd = txtPostAdd.Text;
        userInfo.PhoneNum = txtPhoneNum.Text;
        userInfo.UserBirth = new DateTime(1986, 10, 8);
        userInfo.UserGender = Convert.ToInt32(ddlUserGender.SelectedValue);
        userInfo.IDCardNum = txtIDCardNum.Text;

        Membership.UpdateUser(user);
        UserInfoDAL userInfoDAL = new UserInfoDAL();
        if(userInfoDAL.ModiUserInfo(userInfo))
        {
            //操作成功
        }
        else
        {
            //操作失败
        }
    }
}
