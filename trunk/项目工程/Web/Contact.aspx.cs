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

public partial class Contact : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        String mailTitle = "Sherry客户:";
        if(this.txtSub.Text == "" || this.txtSub.Text == null)
            mailTitle = mailTitle + "无主题";
        else
            mailTitle = mailTitle + this.txtSub.Text;
        String mailCont = "来自:";
        if (this.txtName.Text.Length <= 0 || this.txtName.Text == null)
            mailCont = mailCont + "匿名用户<br/>";
        else
            mailCont = mailCont + this.txtName.Text + "<br/>";
        if (this.txtEmail.Text.Length <= 0 || this.txtEmail.Text == null)
            mailCont = mailCont + "联系邮箱:未留<br/>";
        else
            mailCont = mailCont + "联系邮箱:" + this.txtEmail.Text + "<br/>";
        if (this.txtPhoneNum.Text.Length <= 0 || this.txtPhoneNum.Text == null)
            mailCont = mailCont + "电话号码:未留<br/><br/><hr/><br/><br/>";
        else
            mailCont = mailCont + "电话号码:" + this.txtPhoneNum.Text + "<br/><br/><hr/><br/><br/>";

        if (this.txtDetail.Text.Length <= 0 || this.txtDetail.Text == null)
            Response.Write("<script language='javascript'>alert('请您填写您的意见和意见概要');location.href='Contact.aspx';</script>");
        else
        {
            mailCont = mailCont + this.txtDetail.Text;
            mailCont = mailCont.Replace("\r\n","<br/>");
            MailBLL mailSender = new MailBLL();
            if (mailSender.SendEmail("forus_2009@sina.com", mailTitle, mailCont))
            {
                Response.Write("<script language='javascript'>alert('邮件发送成功。我们将在7个工作日内回复您。');location.href='Contact.aspx';</script>");
                if (this.txtEmail.Text.Length <= 0 || this.txtEmail.Text == null)
                {
                    mailSender.SendEmail(this.txtEmail.Text, "Sherry化妆品客户意见回执", "我们已收到您的意见，将在7个工作日内恢复您");
                }
            }
            else
                Response.Write("<script language='javascript'>alert('邮件发送失败。请重试或联系管理员。');location.href='Contact.aspx';</script>");
        }
    }
}
