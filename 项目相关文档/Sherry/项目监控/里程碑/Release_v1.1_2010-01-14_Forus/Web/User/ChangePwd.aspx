<%@ Page Language="C#" MasterPageFile="~/IndexMaster.master" AutoEventWireup="true" CodeFile="ChangePwd.aspx.cs" Inherits="ChangePwd" Title="�޸�����" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentHolder" Runat="Server">

     <div class="title"><span class="title_icon"><img src="../images/bullet1.gif" alt="" title="" /></span>�޸���������</div>
        
        	<div class="feat_prod_box_details">
            <p class="details">
			 �������޸�����ǰ��д��ȷ�ĸ������롣<br/>
             ��ȷ������ȷ��������������һ��<br/>
            </p>
            
              	<div class="contact_form">
                <div class="form_subtitle">�޸������ʻ�</div>
                
                    <div class="form_row">
                        <asp:Label ID="lblOldPwd" runat="server" Text="ԭ&nbsp;&nbsp;��&nbsp;&nbsp;�룺"></asp:Label>
                        <asp:TextBox ID="txtUserPwd" runat="server" Width="158px" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="txtUserPwd" 
                        ErrorMessage="����дԭʼ����" ToolTip="����дԭʼ����" ValidationGroup="ModiPwd">*</asp:RequiredFieldValidator>
                    </div>
                    
                    <div class="form_row">
                        <asp:Label ID="lblNewPwd" runat="server" Text="��&nbsp;&nbsp;��&nbsp;&nbsp;�룺"></asp:Label>
                        <asp:TextBox ID="txtNewPwd" runat="server" Width="158px" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server" ControlToValidate="txtNewPwd" 
                        ErrorMessage="����д������" ToolTip="����д������" ValidationGroup="ModiPwd">*</asp:RequiredFieldValidator>
                    </div>
                    
                    <div class="form_row">
                        <asp:Label ID="lblNewPwdC" runat="server" Text="ȷ�����룺"></asp:Label>
                        <asp:TextBox ID="txtNewPwdC" runat="server" Width="158px" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="NewPasswordCRequired" runat="server" ControlToValidate="txtNewPwdC" 
                        ErrorMessage="��ȷ��������" ToolTip="��ȷ��������" ValidationGroup="ModiPwd">*</asp:RequiredFieldValidator>
                    </div>
                    
                    <div class="form_row">
                      <div class="terms">
                        <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="txtNewPwd" 
                        ControlToValidate="txtNewPwdC" Display="Dynamic" 
                        ForeColor="red" ValidationGroup="ModiPwd">�����롱�͡�ȷ�����롱����ƥ�䡣</asp:CompareValidator>
                        <asp:ValidationSummary ID="ModiPwdValidationSummary" runat="server" ValidationGroup="ModiPwd" />
                      </div>
                    </div>
                    
                    <div class="form_row">
                        <asp:Button ID="btnBack" runat="server" Text="����" CssClass="register" OnClick="btnBack_Click"/>
                        <asp:Button ID="btnCommit" runat="server" Text="ȷ���޸�" CssClass="register" OnClick="btnCommit_Click" ValidationGroup="ModiPwd"/>
                    </div>
                </div>
            </div>

</asp:Content>

