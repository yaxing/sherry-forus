<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListUser.aspx.cs" Inherits="ListUser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>用户列表</title>
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
           <th width="100%" height="25px" class="tableHeaderText">用户列表</th>
           </tr>
         </table>
         <div align="center">
    <asp:GridView ID="UserList" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="UserID" OnRowDeleting="UserList_RowDeleting" OnRowEditing="UserList_RowEditing" AllowPaging="True" OnPageIndexChanging="UserList_PageIndexChanging" Width="790px">
        <Columns>
            <asp:BoundField DataField="UserName" HeaderText="用户名" />
            <asp:BoundField DataField="Score" HeaderText="用户积分" />
            <asp:BoundField DataField="Level" HeaderText="用户级别" />
            <asp:BoundField DataField="State" HeaderText="用户状态" />
            <asp:BoundField DataField="RegTime" HeaderText="注册时间" />
            <asp:ButtonField HeaderText="状态变更" Text="冻结/启用" CommandName="Edit"/>
            <asp:ButtonField HeaderText="删除" Text="删除" CommandName="Delete" />
        </Columns>
    </asp:GridView>
         </div>
         <table class="tableBorder" cellspacing="1" cellpadding="2" width="790px" align="center" border="0">
           <tr>
             <th width="100%" class="tableHeaderText" style="height: 25px">&nbsp;</th>
           </tr>
         </table>
    </div>
    </form>
</body>
</html>
