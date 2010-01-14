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
using System.Drawing;

public partial class FindGoods : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void FindGoodsCommit(object sender, EventArgs e)
    {
        FindResult.AllowPaging = true;
        FindResult.PageSize = 10;
        BindData();
    }

    #region 分页
    #region PageIndexChanging
    protected void FindResult_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        FindResult.PageIndex = e.NewPageIndex;

        BindData();

    }
    #endregion

    protected void FindResult_RowCreated(object sender, GridViewRowEventArgs e)
    {
        #region 翻页绑定
        if (e.Row.RowType == DataControlRowType.Pager)
        {
            Label label_Index = new Label();
            LinkButton Button_IndexFirst = new LinkButton();
            LinkButton Button_IndexLast = new LinkButton();
            LinkButton Button_IndexNext = new LinkButton();
            LinkButton Button_IndexPrevious = new LinkButton();
            label_Index.Font.Name = "微软雅黑";
            label_Index.Font.Size = 8;
            Button_IndexFirst.Font.Size = 8;
            Button_IndexLast.Font.Size = 8;
            Button_IndexNext.Font.Size = 9;
            Button_IndexPrevious.Font.Size = 9;

            Button_IndexFirst.Text = "第一页 ";
            Button_IndexFirst.CommandName = "first";
            Button_IndexFirst.ForeColor = Color.Black;
            Button_IndexFirst.Font.Name = "微软雅黑";
            Button_IndexFirst.Click += new EventHandler(PageButtonClick);

            Button_IndexNext.Text = "   下一页 ";
            Button_IndexNext.CommandName = "next";
            Button_IndexNext.ForeColor = Color.Black;
            Button_IndexNext.Font.Name = "微软雅黑";
            Button_IndexNext.Click += new EventHandler(PageButtonClick);

            Button_IndexPrevious.Text = "前一页 ";
            Button_IndexPrevious.CommandName = "previous";
            Button_IndexPrevious.ForeColor = Color.Black;
            Button_IndexPrevious.Font.Name = "微软雅黑";
            Button_IndexPrevious.Click += new EventHandler(PageButtonClick);

            Button_IndexLast.Text = "最末页 ";
            Button_IndexLast.CommandName = "last";
            Button_IndexLast.ForeColor = Color.Black;
            Button_IndexLast.Font.Name = "微软雅黑";
            Button_IndexLast.Click += new EventHandler(PageButtonClick);

            label_Index.Text = "|当前为第" + (FindResult.PageIndex + 1) + "页,共有" + ((GridView)sender).PageCount + "页";
            e.Row.Controls[0].Controls[0].Controls[0].Controls[0].Controls.AddAt(0, (Button_IndexFirst));
            e.Row.Controls[0].Controls[0].Controls[0].Controls[0].Controls.AddAt(1, (Button_IndexPrevious));

            int controlTmp = e.Row.Controls[0].Controls[0].Controls[0].Controls.Count - 1;
            e.Row.Controls[0].Controls[0].Controls[0].Controls[controlTmp].Controls.Add(Button_IndexNext);
            e.Row.Controls[0].Controls[0].Controls[0].Controls[controlTmp].Controls.Add(Button_IndexLast);

            e.Row.Controls[0].Controls[0].Controls[0].Controls[controlTmp].Controls.Add(label_Index);

            //e.Row.Controls[0].Controls.Add(label_Index);
        }
        #endregion
    }

    protected void PageButtonClick(object sender, EventArgs e)
    {
        LinkButton clickedButton = ((LinkButton)sender);
        if (clickedButton.CommandName == "first")
        {
            FindResult.PageIndex = 0;
        }
        else if (clickedButton.CommandName == "next")
        {
            if (FindResult.PageIndex < FindResult.PageCount - 1)
            {
                FindResult.PageIndex += 1;
            }
        }
        else if (clickedButton.CommandName == "previous")
        {
            if (FindResult.PageIndex >= 1)
            {
                FindResult.PageIndex -= 1;
            }
        }
        else if (clickedButton.CommandName == "last")
        {
            FindResult.PageIndex = FindResult.PageCount - 1;
        }
        BindData();
    }

    #endregion

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

    protected void FindResult_RowEditing(object sender, GridViewEditEventArgs e)
    {
        this.FindResult.EditIndex = e.NewEditIndex;
        BindData();
    }

    protected void FindResult_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        this.FindResult.EditIndex = -1;
    }

    protected void FindResult_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int goodsID = Convert.ToInt32(FindResult.DataKeys[e.RowIndex].Value);
        int goodsStorage;
        double goodsPrice;

        try
        {
            goodsStorage = Convert.ToInt32(FindResult.Rows[e.RowIndex].Cells[4].Text);
            goodsPrice = Convert.ToDouble(FindResult.Rows[e.RowIndex].Cells[5].Text);
            //goodsStorage = Convert.ToInt32(e.NewValues["goodsStorage"].ToString());
            //goodsPrice = Convert.ToDouble(e.NewValues["goodsPrice"].ToString());
        }
        catch
        {
            Result.Text = "格式错误";
            return;
        }
        try
        {
            GoodsInfoBLL.ChangeGoodsStat(goodsID, true, goodsStorage);
        }
        catch
        {
            Result.Text = "修改产品状态出错";
            return;
        }
        BindData();
    }
}
