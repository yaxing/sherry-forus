<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddPoll.aspx.cs" Inherits="AddPoll" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table>
        <tr>
            <td>�������⣺</td>
            <td align="left"><asp:TextBox ID="topic" runat="server" Width="300px"  ></asp:TextBox>
            <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" Display="Dynamic" ControlToValidate="topic"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>ѡ��������</td>
            <td align="left">
                <asp:DropDownList ID="selectNum" runat="server" AutoPostBack="True">
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                    <asp:ListItem>6</asp:ListItem>
                    <asp:ListItem>7</asp:ListItem>
                    <asp:ListItem>8</asp:ListItem>
                    <asp:ListItem>9</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:PlaceHolder ID="options" runat="server"></asp:PlaceHolder>
            </td>
        </tr>
        <tr>
            <td>ѡ��ģʽ��</td>
            <td align="left">
                <asp:RadioButtonList ID="selectPattern" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Selected="True">��ѡ</asp:ListItem>
                    <asp:ListItem>��ѡ</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td>ͼ�θ�ʽ��</td>
            <td align="left">
                <asp:RadioButtonList ID="picStyle" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Selected="True">��״ͼ</asp:ListItem>
                    <asp:ListItem>��״ͼ</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="addVote" runat="server" Text="ȷ��" OnClick="addVote_Click"/></td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
