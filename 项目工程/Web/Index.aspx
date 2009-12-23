<%@ Page Language="C#" MasterPageFile="~/IndexMaster.master" AutoEventWireup="true"
    CodeFile="Index.aspx.cs" Inherits="Index" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentHolder" runat="Server">
    <div class="title">
        <span class="title_icon">
            <img src="images/bullet1.gif" alt="" title="" /></span>热卖产品</div>
    <asp:Repeater runat="server" ID="HotGoods">
        <ItemTemplate>
            <div class="feat_prod_box">
                <div class="prod_img">
                    <a href="Details.aspx?GoodsID=<%#Eval("goodsID")%>">
                        <img src="<%#Eval("goodsImg")%>" width="149px" height="137px" alt="<%#Eval("goodsName")%>" title="" /></a></div>
                <div class="prod_det_box">
                    <div class="box_top">
                    </div>
                    <div class="box_center">
                        <div class="prod_title">
                            <%#Eval("goodsName")%></div>
                        <p class="details">
                            <%#Eval("goodsDescribe")%></p>
                        <a href="Details.aspx?GoodsID=<%#Eval("goodsID")%>" class="more">- 详细信息 -</a>
                        <div class="clear">
                        </div>
                    </div>
                    <div class="box_bottom">
                    </div>
                </div>
                <div class="clear">
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
    <div class="title">
        <span class="title_icon">
            <img src="images/bullet2.gif" alt="" title="" /></span>新品上架</div>
    <div class="new_products">
        <asp:Repeater runat="server" ID="NewGoods">
            <ItemTemplate>
                <div class="new_prod_box">
                    <a href="Details.aspx?GoodsID=<%#Eval("goodsID")%>">
                        <%#Eval("goodsName")%>
                    </a>
                    <div class="new_prod_bg">
                        <span class="new_icon">
                            <img src="images/new_icon.gif" alt="" title="" /></span> <a href="Details.aspx?GoodsID=<%#Eval("goodsID")%>">
                                <img src="<%#Eval("goodsImg")%>" alt="<%#Eval("goodsName")%>" title="" height="100px"
                                    width="112px" class="thumb" />
                            </a>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div class="clear">
    </div>
</asp:Content>
