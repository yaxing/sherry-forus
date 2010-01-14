<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BgLogin.aspx.cs" Inherits="Management_BgLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Sherry��ױƷ�������۹���ϵͳ</title>
    <link rel="stylesheet" type="text/css" href="Style.css"/>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center" style="background-color:#bbb">
      <div class="login" align="left">
      <div class="logo">
          <h1><font face="΢���ź�">Sherry��ױƷ</font></h1>
          <h1><font face="΢���ź�">�������������������۹���ϵͳ</font></h1>
      </div>
      <div class="lform">
        <asp:Login ID="BgLogin" runat="server" OnLoggedIn="BgLogin_LoggedIn">
            <LayoutTemplate>
                <table border="0" cellpadding="1" cellspacing="0" style="border-collapse: collapse">
                    <tr>
                        <td>
                            <table border="0" cellpadding="0">
                                
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">�û���:</asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="UserName" runat="server" Width="156px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                            ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="BgLogin">*</asp:RequiredFieldValidator>
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">�ܡ���:</asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="Password" runat="server" TextMode="Password" Width="156px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                            ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="BgLogin">*</asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="��½" ValidationGroup="BgLogin" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="2">
                                        
                                    </td>
                                    <td align="left" colspan="2" style="color: red">
                                        <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                    </td>
                                    <td></td>
                                </tr>
                                
                            </table>
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>
        </asp:Login>
      </div>
      </div>
    </div>
    </form>
</body>
</html>
