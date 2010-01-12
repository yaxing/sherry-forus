<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CSManage.aspx.cs" Inherits="CSManage" %>
<%@ Import Namespace="System.Data" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

 <html xmlns="http://www.w3.org/1999/xhtml">
       <head>
              <title>CSManage</title>
              <meta http-equiv="Content-Type" content="text/html; charset=gb2312">
       </head>
       <body >
       <form id="form1" runat="server">
           <asp:DataList ID="dataList" runat="server" CellPadding="4" ForeColor="#333333" OnEditCommand="EditCommand" OnDeleteCommand="DeleteCommand">
               <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
               <SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
               <AlternatingItemStyle BackColor="White" />
               <ItemStyle BackColor="#FFFBD6" ForeColor="#333333" />
               <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
               
                  <ItemTemplate>
                    <font face="宋体">
                    <blockquote>
                        <asp:Label ID="MessageID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"MessageID") %>' Visible="false"></asp:Label>
                        标题：<%# DataBinder.Eval(Container.DataItem,"Topic") %>
                        内容：<%# DataBinder.Eval(Container.DataItem,"Messages") %>
                        </blockquote></font>&nbsp;&nbsp;
                        <asp:TextBox ID="Reply" runat="server" Width="189px"></asp:TextBox>
                        <asp:Button ID="Edit" runat="server" Text="编辑" CommandName="Edit" />
                        <asp:Button ID="Delete" runat="server" Text="删除" CommandName="Delete" />
                        
                   </ItemTemplate>

               
           </asp:DataList>

              
       </form>     
       </body>
       
</html>

