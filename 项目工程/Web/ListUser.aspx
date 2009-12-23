<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListUser.aspx.cs" Inherits="ListUser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    <asp:GridView ID="UserList" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="UserID" OnRowDeleting="UserList_RowDeleting" OnRowEditing="UserList_RowEditing" AllowPaging="True" OnPageIndexChanging="UserList_PageIndexChanging">
        <Columns>
            <asp:BoundField DataField="UserName" HeaderText="用户名" />
            <asp:BoundField DataField="Score" HeaderText="用户积分" />
            <asp:BoundField DataField="Level" HeaderText="用户级别" />
            <asp:BoundField DataField="State" HeaderText="用户状态" />
            <asp:BoundField DataField="RegTime" HeaderText="注册时间" />
            <asp:ButtonField Text="状态变更" CommandName="Edit"/>
            <asp:ButtonField Text="删除" CommandName="Delete" />
        </Columns>
    </asp:GridView>
    </form>
</body>
</html>
