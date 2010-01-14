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
        #region ͶƱ���������

        #region �����ͶƱ����

        /// <summary>
        /// �����ͶƱ����
        /// </summary>
        /// <param name="newMainPoll">ͶƱ����ʵ�����</param>
        /// <returns>IDֵ</returns>

        public int AddMainPollInfo(MainPoll newMainPoll)
        {

            PollInfoDAL PollInfoDAL = new PollInfoDAL();
            return PollInfoDAL.AddMainPoll(newMainPoll);
        }
        #endregion

        #region ��ͶƱID��ѯ

        /// <summary>
        /// ��ѯͶƱ
        /// </summary>
        /// <param name="mainPoll">ͶƱ����</param>
        /// <returns>bool</returns>

        public bool SelectByID(ref MainPoll mainPoll)
        {
            PollInfoDAL PollInfoDAL = new PollInfoDAL();
            return PollInfoDAL.SelectByID(ref mainPoll);
        }

        #endregion

        #region ��ѯ����ͶƱ������

        /// <summary>
        /// ��ѯ����ͶƱ������
        /// </summary>
        /// <param name="mainPollList">ͶƱ������ʵ����󼯺�</param>
        /// <returns>����Ԫ�ظ���</returns>

        public int ShowMainPoll(ref IList<MainPoll> mainPollList)
        {
            PollInfoDAL PollInfoDAL = new PollInfoDAL();
            return PollInfoDAL.ShowMainPoll(ref mainPollList);
        }

        #endregion

        #region ��ѯͶƱ������

        /// <summary>
        /// ��ѯͶƱ������
        /// </summary>
        /// <returns>int</returns>

        public int NumOfMainPoll()
        {
            PollInfoDAL pollNum = new PollInfoDAL();
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
            PollInfoDAL pollNum = new PollInfoDAL();
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

        #region ��������

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="mainPoll">����ʵ��</param>
        /// <returns>bool</returns>

        public bool UpdateMainPoll(MainPoll mainPoll)
        {
            PollInfoDAL pollInfo = new PollInfoDAL();
            return pollInfo.UpdateMainPoll(mainPoll);
            
        }

        #endregion

        #endregion

        #region ͶƱ��ֱ����

        #region �����ͶƱ����

        /// <summary>
        /// �����ͶƱ���������ɹ�����true��ʧ�ܷ���false
        /// </summary>
        /// <param name="newMainPoll">ͶƱ����ʵ�����</param>
        /// <returns>boolֵ</returns>

        public bool AddSubPollInfo(SubPoll newSubPoll)
        {

            PollInfoDAL PollInfoDAL = new PollInfoDAL();
            return PollInfoDAL.AddSubPoll(newSubPoll);
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
            PollInfoDAL subPoll = new PollInfoDAL();
            return subPoll.ShowSubPoll(ref subPollList, mainPoll.MainPollID);
        }

        #endregion

        #region ����ͶƱ�ֱ�

        /// <summary>
        /// ����ͶƱ��
        /// </summary>
        /// <param name="subPoll">ͶƱ�ֱ�</param>
        /// <returns>bool</returns>

        public bool UpdateSubPoll(SubPoll subPoll)
        {
            PollInfoDAL pollInfo = new PollInfoDAL();
            return pollInfo.UpdateSubPoll(subPoll);
        }

        #endregion

        #endregion

        #region ɾ��ͶƱ��

        /// <summary>
        /// ��������IDɾ��ͶƱ��
        /// </summary>
        /// 

        public bool DeletePoll(int mainPollID)
        {
            PollInfoDAL pollInfo = new PollInfoDAL();
            return pollInfo.DeletePoll(mainPollID);
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
            PollInfoDAL subPollDAL = new PollInfoDAL();
            return subPollDAL.UpdatePollNum(subPoll);
        }

        #endregion

    }
}
