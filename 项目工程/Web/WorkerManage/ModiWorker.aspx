<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ModiWorker.aspx.cs" Inherits="ModiWorker" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>�޸Ĺ�����Ա��Ϣ</title>
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
           <th width="100%" height="25px" class="tableHeaderText">�޸Ĺ�����Ա��Ϣ</th>
           </tr>
         </table>
         
         <div align="center">
      <table width="790px">
        <tr>
          <td align="left">
              <asp:Label ID="lblName" runat="server" Text="��&nbsp;��&nbsp;��:"></asp:Label>
          </td>
          <td align="left">
              <asp:Label ID="lblWorkerName" runat="server" Text="" Width="200px"></asp:Label>
          </td>
          <td align="left">
              <asp:Label ID="lblReal" runat="server" Text="��ʵ����:"></asp:Label>
          </td>
          <td align="left">
              <asp:Label ID="lblRealName" runat="server" Width="200px"></asp:Label></td>
        </tr>
        <tr>
          <td align="left">
              <asp:Label ID="lblNum" runat="server" Text="��������:"></asp:Label></td>
          <td align="left">
              <asp:Label ID="lblWorkerNum" runat="server" Width="200px"></asp:Label></td>
          <td align="left">
              <asp:Label ID="lblShop" runat="server" Text="�ꡡ����:"></asp:Label></td>
          <td align="left">
              <asp:DropDownList ID="DDLShop" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLShop_SelectedIndexChanged" Width="200px">
              </asp:DropDownList></td>
        </tr>
        <tr>
          <td align="left">
              <asp:Label ID="lblLv" runat="server" Text="��������:"></asp:Label></td>
          <td align="left">
              <asp:DropDownList ID="DDLWorkerLv" runat="server">
                  <asp:ListItem Value="0">������Ա</asp:ListItem>
                  <asp:ListItem Value="1">������</asp:ListItem>
              </asp:DropDownList></td>
          <td align="left">
              <asp:Label ID="lblManager" runat="server" Text="��&nbsp;��&nbsp;��:"></asp:Label></td>
          <td align="left">
              <asp:DropDownList ID="DDLManager" runat="server" Width="200px">
              </asp:DropDownList></td>
        </tr>
        <tr>
          <td align="left">
              <asp:Label ID="lblEmail" runat="server" Text="��������:"></asp:Label>
          </td>
          <td align="left">
              <asp:TextBox ID="txtEmail" runat="server" Width="200px"></asp:TextBox>
              <asp:RequiredFieldValidator ID="rfvEmail" runat="server" Display="Dynamic" ErrorMessage="����д��������" 
              ValidationGroup="modiWorker" ControlToValidate="txtEmail">*</asp:RequiredFieldValidator>
          </td>
          <td align="left">
              <asp:Label ID="lblPhone" runat="server" Text="�绰����:"></asp:Label></td>
          <td align="left">
              <asp:TextBox ID="txtPhone" runat="server" Width="200px"></asp:TextBox>
              <asp:RequiredFieldValidator ID="rfvPhoneNum" runat="server" Display="Dynamic" ErrorMessage="����д�绰����" 
              ValidationGroup="modiWorker" ControlToValidate="txtPhone">*</asp:RequiredFieldValidator>
          </td>
        </tr>
        <tr>
          <td align="left">
              <asp:Label ID="lblState" runat="server" Text="����״̬:"></asp:Label></td>
          <td align="left">
              <asp:Label ID="lblWorkerState" runat="server" Width="200px"></asp:Label></td>
          <td align="left">
              <asp:Label ID="lblAccountS" runat="server" Text="�ʺ�״̬:"></asp:Label></td>
          <td align="left">
              <asp:Label ID="lblAccountState" runat="server" Width="200px"></asp:Label></td>
        </tr>
        <asp:Panel ID="PanelPwd" runat="server">
        <tr>
          <td colspan = "4" id="submenu30" style="display:none;" align="left">
          <table width = "790px">
        <tr>
          <td align="left" style="width:100px">
              ��&nbsp;��&nbsp;��:
          </td>
          <td align="left" style="width:300px">
              <asp:TextBox ID="txtNewPwd" runat="server" TextMode="Password" Width="200px"></asp:TextBox>
              <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server" ControlToValidate="txtNewPwd" 
              ErrorMessage="����д������" ToolTip="����д������" ValidationGroup="ModiPwd">*</asp:RequiredFieldValidator>
          </td>
          <td align="left" style="width:80px">
              ȷ������:
          </td>
          <td align="left">
              <asp:TextBox ID="txtNewPwdC" runat="server" TextMode="Password" Width="200px"></asp:TextBox>
              <asp:RequiredFieldValidator ID="NewPasswordCRequired" runat="server" ControlToValidate="txtNewPwdC" 
              ErrorMessage="��ȷ��������" ToolTip="��ȷ��������" ValidationGroup="ModiPwd">*</asp:RequiredFieldValidator>
          </td>
        </tr>
        <tr>
          <td align="left" style="width:100px">
              ԭ&nbsp;��&nbsp;��:
          </td>
          <td align="left">
              <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="200px"></asp:TextBox>
              <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="txtPassword" 
              ErrorMessage="����дԭʼ����" ToolTip="����дԭʼ����" ValidationGroup="ModiPwd">*</asp:RequiredFieldValidator>
          </td>
          <td align="left">
              <asp:Button ID="btnPassword" runat="server" Text="ȷ���޸�" CssClass="submit" ValidationGroup="ModiPwd" OnClick="btnPassword_Click"/>
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
              ControlToValidate="txtNewPwdC" Display="Dynamic" ForeColor="red" ValidationGroup="ModiPwd">�����롱�͡�ȷ�����롱����ƥ�䡣</asp:CompareValidator>
              <br />
              <asp:RegularExpressionValidator ID="revPwd" runat="server" ErrorMessage="����Ӧ��6-16λ֮��" ToolTip="����Ӧ��6-16λ֮��" ValidationGroup="ModiPwd" Display="Dynamic" ControlToValidate="txtNewPwd" ValidationExpression="\d{6,16}"></asp:RegularExpressionValidator>
              <br />
              <asp:RegularExpressionValidator ID="revEmail" runat="server" Display="Dynamic" ErrorMessage="*���������ʽ����" 
              ValidationGroup="modiWorker" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*���������ʽ����</asp:RegularExpressionValidator>
              <asp:RegularExpressionValidator id="revPhone" runat="server" ValidationGroup="modiWorker" ToolTip="*�绰�����ʽ����" ErrorMessage="*�绰�����ʽ����" ControlToValidate="txtPhone" Display="Dynamic" ValidationExpression="((\d{11})|^((\d{7,8})|(\d{4}|\d{3})-(\d{7,8})|(\d{4}|\d{3})-(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1})|(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1}))$)"></asp:RegularExpressionValidator>
          </td>
        </tr>
        <tr>
          <td>
              <asp:Panel ID="PanelButton" runat="server">
                  <input type="button" class="submit" value="�޸�����>" onclick="showsubmenu(30)"/>
              </asp:Panel>
          </td>
          <td colspan="3">
              <asp:Button ID="btnCommit" runat="server" Text="ȷ���޸�" OnClick="btnCommit_Click" CssClass="submit" ValidationGroup="modiWorker"/>
              <asp:Button ID="btnCancel" runat="server" Text="ȡ���޸�" OnClick="btnCancel_Click" CssClass="submit"/>
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
