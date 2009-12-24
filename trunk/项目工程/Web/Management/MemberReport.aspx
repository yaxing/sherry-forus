<%@ Page Language="C#" MasterPageFile="~/IndexMaster.master" AutoEventWireup="true" CodeFile="MemberReport.aspx.cs" Inherits="Management_MemberReport" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ContentPlaceHolderID="contentHolder" ID="MemberReportContent" runat="server">
    &nbsp; &nbsp;&nbsp;
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" Height="400px" Width="400px">
        <LocalReport ReportPath="Management\MemberReport.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="MemberReportLine" />
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="MemberReportLine1" />
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="MemberReportLine2" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
    &nbsp; &nbsp;
    &nbsp; &nbsp;
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetMemberReportLines"
        TypeName="BLL.MemberReportBLL">
        <SelectParameters>
            <asp:SessionParameter DefaultValue="null" Name="ageGaps" SessionField="ageGapsList"
                Type="Object" />
        </SelectParameters>
    </asp:ObjectDataSource>



</asp:Content>