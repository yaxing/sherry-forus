﻿<%@ Page Language="C#" MasterPageFile="~/IndexMaster.master" AutoEventWireup="true"
    CodeFile="CartView.aspx.cs" Inherits="CartView" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentHolder" runat="Server">
    <div style="position: relative; left: 130px; font-family: 微软雅黑; font-size: 15px;
        font-weight: bold; border-bottom-style: solid; border-bottom-color: white; border-bottom-width: 3px;
        width: 350px">
        <table>
            <tr>
                <td style="color:white">
                    您的购物车
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbCookieWarning" runat="server" Font-Size="10px" Font-Names="微软雅黑"
                        Text="！为了您能够方便的使用购物车功能，请将您的浏览器设置为允许cookie！"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <div style="position: relative; left: 130px; top: 30px; height: 320px">
        <asp:GridView ID="gvItems" runat="server" Width="555px" AutoGenerateColumns="False"
            OnRowCommand="gvItems_RowCommand" GridLines="None" AllowPaging="true" OnPageIndexChanging="gvItems_PageIndexChanging"
            OnRowCreated="gvItems_RowCreated">
            <EmptyDataTemplate>
                <table width="100%" style="font-family: 微软雅黑; font-size: 12px">
                    <tr>
                        <td align="center" style="height: 80px">
                            您还没有选购商品。<a href="index.aspx">浏览商品>></a>
                        </td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <Columns>
                <asp:TemplateField Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lbId" runat="server" Text='<%#Eval("ID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemStyle Width="80px" Font-Names="微软雅黑" />
                    <HeaderStyle ForeColor="white" Font-Size="15px" />
                    <HeaderTemplate>
                        <font style="font-family: 微软雅黑; font-weight: bold">商品</font>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <table>
                            <tr style="height: 10px">
                            </tr>
                            <tr>
                                <td>
                                    <asp:Image ID="itemImg" runat="server" Width="70px" ImageUrl='<%#Eval("ImgPath") %>' />
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemStyle Font-Names="微软雅黑" />
                    <ItemTemplate>
                        <table>
                            <tr>
                                <td align="center">
                                    <asp:LinkButton ForeColor="white" ID="itemInfo" Font-Underline="true" runat="server"
                                        CommandName="ShowInfo" CommandArgument='<%# Eval("ID") %>'><%#Eval("Name") %></asp:LinkButton>
                                </td>
                            </tr>
                            <tr style="height: 50px">
                            </tr>
                            <tr>
                                <td>
                                    <asp:LinkButton ForeColor="white" Font-Underline="true" ID="LinkButton1" runat="server"
                                        CommandName="DelFromCart" OnClientClick="return confirm('真的要从购物车中删除该商品吗？')" CommandArgument='<%# Eval("ID") %>'>移除此项</asp:LinkButton>
                                </td>
                            </tr>
                            <tr style="height: 10px">
                            </tr>
                        </table>
                    </ItemTemplate>
                    <ItemStyle Width="200px" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderStyle ForeColor="white" Font-Size="15px" />
                    <ItemStyle HorizontalAlign="Center" Width="40px" Font-Names="微软雅黑" />
                    <HeaderTemplate>
                        | <font style="font-family: 微软雅黑; font-weight: bold">单价</font>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <font color="white">
                            <%#Eval("ShowPrice") %>
                        </font>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemStyle HorizontalAlign="Center" Width="40px" Font-Names="微软雅黑" />
                    <HeaderStyle ForeColor="white" Font-Size="15px" />
                    <HeaderTemplate>
                        | <font style="font-family: 微软雅黑; font-weight: bold">数量</font>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:TextBox ID="tbNumber" Width="30px" runat="server" ForeColor="black" Text='<%#Eval("Number") %>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemStyle HorizontalAlign="Center" Width="40px" Font-Names="微软雅黑" />
                    <HeaderStyle ForeColor="white" Font-Size="15px" />
                    <FooterStyle />
                    <HeaderTemplate>
                        | <font style="font-family: 微软雅黑; font-weight: bold">合计</font>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <font color="white" style="font-weight: bold">
                            <%#Eval("CurItemTotalPrice")%>
                        </font>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <div style="position: relative; left: 500px; top: 75px">
        <table>
            <tr>
                <td style="width: 90px">
                    <asp:ImageButton ID="ibClearCart" runat="server" ImageUrl="images/clear.jpg" Width="70px"
                        OnClick="ibClearCart_Click" />
                </td>
                <td>
                    <asp:ImageButton ID="ibSaveCart" runat="server" ImageUrl="images/save.jpg" Width="70px"
                        OnClick="ibSaveCart_Click" />
                </td>
            </tr>
        </table>
    </div>
    <div style="position: relative; left: 720px; bottom: 180px; width: 270px; height: 200px;
        border-style:solid; border-width: 2px; border-color: white; font-family: 微软雅黑">
        <table>
            <tr style="height: 30px">
            </tr>
            <tr>
                <td style="width: 15px">
                </td>
                <td style="width: 180px; font-size: 15px; color:white">
                    购物车小结：
                </td>
                <td style="width: 45px">
                </td>
            </tr>
            <tr style="height: 20px">
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Label ID="lbTotalQuantityTitle" ForeColor="white" runat="server" Text="商品总量："></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lbTotalQuantity"  ForeColor="white" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr style="height: 10px">
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Label ID="lbTotalPriceTitle"  ForeColor="white" runat="server" Text="价格总计："></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lbTotalPrice"  ForeColor="white" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr style="height: 50px">
            </tr>
            <tr>
        </table>
        <table>
            <tr>
                <td style="width: 20px">
                </td>
                <td>
                    <asp:ImageButton ID="ibReturn" runat="server" Width="110px" ImageUrl="images/cartReturn.jpg"
                        OnClick="ibReturn_Click" />
                </td>
                <td style="width: 15px">
                </td>
                <td>
                    <asp:ImageButton ID="ibPay" runat="server" Width="110px" ImageUrl="images/cart.jpg"
                        OnClick="ibPay_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
