<%@ Page Language="C#" MasterPageFile="~/IndexMaster.master" AutoEventWireup="true" CodeFile="GetPassword.aspx.cs" Inherits="GetPassword" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentHolder" Runat="Server">

<div class="title"><span class="title_icon"><img src="images/bullet1.gif" alt="" title="" /></span>�һ���������</div>
        <div class="feat_prod_box_details">
            <p class="details">
             ������ͨ������<font color="blue">�û���</font>��<font color="blue">ע��ʱ</font>��д��<font color="blue">��ȫ��</font>�һ��������롣<br/>
			 �������뽫�ᷢ�͵���<font color="blue">��ǰ</font>������Ϣ����д��<font color="blue">��������</font>��<br/>
			 �����������ǵ���ʾ�һ��������롣
            </p>
        <asp:PasswordRecovery ID="PasswordRecovery1" runat="server">
            <QuestionTemplate>
              <div class="contact_form">
                <div class="form_subtitle">�ڶ���</div>
                
                  <div class="form_row">
                      <font color="blue"><asp:Literal ID="UserName" runat="server"></asp:Literal></font>���ã�
                  </div>
                  
                  <div class="form_row">
                      ������<font color="blue">ע��ʱ</font>�����������ʾ����<font color="blue">��</font>
                  </div>
                  
                  <div class="form_row">
                      &nbsp;
                  </div>
                  
                  <div class="form_row">
                      ���趨������Ϊ:<asp:Literal ID="Question" runat="server"></asp:Literal>
                  </div>
                  
                  <div class="form_row">
                      <asp:Label ID="AnswerLabel" runat="server" AssociatedControlID="Answer" Height="15px" Width="146px">���������Ļش�:</asp:Label>
                      <asp:TextBox ID="Answer" runat="server"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="AnswerRequired" runat="server" 
                      ControlToValidate="Answer" ErrorMessage="��Ҫ�𰸡�" ToolTip="��Ҫ�𰸡�" 
                      ValidationGroup="PasswordRecovery1">*</asp:RequiredFieldValidator>
                  </div>
                  
                  <div class="form_row">
                    <div class="terms">
                      <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                    </div>
                  </div>
                  
                  <div class="form_row">
                      <asp:Button ID="SubmitButton" runat="server" CommandName="Submit" Text="����" 
                      ValidationGroup="PasswordRecovery1" CssClass="register"/>
                  </div>
                  
                </div>
            </QuestionTemplate>
            <UserNameTemplate>
              <div class="contact_form">
                <div class="form_subtitle">��һ��</div>
                
                  <div class="form_row">
                      ������<font color="blue">ע��ʱ</font>�����<font color="blue">�û���</font>
                  </div>
                  
                  <div class="form_row">
                      &nbsp;
                  </div>
                  
                  <div class="form_row">
                      ����������<font color="blue">�û���</font>���Ա����ǻ�ȡ����ע����Ϣ��
                  </div>
                  
                  <div class="form_row">
                      <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">�û���:</asp:Label>
                      <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" 
                      ControlToValidate="UserName" ErrorMessage="������д���û�������" ToolTip="������д���û�������" 
                      ValidationGroup="PasswordRecovery1">*</asp:RequiredFieldValidator>
                  </div>
                  
                  <div class="form_row">
                    <div class="terms">
                      <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                    </div>
                  </div>
                  
                  <div class="form_row">
                      <asp:Button ID="SubmitButton" runat="server" CommandName="Submit" Text="�ύ" 
                      ValidationGroup="PasswordRecovery1" CssClass="register"/>
                  </div>
                
              </div>
            </UserNameTemplate>
            <SuccessTemplate>
              <div class="contact_form">
                <div class="form_subtitle">���</div>
                
                  <div class="form_row">
                      ����<font color="blue">����</font>�ѷ��͵�����<font color="blue">��ǰ����</font>����ע����ա�
                  </div>
                  
                  <div class="form_row">
                      &nbsp;
                  </div>
                  
                  <div class="form_row">
                      <a href="Index.aspx">�ص���ҳ���������>></a>
                  </div>
                  
              </div>
            </SuccessTemplate>
        </asp:PasswordRecovery>
        </div>

</asp:Content>

