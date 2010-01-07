using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using Entity;

namespace BLL
{
    public class UploadInfoBLL
    {
        #region ������ϴ���

        public int AddMainUpload(MainUpload mainUpload)
        {
            UploadInfoDAL uploadInfo = new UploadInfoDAL();
            return uploadInfo.AddMainUpload(mainUpload);
        }

        #endregion

        #region ����ϴ������

        /// <summary>
        /// ����ϴ������
        /// </summary>
        /// <param name="newSubUpload">�ϴ�����ʵ�����</param>
        /// <returns>boolֵ</returns>

        public bool AddSubUpload(SubUpload newSubUpload)
        {
            UploadInfoDAL uploadInfo = new UploadInfoDAL();
            return uploadInfo.AddSubUpload(newSubUpload);
        }

        #endregion
    }
}
