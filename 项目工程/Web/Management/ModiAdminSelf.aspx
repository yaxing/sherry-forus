<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ModiAdminSelf.aspx.cs" Inherits="Management_ModiAdminSelf" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>������Ϣ�޸�</title>
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
           <th width="100%" height="25px" class="tableHeaderText">������Ϣ�޸�</th>
           </tr>
         </table>
         
         
         <div align="center">
      <table>
        <tr>
          <td colspan="2" align="center">
            �𾴵�<asp:Label ID="lblType" runat="server" Text=""></asp:Label><asp:Label ID="lblAdminName" runat="server" Text=""></asp:Label>�����ã�
          </td>
        </tr>
        <tr>
          <td style="width: 71px">
             ��ʵ����:
          </td>
          <td style="width: 200px">
              <asp:TextBox ID="txtAdminRealName" runat="server"></asp:TextBox>
              <asp:RequiredFieldValidator ID="rfvRealName" runat="server" Display="Dynamic" ErrorMessage="����д������ʵ����"
                  ValidationGroup="modiAdmin" ControlToValidate="txtAdminRealName">*</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
          <td style="width: 71px">
             ��������:
          </td>
          <td style="width: 200px">
              <asp:TextBox ID="txtAdminEmail" runat="server"></asp:TextBox>
              <asp:RequiredFieldValidator ID="rfvEmail" runat="server" Display="Dynamic" ErrorMessage="����д��������"
                  ValidationGroup="modiAdmin" ControlToValidate="txtAdminEmail">*</asp:RequiredFieldValidator>
              <asp:RegularExpressionValidator ID="revEmail" runat="server" Display="Dynamic" ErrorMessage="���������ʽ����"
                  ValidationGroup="modiAdmin" ControlToValidate="txtAdminEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">x</asp:RegularExpressionValidator></td>
        </tr>
        <tr>
          <td style="width: 71px">
             �绰����:
          </td>
          <td style="width: 200px">
              <asp:TextBox ID="txtPhoneNum" runat="server"></asp:TextBox>
              <asp:RequiredFieldValidator ID="rfvPhoneNum" runat="server" Display="Dynamic" ErrorMessage="����д�绰����"
                  ValidationGroup="modiAdmin" ControlToValidate="txtPhoneNum">*</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
          <td colspan="2" align="center">
              <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List"
                  ValidationGroup="modiAdmin" />
          </td>
        </tr>
        <tr>
          <td colspan="2" align="right">
              <asp:Button ID="btnSub" runat="server" Text="ȷ���޸�" ValidationGroup="modiAdmin" OnClick="btnSub_Click" />
              <asp:Button ID="btnReset" runat="server" Text="����" OnClick="btnReset_Click" /></td>
        </tr>
      </table>
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
