<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ClientService.aspx.cs" Inherits="ClientService" %>
<%@ Import Namespace="System.Data" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        F &amp; Q ：<br />
        <br />
        <asp:DataList ID="dataList" runat="server" CellPadding="2" ForeColor="#333333" Width="739px">
               <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
               <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
               <AlternatingItemStyle BackColor="White" />
               <ItemStyle BackColor="#EFF3FB" />
               <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
               
                  <ItemTemplate>
                    <font face="宋体">
                    <blockquote>
                        标题：<%# DataBinder.Eval(Container.DataItem,"Topic") %>
                        内容:<%# DataBinder.Eval(Container.DataItem,"Messages") %>
                        管理员回复:<%# DataBinder.Eval(Container.DataItem,"Reply") %>
                    </blockquote></font>
                   </ItemTemplate>

               
           </asp:DataList>
        <table style="width: 419px; height: 104px">
            <tr>
                <td style="width: 104px; height: 32px">
                    标题：<br />
        <asp:TextBox ID="Topic" runat="server" ></asp:TextBox></td>
                <td style="width: 245px; height: 32px">
                </td>
            </tr>
            <tr>
                <td colspan="2" style="height: 58px">
                    内容：<br />
                    <asp:TextBox ID="Message" runat="server" Width="356px" Height="46px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 104px; height: 29px">
        <asp:Button ID="Submit" runat="server" type="reset" Text="提交" OnClick="Submit_Click"  /></td>
                <td style="width: 245px; height: 29px">
                    <input id="Reset" type="reset" value="清空" /></td>
            </tr>
        </table>
        <br />
    </div>
    </form>
</body>
</html>
