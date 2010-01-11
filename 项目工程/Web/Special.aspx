<%@ Page Language="C#" MasterPageFile="~/IndexMaster.master" AutoEventWireup="true" CodeFile="Special.aspx.cs" Inherits="Special" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentHolder" Runat="Server">
    <div class="title">
        <span class="title_icon">
            <img src="images/bullet1.gif" alt="" title="" /></span>
            特价产品</div>
    <div class="new_products">
        <asp:DataList runat="server" ID="SpecialGoods" RepeatDirection="Horizontal" RepeatColumns="3">
            <ItemTemplate>
                <div class="new_prod_box">
                    <a href="<%#"Details.aspx?GoodsID=" + DataBinder.Eval(Container.DataItem, "goodsID")%>">
                        <%#DataBinder.Eval(Container.DataItem, "goodsName")%>
                    </a>
                    <div class="new_prod_bg">
                        <span class="new_icon">
                            <img src="images/promo_icon.gif" alt="" title="" /></span> <a href="<%#"Details.aspx?GoodsID=" + DataBinder.Eval(Container.DataItem, "goodsID")%>">
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

