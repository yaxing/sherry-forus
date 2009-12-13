<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddWorker.aspx.cs" Inherits="WorkerManage_AddWorker" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>添加新的工作人员</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
          <asp:CreateUserWizard ID="CreateUserWizard" runat="server" OnCreatedUser="CreateUserWizard_CreatedUser"
                ContinueDestinationPageUrl="~/Management/bgIndex.aspx" CreateUserButtonText="添加工作人员">
                <WizardSteps>
                    <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server">
                        <ContentTemplate>
                            <table border="0" width="400">
                                <tr style="width: 250px">
                                    <td align="center" colspan="3">
                                        <font face="微软雅黑">添加新工作人员</font></td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 85px; height: 26px">
                                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">用户名:</asp:Label>
                                    </td>
                                    <td style="width: 296px; height: 26px;">
                                        <asp:TextBox ID="UserName" runat="server" Width="156px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                            ErrorMessage="必须填写“管理员名”。" ToolTip="必须填写“管理员名”。" ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 85px; height: 26px">
                                        <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">密码:</asp:Label>
                                    </td>
                                    <td style="width: 296px; height: 26px;">
                                        <asp:TextBox ID="Password" runat="server" TextMode="Password" Width="156px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                            ErrorMessage="必须填写“密码”。" ToolTip="必须填写“密码”。" ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 85px; height: 26px">
                                        <asp:Label ID="ConfirmPasswordLabel" runat="server" AssociatedControlID="ConfirmPassword">确认密码:</asp:Label>
                                    </td>
                                    <td style="width: 296px; height: 26px;">
                                        <asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password" Width="156px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" ControlToValidate="ConfirmPassword"
                                            ErrorMessage="必须填写“确认密码”。" ToolTip="必须填写“确认密码”。" ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 85px; height: 26px">
                                        <asp:Label ID="lblRealName" runat="server" Text="真实姓名:"></asp:Label>
                                    </td>
                                    <td style="width: 296px; height: 26px;">
                                        <asp:TextBox ID="txtRealName" runat="server" Width="156px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 85px; height: 26px">
                                        <asp:Label ID="lblWorkerNum" runat="server" Text="工号:"></asp:Label>
                                    </td>
                                    <td style="width: 296px; height: 26px;">
                                        <asp:TextBox ID="txtWorkerNum" runat="server" Width="156px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 85px; height: 26px">
                                        <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">电子邮件:</asp:Label>
                                    </td>
                                    <td style="width: 296px; height: 26px;">
                                        <asp:TextBox ID="Email" runat="server" Width="156px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email"
                                            ErrorMessage="必须填写“电子邮件”。" ToolTip="必须填写“电子邮件”。" ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 85px; height: 26px">
                                        <asp:Label ID="lblPhoneNum" runat="server" Text="电话号码:"></asp:Label></td>
                                    <td style="width: 296px; height: 26px;">
                                        <asp:TextBox ID="txtPhoneNum" runat="server" Width="156px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 85px; height: 26px">
                                        <asp:Label ID="lblWorkerType" runat="server" Text="类型:"></asp:Label></td>
                                    <td style="width: 296px; height: 26px;">
                                        <asp:DropDownList ID="DDLWorkerLv" runat="server">
                                            <asp:ListItem Value="0">普通员工</asp:ListItem>
                                            <asp:ListItem Value="1">负责人</asp:ListItem>
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 85px; height: 26px">
                                        <asp:Label ID="lblShop" runat="server" Text="店面:"></asp:Label></td>
                                    <td style="width: 296px; height: 26px;">
                                        <asp:DropDownList ID="ddlShop" runat="server">
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 85px; height: 26px">
                                        <asp:Label ID="lblManager" runat="server" Text="负责人:"></asp:Label></td>
                                    <td style="width: 296px; height: 26px;">
                                        <asp:DropDownList ID="ddlManager" runat="server">
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 85px; height: 26px">
                                        <asp:Label ID="QuestionLabel" runat="server" AssociatedControlID="Question">安全问题:</asp:Label>
                                    </td>
                                    <td style="width: 296px; height: 26px;">
                                        <asp:TextBox ID="Question" runat="server" Width="156px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="QuestionRequired" runat="server" ControlToValidate="Question"
                                            ErrorMessage="必须填写“安全提示问题”。" ToolTip="必须填写“安全提示问题”。" ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 85px; height: 26px">
                                        <asp:Label ID="AnswerLabel" runat="server" AssociatedControlID="Answer">安全答案:</asp:Label>
                                    </td>
                                    <td style="width: 296px; height: 26px;">
                                        <asp:TextBox ID="Answer" runat="server" Width="156px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="AnswerRequired" runat="server" ControlToValidate="Answer"
                                            ErrorMessage="必须填写“安全答案”。" ToolTip="必须填写“安全答案”。" ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2">
                                        <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password"
                                            ControlToValidate="ConfirmPassword" Display="Dynamic" ErrorMessage="“密码”和“确认密码”必须匹配。"
                                            ValidationGroup="CreateUserWizard1"></asp:CompareValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2" style="color: red">
                                        <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:CreateUserWizardStep>
                    <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server">
                        <ContentTemplate>
                            <table border="0">
                                <tr>
                                    <td align="center" colspan="2">
                                        完成</td>
                                </tr>
                                <tr>
                                    <td>
                                        已成功创建您的帐户。</td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="2">
                                        <asp:Button ID="ContinueButton" runat="server" CausesValidation="False" CommandName="Continue"
                                            Text="继续" ValidationGroup="CreateUserWizard1" />
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:CompleteWizardStep>
                </WizardSteps>
            </asp:CreateUserWizard>
    </div>
    </form>
</body>
</html>
