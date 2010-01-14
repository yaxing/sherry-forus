<%@ Page Language="C#" MasterPageFile="~/IndexMaster.master" AutoEventWireup="true" CodeFile="ChangePwd.aspx.cs" Inherits="ChangePwd" Title="修改密码" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentHolder" Runat="Server">

     <div class="title"><span class="title_icon"><img src="../images/bullet1.gif" alt="" title="" /></span>修改您的密码</div>
        
        	<div class="feat_prod_box_details">
            <p class="details">
			 请您在修改密码前填写正确的个人密码。<br/>
             请确保您的确认密码与新密码一致<br/>
            </p>
            
              	<div class="contact_form">
                <div class="form_subtitle">修改您的帐户</div>
                
                    <div class="form_row">
                        <asp:Label ID="lblOldPwd" runat="server" Text="原&nbsp;&nbsp;密&nbsp;&nbsp;码："></asp:Label>
                        <asp:TextBox ID="txtUserPwd" runat="server" Width="158px" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="txtUserPwd" 
                        ErrorMessage="请填写原始密码" ToolTip="请填写原始密码" ValidationGroup="ModiPwd">*</asp:RequiredFieldValidator>
                    </div>
                    
                    <div class="form_row">
                        <asp:Label ID="lblNewPwd" runat="server" Text="新&nbsp;&nbsp;密&nbsp;&nbsp;码："></asp:Label>
                        <asp:TextBox ID="txtNewPwd" runat="server" Width="158px" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server" ControlToValidate="txtNewPwd" 
                        ErrorMessage="请填写新密码" ToolTip="请填写新密码" ValidationGroup="ModiPwd">*</asp:RequiredFieldValidator>
                    </div>
                    
                    <div class="form_row">
                        <asp:Label ID="lblNewPwdC" runat="server" Text="确认密码："></asp:Label>
                        <asp:TextBox ID="txtNewPwdC" runat="server" Width="158px" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="NewPasswordCRequired" runat="server" ControlToValidate="txtNewPwdC" 
                        ErrorMessage="请确认新密码" ToolTip="请确认新密码" ValidationGroup="ModiPwd">*</asp:RequiredFieldValidator>
                    </div>
                    
                    <div class="form_row">
                      <div class="terms">
                        <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="txtNewPwd" 
                        ControlToValidate="txtNewPwdC" Display="Dynamic" 
                        ForeColor="red" ValidationGroup="ModiPwd">“密码”和“确认密码”必须匹配。</asp:CompareValidator>
                        <asp:ValidationSummary ID="ModiPwdValidationSummary" runat="server" ValidationGroup="ModiPwd" />
                      </div>
                    </div>
                    
                    <div class="form_row">
                        <asp:Button ID="btnBack" runat="server" Text="返回" CssClass="register" OnClick="btnBack_Click"/>
                        <asp:Button ID="btnCommit" runat="server" Text="确认修改" CssClass="register" OnClick="btnCommit_Click" ValidationGroup="ModiPwd"/>
                    </div>
                </div>
            </div>

</asp:Content>

