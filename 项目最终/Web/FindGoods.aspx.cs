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

public partial class Goods_FindGoods : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void FindGoodsCommit(object sender, EventArgs e)
    {
        BindData();
    }
    protected void FindResult_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int goodsID = Convert.ToInt32(FindResult.DataKeys[e.RowIndex].Value);
        try
        {
            GoodsInfoBLL.DeleteGoods(goodsID);
        }
        catch (Exception deleteException)
        {
            Console.WriteLine("{0}", deleteException);
        }
        BindData();
    }

    protected void BindData()
    {
        string goodsName = GoodsName.Text;
        string goodsNUM = GoodsNum.Text;
        int goodsCategory = Convert.ToInt32(GoodsCategory.Text);
        DateTime timeFrom;
        DateTime timeTo;
        if (TimeFrom.Text.Equals(""))
        {
            timeFrom = DateTime.MinValue; 
        }
        else
        {
            timeFrom = Convert.ToDateTime(TimeFrom.Text);
        }
        if (TimeTo.Text.Equals(""))
        {
            timeTo = DateTime.MaxValue; 
        }
        else
        {
            timeTo = Convert.ToDateTime(TimeTo.Text);
            if (timeFrom.CompareTo(timeTo) >= 0)
            {
                return;
            }
        }
        DataTable findResult = GoodsInfoBLL.FindGoods(goodsName, goodsNUM, goodsCategory, timeFrom, timeTo);
        FindResult.DataSource = findResult;
        FindResult.DataBind();
    }
}
