<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Upload.aspx.cs" Inherits="Management_Upload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <tr bgcolor="#ffffff">
        <td height="24">
            <input type="file" id="Up_file" class="edline" runat="server" style="WIDTH: 456px; HEIGHT: 20px" size="60" name="Up_file">
        </td>
    </tr>
    <tr bgcolor="#ffffff">
        <td height="24" align="center">
            <asp:Button ID="submit" Runat="server" Text="文件上传" CssClass="Cmdbut" Height="20px" OnClick="submit_Click1"></asp:Button>
        </td>
    </tr> 

    <div>
    </div>
    </form>
</body>
</html>
