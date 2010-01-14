<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ModiAdminSelf.aspx.cs" Inherits="Management_ModiAdminSelf" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>个人信息修改</title>
    <link rel="stylesheet" type="text/css" href="../bgStyle.css" />
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
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table cellspacing="1" cellpadding="3" width="790px" align="center" border="0">
           <tr>
             <td valign="top" width="100%">
               <p><br /></p>
             </td>
           </tr>
         </table>
         <table class="tableBorder" cellspacing="1" cellpadding="2" width="790px" align="center" border="0">
           <tr>
           <th width="100%" height="25px" class="tableHeaderText">个人信息修改</th>
           </tr>
         </table>
         
         
         <div align="center">
      <table width="540px">
        <tr>
          <td colspan="4" align="center">
            尊敬的<asp:Label ID="lblType" runat="server" Text=""></asp:Label><asp:Label ID="lblAdminName" runat="server" Text=""></asp:Label>，您好！
          </td>
        </tr>
        <tr>
          <td align="left" style="width:70px">
             真实姓名:
          </td>
          <td align="left" style="width:200px">
              <asp:TextBox ID="txtAdminRealName" runat="server"></asp:TextBox>
              <asp:RequiredFieldValidator ID="rfvRealName" runat="server" Display="Dynamic" ErrorMessage="请填写您的真实姓名"
                  ValidationGroup="modiAdmin" ControlToValidate="txtAdminRealName">*</asp:RequiredFieldValidator>
          </td>
          <td align="left" style="width:70px">
             电子邮箱:
          </td>
          <td align="left" style="width:200px">
              <asp:TextBox ID="txtAdminEmail" runat="server"></asp:TextBox>
              <asp:RequiredFieldValidator ID="rfvEmail" runat="server" Display="Dynamic" ErrorMessage="请填写电子邮箱"
                  ValidationGroup="modiAdmin" ControlToValidate="txtAdminEmail">*</asp:RequiredFieldValidator>
              <asp:RegularExpressionValidator ID="revEmail" runat="server" Display="Dynamic" ErrorMessage="电子邮箱格式错误"
                  ValidationGroup="modiAdmin" ControlToValidate="txtAdminEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">x</asp:RegularExpressionValidator></td>
        </tr>
        <tr>
          <td align="left" style="width:70px">
             电话号码:
          </td>
          <td align="left" style="width:200px">
              <asp:TextBox ID="txtPhoneNum" runat="server"></asp:TextBox>
              <asp:RequiredFieldValidator ID="rfvPhoneNum" runat="server" Display="Dynamic" ErrorMessage="请填写电话号码"
                  ValidationGroup="modiAdmin" ControlToValidate="txtPhoneNum">*</asp:RequiredFieldValidator>
          </td>
          <td>
              <input type="button" class="submit" value="修改密码>" onclick="showsubmenu(30)"/>
          </td>
          <td>
          </td>
        </tr>
        <tr>
          <td colspan = "4" id="submenu30" style="display:none;" align="left">
          <table width = "540px">
        <tr>
          <td align="left" style="width:70px">
              新&nbsp;&nbsp;密&nbsp;&nbsp;码:
          </td>
          <td align="left" style="width:200px">
              <asp:TextBox ID="txtNewPwd" runat="server" TextMode="Password"></asp:TextBox>
              <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server" ControlToValidate="txtNewPwd" 
              ErrorMessage="请填写新密码" ToolTip="请填写新密码" ValidationGroup="ModiPwd">*</asp:RequiredFieldValidator>
          </td>
          <td align="left" style="width:70px">
              确认密码:
          </td>
          <td align="left" style="width:200px">
              <asp:TextBox ID="txtNewPwdC" runat="server" TextMode="Password"></asp:TextBox>
              <asp:RequiredFieldValidator ID="NewPasswordCRequired" runat="server" ControlToValidate="txtNewPwdC" 
              ErrorMessage="请确认新密码" ToolTip="请确认新密码" ValidationGroup="ModiPwd">*</asp:RequiredFieldValidator>
          </td>
        </tr>
        <tr>
          <td align="left" style="width:70px">
              原&nbsp;&nbsp;密&nbsp;&nbsp;码:
          </td>
          <td align="left" style="width:200px">
              <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
              <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="txtPassword" 
              ErrorMessage="请填写原始密码" ToolTip="请填写原始密码" ValidationGroup="ModiPwd">*</asp:RequiredFieldValidator>
          </td>
          <td>
          </td>
          <td align="left">
              <asp:Button ID="btnPassword" runat="server" Text="确认修改" CssClass="submit" OnClick="btnPassword_Click" ValidationGroup="ModiPwd"/>
          </td>
        </tr>
          </table>
          </td>
        </tr>
        
        <tr>
          <td colspan="4" align="center">
              <asp:RegularExpressionValidator ID="revPwd" runat="server" ErrorMessage="密码应在6-16位之间" ToolTip="密码应在6-16位之间" ValidationGroup="ModiPwd" Display="Dynamic" ControlToValidate="txtNewPwd" ValidationExpression="\d{6,16}"></asp:RegularExpressionValidator><br />
              <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="txtNewPwd" 
              ControlToValidate="txtNewPwdC" Display="Dynamic" ForeColor="red" ValidationGroup="ModiPwd">“密码”和“确认密码”必须匹配。</asp:CompareValidator>
              <asp:RegularExpressionValidator id="revRealName" runat="server" ValidationGroup="modiAdmin" ToolTip="真实姓名只能使用汉字或英文" ErrorMessage="真实姓名只能使用汉字或英文" ControlToValidate="txtAdminRealName" Display="Dynamic" ValidationExpression="^[\u4e00-\u9fa5A-Za-z]+$"></asp:RegularExpressionValidator>
              <br />
              <asp:RegularExpressionValidator id="revPhone" runat="server" ValidationGroup="modiAdmin" ToolTip="电话号码格式错误" ErrorMessage="电话号码格式错误" ControlToValidate="txtPhoneNum" Display="Dynamic" ValidationExpression="((\d{11})|^((\d{7,8})|(\d{4}|\d{3})-(\d{7,8})|(\d{4}|\d{3})-(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1})|(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1}))$)"></asp:RegularExpressionValidator>
              <br />
              <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="SingleParagraph"
                  ValidationGroup="modiAdmin" />
          </td>
        </tr>
        <tr>
          <td colspan="4" align="right">
              <asp:Button ID="btnSub" runat="server" Text="确认修改" ValidationGroup="modiAdmin" OnClick="btnSub_Click" CssClass="submit"/>
              <asp:Button ID="btnReset" runat="server" Text="重置" OnClick="btnReset_Click" CssClass="submit"/></td>
        </tr>
      </table>
      </div>
      
      <table class="tableBorder" cellspacing="1" cellpadding="2" width="790px" align="center" border="0">
           <tr>
             <th width="100%" class="tableHeaderText" style="height: 25px">&nbsp;</th>
           </tr>
         </table>
    </div>
    </form>
</body>
</html>
