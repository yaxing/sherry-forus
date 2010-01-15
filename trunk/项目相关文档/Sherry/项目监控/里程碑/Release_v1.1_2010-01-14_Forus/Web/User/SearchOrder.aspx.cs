////��д�ߣ�������
////��  �ڣ�2010-01-11
////��  �ܣ��û���������
using System;
using System.Data;
using System.Web.UI.WebControls;
using System.Drawing;
using BLL;
using Entity;
using InterFace;
using System.Collections.Generic;
using System.Web;

public partial class SearchOrder : System.Web.UI.Page
{
    OrderCtrlBLL orderCtrl;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.User.Identity.Name.Length == 0)
        {
            Response.Write("<script>location.href('/Web/Index.aspx');</script>");
            return;
        }
        tbDateStart.Attributes.Add("OnClick", bChooseStartDate.ClientID + ".click()");
        tbDateEnd.Attributes.Add("OnClick", bChooseEndDate.ClientID + ".click()");
        if (!IsPostBack) 
        {
            calenderDateStart.Visible = false;
            calenderDateEnd.Visible = false;
            gvSrchResult.AllowPaging = true;
            gvSrchResult.PageSize = 10;
        }
    }
    #region ����������ݰ�
    public bool srchResultDatabind()
    {

        DateTime dateStart = DateTime.Today;
        DateTime dateEnd = DateTime.Today;
        if (calenderDateStart.SelectedDate != null)
        {
            dateStart = calenderDateStart.SelectedDate;
        }
        if (calenderDateEnd.SelectedDate != null)
        {
            dateEnd = calenderDateEnd.SelectedDate;
        }
        if (dateStart == dateEnd)
        {
            dateEnd = dateStart.AddDays(1);
        }
        else if (dateStart > dateEnd)
        {
            return false;
        }
        IList<OrderInfo> orders = new List<OrderInfo>();

        orderCtrl = new OrderCtrlBLL();
        pError.Visible = false;
        if (!orderCtrl.GetOrdersByTime(ref orders, dateStart, dateEnd))
        {
            return false;
        }
        if (orders.Count <= 0)
        {
            pSrch.Visible = false;
            pError.Visible = true;
            lError.Text = "ָ��������û�ж���";
            return true;
        }
        else
        {
            pSrch.Visible = true;
            pError.Visible = false;
        }
        gvSrchResult.DataSource = orders;
        gvSrchResult.DataBind();

        return true;
    }
    #endregion

    #region ���������ҳ
    #region PageIndexChanging
    protected void gvSrchResult_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvSrchResult.PageIndex = e.NewPageIndex;
        srchResultDatabind();

    }
    #endregion

    protected void gvSrchResult_RowCreated(object sender, GridViewRowEventArgs e)
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
            Button_IndexFirst.Click += new EventHandler(PageButtonClick3);

            Button_IndexNext.Text = "   ��һҳ ";
            Button_IndexNext.CommandName = "next";
            Button_IndexNext.ForeColor = Color.Black;
            Button_IndexNext.Font.Name = "΢���ź�";
            Button_IndexNext.Click += new EventHandler(PageButtonClick3);

            Button_IndexPrevious.Text = "ǰһҳ ";
            Button_IndexPrevious.CommandName = "previous";
            Button_IndexPrevious.ForeColor = Color.Black;
            Button_IndexPrevious.Font.Name = "΢���ź�";
            Button_IndexPrevious.Click += new EventHandler(PageButtonClick3);

            Button_IndexLast.Text = "��ĩҳ ";
            Button_IndexLast.CommandName = "last";
            Button_IndexLast.ForeColor = Color.Black;
            Button_IndexLast.Font.Name = "΢���ź�";
            Button_IndexLast.Click += new EventHandler(PageButtonClick3);

            label_Index.Text = "|��ǰΪ��" + (gvSrchResult.PageIndex + 1) + "ҳ,����" + ((GridView)sender).PageCount + "ҳ";
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


    protected void PageButtonClick3(object sender, EventArgs e)
    {
        LinkButton clickedButton = ((LinkButton)sender);
        if (clickedButton.CommandName == "first")
        {
            gvSrchResult.PageIndex = 0;
        }
        else if (clickedButton.CommandName == "next")
        {
            if (gvSrchResult.PageIndex < gvSrchResult.PageCount - 1)
            {
                gvSrchResult.PageIndex += 1;
            }
        }
        else if (clickedButton.CommandName == "previous")
        {
            if (gvSrchResult.PageIndex >= 1)
            {
                gvSrchResult.PageIndex -= 1;
            }
        }
        else if (clickedButton.CommandName == "last")
        {
            gvSrchResult.PageIndex = gvSrchResult.PageCount - 1;
        }
        srchResultDatabind();
    }
    #endregion 

    protected void bChooseStartDate_Click(object sender, EventArgs e)
    {
        calenderDateStart.Visible = true;
        calenderDateEnd.Visible = false;
    }
    protected void bChooseEndDate_Click(object sender, EventArgs e)
    {
        calenderDateEnd.Visible = true;
        calenderDateStart.Visible = false;
    }
    protected void calenderDateStart_SelectionChanged(object sender, EventArgs e)
    {
        tbDateStart.Text = calenderDateStart.SelectedDate.ToString("d");
        calenderDateStart.Visible = false;
    }
    protected void calenderDateEnd_SelectionChanged(object sender, EventArgs e)
    {
        tbDateEnd.Text = calenderDateEnd.SelectedDate.ToString("d");
        calenderDateEnd.Visible = false;
    }
    protected void bSrch_Click(object sender, EventArgs e)
    {
        if (!srchResultDatabind())
        {
            Response.Write("<script>alert('���ݴ�����ȷ������ѡ����ȷ��');history.go(-1);</script>");
        }
        return;
    }
}
