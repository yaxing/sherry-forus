<%@ Page Language="C#" MasterPageFile="~/IndexMaster.master" AutoEventWireup="true"
    CodeFile="OrderManage.aspx.cs" Inherits="OrderManage" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentHolder" runat="Server">
    <img src="images/bullet1.gif" width="20" alt="" title="" /><font style="font-size: 19px;
        color: #a81f22">我的订单</font>
    <div style="position: relative; bottom: 20px; left: 330px; color: DarkRed">
        <a href="SearchOrder.aspx">订单搜索</a>&nbsp;|&nbsp;<a href="OrderManage.aspx">我的订单</a>
    </div>
    <asp:Panel ID="pOrderList" runat="server">
        <div id="demo" class="demolayout" style="margin-top: 10px; margin-top: 20pxf">
            <asp:Literal ID="ltTabs" runat="server"></asp:Literal>
            <div class="tabs-container">
                <div style="display: block; height: 416px; width: 436px" class="tab" id="tab1">
                    <asp:GridView ID="gvOrderList" runat="server" AutoGenerateColumns="False" GridLines="None"
                        AllowPaging="true" OnPageIndexChanging="gvOrderList_PageIndexChanging" OnRowCreated="gvOrderList_RowCreated">
                        <Columns>
                            <asp:TemplateField>
                                <HeaderStyle Width="50px" ForeColor="White" Font-Size="15px" BackColor="darkred" />
                                <HeaderTemplate>
                                    <font style="font-weight: bold">订单号</font>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <table>
                                        <tr>
                                            <td align="center" style="width: 50px">
                                                <a href='OrderManage.aspx?ID=<%#Eval("mainOrderID") %>'>
                                                    <%#Eval("mainOrderID") %>
                                                </a>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderStyle Width="200px" BackColor="darkred" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderStyle Width="180px" ForeColor="White" Font-Size="15px" BackColor="darkred" />
                                <HeaderTemplate>
                                    <font style="font-weight: bold">下单时间</font>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <table>
                                        <tr>
                                            <td align="center" style="width: 180px">
                                                <%#Eval("orderTime") %>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <div style="display: none; height: 416px; width: 436px" class="tab" id="tab2">
                    <asp:GridView ID="gvOrderListHistory" runat="server" AutoGenerateColumns="False"
                        GridLines="None" AllowPaging="true" OnPageIndexChanging="gvOrderList_PageIndexChanging"
                        OnRowCreated="gvOrderList_RowCreated">
                        <Columns>
                            <asp:TemplateField>
                                <HeaderStyle Width="50px" ForeColor="White" Font-Size="15px" BackColor="darkred" />
                                <HeaderTemplate>
                                    <font style="font-weight: bold">订单号</font>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <table>
                                        <tr>
                                            <td align="center" style="width: 50px">
                                                <a href='OrderManage.aspx?ID=<%#Eval("mainOrderID") %>'>
                                                    <%#Eval("mainOrderID") %>
                                                </a>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderStyle Width="200px" BackColor="darkred" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderStyle Width="180px" ForeColor="White" Font-Size="15px" BackColor="darkred" />
                                <HeaderTemplate>
                                    <font style="font-weight: bold">下单时间</font>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <table>
                                        <tr>
                                            <td align="center" style="width: 180px">
                                                <%#Eval("orderTime") %>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <div class="clear">
                    </div>
                </div>
            </div>
        </div>
        <div class="clear">
        </div>
        <div style="">
        </div>
    </asp:Panel>
    <asp:Panel ID="pOrderDetail" runat="server">
        <div style="position: relative; left: 20px; top: 30px">
            <table>
                <tr>
                    <td style="font-size: 12px; font-weight: bold">
                        收货人
                    </td>
                    <td>
                        <asp:Label ID="lOrderID" runat="server" Text=""></asp:Label>
                        <asp:Label ID="lUserRealName" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td style="font-size: 12px; font-weight: bold">
                        收货地址
                    </td>
                    <td>
                        <asp:Label ID="lUserProvince" runat="server" Text=""></asp:Label>
                        <asp:Label ID="lUserAdd" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lUserZip" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="font-size: 12px; font-weight: bold">
                        收货人电话
                    </td>
                    <td>
                        <asp:Label ID="lUserTel" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="font-size: 12px; font-weight: bold">
                        订单总计
                    </td>
                    <td>
                        <asp:Label ID="lTotalPrice" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="font-size: 12px; font-weight: bold">
                        下单时间
                    </td>
                    <td>
                        <asp:Label ID="lOrderTime" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="font-size: 12px; font-weight: bold">
                        订单状态
                    </td>
                    <td>
                        <asp:Label ID="lState" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td style="width: 200px">
                        <asp:Button ID="bBackToList" runat="server" CssClass="register" Text="返回" OnClick="bBackToList_Click" />
                    </td>
                    <td align="right" style="font-size: 12px; font-weight: bold">
                        <asp:Button ID="bCancel" runat="server" OnClick="bCancel_Click" CssClass="register"
                            Text="撤销订单" />
                        <asp:Button ID="bReturn" runat="server" Text="申请退货" CssClass="register" OnClick="bReturn_Click" />
                    </td>
                    <td>
                        <asp:Button ID="imgbPay" runat="server" OnClick="imgbPay_Click" CssClass="register"
                            Text="付 款" />
                        <asp:Button ID="bConfirm" runat="server" OnClick="bConfirm_Click" CssClass="register"
                            Text="确认收货" />
                    </td>
                </tr>
            </table>
        </div>
        <div style="position: relative; left: 20px; top: 60px">
            <asp:GridView ID="gvItemList" runat="server" AutoGenerateColumns="False" GridLines="None"
                AllowPaging="true" OnPageIndexChanging="gvItemList_PageIndexChanging" OnRowCreated="gvItemList_RowCreated">
                <Columns>
                    <asp:TemplateField>
                        <HeaderStyle Width="180px" ForeColor="White" Font-Size="15px" BackColor="darkred" />
                        <HeaderTemplate>
                            <font style="font-weight: bold">商品</font>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <table>
                                <tr>
                                    <td align="center" style="width: 180px">
                                        <asp:Image BorderStyle="Solid" BorderColor="black" BorderWidth="1px" ID="itemImg"
                                            runat="server" Width="70px" ImageUrl='<%#Eval("goodsImg") %>' />
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderStyle ForeColor="White" Font-Size="15px" BackColor="darkred" />
                        <HeaderTemplate>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <table>
                                <tr>
                                    <td align="center" style="width: 120px">
                                        <a href='Details.aspx?GoodsID=<%#Eval("goodsID") %>'>
                                            <%#Eval("goodsName") %>
                                        </a>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderStyle ForeColor="White" Font-Size="15px" BackColor="darkred" />
                        <HeaderTemplate>
                            <font style="font-family: 微软雅黑; font-weight: bold">小计</font>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <table>
                                <tr>
                                    <td align="center" style="width: 120px">
                                        <%#Eval("goodsNum") %>
                                        ×
                                        <%#String.Format("{0:C}",Convert.ToDouble(Eval("goodsPrice").ToString())) %>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="pError">
        <div style="position: relative; left: 80px; top: 60px">
            <asp:Label ID="lError" runat="server" ForeColor="red" Font-Bold="true" Font-Size="12px"
                Text=""></asp:Label>
        </div>
    </asp:Panel>
</asp:Content>
