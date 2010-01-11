<%@ Page Language="C#" MasterPageFile="~/IndexMaster.master" AutoEventWireup="true" CodeFile="Goods.aspx.cs" Inherits="Goods" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentHolder" Runat="Server">
    <div class="title">
        <span class="title_icon">
            <img src="images/bullet1.gif" alt="" title="" /></span>
        <asp:Label runat="server" ID="SubTitle" /></div>
    <div class="new_products">
        <asp:DataList runat="server" ID="SameCategory" RepeatDirection="Horizontal" RepeatColumns="3">
            <ItemTemplate>
                <div class="new_prod_box">
                    <a href="<%#"Details.aspx?GoodsID=" + DataBinder.Eval(Container.DataItem, "goodsID")%>">
                        <%#DataBinder.Eval(Container.DataItem, "goodsName")%>
                    </a>
                    <div class="new_prod_bg">
                        <a href="<%#"Details.aspx?GoodsID=" + DataBinder.Eval(Container.DataItem, "goodsID")%>">
                                <img src="<%#DataBinder.Eval(Container.DataItem, "goodsImg")%>" alt="<%#DataBinder.Eval(Container.DataItem, "goodsName")%>"
                                    title="" height="100px" width="112px" class="thumb" />
                            </a>
                    </div>
                </div>
            </ItemTemplate>
        </asp:DataList>
        <br />
    </div>
    <div class="clear">
    </div>
</asp:Content>

