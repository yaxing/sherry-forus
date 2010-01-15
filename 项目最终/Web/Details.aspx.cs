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

using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Text;
using BLL;
using DAL;
using Entity;

public partial class Details : System.Web.UI.Page
{
    int goodsID;
    CartCtrl shopCart;
    //string CookieName = "ShopCart";

    protected void Page_Load(object sender, EventArgs e)
    {
        int shortDescribeLength = 100;
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
        GoodsImg.ImageUrl = goodsInfo.goodsImg;
        GoodsName.Text = goodsInfo.goodsName;
        GoodsPrice.Text = goodsInfo.goodsPrice.ToString();
        if (goodsInfo.goodsDescribe.Length <= shortDescribeLength)
        {
            ShortGoodsDescribe.Text = goodsInfo.goodsDescribe;
        }
        else
        {
            ShortGoodsDescribe.Text = goodsInfo.goodsDescribe.Substring(0, shortDescribeLength) + "...";
        }
        GoodsDescribe.Text = goodsInfo.goodsDescribe;

        if (goodsInfo.goodsSpecialOffer == 0 && User.Identity.Name.ToString().Length == 0)
        {
            Discount.Text = "9.5折";
        }
        else
        {
            Discount.Text = "9.0折";
        }

        Storage.Text = goodsInfo.goodsStorage.ToString();
        SameCategory.DataSource = GoodsInfoBLL.FindGoodsByCategory(goodsInfo.goodsCategory);
        SameCategory.DataBind();


        if (!GoodsCommentLoad(goodsID))
        {
            this.PanelSuccess.Visible = false;
            this.PanelFail.Visible = true;
        }
        else
        {
            this.PanelSuccess.Visible = true;
            this.PanelFail.Visible = false;
        }
    }

    #region 商品评论装载

    /// <summary>
    /// 商品评论装载
    /// </summary>
    /// <param name="goodsID">商品ID</param>
    /// <returns>bool</returns>

    protected Boolean GoodsCommentLoad(int goodsID)
    {
        if (User.Identity.Name == null || User.Identity.Name == "")
        {
            this.PanelAnonymous.Visible = true;
            this.PanelLoggedin.Visible = false;
        }
        else
        {
            this.PanelAnonymous.Visible = false;
            this.PanelLoggedin.Visible = true;
            this.lblUserName.Text = User.Identity.Name + ",您好！";
        }

        //读取评论统计信息
        GoodsComment goodsComment = new GoodsComment();
        GoodsCommentBLL commentBLL = new GoodsCommentBLL();
        try
        {
            goodsComment.GoodsID = Convert.ToInt32(Request.QueryString["GoodsID"]);

            if (!commentBLL.ShowCountOfGood(ref goodsComment))
            {
                return false;
            }
            if (!CommentBind(goodsID))
            {
                return false;
            }
        }
        catch
        {
            return false;
        }

        this.lblSold.Text = goodsComment.GoodsVolume.ToString();
        this.lblCommentAcount.Text = (goodsComment.GoodsBC + goodsComment.GoodsGC + goodsComment.GoodsMC).ToString();

        Double Goods = Convert.ToDouble(goodsComment.GoodsGC);
        Double Normals = Convert.ToDouble(goodsComment.GoodsMC);
        Double Bads = Convert.ToDouble(goodsComment.GoodsBC);

        int GoodsP = 0;
        int NormalsP = 0;
        int BadsP = 0;
        if ((Goods + Normals + Bads) > 0)
        {
            GoodsP = Convert.ToInt32(Goods / (Goods + Normals + Bads) * 100);
            NormalsP = Convert.ToInt32(Normals / (Goods + Normals + Bads) * 100);
            BadsP = Convert.ToInt32(Bads / (Goods + Normals + Bads) * 100);
        }

        this.ImageGood.Width = GoodsP * 2;
        this.ImageMid.Width = NormalsP * 2;
        this.ImageBad.Width = BadsP * 2;

        this.ImageGoodD.Width = 200 - GoodsP * 2;
        this.ImageMidD.Width = 200 - NormalsP * 2;
        this.ImageBadD.Width = 200 - BadsP * 2;

        this.lblGood.Text = goodsComment.GoodsGC + "人(" + GoodsP.ToString() + "%)";
        this.lblNormal.Text = goodsComment.GoodsMC + "人(" + NormalsP.ToString() + "%)";
        this.lblbad.Text = goodsComment.GoodsBC + "人(" + BadsP.ToString() + "%)";

        return true;
    }
    #endregion

    #region 加入购物车
    protected void addToCart_Click(object sender, EventArgs e)
    {
        shopCart = new CartCtrl();

        if (!shopCart.Add(goodsID))
        {
            Response.Write("<script>alert('添加商品失败，请重新操作！');history.go(-1);</script>");
        }
        else
        {
            Response.Write("<script>alert('商品已成功加入购物车！');location.href('Details.aspx?GoodsID=" + goodsID + "');</script>");
            //Response.Redirect("Details.aspx?GoodsID=" + goodsID);
        }
    }
    #endregion

    #region 添加新的评论
    /// <summary>
    /// 添加新的评论
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (this.txtComment.Text.Length <= 0 || this.txtComment.Text.Length >= 500)
        {
            Response.Write("<script language='javascript'>alert('不能提交空评论或字数超过限制。');location.href='Details.aspx?GoodsID=" + Request.QueryString["GoodsID"] + "'</script>");
            return;
        }

        GoodsComment goodsComment = new GoodsComment();
        GoodsCommentBLL commentBLL = new GoodsCommentBLL();

        goodsComment.CommentLevel = Convert.ToInt32(this.rblCommentLv.SelectedValue);
        goodsComment.GoodsCom = this.txtComment.Text;
        goodsComment.GoodsCom = goodsComment.GoodsCom.Replace("\r\n", "<br/>");

        try
        {
            goodsComment.GoodsID = Convert.ToInt32(Request.QueryString["GoodsID"]);
            goodsComment.UserID = (Guid)Membership.GetUser(User.Identity.Name).ProviderUserKey;
            if (!commentBLL.AddComment(goodsComment))
            {
                Response.Write("<script language='javascript'>alert('发生问题，请重试或联系管理员。');location.href='Details.aspx?GoodsID=" + Request.QueryString["GoodsID"] + "'</script>");
                return;
            }
            else
            {
                Response.Write("<script language='javascript'>alert('评论成功。');location.href='Details.aspx?GoodsID=" + Request.QueryString["GoodsID"] + "'</script>");
                return;
            }
        }
        catch
        {
            Response.Write("<script language='javascript'>alert('发生问题，请重试或联系管理员。');location.href='Details.aspx?GoodsID=" + Request.QueryString["GoodsID"] + "'</script>");
            return;
        }
    }
    #endregion

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
            if (commentBLL.ShowFiveCommentOfGood(ref goodsComment, goodsInfoID) == -1)
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
    protected void btnMore_Click(object sender, EventArgs e)
    {
        Response.Redirect("Comment.aspx?GoodsID=" + Request.QueryString["GoodsID"]);
        return;
    }
}
