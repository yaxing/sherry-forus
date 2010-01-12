<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangeGoods.aspx.cs" Inherits="ChangeGoods" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>�޸Ĳ�Ʒ��Ϣ</title>
</head>
<body>
    <form id="form1" runat="server">
    <table>
        <tr>
            <td>
                ��Ʒ����</td>
            <td>
                <asp:TextBox ID="GoodsName" runat="server" CausesValidation="true"></asp:TextBox>
                <asp:RequiredFieldValidator ID="GoodsNameRequired" runat="server" ErrorMessage="��Ʒ���Ʊ�����д" ControlToValidate="GoodsName"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>
                ��Ʒ���</td>
            <td>
                <asp:TextBox ID="GoodsNum" runat="server" CausesValidation="true"></asp:TextBox>
                <asp:RequiredFieldValidator ID="GoodsNumRequired" runat="server" ErrorMessage="��Ʒ��ű�����д" ControlToValidate="GoodsNum"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>
                ��Ʒ���</td>
            <td>
                <asp:ListBox ID="GoodsCategory" runat="server" Rows="1">
                    <asp:ListItem Value="1">�沿����</asp:ListItem>
                    <asp:ListItem Value="2">�ֲ�����</asp:ListItem>
                    <asp:ListItem Value="3">���廤��</asp:ListItem>
                    <asp:ListItem Value="4">�㷢����</asp:ListItem>
                    <asp:ListItem Value="5">�۲�����</asp:ListItem>
                    <asp:ListItem Value="6">��������</asp:ListItem>
                    <asp:ListItem Value="7">����</asp:ListItem>
                    <asp:ListItem Value="8">��ˮ</asp:ListItem>
                    <asp:ListItem Value="9">��ױ</asp:ListItem>
                    <asp:ListItem Value="10">�㾫/����/��ˮ</asp:ListItem>
                    <asp:ListItem Value="11">��������</asp:ListItem>
                </asp:ListBox></td>
        </tr>
        <tr>
            <td>
                ��ƷͼƬ</td>
            <td>
                <asp:FileUpload ID="GoodsImg" runat="server" /></td>
        </tr>
        <tr>
            <td>
                ��Ʒ��Ч����</td>
            <td>
                <asp:TextBox ID="Year" runat="server" Width="30" Text="2"></asp:TextBox>��
                <asp:TextBox ID="Month" runat="server" Width="15"></asp:TextBox>��
                <asp:TextBox ID="Day" runat="server" Width="15"></asp:TextBox>�գ�����ʱ�䣩</td>
        </tr>
        <tr>
            <td>
                ��Ʒ����</td>
            <td>
               <asp:TextBox ID="GoodsPrice" runat="server"></asp:TextBox>��Ԫ��</td>
        </tr>
        <tr>
            <td>
                ��Ʒ���</td>
            <td>
                <asp:TextBox ID="GoodsStorage" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                ��Ʒ���¼�״̬</td>
            <td>
            <asp:RadioButtonList ID="GoodsAvailable" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Text="�ϼ�״̬" Value="true" />
                <asp:ListItem Text="�¼�״̬" Value="false" Selected="True" />
            </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>
                ��Ʒ����</td>
            <td>
                <asp:TextBox ID="GoodsDescribe" runat="server" TextMode="MultiLine" Height="200" Width="300" /></td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Button CssClass="register" ID="ChangeCommit" OnClick="ChangeGoodsCommit" runat="server" Text="ȷ���޸�" /></td>
        </tr>
    </table>
    <div style="text-align:center; color:Red"><asp:Label ID="ChangeResult" runat="server"/></div>
    </form>
</body>
</html>
