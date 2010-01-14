<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PollMain.aspx.cs" Inherits="PollMain" %>

<%@ Import Namespace="System.Data" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div align="center">
            <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound"
                OnItemCommand="Repeater1_ItemCommand">
                <ItemTemplate>
                    <asp:Label ID="lbId" runat="server" Text='<%# ((DataRowView)Container.DataItem)["mainPollID"] %>'
                        Visible="false"></asp:Label>
                    <asp:Label ID="selMode" runat="server" Text='<%# ((DataRowView)Container.DataItem)["singleMode"] %>'
                        Visible="false"></asp:Label>
                    <table>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="lbTitle" runat="server" Text='<%# ((DataRowView)Container.DataItem)["topic"] %>'></asp:Label></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:PlaceHolder ID="phOptions" runat="server"></asp:PlaceHolder>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:LinkButton ID="lbPoll" CommandName="poll" CommandArgument='<%# ((DataRowView)Container.DataItem)["mainPollID"] %>'
                                    runat="server" CssClass="register" Text="投票" CausesValidation="false"></asp:LinkButton></td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:LinkButton ID="prev" CommandName="prev" runat="server" CssClass="register" Text="上一个"></asp:LinkButton></td>
                            <td align="right">
                                <asp:LinkButton ID="next" CommandName="next" runat="server" CssClass="register" Text="下一个"></asp:LinkButton></td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
