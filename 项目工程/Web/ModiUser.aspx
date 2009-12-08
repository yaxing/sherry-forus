<%@ Page Language="C#" MasterPageFile="~/IndexMaster.master" AutoEventWireup="true" CodeFile="ModiUser.aspx.cs" Inherits="ModiUser" Title="无标题页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentHolder" Runat="Server">
<div class="main float-l" style="width:600px;">
<div style="margin-left:20%">
    <table border="0">
        <tr style="height:45px;">
            <td align="center" colspan="4" valign="top">
                <font face="微软雅黑" size="normal">修改<asp:Label ID="lblName" runat="server" Text=""></asp:Label>的个人信息</font>
            </td>
        </tr>
        <tr>
            <td align="left" colspan="2">
                <div class="menu" style="font-family: 微软雅黑;">
                  <ul>
                    <li>
                      <a href="#">必要信息</a>
                    </li>
                  </ul>
                </div>
            </td>
            <td align="left" colspan="2">
                <div class="menu" style="font-family: 微软雅黑;">
                  <ul>
                    <li>
                      <a href="#">选填信息</a>
                    </li>
                  </ul>
                </div>
            </td>
            
        </tr>       
        <tr style="height:26px">
            <td align="right" style="width: 58px">
                <asp:Label ID="lblUserRealName" runat="server" Text="真实姓名:"></asp:Label>
            </td>
            <td style="width: 175px">
                <asp:TextBox ID="txtRealName" runat="server" MaxLength="50"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvRealName" runat="server" ControlToValidate="txtRealName"
                    ErrorMessage="真实姓名不能为空;" ForeColor="White" ValidationGroup="ModiUserInfo" Display="Dynamic" ToolTip="真实姓名不能为空;">*</asp:RequiredFieldValidator></td>
            <td align="right" style="width: 58px">
                <asp:Label ID="lblIDCardNum" runat="server" Text="身份证号:"></asp:Label></td>
            <td style="width: 175px">
                <asp:TextBox ID="txtIDCardNum" runat="server" MaxLength="18"></asp:TextBox>
            </td>
        </tr>
        <tr style="height:26px">
            <td align="right" style="width: 58px">
                <asp:Label ID="lblPostAdd" runat="server" Text="邮寄地址:"></asp:Label>
            </td>
            <td style="width: 175px">
                <asp:TextBox ID="txtPostAdd" runat="server" MaxLength="200"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvPostAdd" runat="server" ControlToValidate="txtPostAdd"
                    ErrorMessage="邮寄地址不能为空;" ForeColor="White" ValidationGroup="ModiUserInfo" Display="Dynamic" ToolTip="邮寄地址不能为空;">*</asp:RequiredFieldValidator></td>
            <td align="right" style="width: 58px">
                <asp:Label ID="lblUserBirth" runat="server" Text="出生日期:"></asp:Label>
            </td>
            <td style="width: 175px">
                <asp:TextBox ID="txtUserBirth" runat="server" MaxLength="10"></asp:TextBox>
            </td>
        </tr>
        <tr style="height:26px">
            <td align="right" style="width: 58px">
                <asp:Label ID="lblPostNum" runat="server" Text="邮政编码:"></asp:Label>
            </td>
            <td style="width: 175px">
                <asp:TextBox ID="txtPostNum" runat="server" MaxLength="6"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvPostNum" runat="server" ControlToValidate="txtPostNum"
                    ErrorMessage="邮编不能为空;" ForeColor="White" ValidationGroup="ModiUserInfo" Display="Dynamic" ToolTip="邮编不能为空;">*</asp:RequiredFieldValidator></td>
            <td align="right" style="width: 58px">
                <asp:Label ID="lblUserGender" runat="server" Text="性别:"></asp:Label>
            </td>
            <td style="width: 175px">
                <asp:DropDownList ID="ddlUserGender" runat="server">
                    <asp:ListItem Value="0">保密</asp:ListItem>
                    <asp:ListItem Value="1">男</asp:ListItem>
                    <asp:ListItem Value="2">女</asp:ListItem>
                    <asp:ListItem Value="3">春哥</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr style="height:26px">
            <td align="right" style="width: 58px">
                <asp:Label ID="lblPhoneNum" runat="server" Text="电话号码:"></asp:Label>
            </td>
            <td style="width: 175px">
                <asp:TextBox ID="txtPhoneNum" runat="server" MaxLength="20"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvPhoneNum" runat="server" ControlToValidate="txtPhoneNum"
                    ErrorMessage="电话号码不能为空;" ForeColor="White" ValidationGroup="ModiUserInfo" Display="Dynamic" ToolTip="电话号码不能为空;">*</asp:RequiredFieldValidator></td>
            <td style="width: 58px"></td>
            <td style="width: 175px"></td>
        </tr>
        <tr style="height:26px">
            <td align="right" style="width: 58px">
                <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">电子邮件:</asp:Label></td>
            <td style="width: 175px">
                <asp:TextBox ID="Email" runat="server" MaxLength="50"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="Email"
                    Display="Dynamic" ErrorMessage="电子邮箱不能为空;" ForeColor="White" ValidationGroup="ModiUserInfo" ToolTip="电子邮箱不能为空;">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revEmail" runat="server" Display="Dynamic" ErrorMessage="邮箱格式错误;"
                    ForeColor="WhiteSmoke" ToolTip="邮箱格式错误;" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                    ValidationGroup="ModiUserInfo" ControlToValidate="Email">*</asp:RegularExpressionValidator></td>
            <td style="width: 58px"></td>
            <td style="width: 175px"></td>
        </tr>   
        <tr style="height:26px">
            <td colspan="2" align="left">
                &nbsp;<asp:ValidationSummary ID="vsErrorMsg" runat="server" DisplayMode="SingleParagraph"
                    ForeColor="WhiteSmoke" Height="38px" ValidationGroup="ModiUserInfo" Width="223px" />
            </td>
            <td colspan="2" align="right">
                <asp:Button ID="submit" runat="server" Text="提交保存" onclick="submit_Click" ValidationGroup="ModiUserInfo" /></td>
        </tr>     
    </table>
</div>
</div>
</asp:Content>

