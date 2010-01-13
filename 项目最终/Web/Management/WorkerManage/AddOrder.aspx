<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddOrder.aspx.cs" Inherits="Management_AddOrder" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>�绰���۶������</title>
    <link rel="stylesheet" type="text/css" href="/Web/Management/bgStyle.css" />
    <script type="text/jscript" >
    function quantityCheck(){
//     var quantity = parseint(document.all.tbGoodQuantity.value);
//     var storage = parseint(document.all.lStorage.value);
     if(document.all.tbGoodQuantity.value.length==0){
      alert("����д������");
      return false;
     }
     if(document.all.tbGoodQuantity.value<0){
      alert("��������С��0��");
      return false;
     }
    }
    function check(){
      if(document.all.tbUserRealName.value.length==0){
       alert("�û���������Ϊ�գ�");
       return false;
      }
      if(document.all.ddlUserProvince.SelectedValue<1){
       alert("��ѡ���û���������");
       return false;
      }
      if(document.all.tbUserAdd.value.length==0){
       alert("�ջ���ַ����Ϊ�գ�");
       return false;
      }
      if(document.all.tbUserZip.value.length>6||document.all.tbUserZip.value.length==0){
       alert("�ʱ��ʽ����");
       return false;
      }
      if(document.all.tbUserTel.value.length>6||document.all.tbUserTel.value.length==0){
       alert("�绰��ʽ����");
       return false;
      }
      if(document.all.cbInvoiceNeeded.checked){
       if(document.all.tbInvoiceHead.value.length==0||document.all.tbInvoiceContent.value.length==0){
        alert("��Ʊ̧ͷ�����ݲ���Ϊ�գ�");
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
                        �绰���۶������</th>
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
                                �����Ϣ
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr style="height: 15px">
                        </tr>
                        <tr style="text-align: left">
                            <td>
                                �ջ�������:
                            </td>
                            <td>
                                <asp:TextBox ID="tbUserRealName" runat="server" Width="152px"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr style="text-align: left">
                            <td>
                                �ջ���ַ:
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlUserProvince" runat="server" OnSelectedIndexChanged="ddlUserProvince_SelectedIndexChanged"
                                    AutoPostBack="true" Width="75px">
                                    <asp:ListItem Text="[��ѡ��]" Value="0" />
                                    <asp:ListItem Text="����" Value="1" />
                                    <asp:ListItem Text="�Ϻ�" Value="2" />
                                    <asp:ListItem Text="����" Value="3" />
                                    <asp:ListItem Text="�ɶ�" Value="4" />
                                    <asp:ListItem Text="����" Value="5" />
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
                                �ʱ�:
                            </td>
                            <td>
                                <asp:TextBox ID="tbUserZip" runat="server" Width="152px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="text-align: left">
                            <td>
                                ��ϵ�绰:
                            </td>
                            <td>
                                <asp:TextBox ID="tbUserTel" runat="server" Width="152px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="height:10px">
                        </tr>
                        <tr style="text-align: left">
                            <td>
                                <asp:CheckBox ID="cbInvoiceNeeded" runat="server" Text="��Ҫ��Ʊ" />
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr style="text-align: left">
                            <td>
                                ��Ʊ̧ͷ:
                            </td>
                            <td>
                                <asp:TextBox ID="tbInvoiceHead" runat="server" Width="152px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="text-align: left">
                            <td>
                                ��Ʊ����:
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
                                ѡ����Ʒ
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr style="height: 10px">
                        </tr>
                        <tr style="text-align: center">
                            <td style="height: 17px; border-left: solid 1px Black; border-right: solid 1px Black">
                                ���
                            </td>
                            <td style="height: 17px; border-right: solid 1px Black">
                                ��Ʒ
                            </td>
                            <td style="width: 30px; height: 17px; border-right: solid 1px Black">
                                ���
                            </td>
                            <td style="width: 30px; height: 17px; border-right: solid 1px Black">
                                �۸�
                            </td>
                            <td style="width: 30px; height: 17px; border-right: solid 1px Black">
                                ����
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
                                <asp:Button ID="bAddGood" runat="server" Text="���" OnClientClick="return quantityCheck()" OnClick="bAddGood_Click" />
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
                                    ��δѡ����Ʒ
                                </td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                    <Columns>
                        <asp:TemplateField>
                            <HeaderStyle ForeColor="White" Font-Size="12px" BackColor="#4455aa" />
                            <HeaderTemplate>
                                <font style="font-weight: bold">��Ʒ</font>
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
                                                (ʣ��: <a><strong>
                                                    <%#Eval("GoodsStorage")%>
                                                </strong></a>��)
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <asp:LinkButton ForeColor="black" Font-Underline="true" ID="LinkButton1" runat="server"
                                                    CommandName="DelFromCart" OnClientClick="return confirm('���Ҫ�ӹ��ﳵ��ɾ������Ʒ��')" CommandArgument='<%# Eval("ID") %>'>�Ƴ�����</asp:LinkButton>
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
                                | <font style="font-weight: bold">����</font>
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
                                | <font style="font-weight: bold">����</font>
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
                                | <font style="font-weight: bold">С��</font>
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
                        <asp:Button ID="ibClearCart" runat="server" Text="���" OnClientClick="return confirm('���Ҫ�����')"
                            OnClick="ibClearCart_Click" />
                    </td>
                    <td style="width: 165px; border-top:dotted 1px black; text-align:left ">
                        <asp:Button ID="bConfirm" runat="server" Text="���ɶ���" OnClientClick="return check()" OnClick="bConfirm_Click"/>
                    </td>
                </tr>
            </table>
            </div>
        </div>
    </form>
</body>
</html>
