<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddOrder.aspx.cs" Inherits="Management_AddOrder" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>电话销售订单添加</title>
    <link rel="stylesheet" type="text/css" href="bgStyle.css" />
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
                        电话销售订单添加</th>
                </tr>
            </table>
            <div align="center">
                <table style="width: 270px">
                    <tr style="text-align: left">
                        <td>
                            用户真实姓名:
                        </td>
                        <td>
                            <asp:TextBox ID="tbUserRealName" runat="server"></asp:TextBox>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr style="text-align: left">
                        <td>
                            收货地址:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlUserProvince" runat="server" OnSelectedIndexChanged="ddlUserProvince_SelectedIndexChanged"
                                AutoPostBack="true" Width="75px">
                                <asp:ListItem Text="[请选择]" Value="0" />
                                <asp:ListItem Text="北京" Value="1" />
                                <asp:ListItem Text="上海" Value="2" />
                                <asp:ListItem Text="沈阳" Value="3" />
                                <asp:ListItem Text="成都" Value="4" />
                                <asp:ListItem Text="广州" Value="5" />
                            </asp:DropDownList>
                            <asp:DropDownList ID="ddlUserArea" runat="server" AutoPostBack="false" Width="75px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr style="text-align: left">
                        <td>
                        </td>
                        <td>
                            <asp:TextBox ID="tbUserAdd" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="text-align: left">
                        <td>
                            邮编:
                        </td>
                        <td>
                            <asp:TextBox ID="tbUserZip" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="text-align: left">
                        <td>
                            联系电话:
                        </td>
                        <td>
                            <asp:TextBox ID="tbUserTel" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <table style="width: 270px">
                    <tr style="height: 10px">
                    </tr>
                    <tr style="text-align: center">
                        <td style="font-weight:bold">
                            请选择要购买的商品:
                        </td>
                    </tr>
                </table>
                <table>
                <tr style="height:10px"></tr>
                    <tr style="text-align: left">
                        <td>
                            类别
                        </td>
                        <td>
                            商品
                        </td>
                        <td>
                            库存
                        </td>
                        <td>
                            数量
                        </td>
                    </tr>
                    <tr style="text-align: left">
                        <td>
                            <asp:DropDownList ID="ddlGoodsCategory" runat="server" Width="100px" AutoPostBack="false" OnSelectedIndexChanged="ddlGoodsCategory_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlGoods" runat="server" Width="150px" AutoPostBack="false">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Label ID="lStorage" runat="server" Width="15px"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="tbGoodQuantity" runat="server" Width="15px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="bAddGood" runat="server" Text="添加" />
                        </td>
                    </tr>
                </table>
            </div>
            <table class="tableBorder" cellspacing="1" cellpadding="2" width="790px" align="center"
                border="0">
                <tr>
                    <th width="100%" class="tableHeaderText" style="height: 25px">
                        &nbsp;</th>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
