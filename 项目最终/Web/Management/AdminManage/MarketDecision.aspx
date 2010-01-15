<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MarketDecision.aspx.cs" Inherits="Default2"%>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>市场决策</title>
</head>
<body>
    <form id="form1" runat="server" >

    <div>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp;
        <table style="width: 198px">
            <tr>
                <td style="height: 33px">
        <asp:Panel ID="ConditionPan" runat="server"  Width="281px" GroupingText="请选择调查重点" Height="1px">
            &nbsp;<table>
            <tr>
                <td style="width: 85px; height: 16px;">
        <asp:DropDownList ID="Condition" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            <asp:ListItem Selected="True" Value="-1">请选择</asp:ListItem>
            <asp:ListItem Value="0">会员数</asp:ListItem>
            <asp:ListItem Value="1">各用户群消费额</asp:ListItem>
            <asp:ListItem Value="2">各类商品消费额</asp:ListItem>
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
                <asp:ListItem Value="1" Selected="True">1组</asp:ListItem>
                <asp:ListItem Value="2">2组</asp:ListItem>
                <asp:ListItem Value="3">3组</asp:ListItem>
                <asp:ListItem Value="4">4组</asp:ListItem>
            </asp:DropDownList>&nbsp;<br />
            <br />
            <asp:Panel ID="line1" runat="server" Height="25px" Width="230px" >
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbx11"
                    Display="Dynamic" ErrorMessage="起始年龄不能为空" Height="15px" Width="4px">*</asp:RequiredFieldValidator>
                <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="tbx11"
                    Display="Dynamic" ErrorMessage="年龄应是1到100之间则整数" MaximumValue="100" MinimumValue="1"
                    Type="Integer">*</asp:RangeValidator>
                <asp:TextBox ID="tbx11" runat="server" Width="43px"></asp:TextBox>岁到<asp:RequiredFieldValidator
                    ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbx12" Display="Dynamic"
                    ErrorMessage="截止年龄不能为空" >*</asp:RequiredFieldValidator>
                <asp:RangeValidator ID="RangeValidator5" runat="server" ControlToValidate="tbx12"
                    Display="Dynamic" ErrorMessage="年龄应是1到100之间则整数" MaximumValue="100" MinimumValue="1" Type="Integer" >*</asp:RangeValidator>
                <asp:TextBox ID="tbx12"
                    runat="server" Width="37px"></asp:TextBox>岁<asp:CompareValidator ID="CompareValidator1"
                        runat="server" ControlToCompare="tbx12" ControlToValidate="tbx11" Display="Dynamic"
                        ErrorMessage="起始年龄不应大于截止年龄" Operator="LessThanEqual" >*</asp:CompareValidator>
            </asp:Panel>
            <asp:Panel ID="line2" runat="server" Height="25px" Width="230px" >
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbx21"
                    Display="Dynamic" ErrorMessage="起始年龄不能为空" >*</asp:RequiredFieldValidator>
                <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="tbx21"
                    Display="Dynamic" ErrorMessage="年龄应是1到100之间则整数" MaximumValue="100" MinimumValue="1"
                    Type="Integer" >*</asp:RangeValidator>
                <asp:TextBox ID="tbx21" runat="server" Width="43px"></asp:TextBox>岁到<asp:RequiredFieldValidator
                    ID="RequiredFieldValidator4" runat="server" ControlToValidate="tbx22" Display="Dynamic"
                    ErrorMessage="截止年龄不能为空" >*</asp:RequiredFieldValidator>
                <asp:RangeValidator ID="RangeValidator6" runat="server" ControlToValidate="tbx22"
                    Display="Dynamic" ErrorMessage="年龄应是1到100之间则整数" MaximumValue="100" MinimumValue="1" Type="Integer" >*</asp:RangeValidator>
                <asp:TextBox ID="tbx22"
                    runat="server" Width="37px"></asp:TextBox>岁<asp:CompareValidator ID="CompareValidator2"
                        runat="server" ControlToCompare="tbx22" ControlToValidate="tbx21" Display="Dynamic"
                        ErrorMessage="起始年龄不应大于截止年龄" Operator="LessThanEqual" >*</asp:CompareValidator>
                <asp:CompareValidator ID="CompareValidator5" runat="server" ControlToCompare="tbx12"
                    ControlToValidate="tbx21" Display="Dynamic" ErrorMessage="年龄段之间不应有重叠" Operator="GreaterThan"
                    >*</asp:CompareValidator></asp:Panel>
            <asp:Panel ID="line3" runat="server" Height="25px" Width="230px" >
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="tbx31"
                    Display="Dynamic" ErrorMessage="起始年龄不能为空" >*</asp:RequiredFieldValidator>
                <asp:RangeValidator ID="RangeValidator3" runat="server" ControlToValidate="tbx31"
                    Display="Dynamic" ErrorMessage="年龄应是1到100之间则整数" MaximumValue="100" MinimumValue="1"
                    Type="Integer" >*</asp:RangeValidator>
                <asp:TextBox ID="tbx31" runat="server" Width="43px"></asp:TextBox>岁到<asp:RequiredFieldValidator
                    ID="RequiredFieldValidator7" runat="server" ControlToValidate="tbx32" Display="Dynamic"
                    ErrorMessage="截止年龄不能为空" >*</asp:RequiredFieldValidator>
                <asp:RangeValidator ID="RangeValidator7" runat="server" ControlToValidate="tbx32"
                    Display="Dynamic" ErrorMessage="年龄应是1到100之间则整数" MaximumValue="100" MinimumValue="1" Type="Integer" >*</asp:RangeValidator>
                <asp:TextBox ID="tbx32"
                    runat="server" Width="37px"></asp:TextBox>岁<asp:CompareValidator ID="CompareValidator3"
                        runat="server" ControlToCompare="tbx32" ControlToValidate="tbx31" Display="Dynamic"
                        ErrorMessage="起始年龄不应大于截止年龄" Operator="LessThanEqual" >*</asp:CompareValidator>
                <asp:CompareValidator ID="CompareValidator6" runat="server" ControlToCompare="tbx22"
                    ControlToValidate="tbx31" Display="Dynamic" ErrorMessage="年龄段之间不应有重叠" Operator="GreaterThan"
                    >*</asp:CompareValidator></asp:Panel>
            <asp:Panel ID="line4" runat="server" Height="25px" Width="230px" >
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="tbx41"
                    Display="Dynamic" ErrorMessage="起始年龄不能为空" >*</asp:RequiredFieldValidator>
                <asp:RangeValidator ID="RangeValidator4" runat="server" ControlToValidate="tbx41"
                    Display="Dynamic" ErrorMessage="年龄应是1到100之间则整数" MaximumValue="100" MinimumValue="1"
                    Type="Integer" >*</asp:RangeValidator>
                <asp:TextBox ID="tbx41" runat="server" Width="43px"></asp:TextBox>岁到<asp:RequiredFieldValidator
                    ID="RequiredFieldValidator8" runat="server" ControlToValidate="tbx42" Display="Dynamic"
                    ErrorMessage="截止年龄不能为空" >*</asp:RequiredFieldValidator>
                <asp:RangeValidator ID="RangeValidator8" runat="server" ControlToValidate="tbx42"
                    Display="Dynamic" ErrorMessage="年龄应是1到100之间则整数" MaximumValue="100" MinimumValue="1" Type="Integer" >*</asp:RangeValidator>
                <asp:TextBox
                    ID="tbx42" runat="server" Width="37px"></asp:TextBox>岁<asp:CompareValidator ID="CompareValidator4"
                        runat="server" ControlToCompare="tbx42" ControlToValidate="tbx41" Display="Dynamic"
                        ErrorMessage="起始年龄不应大于截止年龄" Operator="LessThanEqual" >*</asp:CompareValidator>
                <asp:CompareValidator ID="CompareValidator7" runat="server" ControlToCompare="tbx32"
                    ControlToValidate="tbx41" Display="Dynamic" ErrorMessage="年龄段之间不应有重叠" Operator="GreaterThan">*</asp:CompareValidator></asp:Panel>
            </asp:Panel>
        <asp:Panel ID="TimeGapPan" runat="server" Height="95px" Width="281px" GroupingText="请选择时间段" Direction="LeftToRight">
            <table style="width: 158px">
                <tr>
                    <td>
            <asp:Panel ID="Panel1" runat="server" Height="50px" Width="200px" GroupingText="起始日期">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="tbxStrartingYear"
                    Display="Dynamic" ErrorMessage="时间段信息不能为空">*</asp:RequiredFieldValidator>
                <asp:RangeValidator ID="sYearRangeVali" runat="server" ControlToValidate="tbxStrartingYear"
                    Display="Dynamic" Type="Integer">*</asp:RangeValidator>
                <asp:TextBox ID="tbxStrartingYear" runat="server" Width="45px"></asp:TextBox>&nbsp;
                年<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="tbxStartingMonth"
                    Display="Dynamic" ErrorMessage="时间段信息不能为空">*</asp:RequiredFieldValidator>
                <asp:RangeValidator ID="sMonthRangeVali" runat="server" ControlToValidate="tbxStartingMonth"
                    Display="Dynamic" ErrorMessage="RangeValidator" Type="Integer" MaximumValue="12" MinimumValue="1">*</asp:RangeValidator>
                <asp:TextBox ID="tbxStartingMonth" runat="server" Width="25px"></asp:TextBox>月</asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td>
            <asp:Panel ID="Panel2" runat="server" Height="50px" Width="200px" GroupingText="终止日期">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="tbxEndingYear"
                    Display="Dynamic" ErrorMessage="时间段信息不能为空">*</asp:RequiredFieldValidator>
                <asp:RangeValidator ID="eYearRangeVali" runat="server" ControlToValidate="tbxEndingYear"
                    Display="Dynamic" Type="Integer">*</asp:RangeValidator>
                <asp:TextBox ID="tbxEndingYear" runat="server" Width="45px"></asp:TextBox>
                年
                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="tbxEndingMonth"
                    Display="Dynamic" ErrorMessage="时间段信息不能为空">*</asp:RequiredFieldValidator>
                <asp:RangeValidator ID="eMonthRangeVali" runat="server" ControlToValidate="tbxEndingMonth"
                    Display="Dynamic" ErrorMessage="RangeValidator" Type="Integer" MaximumValue="12" MinimumValue="1">*</asp:RangeValidator>
                <asp:TextBox ID="tbxEndingMonth" runat="server" Width="25px"></asp:TextBox>月
                </asp:Panel>
                    </td>
                </tr>
            </table>
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;</asp:Panel>
                    </td>
                <td align="left" valign="top" style="width: 3px; height: 33px;">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" BorderStyle="None" Width="290px" />
                    &nbsp;
                </td>
            </tr>
        </table>
        &nbsp; &nbsp; &nbsp;&nbsp;
    </div>
    </form>
</body>
</html>
