<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShowOrderForWorker.aspx.cs" Inherits="ShowOrderForWorker" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>工作人员定单显示</title>
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
                        工作人员订单显示</th>
                </tr>
            </table>
            <div align="center">
            <asp:Panel ID="pOrderList" runat="server">
                    <asp:GridView ID="gvOrderList" runat="server" AutoGenerateColumns="False" GridLines="None"
                        AllowPaging="true" OnPageIndexChanging="gvOrderList_PageIndexChanging" OnRowCreated="gvOrderList_RowCreated" Width="490px">
                        <Columns>
                            <asp:TemplateField>
                                <HeaderStyle Width="50px" ForeColor="Black" Font-Size="15px"/>
                                <HeaderTemplate>
                                    <font style="font-weight: bold;" color="white">订单号</font>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <table>
                                        <tr>
                                            <td align="center" style="width: 50px">
                                                <a href='ShowOrderForWorker.aspx?ID=<%#Eval("OrderID") %>'>
                                                    <%#Eval("OrderID") %>
                                                </a>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderStyle Width="200px"/>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderStyle Width="180px" ForeColor="Black" Font-Size="15px"/>
                                <HeaderTemplate>
                                    <font style="font-weight: bold;" color="white">下单时间</font>
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
            </asp:Panel>
            <asp:Panel ID="pOrderDetail" runat="server" Width="790px">
            <table width="790px">
            <tr>
            <td width="375px">
                    <table width="375px" align="left">
                        <tr>
                            <td style="font-size: 12px; font-weight: bold" width="30%" align="left">
                                收货人
                            </td>
                            <td align="left">
                                <asp:Label ID="lOrderID" runat="server" Text=""></asp:Label>
                                <asp:Label ID="lUserRealName" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-size: 12px; font-weight: bold" align="left">
                                收货地址
                            </td>
                            <td align="left">
                                <asp:Label ID="lUserProvince" runat="server" Text=""></asp:Label>
                                <asp:Label ID="lUserAdd" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-size: 12px; font-weight: bold" align="left">
                                邮政编码
                            </td>
                            <td align="left">
                                <asp:Label ID="lUserZip" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-size: 12px; font-weight: bold" align="left">
                                收货人电话
                            </td>
                            <td align="left">
                                <asp:Label ID="lUserTel" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-size: 12px; font-weight: bold" align="left">
                                订单总计
                            </td>
                            <td align="left">
                                <asp:Label ID="lTotalPrice" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-size: 12px; font-weight: bold" align="left">
                                下单时间
                            </td>
                            <td align="left">
                                <asp:Label ID="lOrderTime" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-size: 12px; font-weight: bold" align="left">
                                订单状态
                            </td>
                            <td align="left">
                                <asp:Label ID="lState" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <table width="375px">
                        <tr>
                            <td align="right" style="font-size: 12px; font-weight: bold" width="200px">
                                <asp:Button ID="cPicking" runat="server" Text="确认发货" onclick="cPicking_Click" CssClass="submit"/>
                                <asp:Button ID="cReturn" runat="server" Text="确认退货" onclick="cReturn_Click" CssClass="submit"/>
                            </td>
                            <td width="195px" align="right">
                                <asp:Button ID="rReturn" runat="server" Text="退货驳回" onclick="rReturn_Click" CssClass="submit"/>
                            </td>
                        </tr>
                    </table>
                    </td>
                    <td width="395px">
                    <asp:GridView ID="gvItemList" runat="server" AutoGenerateColumns="False" GridLines="None"
                        AllowPaging="true" OnPageIndexChanging="gvItemList_PageIndexChanging" OnRowCreated="gvItemList_RowCreated" Width="395px">
                        <Columns>
                            <asp:TemplateField>
                                <HeaderStyle Width="180px" ForeColor="Black" Font-Size="15px"/>
                                <HeaderTemplate>
                                    <font style="font-weight: bold;" color="white">商品</font>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <table>
                                        <tr>
                                            <td align="center" style="width: 180px">
                                                <asp:Image BorderStyle="Solid" BorderColor="black" BorderWidth="1px" ID="itemImg"
                                                    runat="server" Width="70px" ImageUrl='<%#"../../"+Eval("goodsImg") %>' />
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderStyle ForeColor="Black" Font-Size="15px" />
                                <HeaderTemplate>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <table>
                                        <tr>
                                            <td align="center" style="width: 120px">
                                                <a href='../../Details.aspx?ID=<%#Eval("goodsID") %>' target="_blank">
                                                    <%#Eval("goodsName") %>
                                                </a>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderStyle ForeColor="Black" Font-Size="15px"/>
                                <HeaderTemplate>
                                    <font style="font-weight: bold;" color="white">小计</font>
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
                </td>
                </tr>
                </table>
            </asp:Panel>
            <asp:Panel runat="server" ID="pError">
                    <asp:Label ID="lError" runat="server" ForeColor="red" Font-Bold="true" Font-Size="12px"
                        Text=""></asp:Label>
            </asp:Panel>
            <table class="tableBorder" cellspacing="1" cellpadding="2" width="790px" align="center" border="0">
           <tr>
             <th width="100%" class="tableHeaderText" style="height: 25px" />
           </tr>
         </table>
            </div>
        </div>
    </form>
</body>
</html>
