<%@ Page Language="C#" MasterPageFile="~/IndexMaster.master" AutoEventWireup="true" CodeFile="ModiUser.aspx.cs" Inherits="ModiUser" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentHolder" Runat="Server">
    <table border="0">
        <tr>
            <td align="center" colspan="2">
                修改用户信息</td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="UserNameLabel" runat="server">用户名:</asp:Label>
            </td>
            <td>
                <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
                
            </td>
        </tr>       
        <tr>
            <td align="right">
                <asp:Label ID="lblRealName" runat="server" Text="真实姓名:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtRealName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">电子邮件:</asp:Label>
            </td>
            <td>
                <asp:TextBox ID="Email" runat="server"></asp:TextBox>                
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblPostAdd" runat="server" Text="邮寄地址:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtPostAdd" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblPostNum" runat="server" Text="邮政编码:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtPostNum" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblPhoneNum" runat="server" Text="电话号码:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtPhoneNum" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblUserBirth" runat="server" Text="出生日期:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtUserBirth" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblUserGender" runat="server" Text="性别:"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlUserGender" runat="server">
                    <asp:ListItem Value="0">保密</asp:ListItem>
                    <asp:ListItem Value="1">男</asp:ListItem>
                    <asp:ListItem Value="2">女</asp:ListItem>
                    <asp:ListItem Value="3">春哥</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblIDCardNum" runat="server" Text="身份证号:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtIDCardNum" runat="server"></asp:TextBox>
            </td>
        </tr>   
        <tr>
            <td colspan="2">
                <asp:Button ID="submit" runat="server" Text="提交保存" onclick="submit_Click" /></td>
        </tr>     
    </table>
</asp:Content>

