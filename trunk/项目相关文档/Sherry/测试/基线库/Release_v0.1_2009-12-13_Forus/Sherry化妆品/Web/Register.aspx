<%@ Page Language="C#" MasterPageFile="~/IndexMaster.master" AutoEventWireup="true"
    CodeFile="Register.aspx.cs" Inherits="Register" Title="ע�����û�" %>

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
                                        <font face="΢���ź�">ע�����ʻ�</font></td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <div class="menu" style="font-family: ΢���ź�;">
                                            <ul>
                                                <li><a href="#">��Ҫ��Ϣ</a> </li>
                                            </ul>
                                        </div>
                                    </td>
                                    <td rowspan="11" style="width: 250px" valign="top">
                                        <div class="menu" style="font-family: ΢���ź�;">
                                            <ul>
                                                <li><a href="#">ѡ����Ϣ</a>
                                                    <ul>
                                                        <li>
                                                            <table border="0">
                                                                <tr>
                                                                    <td align="left" style="width: 60px; height: 26px;">
                                                                        <asp:Label ID="lblUserGender" runat="server" Text="�Ա�:" Width="60px"></asp:Label>
                                                                    </td>
                                                                    <td style="height: 26px">
                                                                        <asp:RadioButtonList ID="rdlUserGender" runat="server" RepeatDirection="Horizontal"
                                                                            Style="left: 60px; top: 5px" Height="20px" Width="166px">
                                                                            <asp:ListItem Selected="True" Value="0">����</asp:ListItem>
                                                                            <asp:ListItem Value="1">��</asp:ListItem>
                                                                            <asp:ListItem Value="2">Ů</asp:ListItem>
                                                                            <asp:ListItem Value="3">����</asp:ListItem>
                                                                        </asp:RadioButtonList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" style="width: 60px; height: 26px;">
                                                                        <asp:Label ID="lblUserBirth" runat="server" Text="��������:" Width="60px"></asp:Label>
                                                                    </td>
                                                                    <td style="height: 26px">
                                                                        <asp:TextBox ID="txtUserBirth" runat="server" Width="156px"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" style="width: 60px; height: 26px;">
                                                                        <asp:Label ID="lblIDCardNum" runat="server" Text="���֤��:" Width="60px"></asp:Label>
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
                                      <span style="font-family: ΢���ź�; font-size: medium">Serry��ױƷ�������۷���Э��</span>
                                      <br />
                                      <span style="font-family: ΢���ź�; font-size: small">1.�������۵Ļ�ױƷ�������ԭ�����˻���</span>
                                      <br />
                                      <span style="font-family: ΢���ź�; font-size: small">2.�û��ջ�ʱ�뵱��ȷ�ϣ��û�ȷ���ջ���������������Ȿ��˾�Ų�����</span>
                                      <br />
                                            </asp:Literal>
                                            <br />
                                            <asp:CheckBox ID="cbPortRead" runat="server" ValidationGroup="CreateUserWizard1" />�����Ķ���ͬ���û�Э��
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 60px; height: 26px">
                                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName" Width="60px">�û���:</asp:Label>
                                    </td>
                                    <td style="width: 196px; height: 26px;">
                                        <asp:TextBox ID="UserName" runat="server" Width="156px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                            ErrorMessage="������д���û�������" ToolTip="������д���û�������" ValidationGroup="CreateUserWizard1"
                                            ForeColor="White">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 60px; height: 26px">
                                        <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">����:</asp:Label>
                                    </td>
                                    <td style="width: 196px; height: 26px;">
                                        <asp:TextBox ID="Password" runat="server" TextMode="Password" Width="156px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                            ErrorMessage="������д�����롱��" ToolTip="������д�����롱��" ValidationGroup="CreateUserWizard1"
                                            ForeColor="White">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 60px; height: 26px">
                                        <asp:Label ID="ConfirmPasswordLabel" runat="server" AssociatedControlID="ConfirmPassword">ȷ������:</asp:Label>
                                    </td>
                                    <td style="width: 196px; height: 26px;">
                                        <asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password" Width="156px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" ControlToValidate="ConfirmPassword"
                                            ErrorMessage="������д��ȷ�����롱��" ToolTip="������д��ȷ�����롱��" ValidationGroup="CreateUserWizard1"
                                            ForeColor="White">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 60px; height: 26px">
                                        <asp:Label ID="lblRealName" runat="server" Text="��ʵ����:"></asp:Label>
                                    </td>
                                    <td style="width: 196px; height: 26px;">
                                        <asp:TextBox ID="txtRealName" runat="server" Width="156px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 60px; height: 26px">
                                        <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">�����ʼ�:</asp:Label>
                                    </td>
                                    <td style="width: 196px; height: 26px;">
                                        <asp:TextBox ID="Email" runat="server" Width="156px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email"
                                            ErrorMessage="������д�������ʼ�����" ToolTip="������д�������ʼ�����" ValidationGroup="CreateUserWizard1"
                                            ForeColor="White">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 60px; height: 26px">
                                        <asp:Label ID="lblPostAdd" runat="server" Text="�ʼĵ�ַ:"></asp:Label>
                                    </td>
                                    <td style="width: 196px; height: 26px;">
                                        <asp:TextBox ID="txtPostAdd" runat="server" Width="156px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 60px; height: 26px">
                                        <asp:Label ID="lblPostNum" runat="server" Text="��������:"></asp:Label>
                                    </td>
                                    <td style="width: 196px; height: 26px;">
                                        <asp:TextBox ID="txtPostNum" runat="server" Width="156px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 60px; height: 26px">
                                        <asp:Label ID="lblPhoneNum" runat="server" Text="�绰����:"></asp:Label>
                                    </td>
                                    <td style="width: 196px; height: 26px;">
                                        <asp:TextBox ID="txtPhoneNum" runat="server" Width="156px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 60px; height: 26px">
                                        <asp:Label ID="QuestionLabel" runat="server" AssociatedControlID="Question">��ȫ����:</asp:Label>
                                    </td>
                                    <td style="width: 196px; height: 26px;">
                                        <asp:TextBox ID="Question" runat="server" Width="156px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="QuestionRequired" runat="server" ControlToValidate="Question"
                                            ErrorMessage="������д����ȫ��ʾ���⡱��" ToolTip="������д����ȫ��ʾ���⡱��" ValidationGroup="CreateUserWizard1"
                                            ForeColor="White">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 60px; height: 26px">
                                        <asp:Label ID="AnswerLabel" runat="server" AssociatedControlID="Answer">��ȫ��:</asp:Label>
                                    </td>
                                    <td style="width: 196px; height: 26px;">
                                        <asp:TextBox ID="Answer" runat="server" Width="156px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="AnswerRequired" runat="server" ControlToValidate="Answer"
                                            ErrorMessage="������д����ȫ�𰸡���" ToolTip="������д����ȫ�𰸡���" ValidationGroup="CreateUserWizard1"
                                            ForeColor="White">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="3">
                                        <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password"
                                            ControlToValidate="ConfirmPassword" Display="Dynamic" ErrorMessage="�����롱�͡�ȷ�����롱����ƥ�䡣"
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
    </div>
</asp:Content>
