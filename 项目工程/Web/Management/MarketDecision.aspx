<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MarketDecision.aspx.cs" Inherits="Default2" MasterPageFile="~/IndexMaster.master" %>



<asp:Content ContentPlaceHolderID="contentHolder" ID="one" runat="server">
    <div>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
        <asp:Panel ID="ConditionPan" runat="server"  Width="281px" GroupingText="��ѡ������ص�" Height="1px">
            &nbsp;<table>
            <tr>
                <td style="width: 85px; height: 16px;">
        <asp:DropDownList ID="Condition" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            <asp:ListItem Selected="True" Value="-1">Please select</asp:ListItem>
            <asp:ListItem Value="0">��Ա��</asp:ListItem>
            <asp:ListItem Value="1">���û�Ⱥ���Ѷ�</asp:ListItem>
            <asp:ListItem Value="2">������Ʒ���۶�</asp:ListItem>
        </asp:DropDownList></td>
                <td style="width: 69px; height: 16px">
        <asp:Button ID="Button1" runat="server" Text="���ɱ���" OnClick="Button1_Click1" /></td>
            </tr>
        </table>
        </asp:Panel>
        
        <asp:Panel ID="AgeGroupPan"  runat="server" Height="122px" Width="281px" GroupingText="��ѡ�������">
            &nbsp;
            <asp:Label ID="Label1" runat="server" Text="��ѡ�������"></asp:Label>
            <asp:DropDownList ID="drpAgeGapNum" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                <asp:ListItem Value="-1">��ѡ��</asp:ListItem>
                <asp:ListItem Value="1">1��</asp:ListItem>
                <asp:ListItem Value="2">2��</asp:ListItem>
                <asp:ListItem Value="3">3��</asp:ListItem>
                <asp:ListItem Value="4">4��</asp:ListItem>
            </asp:DropDownList>&nbsp;<br />
            <br />
            <asp:Panel ID="line1" runat="server" Height="25px" Width="172px" >
                <asp:TextBox ID="tbx11" runat="server" Width="43px"></asp:TextBox>�굽<asp:TextBox ID="tbx12"
                    runat="server" Width="37px"></asp:TextBox>��</asp:Panel>
            <asp:Panel ID="line2" runat="server" Height="25px" Width="172px" >
                <asp:TextBox ID="tbx21" runat="server" Width="43px"></asp:TextBox>�굽<asp:TextBox ID="tbx22"
                    runat="server" Width="37px"></asp:TextBox>��</asp:Panel>
            <asp:Panel ID="line3" runat="server" Height="25px" Width="172px" >
                <asp:TextBox ID="tbx31" runat="server" Width="43px"></asp:TextBox>�굽<asp:TextBox ID="tbx32"
                    runat="server" Width="37px"></asp:TextBox>��</asp:Panel>
            <asp:Panel ID="line4" runat="server" Height="25px" Width="172px" >
                <asp:TextBox ID="tbx41" runat="server" Width="43px"></asp:TextBox>�굽<asp:TextBox
                    ID="tbx42" runat="server" Width="37px"></asp:TextBox>��</asp:Panel>
            &nbsp; &nbsp;
            <br />
            </asp:Panel>
        <asp:Panel ID="TimeGapPan" runat="server" Height="95px" Width="302px" GroupingText="��ѡ��ʱ���" Direction="LeftToRight">
            <table style="width: 191px">
                <tr>
                    <td style="height: 72px; width: 267px;">
            <asp:Panel ID="Panel1" runat="server" Height="50px" Width="158px" GroupingText="��ʼ����">
                &nbsp;<asp:TextBox ID="tbxStrartingYear" runat="server" Width="46px"></asp:TextBox>&nbsp;
                ��<asp:TextBox ID="tbxStartingMonth" runat="server" Width="25px"></asp:TextBox>��</asp:Panel>
                    </td>
                    <td style="width: 935px; height: 72px;">
            <asp:Panel ID="Panel2" runat="server" Height="50px" Width="147px" GroupingText="��ֹ����">
                <asp:TextBox ID="tbxEndingYear" runat="server" Width="49px"></asp:TextBox>
                ��<asp:TextBox ID="tbxEndingMonth" runat="server" Width="26px"></asp:TextBox>��
            </asp:Panel>
                    </td>
                </tr>
            </table>
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;</asp:Panel>
        &nbsp;
    </div>

</asp:Content>