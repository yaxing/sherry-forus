<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddAdmin.aspx.cs" Inherits="Management_AddAdmin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>����Ա����</title>
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
           <th width="100%" class="tableHeaderText" style="height: 25px">����¹���Ա</th>
           </tr>
         </table>
         
         <div align="center">
        <asp:Panel ID="PanelAddAdmin" runat="server">
          <asp:CreateUserWizard ID="CreateUserWizard" runat="server" OnCreatedUser="CreateUserWizard_CreatedUser"
                ContinueDestinationPageUrl="~/Management/bgIndex.aspx" CreateUserButtonText="��ӹ���Ա" LoginCreatedUser="False">
                <WizardSteps>
                    <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server">
                        <ContentTemplate>
                            <table border="0" width="790">
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">����Ա��:</asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="UserName" runat="server" Width="156px" MaxLength="20"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" 
                                        ErrorMessage="������д������Ա������" ToolTip="������д������Ա������" ValidationGroup="CreateUserWizard">*</asp:RequiredFieldValidator>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblRealName" runat="server" Text="��ʵ����:"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtRealName" runat="server" Width="156px" MaxLength="50"></asp:TextBox>
                                        <asp:RequiredFieldValidator id="RFVRealName" runat="server" ForeColor="red" ValidationGroup="CreateUserWizard" ToolTip="������д����ʵ��������" ErrorMessage="������д����ʵ��������" ControlToValidate="txtRealName">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">�ܡ�����:</asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="Password" runat="server" TextMode="Password" Width="156px" MaxLength="20"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" 
                                        ErrorMessage="������д�����롱��" ToolTip="������д�����롱��" ValidationGroup="CreateUserWizard">*</asp:RequiredFieldValidator>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="ConfirmPasswordLabel" runat="server" AssociatedControlID="ConfirmPassword">ȷ������:</asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password" Width="156px" MaxLength="20"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" ControlToValidate="ConfirmPassword"
                                            ErrorMessage="������д��ȷ�����롱��" ToolTip="������д��ȷ�����롱��" ValidationGroup="CreateUserWizard">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="lblAdminType" runat="server" Text="��������:"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="DDLAdminLv" runat="server" Width="156px">
                                            <asp:ListItem Value="0">��Ʒ����</asp:ListItem>
                                            <asp:ListItem Value="1">�г�����</asp:ListItem>
                                            <asp:ListItem Value="2">���¹���</asp:ListItem>
                                            <asp:ListItem Value="3">������</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">�����ʼ�:</asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="Email" runat="server" Width="156px" MaxLength="50"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email" 
                                        ErrorMessage="������д�������ʼ�����" ToolTip="������д�������ʼ�����" ValidationGroup="CreateUserWizard">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="lblPhoneNum" runat="server" Text="�绰����:"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtPhoneNum" runat="server" Width="156px" MaxLength="20"></asp:TextBox>
                                        <asp:RequiredFieldValidator id="RFVPhone" runat="server" ForeColor="red" ValidationGroup="CreateUserWizard" ToolTip="������д����ϵ�绰����" ErrorMessage="������д����ϵ�绰����" ControlToValidate="txtPhoneNum">*</asp:RequiredFieldValidator>
                                    </td>
                                    <td align="left">
                                    </td>
                                    <td align="left">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="QuestionLabel" runat="server" AssociatedControlID="Question">��ȫ����:</asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="Question" runat="server" Width="156px" MaxLength="50"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="QuestionRequired" runat="server" ControlToValidate="Question" 
                                        ErrorMessage="������д����ȫ��ʾ���⡱��" ToolTip="������д����ȫ��ʾ���⡱��" ValidationGroup="CreateUserWizard">*</asp:RequiredFieldValidator>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="AnswerLabel" runat="server" AssociatedControlID="Answer">��ȫ��:</asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="Answer" runat="server" Width="156px" MaxLength="50"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="AnswerRequired" runat="server" ControlToValidate="Answer" 
                                        ErrorMessage="������д����ȫ�𰸡���" ToolTip="������д����ȫ�𰸡���" ValidationGroup="CreateUserWizard">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password" 
                                        ControlToValidate="ConfirmPassword" Display="Dynamic" ErrorMessage="�����롱�͡�ȷ�����롱����ƥ�䡣" 
                                        ValidationGroup="CreateUserWizard"></asp:CompareValidator>
                                        <br />
                                        <asp:RegularExpressionValidator id="revEmail" runat="server" ValidationGroup="CreateUserWizard" ToolTip="���������ʽ����" ErrorMessage="���������ʽ����" ControlToValidate="Email" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">���������ʽ����</asp:RegularExpressionValidator>
                                        <asp:RegularExpressionValidator id="revPhone" runat="server" ValidationGroup="CreateUserWizard" ToolTip="�绰�����ʽ����" ErrorMessage="�绰�����ʽ����" ControlToValidate="txtPhoneNum" Display="Dynamic" ValidationExpression="((\d{11})|^((\d{7,8})|(\d{4}|\d{3})-(\d{7,8})|(\d{4}|\d{3})-(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1})|(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1}))$)"></asp:RegularExpressionValidator>
                                        <br />
                                        <asp:RegularExpressionValidator ID="revAdminName" runat="server" ErrorMessage="����Ա��ֻ�ܰ�����ĸ�����ֻ�_��" Display="Dynamic" ToolTip="����Ա��ֻ�ܰ�����ĸ�����ֻ�_��" ValidationExpression="^[A-Za-z0-9_]+$" ValidationGroup="CreateUserWizard" ControlToValidate="UserName"></asp:RegularExpressionValidator>
                                        <br />
                                        <asp:RegularExpressionValidator ID="revRealName" runat="server" ErrorMessage="��ʵ����ֻ��ʹ�ú��ֻ�Ӣ��" Display="Dynamic" ToolTip="��ʵ����ֻ��ʹ�ú��ֻ�Ӣ��" ValidationExpression="^[\u4e00-\u9fa5A-Za-z]+$" ValidationGroup="CreateUserWizard" ControlToValidate="txtRealName"></asp:RegularExpressionValidator>
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
                                        ���</td>
                                </tr>
                                <tr>
                                    <td>
                                        �ѳɹ����������ʻ���</td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="2">
                                        <asp:Button ID="ContinueButton" runat="server" CausesValidation="False" CommandName="Continue"
                                            Text="����" ValidationGroup="CreateUserWizard" />
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
