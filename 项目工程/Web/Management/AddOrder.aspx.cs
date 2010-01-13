////编写者：陈亚星
////日  期：2010-01-12
////功  能：后台电话销售订单生成
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
using System.Drawing;

public partial class Management_AddOrder : System.Web.UI.Page
{
    CartCtrl shopCart;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminInfo admin = new AdminInfo();
        AdminInfoBLL adminBLL = new AdminInfoBLL();

        if (!adminBLL.SrchAdminInfoByUserName(ref admin, User.Identity.Name))
        {
            Response.Write("<script language='javascript'>alert('无法获取数据，请重试或联系管理员');top.location='../Index.aspx';</script>");
            return;
        }
        if (admin.AdminLv == 0 || admin.AdminLv == 2) 
        {
            Response.Write("<script>alert('没有权限访问！');history.go(-1);</script>");
            return;
        }

        if (!IsPostBack) 
        {
            if (!PageDataBind()) 
            {
                Response.Write("<script>alert('数据绑定失败，请重新操作！');history.go(-1);</script>");
                return;
            }
            GvSourceBind();
        }
    }

    #region 基本数据绑定
    public bool PageDataBind() 
    {
        try
        {
            DataTable category = new DataTable();
            if (!GoodsInfoBLL.GetCategory(ref category)) 
            {
                return false;
            }
            ddlGoodsCategory.DataSource = category;
            ddlGoodsCategory.DataValueField = "ID";
            ddlGoodsCategory.DataTextField = "name";
            ddlGoodsCategory.DataBind();

            DataTable goods = new DataTable();
            goods = GoodsInfoBLL.FindGoods(Convert.ToInt32(ddlGoodsCategory.SelectedItem.Value));
            ddlGoods.Items.Clear();
            ddlGoods.DataSource = goods;
            ddlGoods.DataTextField = "goodsName";
            ddlGoods.DataValueField = "goodsID";
            ddlGoods.DataBind();

            int i = 0;
            string buffer = "";
            string buffer2 = "";
            for (; i < goods.Rows.Count; i++)
            {
                if (ddlGoods.SelectedValue.Equals(goods.Rows[i]["goodsID"].ToString()))
                {
                    buffer = goods.Rows[i]["goodsStorage"].ToString();
                    buffer2 = goods.Rows[i]["goodsPrice"].ToString();
                    break;
                }
            }
            if (buffer2.Length > 0)
            {
                lPrice.Text = String.Format("{0:C}", Convert.ToDouble(buffer2));
            }
            else 
            {
                lPrice.Text = "";
            }
            lStorage.Text = buffer;
            if (buffer.Length > 0)
            {
                tbGoodQuantity.Text = "1";
            }
            else
            {
                tbGoodQuantity.Text = "";
            }
        }
        catch 
        {
            return false;
        }
        return true;
    }
    #endregion

    #region 商品项列表数据绑定
    protected void GvSourceBind()
    {
        shopCart = new CartCtrl(true);

        if (shopCart.GetItems().Count > 0)
        {
            bConfirm.Visible = true;
            ibClearCart.Visible = true;
        }
        else
        {
            bConfirm.Visible = false;
            ibClearCart.Visible = false;
        }

        gvItems.AllowPaging = true;
        gvItems.PageSize = 4;
        try
        {
            gvItems.DataSource = shopCart.GetItems();
            gvItems.DataBind();
        }
        catch
        {
            Response.Write("<script>alert('获取购物车错误，请重新操作！');history.go(-1);</script>");
            return;
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
        shopCart = new CartCtrl(true);
        if (e.CommandName == "DelFromCart")
        {
            shopCart.Remove(Convert.ToInt32(index));
        }
        GvSourceBind();
        //Response.Redirect("AddOrder.aspx");
    }

    #endregion

    #region 更新区域列表
    protected void ddlUserProvince_SelectedIndexChanged(object sender, EventArgs e)
    {
        IList<ShopInfo> shopInfoList = new List<ShopInfo>();
        string province = ddlUserProvince.SelectedItem.Text.ToString();
        ShopInfoBLL updateArea = new ShopInfoBLL();
        if (updateArea.SrchShopByProvince(ref shopInfoList, province) == -1)
        {
            Response.Write("<script>alert('区域数据更新失败，请重新选择！');history.go(-1);</script>");
            return;
        }
        int i = 0;
        ddlUserArea.Items.Clear();
        for (; i < shopInfoList.Count; i++)
        {
            ListItem it = new ListItem(shopInfoList[i].Area.ToString(), shopInfoList[i].ShopID.ToString());
            ddlUserArea.Items.Add(it);
        }
    }
    #endregion

    #region 更新商品列表,库存,价格
    protected void ddlGoodsCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DataTable goods = new DataTable();
            goods = GoodsInfoBLL.FindGoods(Convert.ToInt32(ddlGoodsCategory.SelectedItem.Value));
            ddlGoods.Items.Clear();
            ddlGoods.DataSource = goods;
            ddlGoods.DataTextField = "goodsName";
            ddlGoods.DataValueField = "goodsID";
            ddlGoods.DataBind();

            int i = 0;
            string buffer = "";
            string buffer2 = "";
            for (; i < goods.Rows.Count; i++)
            {
                if (ddlGoods.SelectedValue.Equals(goods.Rows[i]["goodsID"].ToString()))
                {
                    buffer = goods.Rows[i]["goodsStorage"].ToString();
                    buffer2 = goods.Rows[i]["goodsPrice"].ToString();
                    break;
                }
            }
            lStorage.Text = buffer;
            if (buffer2.Length > 0)
            {
                lPrice.Text = String.Format("{0:C}", Convert.ToDouble(buffer2));
            }
            else
            {
                lPrice.Text = "";
            }
            if (buffer.Length > 0)
            {
                tbGoodQuantity.Text = "1";
            }
            else
            {
                tbGoodQuantity.Text = "";
            }
        }
        catch 
        {
            Response.Write("<script>alert('数据绑定失败，请重新操作！');history.go(-1);</script>");
        }
    }
    
    protected void ddlGoods_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        int buffer = -1;
        double buffer2 = -1;
        if (!CartCtrl.curStoragePrice(ref buffer, ref buffer2, Convert.ToInt32(ddlGoods.SelectedValue.ToString()))) 
        {
            Response.Write("<script>alert('数据绑定失败，请重新操作！');history.go(-1);</script>");
            return;
        }
        
        lStorage.Text = buffer.ToString();
        lPrice.Text = String.Format("{0:C}",buffer2);
        if (buffer>= 0)
        {
            tbGoodQuantity.Text = "1";
        }
        else
        {
            tbGoodQuantity.Text = "";
        }
    }
    #endregion

    protected void bAddGood_Click(object sender, EventArgs e)
    {
        //将商品内容暂存至cookie
        if (Convert.ToInt32(lStorage.Text) < Convert.ToInt32(tbGoodQuantity.Text)) 
        {
            Response.Write("<script>alert('商品数量不能大于库存量！');history.go(-1);</script>");
            return;
        }
        CartCtrl cartCtrl = new CartCtrl(true);
        cartCtrl.Add(Convert.ToInt32(ddlGoods.SelectedValue.ToString()),Convert.ToInt32(tbGoodQuantity.Text));
        GvSourceBind();
    }

    #region 清空购物车
    protected void ibClearCart_Click(object sender, EventArgs e)
    {
        shopCart = new CartCtrl(true);
        if (shopCart != null)
        {
            shopCart.RemoveCart();
            Request.Cookies.Remove("CartFroCallCenter");
            GvSourceBind();
        }
    }
    #endregion


    protected void bConfirm_Click(object sender, EventArgs e)
    {
        CartCtrl curCart = new CartCtrl(true);
        OrderInfo curOrder = new OrderInfo();
        curOrder.UserID = (Guid)Membership.GetUser(HttpContext.Current.User.Identity.Name).ProviderUserKey;
        curOrder.UserRealName = tbUserRealName.Text;
        curOrder.UserAdd = tbUserAdd.Text;
        curOrder.UserProvince = ddlUserArea.SelectedItem.Text;
        curOrder.UserPayState = 0;
        curOrder.State = 0;
        curOrder.OrderTime = DateTime.Today.ToString();
        curOrder.UserOrderPrice = curCart.GetTotalPrice();
        curOrder.UserTel = tbUserTel.Text;
        curOrder.UserZip = tbUserZip.Text;
        curOrder.UserOrderItems = curCart.GetList();
        if (cbInvoiceNeeded.Checked)
        {
            curOrder.InvoiceHead = tbInvoiceHead.Text;
            curOrder.InvoiceContent = tbInvoiceContent.Text;
        }
        int orderID = 0;
        CheckoutCtrl generateOrder = new CheckoutCtrl();
        int state = generateOrder.GenerateOrder(curOrder, ref orderID, true);
        if (state == 1) 
        {
            Response.Write("<script>alert('订单生成失败，请重新操作!');history.go(-1);</script>");
            return;
        }
        else if (state == 2)
        {
            if (!curCart.RemoveCart()) 
            {
                Response.Write("<script>alert('订单生成成功,购物车清空失败!请重新操作');location.href('AddOrder.aspx');</script>");
            }
            Response.Write("<script>alert('订单生成成功,物流启动失败!请联系管理员');location.href('AddOrder.aspx');</script>");
            return;
        }
        else 
        {
            if (!curCart.RemoveCart())
            {
                Response.Write("<script>alert('订单生成成功,购物车清空失败!请重新操作');location.href('AddOrder.aspx');</script>");
            }
            Response.Write("<script>alert('订单生成成功!');location.href('AddOrder.aspx');</script>");
            return;
        }
    }
}
