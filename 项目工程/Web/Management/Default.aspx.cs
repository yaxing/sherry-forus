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
using Microsoft.Reporting.WebForms;
using BLL;

public partial class Management_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        //ÊµÀý»¯XSD 
        DataSet1.DataTable1DataTable dt;
        MemberReportBLL mrb = new MemberReportBLL();

        dt = mrb.pugetDS();
       
        

        //°ó¶¨
        ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1_DataTable1", dt));
        ReportViewer1.LocalReport.Refresh();
        
    }
}