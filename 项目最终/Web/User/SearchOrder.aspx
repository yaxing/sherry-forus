<%@ Page Language="C#" MasterPageFile="~/IndexMaster.master" AutoEventWireup="true"
    CodeFile="SearchOrder.aspx.cs" Inherits="SearchOrder" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentHolder" runat="Server">
    <img src="/Web/images/bullet1.gif" width="20" alt="" title="" /><font style="font-size: 19px;
        color: #a81f22">我的订单</font>
    <div style="position: relative; bottom: 20px; left: 330px; color: DarkRed">
        <a href="SearchOrder.aspx">订单搜索</a>&nbsp;|&nbsp;<a href="OrderManage.aspx">我的订单</a>
    </div>
    <asp:Panel ID="pSrch" runat="server">
        <font style="color: DarkRed; font-weight: bold">请选择您要搜索的日期范围:</font>
        <table style="margin-top: 15px">
            <tr>
                <td>
                    <asp:TextBox ID="tbDateStart" runat="server" OnClick="bChooseStartDate_Click"></asp:TextBox>
                    <asp:Button ID="bChooseStartDate" runat="server" OnClick="bChooseStartDate_Click"
                        Style="display: none" />
                </td>
                <td>
                    至
                </td>
                <td>
                    <asp:TextBox ID="tbDateEnd" runat="server" OnClick="bChooseStartDate_Click"></asp:TextBox>
                    <asp:Button ID="bChooseEndDate" runat="server" OnClick="bChooseEndDate_Click" Style="display: none" />
                </td>
                <td>
                    <asp:Button ID="bSrch" runat="server" CssClass="register" Text="搜索" OnClick="bSrch_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Calendar ID="calenderDateStart" runat="server" OnSelectionChanged="calenderDateStart_SelectionChanged">
                    </asp:Calendar>
                </td>
                <td>
                </td>
                <td>
                    <asp:Calendar ID="calenderDateEnd" runat="server" OnSelectionChanged="calenderDateEnd_SelectionChanged">
                    </asp:Calendar>
                </td>
            </tr>
        </table>
        <asp:GridView ID="gvSrchResult" runat="server" AutoGenerateColumns="False" GridLines="None"
            AllowPaging="true" OnPageIndexChanging="gvSrchResult_PageIndexChanging" OnRowCreated="gvSrchResult_RowCreated">
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
                                    <a href='/Web/User/OrderManage.aspx?ID=<%#Eval("orderID") %>'>
                                        <%#Eval("orderID") %>
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
    </asp:Panel>
    <asp:Panel runat="server" ID="pError">
        <div style="position: relative; left: 80px; top: 60px">
            <asp:Label ID="lError" runat="server" ForeColor="red" Font-Bold="true" Font-Size="12px"
                Text=""></asp:Label>
        </div>
    </asp:Panel>
</asp:Content>
