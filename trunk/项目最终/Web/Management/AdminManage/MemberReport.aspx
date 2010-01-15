<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MemberReport.aspx.cs" Inherits="Management_MemberReport" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>会员数量统计</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table cellspacing="1" cellpadding="3" width="790px" align="center" border="0">
           <tr>
             <td valign="top" width="100%">
               <p><br /></p>
             </td>
           </tr>
         </table>
         <table class="tableBorder" cellspacing="1" cellpadding="2" width="790px" align="center" border="0">
           <tr>
           <th width="100%" class="tableHeaderText" style="height: 25px">市场决策</th>
           </tr>
         </table>
         
         <div align="center">
         
        <rsweb:reportviewer id="ReportViewer1" runat="server" font-names="Verdana" font-size="8pt" Height="1000px" Width="600px"
            >
<LocalReport ReportPath="Management\MemberReport.rdlc">
</LocalReport>
</rsweb:reportviewer>
        &nbsp;
    
         
<table class="tableBorder" cellspacing="1" cellpadding="2" width="790px" align="center" border="0">
           <tr>
             <th width="100%" class="tableHeaderText" style="height: 25px">&nbsp;</th>
           </tr>
         </table>
    </div>
    </form>
</body>
</html>
