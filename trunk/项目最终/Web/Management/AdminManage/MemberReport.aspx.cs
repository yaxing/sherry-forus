using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using BLL;
using Microsoft.Reporting.WebForms;
using Report=BLL.Report;

public partial class Management_MemberReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Session param checking
        if(Session["ageGapsList"]==null)
            Response.Redirect("MarketDecision.aspx");

        MemberReportBLL bll=new MemberReportBLL();
        List<AgeGap> ageList = (List<AgeGap>) Session["ageGapsList"];
        Report.MemberReportDataTable dt = bll.MembersAgeGroupDT(ageList);
        ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Report_MemberReport",dt));
        ReportViewer1.LocalReport.Refresh();
    }
}
