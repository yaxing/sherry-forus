<%@ Page Language="C#" MasterPageFile="~/IndexMaster.master" AutoEventWireup="true" CodeFile="MyAccount.aspx.cs" Inherits="MyAccount" Title="我的帐户" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentHolder" Runat="Server">
    <asp:LoginView ID="LoginView" runat="server">
        <AnonymousTemplate>
            <div class="title"><span class="title_icon"><img src="images/bullet1.gif" alt="" title="" /></span>我的帐户</div>
        
        	<div class="feat_prod_box_details">
            <p class="details">
             请输入您注册时填写的用户名和密码登陆本站点以完成定购服务。<br/>
			 如果您还没有注册，请点击导航菜单的“注册”项进行注册。<br/>
			 如果您忘记了密码，请点击找回密码按钮找回您的密码。<br/>
			 感谢您支持本站，请享受我们为您提供的服务。
            </p>
            
              	<div class="contact_form">
                <div class="form_subtitle">使用您的帐户登陆</div>         
                      <asp:Login ID="Login1" runat="server">
                          <LayoutTemplate>
                              <div class="form_row">
                                  <label class="contact"><strong>用户名:</strong></label>
                                  <asp:TextBox ID="UserName" runat="server" Width="158px"></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" 
                                  ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="ctl06$Login1">*</asp:RequiredFieldValidator>
                              </div>  


                              <div class="form_row">
                                  <label class="contact"><strong>密　码:</strong></label>
                                  <asp:TextBox ID="Password" runat="server" TextMode="Password" Width="158px"></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" 
                                  ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="ctl06$Login1">*</asp:RequiredFieldValidator>
                              </div>                     

                              <div class="form_row">
                                  <div class="terms">
                                  <asp:CheckBox ID="RememberMe" runat="server" Text="记住我" />　　　
                                  <a href="GetPassword.aspx">忘记密码？</a>
                                  </div>
                              </div> 

                    
                              <div class="form_row">
                                  <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                              </div>
                              
                              <div class="form_row">
                                  <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="登录" ValidationGroup="ctl06$Login1" class="register"/>
                              </div>
                              
                          </LayoutTemplate>
                      </asp:Login>    
                    
                </div>  
            
            </div>
        </AnonymousTemplate>
        <LoggedInTemplate>
            <div class="title"><span class="title_icon"><img src="images/bullet1.gif" alt="" title="" /></span><asp:LoginName ID="LoginName1" runat="server" />的帐户　　<font face="微软雅黑" size="small"><asp:LoginStatus ID="LoginStatus" runat="server" LoginText="" LogoutText="登出" /></font></div>
            <div class="feat_prod_box_details">
            <p class="details">
             欢迎回来，<asp:LoginName ID="LoginName2" runat="server" /><br/>
			 您可以在登录后查看、修改您的注册信息。<br/>
			 您可以通过本页面修改您的密码等信息<br/>
			 您也可以通过本页面查看您的积分和用户级别
            </p>
            
              	<div class="contact_form">
                <div class="form_subtitle">您的帐户信息</div>
                    <div class="form_row">
                        <label class="contact"><strong>注册姓名:</strong></label>
                        <asp:Label ID="lblRealName" runat="server" Text="" class="contact"></asp:Label>
                    </div>
                    
                    <div class="form_row">
                        <label class="contact"><strong>注册邮箱:</strong></label>
                        <asp:Label ID="lblEmailAdd" runat="server" Text="" class="contact"></asp:Label>
                    </div>
                    
                    <div class="form_row">
                        <label class="contact"><strong>邮寄地址:</strong></label>
                        <asp:Label ID="lblAddress" runat="server" Text="" class="contact"></asp:Label>
                    </div>
                    
                    <div class="form_row">
                        <label class="contact"><strong>邮政编码:</strong></label>
                        <asp:Label ID="lblPostCode" runat="server" Text="" class="contact"></asp:Label>
                    </div>
                    
                    <div class="form_row">
                        <label class="contact"><strong>联系电话:</strong></label>
                        <asp:Label ID="lblPhoneNum" runat="server" Text="" class="contact"></asp:Label>
                    </div>
                    
                    <div class="form_row">
                        <label class="contact"><strong>性　　别:</strong></label>
                        <asp:Label ID="lblGender" runat="server" Text="" class="contact"></asp:Label>
                    </div>
                    
                    <div class="form_row">
                        <label class="contact"><strong>生　　日:</strong></label>
                        <asp:Label ID="lblBirth" runat="server" Text="" class="contact"></asp:Label>
                    </div>
                    
                    <div class="form_row">
                        <label class="contact"><strong>身份证号:</strong></label>
                        <asp:Label ID="lblIDCardNum" runat="server" Text="" class="contact"></asp:Label>
                    </div>
                    
                    <div class="form_row">
                        <label class="contact"><strong>当前积分:</strong></label>
                        <asp:Label ID="lblScore" runat="server" Text="" class="contact"></asp:Label>
                    </div>
                    
                    <div class="form_row">
                        <label class="contact"><strong>您的级别:</strong></label>
                        <asp:Label ID="lblUserLv" runat="server" Text="" class="contact"></asp:Label>
                    </div>
                    
                    <div class="form_row">
                        <asp:Button ID="BtnModiPwd" runat="server" Text="修改密码" class="register" OnClick="BtnModiPwd_Click"/>
                        <asp:Button ID="BtnModiInfo" runat="server" Text="修改信息" class="register" OnClick="BtnModiInfo_Click"/>
                    </div>
                </div>
            </div>
        </LoggedInTemplate>
    </asp:LoginView>
</asp:Content>

