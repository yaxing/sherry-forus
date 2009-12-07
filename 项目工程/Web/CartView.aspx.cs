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
using System.Drawing;
using Entity;
using BLL;

public partial class CartView : System.Web.UI.Page
{
    CartCtrl shopCart;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GvSourceBind();
        }
    }

    #region 绑定数据
    protected void GvSourceBind() 
    {
        #region 构造购物车
        shopCart = new CartCtrl();
        /*获取用户登录名*/
        String userName = HttpContext.Current.User.Identity.Name;
        /*如果用户为登录状态并且COOKIE存在则将COOKIE购物车写入XML*/
        if (userName != null && userName.Length > 0)
        {
            if (HttpContext.Current.Request.Cookies["Cart"] != null)
            {
                shopCart.WriteToXML(userName);
            }
        }
        #endregion
            gvItems.AllowPaging = true;
            gvItems.PageSize = 3;
            gvItems.DataSource = shopCart.GetItems();
            gvItems.DataBind();
            lbTotalPrice.Text = shopCart.ShowTotalPrice();
            lbTotalQuantity.Text = shopCart.GetItemQuantity().ToString();
    }
    #endregion

    #region 分页
    #region PageIndexChanging
    protected void gvItems_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvItems.PageIndex = e.NewPageIndex;

        GvSourceBind();

    }
    #endregion

    protected void gvItems_RowCreated(object sender, GridViewRowEventArgs e)
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
            label_Index.Font.Size =8;
            Button_IndexFirst.Font.Size = 8;
            Button_IndexLast.Font.Size = 8;
            Button_IndexNext.Font.Size = 9;
            Button_IndexPrevious.Font.Size = 9;

            Button_IndexFirst.Text = "第一页 ";
            Button_IndexFirst.CommandName = "first";
            Button_IndexFirst.ForeColor = Color.White;
            Button_IndexFirst.Font.Name = "微软雅黑";
            Button_IndexFirst.Click += new EventHandler(PageButtonClick);

            Button_IndexNext.Text = "   下一页 ";
            Button_IndexNext.CommandName = "next";
            Button_IndexNext.ForeColor = Color.White;
            Button_IndexNext.Font.Name = "微软雅黑";
            Button_IndexNext.Click += new EventHandler(PageButtonClick);

            Button_IndexPrevious.Text = "前一页 ";
            Button_IndexPrevious.CommandName = "previous";
            Button_IndexPrevious.ForeColor = Color.White;
            Button_IndexPrevious.Font.Name = "微软雅黑";
            Button_IndexPrevious.Click += new EventHandler(PageButtonClick);

            Button_IndexLast.Text = "最末页 ";
            Button_IndexLast.CommandName = "last";
            Button_IndexLast.ForeColor = Color.White;
            Button_IndexLast.Font.Name = "微软雅黑";
            Button_IndexLast.Click += new EventHandler(PageButtonClick);

            label_Index.Text = "|当前为第" + (gvItems.PageIndex + 1) + "页,共有" + ((GridView)sender).PageCount + "页";
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
            gvItems.PageIndex = 0;
        }
        else if (clickedButton.CommandName == "next")
        {
            if (gvItems.PageIndex < gvItems.PageCount - 1)
            {
                gvItems.PageIndex += 1;
            }
        }
        else if (clickedButton.CommandName == "previous")
        {
            if (gvItems.PageIndex >= 1)
            {
                gvItems.PageIndex -= 1;
            }
        }
        else if (clickedButton.CommandName == "last")
        {
            gvItems.PageIndex = gvItems.PageCount - 1;
        }
        GvSourceBind();
    }

    #endregion

    #region 列命令事件
    protected void gvItems_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        String index = Convert.ToString(e.CommandArgument);
        shopCart = new CartCtrl();

        if (e.CommandName == "AddItemOne")
        {

            if (shopCart != null)
            {
                shopCart.Edit(Convert.ToInt32(index), shopCart.GetItem(Convert.ToInt32(index)).number + 1);
            }
        }
        else if (e.CommandName == "DelItemOne")
        {

            shopCart.Edit(Convert.ToInt32(index), shopCart.GetItem(Convert.ToInt32(index)).number - 1);
        }
        else if (e.CommandName == "DelFromCart")
        {
            shopCart.Remove(Convert.ToInt32(index));
        }
        else if (e.CommandName == "ShowInfo")
        {
            Response.Redirect("ProductInfo.aspx?ID="+index);
        }
        Response.Redirect("CartView.aspx");
    }

    #endregion

    #region 清空购物车
    protected void ibClearCart_Click(object sender, ImageClickEventArgs e)
    {
        shopCart = new CartCtrl();
        if (shopCart != null) 
        {
            shopCart.RemoveCart();
            Request.Cookies.Remove("Cart");
            GvSourceBind();
        }
        Response.Redirect("CartView.aspx");
    }
    #endregion

    #region 保存购物车
    protected void ibSaveCart_Click(object sender, ImageClickEventArgs e)
    {
        shopCart = new CartCtrl();
        Boolean validation = true;
        foreach (GridViewRow row in gvItems.Rows)
        {
            Label lbCtrl = (Label)row.FindControl("lbId");
            TextBox tbCtrl = (TextBox)row.FindControl("tbNumber");
            int id = Convert.ToInt32(lbCtrl.Text);
            int quantity = Convert.ToInt32(tbCtrl.Text);
            if (quantity == 0)
            {
                shopCart.Remove(id);
            }
            else if (quantity < 0)
            {
                validation = false;
            }
            else
            {
                shopCart.Edit(id, quantity);
            }
        }

        if (validation)
        {
            Response.Write("<script>alert('保存成功！');location.href('CartView.aspx');</script>");
        }
        else 
        {
            Response.Write("<script>alert('保存失败！商品数量输入错误！');</script>");
        }
        GvSourceBind();
    }
    #endregion
}
