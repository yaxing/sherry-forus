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
        String mailTitle = "Sherry�ͻ�:";
        if(this.txtSub.Text == "" || this.txtSub.Text == null)
            mailTitle = mailTitle + "������";
        else
            mailTitle = mailTitle + this.txtSub.Text;
        String mailCont = "����:";
        if (this.txtName.Text.Length <= 0 || this.txtName.Text == null)
            mailCont = mailCont + "�����û�<br/>";
        else
            mailCont = mailCont + this.txtName.Text + "<br/>";
        if (this.txtEmail.Text.Length <= 0 || this.txtEmail.Text == null)
            mailCont = mailCont + "��ϵ����:δ��<br/>";
        else
            mailCont = mailCont + "��ϵ����:" + this.txtEmail.Text + "<br/>";
        if (this.txtPhoneNum.Text.Length <= 0 || this.txtPhoneNum.Text == null)
            mailCont = mailCont + "�绰����:δ��<br/><br/><hr/><br/><br/>";
        else
            mailCont = mailCont + "�绰����:" + this.txtPhoneNum.Text + "<br/><br/><hr/><br/><br/>";

        if (this.txtDetail.Text.Length <= 0 || this.txtDetail.Text == null)
            Response.Write("<script language='javascript'>alert('������д��������������Ҫ');location.href='Contact.aspx';</script>");
        else
        {
            mailCont = mailCont + this.txtDetail.Text;
            mailCont = mailCont.Replace("\r\n","<br/>");
            MailBLL mailSender = new MailBLL();
            if (mailSender.SendEmail("forus_2009@sina.com", mailTitle, mailCont))
            {
                Response.Write("<script language='javascript'>alert('�ʼ����ͳɹ������ǽ���7���������ڻظ�����');location.href='Contact.aspx';</script>");
                if (this.txtEmail.Text.Length <= 0 || this.txtEmail.Text == null)
                {
                    mailSender.SendEmail(this.txtEmail.Text, "Sherry��ױƷ�ͻ������ִ", "�������յ��������������7���������ڻָ���");
                }
            }
            else
                Response.Write("<script language='javascript'>alert('�ʼ�����ʧ�ܡ������Ի���ϵ����Ա��');location.href='Contact.aspx';</script>");
        }
    }
}
