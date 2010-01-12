using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using Entity;

namespace BLL
{
    public class UploadInfoBLL
    {
        #region 添加新上传表

        public int AddMainUpload(MainUpload mainUpload)
        {
            UploadInfoDAL uploadInfo = new UploadInfoDAL();
            return uploadInfo.AddMainUpload(mainUpload);
        }

        #endregion

        #region 添加上传表表副表

        /// <summary>
        /// 添加上传表表副表
        /// </summary>
        /// <param name="newSubUpload">上传表副表实体对象</param>
        /// <returns>bool值</returns>

        public bool AddSubUpload(SubUpload newSubUpload)
        {
            UploadInfoDAL uploadInfo = new UploadInfoDAL();
            return uploadInfo.AddSubUpload(newSubUpload);
        }

        #endregion
    }
}
