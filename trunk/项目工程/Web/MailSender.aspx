<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MailSender.aspx.cs" Inherits="MailSender" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>�����ʼ�</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <table>
        <tr onmousemove="javascript:this.bgColor='#ccddee';" onmouseout="javascript:this.bgColor='#ffffff';">
          <td>
              <asp:Label ID="lblToMailAdd" runat="server" Text="�ռ���:"></asp:Label>
          </td>
          <td style="width: 188px">
              <asp:TextBox ID="txtToMailAdd" runat="server"></asp:TextBox>
          </td>
        </tr>
        <tr onmousemove="javascript:this.bgColor='#ccddee';" onmouseout="javascript:this.bgColor='#ffffff';">
          <td>
              <asp:Label ID="lblSub" runat="server" Text="����:"></asp:Label>
          </td>
          <td style="width: 188px">
              <asp:TextBox ID="txtSub" runat="server"></asp:TextBox>
          </td>
        </tr>
        <tr onmousemove="javascript:this.bgColor='#ccddee';" onmouseout="javascript:this.bgColor='#ffffff';">
          <td style="height: 70px">
              <asp:Label ID="lblContext" runat="server" Text="�ʼ�����:"></asp:Label>
          </td>
          <td style="width: 188px; height: 70px">
              <asp:TextBox ID="txtContext" runat="server" Height="150px" TextMode="MultiLine" Width="365px"></asp:TextBox>
          </td>
        </tr>
        <tr onmousemove="javascript:this.bgColor='#ccddee';" onmouseout="javascript:this.bgColor='#ffffff';">
          <td align="right" colspan="2">
              <asp:Button ID="btnSend" runat="server" Text="����" OnClick="btnSend_Click" /></td>
        </tr>
      </table>
    
    </div>
    </form>
</body>
</html>
