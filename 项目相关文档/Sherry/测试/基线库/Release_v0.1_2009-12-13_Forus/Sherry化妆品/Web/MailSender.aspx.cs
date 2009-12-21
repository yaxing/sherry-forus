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

using System.Net;
using System.Net.Mail;
using System.Net.Mime;


public partial class MailSender : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    
    protected Boolean SendMail(string toMail,string mailTitle,string mailMessage)
    {
        MailAddress toMailAdd = new MailAddress(toMail);
        MailAddress fromMailAdd = new MailAddress("forus_2009@sina.com");

        MailMessage msg = new MailMessage(fromMailAdd,toMailAdd);
        msg.Subject = mailTitle;
        msg.Body = mailMessage;

        SmtpClient sendMail = new SmtpClient();
        sendMail.Host = "smtp.sina.com";
        sendMail.Credentials = new NetworkCredential("forus_2009", "forus2009");
        sendMail.DeliveryMethod = SmtpDeliveryMethod.Network;
        sendMail.Send(msg);

        return true;
    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        string toMail = this.txtToMailAdd.Text.ToString();
        string subTitle = this.txtSub.Text.ToString();
        string mailContext = this.txtContext.Text.ToString();

        SendMail(toMail, subTitle, mailContext);
    }
}
