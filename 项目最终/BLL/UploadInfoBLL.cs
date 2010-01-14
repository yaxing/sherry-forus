using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using Entity;

namespace BLL
{
    public class UploadInfoBLL  //上传表BLL
    {
        #region 添加新上传表

        /// <summary>
        /// 添加上传表
        /// </summary>
        /// <param name="newMainUpload">上传表实体对象</param>
        /// <returns>int值</returns>

        public int AddMainUpload(MainUpload mainUpload) //添加新上传表
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

        public bool AddSubUpload(SubUpload newSubUpload)    //添加新上传表副表
        {
            UploadInfoDAL uploadInfo = new UploadInfoDAL();
            return uploadInfo.AddSubUpload(newSubUpload);
        }

        #endregion
    }
}
