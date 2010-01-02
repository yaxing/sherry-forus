<%@ Page Language="C#" MasterPageFile="~/IndexMaster.master" AutoEventWireup="true"
    CodeFile="CartView.aspx.cs" Inherits="CartView" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentHolder" runat="Server">
    <img src="images/bullet1.gif" width="20px" alt="" title="" /><font style="font-size: 19px;
        color: #a81f22">我的购物车</font>
    <div style="position: relative; left: 0px; top: 15px; width: 270px; border-style: solid;
        border-width: 2px; border-color: black; font-family: 微软雅黑">
        <table>
            <tr style="">
            </tr>
            <tr style="">
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Label ID="lbTotalQuantityTitle" ForeColor="black" runat="server" Text="商品总量："></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lbTotalQuantity" ForeColor="black" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr style="">
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Label ID="lbTotalPriceTitle" ForeColor="black" runat="server" Text="价格总计："></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lbTotalPrice" ForeColor="black" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr style="">
            </tr>
            <tr>
        </table>
        <table>
            <tr>
                <td style="width: 20px">
                </td>
                <td>
                    <asp:ImageButton ID="ibReturn" runat="server" Width="85px" ImageUrl="images/goOnShopping.jpg"
                        OnClick="ibReturn_Click" />
                </td>
                <td style="width: 15px">
                </td>
                <td>
                    <asp:ImageButton ID="ibPay" runat="server" Width="85px" ImageUrl="images/Pay.jpg"
                        OnClick="ibPay_Click" />
                </td>
            </tr>
        </table>
    </div>
    <div style="position: relative; left: 0px; font-family: 微软雅黑; font-size: 15px; font-weight: bold;
        width: 350px">
        <table>
            <%--<tr>
                <td style="color: black">
                    您的购物车
                </td>
            </tr>--%>
            <tr>
                <td>
                    <asp:Label ID="lbCookieWarning" runat="server" Font-Size="10px" Font-Names="微软雅黑"
                        Text="！为了您能够方便的使用购物车功能，请将您的浏览器设置为允许cookie！"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <div style="position: relative; left: -10px; top: 30px; height: 320px">
        <asp:GridView ID="gvItems" runat="server" Width="490px" AutoGenerateColumns="False"
            OnRowCommand="gvItems_RowCommand" GridLines="None" AllowPaging="true" OnPageIndexChanging="gvItems_PageIndexChanging"
            OnRowCreated="gvItems_RowCreated">
            <EmptyDataTemplate>
                <table width="100%" style="font-family: 微软雅黑; font-size: 12px">
                    <tr>
                        <td align="center" style="height: 80px">
                            您还没有选购商品。<a href="Goods.aspx">浏览商品>></a>
                        </td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <Columns>
                <asp:TemplateField Visible="False">
                    <ItemTemplate>
                        <asp:Label ID="lbId" runat="server" Text='<%#Eval("ID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemStyle Width="80px" Font-Names="微软雅黑" />
                    <HeaderStyle ForeColor="Black" Font-Size="15px" BackColor="lightgray" />
                    <HeaderTemplate>
                        <font style="font-family: 微软雅黑; font-weight: bold">商品</font>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <table>
                            <tr style="height: 10px">
                            </tr>
                            <tr>
                                <td>
                                    <asp:Image BorderStyle="Solid" BorderColor="black" BorderWidth="1px" ID="itemImg"
                                        runat="server" Width="70px" ImageUrl='<%#Eval("ImgPath") %>' />
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderStyle BackColor="lightgray" />
                    <ItemTemplate>
                        <div style="position:relative; top:20px">
                            <table>
                                <tr style="height: 20px;">
                                </tr>
                                <tr>
                                    <td align="left" style="width:120px">
                                        <asp:LinkButton ForeColor="black" ID="itemInfo" Font-Underline="true" runat="server"
                                            CommandName="ShowInfo" CommandArgument='<%# Eval("ID") %>'><%#Eval("Name") %></asp:LinkButton>
                                    </td>
                                </tr>
                                <tr style="height: 20px">
                                </tr>
                                <tr>
                                    <td>
                                        <asp:LinkButton ForeColor="black" Font-Underline="true" ID="LinkButton1" runat="server"
                                            CommandName="DelFromCart" OnClientClick="return confirm('真的要从购物车中删除该商品吗？')" CommandArgument='<%# Eval("ID") %>'>移除此项</asp:LinkButton>
                                    </td>
                                </tr>
                                <tr style="height: 10px">
                                </tr>
                            </table>
                        </div>
                    </ItemTemplate>
                    <ItemStyle Width="200px" Font-Names="微软雅黑" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderStyle ForeColor="Black" Font-Size="15px" BackColor="lightgray" />
                    <ItemStyle HorizontalAlign="Center" Width="40px" Font-Names="微软雅黑" />
                    <HeaderTemplate>
                        | <font style="font-family: 微软雅黑; font-weight: bold">积分</font>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <font color="black">
                            <%#Eval("TotalPrice") %>分
                        </font>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderStyle ForeColor="Black" Font-Size="15px" BackColor="lightgray" />
                    <ItemStyle HorizontalAlign="Center" Width="40px" Font-Names="微软雅黑" />
                    <HeaderTemplate>
                        | <font style="font-family: 微软雅黑; font-weight: bold">单价</font>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <font color="black">
                            <%#Eval("ShowPrice") %>
                        </font>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemStyle HorizontalAlign="Center" Width="40px" Font-Names="微软雅黑" />
                    <HeaderStyle ForeColor="Black" Font-Size="15px" BackColor="lightgray" />
                    <HeaderTemplate>
                        | <font style="font-family: 微软雅黑; font-weight: bold">数量</font>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:TextBox ID="tbNumber" Width="30px" runat="server" ForeColor="black" Text='<%#Eval("Number") %>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemStyle HorizontalAlign="Center" Width="45px" Font-Names="微软雅黑" />
                    <HeaderStyle ForeColor="Black" Font-Size="15px" BackColor="lightgray" />
                    <HeaderTemplate>
                        | <font style="font-family: 微软雅黑; font-weight: bold">折扣</font>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <%#Convert.ToDouble(Eval("Discount").ToString())*10 %>折
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemStyle HorizontalAlign="Center" Width="40px" Font-Names="微软雅黑" />
                    <HeaderStyle ForeColor="Black" Font-Size="15px" BackColor="lightgray" />
                    <FooterStyle ForeColor="Black" Font-Size="15px" />
                    <HeaderTemplate>
                        | <font style="font-family: 微软雅黑; font-weight: bold">小计</font>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <font color="black" style="font-weight: bold">
                            <%#Eval("CurItemTotalPrice")%>
                        </font>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <div style="position: relative; left: 280px; top: 20px">
            <table>
                <tr>
                    <td style="width: 90px">
                        <asp:ImageButton ID="ibClearCart" runat="server" ImageUrl="images/clearAll.jpg" Width="85px"
                            OnClick="ibClearCart_Click" />
                    </td>
                    <td>
                        <asp:ImageButton ID="ibSaveCart" runat="server" ImageUrl="images/saveCart.jpg" Width="85px"
                            OnClick="ibSaveCart_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
