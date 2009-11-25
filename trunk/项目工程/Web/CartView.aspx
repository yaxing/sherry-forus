<%@ Page Language="C#" MasterPageFile="~/IndexMaster.master" AutoEventWireup="true" CodeFile="CartView.aspx.cs" Inherits="CartView" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentHolder" Runat="Server">
<div style="position: relative; left: 100px">
            <asp:GridView ID="gvItems" runat="server" CellPadding="2" ForeColor="Black" GridLines="None"
                BorderWidth="1px" Width="90%" AutoGenerateColumns="False" OnRowCommand="gvItems_RowCommand" BackColor="LightGoldenrodYellow" BorderColor="Tan">
                <FooterStyle BackColor="Tan" />
            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
            <HeaderStyle BackColor="Tan" Font-Bold="True" />
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
            <EmptyDataTemplate>
                    <table width="100%">
                        <tr>
                            <td align="center" style="height: 80px">
                                <img src="images/cart.gif" style="margin: 10px auto; padding: 20px 20px" />
                                <p style="padding: 50px auto">
                                    购物车列表为空。<a href="Index.aspx">浏览商品</a>
                                </p>
                            </td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <Columns>
                <asp:BoundField DataField="ID" ReadOnly="True" Visible="False"/>
                <asp:BoundField DataField="Name" HeaderText="产品名" ReadOnly="True" />
                <asp:BoundField DataField="Price" HeaderText="价格" DataFormatString="{0:c}" />
                <asp:BoundField DataField="Number" HeaderText="数量" />
                <asp:TemplateField HeaderText="加减">
                    <ItemTemplate>
                        <asp:LinkButton ID="addItemBt" runat="server" CommandName="AddItemOne" CommandArgument='<%# Eval("ID") %>'>+</asp:LinkButton>
                        /<asp:LinkButton ID="delItemBt" runat="server" CommandName="DelItemOne" CommandArgument='<%# Eval("ID") %>'>-</asp:LinkButton>
                        <br />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="删除">
                    <ItemTemplate>
                        <asp:LinkButton ID="DelBt" runat="server" CommandName="DelFromCart" OnClientClick="return confirm('真的要从购物车中删除该商品吗？')"
                            CommandArgument='<%# Eval("ID") %>'>删除</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        </div>
</asp:Content>

