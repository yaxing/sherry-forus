<%@ Page Language="C#" MasterPageFile="~/IndexMaster.master" AutoEventWireup="true"
    CodeFile="CheckOut.aspx.cs" Inherits="CheckOut" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentHolder" runat="Server">
    <asp:Panel runat="server" ID="pAnonymous">
        <div style="position: relative; left: 220px; top: 60px;">
            <asp:Label runat="server" ID="lbAnonymous" Font-Names="微软雅黑" Font-Size="15px" Text="您还未登录，请使用页面右上角链接登录或注册>>"></asp:Label>
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="pLoggedIn">
        <div style="position: relative; width: 280px; left: 150px; border-bottom-style: solid;
            border-bottom-color: White; border-bottom-width: 2px;">
            <asp:Image runat="server" ID="imgCartPath" ImageUrl="images/cartPath2.jpg" />
        </div>
        <asp:Panel runat="server" ID="pAddChange">
            <div style="position: relative; left: 300px; top: 30px; height: 320px">
                <table style="font-family: 微软雅黑">
                    <tr>
                        <td style="width: 150px">
                            <asp:Label runat="server" ID="lbTitleNewName" Text="收货人姓名：" />
                        </td>
                        <td style="width: 200px">
                            <asp:TextBox runat="server" ID="tbNewName" Text="" />
                        </td>
                    </tr>
                    <tr style="height: 10px">
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" ID="lbTitleNewAdd" Text="收货人地址：" />
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="tbNewAdd" Text="" />
                        </td>
                    </tr>
                    <tr style="height: 10px">
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" ID="lbTitleNewZip" Text="邮编：" />
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="tbNewZip" Text="" />
                        </td>
                    </tr>
                    <tr style="height: 10px">
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" ID="lbTitleNewTel" Text="联系电话：" />
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="tbNewTel" Text="" />
                        </td>
                    </tr>
                    <tr style="height: 20px">
                    </tr>
                </table>
                <table>
                    <tr>
                        <td align="right" style="width: 230px; border-bottom-style: dotted; border-bottom-color: White;
                            border-bottom-width: 1px">
                            <asp:ImageButton ID="imgbCancelChange" runat="server" Width="35px" ImageUrl="images/cancel.jpg"
                                OnClick="imgbCancelChange_Click" />
                        </td>
                        <td style="width: 5px; border-bottom-style: dotted; border-bottom-color: White; border-bottom-width: 1px">
                        </td>
                        <td align="right" style="border-bottom-style: dotted; border-bottom-color: White;
                            border-bottom-width: 1px">
                            <asp:ImageButton ID="imgbSaveAddChange" runat="server" Width="70px" ImageUrl="images/saveChange.jpg"
                                OnClick="imgbSaveAddChange_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </asp:Panel>
        <asp:Panel runat="server" ID="pPayChange" Font-Names="微软雅黑">
            <div style="position: relative; left: 150px; top: 20px; width: 560px; border-bottom-style: dotted;
                border-bottom-width: 1px; border-bottom-color: White">
                <table>
                    <tr>
                        <td style="width: 200px">
                            <asp:Label Font-Bold="true" Text="请选择您的支付方式：" ID="lbChosePay" runat="server" Height="20px" />
                            <asp:RadioButtonList ID="rblPayMethods" runat="server" CellSpacing="10" RepeatLayout="Table">
                                <asp:ListItem Value="1" Text="网上银行" Selected="True"/>
                                <asp:ListItem Value="2" Text="银行/邮局汇款" />
                                <asp:ListItem Value="3" Text="货到付款" />
                            </asp:RadioButtonList>
                        </td>
                        <td style="width: 10px; border-left-style: dotted; border-left-color: White; border-left-width: 1px">
                        </td>
                        <td>
                            <p style="font-weight: bold">
                                注：</p>
                            <p>
                                请在汇款人简短留言中注明您的订单号/用户名(非常重要)。收款时间一般为款汇出后的3-5个工作日。</p>
                            <p>
                                由于全国邮政系统升级，某些城市的邮局使用新的汇款单。请选择新汇款单中的商务汇款，填写110000858作为收款人的帐号。</p>
                            <p>
                                请在汇款完毕后将汇款单/凭证传真至本公司</p>
                        </td>
                    </tr>
                </table>
            </div>
            <div style="position: relative; left: 150px; top: 30px">
                <table style="width: 560px">
                    <tr>
                        <td style="width: 150px; font-weight: bold">
                            SHERRY公司银行信息
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                    </tr>
                    <tr>
                        <td>
                            分行：
                        </td>
                        <td>
                            中国农业银行北京永安里支行
                        </td>
                    </tr>
                    <tr>
                        <td>
                            银行帐号：
                        </td>
                        <td>
                            0425 0104 0004 787
                        </td>
                    </tr>
                    <tr style="height: 15px">
                    </tr>
                    <tr>
                        <td style="font-weight: bold">
                            SHERRY电汇地址
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                    </tr>
                    <tr>
                        <td>
                            收款人：
                        </td>
                        <td>
                            北京SHERRY化妆品有限责任公司
                        </td>
                    </tr>
                    <tr>
                        <td>
                            SWIFT代码：
                        </td>
                        <td>
                            ICBKCNBJBJM
                        </td>
                    </tr>
                    <tr>
                        <td>
                            银行名称：
                        </td>
                        <td>
                            中国建设银行北京光华支行
                        </td>
                    </tr>
                    <tr>
                        <td>
                            银行地址：
                        </td>
                        <td>
                            北京市朝阳区建国门外大街12号，邮编：100022
                        </td>
                    </tr>
                    <tr>
                        <td style="border-bottom-style: dotted; border-bottom-width: 1px; border-bottom-color: White">
                            公司地址：
                        </td>
                        <td style="border-bottom-style: dotted; border-bottom-width: 1px; border-bottom-color: White">
                            北京市朝阳区建国门外大街12号永安东里华彬国际大厦19层，邮编：100022
                        </td>
                    </tr>
                </table>
                <table>
                    <tr style="height: 15px">
                    </tr>
                    <tr>
                        <td style="width: 425px" align="right">
                            <asp:ImageButton ID="imgbCancelPayChange" Width="35px" runat="server" ImageUrl="images/cancel.jpg"
                                OnClick="imgbCancelChange_Click" />
                        </td>
                        <td style="width: 5px">
                        </td>
                        <td>
                            <asp:ImageButton ID="imgbSavePay" Width="70px" runat="server" ImageUrl="images/saveChange.jpg"
                                OnClick="imgbSavePay_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </asp:Panel>
        <asp:Panel runat="server" ID="pShippingConfirm">
            <div style="position: relative; left: 300px; top: 30px; height: 320px">
                <table style="font-family: 微软雅黑">
                    <tr>
                        <td style="width: 100px">
                            <asp:Label runat="server" ID="lbTitleName" Text="收货人姓名：" />
                        </td>
                        <td style="width: 230px">
                            <asp:Label runat="server" ID="lbName" Text="" />
                        </td>
                    </tr>
                    <tr style="height: 10px">
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" ID="lbTitleAdd" Text="收货人地址：" />
                        </td>
                        <td>
                            <asp:Label runat="server" ID="lbAdd" Text="" />
                        </td>
                    </tr>
                    <tr style="height: 10px">
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" ID="lbTitleZip" Text="邮编：" />
                        </td>
                        <td>
                            <asp:Label runat="server" ID="lbZip" Text="" />
                        </td>
                    </tr>
                    <tr style="height: 10px">
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" ID="lbTitleTel" Text="联系电话：" />
                        </td>
                        <td>
                            <asp:Label runat="server" ID="lbTel" Text="" />
                        </td>
                    </tr>
                    <tr style="height: 20px">
                    </tr>
                    <tr>
                        <td align="center" style="border-bottom-style: dotted; border-bottom-color: White;
                            border-bottom-width: 1px">
                        </td>
                        <td align="right" style="border-bottom-style: dotted; border-bottom-color: White;
                            border-bottom-width: 1px">
                            <asp:ImageButton ID="imgbAddNew" runat="server" Width="35px" ImageUrl="images/change.jpg"
                                OnClick="imgbAddNew_Click" />
                        </td>
                    </tr>
                    <tr style="height: 10px">
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" ID="lbTitlePay" Text="付款方式：" />
                        </td>
                        <td>
                            <asp:Label runat="server" ID="lbPay" Text="" />
                        </td>
                    </tr>
                    <tr style="height: 20px">
                    </tr>
                    <tr>
                        <td align="center" style="border-bottom-style: dotted; border-bottom-color: White;
                            border-bottom-width: 1px">
                        </td>
                        <td align="right" style="border-bottom-style: dotted; border-bottom-color: White;
                            border-bottom-width: 1px">
                            <asp:ImageButton ID="imgbPayNew" runat="server" Width="35px" ImageUrl="images/change.jpg"
                                OnClick="imgbPayNew_Click" />
                        </td>
                    </tr>
                    <tr style="height: 10px">
                    </tr>
                    <tr>
                        <td>
                            <asp:CheckBox ID="cbInvoice" runat="server" Text="是否需要发票？" />
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" ID="lbTitleInvoice" Text="发票抬头：" />
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="tbInvoiceHead" Text="" />
                        </td>
                    </tr>
                    <tr style="height: 10px">
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" ID="lbTitleInvoiceC" Text="发票内容：" />
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="tbInvoiceContent" Text="化妆品" />
                        </td>
                    </tr>
                </table>
                <table>
                    <tr style="height: 15px;">
                        <td style=" width:270px;  border-bottom-style: dotted; border-bottom-color: White;
                        border-bottom-width: 1px">
                        </td>
                        <td style=" border-bottom-style: dotted; border-bottom-color: White;
                        border-bottom-width: 1px">
                        </td>
                        <td style=" border-bottom-style: dotted; border-bottom-color: White;
                        border-bottom-width: 1px">
                        </td>                        
                    </tr>
                    <tr style="height:5px">
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:ImageButton ID="imgbBack" Width="35px" runat="server" ImageUrl="images/cancel.jpg"
                                OnClick="imgbCancelShipping_Click" />
                        </td>
                        <td style="width: 5px">
                        </td>
                        <td style="height: 19px">
                            <asp:ImageButton ID="imgbConfirm" Width="70px" runat="server" ImageUrl="images/confirm.jpg"
                                OnClick="imgbConfirm_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </asp:Panel>
        <div style="position: relative; left: 720px; bottom: 150px; width: 270px; height: 155px;
            border-style: solid; border-width: 1px; border-color: White; font-family: 微软雅黑">
            <table>
                <tr style="height: 30px">
                </tr>
                <tr>
                    <td style="width: 15px">
                    </td>
                    <td style="width: 180px; font-size: 15px">
                        订单小结：
                    </td>
                    <td style="width: 45px">
                    </td>
                </tr>
                <tr style="height: 20px">
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:Label ID="lbTotalQuantityTitle" runat="server" Text="商品总量："></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lbTotalQuantity" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr style="height: 10px">
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:Label ID="lbTotalPriceTitle" runat="server" Text="价格总计："></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lbTotalPrice" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr style="height: 15px">
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:ImageButton Width="70px" ImageUrl="images/changeItems.jpg" runat="server" ID="imgbChangeItems"
                            OnClick="imgbChangeItems_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
</asp:Content>
