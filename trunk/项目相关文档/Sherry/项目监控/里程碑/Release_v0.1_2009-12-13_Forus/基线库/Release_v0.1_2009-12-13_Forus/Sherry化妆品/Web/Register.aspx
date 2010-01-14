<%@ Page Language="C#" MasterPageFile="~/IndexMaster.master" AutoEventWireup="true"
    CodeFile="Register.aspx.cs" Inherits="Register" Title="注册新用户" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentHolder" runat="Server">
    <div class="main float-l">
        <div style="margin-left: 10%">
            <asp:CreateUserWizard ID="CreateUserWizard" runat="server" OnCreatedUser="CreateUserWizard_CreatedUser"
                ContinueDestinationPageUrl="~/Index.aspx">
                <WizardSteps>
                    <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server">
                        <ContentTemplate>
                            <table border="0" width="500">
                                <tr style="width: 250px">
                                    <td align="center" colspan="3">
                                        <font face="微软雅黑">注册新帐户</font></td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <div class="menu" style="font-family: 微软雅黑;">
                                            <ul>
                                                <li><a href="#">必要信息</a> </li>
                                            </ul>
                                        </div>
                                    </td>
                                    <td rowspan="11" style="width: 250px" valign="top">
                                        <div class="menu" style="font-family: 微软雅黑;">
                                            <ul>
                                                <li><a href="#">选填信息</a>
                                                    <ul>
                                                        <li>
                                                            <table border="0">
                                                                <tr>
                                                                    <td align="left" style="width: 60px; height: 26px;">
                                                                        <asp:Label ID="lblUserGender" runat="server" Text="性别:" Width="60px"></asp:Label>
                                                                    </td>
                                                                    <td style="height: 26px">
                                                                        <asp:RadioButtonList ID="rdlUserGender" runat="server" RepeatDirection="Horizontal"
                                                                            Style="left: 60px; top: 5px" Height="20px" Width="166px">
                                                                            <asp:ListItem Selected="True" Value="0">保密</asp:ListItem>
                                                                            <asp:ListItem Value="1">男</asp:ListItem>
                                                                            <asp:ListItem Value="2">女</asp:ListItem>
                                                                            <asp:ListItem Value="3">春哥</asp:ListItem>
                                                                        </asp:RadioButtonList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" style="width: 60px; height: 26px;">
                                                                        <asp:Label ID="lblUserBirth" runat="server" Text="出生日期:" Width="60px"></asp:Label>
                                                                    </td>
                                                                    <td style="height: 26px">
                                                                        <asp:TextBox ID="txtUserBirth" runat="server" Width="156px"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" style="width: 60px; height: 26px;">
                                                                        <asp:Label ID="lblIDCardNum" runat="server" Text="身份证号:" Width="60px"></asp:Label>
                                                                    </td>
                                                                    <td style="height: 26px">
                                                                        <asp:TextBox ID="txtIDCardNum" runat="server" Width="156px"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </li>
                                                    </ul>
                                                </li>
                                            </ul>
                                        </div>
                                        <div style="position: relative; top: 80px">
                                            <asp:Literal ID="ltlUserPort" runat="server">
                                      <br />
                                      <br />
                                      <span style="font-family: 微软雅黑; font-size: medium">Serry化妆品网络销售服务协议</span>
                                      <br />
                                      <span style="font-family: 微软雅黑; font-size: small">1.本店销售的化妆品如非特殊原因不予退换。</span>
                                      <br />
                                      <span style="font-family: 微软雅黑; font-size: small">2.用户收货时请当面确认，用户确认收货后若货物出现问题本公司概不负责。</span>
                                      <br />
                                            </asp:Literal>
                                            <br />
                                            <asp:CheckBox ID="cbPortRead" runat="server" ValidationGroup="CreateUserWizard1" />我已阅读并同意用户协议
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 60px; height: 26px">
                                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName" Width="60px">用户名:</asp:Label>
                                    </td>
                                    <td style="width: 196px; height: 26px;">
                                        <asp:TextBox ID="UserName" runat="server" Width="156px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                            ErrorMessage="必须填写“用户名”。" ToolTip="必须填写“用户名”。" ValidationGroup="CreateUserWizard1"
                                            ForeColor="White">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 60px; height: 26px">
                                        <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">密码:</asp:Label>
                                    </td>
                                    <td style="width: 196px; height: 26px;">
                                        <asp:TextBox ID="Password" runat="server" TextMode="Password" Width="156px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                            ErrorMessage="必须填写“密码”。" ToolTip="必须填写“密码”。" ValidationGroup="CreateUserWizard1"
                                            ForeColor="White">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 60px; height: 26px">
                                        <asp:Label ID="ConfirmPasswordLabel" runat="server" AssociatedControlID="ConfirmPassword">确认密码:</asp:Label>
                                    </td>
                                    <td style="width: 196px; height: 26px;">
                                        <asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password" Width="156px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" ControlToValidate="ConfirmPassword"
                                            ErrorMessage="必须填写“确认密码”。" ToolTip="必须填写“确认密码”。" ValidationGroup="CreateUserWizard1"
                                            ForeColor="White">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 60px; height: 26px">
                                        <asp:Label ID="lblRealName" runat="server" Text="真实姓名:"></asp:Label>
                                    </td>
                                    <td style="width: 196px; height: 26px;">
                                        <asp:TextBox ID="txtRealName" runat="server" Width="156px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 60px; height: 26px">
                                        <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">电子邮件:</asp:Label>
                                    </td>
                                    <td style="width: 196px; height: 26px;">
                                        <asp:TextBox ID="Email" runat="server" Width="156px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email"
                                            ErrorMessage="必须填写“电子邮件”。" ToolTip="必须填写“电子邮件”。" ValidationGroup="CreateUserWizard1"
                                            ForeColor="White">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 60px; height: 26px">
                                        <asp:Label ID="lblPostAdd" runat="server" Text="邮寄地址:"></asp:Label>
                                    </td>
                                    <td style="width: 196px; height: 26px;">
                                        <asp:TextBox ID="txtPostAdd" runat="server" Width="156px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 60px; height: 26px">
                                        <asp:Label ID="lblPostNum" runat="server" Text="邮政编码:"></asp:Label>
                                    </td>
                                    <td style="width: 196px; height: 26px;">
                                        <asp:TextBox ID="txtPostNum" runat="server" Width="156px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 60px; height: 26px">
                                        <asp:Label ID="lblPhoneNum" runat="server" Text="电话号码:"></asp:Label>
                                    </td>
                                    <td style="width: 196px; height: 26px;">
                                        <asp:TextBox ID="txtPhoneNum" runat="server" Width="156px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 60px; height: 26px">
                                        <asp:Label ID="QuestionLabel" runat="server" AssociatedControlID="Question">安全问题:</asp:Label>
                                    </td>
                                    <td style="width: 196px; height: 26px;">
                                        <asp:TextBox ID="Question" runat="server" Width="156px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="QuestionRequired" runat="server" ControlToValidate="Question"
                                            ErrorMessage="必须填写“安全提示问题”。" ToolTip="必须填写“安全提示问题”。" ValidationGroup="CreateUserWizard1"
                                            ForeColor="White">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 60px; height: 26px">
                                        <asp:Label ID="AnswerLabel" runat="server" AssociatedControlID="Answer">安全答案:</asp:Label>
                                    </td>
                                    <td style="width: 196px; height: 26px;">
                                        <asp:TextBox ID="Answer" runat="server" Width="156px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="AnswerRequired" runat="server" ControlToValidate="Answer"
                                            ErrorMessage="必须填写“安全答案”。" ToolTip="必须填写“安全答案”。" ValidationGroup="CreateUserWizard1"
                                            ForeColor="White">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="3">
                                        <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password"
                                            ControlToValidate="ConfirmPassword" Display="Dynamic" ErrorMessage="“密码”和“确认密码”必须匹配。"
                                            ValidationGroup="CreateUserWizard1" ForeColor="White"></asp:CompareValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="3" style="color: white">
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
    </div>
</asp:Content>
