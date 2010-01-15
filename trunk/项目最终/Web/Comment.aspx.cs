using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using BLL;
using DAL;
using Entity;

public partial class Comment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GoodsInfo goodsInfo = new GoodsInfo();
        int goodsID = 0;
        try
        {
            goodsID = Convert.ToInt32(Request.QueryString["GoodsID"]);
            goodsInfo = GoodsInfoBLL.GoodsDetail(goodsID);
        }
        catch
        {
            Response.Redirect("Index.aspx");
        }

        if (!CommentBind(goodsID))
        {
            Response.Redirect("Details.aspx?GoodID="+goodsID);
        }

        this.GoodsName.Text = goodsInfo.goodsName;
        this.lblBack.Text = "<a href='Details.aspx?GoodsID=" + goodsID + "'><font size='small'>返回商品页面</font></a>";
    }

    #region 绑定评论信息

    /// <summary>
    /// 绑定评论信息
    /// </summary>
    /// <param name="goodsID">商品ID</param>
    /// <returns>boll</returns>

    public bool CommentBind(int goodsID)
    {
        IList<GoodsComment> goodsComment = new List<GoodsComment>();
        GoodsInfo goodsInfoID = new GoodsInfo();
        GoodsCommentBLL commentBLL = new GoodsCommentBLL();

        try
        {
            goodsInfoID.goodsID = Convert.ToInt32(goodsID);
            if (commentBLL.ShowCommentOfGood(ref goodsComment, goodsInfoID) == -1)
            {
                return false;
            }
        }
        catch
        {
            return false;
        }


        this.GridViewComment.DataSource = goodsComment;
        this.GridViewComment.DataBind();

        return true;
    }

    #endregion
    protected void GridViewComment_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.GridViewComment.PageIndex = e.NewPageIndex;
        int goodsID = Convert.ToInt32(Request.QueryString["GoodsID"]);
        if (!CommentBind(goodsID))
        {
            Response.Write("<script language='javascript'>alert('发生问题，请重试或联系管理员。');location.href='Details.aspx?GoodsID=" + Request.QueryString["GoodsID"] + "'</script>");
        }
    }
}
