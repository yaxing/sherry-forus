<%@ Page Language="C#" MasterPageFile="~/IndexMaster.master" AutoEventWireup="true" CodeFile="GetPassword.aspx.cs" Inherits="GetPassword" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentHolder" Runat="Server">

 <div class="main float-l" style="width:600px;">
        <div style="margin-left: 30%">
        <asp:PasswordRecovery ID="PasswordRecovery1" runat="server">
            <QuestionTemplate>
                <table border="0" cellpadding="1" cellspacing="0" 
                    style="border-collapse:collapse;">
                    <tr>
                        <td>
                            <table border="0" cellpadding="0">
                                <tr>
                                    <td align="center" colspan="2">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2">
                                        找回您的密码：第二步-->输入您<font color="blue">注册时</font>输入的密码提示问题<font color="blue">答案</font>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2" style="height: 17px">
                                       <font color="blue"><asp:Literal ID="UserName" runat="server"></asp:Literal></font>您好！
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 102px">
                                        您设定的问题为:</td>
                                    <td>
                                        <asp:Literal ID="Question" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 102px">
                                        <asp:Label ID="AnswerLabel" runat="server" AssociatedControlID="Answer" Height="15px" Width="146px">请输入您的回答:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="Answer" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="AnswerRequired" runat="server" 
                                            ControlToValidate="Answer" ErrorMessage="需要答案。" ToolTip="需要答案。" 
                                            ValidationGroup="PasswordRecovery1">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2" style="color:Red;">
                                        <font color="white"><asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal></font>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2" style="height: 24px">
                                        <asp:Button ID="SubmitButton" runat="server" CommandName="Submit" Text="提交" 
                                            ValidationGroup="PasswordRecovery1" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </QuestionTemplate>
            <UserNameTemplate>
                <table border="0" cellpadding="1" cellspacing="0" 
                    style="border-collapse:collapse;">
                    <tr>
                        <td>
                            <table border="0" cellpadding="0">
                                <tr>
                                <td align="center" colspan="2">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                <td align="center" colspan="2">
                                        找回您的密码：第一步-->输入您<font color="blue">注册时</font>输入的<font color="blue">用户名</font>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                <td align="center" colspan="2">
                                        请输入您的<font color="blue">用户名</font>，以便我们获取您的注册信息。
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 66px">
                                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">用户名:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" 
                                            ControlToValidate="UserName" ErrorMessage="必须填写“用户名”。" ToolTip="必须填写“用户名”。" 
                                            ValidationGroup="PasswordRecovery1">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2" style="color:Red;">
                                        <font color="white"><asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal></font>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2">
                                        <asp:Button ID="SubmitButton" runat="server" CommandName="Submit" Text="提交" 
                                            ValidationGroup="PasswordRecovery1" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </UserNameTemplate>
            <SuccessTemplate>
                <table border="0" cellpadding="1" cellspacing="0" 
                    style="border-collapse:collapse;">
                    <tr>
                        <td style="height: 32px">
                            <table border="0" cellpadding="0">
                                <tr>
                                <td align="center" colspan="2">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        找回您的密码：<font color="blue">结果</font>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    &nbsp;
                                    </td>
                                    <td>
                                    &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        您的<font color="blue">密码</font>已发送到您的<font color="blue">注册邮箱</font>，请注意查收。
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    &nbsp;
                                    </td>
                                    <td>
                                    &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                    <a href="Index.aspx">回到主页，继续浏览>></a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </SuccessTemplate>
        </asp:PasswordRecovery>
        </div>
    </div>

</asp:Content>

