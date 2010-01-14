<%@ Page Language="C#" MasterPageFile="~/IndexMaster.master" AutoEventWireup="true"
    CodeFile="Details.aspx.cs" Inherits="Details" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentHolder" runat="Server">
    <div class="title">
        <span class="title_icon">
            <img src="images/bullet1.gif" alt="" title="" /></span>
        <asp:Label ID="GoodsName" runat="server" /></div>
    <div class="feat_prod_box_details">
        <div class="prod_img">
            <asp:Image ID="GoodsImg" runat="server" Width="150px" Height="150px" />
            <br />
            <br />
            <a href="images/eg2.jpg" rel="lightbox">
                <img src="images/zoom.gif" alt="" title="" /></a>
        </div>
        <div class="prod_det_box">
            <div class="box_top">
            </div>
            <div class="box_center">
                <div class="prod_title">
                    详细信息</div>
                <p class="details">
                    <asp:Label ID="ShortGoodsDescribe" runat="server" />
                </p>
                <div class="price">
                    <strong>售价:</strong> <span class="red">
                        <asp:Label ID="GoodsPrice" runat="server" /></span></div>
                <div class="price">
                    <strong>折扣:</strong>
                    <asp:Label ID="Discount" runat="server" ToolTip="网购为9.5折，会员或商品为特价为9.0折" />
                </div>
                <div style="padding: 0 30px 0 0px">
                    <asp:Button ID="addToCart" runat="server" OnClick="addToCart_Click" CssClass="register"
                        Text="加入购物车" ToolTip="加入购物车" /></div>
                <div class="clear">
                </div>
            </div>
            <div class="box_bottom">
            </div>
        </div>
        <div class="clear">
        </div>
    </div>
    <div id="demo" class="demolayout">
        <ul id="demo-nav" class="demolayout">
            <li><a class="active" href="tab1">更多信息</a></li>
            <li><a class="" href="tab2">同类商品</a></li>
        </ul>
        <div class="tabs-container">
            <div style="display: block;" class="tab" id="tab1">
                <p class="more_details">
                    <asp:Label ID="GoodsDescribe" runat="server" />
                </p>
            </div>
            <div style="display: none;" class="tab" id="tab2">
                <asp:Repeater runat="server" ID="SameCategory">
                    <ItemTemplate>
                        <div class="new_prod_box">
                            <a href="Details.aspx?GoodsID=<%#Eval("goodsID")%>">
                                <%#Eval("goodsName")%>
                            </a>
                            <div class="new_prod_bg">
                                <a href="Details.aspx?GoodsID=<%#Eval("goodsID")%>">
                                    <img src="<%#Eval("goodsImg")%>" alt="<%#Eval("goodsName")%>" title="" height="100px"
                                        width="112px" class="thumb" />
                                </a>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <div class="clear">
                </div>
            </div>
        </div>
    </div>
    <div class="clear">
    </div>
</asp:Content>
