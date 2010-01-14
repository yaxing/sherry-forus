////��д�ߣ�������
////��  �ڣ�2009-12-18
////��  �ܣ�ĸ��ҳ���߼�����
using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using DAL;
using Entity;

namespace BLL
{
    public class MasterPageBLL
    {
        MasterPageDAL mpData;

        #region ��ȡ�ؼ���Ʒ�б�
        /// <summary>
        /// ��ȡ�ؼ���Ʒ�б�
        /// </summary>
        /// <param name="itemList">���б�IList</param>
        /// <returns>boolֵ</returns>
        public bool GetSpecialOffers(ref IList<ItemEntity> itemList) 
        {
            mpData = new MasterPageDAL();
            if (!mpData.GetItemList(ref itemList)) 
            {
                return false;
            }
            return true;
        }
        #endregion

        #region ��ȡ��Ʒ�����б�
        /// <summary>
        /// ��ȡ��Ʒ�����б�
        /// </summary>
        /// <param name="itemList">���б�IList</param>
        /// <returns>boolֵ</returns>
        public bool GetCategoryList(ref IList<ItemEntity> categoryList)
        {
            mpData = new MasterPageDAL();
            if (!mpData.GetCategoryList(ref categoryList))
            {
                return false;
            }
            return true;
        }
        #endregion
    }
}
