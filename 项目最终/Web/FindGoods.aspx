<%@ Page Language="C#" MasterPageFile="~/IndexMaster.master" AutoEventWireup="true"
    CodeFile="FindGoods.aspx.cs" Inherits="Goods_FindGoods" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentHolder" runat="Server">
    <table>
        <tr>
            <td>
                产品名称</td>
            <td>
                <asp:TextBox ID="GoodsName" runat="server" CausesValidation="true"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                产品编号</td>
            <td>
                <asp:TextBox ID="GoodsNum" runat="server" CausesValidation="true"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                产品类别</td>
            <td>
                <asp:ListBox ID="GoodsCategory" runat="server" Rows="1">
                    <asp:ListItem Value="0">所有</asp:ListItem>
                    <asp:ListItem Value="1">基础</asp:ListItem>
                    <asp:ListItem Value="2">美白</asp:ListItem>
                    <asp:ListItem Value="3">彩妆</asp:ListItem>
                    <asp:ListItem Value="4">洗浴</asp:ListItem>
                    <asp:ListItem Value="5">香品</asp:ListItem>
                </asp:ListBox></td>
        </tr>
        <tr>
            <td>
                从<asp:TextBox ID="TimeFrom" runat="server" Width="70"></asp:TextBox></td>
            <td>
                到<asp:TextBox ID="TimeTo" runat="server" Width="70"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Button ID="FindCommit" OnClick="FindGoodsCommit" runat="server" Text="查找产品" /></td>
        </tr>
    </table>
    <asp:GridView ID="FindResult" runat="server" AutoGenerateColumns="False" OnRowDeleting="FindResult_RowDeleting"
        DataKeyNames="goodsID">
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="goodsID" DataTextField="goodsName" HeaderText="产品名称"
                DataNavigateUrlFormatString="Details.aspx?goodsID={0}" />
            <asp:BoundField DataField="goodsNum" HeaderText="产品编号" />
            <asp:BoundField DataField="goodsAddTime" HeaderText="产品添加日期" />
            <asp:BoundField DataField="goodsCategory" HeaderText="产品类别" />
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:ImageButton ID="DeleteGoods" runat="server" CausesValidation="False" CommandName="Delete"
                        ImageUrl="~/images/delete.png" ToolTip="删除" OnClientClick="return confirm('确认要删除吗？');" />
                    <asp:ImageButton ID="ChangeGoods" runat="server" ImageUrl="~/images/delete.png" ToolTip="修改产品信息" PostBackUrl="ChangeGoods.aspx" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
