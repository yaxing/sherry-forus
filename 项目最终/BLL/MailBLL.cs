////编写者：李开林
////日  期：2009-12-9
////功  能：邮件部分的逻辑处理

using DAL;

namespace BLL
{
    public class MailBLL
    {
        #region 发送邮件

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="toMail">收件人地址</param>
        /// <param name="mailTitle">邮件标题</param>
        /// <param name="mailBody">邮件正文</param>
        /// <returns>成功返回true，否则返回false</returns>

        public bool SendEmail(string toMail, string mailTitle, string mailBody)
        {
            MailDAL mailDAL = new MailDAL();
            return mailDAL.SendEmail(toMail , mailTitle , mailBody);
        }
        #endregion
    }
}
