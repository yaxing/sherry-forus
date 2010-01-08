<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddAdmin.aspx.cs" Inherits="Management_AddAdmin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>管理员管理</title>
    <link rel="stylesheet" type="text/css" href="bgStyle.css" />
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
           <th width="100%" class="tableHeaderText" style="height: 25px">添加新管理员</th>
           </tr>
         </table>
         
         <div align="center">
        <asp:Panel ID="PanelAddAdmin" runat="server">
          <asp:CreateUserWizard ID="CreateUserWizard" runat="server" OnCreatedUser="CreateUserWizard_CreatedUser"
                ContinueDestinationPageUrl="~/Management/bgIndex.aspx" CreateUserButtonText="添加管理员" LoginCreatedUser="False">
                <WizardSteps>
                    <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server">
                        <ContentTemplate>
                            <table border="0" width="790">
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">管理员名:</asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="UserName" runat="server" Width="156px" MaxLength="20"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" 
                                        ErrorMessage="必须填写“管理员名”。" ToolTip="必须填写“管理员名”。" ValidationGroup="CreateUserWizard">*</asp:RequiredFieldValidator>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblRealName" runat="server" Text="真实姓名:"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtRealName" runat="server" Width="156px" MaxLength="50"></asp:TextBox>
                                        <asp:RequiredFieldValidator id="RFVRealName" runat="server" ForeColor="red" ValidationGroup="CreateUserWizard" ToolTip="必须填写“真实姓名”。" ErrorMessage="必须填写“真实姓名”。" ControlToValidate="txtRealName">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">密　　码:</asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="Password" runat="server" TextMode="Password" Width="156px" MaxLength="20"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" 
                                        ErrorMessage="必须填写“密码”。" ToolTip="必须填写“密码”。" ValidationGroup="CreateUserWizard">*</asp:RequiredFieldValidator>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="ConfirmPasswordLabel" runat="server" AssociatedControlID="ConfirmPassword">确认密码:</asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password" Width="156px" MaxLength="20"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" ControlToValidate="ConfirmPassword"
                                            ErrorMessage="必须填写“确认密码”。" ToolTip="必须填写“确认密码”。" ValidationGroup="CreateUserWizard">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="lblAdminType" runat="server" Text="管理类型:"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="DDLAdminLv" runat="server" Width="156px">
                                            <asp:ListItem Value="0">商品管理</asp:ListItem>
                                            <asp:ListItem Value="1">市场管理</asp:ListItem>
                                            <asp:ListItem Value="2">人事管理</asp:ListItem>
                                            <asp:ListItem Value="3">管理经理</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">电子邮件:</asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="Email" runat="server" Width="156px" MaxLength="50"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email" 
                                        ErrorMessage="必须填写“电子邮件”。" ToolTip="必须填写“电子邮件”。" ValidationGroup="CreateUserWizard">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="lblPhoneNum" runat="server" Text="电话号码:"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtPhoneNum" runat="server" Width="156px" MaxLength="20"></asp:TextBox>
                                        <asp:RequiredFieldValidator id="RFVPhone" runat="server" ForeColor="red" ValidationGroup="CreateUserWizard" ToolTip="必须填写“联系电话”。" ErrorMessage="必须填写“联系电话”。" ControlToValidate="txtPhoneNum">*</asp:RequiredFieldValidator>
                                    </td>
                                    <td align="left">
                                    </td>
                                    <td align="left">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="QuestionLabel" runat="server" AssociatedControlID="Question">安全问题:</asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="Question" runat="server" Width="156px" MaxLength="50"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="QuestionRequired" runat="server" ControlToValidate="Question" 
                                        ErrorMessage="必须填写“安全提示问题”。" ToolTip="必须填写“安全提示问题”。" ValidationGroup="CreateUserWizard">*</asp:RequiredFieldValidator>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="AnswerLabel" runat="server" AssociatedControlID="Answer">安全答案:</asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="Answer" runat="server" Width="156px" MaxLength="50"></asp:TextBox>
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
                                        <asp:RegularExpressionValidator id="revEmail" runat="server" ValidationGroup="CreateUserWizard" ToolTip="电子邮箱格式错误" ErrorMessage="电子邮箱格式错误" ControlToValidate="Email" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">电子邮箱格式错误</asp:RegularExpressionValidator>
                                        <asp:RegularExpressionValidator id="revPhone" runat="server" ValidationGroup="CreateUserWizard" ToolTip="电话号码格式错误" ErrorMessage="电话号码格式错误" ControlToValidate="txtPhoneNum" Display="Dynamic" ValidationExpression="((\d{11})|^((\d{7,8})|(\d{4}|\d{3})-(\d{7,8})|(\d{4}|\d{3})-(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1})|(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1}))$)"></asp:RegularExpressionValidator>
                                        <br />
                                        <asp:RegularExpressionValidator ID="revAdminName" runat="server" ErrorMessage="管理员名只能包含字母、数字或“_”" Display="Dynamic" ToolTip="管理员名只能包含字母、数字或“_”" ValidationExpression="^[A-Za-z0-9_]+$" ValidationGroup="CreateUserWizard" ControlToValidate="UserName"></asp:RegularExpressionValidator>
                                        <br />
                                        <asp:RegularExpressionValidator ID="revRealName" runat="server" ErrorMessage="真实姓名只能使用汉字或英文" Display="Dynamic" ToolTip="真实姓名只能使用汉字或英文" ValidationExpression="^[\u4e00-\u9fa5A-Za-z]+$" ValidationGroup="CreateUserWizard" ControlToValidate="txtRealName"></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
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
                                            Text="继续" ValidationGroup="CreateUserWizard" />
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:CompleteWizardStep>
                </WizardSteps>
              <CreateUserButtonStyle CssClass="tableBorder" />
            </asp:CreateUserWizard>
        </asp:Panel>
          </div>
        
        <table class="tableBorder" cellspacing="1" cellpadding="2" width="790px" align="center" border="0">
           <tr>
             <th width="100%" class="tableHeaderText" style="height: 25px">&nbsp;</th>
           </tr>
         </table>
    </div>
    </form>
</body>
</html>
