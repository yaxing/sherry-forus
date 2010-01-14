////编写者：李开林
////日  期：2009-12-9
////功  能：邮件部分的数据库操作

using System;
using System.Net;
using System.Net.Configuration;
using System.Net.Mail;
using System.Web.Configuration;

namespace DAL
{
    public class MailDAL
    {
        #region 发送邮件

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="toMail">收件人地址</param>
        /// <param name="mailTitle">邮件标题</param>
        /// <param name="mailBody">邮件正文</param>
        /// <returns>成功返回true，否则返回false</returns>

        public bool SendEmail(string toMail , string mailTitle , string mailBody)
        {
            try
            {
                SmtpSection mailConfig = NetSectionGroup.GetSectionGroup(WebConfigurationManager.OpenWebConfiguration("~/web.config")).MailSettings.Smtp;

                MailMessage email = new MailMessage(mailConfig.From, toMail);

                email.IsBodyHtml = true;
                email.Subject = mailTitle;
                email.Body = mailBody;

                SmtpClient sendMail = new SmtpClient();
                sendMail.Host = mailConfig.Network.Host;
                sendMail.UseDefaultCredentials = true;
                sendMail.Credentials = new NetworkCredential(mailConfig.Network.UserName, mailConfig.Network.Password);
                sendMail.DeliveryMethod = SmtpDeliveryMethod.Network;

                sendMail.Send(email);
            }
            catch(Exception e)
            {
                return false;
            }
            return true;
        }
        #endregion
    }
}
