////编写者：陈亚星
////日  期：2010-01-05
////功  能：后台工作人员订单显示
using System;
using System.Data;
using System.Collections.Generic;
using System.Web.Security;
using System.Web.UI.WebControls;
using System.Drawing;
using BLL;
using Entity;
using InterFace;


public partial class ShowOrderForWorker : System.Web.UI.Page
{
    int orderId;
    OrderCtrlBLL orderCtrl;
    IShipping shipping;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            orderId = Convert.ToInt32(Request.QueryString["ID"]);
            gvOrderList.AllowPaging = true;
            gvOrderList.PageSize = 10;
            gvItemList.AllowPaging = true;
            gvItemList.PageSize = 5;
            if (orderId <= 0)
            {
                if (!mainOrderDatabind())
                {
                    Response.Write("<script>alert('数据绑定失败！请尝试重新操作');history.go(-1);</script>");
                    return;
                }
            }
            else
            {
                if (!subOrderDatabind())
                {
                    Response.Write("<script>alert('数据绑定失败！请尝试重新操作');history.go(-1);</script>");
                    return;
                }
            }
        }
    }

    #region mainOrderList分页
    #region PageIndexChanging
    protected void gvOrderList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvOrderList.PageIndex = e.NewPageIndex;

        if (orderId <= 0)
        {
            mainOrderDatabind();
        }
        else
        {

        }

    }
    #endregion

    protected void gvOrderList_RowCreated(object sender, GridViewRowEventArgs e)
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

            label_Index.Text = "|当前为第" + (gvOrderList.PageIndex + 1) + "页,共有" + ((GridView)sender).PageCount + "页";
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
            gvOrderList.PageIndex = 0;
        }
        else if (clickedButton.CommandName == "next")
        {
            if (gvOrderList.PageIndex < gvOrderList.PageCount - 1)
            {
                gvOrderList.PageIndex += 1;
            }
        }
        else if (clickedButton.CommandName == "previous")
        {
            if (gvOrderList.PageIndex >= 1)
            {
                gvOrderList.PageIndex -= 1;
            }
        }
        else if (clickedButton.CommandName == "last")
        {
            gvOrderList.PageIndex = gvOrderList.PageCount - 1;
        }
        mainOrderDatabind();
    }

    #endregion

    #region items分页
    #region PageIndexChanging
    protected void gvItemList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvItemList.PageIndex = e.NewPageIndex;

        if (orderId <= 0)
        {
            mainOrderDatabind();
        }
        else
        {

        }

    }
    #endregion

    protected void gvItemList_RowCreated(object sender, GridViewRowEventArgs e)
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
            Button_IndexFirst.Click += new EventHandler(PageButtonClick2);

            Button_IndexNext.Text = "   下一页 ";
            Button_IndexNext.CommandName = "next";
            Button_IndexNext.ForeColor = Color.Black;
            Button_IndexNext.Font.Name = "微软雅黑";
            Button_IndexNext.Click += new EventHandler(PageButtonClick2);

            Button_IndexPrevious.Text = "前一页 ";
            Button_IndexPrevious.CommandName = "previous";
            Button_IndexPrevious.ForeColor = Color.Black;
            Button_IndexPrevious.Font.Name = "微软雅黑";
            Button_IndexPrevious.Click += new EventHandler(PageButtonClick2);

            Button_IndexLast.Text = "最末页 ";
            Button_IndexLast.CommandName = "last";
            Button_IndexLast.ForeColor = Color.Black;
            Button_IndexLast.Font.Name = "微软雅黑";
            Button_IndexLast.Click += new EventHandler(PageButtonClick2);

            label_Index.Text = "|当前为第" + (gvItemList.PageIndex + 1) + "页,共有" + ((GridView)sender).PageCount + "页";
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


    protected void PageButtonClick2(object sender, EventArgs e)
    {
        LinkButton clickedButton = ((LinkButton)sender);
        if (clickedButton.CommandName == "first")
        {
            gvItemList.PageIndex = 0;
        }
        else if (clickedButton.CommandName == "next")
        {
            if (gvItemList.PageIndex < gvItemList.PageCount - 1)
            {
                gvItemList.PageIndex += 1;
            }
        }
        else if (clickedButton.CommandName == "previous")
        {
            if (gvItemList.PageIndex >= 1)
            {
                gvItemList.PageIndex -= 1;
            }
        }
        else if (clickedButton.CommandName == "last")
        {
            gvItemList.PageIndex = gvItemList.PageCount - 1;
        }
        subOrderDatabind();
    }

    #endregion

    #region 订单列表数据绑定
    public bool mainOrderDatabind()
    {
        IList<OrderInfo> orderInfoList = new List<OrderInfo>();
        shipping = new LogisticsInfoBLL();
        //获取需要显示的订单列表(仅包括订单ID)
        if (!shipping.SrchOrderListByWorkerID(ref orderInfoList, (Guid)Membership.GetUser().ProviderUserKey)) 
        {
            return false;
        }
        //根据订单列表中的ID值获取包括完整主订单信息的订单列表
        orderCtrl = new OrderCtrlBLL();
        if (!orderCtrl.SrchOrderInfoByID(ref orderInfoList))
        {
            return false;
        }
        pError.Visible = false;

        if (orderInfoList.Count > 0)
        {
            pOrderDetail.Visible = false;
            pOrderList.Visible = true;
            pError.Visible = false;
        }
        else
        {
            pOrderDetail.Visible = false;
            pOrderDetail.Visible = false;
            pError.Visible = true;
            lError.Text = "没有可以显示的订单";
            return true;
        }
        gvOrderList.DataSource = orderInfoList;
        gvOrderList.DataBind();
        return true;
    }
    #endregion

    #region 订单详细信息数据绑定
    public bool subOrderDatabind()
    {
        String state = String.Empty;
        DataTable items = new DataTable();
        orderCtrl = new OrderCtrlBLL();
        pError.Visible = false;
        if (!orderCtrl.GetItemList(ref items, orderId))
        {
            return false;
        }
        if (items.Rows.Count > 0)
        {
            pOrderDetail.Visible = true;
            pOrderList.Visible = false;
            pError.Visible = false;
        }
        else
        {
            pOrderDetail.Visible = false;
            pOrderList.Visible = false;
            pError.Visible = true;
            lError.Text = "当前订单不存在或已被撤销";
            return true;
        }


        gvItemList.DataSource = items;
        gvItemList.DataBind();
        lOrderID.Text = items.Rows[0]["mainOrderID"].ToString();
        lOrderID.Visible = false;
        lUserRealName.Text = items.Rows[0]["userRealName"].ToString();
        lUserAdd.Text = items.Rows[0]["postAdd"].ToString();
        lUserTel.Text = items.Rows[0]["phoneNum"].ToString();
        lUserZip.Text = items.Rows[0]["postNum"].ToString();
        lUserProvince.Text = items.Rows[0]["province"].ToString();
        lTotalPrice.Text = String.Format("{0:C}", Convert.ToDouble(items.Rows[0]["orderPrice"].ToString()));
        lOrderTime.Text = items.Rows[0]["orderTime"].ToString();

        cPicking.Visible = false;
        cReturn.Visible = false;
        rReturn.Visible = false;

        switch (Convert.ToInt32(items.Rows[0]["orderState"].ToString()))
        {
            case 0:
                state = "等待发货";
                if (Convert.ToInt32(items.Rows[0]["isPaid"].ToString()) == 0)
                {
                    state += "，货到付款";
                    cPicking.Visible = true;
                }
                else
                {
                    state += "，货款已付";
                    cPicking.Visible = true;
                }
                break;
            case 1:
                state = "等待付款";
                //imgbPay.Visible = true;
                if (Convert.ToInt32(items.Rows[0]["isPaid"].ToString()) == 0)
                {
                    //bCancel.Visible = true;
                }
                break;
            case 2:
                state = "等待收货确认";
                //bConfirm.Visible = true;
                break;
            case 3:
                state = "交易完成";
                //bReturn.Visible = true;
                break;
            case 4:
                state = "交易失败";
                break;
            case 5:
                state = "申请退货";
                cReturn.Visible = true;
                rReturn.Visible = true;
                break;
            case 6:
                state = "退货驳回";
                break;
        }
        lState.Text = state;
        return true;
    }
    #endregion

    protected void cPicking_Click(object sender, EventArgs e)
    {
        OrderInfo orderInfo = new OrderInfo();
        orderInfo.OrderID = Convert.ToInt32(lOrderID.Text);
        shipping = new LogisticsInfoBLL();
        if (!shipping.ConfirmPicking(orderInfo))
            Response.Write("<script>alert('发货确认失败！请尝试重新尝试');history.go(-1);</script>");
        else
        {
            Response.Write("<script>alert('发货确认成功！');</script>");
            orderId = Convert.ToInt32(lOrderID.Text);
            if (!subOrderDatabind())
            {
                Response.Write("<script>alert('数据绑定失败！请尝试重新操作');history.go(-1);</script>");
            }
        }

    }
    protected void cReturn_Click(object sender, EventArgs e)
    {
        OrderInfo orderInfo = new OrderInfo();
        orderInfo.OrderID = Convert.ToInt32(lOrderID.Text);
        shipping = new LogisticsInfoBLL();
        if (!shipping.ConfirmReturning(orderInfo))
            Response.Write("<script>alert('退货确认失败！请尝试重新尝试');history.go(-1);</script>");
        else
        {
            Response.Write("<script>alert('退货确认成功！');</script>");
            orderId = Convert.ToInt32(lOrderID.Text);
            if (!subOrderDatabind())
            {
                Response.Write("<script>alert('数据绑定失败！请尝试重新操作');history.go(-1);</script>");
                return;
            }
        }
    }
    protected void rReturn_Click(object sender, EventArgs e)
    {
        OrderInfo orderInfo = new OrderInfo();
        orderInfo.OrderID = Convert.ToInt32(lOrderID.Text);
        shipping = new LogisticsInfoBLL();
        if (!shipping.RefuseReturning(orderInfo))
            Response.Write("<script>alert('退货驳回失败！请尝试重新尝试');history.go(-1);</script>");
        else
        {
            Response.Write("<script>alert('退货驳回成功！');</script>");
            orderId = Convert.ToInt32(lOrderID.Text);
            if (!subOrderDatabind())
            {
                Response.Write("<script>alert('数据绑定失败！请尝试重新操作');history.go(-1);</script>");
                return;
            }
        }
    }
}
