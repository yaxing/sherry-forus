<%@ Page Language="C#" MasterPageFile="~/IndexMaster.master" AutoEventWireup="true"
    CodeFile="Register.aspx.cs" Inherits="Register" Title="注册新用户" %>

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

     <div class="title"><span class="title_icon"><img src="images/bullet1.gif" alt="" title="" /></span>注册</div>
        
        	<div class="feat_prod_box_details">
            <p class="details">
			 欢迎您光临本站，感谢您对本站的支持。<br/>
             您注册后可以享受到的服务：<br/>
			 1.商品网上定购服务<br/>
			 2.商品邮寄与送货区内送货上门服务<br/>
			 3.更多商品折扣与几分折价<br/>
			 4.商品评论与打分<br/>
			 5.全面售后服务
            </p>
            
              	<div class="contact_form">
                <div class="form_subtitle">创建您的帐户</div>
                <asp:CreateUserWizard ID="CreateUserWizard" runat="server" OnCreatedUser="CreateUserWizard_CreatedUser"
                ContinueDestinationPageUrl="~/Index.aspx" CreateUserButtonImageUrl="~/images/register_bt.gif" CreateUserButtonText="注册">
                <WizardSteps>
                    <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server">
                        <ContentTemplate>        
                    <div class="form_row">
                    <label class="contact"><strong>用&nbsp;&nbsp;户&nbsp;&nbsp;名:</strong></label>
                    <asp:TextBox ID="UserName" runat="server" Width="156px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" 
                    ErrorMessage="必须填写“用户名”。" ToolTip="必须填写“用户名”。" ValidationGroup="CreateUserWizard" 
                    ForeColor="red">*</asp:RequiredFieldValidator>
                        </div>  


                    <div class="form_row">
                    <label class="contact"><strong>密　　码:</strong></label>
                    <asp:TextBox ID="Password" runat="server" TextMode="Password" Width="156px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" 
                    ErrorMessage="必须填写“密码”。" ToolTip="必须填写“密码”。" ValidationGroup="CreateUserWizard" 
                    ForeColor="red">*</asp:RequiredFieldValidator>
                    </div>
                    
                    <div class="form_row">
                    <label class="contact"><strong>确认密码:</strong></label>
                    <asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password" Width="156px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" ControlToValidate="ConfirmPassword" 
                    ErrorMessage="必须填写“确认密码”。" ToolTip="必须填写“确认密码”。" ValidationGroup="CreateUserWizard" 
                    ForeColor="red">*</asp:RequiredFieldValidator>
                    </div>
                    
                    <div class="form_row">
                    <label class="contact"><strong>真实姓名:</strong></label>
                    <asp:TextBox ID="txtRealName" runat="server" Width="156px" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtRealName"
                            ErrorMessage="必须填写“真实姓名”。" ForeColor="red" ToolTip="必须填写“真实姓名”。" ValidationGroup="CreateUserWizard">*</asp:RequiredFieldValidator></div>

                    <div class="form_row">
                    <label class="contact"><strong>电子邮箱:</strong></label>
                    <asp:TextBox ID="Email" runat="server" Width="156px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email" 
                    ErrorMessage="必须填写“电子邮件”。" ToolTip="必须填写“电子邮件”。" ValidationGroup="CreateUserWizard" 
                    ForeColor="red">*</asp:RequiredFieldValidator>
                    </div>


                    <div class="form_row">
                    <label class="contact"><strong>电话号码:</strong></label>
                    <asp:TextBox ID="txtPhoneNum" runat="server" Width="156px" MaxLength="20"></asp:TextBox>
                    </div>
                    
                    <div class="form_row">
                    <label class="contact"><strong>邮寄地址:</strong></label>
                    <asp:TextBox ID="txtPostAdd" runat="server" Width="156px" MaxLength="200"></asp:TextBox>
                    </div>
                    
                    <div class="form_row">
                    <label class="contact"><strong>邮政编码:</strong></label>
                    <asp:TextBox ID="txtPostNum" runat="server" Width="156px" MaxLength="6"></asp:TextBox>
                    </div>
                    
                    <div class="form_row">
                    <label class="contact"><strong>安全问题:</strong></label>
                    <asp:TextBox ID="Question" runat="server" Width="156px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="QuestionRequired" runat="server" ControlToValidate="Question" 
                    ErrorMessage="必须填写“安全提示问题”。" ToolTip="必须填写“安全提示问题”。" ValidationGroup="CreateUserWizard" 
                    ForeColor="red">*</asp:RequiredFieldValidator>
                    </div>
                    
                    <div class="form_row">
                    <label class="contact"><strong>安全答案:</strong></label>
                    <asp:TextBox ID="Answer" runat="server" Width="156px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="AnswerRequired" runat="server" ControlToValidate="Answer" 
                    ErrorMessage="必须填写“安全答案”。" ToolTip="必须填写“安全答案”。" ValidationGroup="CreateUserWizard" 
                    ForeColor="red">*</asp:RequiredFieldValidator>
                    </div>
                    
                    <table>
                    <tr>
                    <td>
                    <div class="form_row">
                        <input type="button" class="register" value="<选填信息" onclick="showsubmenu(30)"/>
                    </div>
                    </td>
                    </tr>
                    
                    <tr>
                    <td id="submenu30" style="display:none;">
                    <div class="form_row">
                        <label class="contact"><strong>性　　别:</strong></label>
                        <asp:RadioButtonList ID="rdlUserGender" runat="server" RepeatDirection="Horizontal" 
                        Style="left: 60px; top: 5px" Height="20px" Width="222px">
                            <asp:ListItem Selected="True" Value="0">保密</asp:ListItem>
                            <asp:ListItem Value="1">男</asp:ListItem>
                            <asp:ListItem Value="2">女</asp:ListItem>
                            <asp:ListItem Value="3">春哥</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                    
                    <div class="form_row">
                        <label class="contact"><strong>生　　日:</strong></label>
                        <asp:TextBox ID="txtUserBirth" runat="server" Width="156px"></asp:TextBox>
                    </div>
                    
                    <div class="form_row">
                        <label class="contact"><strong>身份证号:</strong></label>
                        <asp:TextBox ID="txtIDCardNum" runat="server" Width="156px"></asp:TextBox>
                    </div>
                    </td>
                    </tr>
                    </table>
                    
                    <div class="form_row">
                        <div class="terms">
                        <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password" 
                        ControlToValidate="ConfirmPassword" Display="Dynamic" ErrorMessage="“密码”和“确认密码”必须匹配。" 
                        ValidationGroup="CreateUserWizard1" ForeColor="red"></asp:CompareValidator>
                            <br />
                            <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="Email"
                                Display="Dynamic" ErrorMessage="电子邮箱格式错误" ToolTip="电子邮箱格式错误" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                ValidationGroup="CreateUserWizard">电子邮箱格式错误</asp:RegularExpressionValidator>
                            <asp:RegularExpressionValidator ID="revIDCardNum" runat="server" ControlToValidate="txtIDCardNum"
                                ErrorMessage="身份证号码格式错误" ToolTip="身份证号码格式错误" ValidationExpression="\d{17}[\d|X]|\d{15}"
                                ValidationGroup="CreateUserWizard"></asp:RegularExpressionValidator><br />
                            <asp:RegularExpressionValidator ID="revPhone" runat="server" ControlToValidate="txtPhoneNum"
                                Display="Dynamic" ErrorMessage="电话号码格式错误" ToolTip="电话号码格式错误" ValidationExpression="((\d{11})|^((\d{7,8})|(\d{4}|\d{3})-(\d{7,8})|(\d{4}|\d{3})-(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1})|(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1}))$)"
                                ValidationGroup="CreateUserWizard"></asp:RegularExpressionValidator>
                            <asp:RegularExpressionValidator ID="revBirthday" runat="server" ControlToValidate="txtUserBirth"
                                ErrorMessage="生日请按xxxx-xx-xx格式填写并保证日期无误" ToolTip="生日请按xxxx-xx-xx格式填写并保证日期无误"
                                ValidationExpression="((^((1[8-9]\d{2})|([2-9]\d{3}))([-\/\._])(10|12|0?[13578])([-\/\._])(3[01]|[12][0-9]|0?[1-9])$)|(^((1[8-9]\d{2})|([2-9]\d{3}))([-\/\._])(11|0?[469])([-\/\._])(30|[12][0-9]|0?[1-9])$)|(^((1[8-9]\d{2})|([2-9]\d{3}))([-\/\._])(0?2)([-\/\._])(2[0-8]|1[0-9]|0?[1-9])$)|(^([2468][048]00)([-\/\._])(0?2)([-\/\._])(29)$)|(^([3579][26]00)([-\/\._])(0?2)([-\/\._])(29)$)|(^([1][89][0][48])([-\/\._])(0?2)([-\/\._])(29)$)|(^([2-9][0-9][0][48])([-\/\._])(0?2)([-\/\._])(29)$)|(^([1][89][2468][048])([-\/\._])(0?2)([-\/\._])(29)$)|(^([2-9][0-9][2468][048])([-\/\._])(0?2)([-\/\._])(29)$)|(^([1][89][13579][26])([-\/\._])(0?2)([-\/\._])(29)$)|(^([2-9][0-9][13579][26])([-\/\._])(0?2)([-\/\._])(29)$))"
                                ValidationGroup="CreateUserWizard"></asp:RegularExpressionValidator><br />
                            <asp:RegularExpressionValidator ID="revPostCode" runat="server" ControlToValidate="txtPostNum"
                                Display="Dynamic" ErrorMessage="邮政编码错误" ValidationExpression="\d{6}" ValidationGroup="CreateUserWizard"></asp:RegularExpressionValidator>
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
                        我同意 <a href="#">Sherry化妆品网上销售协议</a>
                        </div>
                    </div>   
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
                    <CreateUserButtonStyle CssClass="register" />
                </asp:CreateUserWizard>  
                </div>  
            
          </div>
                        
</asp:Content>
