<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListAdmin.aspx.cs" Inherits="Management_ListAdmin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>����Ա�б�</title>
    <link rel="stylesheet" type="text/css" href="bgStyle.css" />
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
           <th width="100%" height="25px" class="tableHeaderText">����Ա�б�</th>
           </tr>
         </table>
         <div align="center">
           <asp:GridView ID="AdminList" runat="server" AutoGenerateColumns="False" 
           DataKeyNames="AdminID" OnRowEditing="AdminList_RowEditing" OnRowCancelingEdit="AdminList_RowCancelingEdit" OnRowUpdating="AdminList_RowUpdating" OnRowDeleting="AdminList_RowDeleting" AllowPaging="True" OnPageIndexChanging="AdminList_PageIndexChanging" Width="790px">
           <Columns>
            <asp:BoundField DataField="AdminName" HeaderText="����Ա��" ReadOnly="True" />
            <asp:TemplateField HeaderText="����">
                <EditItemTemplate>
                        <asp:DropDownList ID="ddlAdminType" runat="server">
                        <asp:ListItem Value="0">��Ʒ����</asp:ListItem>
                        <asp:ListItem Value="1">�г�����</asp:ListItem>
                        <asp:ListItem Value="2">���¹���</asp:ListItem>
                        <asp:ListItem Value="3">������</asp:ListItem>
                    </asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblAdminType" runat="server" Text="<%# Bind('AdminType') %>"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="State" HeaderText="�ʺ�״̬" ReadOnly="True" />
            <asp:BoundField DataField="AddTime" HeaderText="���ʱ��" ReadOnly="True" />
            <asp:ButtonField Text="ɾ��" CommandName="Delete" />
            <asp:CommandField CancelText="ȡ��" DeleteText="ɾ��" EditText="ְ�����" InsertText="����"
                NewText="�½�" SelectText="ѡ��" ShowEditButton="True" UpdateText="����" />
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
