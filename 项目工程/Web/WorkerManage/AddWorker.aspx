<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddWorker.aspx.cs" Inherits="WorkerManage_AddWorker" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>����µĹ�����Ա</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
          <asp:CreateUserWizard ID="CreateUserWizard" runat="server" OnCreatedUser="CreateUserWizard_CreatedUser"
                ContinueDestinationPageUrl="~/Management/bgIndex.aspx" CreateUserButtonText="��ӹ�����Ա">
                <WizardSteps>
                    <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server">
                        <ContentTemplate>
                            <table border="0" width="400">
                                <tr style="width: 250px">
                                    <td align="center" colspan="3">
                                        <font face="΢���ź�">����¹�����Ա</font></td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 85px; height: 26px">
                                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">�û���:</asp:Label>
                                    </td>
                                    <td style="width: 296px; height: 26px;">
                                        <asp:TextBox ID="UserName" runat="server" Width="156px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                            ErrorMessage="������д������Ա������" ToolTip="������д������Ա������" ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 85px; height: 26px">
                                        <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">����:</asp:Label>
                                    </td>
                                    <td style="width: 296px; height: 26px;">
                                        <asp:TextBox ID="Password" runat="server" TextMode="Password" Width="156px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                            ErrorMessage="������д�����롱��" ToolTip="������д�����롱��" ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 85px; height: 26px">
                                        <asp:Label ID="ConfirmPasswordLabel" runat="server" AssociatedControlID="ConfirmPassword">ȷ������:</asp:Label>
                                    </td>
                                    <td style="width: 296px; height: 26px;">
                                        <asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password" Width="156px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" ControlToValidate="ConfirmPassword"
                                            ErrorMessage="������д��ȷ�����롱��" ToolTip="������д��ȷ�����롱��" ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 85px; height: 26px">
                                        <asp:Label ID="lblRealName" runat="server" Text="��ʵ����:"></asp:Label>
                                    </td>
                                    <td style="width: 296px; height: 26px;">
                                        <asp:TextBox ID="txtRealName" runat="server" Width="156px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 85px; height: 26px">
                                        <asp:Label ID="lblWorkerNum" runat="server" Text="����:"></asp:Label>
                                    </td>
                                    <td style="width: 296px; height: 26px;">
                                        <asp:TextBox ID="txtWorkerNum" runat="server" Width="156px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 85px; height: 26px">
                                        <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">�����ʼ�:</asp:Label>
                                    </td>
                                    <td style="width: 296px; height: 26px;">
                                        <asp:TextBox ID="Email" runat="server" Width="156px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email"
                                            ErrorMessage="������д�������ʼ�����" ToolTip="������д�������ʼ�����" ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 85px; height: 26px">
                                        <asp:Label ID="lblPhoneNum" runat="server" Text="�绰����:"></asp:Label></td>
                                    <td style="width: 296px; height: 26px;">
                                        <asp:TextBox ID="txtPhoneNum" runat="server" Width="156px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 85px; height: 26px">
                                        <asp:Label ID="lblWorkerType" runat="server" Text="����:"></asp:Label></td>
                                    <td style="width: 296px; height: 26px;">
                                        <asp:DropDownList ID="DDLWorkerLv" runat="server">
                                            <asp:ListItem Value="0">��ͨԱ��</asp:ListItem>
                                            <asp:ListItem Value="1">������</asp:ListItem>
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 85px; height: 26px">
                                        <asp:Label ID="lblShop" runat="server" Text="����:"></asp:Label></td>
                                    <td style="width: 296px; height: 26px;">
                                        <asp:DropDownList ID="ddlShop" runat="server">
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 85px; height: 26px">
                                        <asp:Label ID="lblManager" runat="server" Text="������:"></asp:Label></td>
                                    <td style="width: 296px; height: 26px;">
                                        <asp:DropDownList ID="ddlManager" runat="server">
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 85px; height: 26px">
                                        <asp:Label ID="QuestionLabel" runat="server" AssociatedControlID="Question">��ȫ����:</asp:Label>
                                    </td>
                                    <td style="width: 296px; height: 26px;">
                                        <asp:TextBox ID="Question" runat="server" Width="156px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="QuestionRequired" runat="server" ControlToValidate="Question"
                                            ErrorMessage="������д����ȫ��ʾ���⡱��" ToolTip="������д����ȫ��ʾ���⡱��" ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 85px; height: 26px">
                                        <asp:Label ID="AnswerLabel" runat="server" AssociatedControlID="Answer">��ȫ��:</asp:Label>
                                    </td>
                                    <td style="width: 296px; height: 26px;">
                                        <asp:TextBox ID="Answer" runat="server" Width="156px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="AnswerRequired" runat="server" ControlToValidate="Answer"
                                            ErrorMessage="������д����ȫ�𰸡���" ToolTip="������д����ȫ�𰸡���" ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2">
                                        <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password"
                                            ControlToValidate="ConfirmPassword" Display="Dynamic" ErrorMessage="�����롱�͡�ȷ�����롱����ƥ�䡣"
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
                                        ���</td>
                                </tr>
                                <tr>
                                    <td>
                                        �ѳɹ����������ʻ���</td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="2">
                                        <asp:Button ID="ContinueButton" runat="server" CausesValidation="False" CommandName="Continue"
                                            Text="����" ValidationGroup="CreateUserWizard1" />
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
