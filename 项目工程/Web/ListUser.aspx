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
    <asp:GridView ID="UserList" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="UserRealName" HeaderText="用户名" />
        </Columns>
    </asp:GridView>
    </form>
</body>
</html>
