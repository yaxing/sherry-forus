<%@ Page Language="C#" MasterPageFile="~/IndexMaster.master" AutoEventWireup="true"
    CodeFile="Register.aspx.cs" Inherits="Register" Title="ע�����û�" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentHolder" runat="Server">
<script type="text/javascript">

function showsubmenu(sid)
{
whichEl = eval("submenu" + sid);
if (whichEl.style.display == "none")
{
eval("submenu" + sid + ".style.display=\"\";");
}
else
{
eval("submenu" + sid + ".style.display=\"none\";");
}
}
</script>

     <div class="title"><span class="title_icon"><img src="images/bullet1.gif" alt="" title="" /></span>ע��</div>
        
        	<div class="feat_prod_box_details">
            <p class="details">
			 ��ӭ�����ٱ�վ����л���Ա�վ��֧�֡�<br/>
             ��ע���������ܵ��ķ���<br/>
			 1.��Ʒ���϶�������<br/>
			 2.��Ʒ�ʼ����ͻ������ͻ����ŷ���<br/>
			 3.������Ʒ�ۿ��뼸���ۼ�<br/>
			 4.��Ʒ��������<br/>
			 5.ȫ���ۺ����
            </p>
            
              	<div class="contact_form">
                <div class="form_subtitle">���������ʻ�</div>
                <asp:CreateUserWizard ID="CreateUserWizard" runat="server" OnCreatedUser="CreateUserWizard_CreatedUser"
                ContinueDestinationPageUrl="~/Index.aspx" CreateUserButtonImageUrl="~/images/register_bt.gif" CreateUserButtonText="ע��">
                <WizardSteps>
                    <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server">
                        <ContentTemplate>        
                    <div class="form_row">
                    <label class="contact"><strong>��&nbsp;&nbsp;��&nbsp;&nbsp;��:</strong></label>
                    <asp:TextBox ID="UserName" runat="server" Width="156px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" 
                    ErrorMessage="������д���û�������" ToolTip="������д���û�������" ValidationGroup="CreateUserWizard" 
                    ForeColor="red">*</asp:RequiredFieldValidator>
                        </div>  


                    <div class="form_row">
                    <label class="contact"><strong>�ܡ�����:</strong></label>
                    <asp:TextBox ID="Password" runat="server" TextMode="Password" Width="156px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" 
                    ErrorMessage="������д�����롱��" ToolTip="������д�����롱��" ValidationGroup="CreateUserWizard" 
                    ForeColor="red">*</asp:RequiredFieldValidator>
                    </div>
                    
                    <div class="form_row">
                    <label class="contact"><strong>ȷ������:</strong></label>
                    <asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password" Width="156px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" ControlToValidate="ConfirmPassword" 
                    ErrorMessage="������д��ȷ�����롱��" ToolTip="������д��ȷ�����롱��" ValidationGroup="CreateUserWizard" 
                    ForeColor="red">*</asp:RequiredFieldValidator>
                    </div>
                    
                    <div class="form_row">
                    <label class="contact"><strong>��ʵ����:</strong></label>
                    <asp:TextBox ID="txtRealName" runat="server" Width="156px" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtRealName"
                            ErrorMessage="������д����ʵ��������" ForeColor="red" ToolTip="������д����ʵ��������" ValidationGroup="CreateUserWizard">*</asp:RequiredFieldValidator></div>

                    <div class="form_row">
                    <label class="contact"><strong>��������:</strong></label>
                    <asp:TextBox ID="Email" runat="server" Width="156px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email" 
                    ErrorMessage="������д�������ʼ�����" ToolTip="������д�������ʼ�����" ValidationGroup="CreateUserWizard" 
                    ForeColor="red">*</asp:RequiredFieldValidator>
                    </div>


                    <div class="form_row">
                    <label class="contact"><strong>�绰����:</strong></label>
                    <asp:TextBox ID="txtPhoneNum" runat="server" Width="156px" MaxLength="20"></asp:TextBox>
                    </div>
                    
                    <div class="form_row">
                    <label class="contact"><strong>�ʼĵ�ַ:</strong></label>
                    <asp:TextBox ID="txtPostAdd" runat="server" Width="156px" MaxLength="200"></asp:TextBox>
                    </div>
                    
                    <div class="form_row">
                    <label class="contact"><strong>��������:</strong></label>
                    <asp:TextBox ID="txtPostNum" runat="server" Width="156px" MaxLength="6"></asp:TextBox>
                    </div>
                    
                    <div class="form_row">
                    <label class="contact"><strong>��ȫ����:</strong></label>
                    <asp:TextBox ID="Question" runat="server" Width="156px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="QuestionRequired" runat="server" ControlToValidate="Question" 
                    ErrorMessage="������д����ȫ��ʾ���⡱��" ToolTip="������д����ȫ��ʾ���⡱��" ValidationGroup="CreateUserWizard" 
                    ForeColor="red">*</asp:RequiredFieldValidator>
                    </div>
                    
                    <div class="form_row">
                    <label class="contact"><strong>��ȫ��:</strong></label>
                    <asp:TextBox ID="Answer" runat="server" Width="156px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="AnswerRequired" runat="server" ControlToValidate="Answer" 
                    ErrorMessage="������д����ȫ�𰸡���" ToolTip="������д����ȫ�𰸡���" ValidationGroup="CreateUserWizard" 
                    ForeColor="red">*</asp:RequiredFieldValidator>
                    </div>
                    
                    <table>
                    <tr>
                    <td>
                    <div class="form_row">
                        <input type="button" class="register" value="<ѡ����Ϣ" onclick="showsubmenu(30)"/>
                    </div>
                    </td>
                    </tr>
                    
                    <tr>
                    <td id="submenu30" style="display:none;">
                    <div class="form_row">
                        <label class="contact"><strong>�ԡ�����:</strong></label>
                        <asp:RadioButtonList ID="rdlUserGender" runat="server" RepeatDirection="Horizontal" 
                        Style="left: 60px; top: 5px" Height="20px" Width="222px">
                            <asp:ListItem Selected="True" Value="0">����</asp:ListItem>
                            <asp:ListItem Value="1">��</asp:ListItem>
                            <asp:ListItem Value="2">Ů</asp:ListItem>
                            <asp:ListItem Value="3">����</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                    
                    <div class="form_row">
                        <label class="contact"><strong>��������:</strong></label>
                        <asp:TextBox ID="txtUserBirth" runat="server" Width="156px"></asp:TextBox>
                    </div>
                    
                    <div class="form_row">
                        <label class="contact"><strong>���֤��:</strong></label>
                        <asp:TextBox ID="txtIDCardNum" runat="server" Width="156px"></asp:TextBox>
                    </div>
                    </td>
                    </tr>
                    </table>
                    
                    <div class="form_row">
                        <div class="terms">
                        <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password" 
                        ControlToValidate="ConfirmPassword" Display="Dynamic" ErrorMessage="�����롱�͡�ȷ�����롱����ƥ�䡣" 
                        ValidationGroup="CreateUserWizard1" ForeColor="red"></asp:CompareValidator>
                            <br />
                            <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="Email"
                                Display="Dynamic" ErrorMessage="���������ʽ����" ToolTip="���������ʽ����" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                ValidationGroup="CreateUserWizard">���������ʽ����</asp:RegularExpressionValidator>
                            <asp:RegularExpressionValidator ID="revIDCardNum" runat="server" ControlToValidate="txtIDCardNum"
                                ErrorMessage="���֤�����ʽ����" ToolTip="���֤�����ʽ����" ValidationExpression="\d{17}[\d|X]|\d{15}"
                                ValidationGroup="CreateUserWizard"></asp:RegularExpressionValidator><br />
                            <asp:RegularExpressionValidator ID="revPhone" runat="server" ControlToValidate="txtPhoneNum"
                                Display="Dynamic" ErrorMessage="�绰�����ʽ����" ToolTip="�绰�����ʽ����" ValidationExpression="((\d{11})|^((\d{7,8})|(\d{4}|\d{3})-(\d{7,8})|(\d{4}|\d{3})-(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1})|(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1}))$)"
                                ValidationGroup="CreateUserWizard"></asp:RegularExpressionValidator>
                            <asp:RegularExpressionValidator ID="revBirthday" runat="server" ControlToValidate="txtUserBirth"
                                ErrorMessage="�����밴xxxx-xx-xx��ʽ��д����֤��������" ToolTip="�����밴xxxx-xx-xx��ʽ��д����֤��������"
                                ValidationExpression="((^((1[8-9]\d{2})|([2-9]\d{3}))([-\/\._])(10|12|0?[13578])([-\/\._])(3[01]|[12][0-9]|0?[1-9])$)|(^((1[8-9]\d{2})|([2-9]\d{3}))([-\/\._])(11|0?[469])([-\/\._])(30|[12][0-9]|0?[1-9])$)|(^((1[8-9]\d{2})|([2-9]\d{3}))([-\/\._])(0?2)([-\/\._])(2[0-8]|1[0-9]|0?[1-9])$)|(^([2468][048]00)([-\/\._])(0?2)([-\/\._])(29)$)|(^([3579][26]00)([-\/\._])(0?2)([-\/\._])(29)$)|(^([1][89][0][48])([-\/\._])(0?2)([-\/\._])(29)$)|(^([2-9][0-9][0][48])([-\/\._])(0?2)([-\/\._])(29)$)|(^([1][89][2468][048])([-\/\._])(0?2)([-\/\._])(29)$)|(^([2-9][0-9][2468][048])([-\/\._])(0?2)([-\/\._])(29)$)|(^([1][89][13579][26])([-\/\._])(0?2)([-\/\._])(29)$)|(^([2-9][0-9][13579][26])([-\/\._])(0?2)([-\/\._])(29)$))"
                                ValidationGroup="CreateUserWizard"></asp:RegularExpressionValidator><br />
                            <asp:RegularExpressionValidator ID="revPostCode" runat="server" ControlToValidate="txtPostNum"
                                Display="Dynamic" ErrorMessage="�����������" ValidationExpression="\d{6}" ValidationGroup="CreateUserWizard"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    
                    <div class="form_row">
                        <div class="terms">
                        <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
                        </div>
                    </div>

                    <div class="form_row">
                        <div class="terms">
                        <asp:CheckBox ID="CKAgree" runat="server" ValidationGroup="CreateUserWizard" />
                        ��ͬ�� <a href="#">Sherry��ױƷ��������Э��</a>
                        </div>
                    </div>   
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
                    <CreateUserButtonStyle CssClass="register" />
                </asp:CreateUserWizard>  
                </div>  
            
          </div>
                        
</asp:Content>
