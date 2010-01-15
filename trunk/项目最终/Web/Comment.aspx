<%@ Page Language="C#" MasterPageFile="~/IndexMaster.master" AutoEventWireup="true" CodeFile="Comment.aspx.cs" Inherits="Comment" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentHolder" Runat="Server">
      <div class="title">
        <span class="title_icon">
            <img src="images/bullet1.gif" alt="" title="" /></span>
        <asp:Label ID="GoodsName" runat="server" />评论&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblBack" runat="server" Text=""></asp:Label>
      </div>
          <asp:GridView ID="GridViewComment" runat="server" Width="432px" AutoGenerateColumns="False" BorderStyle="None" AllowPaging="True" OnPageIndexChanging="GridViewComment_PageIndexChanging" PageSize="5">
                        <Columns>
                            <asp:TemplateField AccessibleHeaderText="false" ShowHeader="False">
                                <ItemTemplate>
                                <div class="feat_prod_box_details" style="width:430px">
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
</asp:Content>

