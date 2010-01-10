using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

public partial class Default2 : Page
{
    private int conditionVal = -1;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            AgeGroupPan.Visible = TimeGapPan.Visible = false;
        }
    }


    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        conditionVal = Condition.SelectedIndex;

        switch (conditionVal)
        {
            case 0:
                AgeGroupPan.Visible = TimeGapPan.Visible = false;
                break;

            case 1:

                AgeGroupPan.Visible = true;
                TimeGapPan.Visible = false;
                cleanupControls();
                break;
            case 2:
                AgeGroupPan.Visible = true;
                TimeGapPan.Visible = true;
                cleanupControls();
                break;
            case 3:
                AgeGroupPan.Visible = false;
                TimeGapPan.Visible = true;
                cleanupControls();
                break;
        }
    }


    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        int val = drpAgeGapNum.SelectedIndex;

        for (int i = 1; i <= val; i++)
        {
            Page.FindControl("line" + i).Visible = true;
        }

        for (int i = val + 1; i <= 4; i++)
        {
            Page.FindControl("line" + i).Visible = false;
        }

        #region 用编程的方式向agePan添加textbox

        //Unit unit = new Unit(30);

        //unit.Type = UnitType.Pixel;
        ////drawing input fields line by line
        //for (int i = 1; i <= val; i++)
        //{
        //    //add a breakline
        //    Literal lt = new Literal();
        //    lt.Text = "</br>";
        //    lt.ID = "lt" + i;
        //    lt.Mode = LiteralMode.PassThrough;

        //    //display text
        //    AgeGroupPan.Controls.Add(lt);
        //    Label lb = new Label();
        //    lb.Text = "第" + i + "组";

        //    //creating testboxes one by one
        //    AgeGroupPan.Controls.Add(lb);
        //    TextBox tb = new TextBox();
        //    tbList.Add(tb);
        //    tb.Width = unit;
        //    tb.MaxLength = 3;
        //    //calculating textbox IDs
        //    tb.ID = "tbx" + 2 * (i - 1);
        //    AgeGroupPan.Controls.Add(tb);
        //    //label
        //    Label lb2 = new Label();
        //    lb2.Text = "岁到";
        //    AgeGroupPan.Controls.Add(lb2);
        //    //textbox 
        //    TextBox tb2 = new TextBox();
        //    tbList.Add(tb2);
        //    tb2.Width = unit;
        //    tb2.MaxLength = 3;
        //    tb2.ID = "tbx" + (2 * (i - 1) + 1);
        //    AgeGroupPan.Controls.Add(tb2);
        //    Label lb3 = new Label();
        //    lb3.Text = "岁";
        //    AgeGroupPan.Controls.Add(lb3);


        //    //add some CompareValidators,one per line
        //    CompareValidator cv = new CompareValidator();
        //    cv.ErrorMessage = "sameLine";
        //    Page.Validators.Add(cv);
        //    AgeGroupPan.Controls.Add(cv);
        //    cv.ID = "sameLine" + i;
        //    cv.ControlToValidate = tb2.ID;
        //    cv.ControlToCompare = tb.ID;
        //    cv.Operator = ValidationCompareOperator.GreaterThanEqual;
        //    //TODO how to display error??

        //    //if its not the first line, compare the second tbx with the first tbx of previous line
        //    if (i > 1)
        //    {

        //        CompareValidator cv1 = new CompareValidator();

        //        Page.Validators.Add(cv1);
        //        AgeGroupPan.Controls.Add(cv1);
        //        cv1.ID = "diffLine" + i;
        //        cv1.ControlToValidate = tbList[2 * i - 1].ID;
        //        cv1.ControlToCompare = tbList[2 * i - 2].ID;
        //        cv1.ErrorMessage = "diffLine";
        //        cv.Operator = ValidationCompareOperator.GreaterThan;
        //        Response.Write(tbList.Count);
        //        //TODO how to display error??
        //    }

        //}

        #endregion
    }

    protected void Button1_Click1(object sender, EventArgs e)
    {
        Response.Write("hi");

        int gapNum = drpAgeGapNum.SelectedIndex;
        int condition = Condition.SelectedIndex;
        Condition.SelectedIndex = 0;

        switch (condition)
        {
            case 0:
                break;
            case 1:
                FindAgeGap(gapNum);
                Response.Redirect("MemberReport.aspx");
                break;
            case 2:
                FindAgeGap(gapNum);
                FindTimeGap();
                Response.Redirect("MemberSalesReport.aspx");
                break;
            case 3:
                FindTimeGap();
                Response.Redirect("GoodsSalesReport.aspx");
                break;
            default:
                break;
        }


        cleanupControls();
        AgeGroupPan.Visible = TimeGapPan.Visible = false;
    }

    #region 不太重要

    private void cleanupControls()
    {
        //cleanup textboxes
        drpAgeGapNum.SelectedIndex = 0;

        //((DropDownList)Page.FindControl("drpAgeGapNum")).SelectedIndex = 0;
        tbxStartingMonth.Text = tbxStrartingYear.Text = tbxEndingMonth.Text = tbxEndingYear.Text = "";


        ((TextBox) Page.FindControl("tbxStrartingYear")).Text = "";
        ((TextBox) Page.FindControl("tbxEndingYear")).Text = "";
        ((TextBox) Page.FindControl("tbxStartingMonth")).Text = "";
        ((TextBox) Page.FindControl("tbxEndingMonth")).Text = "";

        //cleanup pannels in AgeGroupPan,and set the value tobe ""
        for (int i = 1; i <= 4; i++)
        {
            Page.FindControl("line" + i).Visible = false;
            ((TextBox) Page.FindControl("tbx" + i + 1)).Text = "";
            ((TextBox) Page.FindControl("tbx" + i + 2)).Text = "";
        }
    }

    private void FindAgeGap(int gapNum)
    {
        Session.Remove("ageGapsList");
        List<AgeGap> list = new List<AgeGap>();
        AgeGap gap;
        //从年龄段获取整数
        for (int i = 1; i <= gapNum; i++)
        {
            gap = new AgeGap();
            gap.SAge = Convert.ToInt32(((TextBox) Page.FindControl("tbx" + i + 1)).Text);
            gap.EAge = Convert.ToInt32(((TextBox) Page.FindControl("tbx" + i + 2)).Text);

            list.Add(gap);
        }

        Session.Add("ageGapsList", list);
    }

    private void FindTimeGap()
    {
        Session.Remove("timeList");
        List<Int32> timeList = new List<Int32>();
        //从时间段获取整数
        timeList.Add(Convert.ToInt32(tbxStrartingYear.Text));
        timeList.Add(Convert.ToInt32(tbxStartingMonth.Text));
        timeList.Add(Convert.ToInt32(tbxEndingYear.Text));
        timeList.Add(Convert.ToInt32(tbxEndingMonth.Text));

        Session.Add("timeList", timeList);
    }

    #endregion
}