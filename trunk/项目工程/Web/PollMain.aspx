<%@ Page Language="C#" MasterPageFile="~/IndexMaster.master" AutoEventWireup="true" CodeFile="PollMain.aspx.cs" Inherits="PollMain" %>
<%@ Import Namespace="System.Data" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentHolder" runat="Server">
    <div align="center">
        <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound" OnItemCommand="Repeater1_ItemCommand">
        
        <ItemTemplate>
            <asp:Label ID="lbId" runat="server" Text='<%# ((DataRowView)Container.DataItem)["mainPollID"] %>' Visible="false"></asp:Label>
        
            <asp:Label ID="selMode" runat="server" Text='<%# ((DataRowView)Container.DataItem)["singleMode"] %>' Visible="false"></asp:Label>
        <table>
        <tr>
            <td colspan="2"><asp:Label ID="lbTitle" runat="server" Text='<%# ((DataRowView)Container.DataItem)["topic"] %>'></asp:Label></td>
        </tr>
        <tr>
            <td colspan="2"><asp:PlaceHolder ID="phOptions" runat="server"></asp:PlaceHolder></td>
        </tr>
        <tr>
            <td colspan="2"><asp:LinkButton ID="lbPoll" CommandName="poll" CommandArgument='<%# ((DataRowView)Container.DataItem)["mainPollID"] %>' runat="server" Cssclass="register" Text="投票" CausesValidation="false"></asp:LinkButton></td>
        </tr>
        <tr>
            <td align="left">
                <asp:LinkButton ID="prev" CommandName="prev" runat="server" Cssclass="register" Text="上一个"></asp:LinkButton></td>
            <td align="right">
                <asp:LinkButton ID="next" CommandName="next" runat="server" Cssclass="register" Text="下一个"></asp:LinkButton></td>
        </tr>
        </table>
        
        </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>