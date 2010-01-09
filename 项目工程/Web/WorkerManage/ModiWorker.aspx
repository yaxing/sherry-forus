<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ModiWorker.aspx.cs" Inherits="ModiWorker" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>修改工作人员信息</title>
    <link rel="stylesheet" type="text/css" href="../Management/bgStyle.css" />
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
           <th width="100%" height="25px" class="tableHeaderText">修改工作人员信息</th>
           </tr>
         </table>
         
         <div align="center">
      <table width="790px">
        <tr>
          <td align="left">
              <asp:Label ID="lblName" runat="server" Text="用&nbsp;户&nbsp;名:"></asp:Label>
          </td>
          <td align="left">
              <asp:Label ID="lblWorkerName" runat="server" Text="" Width="200px"></asp:Label>
          </td>
          <td align="left">
              <asp:Label ID="lblReal" runat="server" Text="真实姓名:"></asp:Label>
          </td>
          <td align="left">
              <asp:Label ID="lblRealName" runat="server" Width="200px"></asp:Label></td>
        </tr>
        <tr>
          <td align="left">
              <asp:Label ID="lblNum" runat="server" Text="工　　号:"></asp:Label></td>
          <td align="left">
              <asp:Label ID="lblWorkerNum" runat="server" Width="200px"></asp:Label></td>
          <td align="left">
              <asp:Label ID="lblShop" runat="server" Text="店　　面:"></asp:Label></td>
          <td align="left">
              <asp:DropDownList ID="DDLShop" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLShop_SelectedIndexChanged" Width="200px">
              </asp:DropDownList></td>
        </tr>
        <tr>
          <td align="left">
              <asp:Label ID="lblLv" runat="server" Text="级　　别:"></asp:Label></td>
          <td align="left">
              <asp:DropDownList ID="DDLWorkerLv" runat="server">
                  <asp:ListItem Value="0">工作人员</asp:ListItem>
                  <asp:ListItem Value="1">负责人</asp:ListItem>
              </asp:DropDownList></td>
          <td align="left">
              <asp:Label ID="lblManager" runat="server" Text="负&nbsp;责&nbsp;人:"></asp:Label></td>
          <td align="left">
              <asp:DropDownList ID="DDLManager" runat="server" Width="200px">
              </asp:DropDownList></td>
        </tr>
        <tr>
          <td align="left">
              <asp:Label ID="lblEmail" runat="server" Text="电子邮箱:"></asp:Label>
          </td>
          <td align="left">
              <asp:TextBox ID="txtEmail" runat="server" Width="200px"></asp:TextBox>
              <asp:RequiredFieldValidator ID="rfvEmail" runat="server" Display="Dynamic" ErrorMessage="请填写电子邮箱" 
              ValidationGroup="modiWorker" ControlToValidate="txtEmail">*</asp:RequiredFieldValidator>
          </td>
          <td align="left">
              <asp:Label ID="lblPhone" runat="server" Text="电话号码:"></asp:Label></td>
          <td align="left">
              <asp:TextBox ID="txtPhone" runat="server" Width="200px"></asp:TextBox>
              <asp:RequiredFieldValidator ID="rfvPhoneNum" runat="server" Display="Dynamic" ErrorMessage="请填写电话号码" 
              ValidationGroup="modiWorker" ControlToValidate="txtPhone">*</asp:RequiredFieldValidator>
          </td>
        </tr>
        <tr>
          <td align="left">
              <asp:Label ID="lblState" runat="server" Text="工作状态:"></asp:Label></td>
          <td align="left">
              <asp:Label ID="lblWorkerState" runat="server" Width="200px"></asp:Label></td>
          <td align="left">
              <asp:Label ID="lblAccountS" runat="server" Text="帐号状态:"></asp:Label></td>
          <td align="left">
              <asp:Label ID="lblAccountState" runat="server" Width="200px"></asp:Label></td>
        </tr>
        <asp:Panel ID="PanelPwd" runat="server">
        <tr>
          <td colspan = "4" id="submenu30" style="display:none;" align="left">
          <table width = "790px">
        <tr>
          <td align="left" style="width:100px">
              新&nbsp;密&nbsp;码:
          </td>
          <td align="left" style="width:300px">
              <asp:TextBox ID="txtNewPwd" runat="server" TextMode="Password" Width="200px"></asp:TextBox>
              <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server" ControlToValidate="txtNewPwd" 
              ErrorMessage="请填写新密码" ToolTip="请填写新密码" ValidationGroup="ModiPwd">*</asp:RequiredFieldValidator>
          </td>
          <td align="left" style="width:80px">
              确认密码:
          </td>
          <td align="left">
              <asp:TextBox ID="txtNewPwdC" runat="server" TextMode="Password" Width="200px"></asp:TextBox>
              <asp:RequiredFieldValidator ID="NewPasswordCRequired" runat="server" ControlToValidate="txtNewPwdC" 
              ErrorMessage="请确认新密码" ToolTip="请确认新密码" ValidationGroup="ModiPwd">*</asp:RequiredFieldValidator>
          </td>
        </tr>
        <tr>
          <td align="left" style="width:100px">
              原&nbsp;密&nbsp;码:
          </td>
          <td align="left">
              <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="200px"></asp:TextBox>
              <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="txtPassword" 
              ErrorMessage="请填写原始密码" ToolTip="请填写原始密码" ValidationGroup="ModiPwd">*</asp:RequiredFieldValidator>
          </td>
          <td align="left">
              <asp:Button ID="btnPassword" runat="server" Text="确认修改" CssClass="submit" ValidationGroup="ModiPwd" OnClick="btnPassword_Click"/>
          </td>
          <td>
          </td>
        </tr>
          </table>
          </td>
        </tr>
        </asp:Panel>
        <tr>
          <td colspan="4">
              <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="txtNewPwd" 
              ControlToValidate="txtNewPwdC" Display="Dynamic" ForeColor="red" ValidationGroup="ModiPwd">“密码”和“确认密码”必须匹配。</asp:CompareValidator>
              <br />
              <asp:RegularExpressionValidator ID="revPwd" runat="server" ErrorMessage="密码应在6-16位之间" ToolTip="密码应在6-16位之间" ValidationGroup="ModiPwd" Display="Dynamic" ControlToValidate="txtNewPwd" ValidationExpression="\d{6,16}"></asp:RegularExpressionValidator>
              <br />
              <asp:RegularExpressionValidator ID="revEmail" runat="server" Display="Dynamic" ErrorMessage="*电子邮箱格式错误" 
              ValidationGroup="modiWorker" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*电子邮箱格式错误</asp:RegularExpressionValidator>
              <asp:RegularExpressionValidator id="revPhone" runat="server" ValidationGroup="modiWorker" ToolTip="*电话号码格式错误" ErrorMessage="*电话号码格式错误" ControlToValidate="txtPhone" Display="Dynamic" ValidationExpression="((\d{11})|^((\d{7,8})|(\d{4}|\d{3})-(\d{7,8})|(\d{4}|\d{3})-(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1})|(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1}))$)"></asp:RegularExpressionValidator>
          </td>
        </tr>
        <tr>
          <td>
              <asp:Panel ID="PanelButton" runat="server">
                  <input type="button" class="submit" value="修改密码>" onclick="showsubmenu(30)"/>
              </asp:Panel>
          </td>
          <td colspan="3">
              <asp:Button ID="btnCommit" runat="server" Text="确认修改" OnClick="btnCommit_Click" CssClass="submit" ValidationGroup="modiWorker"/>
              <asp:Button ID="btnCancel" runat="server" Text="取消修改" OnClick="btnCancel_Click" CssClass="submit"/>
          </td>
        </tr>
      </table>
        </div>
        
        <table class="tableBorder" cellspacing="1" cellpadding="2" width="790px" align="center" border="0">
           <tr>
             <th width="100%" class="tableHeaderText" style="height: 25px" />
           </tr>
         </table>
    </div>
    </form>
</body>
</html>
