<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListWorker.aspx.cs" Inherits="WorkerManage_ListWorker" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>������Ա�б�</title>
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
           <th width="100%" height="25px" class="tableHeaderText">������Ա�б�</th>
           </tr>
         </table>
         
         <div align="center">
        <asp:GridView ID="WorkerList" runat="server" AutoGenerateColumns="False" DataKeyNames="WorkerID,WorkerLv,ManageID" OnRowDeleting="WorkerList_RowDeleting" OnRowEditing="WorkerList_RowEditing" AllowPaging="True" OnPageIndexChanging="WorkerList_PageIndexChanging" Width="790px">
            <Columns>
                <asp:BoundField DataField="WorkerName" HeaderText="������Ա��" />
                <asp:BoundField DataField="WorkerNum" HeaderText="����" />
                <asp:BoundField DataField="ShopName" HeaderText="��������" />
                <asp:BoundField DataField="WorkerType" HeaderText="ְ��" />
                <asp:BoundField DataField="WorkerWorkStat" HeaderText="��ǰ״̬" />
                <asp:BoundField DataField="AccountState" HeaderText="�˺�״̬" />
                <asp:BoundField DataField="WorkerLv" HeaderText="�����˱��" Visible="False" />
                <asp:ButtonField Text="����/����" CommandName="Delete" />
                <asp:ButtonField Text="�༭" CommandName="Edit" />
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
