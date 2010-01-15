using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

public partial class Default2 : Page
{
    private int ConditionVal = -1;

    protected void Page_Load(object sender, EventArgs e)
    {
        eYearRangeVali.MaximumValue = sYearRangeVali.MaximumValue = "" + DateTime.Now.Year;
        eYearRangeVali.MinimumValue = sYearRangeVali.MinimumValue = "" + 1753;
        eYearRangeVali.ErrorMessage = sYearRangeVali.ErrorMessage = "起始年份范围应在1753到" + DateTime.Now.Year + "之间";
        eMonthRangeVali.ErrorMessage = sMonthRangeVali.ErrorMessage = "月份的取值范围应在1到12之间";


        //页面载入时执行一次
        if (!Page.IsPostBack)
        {

            Button1.Enabled = false;
            
            AgeGroupPan.Visible = TimeGapPan.Visible = false;
        }
    }

    /// <summary>
    /// 重点选择器，用编程方式控制Visible
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        ConditionVal = Condition.SelectedIndex;

        switch (ConditionVal)
        {
            //请选择
            case 0:
                AgeGroupPan.Visible = TimeGapPan.Visible = false;
                Button1.Enabled = false;
                break;
            //会员数
            case 1:
                Button1.Enabled = true;
                AgeGroupPan.Visible = true;                
                TimeGapPan.Visible = false;
                cleanupControls();
                displayAgepanContents(1);
                break;
            //各年龄段用户群消费额
            case 2:
                Button1.Enabled = true;
                AgeGroupPan.Visible = true;                
                TimeGapPan.Visible = true;
                cleanupControls();
                displayAgepanContents(1);
                break;
            //各类商品销售额
            case 3:
                Button1.Enabled = true;
                AgeGroupPan.Visible = false;
                TimeGapPan.Visible = true;
                cleanupControls();
                break;
        }
    }

    /// <summary>
    /// 年龄段数目选择器，编程方式控制visible
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        int val = drpAgeGapNum.SelectedIndex;
        displayAgepanContents(val+1);

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

        int gapNum = drpAgeGapNum.SelectedIndex+1;
        int condition = Condition.SelectedIndex;
        Condition.SelectedIndex = 0;

        switch (condition)
        {
            case 0:
                break;
            case 1:
                FindAgeGap(gapNum);
                Response.Redirect("AdminManage/MemberReport.aspx");
                break;
            case 2:
                FindAgeGap(gapNum);
                FindTimeGap();
                Response.Redirect("AdminManage/MemberSalesReport.aspx");
                break;
            case 3:
                FindTimeGap();
                Response.Redirect("AdminManage/GoodsSalesReport.aspx");
                break;
            default:
                break;
        }


        cleanupControls();
        AgeGroupPan.Visible = TimeGapPan.Visible = false;
    }

    #region 不太重要

    private void displayAgepanContents(int val)
    {
        for (int i = 1; i <= val; i++)
        {
            Page.FindControl("line" + i).Visible = true;

        }

        for (int i = val + 1; i <= 4; i++)
        {
            Page.FindControl("line" + i).Visible = false;
        }

    } 


    /// <summary>
    /// 清空时间段输入框，年龄段输入框。   
    /// </summary>
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

    /// <summary>
    /// 取出需要的年龄段信息
    /// </summary>
    /// <param name="gapNum">年龄段组数</param>
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
    /// <summary>
    /// 取出需要的时间段信息
    /// </summary>
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