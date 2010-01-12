<%@ Page Language="C#" MasterPageFile="~/IndexMaster.master" AutoEventWireup="true" CodeFile="ModiUser.aspx.cs" Inherits="ModiUser" Title="无标题页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentHolder" Runat="Server">

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

<div class="title"><span class="title_icon"><img src="images/bullet1.gif" alt="" title="" /></span>修改您的帐户信息</div>
        
       <div class="feat_prod_box_details">
            <p class="details">
			 请你确保填写的数据正确完整。<br/>
			 如果您修改了地址,请确保地址与邮政编码对应。<br/>
			 如果您不修改个人信息,请点击返回按钮。<br/>
			 感谢您支持本站，祝您愉快。
            </p>
            
            <div class="contact_form">
                <div class="form_subtitle">修改<asp:Label ID="lblName" runat="server" Text=""></asp:Label>的帐户信息</div>
                
                <div class="form_row">
                    <asp:Label ID="lblUserRealName" runat="server" Text="真实姓名:"></asp:Label>
                    <asp:TextBox ID="txtRealName" runat="server" MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvRealName" runat="server" ControlToValidate="txtRealName" 
                    ErrorMessage="真实姓名不能为空;" ForeColor="White" ValidationGroup="ModiUserInfo" Display="Dynamic" ToolTip="真实姓名不能为空;">*</asp:RequiredFieldValidator>
                </div>
                
                <div class="form_row">
                    <asp:Label ID="lblPostAdd" runat="server" Text="邮寄地址:"></asp:Label>
                    <asp:TextBox ID="txtPostAdd" runat="server" MaxLength="200"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvPostAdd" runat="server" ControlToValidate="txtPostAdd" 
                    ErrorMessage="邮寄地址不能为空;" ForeColor="White" ValidationGroup="ModiUserInfo" Display="Dynamic" ToolTip="邮寄地址不能为空;">*</asp:RequiredFieldValidator>
                </div>
                
                <div class="form_row">
                    <asp:Label ID="lblPostNum" runat="server" Text="邮政编码:"></asp:Label>
                    <asp:TextBox ID="txtPostNum" runat="server" MaxLength="6"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvPostNum" runat="server" ControlToValidate="txtPostNum" 
                    ErrorMessage="邮编不能为空;" ForeColor="White" ValidationGroup="ModiUserInfo" Display="Dynamic" ToolTip="邮编不能为空;">*</asp:RequiredFieldValidator>
                </div>
                
                <div class="form_row">
                    <asp:Label ID="lblPhoneNum" runat="server" Text="电话号码:"></asp:Label>
                    <asp:TextBox ID="txtPhoneNum" runat="server" MaxLength="20"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvPhoneNum" runat="server" ControlToValidate="txtPhoneNum" 
                    ErrorMessage="电话号码不能为空;" ForeColor="White" ValidationGroup="ModiUserInfo" Display="Dynamic" ToolTip="电话号码不能为空;">*</asp:RequiredFieldValidator>
                </div>
                
                <div class="form_row">
                    <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">电子邮件:</asp:Label>
                    <asp:TextBox ID="Email" runat="server" MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="Email" 
                    Display="Dynamic" ErrorMessage="电子邮箱不能为空;" ForeColor="White" ValidationGroup="ModiUserInfo" ToolTip="电子邮箱不能为空;">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revEmail" runat="server" Display="Dynamic" ErrorMessage="邮箱格式错误;" 
                    ForeColor="WhiteSmoke" ToolTip="邮箱格式错误;" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                    ValidationGroup="ModiUserInfo" ControlToValidate="Email">*</asp:RegularExpressionValidator>
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
                    <asp:Label ID="lblUserGender" runat="server" Text="性别:"></asp:Label>
                    <asp:DropDownList ID="ddlUserGender" runat="server">
                        <asp:ListItem Value="0">保密</asp:ListItem>
                        <asp:ListItem Value="1">男</asp:ListItem>
                        <asp:ListItem Value="2">女</asp:ListItem>
                        <asp:ListItem Value="3">春哥</asp:ListItem>
                    </asp:DropDownList>
                </div>
                
                <div class="form_row">
                    <asp:Label ID="lblUserBirth" runat="server" Text="出生日期:"></asp:Label>
                    <asp:TextBox ID="txtUserBirth" runat="server" MaxLength="10"></asp:TextBox>
                </div>
                
                <div class="form_row">
                    <asp:Label ID="lblIDCardNum" runat="server" Text="身份证号:"></asp:Label>
                    <asp:TextBox ID="txtIDCardNum" runat="server" MaxLength="18"></asp:TextBox>
                </div>
                
                </td>
                </tr>
                </table>
                
                <div class="form_row">
                  <div class="terms">
                    <asp:ValidationSummary ID="vsErrorMsg" runat="server" DisplayMode="SingleParagraph" 
                    ForeColor="WhiteSmoke" Height="38px" ValidationGroup="ModiUserInfo" Width="223px" />
                    <asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" ValidationGroup="ModiUserInfo" ToolTip="电子邮箱格式错误" ErrorMessage="电子邮箱格式错误" ControlToValidate="Email" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">电子邮箱格式错误</asp:RegularExpressionValidator>
                    <asp:RegularExpressionValidator ID="revIDCardNum" runat="server" ControlToValidate="txtIDCardNum"
                        ErrorMessage="身份证号码格式错误" ToolTip="身份证号码格式错误" ValidationExpression="\d{17}[\d|X]|\d{15}"
                        ValidationGroup="ModiUserInfo"></asp:RegularExpressionValidator><br />
                    <asp:RegularExpressionValidator ID="revPhone" runat="server" ControlToValidate="txtPhoneNum"
                        Display="Dynamic" ErrorMessage="电话号码格式错误" ToolTip="电话号码格式错误" ValidationExpression="((\d{11})|^((\d{7,8})|(\d{4}|\d{3})-(\d{7,8})|(\d{4}|\d{3})-(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1})|(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1}))$)" ValidationGroup="ModiUserInfo"></asp:RegularExpressionValidator>
                    <asp:RegularExpressionValidator ID="revBirthday" runat="server" ControlToValidate="txtUserBirth"
                        ErrorMessage="生日请按xxxx-xx-xx格式填写并保证日期无误" ToolTip="生日请按xxxx-xx-xx格式填写并保证日期无误"
                        ValidationExpression="((^((1[8-9]\d{2})|([2-9]\d{3}))([-\/\._])(10|12|0?[13578])([-\/\._])(3[01]|[12][0-9]|0?[1-9])$)|(^((1[8-9]\d{2})|([2-9]\d{3}))([-\/\._])(11|0?[469])([-\/\._])(30|[12][0-9]|0?[1-9])$)|(^((1[8-9]\d{2})|([2-9]\d{3}))([-\/\._])(0?2)([-\/\._])(2[0-8]|1[0-9]|0?[1-9])$)|(^([2468][048]00)([-\/\._])(0?2)([-\/\._])(29)$)|(^([3579][26]00)([-\/\._])(0?2)([-\/\._])(29)$)|(^([1][89][0][48])([-\/\._])(0?2)([-\/\._])(29)$)|(^([2-9][0-9][0][48])([-\/\._])(0?2)([-\/\._])(29)$)|(^([1][89][2468][048])([-\/\._])(0?2)([-\/\._])(29)$)|(^([2-9][0-9][2468][048])([-\/\._])(0?2)([-\/\._])(29)$)|(^([1][89][13579][26])([-\/\._])(0?2)([-\/\._])(29)$)|(^([2-9][0-9][13579][26])([-\/\._])(0?2)([-\/\._])(29)$))"
                        ValidationGroup="ModiUserInfo"></asp:RegularExpressionValidator><br />
                    <asp:RegularExpressionValidator ID="revPostCode" runat="server" ControlToValidate="txtPostNum"
                        Display="Dynamic" ErrorMessage="邮政编码错误" ValidationExpression="\d{6}" ValidationGroup="ModiUserInfo"></asp:RegularExpressionValidator>
                  </div>
                </div>
                
                <div class="form_row">
                    <asp:Button ID="back" runat="server" Text="返回" CssClass="register" OnClick="back_Click"/>
                    <asp:Button ID="submit" runat="server" Text="提交保存" onclick="submit_Click" ValidationGroup="ModiUserInfo" CssClass="register"/></div>
                
            </div>
        </div>

</asp:Content>

