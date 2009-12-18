////编写者：陈亚星
////日  期：2009-12-03
////功  能：购物车
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
            lbCookieWarning.Visible = false;
            if (!TestCookie())
            {
                lbCookieWarning.Visible = true;
            }
            GvSourceBind();
        }
    }

    #region 检测浏览器是否允许cookie
    /// <summary>
    /// 构造一个测试cookie，检测是否能够正确写入
    /// </summary>
    /// <param></param>
    /// <returns>bool值</returns>
    private bool TestCookie() 
    {
        HttpCookie testCookie = new HttpCookie("test");
        testCookie.Value = "Web is testing the brower's cookie setting!";
        try
        {
            testCookie.Expires = DateTime.Now.AddDays(1);
            HttpContext.Current.Response.Cookies.Add(testCookie);
        }
        catch (Exception e) 
        {
            return false;
        }
        if (Request.Cookies["test"]!=null) 
        {
            Response.Cookies["test"].Expires = DateTime.Now.AddDays(-1);
            return true;
        }
        return false;
    }
    #endregion

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
                /*购物车转存完毕后清除COOKIE购物车*/
                Response.Cookies["Cart"].Expires = DateTime.Now.AddDays(-1);
            }
        }
        #endregion

            gvItems.AllowPaging = true;
            gvItems.PageSize = 3;
            gvItems.DataSource = shopCart.GetItems();
            gvItems.DataBind();
            lbTotalPrice.Text = shopCart.ShowTotalPrice();
            lbTotalQuantity.Text = shopCart.GetItemQuantity().ToString();
            if (shopCart.GetItemQuantity() == 0)
            {
                ibPay.Visible = false;
                ibClearCart.Visible = false;
                ibSaveCart.Visible = false;
            }
            else 
            {
                ibPay.Visible = true;
                ibClearCart.Visible = true;
                ibSaveCart.Visible = true;
            }
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
                shopCart.Edit(Convert.ToInt32(index), shopCart.GetItem(Convert.ToInt32(index)).Number + 1);
            }
        }
        else if (e.CommandName == "DelItemOne")
        {

            shopCart.Edit(Convert.ToInt32(index), shopCart.GetItem(Convert.ToInt32(index)).Number - 1);
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

            int s = 0;
            CartCtrl getStorage = new CartCtrl(id);
            bool flagStorage = getStorage.curStorage(ref s);
            
            if (quantity == 0)
            {
                shopCart.Remove(id);
            }
            else if (quantity < 0)
            {
                validation = false;
            }
            else if (flagStorage) 
            {
                if (s < quantity)
                {
                    validation = false;
                }
                else 
                {
                    shopCart.Edit(id, quantity);
                }
            }
            else if (!flagStorage) 
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
            Response.Write("<script>alert('保存失败！商品数量输入错误！');location.href('CartView.aspx');</script>");
        }
        GvSourceBind();
    }
    #endregion
    protected void ibReturn_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Index.aspx");
    }
    protected void ibPay_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("CheckOut.aspx");
    }
}
