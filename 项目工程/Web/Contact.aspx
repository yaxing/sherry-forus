<%@ Page Language="C#" MasterPageFile="~/IndexMaster.master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentHolder" Runat="Server">

<div class="title"><span class="title_icon"><img src="images/bullet1.gif" alt="" title="" /></span>��ϵ����</div> 
        
        	<div class="feat_prod_box_details"> 
            <p class="details"> 
             ��л���Ա���˾��֧�֡�<br/> 
			 ������ͨ����ҳ�����ҹ�˾�ͻ������ŷ�ӳ���ڹ����ʹ���ҹ�˾��Ʒʱ�����ĸ������⡣��Ȼ������Ҳ��ӭ��ָ�����ǹ����е�ȱ���벻�㣬���ǻ����������<br/> 
			 ��ӭ���Ա���˾���������顣���ǵĿͷ���Ա�߳�Ϊ���������ķ�ӳ�����⽫��7���������ڵõ��ظ����ٴθ�л���Ա���˾��֧�֡�
            </p> 
            
              	<div class="contact_form"> 
                <div class="form_subtitle">�ڴ��������</div>          
                    <div class="form_row"> 
                    <label class="contact"><strong>��������:</strong></label> 
                    <asp:TextBox ID="txtName" runat="server" MaxLength="30" class="contact_input"></asp:TextBox>
                    </div>  
 
                    <div class="form_row"> 
                    <label class="contact"><strong>��������:</strong></label> 
                    <asp:TextBox ID="txtEmail" runat="server" MaxLength="50" class="contact_input"></asp:TextBox> 
                    </div> 
 
 
                    <div class="form_row"> 
                    <label class="contact"><strong>�绰����:</strong></label> 
                    <asp:TextBox ID="txtPhoneNum" runat="server" MaxLength="20" class="contact_input"></asp:TextBox>
                    </div> 
                    
                    <div class="form_row"> 
                    <label class="contact"><strong>�����Ҫ:</strong></label> 
                    <asp:TextBox ID="txtSub" runat="server" MaxLength="50" class="contact_input"></asp:TextBox>
                    </div> 
 
 
                    <div class="form_row"> 
                    <label class="contact"><strong>�������:</strong></label> 
                    <asp:TextBox ID="txtDetail" runat="server" TextMode="MultiLine" class="contact_textarea"></asp:TextBox>
                    </div> 
 
                    
                    <div class="form_row"> 
                        <asp:LinkButton ID="LinkButton1" runat="server" class="contact" OnClick="LinkButton1_Click">����</asp:LinkButton>
                    </div>      
                </div>
                <div class="contact_form"> 
                <div class="form_subtitle">������ϵ��ʽ</div>          
                    <div class="form_row"> 
                    <label class="contact"><strong>�ͷ��绰:</strong></label> 
                    <label class="contact" style="width:100px; text-align:left;">800-800-8000</label> 
                    </div>
                    <div class="form_row"> 
                    <label class="contact"><strong>�ͷ��绰:</strong></label> 
                    <label class="contact" style="width:100px; text-align:left;">010-68915667</label> 
                    </div>
                    <div class="form_row"> 
                    <label class="contact"><strong>�ʼĵ�ַ:</strong></label> 
                    <label class="contact" style="width:250px; text-align:left;">�����к������йش��ϴ��5�����ʵѵ����</label> 
                    </div>
                    <div class="form_row"> 
                    <label class="contact"><strong>��������:</strong></label> 
                    <label class="contact" style="width:100px; text-align:left;">100081</label> 
                    </div>
                </div>  
            
          </div>

</asp:Content>

