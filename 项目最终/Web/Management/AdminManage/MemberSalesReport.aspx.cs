using System;
using System.Collections.Generic;
using System.Web.UI;
using BLL;
using Microsoft.Reporting.WebForms;
using Report=BLL.Report;

public partial class Management_MemberSalesReport : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        //check Session params
        if (Session["timeList"] == null || Session["ageGapsList"] == null)
            Response.Redirect("MarketDecision.aspx");

        // SetParameters
        List<int> timeList = (List<int>) Session["timeList"];
        int sYear = timeList[0];
        int sMonth = timeList[1];
        int eYear = timeList[2];
        int eMonth = timeList[3];

        List<ReportParameter> paras = new List<ReportParameter>();
        paras.Add(new ReportParameter("sDate", sYear + "年" + sMonth + "月"));
        paras.Add(new ReportParameter("eDate", eYear + "年" + eMonth + "月"));
        ReportViewer1.LocalReport.SetParameters(paras);

        //set report datasource
        List<AgeGap> ageList = (List<AgeGap>) Session["ageGapsList"];
        MemberSalesReportBLL msr = new MemberSalesReportBLL();
        Report.MemberSalesReportDataTable dt = msr.MemberSalesReportDT(ageList, timeList);
        ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Report_MemberSalesReport", dt));

        ReportViewer1.LocalReport.Refresh();
    }
}