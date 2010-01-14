<%@ Page Language="C#" MasterPageFile="~/IndexMaster.master" AutoEventWireup="true" CodeFile="GetPassword.aspx.cs" Inherits="GetPassword" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentHolder" Runat="Server">

<div class="title"><span class="title_icon"><img src="images/bullet1.gif" alt="" title="" /></span>找回您的密码</div>
        <div class="feat_prod_box_details">
            <p class="details">
             您可以通过您的<font color="blue">用户名</font>和<font color="blue">注册时</font>填写的<font color="blue">安全答案</font>找回您的密码。<br/>
			 您的密码将会发送到您<font color="blue">当前</font>个人信息中填写的<font color="blue">电子邮箱</font>。<br/>
			 请您根据我们的提示找回您的密码。
            </p>
        <asp:PasswordRecovery ID="PasswordRecovery1" runat="server">
            <QuestionTemplate>
              <div class="contact_form">
                <div class="form_subtitle">第二步</div>
                
                  <div class="form_row">
                      <font color="blue"><asp:Literal ID="UserName" runat="server"></asp:Literal></font>您好！
                  </div>
                  
                  <div class="form_row">
                      输入您<font color="blue">注册时</font>输入的密码提示问题<font color="blue">答案</font>
                  </div>
                  
                  <div class="form_row">
                      &nbsp;
                  </div>
                  
                  <div class="form_row">
                      您设定的问题为:<asp:Literal ID="Question" runat="server"></asp:Literal>
                  </div>
                  
                  <div class="form_row">
                      <asp:Label ID="AnswerLabel" runat="server" AssociatedControlID="Answer" Height="15px" Width="146px">请输入您的回答:</asp:Label>
                      <asp:TextBox ID="Answer" runat="server"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="AnswerRequired" runat="server" 
                      ControlToValidate="Answer" ErrorMessage="需要答案。" ToolTip="需要答案。" 
                      ValidationGroup="PasswordRecovery1">*</asp:RequiredFieldValidator>
                  </div>
                  
                  <div class="form_row">
                    <div class="terms">
                      <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                    </div>
                  </div>
                  
                  <div class="form_row">
                      <asp:Button ID="SubmitButton" runat="server" CommandName="Submit" Text="继续" 
                      ValidationGroup="PasswordRecovery1" CssClass="register"/>
                  </div>
                  
                </div>
            </QuestionTemplate>
            <UserNameTemplate>
              <div class="contact_form">
                <div class="form_subtitle">第一步</div>
                
                  <div class="form_row">
                      输入您<font color="blue">注册时</font>输入的<font color="blue">用户名</font>
                  </div>
                  
                  <div class="form_row">
                      &nbsp;
                  </div>
                  
                  <div class="form_row">
                      请输入您的<font color="blue">用户名</font>，以便我们获取您的注册信息。
                  </div>
                  
                  <div class="form_row">
                      <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">用户名:</asp:Label>
                      <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" 
                      ControlToValidate="UserName" ErrorMessage="必须填写“用户名”。" ToolTip="必须填写“用户名”。" 
                      ValidationGroup="PasswordRecovery1">*</asp:RequiredFieldValidator>
                  </div>
                  
                  <div class="form_row">
                    <div class="terms">
                      <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                    </div>
                  </div>
                  
                  <div class="form_row">
                      <asp:Button ID="SubmitButton" runat="server" CommandName="Submit" Text="提交" 
                      ValidationGroup="PasswordRecovery1" CssClass="register"/>
                  </div>
                
              </div>
            </UserNameTemplate>
            <SuccessTemplate>
              <div class="contact_form">
                <div class="form_subtitle">完成</div>
                
                  <div class="form_row">
                      您的<font color="blue">密码</font>已发送到您的<font color="blue">当前邮箱</font>，请注意查收。
                  </div>
                  
                  <div class="form_row">
                      &nbsp;
                  </div>
                  
                  <div class="form_row">
                      <a href="Index.aspx">回到主页，继续浏览>></a>
                  </div>
                  
              </div>
            </SuccessTemplate>
        </asp:PasswordRecovery>
        </div>

</asp:Content>

