<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShowOrderForWorker.aspx.cs" Inherits="ShowOrderForWorker" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
            <asp:Panel ID="pOrderList" runat="server">
                <div style="position: relative; left: 30px; top: 30px">
                    <asp:GridView ID="gvOrderList" runat="server" AutoGenerateColumns="False" GridLines="None"
                        AllowPaging="true" OnPageIndexChanging="gvOrderList_PageIndexChanging" OnRowCreated="gvOrderList_RowCreated">
                        <Columns>
                            <asp:TemplateField>
                                <HeaderStyle Width="50px" ForeColor="Black" Font-Size="15px" BackColor="LightGray" />
                                <HeaderTemplate>
                                    <font style="font-family: 微软雅黑; font-weight: bold">订单号</font>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <table>
                                        <tr>
                                            <td align="center" style="width: 50px">
                                                <a href='ShowOrdersForManager.aspx?ID=<%#Eval("OrderID") %>'>
                                                    <%#Eval("OrderID") %>
                                                </a>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderStyle Width="200px" BackColor="lightgray" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderStyle Width="180px" ForeColor="Black" Font-Size="15px" BackColor="LightGray" />
                                <HeaderTemplate>
                                    <font style="font-family: 微软雅黑; font-weight: bold">下单时间</font>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <table>
                                        <tr>
                                            <td align="center" style="width: 180px">
                                                <%#Eval("OrderTime") %>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
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
                            </td>
                            <td align="left" style="font-size: 12px; font-weight: bold">
                                <asp:Button ID="cPicking" runat="server" Text="确认发货" onclick="cPicking_Click" />
                                <asp:Button ID="cReturn" runat="server" Text="确认退货" onclick="cReturn_Click" />
                            </td>
                            <td>
                                <asp:Button ID="rReturn" runat="server" Text="退货驳回" onclick="rReturn_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="position: relative; left: 20px; top: 60px">
                    <asp:GridView ID="gvItemList" runat="server" AutoGenerateColumns="False" GridLines="None"
                        AllowPaging="true" OnPageIndexChanging="gvItemList_PageIndexChanging" OnRowCreated="gvItemList_RowCreated">
                        <Columns>
                            <asp:TemplateField>
                                <HeaderStyle Width="180px" ForeColor="Black" Font-Size="15px" BackColor="LightGray" />
                                <HeaderTemplate>
                                    <font style="font-family: 微软雅黑; font-weight: bold">商品</font>
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
                                <HeaderStyle ForeColor="Black" Font-Size="15px" BackColor="LightGray" />
                                <HeaderTemplate>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <table>
                                        <tr>
                                            <td align="center" style="width: 120px">
                                                <a href='Details.aspx?ID=<%#Eval("goodsID") %>' target="_blank">
                                                    <%#Eval("goodsName") %>
                                                </a>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderStyle ForeColor="Black" Font-Size="15px" BackColor="LightGray" />
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
        </div>
    </form>
</body>
</html>
