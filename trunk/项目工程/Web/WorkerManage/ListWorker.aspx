<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListWorker.aspx.cs" Inherits="WorkerManage_ListWorker" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>������Ա�б�</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="WorkerList" runat="server" AutoGenerateColumns="False" DataKeyNames="WorkerID,WorkerLv,ManageID" OnRowDeleting="WorkerList_RowDeleting" OnRowEditing="WorkerList_RowEditing">
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
    </form>
</body>
</html>
