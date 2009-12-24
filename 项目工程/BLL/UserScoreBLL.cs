////��д�ߣ�������
////��  �ڣ�2009-12-24
////��  �ܣ��û����ֹ���
using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Entity;
using DAL;
using InterFace;
using System.Web;
using System.Web.Security;
using System.Web.UI;

namespace BLL
{
    public class UserScoreBLL
    {
        #region �����û�����
        /// <summary>
        /// �����û�����
        /// </summary>
        /// <param name="score">��Ҫ���ӵĻ���,�����Ĳ����ǻ��ֻ��Ƕ�����(true:����; false:������)</param>
        /// <returns>�����ɹ�����true�����򷵻�false</returns>
        public bool AddUserScore(int score, bool flag)
        {
            MembershipUser curUser = Membership.GetUser(HttpContext.Current.User.Identity.Name.ToString());
            Guid userId = (Guid)curUser.ProviderUserKey;
            UserScoreDAL addScore = new UserScoreDAL();
            if (!addScore.UpdateScore(userId,score,flag)) 
            {
                return false;
            }
            return true;
        }
        #endregion
    }
}
