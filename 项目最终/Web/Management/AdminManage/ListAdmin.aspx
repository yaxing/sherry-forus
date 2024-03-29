<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListAdmin.aspx.cs" Inherits="Management_ListAdmin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>管理员列表</title>
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
           <th width="100%" height="25px" class="tableHeaderText">管理员列表</th>
           </tr>
         </table>
         <div align="center">
           <asp:GridView ID="AdminList" runat="server" AutoGenerateColumns="False" 
           DataKeyNames="AdminID" OnRowEditing="AdminList_RowEditing" OnRowCancelingEdit="AdminList_RowCancelingEdit" OnRowUpdating="AdminList_RowUpdating" OnRowDeleting="AdminList_RowDeleting" AllowPaging="True" OnPageIndexChanging="AdminList_PageIndexChanging" Width="790px">
           <Columns>
            <asp:BoundField DataField="AdminName" HeaderText="管理员名" ReadOnly="True" />
            <asp:TemplateField HeaderText="类型">
                <EditItemTemplate>
                        <asp:DropDownList ID="ddlAdminType" runat="server">
                        <asp:ListItem Value="0">商品管理</asp:ListItem>
                        <asp:ListItem Value="1">市场管理</asp:ListItem>
                        <asp:ListItem Value="2">人事管理</asp:ListItem>
                        <asp:ListItem Value="3">管理经理</asp:ListItem>
                    </asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblAdminType" runat="server" Text="<%# Bind('AdminType') %>"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="State" HeaderText="帐号状态" ReadOnly="True" />
            <asp:BoundField DataField="AddTime" HeaderText="添加时间" ReadOnly="True" />
            <asp:ButtonField CommandName="Delete" HeaderText="删除" ImageUrl="../images/delete.png" ButtonType="Image" />
            <asp:CommandField CancelText="取消" DeleteText="删除" EditText="职务调整" InsertText="插入"
                NewText="新建" SelectText="选中" ShowEditButton="True" UpdateText="更新" ButtonType="Image" EditImageUrl="../images/change.png" HeaderText="职务调整" CancelImageUrl="../images/delete.png" UpdateImageUrl="../images/update.png" />
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
