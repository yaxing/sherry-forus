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
        try
        {
            goodsInfo.goodsPrice = Convert.ToDouble(GoodsPrice.Text);
            if (goodsInfo.goodsPrice < 0)
            {
                AddResult.Visible = true;
                AddResult.Text = "单价小于零";
            }
        }
        catch
        {
            AddResult.Visible = true;
            AddResult.Text = "单价格式不正确";
            return;
        }
        try
        {
            goodsInfo.goodsStorage = Convert.ToInt32(GoodsStorage.Text);
        }
        catch
        {
            AddResult.Visible = true;
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
                return;
            }
        }
        try
        {
            goodsInfo.goodsImg = "D:\\study\\sherryUpload\\" + GoodsImg.FileName;
            GoodsImg.SaveAs(goodsInfo.goodsImg);
        }
        catch
        {
            AddResult.Visible = true;
            AddResult.Text = "图片地址不正确";
            return;
        }
        goodsInfo.goodsAvailable = Convert.ToBoolean(GoodsAvailable.Text);
        goodsInfo.goodsDescribe = GoodsDescribe.Text;
        if (GoodsInfoBLL.AddGoods(goodsInfo))
        {
            AddResult.Visible = true;
            AddResult.Text = "成功添加";
        }
        else
        {
            AddResult.Visible = true;
            AddResult.Text = "添加过程出错";
        }
    }
}
