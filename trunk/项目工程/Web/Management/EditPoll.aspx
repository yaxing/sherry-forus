<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditPoll.aspx.cs" Inherits="Management_EditPoll" %>
<%@ Import Namespace="System.Data" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="gvVote" runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="gvVote_RowCancelingEdit" OnRowDeleting="gvVote_RowDeleting" OnRowEditing="gvVote_RowEditing" OnRowDataBound="gvVote_RowDataBound" OnRowUpdating="gvVote_RowUpdating">
            <Columns>
                <asp:BoundField DataField="mainPollID" HeaderText="编号" ReadOnly="True" />
                <asp:TemplateField HeaderText="标题">
                    <EditItemTemplate>
                        <table>
                        <tr>
                            <td>调查主题：</td>
                            <td align="left"><asp:TextBox ID="tbTitle" runat="server" Width="300px" Text='<%# ((DataRowView)Container.DataItem)["Topic"] %>'></asp:TextBox>
                            <asp:RequiredFieldValidator
                                    ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" Display="Dynamic" ControlToValidate="tbTitle"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td>选项总数：</td>
                            <td align="left">
                                <asp:DropDownList ID="ddlOpCount" runat="server" AutoPostBack="True">
                                    <asp:ListItem>2</asp:ListItem>
                                    <asp:ListItem>3</asp:ListItem>
                                    <asp:ListItem>4</asp:ListItem>
                                    <asp:ListItem>5</asp:ListItem>
                                    <asp:ListItem>6</asp:ListItem>
                                    <asp:ListItem>7</asp:ListItem>
                                    <asp:ListItem>8</asp:ListItem>
                                    <asp:ListItem>9</asp:ListItem>
                                    <asp:ListItem>10</asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:PlaceHolder ID="phOptions" runat="server"></asp:PlaceHolder>
                            </td>
                        </tr>
                        <tr>
                            <td>选择模式：</td>
                            <td align="left">
                                <asp:RadioButtonList ID="rblSelectPattern" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem>单选</asp:ListItem>
                                    <asp:ListItem>多选</asp:ListItem>
                                </asp:RadioButtonList></td>
                        </tr>
                        <tr>
                            <td>图形格式：</td>
                            <td align="left">
                                <asp:RadioButtonList ID="rblPicStyle" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem>柱状图</asp:ListItem>
                                    <asp:ListItem>饼状图</asp:ListItem>
                                </asp:RadioButtonList></td>
                        </tr>
                    </table>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbTitle" runat="server" Text='<%# ((DataRowView)Container.DataItem)["Topic"] %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField HeaderText="编辑" ShowEditButton="True" />
                <asp:TemplateField HeaderText="删除">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="delete" OnClientClick="return confirm('确定删除吗？')">删除</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>