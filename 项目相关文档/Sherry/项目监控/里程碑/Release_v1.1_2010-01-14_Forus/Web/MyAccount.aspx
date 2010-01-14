<%@ Page Language="C#" MasterPageFile="~/IndexMaster.master" AutoEventWireup="true" CodeFile="MyAccount.aspx.cs" Inherits="MyAccount" Title="�ҵ��ʻ�" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentHolder" Runat="Server">
    <asp:LoginView ID="LoginView" runat="server">
        <AnonymousTemplate>
            <div class="title"><span class="title_icon"><img src="images/bullet1.gif" alt="" title="" /></span>�ҵ��ʻ�</div>
        
        	<div class="feat_prod_box_details">
            <p class="details">
             ��������ע��ʱ��д���û����������½��վ������ɶ�������<br/>
			 �������û��ע�ᣬ���������˵��ġ�ע�ᡱ�����ע�ᡣ<br/>
			 ��������������룬�����һ����밴ť�һ��������롣<br/>
			 ��л��֧�ֱ�վ������������Ϊ���ṩ�ķ���
            </p>
            
              	<div class="contact_form">
                <div class="form_subtitle">ʹ�������ʻ���½</div>         
                      <asp:Login ID="Login1" runat="server">
                          <LayoutTemplate>
                              <div class="form_row">
                                  <label class="contact"><strong>�û���:</strong></label>
                                  <asp:TextBox ID="UserName" runat="server" Width="158px"></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" 
                                  ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="ctl06$Login1">*</asp:RequiredFieldValidator>
                              </div>  


                              <div class="form_row">
                                  <label class="contact"><strong>�ܡ���:</strong></label>
                                  <asp:TextBox ID="Password" runat="server" TextMode="Password" Width="158px"></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" 
                                  ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="ctl06$Login1">*</asp:RequiredFieldValidator>
                              </div>                     

                              <div class="form_row">
                                  <div class="terms">
                                  <asp:CheckBox ID="RememberMe" runat="server" Text="��ס��" />������
                                  <a href="GetPassword.aspx">�������룿</a>
                                  </div>
                              </div> 

                    
                              <div class="form_row">
                                  <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                              </div>
                              
                              <div class="form_row">
                                  <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="��¼" ValidationGroup="ctl06$Login1" class="register"/>
                              </div>
                              
                          </LayoutTemplate>
                      </asp:Login>    
                    
                </div>  
            
            </div>
        </AnonymousTemplate>
        <LoggedInTemplate>
            <div class="title"><span class="title_icon"><img src="images/bullet1.gif" alt="" title="" /></span><asp:LoginName ID="LoginName1" runat="server" />���ʻ�����<font face="΢���ź�" size="small"><asp:LoginStatus ID="LoginStatus" runat="server" LoginText="" LogoutText="�ǳ�" /></font></div>
            <div class="feat_prod_box_details">
            <p class="details">
             ��ӭ������<asp:LoginName ID="LoginName2" runat="server" /><br/>
			 �������ڵ�¼��鿴���޸�����ע����Ϣ��<br/>
			 ������ͨ����ҳ���޸������������Ϣ<br/>
			 ��Ҳ����ͨ����ҳ��鿴���Ļ��ֺ��û�����
            </p>
            
              	<div class="contact_form">
                <div class="form_subtitle">�����ʻ���Ϣ</div>
                    <div class="form_row">
                        <label class="contact"><strong>ע������:</strong></label>
                        <asp:Label ID="lblRealName" runat="server" Text="" class="contact"></asp:Label>
                    </div>
                    
                    <div class="form_row">
                        <label class="contact"><strong>ע������:</strong></label>
                        <asp:Label ID="lblEmailAdd" runat="server" Text="" class="contact"></asp:Label>
                    </div>
                    
                    <div class="form_row">
                        <label class="contact"><strong>�ʼĵ�ַ:</strong></label>
                        <asp:Label ID="lblAddress" runat="server" Text="" class="contact"></asp:Label>
                    </div>
                    
                    <div class="form_row">
                        <label class="contact"><strong>��������:</strong></label>
                        <asp:Label ID="lblPostCode" runat="server" Text="" class="contact"></asp:Label>
                    </div>
                    
                    <div class="form_row">
                        <label class="contact"><strong>��ϵ�绰:</strong></label>
                        <asp:Label ID="lblPhoneNum" runat="server" Text="" class="contact"></asp:Label>
                    </div>
                    
                    <div class="form_row">
                        <label class="contact"><strong>�ԡ�����:</strong></label>
                        <asp:Label ID="lblGender" runat="server" Text="" class="contact"></asp:Label>
                    </div>
                    
                    <div class="form_row">
                        <label class="contact"><strong>��������:</strong></label>
                        <asp:Label ID="lblBirth" runat="server" Text="" class="contact"></asp:Label>
                    </div>
                    
                    <div class="form_row">
                        <label class="contact"><strong>���֤��:</strong></label>
                        <asp:Label ID="lblIDCardNum" runat="server" Text="" class="contact"></asp:Label>
                    </div>
                    
                    <div class="form_row">
                        <label class="contact"><strong>��ǰ����:</strong></label>
                        <asp:Label ID="lblScore" runat="server" Text="" class="contact"></asp:Label>
                    </div>
                    
                    <div class="form_row">
                        <label class="contact"><strong>���ļ���:</strong></label>
                        <asp:Label ID="lblUserLv" runat="server" Text="" class="contact"></asp:Label>
                    </div>
                    
                    <div class="form_row">
                        <asp:Button ID="BtnModiPwd" runat="server" Text="�޸�����" class="register" OnClick="BtnModiPwd_Click"/>
                        <asp:Button ID="BtnModiInfo" runat="server" Text="�޸���Ϣ" class="register" OnClick="BtnModiInfo_Click"/>
                    </div>
                </div>
            </div>
        </LoggedInTemplate>
    </asp:LoginView>
</asp:Content>

