////��д�ߣ�������
////��  �ڣ�2010-01-05
////��  �ܣ���̨����Ա������ʾ

using System;
using System.Data;
using System.Collections.Generic;
using System.Web.Security;
using System.Web.UI.WebControls;
using System.Drawing;
using BLL;
using Entity;
using InterFace;

public partial class Management_ShowOrdersForManager : System.Web.UI.Page
{
    
    int orderId;
    OrderCtrlBLL orderCtrl;
    IShipping shipping;

    protected void Page_Load(object sender, EventArgs e)
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
                Response.Write("<script>alert('���ݰ�ʧ�ܣ��볢�����²���');history.go(-1);</script>");
                return;
            }
        }
        else
        {
            if (!subOrderDatabind())
            {
                Response.Write("<script>alert('���ݰ�ʧ�ܣ��볢�����²���');history.go(-1);</script>");
                return;
            }
        }
    }

    #region mainOrderList��ҳ
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
        #region ��ҳ��
        if (e.Row.RowType == DataControlRowType.Pager)
        {
            Label label_Index = new Label();
            LinkButton Button_IndexFirst = new LinkButton();
            LinkButton Button_IndexLast = new LinkButton();
            LinkButton Button_IndexNext = new LinkButton();
            LinkButton Button_IndexPrevious = new LinkButton();
            label_Index.Font.Name = "΢���ź�";
            label_Index.Font.Size = 8;
            Button_IndexFirst.Font.Size = 8;
            Button_IndexLast.Font.Size = 8;
            Button_IndexNext.Font.Size = 9;
            Button_IndexPrevious.Font.Size = 9;

            Button_IndexFirst.Text = "��һҳ ";
            Button_IndexFirst.CommandName = "first";
            Button_IndexFirst.ForeColor = Color.Black;
            Button_IndexFirst.Font.Name = "΢���ź�";
            Button_IndexFirst.Click += new EventHandler(PageButtonClick);

            Button_IndexNext.Text = "   ��һҳ ";
            Button_IndexNext.CommandName = "next";
            Button_IndexNext.ForeColor = Color.Black;
            Button_IndexNext.Font.Name = "΢���ź�";
            Button_IndexNext.Click += new EventHandler(PageButtonClick);

            Button_IndexPrevious.Text = "ǰһҳ ";
            Button_IndexPrevious.CommandName = "previous";
            Button_IndexPrevious.ForeColor = Color.Black;
            Button_IndexPrevious.Font.Name = "΢���ź�";
            Button_IndexPrevious.Click += new EventHandler(PageButtonClick);

            Button_IndexLast.Text = "��ĩҳ ";
            Button_IndexLast.CommandName = "last";
            Button_IndexLast.ForeColor = Color.Black;
            Button_IndexLast.Font.Name = "΢���ź�";
            Button_IndexLast.Click += new EventHandler(PageButtonClick);

            label_Index.Text = "|��ǰΪ��" + (gvOrderList.PageIndex + 1) + "ҳ,����" + ((GridView)sender).PageCount + "ҳ";
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

    #region items��ҳ
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
        #region ��ҳ��
        if (e.Row.RowType == DataControlRowType.Pager)
        {
            Label label_Index = new Label();
            LinkButton Button_IndexFirst = new LinkButton();
            LinkButton Button_IndexLast = new LinkButton();
            LinkButton Button_IndexNext = new LinkButton();
            LinkButton Button_IndexPrevious = new LinkButton();
            label_Index.Font.Name = "΢���ź�";
            label_Index.Font.Size = 8;
            Button_IndexFirst.Font.Size = 8;
            Button_IndexLast.Font.Size = 8;
            Button_IndexNext.Font.Size = 9;
            Button_IndexPrevious.Font.Size = 9;

            Button_IndexFirst.Text = "��һҳ ";
            Button_IndexFirst.CommandName = "first";
            Button_IndexFirst.ForeColor = Color.Black;
            Button_IndexFirst.Font.Name = "΢���ź�";
            Button_IndexFirst.Click += new EventHandler(PageButtonClick2);

            Button_IndexNext.Text = "   ��һҳ ";
            Button_IndexNext.CommandName = "next";
            Button_IndexNext.ForeColor = Color.Black;
            Button_IndexNext.Font.Name = "΢���ź�";
            Button_IndexNext.Click += new EventHandler(PageButtonClick2);

            Button_IndexPrevious.Text = "ǰһҳ ";
            Button_IndexPrevious.CommandName = "previous";
            Button_IndexPrevious.ForeColor = Color.Black;
            Button_IndexPrevious.Font.Name = "΢���ź�";
            Button_IndexPrevious.Click += new EventHandler(PageButtonClick2);

            Button_IndexLast.Text = "��ĩҳ ";
            Button_IndexLast.CommandName = "last";
            Button_IndexLast.ForeColor = Color.Black;
            Button_IndexLast.Font.Name = "΢���ź�";
            Button_IndexLast.Click += new EventHandler(PageButtonClick2);

            label_Index.Text = "|��ǰΪ��" + (gvItemList.PageIndex + 1) + "ҳ,����" + ((GridView)sender).PageCount + "ҳ";
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

    #region �����б����ݰ�
    public bool mainOrderDatabind()
    {
        IList<OrderInfo> orderInfoList = new List<OrderInfo>();
        shipping = new LogisticsInfoBLL();
        //��ȡ��Ҫ��ʾ�Ķ����б�(����������ID)
        if (!shipping.SrchOrderListByManagerID(ref orderInfoList, new Guid("1ac90496-d3e0-4141-9d3c-5898e0941474")))//(Guid)Membership.GetUser().ProviderUserKey)) 
        {
            return false;
        }
        //���ݶ����б��е�IDֵ��ȡ����������������Ϣ�Ķ����б�
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
            lError.Text = "û�п�����ʾ�Ķ���";
            return true;
        }
        gvOrderList.DataSource = orderInfoList;
        gvOrderList.DataBind();
        return true;
    }
    #endregion

    #region ������ϸ��Ϣ���ݰ�
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
            lError.Text = "��ǰ���������ڻ��ѱ�����";
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
                state = "�ȴ�����";
                if (Convert.ToInt32(items.Rows[0]["isPaid"].ToString()) == 0)
                {
                    state += "����������";
                    cPicking.Visible = true;
                }
                else
                {
                    state += "�������Ѹ�";
                    cPicking.Visible = true;
                }
                break;
            case 1:
                state = "�ȴ�����";
                //imgbPay.Visible = true;
                if (Convert.ToInt32(items.Rows[0]["isPaid"].ToString()) == 0)
                {
                    //bCancel.Visible = true;
                }
                break;
            case 2:
                state = "�ȴ��ջ�ȷ��";
                //bConfirm.Visible = true;
                break;
            case 3:
                state = "�������";
                //bReturn.Visible = true;
                break;
            case 4:
                state = "�����˻�";
                cReturn.Visible = true;
                rReturn.Visible = true;
                break;
        }
        lState.Text = state;
        return true;
    }
    #endregion
}
