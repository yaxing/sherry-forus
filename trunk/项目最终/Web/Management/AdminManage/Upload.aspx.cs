using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Timers;
using BLL;
using Entity;

public partial class Management_Upload : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public void submit_Click1(object sender, System.EventArgs e)
    {
        HttpPostedFile postedFile = this.Up_file.PostedFile; //得到要上传文件
        string fileName, fileExtension;
        fileName = System.IO.Path.GetFileName(postedFile.FileName); //文件名称
        if (fileName != "")
        {
            fileExtension = System.IO.Path.GetExtension(fileName); //上传文件的扩展名
            if (fileExtension.Equals(".txt") == false && fileExtension.Equals(".csv") == false)
            {
                this.RegisterStartupScript("msg", "<script>alert('请上传.txt文件或.csv文件')</script>");
                return;
            }
            string new_filename = DateTime.UtcNow.ToLocalTime() + fileExtension; //给文件重新命名

            string filePath = Server.MapPath("./files/") + fileName;
            if (System.IO.Directory.Exists(filePath))
            {
                postedFile.SaveAs(filePath);
            }
            else
            {
                System.IO.Directory.CreateDirectory(Server.MapPath("./files"));
                postedFile.SaveAs(filePath);
            }

            CreateTable(filePath);
        }
    }

    private void CreateTable(string filePath)
    {
        FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
        StreamReader streamReader = new StreamReader(fs);

        string line;
        int start=0, end=0;
        MainUpload newMainUpload = new MainUpload();
        MainUpload tempMainUpload = new MainUpload();
        SubUpload newSubUpload = new SubUpload();
        UploadInfoBLL uploadInfo = new UploadInfoBLL();
        int mainUploadID=0;
        while ((line = streamReader.ReadLine()) != null)
        {
            start = end = 0;
            end = line.IndexOf(',', start);
            string str = line.Substring(start, end - start);
            tempMainUpload.SellTime = DateTime.Parse(line.Substring(start,end-start));
            start = end+1;

            end = line.IndexOf(',', start);
            tempMainUpload.TotalValue = float.Parse(line.Substring(start, end - start));
            start = end + 1;

            end = line.IndexOf(',', start);
            tempMainUpload.Gender = line.Substring(start, end - start);
            start = end + 1;

            end = line.IndexOf(',', start);
            tempMainUpload.Age = Int32.Parse(line.Substring(start, end - start));
            start = end + 1;

            end = line.IndexOf(',', start);
            tempMainUpload.ShopID = Int32.Parse(line.Substring(start, end - start));
            start = end + 1;

            end = line.IndexOf(',', start);
            tempMainUpload.Province = line.Substring(start, end - start);
            start = end + 1;

            if (tempMainUpload.SellTime != newMainUpload.SellTime)
            {
                newMainUpload.SellTime = tempMainUpload.SellTime;
                mainUploadID = uploadInfo.AddMainUpload(tempMainUpload);   
            }

            newSubUpload.MainUploadID = mainUploadID;

            end = line.IndexOf(',', start);
            newSubUpload.GoodsID = Int32.Parse(line.Substring(start, end - start));
            start = end + 1;

            end = line.IndexOf(',', start);
            newSubUpload.GoodsName = line.Substring(start, end - start);
            start = end + 1;

            end = line.IndexOf(',', start);
            newSubUpload.Number = Int32.Parse(line.Substring(start, end - start));
            start = end + 1;

            end = line.IndexOf(',', start);
            newSubUpload.Price = float.Parse(line.Substring(start, end - start));
            start = end + 1;

            str = line.Substring(start);
            newSubUpload.TotalValue = float.Parse(line.Substring(start));
            start = end + 1;

            uploadInfo.AddSubUpload(newSubUpload);

        }
        streamReader.Close();
        fs.Close();
    }

}
