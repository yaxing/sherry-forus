<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListWorker.aspx.cs" Inherits="WorkerManage_ListWorker" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>工作人员列表</title>
    <link rel="stylesheet" type="text/css" href="../bgStyle.css" />
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
           <th width="100%" height="25px" class="tableHeaderText">工作人员列表</th>
           </tr>
         </table>
         
         <div align="center">
        <asp:GridView ID="WorkerList" runat="server" AutoGenerateColumns="False" DataKeyNames="WorkerID,WorkerLv,ManageID" OnRowDeleting="WorkerList_RowDeleting" OnRowEditing="WorkerList_RowEditing" AllowPaging="True" OnPageIndexChanging="WorkerList_PageIndexChanging" Width="790px">
            <Columns>
                <asp:BoundField DataField="WorkerName" HeaderText="工作人员名" />
                <asp:BoundField DataField="WorkerNum" HeaderText="工号" />
                <asp:BoundField DataField="ShopName" HeaderText="所属店面" />
                <asp:BoundField DataField="WorkerType" HeaderText="职务" />
                <asp:BoundField DataField="WorkerWorkStat" HeaderText="当前状态" />
                <asp:BoundField DataField="AccountState" HeaderText="账号状态" />
                <asp:BoundField DataField="WorkerLv" HeaderText="负责人标记" Visible="False" />
                <asp:ButtonField Text="冻结/激活" CommandName="Delete" />
                <asp:ButtonField Text="编辑" CommandName="Edit" />
            </Columns>
        </asp:GridView>
         </div>
        
        <table class="tableBorder" cellspacing="1" cellpadding="2" width="790px" align="center" border="0">
           <tr>
             <th width="100%" class="tableHeaderText" style="height: 25px" />
           </tr>
         </table>
        
    </div>
    </form>
</body>
</html>
