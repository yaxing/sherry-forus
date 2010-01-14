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
using BLL;
using Entity;
using System.IO;

public partial class ChangeGoods : System.Web.UI.Page
{
    int goodsID;
    string goodsImg = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        GoodsInfo goodsInfo = new GoodsInfo();
        try
        {
            goodsID = Convert.ToInt32(Request.QueryString["GoodsID"]);
            goodsInfo = GoodsInfoBLL.GoodsDetail(goodsID);
        }
        catch
        {
            Response.Redirect("Index.aspx");
        }
        goodsImg = goodsInfo.goodsImg;
        if (!IsPostBack)
        { 
            GoodsName.Text = goodsInfo.goodsName;
            GoodsNum.Text = goodsInfo.goodsNum;
            GoodsCategory.Text = goodsInfo.goodsCategory.ToString();
            Year.Text = goodsInfo.goodsValidity.Year.ToString();
            Month.Text = goodsInfo.goodsValidity.Month.ToString();
            Day.Text = goodsInfo.goodsValidity.Day.ToString();
            GoodsPrice.Text = goodsInfo.goodsPrice.ToString();
            GoodsStorage.Text = goodsInfo.goodsStorage.ToString();
            GoodsAvailable.Text = goodsInfo.goodsAvailable.ToString();
            GoodsDescribe.Text = goodsInfo.goodsDescribe;
        }
    }

    protected void ChangeGoodsCommit(object sender, EventArgs e)
    {
        GoodsInfo goodsInfo = new GoodsInfo();
        goodsInfo.goodsID = goodsID;
        goodsInfo.goodsName = GoodsName.Text;
        goodsInfo.goodsNum = GoodsNum.Text;
        goodsInfo.goodsCategory = Convert.ToInt32(GoodsCategory.SelectedValue);

        if (GoodsImg.HasFile)
        {
            String path = Server.MapPath("~/imgUpload/");
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }

            string fileName = GoodsImg.FileName;
            Boolean fileOK = false;
            if (GoodsImg.HasFile)
            {
                String fileExtension =
                    System.IO.Path.GetExtension(GoodsImg.FileName).ToLower();
                String[] allowedExtensions = { ".jpg", ".gif" };
                for (int i = 0; i < allowedExtensions.Length; i++)
                {
                    if (fileExtension == allowedExtensions[i])
                    {
                        fileOK = true;
                        break;
                    }
                }
            }

            if (fileOK)
            {
                try
                {
                    goodsInfo.goodsImg = path + GoodsImg.FileName;
                    FileInfo img = new FileInfo(goodsInfo.goodsImg);
                    if (img.Exists)
                        img.Delete();
                    GoodsImg.PostedFile.SaveAs(goodsInfo.goodsImg);
                    goodsInfo.goodsImg = "imgUpload/" + GoodsImg.FileName;
                }
                catch
                {
                    ChangeResult.Text = "图片上传失败，请重新尝试";
                    return;
                }
            }
            else
            {
                ChangeResult.Text = "图片格式不正确";
                return;
            }
        }
        else
        {
            goodsInfo.goodsImg = goodsImg;
        }

        try
        {
            goodsInfo.goodsPrice = Convert.ToDouble(GoodsPrice.Text);
            if (goodsInfo.goodsPrice < 0)
            {
                ChangeResult.Text = "单价小于零";
            }
        }
        catch
        {
            ChangeResult.Text = "单价格式不正确";
            return;
        }
        try
        {
            goodsInfo.goodsStorage = Convert.ToInt32(GoodsStorage.Text);
        }
        catch
        {
            ChangeResult.Text = "库存格式不正确";
            return;
        }
        
        if (Year.Text.Equals(""))
        {
            Year.Text = "0";    
        }
        if (Month.Text.Equals(""))
        {
            Month.Text = "0";
        }
        if (Day.Text.Equals(""))
        {
            Day.Text = "0";
        }
        try
        {
            goodsInfo.goodsValidity = new DateTime(Convert.ToInt32(Year.Text), Convert.ToInt32(Month.Text), Convert.ToInt32(Day.Text));
        }
        catch
        {
            ChangeResult.Text = "日期格式不正确";
            return;
        }

        goodsInfo.goodsAvailable = Convert.ToBoolean(GoodsAvailable.Text);
        if (!GoodsDescribe.Text.Equals(""))
        {
            goodsInfo.goodsDescribe = GoodsDescribe.Text;
        }
        if (GoodsInfoBLL.ChangeGoods(goodsID, goodsInfo))
        {
            ChangeResult.Text = "成功修改";
        }
        else
        {
            ChangeResult.Text = "修改该过程出错";
        }
    }
}
