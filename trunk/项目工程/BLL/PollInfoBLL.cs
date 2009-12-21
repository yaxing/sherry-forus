////编写者：林思然
////日  期：2009-12-11
////功  能：投票信息的逻辑处理

using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using Entity;

namespace BLL
{
    public class PollInfoBLL
    {
        #region 投票表主表操作

        #region 添加新投票主表

        /// <summary>
        /// 添加新投票主表
        /// </summary>
        /// <param name="newMainPoll">投票主表实体对象</param>
        /// <returns>ID值</returns>

        public int AddMainPollInfo(MainPoll newMainPoll)
        {

            PollInfoDAL PollInfoDAL = new PollInfoDAL();
            return PollInfoDAL.AddMainPoll(newMainPoll);
        }
        #endregion

        #region 按投票ID查询

        /// <summary>
        /// 查询投票
        /// </summary>
        /// <param name="mainPoll">投票主表</param>
        /// <returns>bool</returns>

        public bool SelectByID(ref MainPoll mainPoll)
        {
            PollInfoDAL PollInfoDAL = new PollInfoDAL();
            return PollInfoDAL.SelectByID(ref mainPoll);
        }

        #endregion

        #region 查询所有投票表主表

        /// <summary>
        /// 查询所有投票表主表
        /// </summary>
        /// <param name="mainPollList">投票表主表实体对象集合</param>
        /// <returns>集合元素个数</returns>

        public int ShowMainPoll(ref IList<MainPoll> mainPollList)
        {
            PollInfoDAL PollInfoDAL = new PollInfoDAL();
            return PollInfoDAL.ShowMainPoll(ref mainPollList);
        }

        #endregion

        #region 查询投票主表数

        /// <summary>
        /// 查询投票主表数
        /// </summary>
        /// <returns>int</returns>

        public int NumOfMainPoll()
        {
            PollInfoDAL pollNum = new PollInfoDAL();
            return pollNum.NumOfMainPoll();
        }

        #endregion

        #region 页面显示查询

        /// <summary>
        /// 页面显示查询
        /// </summary>
        /// <param name="currentPage">当前页面</param>
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

        #region 更新主表

        /// <summary>
        /// 更新主表
        /// </summary>
        /// <param name="mainPoll">主表实体</param>
        /// <returns>bool</returns>

        public bool UpdateMainPoll(MainPoll mainPoll)
        {
            PollInfoDAL pollInfo = new PollInfoDAL();
            return pollInfo.UpdateMainPoll(mainPoll);
            
        }

        #endregion

        #endregion

        #region 投票表分表操作

        #region 添加新投票副表

        /// <summary>
        /// 添加新投票副表，操作成功返回true，失败返回false
        /// </summary>
        /// <param name="newMainPoll">投票副表实体对象</param>
        /// <returns>bool值</returns>

        public bool AddSubPollInfo(SubPoll newSubPoll)
        {

            PollInfoDAL PollInfoDAL = new PollInfoDAL();
            return PollInfoDAL.AddSubPoll(newSubPoll);
        }
        #endregion

        #region 根据主表ID查询投票分表

        /// <summary>
        /// 查询投票分表
        /// </summary>
        /// <param name="mainPoll">主表</param>
        /// <param name="subPollList">分表集合</param>
        /// <returns>bool</returns>

        public int SelectSubPollByID(ref IList<SubPoll> subPollList, MainPoll mainPoll)
        {
            PollInfoDAL subPoll = new PollInfoDAL();
            return subPoll.ShowSubPoll(ref subPollList, mainPoll.MainPollID);
        }

        #endregion

        #region 更新投票分表

        /// <summary>
        /// 更新投票数
        /// </summary>
        /// <param name="subPoll">投票分表</param>
        /// <returns>bool</returns>

        public bool UpdateSubPoll(SubPoll subPoll)
        {
            PollInfoDAL pollInfo = new PollInfoDAL();
            return pollInfo.UpdateSubPoll(subPoll);
        }

        #endregion

        #endregion

        #region 删除投票表

        /// <summary>
        /// 根据主表ID删除投票表
        /// </summary>
        /// 

        public bool DeletePoll(int mainPollID)
        {
            PollInfoDAL pollInfo = new PollInfoDAL();
            return pollInfo.DeletePoll(mainPollID);
        }
        #endregion

        #region 更新投票数

        /// <summary>
        /// 更新投票数
        /// </summary>
        /// <param name="subPoll">投票分表</param>
        /// <returns>bool</returns>

        public bool UpdatePollNum(SubPoll subPoll)
        {
            PollInfoDAL subPollDAL = new PollInfoDAL();
            return subPollDAL.UpdatePollNum(subPoll);
        }

        #endregion

    }
}
