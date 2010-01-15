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
                    <strong>库存:</strong> <span class="red">
                        <asp:Label ID="Storage" runat="server" /></span></div>
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
            <li><a class="active" href="tab1">商品评价</a></li>
            <li><a class="" href="tab2">我要评论</a></li>
            <li><a class="" href="tab3">同类商品</a></li></ul>
        <div class="tabs-container">
            <div style="display: block;" class="tab" id="tab1">
                <p class="more_details">
                    <asp:Label ID="GoodsDescribe" runat="server" />
                </p>
                <p class="more_details">
                    <asp:Panel ID="PanelSuccess" runat="server">
                    <table style="width: 354px">
                        <tr>
                            <td colspan="3">
                                本品已售出<asp:Label ID="lblSold" runat="server" style="color: #a81f22"></asp:Label>份
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                共有<asp:Label ID="lblCommentAcount" runat="server" style="color: #a81f22"></asp:Label>用户给与评价
                            </td>
                        </tr>
                        <tr>
                            <td>
                                喜欢：
                            </td>
                            <td style="width: 210px;">
                                <asp:Image ID="ImageGood" runat="server" ImageUrl="images/az_voteline.gif" Width="0px" Height = "13px"  BorderColor="#ffcc66"/>
                                <asp:Image ID="ImageGoodD" runat="server" ImageUrl="images/az_defultline.gif" Width="0px" Height = "13px" BorderColor="#ffefc3"/>
                            </td>
                            <td>
                                <asp:Label ID="lblGood" runat="server" style="color: #a81f22"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                一般：
                            </td>
                            <td style="width: 210px;">
                                <asp:Image ID="ImageMid" runat="server" ImageUrl="images/az_voteline.gif" Width="0px" Height = "13px" BorderWidth="0" BorderColor="#ffcc66"/>
                                <asp:Image ID="ImageMidD" runat="server" ImageUrl="images/az_defultline.gif" Width="0px" Height = "13px" BorderWidth="0" BorderColor="#ffefc3"/>
                            </td>
                            <td>
                                <asp:Label ID="lblNormal" runat="server" style="color: #a81f22"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                讨厌：
                            </td>
                            <td style="width: 210px;">
                                <asp:Image ID="ImageBad" runat="server" ImageUrl="images/az_voteline.gif" Width="0px" Height = "13px" BorderWidth="0" BorderColor="#ffcc66"/>
                                <asp:Image ID="ImageBadD" runat="server" ImageUrl="images/az_defultline.gif" Width="0px" Height = "13px" BorderWidth="0" BorderColor="#ffefc3"/>
                            </td>
                            <td>
                                <asp:Label ID="lblbad" runat="server" style="color: #a81f22"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <hr style="border-style:double; border-color:Silver;" />
                    <div class="title">最新评论</div>
                    <asp:Button ID="btnMore" runat="server" Text="更多评论" CssClass="register" OnClick="btnMore_Click"/>
                    <asp:GridView ID="GridViewComment" runat="server" Width="432px" AutoGenerateColumns="False" BorderStyle="None">
                        <Columns>
                            <asp:TemplateField AccessibleHeaderText="false" ShowHeader="False">
                                <ItemTemplate>
                                <div class="feat_prod_box_details" style="width:420px;">
                                        <div class="prod_comment">
                                        <div class="box_top_small"></div>
                                            <div class="box_center_small">
                                                    <div class="prod_title">
                                                        <asp:Label ID="lblUserLv" runat="server" Text="<%#Bind('UserLevel')%>" />
                                                    </div>
                                                    <p class="details"></p>
                                                    <div class="prod_title">
                                                        <asp:Label ID="lblUserName" runat="server" Text="<%#Bind('UserName')%>" />
                                                    </div>
                                                    <p class="details"></p>
                                                    <div class="prod_title">
                                                        积分:<asp:Label ID="Label1" runat="server" Text="<%#Bind('UserScore')%>" />
                                                    </div>
                                            </div>
                                            <div class="box_bottom_small" style="width:90px;"></div>
                                        </div>
                                        <div class="prod_det_box">
                                            <div class="box_top"></div>
                                            <div class="box_center">
                                                <div class="prod_title">
                                                    用户印象:<asp:Label ID="lblComLv" runat="server" Text="<%#Bind('CommentLv')%>" />
                                                </div>
                                                <p class="details">
                                                    <asp:Literal ID="LiteralComment" runat="server" Text="<%#Bind('GoodsCom')%>"></asp:Literal>
                                                </p>
                                                <p class="details" style="text-align:right;">
                                                        评论时间:<asp:Label ID="lblComTime" runat="server" Text="<%#Bind('CommentTime')%>" />
                                                </p>
                                                <div class="clear"></div>
                                            </div>
                                            <div class="box_bottom">
                                            </div>
                                        </div>
                                            <div class="clear">
                                            </div>
                                </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    </asp:Panel>
                    <asp:Panel ID="PanelFail" runat="server">
                        <ul class="list">
                            <li><a href="#">目前无评论信息或获取数据错误</a></li>                                        
                        </ul>
                    </asp:Panel>
                </p>
            </div>
            <div style="display:none;" class="tab" id="tab2">
                <asp:Panel ID="PanelAnonymous" runat="server">
                    <ul class="list">
                        <li><a href="MyAccount.aspx">您还没有登陆</a></li>                                        
                    </ul>
                </asp:Panel>
                <asp:Panel ID="PanelLoggedin" runat="server">
                    <div class="contact_form">
                        <div class="form_subtitle"><asp:Label ID="lblUserName" runat="server" Text="Label"></asp:Label></div>
                        <div class="form_row">
                            <label class="contact"><strong>您的评价:</strong></label>
                            <asp:RadioButtonList ID="rblCommentLv" runat="server" RepeatDirection="Horizontal" Width="236px">
                                <asp:ListItem Value="0">我不喜欢</asp:ListItem>
                                <asp:ListItem Value="1">感觉一般</asp:ListItem>
                                <asp:ListItem Value="2" Selected="True">我很喜欢</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                        <div class="form_row">
                            <asp:TextBox ID="txtComment" runat="server" Height="114px" TextMode="MultiLine" Width="320px"></asp:TextBox>
                        </div>
                        <div class="form_row">
                            (250字以内)
                            <asp:Button ID="btnSubmit" runat="server" Text="提交" CssClass="register" OnClick="btnSubmit_Click"/>
                        </div>
                    </div>
                    <p class="more_details"></p>
                    <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
                    <p class="more_details"></p>
                </asp:Panel>
            </div>
            <div style="display: none;" class="tab" id="tab3">
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