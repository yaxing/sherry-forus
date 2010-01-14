<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddGoods.aspx.cs" Inherits="AddGoods" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>添加产品</title>
    <link rel="stylesheet" type="text/css" href="/Web/Management/WorkerManage/bgStyle.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="tableBorder" cellspacing="1" cellpadding="2" width="790px" align="center"
                border="0">
                <tr>
                    <th height="25px" class="tableHeaderText">
                        添加产品</th>
                </tr>
            </table>
            <div align="center">
                <table>
                    <tr>
                        <td>
                            产品名称</td>
                        <td align="left">
                            <asp:TextBox ID="GoodsName" runat="server" CausesValidation="true"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="GoodsNameRequired" runat="server" ErrorMessage="产品名称必须填写"
                                ControlToValidate="GoodsName"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td>
                            产品编号</td>
                        <td align="left">
                            <asp:TextBox ID="GoodsNum" runat="server" CausesValidation="true"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="GoodsNumRequired" runat="server" ErrorMessage="产品编号必须填写"
                                ControlToValidate="GoodsNum"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td>
                            产品类别</td>
                        <td align="left">
                            <asp:ListBox ID="GoodsCategory" runat="server" Rows="1">
                                <asp:ListItem Value="1">面部护理</asp:ListItem>
                                <asp:ListItem Value="2">手部护理</asp:ListItem>
                                <asp:ListItem Value="3">身体护理</asp:ListItem>
                                <asp:ListItem Value="4">秀发护理</asp:ListItem>
                                <asp:ListItem Value="5">眼部护理</asp:ListItem>
                                <asp:ListItem Value="6">颈部护理</asp:ListItem>
                                <asp:ListItem Value="7">唇部</asp:ListItem>
                                <asp:ListItem Value="8">香水</asp:ListItem>
                                <asp:ListItem Value="9">彩妆</asp:ListItem>
                                <asp:ListItem Value="10">香精/精油/花水</asp:ListItem>
                                <asp:ListItem Value="11">瘦身美体</asp:ListItem>
                            </asp:ListBox></td>
                    </tr>
                    <tr>
                        <td>
                            产品图片</td>
                        <td align="left">
                            <asp:FileUpload ID="GoodsImg" runat="server" />不选为网站默认图片</td>
                    </tr>
                    <tr>
                        <td>
                            产品有效期</td>
                        <td align="left">
                            <asp:TextBox ID="Year" runat="server" Width="15" Text="2"></asp:TextBox>年
                            <asp:TextBox ID="Month" runat="server" Width="15"></asp:TextBox>月
                            <asp:TextBox ID="Day" runat="server" Width="15"></asp:TextBox>日（相对时间）</td>
                    </tr>
                    <tr>
                        <td>
                            产品单价</td>
                        <td align="left">
                            <asp:TextBox ID="GoodsPrice" runat="server"></asp:TextBox>（元）</td>
                    </tr>
                    <tr>
                        <td>
                            产品库存</td>
                        <td align="left">
                            <asp:TextBox ID="GoodsStorage" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>
                            产品上下架状态</td>
                        <td align="left">
                            <asp:RadioButtonList ID="GoodsAvailable" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Text="上架状态" Value="true" />
                                <asp:ListItem Text="下架状态" Value="false" Selected="True" />
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            产品描述</td>
                        <td align="left">
                            <asp:TextBox ID="GoodsDescribe" runat="server" TextMode="MultiLine" Height="200"
                                Width="300" /></td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td align="left">
                            <asp:Button CssClass="register" ID="AddCommit" OnClick="AddGoodsCommit" runat="server"
                                Text="确认" /></td>
                    </tr>
                </table>
            </div>
            <table class="tableBorder" cellspacing="1" cellpadding="2" width="790px" align="center"
                border="0">
                <tr>
                    <th class="tableHeaderText" style="height: 25px">
                        <div style="text-align: center; color: Red">
                            <asp:Label ID="AddResult" runat="server" /></div>
                    </th>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
