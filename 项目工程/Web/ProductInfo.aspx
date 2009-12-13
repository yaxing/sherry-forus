<%@ Page Language="C#" MasterPageFile="~/IndexMaster.master" AutoEventWireup="true"
    CodeFile="ProductInfo.aspx.cs" Inherits="ProductInfo" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentHolder" runat="Server">
<script type="text/javascript">
var s1=new Drag("person_detial");
</script>
    <div style="position: relative; left: 170px; top: 50px">
        <asp:Image ID="img" runat="server" Width="200px" ImageUrl="" />
    </div>
    <div style="font-family: 微软雅黑; position: relative; left: 400px; bottom: 200px">
        <table style="width: 300px">
            <tr>
                <td>
                    <a href="#">
                        <p style="font-size: 20px">
                            纪梵希感光皙颜粉底液</p>
                    </a>
                </td>
            </tr>
            <tr style="height: 30px">
            </tr>
            <tr>
                <td>
                    价格：300 元
                </td>
            </tr>
            <tr style="height: 20px">
            </tr>
            <tr>
                <td>
                    肌肤的“隐形修正液” 纪梵希感光皙颜粉底肌肤的“隐形修正液” 纪梵希感光皙颜粉底肌肤的“隐形修正液” 纪梵希感光皙颜粉底
                </td>
            </tr>
            <tr style="height: 50px">
            </tr>
            <tr>
                <td align="right">
                    <asp:Button ID="addToCart" runat="server" Text="加入购物车" OnClick="addToCart_Click" />
                    <asp:Button ID="showCart" runat="server" Text="显示购物车" OnClick="showCart_Click" />
                </td>
            </tr>
        </table>
    </div>
    <div id="person_detial">
        <div class="head">
            More Information about Me&nbsp;&nbsp;&nbsp;&nbsp;<a style="color: #ffffff;" href="javascript:void(0)"
                onclick="this.parentNode.parentNode.style.display='none';">关闭</a></div>
        <div id="person_content">
        </div>
    </div>
</asp:Content>

