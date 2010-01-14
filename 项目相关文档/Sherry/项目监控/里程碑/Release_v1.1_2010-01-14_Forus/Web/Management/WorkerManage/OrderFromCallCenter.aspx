<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrderFromCallCenter.aspx.cs"
    Inherits="Management_OrderFromCallCenter" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>�绰���۶�����ʾ</title>
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
                        �绰���۶���</th>
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
                                                <font style="font-weight: bold">������</font>
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
                                                <font style="font-weight: bold">�µ�ʱ��</font>
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
                                    �ջ���
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
                                    �ջ���ַ
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
                                    �ջ��˵绰
                                </td>
                                <td>
                                    <asp:Label ID="lUserTel" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="font-size: 12px; font-weight: bold; text-align:left">
                                    �����ܼ�
                                </td>
                                <td>
                                    <asp:Label ID="lTotalPrice" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="font-size: 12px; font-weight: bold; text-align:left">
                                    �µ�ʱ��
                                </td>
                                <td>
                                    <asp:Label ID="lOrderTime" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="font-size: 12px; font-weight: bold; text-align:left">
                                    ����״̬
                                </td>
                                <td>
                                    <asp:Label ID="lState" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                               <td style="width: 200px">
                                    <asp:Button ID="bBackToList" runat="server" CssClass="register" Text="����" OnClick="bBackToList_Click" />
                                </td>
                                <td align="right" style="font-size: 12px; font-weight: bold">
                                    <%--<asp:Button ID="bCancel" runat="server" OnClick="bCancel_Click" CssClass="register"
                                        Text="��������" />
                                    <asp:Button ID="bReturn" runat="server" Text="�����˻�" CssClass="register" OnClick="bReturn_Click" />--%>
                                </td>
                                <td>
                                    <%--<asp:Button ID="imgbPay" runat="server" OnClick="imgbPay_Click" CssClass="register"
                                        Text="�� ��" />--%>
                                    <asp:Button ID="bConfirm" runat="server" OnClick="bConfirm_Click" CssClass="register"
                                        Text="ȷ���ջ�" />
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
                                        <font style="font-weight: bold">��Ʒ</font>
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
                                        <font style="font-family: ΢���ź�; font-weight: bold">С��</font>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <table>
                                            <tr>
                                                <td align="center" style="width: 120px">
                                                    <%#Eval("goodsNum") %>
                                                    ��
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
