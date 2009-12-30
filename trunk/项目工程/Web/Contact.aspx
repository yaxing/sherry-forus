<%@ Page Language="C#" MasterPageFile="~/IndexMaster.master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentHolder" Runat="Server">

<div class="title"><span class="title_icon"><img src="images/bullet1.gif" alt="" title="" /></span>联系我们</div> 
        
        	<div class="feat_prod_box_details"> 
            <p class="details"> 
             感谢您对本公司的支持。<br/> 
			 您可以通过本页面向我公司客户服务部门反映您在购买或使用我公司商品时遇到的各种问题。当然，我们也欢迎你指出我们工作中的缺陷与不足，我们会积极改正。<br/> 
			 欢迎您对本公司提出意见或建议。我们的客服人员竭诚为您服务，您的反映的问题将在7个工作日内得到回复。再次感谢您对本公司的支持。
            </p> 
            
              	<div class="contact_form"> 
                <div class="form_subtitle">期待您的意见</div>          
                    <div class="form_row"> 
                    <label class="contact"><strong>您的姓名:</strong></label> 
                    <asp:TextBox ID="txtName" runat="server" MaxLength="30" class="contact_input"></asp:TextBox>
                    </div>  
 
                    <div class="form_row"> 
                    <label class="contact"><strong>电子邮箱:</strong></label> 
                    <asp:TextBox ID="txtEmail" runat="server" MaxLength="50" class="contact_input"></asp:TextBox> 
                    </div> 
 
 
                    <div class="form_row"> 
                    <label class="contact"><strong>电话号码:</strong></label> 
                    <asp:TextBox ID="txtPhoneNum" runat="server" MaxLength="20" class="contact_input"></asp:TextBox>
                    </div> 
                    
                    <div class="form_row"> 
                    <label class="contact"><strong>问题概要:</strong></label> 
                    <asp:TextBox ID="txtSub" runat="server" MaxLength="50" class="contact_input"></asp:TextBox>
                    </div> 
 
 
                    <div class="form_row"> 
                    <label class="contact"><strong>您的意见:</strong></label> 
                    <asp:TextBox ID="txtDetail" runat="server" TextMode="MultiLine" class="contact_textarea"></asp:TextBox>
                    </div> 
 
                    
                    <div class="form_row"> 
                        <asp:LinkButton ID="LinkButton1" runat="server" class="contact" OnClick="LinkButton1_Click">发送</asp:LinkButton>
                    </div>      
                </div>
                <div class="contact_form"> 
                <div class="form_subtitle">其他联系方式</div>          
                    <div class="form_row"> 
                    <label class="contact"><strong>客服电话:</strong></label> 
                    <label class="contact" style="width:100px; text-align:left;">800-800-8000</label> 
                    </div>
                    <div class="form_row"> 
                    <label class="contact"><strong>客服电话:</strong></label> 
                    <label class="contact" style="width:100px; text-align:left;">010-68915667</label> 
                    </div>
                    <div class="form_row"> 
                    <label class="contact"><strong>邮寄地址:</strong></label> 
                    <label class="contact" style="width:250px; text-align:left;">北京市海淀区中关村南大街5号软件实训中心</label> 
                    </div>
                    <div class="form_row"> 
                    <label class="contact"><strong>邮政编码:</strong></label> 
                    <label class="contact" style="width:100px; text-align:left;">100081</label> 
                    </div>
                </div>  
            
          </div>

</asp:Content>

