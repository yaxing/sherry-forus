<%@ Page Language="C#" MasterPageFile="~/IndexMaster.master" AutoEventWireup="true" CodeFile="ShowGoods.aspx.cs" Inherits="Goods_ShowGoods" Title="产品信息" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentHolder" Runat="Server">
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
                    <asp:ListItem Value="1">基础</asp:ListItem>
                    <asp:ListItem Value="2">美白</asp:ListItem>
                    <asp:ListItem Value="3">彩妆</asp:ListItem>
                    <asp:ListItem Value="4">洗浴</asp:ListItem>
                    <asp:ListItem Value="5">香品</asp:ListItem>
                </asp:ListBox></td>
        </tr>
        <tr>
            <td>
                产品图片</td>
            <td>
                </td>
        </tr>
        <tr>
            <td>
                产品添加时刻</td>
            <td>
                <asp:TextBox ID="GoodsAddTime" runat="server" Text="2"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                产品单价</td>
            <td>
               <asp:TextBox ID="GoodsPrice" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                产品库存</td>
            <td>
                <asp:TextBox ID="GoodsStorage" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                产品上下架状态</td>
            <td>
            <asp:RadioButtonList ID="GoodsAvailable" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Text="上架状态" Value="True" />
                <asp:ListItem Text="下架状态" Value="False" />
            </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>
                产品描述</td>
            <td>
                <asp:TextBox ID="GoodsDescribe" runat="server"></asp:TextBox></td>
        </tr>
    </table>
</asp:Content>

