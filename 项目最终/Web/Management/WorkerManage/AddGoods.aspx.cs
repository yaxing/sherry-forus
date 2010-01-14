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


public partial class AddGoods : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void AddGoodsCommit(object sender, EventArgs e)
    {
        GoodsInfo goodsInfo = new GoodsInfo();
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
                    AddResult.Text = "图片上传失败，请重新尝试";
                    return;
                }
            }
            else
            {
                AddResult.Text = "图片格式不正确";
                return;
            }
        }
        //else
        //{
        //    AddResult.Text = "没有选择图片";
        //    return;
        //}
        try
        {
            goodsInfo.goodsPrice = Convert.ToDouble(GoodsPrice.Text);
            if (goodsInfo.goodsPrice < 0)
            {
                AddResult.Text = "单价小于零";
            }
        }
        catch
        {
            AddResult.Text = "单价格式不正确";
            return;
        }
        try
        {
            goodsInfo.goodsStorage = Convert.ToInt32(GoodsStorage.Text);
        }
        catch
        {
            AddResult.Text = "库存格式不正确";
            return;
        }
        goodsInfo.goodsAddTime = DateTime.Now;
        goodsInfo.goodsValidity = goodsInfo.goodsAddTime;
        if (!Year.Text.Equals(""))
        {
            try
            {
                goodsInfo.goodsValidity = goodsInfo.goodsValidity.AddYears(Convert.ToInt32(Year.Text));
            }
            catch
            {
                AddResult.Text = "年份格式不正确";
                return;
            }
        }
        if (!Month.Text.Equals(""))
        {
            try
            {
                goodsInfo.goodsValidity = goodsInfo.goodsValidity.AddMonths(Convert.ToInt32(Month.Text));
            }
            catch
            {
                AddResult.Text = "月份格式不正确";
                return;
            }
        }
        if (!Day.Text.Equals(""))
        {
            try
            {
                goodsInfo.goodsValidity = goodsInfo.goodsValidity.AddDays(Convert.ToInt32(Day.Text));
            }
            catch
            {
                AddResult.Text = "日期格式不正确";
                return;
            }
        }

        goodsInfo.goodsAvailable = Convert.ToBoolean(GoodsAvailable.Text);
        if (!GoodsDescribe.Text.Equals(""))
        {
            goodsInfo.goodsDescribe = GoodsDescribe.Text;
        }
        if (GoodsInfoBLL.AddGoods(goodsInfo))
        {
            AddResult.Text = "成功添加";
        }
        else
        {
            AddResult.Text = "添加过程出错";
        }
    }
}
