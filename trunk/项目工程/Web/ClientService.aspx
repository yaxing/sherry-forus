<%@ Page Language="C#" MasterPageFile="~/IndexMaster.master" AutoEventWireup="true" CodeFile="ClientService.aspx.cs" Inherits="ClientService" %>
<%@ Import Namespace="System.Data" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentHolder" runat="Server">
    <div>
        �ͻ��ʴ�<br />
        <br />
        <asp:DataList ID="dataList" runat="server" CellPadding="2" ForeColor="#333333" >
               <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
               <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
               <AlternatingItemStyle BackColor="White" />
               <ItemStyle BackColor="#EFF3FB" />
               <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
               
                  <ItemTemplate>
                    <blockquote>
                        ���⣺<%# DataBinder.Eval(Container.DataItem,"Topic") %>
                        ����:<%# DataBinder.Eval(Container.DataItem,"Messages") %>
                        ����Ա�ظ�:<%# DataBinder.Eval(Container.DataItem,"Reply") %>
                    </blockquote>
                   </ItemTemplate>

               
           </asp:DataList>
        <table style="width: 419px; height: 104px">
            <tr>
                <td style="width: 104px; height: 32px">
                    ���⣺<br />
        <asp:TextBox ID="Topic" runat="server" ></asp:TextBox></td>
                <td style="width: 245px; height: 32px">
                </td>
            </tr>
            <tr>
                <td colspan="2" style="height: 58px">
                    ���ݣ�<br />
                    <asp:TextBox ID="Message" runat="server" Width="356px" Height="46px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 74px; height: 29px">
        <asp:Button ID="Submit" runat="server" Text="�ύ" OnClick="Submit_Click" CssClass="register" /></td>
                <td style="width: 100px; height: 29px">
                    <input id="Reset" type="reset" value="���" class="register" /></td>
            </tr>
        </table>
        <br />
    </div>
</asp:Content>
