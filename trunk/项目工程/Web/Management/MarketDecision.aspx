<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MarketDecision.aspx.cs" Inherits="Default2" MasterPageFile="~/IndexMaster.master" %>



<asp:Content ContentPlaceHolderID="contentHolder" ID="one" runat="server">
    <div>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
        <asp:Panel ID="ConditionPan" runat="server"  Width="281px" GroupingText="请选择调查重点" Height="1px">
            &nbsp;<table>
            <tr>
                <td style="width: 85px; height: 16px;">
        <asp:DropDownList ID="Condition" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            <asp:ListItem Selected="True" Value="-1">Please select</asp:ListItem>
            <asp:ListItem Value="0">会员数</asp:ListItem>
            <asp:ListItem Value="1">各用户群消费额</asp:ListItem>
            <asp:ListItem Value="2">各类商品销售额</asp:ListItem>
        </asp:DropDownList></td>
                <td style="width: 69px; height: 16px">
        <asp:Button ID="Button1" runat="server" Text="生成报表" OnClick="Button1_Click1" /></td>
            </tr>
        </table>
        </asp:Panel>
        
        <asp:Panel ID="AgeGroupPan"  runat="server" Height="122px" Width="281px" GroupingText="请选择年龄段">
            &nbsp;
            <asp:Label ID="Label1" runat="server" Text="请选择分组数"></asp:Label>
            <asp:DropDownList ID="drpAgeGapNum" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                <asp:ListItem Value="-1">请选择</asp:ListItem>
                <asp:ListItem Value="1">1组</asp:ListItem>
                <asp:ListItem Value="2">2组</asp:ListItem>
                <asp:ListItem Value="3">3组</asp:ListItem>
                <asp:ListItem Value="4">4组</asp:ListItem>
            </asp:DropDownList>&nbsp;<br />
            <br />
            <asp:Panel ID="line1" runat="server" Height="25px" Width="172px" >
                <asp:TextBox ID="tbx11" runat="server" Width="43px"></asp:TextBox>岁到<asp:TextBox ID="tbx12"
                    runat="server" Width="37px"></asp:TextBox>岁</asp:Panel>
            <asp:Panel ID="line2" runat="server" Height="25px" Width="172px" >
                <asp:TextBox ID="tbx21" runat="server" Width="43px"></asp:TextBox>岁到<asp:TextBox ID="tbx22"
                    runat="server" Width="37px"></asp:TextBox>岁</asp:Panel>
            <asp:Panel ID="line3" runat="server" Height="25px" Width="172px" >
                <asp:TextBox ID="tbx31" runat="server" Width="43px"></asp:TextBox>岁到<asp:TextBox ID="tbx32"
                    runat="server" Width="37px"></asp:TextBox>岁</asp:Panel>
            <asp:Panel ID="line4" runat="server" Height="25px" Width="172px" >
                <asp:TextBox ID="tbx41" runat="server" Width="43px"></asp:TextBox>岁到<asp:TextBox
                    ID="tbx42" runat="server" Width="37px"></asp:TextBox>岁</asp:Panel>
            &nbsp; &nbsp;
            <br />
            </asp:Panel>
        <asp:Panel ID="TimeGapPan" runat="server" Height="95px" Width="302px" GroupingText="请选择时间段" Direction="LeftToRight">
            <table style="width: 191px">
                <tr>
                    <td style="height: 72px; width: 267px;">
            <asp:Panel ID="Panel1" runat="server" Height="50px" Width="158px" GroupingText="起始日期">
                &nbsp;<asp:TextBox ID="tbxStrartingYear" runat="server" Width="46px"></asp:TextBox>&nbsp;
                年<asp:TextBox ID="tbxStartingMonth" runat="server" Width="25px"></asp:TextBox>月</asp:Panel>
                    </td>
                    <td style="width: 935px; height: 72px;">
            <asp:Panel ID="Panel2" runat="server" Height="50px" Width="147px" GroupingText="终止日期">
                <asp:TextBox ID="tbxEndingYear" runat="server" Width="49px"></asp:TextBox>
                年<asp:TextBox ID="tbxEndingMonth" runat="server" Width="26px"></asp:TextBox>月
            </asp:Panel>
                    </td>
                </tr>
            </table>
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;</asp:Panel>
        &nbsp;
    </div>

</asp:Content>