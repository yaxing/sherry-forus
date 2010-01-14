<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MemberSalesReport.aspx.cs" Inherits="Management_MemberSalesReport" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <rsweb:reportviewer id="ReportViewer1" runat="server" font-names="Verdana" font-size="8pt">
<LocalReport ReportPath="Management\MemberSalesReport.rdlc"><DataSources>
<rsweb:ReportDataSource Name="MemberSalesReportLine" DataSourceId="ObjectDataSource1"></rsweb:ReportDataSource>
</DataSources>
</LocalReport>
</rsweb:reportviewer>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetMemberSalesReportLines"
            TypeName="BLL.MemberSalesReport">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="" Name="ageGaps" SessionField="ageGapsList" Type="Object" />
                <asp:SessionParameter DefaultValue="" Name="timeList" SessionField="timeList" Type="Object" />
            </SelectParameters>
        </asp:ObjectDataSource>
    
    </div>
    </form>
</body>
</html>
