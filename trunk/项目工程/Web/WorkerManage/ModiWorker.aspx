<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ModiWorker.aspx.cs" Inherits="ModiWorker" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>�޸Ĺ�����Ա��Ϣ</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <table>
        <tr>
          <td>
              <asp:Label ID="lblName" runat="server" Text="��&nbsp;&nbsp;��&nbsp;&nbsp;��:"></asp:Label>
          </td>
          <td>
              <asp:Label ID="lblWorkerName" runat="server" Text=""></asp:Label>
          </td>
        </tr>
        <tr>
          <td>
              <asp:Label ID="lblReal" runat="server" Text="��ʵ����:"></asp:Label>
          </td>
          <td>
              <asp:Label ID="lblRealName" runat="server"></asp:Label></td>
        </tr>
        <tr>
          <td>
              <asp:Label ID="lblNum" runat="server" Text="��������:"></asp:Label></td>
          <td>
              <asp:Label ID="lblWorkerNum" runat="server"></asp:Label></td>
        </tr>
        <tr>
          <td>
              <asp:Label ID="lblShop" runat="server" Text="�ꡡ����:"></asp:Label></td>
          <td>
              <asp:DropDownList ID="DDLShop" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLShop_SelectedIndexChanged">
              </asp:DropDownList></td>
        </tr>
        <tr>
          <td>
              <asp:Label ID="lblLv" runat="server" Text="��������:"></asp:Label></td>
          <td>
              <asp:DropDownList ID="DDLWorkerLv" runat="server">
                  <asp:ListItem Value="0">������Ա</asp:ListItem>
                  <asp:ListItem Value="1">������</asp:ListItem>
              </asp:DropDownList></td>
        </tr>
        <tr>
          <td>
              <asp:Label ID="lblManager" runat="server" Text="��&nbsp;&nbsp;��&nbsp;&nbsp;��:"></asp:Label></td>
          <td>
              <asp:DropDownList ID="DDLManager" runat="server">
              </asp:DropDownList></td>
        </tr>
        <tr>
          <td>
              <asp:Label ID="lblEmail" runat="server" Text="��������:"></asp:Label></td>
          <td>
              <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
          <td>
              <asp:Label ID="lblPhone" runat="server" Text="�绰����:"></asp:Label></td>
          <td>
              <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
          <td>
              <asp:Label ID="lblState" runat="server" Text="����״̬:"></asp:Label></td>
          <td>
              <asp:Label ID="lblWorkerState" runat="server"></asp:Label></td>
        </tr>
        <tr>
          <td>
              <asp:Label ID="lblAccountS" runat="server" Text="�ʺ�״̬:"></asp:Label></td>
          <td>
              <asp:Label ID="lblAccountState" runat="server"></asp:Label></td>
        </tr>
        <tr>
          <td>
              <asp:Button ID="btnCommit" runat="server" Text="ȷ���޸�" OnClick="btnCommit_Click" />
          </td>
          <td>
              <asp:Button ID="btnCancel" runat="server" Text="ȡ���޸�" OnClick="btnCancel_Click" />
          </td>
        </tr>
      </table>
    </div>
    </form>
</body>
</html>
