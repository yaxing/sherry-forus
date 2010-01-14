<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FindGoods.aspx.cs" Inherits="FindGoods" %>

<%@ Import Namespace="Entity" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>查找产品</title>
    <link rel="stylesheet" type="text/css" href="/Web/Management/WorkerManage/bgStyle.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="tableBorder" cellspacing="1" cellpadding="2" width="790px" align="center"
                border="0">
                <tr>
                    <th height="25px" class="tableHeaderText">
                        查找产品</th>
                </tr>
            </table>
            <div align="center">
                <div>
                    名称
                    <asp:TextBox ID="GoodsName" runat="server" CausesValidation="true"></asp:TextBox>
                    编号
                    <asp:TextBox ID="GoodsNum" runat="server" CausesValidation="true"></asp:TextBox>
                    类别
                    <asp:ListBox ID="GoodsCategory" runat="server" Rows="1">
                        <asp:ListItem Value="0">所有产品</asp:ListItem>
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
                    </asp:ListBox>
                    日期从<asp:TextBox ID="TimeFrom" runat="server" Width="70"></asp:TextBox>
                    到<asp:TextBox ID="TimeTo" runat="server" Width="70"></asp:TextBox>
                    <asp:Button ID="FindCommit" OnClick="FindGoodsCommit" runat="server" Text="查找产品" />
                </div>
                <br />
                <asp:GridView ID="FindResult" runat="server" AutoGenerateColumns="False" OnRowDeleting="FindResult_RowDeleting"
                    DataKeyNames="goodsID" Width="790px" OnPageIndexChanging="FindResult_PageIndexChanging"
                    OnRowCreated="FindResult_RowCreated" OnRowEditing="FindResult_RowEditing" OnRowCancelingEdit="FindResult_RowCancelingEdit"
                    OnRowUpdating="FindResult_RowUpdating">
                    <Columns>
                        <asp:HyperLinkField DataNavigateUrlFields="goodsID" DataTextField="goodsName" HeaderText="名称"
                            DataNavigateUrlFormatString="Details.aspx?GoodsID={0}">
                            <ItemStyle Width="150px" />
                        </asp:HyperLinkField>
                        <asp:BoundField DataField="goodsNum" HeaderText="编号" ReadOnly="true" ItemStyle-Width="100px" />
                        <asp:BoundField DataField="goodsAddTime" HeaderText="添加日期" ReadOnly="true" ItemStyle-Width="130px" />
                        <asp:TemplateField ShowHeader="False" HeaderText="类别">
                            <ItemTemplate>
                                <%#Category.fulName[Convert.ToInt32(Eval("goodsCategory"))] %>
                            </ItemTemplate>
                            <ItemStyle Width="80px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="goodsStorage" HeaderText="库存" ItemStyle-Width="50px" />
                        <asp:BoundField DataField="goodsPrice" HeaderText="单价" ItemStyle-Width="70px" />
                        <%--<asp:TemplateField ShowHeader="False" HeaderText="价格">
                            <ItemTemplate>
                                <%#String.Format("{0:C}",Eval("goodsPrice")) %>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:CommandField EditImageUrl="../images/update.png" ShowEditButton="True" HeaderText="修改状态"
                            EditText="修改产品状态" ButtonType="Image" ItemStyle-Width="95px" CancelImageUrl="../images/delete.png"
                            UpdateImageUrl="../images/commit.png" />
                        <asp:TemplateField ShowHeader="False" HeaderText="删除" ItemStyle-Width="40px">
                            <ItemTemplate>
                                <asp:ImageButton ID="DeleteGoods" runat="server" CausesValidation="False" CommandName="Delete"
                                    ImageUrl="../images/delete.png" ToolTip="删除" OnClientClick="return confirm('确认要删除吗？');" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ShowHeader="False" HeaderText="修改信息" ItemStyle-Width="55px">
                            <ItemTemplate>
                                <a href='/Web/Management/WorkerManage/ChangeGoods.aspx?GoodsID=<%#Eval("goodsID") %>'>
                                    <img style="border: 0" src="../images/edit.png" alt="修改产品信息" /></a>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <table class="tableBorder" cellspacing="1" cellpadding="2" width="790px" align="center"
                border="0">
                <tr>
                    <th class="tableHeaderText" style="height: 25px">
                        <div style="text-align: center; color: Red">
                            <asp:Label ID="Result" runat="server" /></div>
                    </th>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
