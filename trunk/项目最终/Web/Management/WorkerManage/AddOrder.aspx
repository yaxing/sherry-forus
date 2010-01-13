<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddOrder.aspx.cs" Inherits="Management_AddOrder" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>电话销售订单添加</title>
    <link rel="stylesheet" type="text/css" href="/Web/Management/bgStyle.css" />
    <script type="text/jscript" >
    function quantityCheck(){
//     var quantity = parseint(document.all.tbGoodQuantity.value);
//     var storage = parseint(document.all.lStorage.value);
     if(document.all.tbGoodQuantity.value.length==0){
      alert("请填写数量！");
      return false;
     }
     if(document.all.tbGoodQuantity.value<0){
      alert("数量不能小于0！");
      return false;
     }
    }
    function check(){
      if(document.all.tbUserRealName.value.length==0){
       alert("用户姓名不能为空！");
       return false;
      }
      if(document.all.ddlUserProvince.SelectedValue<1){
       alert("请选择用户所在区域！");
       return false;
      }
      if(document.all.tbUserAdd.value.length==0){
       alert("收货地址不能为空！");
       return false;
      }
      if(document.all.tbUserZip.value.length>6||document.all.tbUserZip.value.length==0){
       alert("邮编格式错误！");
       return false;
      }
      if(document.all.tbUserTel.value.length>6||document.all.tbUserTel.value.length==0){
       alert("电话格式错误！");
       return false;
      }
      if(document.all.cbInvoiceNeeded.checked){
       if(document.all.tbInvoiceHead.value.length==0||document.all.tbInvoiceContent.value.length==0){
        alert("发票抬头和内容不能为空！");
        return false;
       }
      }
    }
    </script>
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
                <div style="width: 455px; position: relative; right: 170px; border-right-color: Black;
                    border-right-style: dotted; border-right-width: 1px; border-bottom: dotted 1px Black;">
                    <table style="width: 270px">
                        <tr style="height: 10px">
                        </tr>
                        <tr style="text-align: center">
                            <td style="font-weight: bold">
                                买家信息
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr style="height: 15px">
                        </tr>
                        <tr style="text-align: left">
                            <td>
                                收货人姓名:
                            </td>
                            <td>
                                <asp:TextBox ID="tbUserRealName" runat="server" Width="152px"></asp:TextBox>
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
                                <asp:TextBox ID="tbUserAdd" runat="server" Width="152px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="text-align: left">
                            <td>
                                邮编:
                            </td>
                            <td>
                                <asp:TextBox ID="tbUserZip" runat="server" Width="152px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="text-align: left">
                            <td>
                                联系电话:
                            </td>
                            <td>
                                <asp:TextBox ID="tbUserTel" runat="server" Width="152px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="height:10px">
                        </tr>
                        <tr style="text-align: left">
                            <td>
                                <asp:CheckBox ID="cbInvoiceNeeded" runat="server" Text="需要发票" />
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr style="text-align: left">
                            <td>
                                发票抬头:
                            </td>
                            <td>
                                <asp:TextBox ID="tbInvoiceHead" runat="server" Width="152px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="text-align: left">
                            <td>
                                发票内容:
                            </td>
                            <td>
                                <asp:TextBox ID="tbInvoiceContent" runat="server" Width="152px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="height: 15px">
                        </tr>
                    </table>
                </div>
                <div style="width: 455px; position: relative; right: 170px; border-right-color: Black;
                    border-right-style: dotted; border-right-width: 1px">
                    <table style="width: 270px">
                        <tr style="height: 10px">
                        </tr>
                        <tr style="text-align: center">
                            <td style="font-weight: bold">
                                选择商品
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr style="height: 10px">
                        </tr>
                        <tr style="text-align: center">
                            <td style="height: 17px; border-left: solid 1px Black; border-right: solid 1px Black">
                                类别
                            </td>
                            <td style="height: 17px; border-right: solid 1px Black">
                                商品
                            </td>
                            <td style="width: 30px; height: 17px; border-right: solid 1px Black">
                                库存
                            </td>
                            <td style="width: 30px; height: 17px; border-right: solid 1px Black">
                                价格
                            </td>
                            <td style="width: 30px; height: 17px; border-right: solid 1px Black">
                                数量
                            </td>
                        </tr>
                        <tr style="text-align: left">
                            <td>
                                <asp:DropDownList ID="ddlGoodsCategory" runat="server" Width="100px" AutoPostBack="true"
                                    OnSelectedIndexChanged="ddlGoodsCategory_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlGoods" runat="server" Width="150px" AutoPostBack="true"
                                    OnSelectedIndexChanged="ddlGoods_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td style="text-align: center">
                                <asp:Label ID="lStorage" runat="server" Width="30px"></asp:Label>
                            </td>
                            <td style="text-align: center">
                                <asp:Label ID="lPrice" runat="server" Width="30px"></asp:Label>
                            </td>
                            <td style="text-align: center">
                                <asp:TextBox ID="tbGoodQuantity" runat="server" Width="30px"></asp:TextBox>
                            </td>
                            <td style="text-align: center">
                                <asp:Button ID="bAddGood" runat="server" Text="添加" OnClientClick="return quantityCheck()" OnClick="bAddGood_Click" />
                            </td>
                        </tr>
                        <tr style="height: 15px">
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
            <div style="position: relative; left: 580px; bottom: 403px">
                <asp:GridView ID="gvItems" runat="server" Width="330px" AutoGenerateColumns="False"
                    OnRowCommand="gvItems_RowCommand" GridLines="None" AllowPaging="true" OnPageIndexChanging="gvItems_PageIndexChanging"
                    OnRowCreated="gvItems_RowCreated">
                    <EmptyDataTemplate>
                        <table width="100%" style="font-size: 12px">
                            <tr>
                                <td align="center" style="height: 80px">
                                    尚未选择商品
                                </td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                    <Columns>
                        <asp:TemplateField>
                            <HeaderStyle ForeColor="White" Font-Size="12px" BackColor="#4455aa" />
                            <HeaderTemplate>
                                <font style="font-weight: bold">商品</font>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%--<div style="position: relative; top: 0px">--%>
                                    <table>
                                        <tr style="height: 20px;">
                                        </tr>
                                        <tr>
                                            <td align="center" style="width: 120px">
                                                <%#Eval("Name") %>
                                            </td>
                                        </tr>
                                        <tr style="height: 20px">
                                            <td align="center">
                                                (剩余: <a><strong>
                                                    <%#Eval("GoodsStorage")%>
                                                </strong></a>个)
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <asp:LinkButton ForeColor="black" Font-Underline="true" ID="LinkButton1" runat="server"
                                                    CommandName="DelFromCart" OnClientClick="return confirm('真的要从购物车中删除该商品吗？')" CommandArgument='<%# Eval("ID") %>'>移除此项</asp:LinkButton>
                                            </td>
                                        </tr>
                                        <tr style="height: 10px">
                                        </tr>
                                    </table>
                                <%--</div>--%>
                            </ItemTemplate>
                            <ItemStyle Width="180px" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderStyle ForeColor="White" Font-Size="12px" BackColor="#4455aa" />
                            <ItemStyle HorizontalAlign="Center" Width="40px" />
                            <HeaderTemplate>
                                | <font style="font-weight: bold">单价</font>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <font color="black">
                                    <%#Eval("ShowPrice") %>
                                </font>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemStyle HorizontalAlign="Center" Width="45px" />
                            <HeaderStyle ForeColor="White" Font-Size="12px" BackColor="#4455aa" />
                            <HeaderTemplate>
                                | <font style="font-weight: bold">数量</font>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="tbNumber" Width="30px" runat="server" ForeColor="black" Text='<%#Eval("Number") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemStyle HorizontalAlign="Center" Width="40px" />
                            <HeaderStyle ForeColor="White" Font-Size="12px" BackColor="#4455aa" />
                            <FooterStyle ForeColor="Black" Font-Size="12px" />
                            <HeaderTemplate>
                                | <font style="font-weight: bold">小计</font>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <font color="darkred" style="font-weight: bold">
                                    <%#Eval("CurItemTotalPrice")%>
                                </font>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <table>
                <tr style="width: 330px; ">
                    <td style="width: 165px; border-top:dotted 1px black; text-align:right ">
                        <asp:Button ID="ibClearCart" runat="server" Text="清空" OnClientClick="return confirm('真的要清空吗？')"
                            OnClick="ibClearCart_Click" />
                    </td>
                    <td style="width: 165px; border-top:dotted 1px black; text-align:left ">
                        <asp:Button ID="bConfirm" runat="server" Text="生成订单" OnClientClick="return check()" OnClick="bConfirm_Click"/>
                    </td>
                </tr>
            </table>
            </div>
        </div>
    </form>
</body>
</html>
