<%@ Page Language="C#" MasterPageFile="~/IndexMaster.master" AutoEventWireup="true" CodeFile="Details.aspx.cs" Inherits="Details" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentHolder" Runat="Server">
<div style="position: relative; left: 170px; top: 50px">
        <asp:Image ID="img" runat="server" Width="200px" ImageUrl="" />
    </div>
    <div style="font-family: ΢���ź�; position: relative; left: 50px; bottom: 200px">
        <table style="width: 300px">
            <tr>
                <td>
                    <a href="#">
                        <p style="font-size: 20px">
                            ����ϣ�й���շ۵�Һ</p>
                    </a>
                </td>
            </tr>
            <tr style="height: 30px">
            </tr>
            <tr>
                <td>
                    �۸�300 Ԫ
                </td>
            </tr>
            <tr style="height: 20px">
            </tr>
            <tr>
                <td>
                    �����ġ���������Һ�� ����ϣ�й���շ۵׼����ġ���������Һ�� ����ϣ�й���շ۵׼����ġ���������Һ�� ����ϣ�й���շ۵�
                </td>
            </tr>
            <tr style="height: 50px">
            </tr>
            <tr>
                <td align="right">
                    <asp:Button ID="addToCart" runat="server" Text="���빺�ﳵ" OnClick="addToCart_Click" />
                    <asp:Button ID="showCart" runat="server" Text="��ʾ���ﳵ" OnClick="showCart_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

