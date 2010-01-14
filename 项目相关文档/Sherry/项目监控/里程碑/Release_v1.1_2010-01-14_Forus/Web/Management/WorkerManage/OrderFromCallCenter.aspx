<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrderFromCallCenter.aspx.cs"
    Inherits="Management_OrderFromCallCenter" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>电话销售订单显示</title>
    <link rel="stylesheet" type="text/css" href="/Web/Management/bgStyle.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table cellspacing="1" cellpadding="3" width="790px" align="center" border="0">
                <tr>
                    <td valign="top" width="100%">
                        <p>
                            <br />
                        </p>
                    </td>
                </tr>
            </table>
            <table class="tableBorder" cellspacing="1" cellpadding="2" width="790px" align="center"
                border="0">
                <tr>
                    <th width="100%" height="25px" class="tableHeaderText">
                        电话销售订单</th>
                </tr>
            </table>
            <div align="center">
                <asp:Panel ID="pOrderList" runat="server">
                    <div id="demo" class="demolayout" style="margin-top: 10px; margin-bottom:10px">
                        <asp:Literal ID="ltTabs" runat="server"></asp:Literal>
                        <div class="tabs-container">
                            <div style="display: block;" id="tab1">
                                <asp:GridView ID="gvOrderList" runat="server" AutoGenerateColumns="False" GridLines="None"
                                    AllowPaging="true" OnPageIndexChanging="gvOrderList_PageIndexChanging" OnRowCreated="gvOrderList_RowCreated">
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderStyle Width="50px" ForeColor="White" Font-Size="12px" BackColor="#4455aa" />
                                            <HeaderTemplate>
                                                <font style="font-weight: bold">订单号</font>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <table>
                                                    <tr>
                                                        <td align="center" style="width: 50px">
                                                            <a href='/Web/Management/WorkerManage/OrderFromCallCenter.aspx?ID=<%#Eval("mainOrderID") %>'>
                                                                <%#Eval("mainOrderID") %>
                                                            </a>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderStyle Width="200px" Font-Size="12px" BackColor="#4455aa" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderStyle Width="180px" ForeColor="White" Font-Size="12px" BackColor="#4455aa" />
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
                        </div>
                    </div>
                    <div class="clear">
                    </div>
                    <div style="">
                    </div>
                </asp:Panel>
                <asp:Panel ID="pOrderDetail" runat="server">
                    <div style="position: relative; right: 200px; top: 30px; border-right: dotted 1px Black; width:380px">
                        <table>
                            <tr>
                                <td style="font-size: 12px; font-weight: bold; text-align:left">
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
                                <td style="font-size: 12px; font-weight: bold; text-align:left">
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
                                <td style="font-size: 12px; font-weight: bold; text-align:left">
                                    收货人电话
                                </td>
                                <td>
                                    <asp:Label ID="lUserTel" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="font-size: 12px; font-weight: bold; text-align:left">
                                    订单总计
                                </td>
                                <td>
                                    <asp:Label ID="lTotalPrice" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="font-size: 12px; font-weight: bold; text-align:left">
                                    下单时间
                                </td>
                                <td>
                                    <asp:Label ID="lOrderTime" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="font-size: 12px; font-weight: bold; text-align:left">
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
                                    <%--<asp:Button ID="bCancel" runat="server" OnClick="bCancel_Click" CssClass="register"
                                        Text="撤销订单" />
                                    <asp:Button ID="bReturn" runat="server" Text="申请退货" CssClass="register" OnClick="bReturn_Click" />--%>
                                </td>
                                <td>
                                    <%--<asp:Button ID="imgbPay" runat="server" OnClick="imgbPay_Click" CssClass="register"
                                        Text="付 款" />--%>
                                    <asp:Button ID="bConfirm" runat="server" OnClick="bConfirm_Click" CssClass="register"
                                        Text="确认收货" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div style="position: relative; left: 220px; bottom:136px">
                        <asp:GridView ID="gvItemList" runat="server" AutoGenerateColumns="False" GridLines="None"
                            AllowPaging="true" OnPageIndexChanging="gvItemList_PageIndexChanging" OnRowCreated="gvItemList_RowCreated">
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderStyle Width="180px" ForeColor="White" Font-Size="12px" BackColor="#4455aa" />
                                    <HeaderTemplate>
                                        <font style="font-weight: bold">商品</font>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <table>
                                            <tr>
                                                <td align="center" style="width: 120px">
                                                    <a href='/Web/Details.aspx?GoodsID=<%#Eval("goodsID") %>'>
                                                        <%#Eval("goodsName") %>
                                                    </a>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderStyle ForeColor="White" Font-Size="12px" BackColor="#4455aa" />
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
                <table class="tableBorder" cellspacing="1" cellpadding="2" width="790px" align="center"
                    border="0">
                    <tr>
                        <th width="100%" class="tableHeaderText" style="height: 25px">
                            &nbsp;</th>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
