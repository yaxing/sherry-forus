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
                                        �һ��������룺�ڶ���-->������<font color="blue">ע��ʱ</font>�����������ʾ����<font color="blue">��</font>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2" style="height: 17px">
                                       <font color="blue"><asp:Literal ID="UserName" runat="server"></asp:Literal></font>���ã�
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 102px">
                                        ���趨������Ϊ:</td>
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
                                        <asp:Label ID="AnswerLabel" runat="server" AssociatedControlID="Answer" Height="15px" Width="146px">���������Ļش�:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="Answer" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="AnswerRequired" runat="server" 
                                            ControlToValidate="Answer" ErrorMessage="��Ҫ�𰸡�" ToolTip="��Ҫ�𰸡�" 
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
                                        <asp:Button ID="SubmitButton" runat="server" CommandName="Submit" Text="�ύ" 
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
                                        �һ��������룺��һ��-->������<font color="blue">ע��ʱ</font>�����<font color="blue">�û���</font>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                <td align="center" colspan="2">
                                        ����������<font color="blue">�û���</font>���Ա����ǻ�ȡ����ע����Ϣ��
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 66px">
                                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">�û���:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" 
                                            ControlToValidate="UserName" ErrorMessage="������д���û�������" ToolTip="������д���û�������" 
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
                                        <asp:Button ID="SubmitButton" runat="server" CommandName="Submit" Text="�ύ" 
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
                                        �һ��������룺<font color="blue">���</font>
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
                                        ����<font color="blue">����</font>�ѷ��͵�����<font color="blue">ע������</font>����ע����ա�
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
                                    <a href="Index.aspx">�ص���ҳ���������>></a>
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

