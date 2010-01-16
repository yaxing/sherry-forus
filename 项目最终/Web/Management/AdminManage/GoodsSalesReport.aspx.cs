////��д�ߣ�������
////��  �ڣ�2009-12-20
////��  ��: ���ñ�������Դ

using System;
using System.Collections.Generic;
using System.Web.UI;
using BLL;
using Microsoft.Reporting.WebForms;
using Report=BLL.Report;

public partial class Management_GoodsSalesReport : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        //session param cheking
        if(Session["timeList"]==null)
            Response.Redirect("MarketDecision.aspx");

        //set report param
        List<int> timeList = (List<int>) Session["timeList"];
        string sDate = timeList[0] + "��" + timeList[1] + "��";
        string eDate = timeList[2] + "��" + timeList[3] + "��";
        List<ReportParameter> paras = new List<ReportParameter>();
        paras.Add(new ReportParameter("sDate",sDate));
        paras.Add(new ReportParameter("eDate",eDate));
        ReportViewer1.LocalReport.SetParameters(paras);

        //set report datasource
        GoodsSalesReportBLL gsr = new GoodsSalesReportBLL();
        Report.GoodsSalesReportDataTable dt = gsr.GoodsSalesReportDT(timeList);
        ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Report_GoodsSalesReport", dt));
        ReportViewer1.LocalReport.Refresh();
    }
}