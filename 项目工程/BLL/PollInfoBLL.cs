////��д�ߣ���˼Ȼ
////��  �ڣ�2009-12-11
////��  �ܣ�ͶƱ��Ϣ���߼�����

using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using Entity;

namespace BLL
{
    public class PollInfoBLL
    {
        #region �����ͶƱ����

        /// <summary>
        /// �����ͶƱ����
        /// </summary>
        /// <param name="newMainPoll">ͶƱ����ʵ�����</param>
        /// <returns>IDֵ</returns>

        public int AddMainPollInfo(MainPoll newMainPoll)
        {

            MainPollDAL mainPollDAL = new MainPollDAL();
            return mainPollDAL.AddMainPoll(newMainPoll);
        }
        #endregion

        
        #region �����ͶƱ����

        /// <summary>
        /// �����ͶƱ���������ɹ�����true��ʧ�ܷ���false
        /// </summary>
        /// <param name="newMainPoll">ͶƱ����ʵ�����</param>
        /// <returns>boolֵ</returns>

        public bool AddSubPollInfo(SubPoll newSubPoll)
        {

            SubPollDAL subPollDAL = new SubPollDAL();
            return subPollDAL.AddSubPoll(newSubPoll);
        }
        #endregion

        /*#region �޸��û���Ϣ

        /// <summary>
        /// ɾ���û��������ɹ�����true��ʧ�ܷ���false
        /// </summary>
        /// <param name="user">�û�ʵ�����</param>
        /// <returns>bool</returns>

        public bool ModiUserInfo(UserInfo user)
        {
            UserInfoDAL userDAL = new UserInfoDAL();
            MembershipUser muser = Membership.GetUser(user.UserRealName);
            user.UserID = (Guid)muser.ProviderUserKey;
            return userDAL.ModiUserInfo(user);
        }
        #endregion


        #region ɾ���û�

        /// <summary>
        /// ɾ���û�
        /// </summary>
        /// <param name="userName">�û���</param>
        /// <returns>bool</returns>

        public bool DeleteUserInfo(String userName)
        {
            MembershipUser user = Membership.GetUser(userName);
            Guid userID = (Guid)user.ProviderUserKey;
            UserInfoDAL userDAL = new UserInfoDAL();
            return userDAL.DeleteUserInfo(userID);
        }
        #endregion
        */
        #region ��ͶƱID��ѯ

        /// <summary>
        /// ��ѯͶƱ
        /// </summary>
        /// <param name="mainPoll">ͶƱ����</param>
        /// <returns>bool</returns>

        public bool SelectByID(ref MainPoll mainPoll)
        {
            MainPollDAL mainPollDAL = new MainPollDAL();
            return mainPollDAL.SelectByID(ref mainPoll);
        }

        #endregion

        #region ��������ID��ѯͶƱ�ֱ�

        /// <summary>
        /// ��ѯͶƱ�ֱ�
        /// </summary>
        /// <param name="mainPoll">����</param>
        /// <param name="subPollList">�ֱ���</param>
        /// <returns>bool</returns>

        public int SelectSubPollByID(ref IList<SubPoll> subPollList, MainPoll mainPoll)
        {
            SubPollDAL subPoll = new SubPollDAL();
            return subPoll.ShowSubPoll(ref subPollList,mainPoll.MainPollID);
        }

        #endregion

        #region ��ѯͶƱ������

        /// <summary>
        /// ��ѯͶƱ������
        /// </summary>
        /// <returns>int</returns>

        public int NumOfMainPoll()
        {
            MainPollDAL pollNum = new MainPollDAL();
            return pollNum.NumOfMainPoll();
        }

        #endregion

        #region ҳ����ʾ��ѯ

        /// <summary>
        /// ҳ����ʾ��ѯ
        /// </summary>
        /// <param name="currentPage">��ǰҳ��</param>
        /// <returns>int</returns>

        public bool GetPageShow(ref IList<MainPoll> ds, int currentPage)
        {
            MainPollDAL pollNum = new MainPollDAL();
            if (currentPage == 0)
            {
                return pollNum.SelectTopN(ref ds, 1);
            }
            else
            {
                return pollNum.SelectTopMNotN(ref ds, 1, currentPage);
            }
        }

        #endregion

        #region ����ͶƱ��

        /// <summary>
        /// ����ͶƱ��
        /// </summary>
        /// <param name="subPoll">ͶƱ�ֱ�</param>
        /// <returns>bool</returns>

        public bool UpdatePollNum(SubPoll subPoll)
        {
            SubPollDAL subPollDAL = new SubPollDAL();
            return subPollDAL.UpdatePollNum(subPoll);
        }

        #endregion


        /*# region ��ʾ�û��б�

        /// <summary>
        /// ��ʾ�û��б�
        /// </summary>
        /// <param name="userList"></param>
        /// <returns>�û�����</returns>

        public int ShowUserInfo(ref IList<UserInfo> userList)
        {
            string[] usernames = Roles.GetUsersInRole("��ͨ�û�");
            UserInfoDAL userDAL = new UserInfoDAL();
            UserInfo userInfo = null;
            foreach (string username in usernames)
            {
                MembershipUser user = Membership.GetUser(username);
                userInfo.UserID = (Guid)user.ProviderUserKey;
                userDAL.SrchUserInfo(ref userInfo);
                userList.Add(userInfo);
            }

            return userList.Count;
        }
        # endregion*/
    }
}
