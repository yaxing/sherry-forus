<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddWorker.aspx.cs" Inherits="WorkerManage_AddWorker" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>添加新的工作人员</title>
    <link rel="stylesheet" type="text/css" href="../Management/bgStyle.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table cellspacing="1" cellpadding="3" width="790px" align="center" border="0">
           <tr>
             <td valign="top" width="100%">
               <p><br /></p>
             </td>
           </tr>
         </table>
         <table class="tableBorder" cellspacing="1" cellpadding="2" width="790px" align="center" border="0">
           <tr>
           <th width="100%" height="25px" class="tableHeaderText">添加新的工作人员</th>
           </tr>
         </table>
         
         
         <div align="center">
          <asp:CreateUserWizard ID="CreateUserWizard" runat="server" OnCreatedUser="CreateUserWizard_CreatedUser"
                ContinueDestinationPageUrl="~/Management/bgIndex.aspx" CreateUserButtonText="添加工作人员" LoginCreatedUser="False">
                <WizardSteps>
                    <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server">
                        <ContentTemplate>
                            <table border="0" width="790px">
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">用户名:</asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="UserName" runat="server" Width="156px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" 
                                        ErrorMessage="必须填写“管理员名”。" ToolTip="必须填写“管理员名”。" ValidationGroup="CreateUserWizard">*</asp:RequiredFieldValidator>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblRealName" runat="server" Text="真实姓名:"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtRealName" runat="server" Width="156px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="lblWorkerNum" runat="server" Text="工号:"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtWorkerNum" runat="server" Width="156px"></asp:TextBox>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblShop" runat="server" Text="店面:"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="DDLShop" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLShop_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="lblWorkerType" runat="server" Text="类型:"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="DDLWorkerLv" runat="server">
                                            <asp:ListItem Value="0">普通员工</asp:ListItem>
                                            <asp:ListItem Value="1">负责人</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblManager" runat="server" Text="负责人:"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlManager" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">密码:</asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="Password" runat="server" TextMode="Password" Width="156px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                            ErrorMessage="必须填写“密码”。" ToolTip="必须填写“密码”。" ValidationGroup="CreateUserWizard">*</asp:RequiredFieldValidator>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="ConfirmPasswordLabel" runat="server" AssociatedControlID="ConfirmPassword">确认密码:</asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password" Width="156px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" ControlToValidate="ConfirmPassword"
                                            ErrorMessage="必须填写“确认密码”。" ToolTip="必须填写“确认密码”。" ValidationGroup="CreateUserWizard">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">电子邮件:</asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="Email" runat="server" Width="156px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email"
                                            ErrorMessage="必须填写“电子邮件”。" ToolTip="必须填写“电子邮件”。" ValidationGroup="CreateUserWizard">*</asp:RequiredFieldValidator>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblPhoneNum" runat="server" Text="电话号码:"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtPhoneNum" runat="server" Width="156px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="QuestionLabel" runat="server" AssociatedControlID="Question">安全问题:</asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="Question" runat="server" Width="156px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="QuestionRequired" runat="server" ControlToValidate="Question"
                                            ErrorMessage="必须填写“安全提示问题”。" ToolTip="必须填写“安全提示问题”。" ValidationGroup="CreateUserWizard">*</asp:RequiredFieldValidator>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="AnswerLabel" runat="server" AssociatedControlID="Answer">安全答案:</asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="Answer" runat="server" Width="156px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="AnswerRequired" runat="server" ControlToValidate="Answer"
                                            ErrorMessage="必须填写“安全答案”。" ToolTip="必须填写“安全答案”。" ValidationGroup="CreateUserWizard">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password"
                                            ControlToValidate="ConfirmPassword" Display="Dynamic" ErrorMessage="“密码”和“确认密码”必须匹配。"
                                            ValidationGroup="CreateUserWizard"></asp:CompareValidator>
                                        <br />
                                        <font color="red"><asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal></font>
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
            
            
            <table class="tableBorder" cellspacing="1" cellpadding="2" width="790px" align="center" border="0">
           <tr>
             <th width="100%" class="tableHeaderText" style="height: 25px" />
           </tr>
         </table>
    </div>
    </form>
</body>
</html>
