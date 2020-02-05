<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Dijabetes__.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
           
            <asp:Label ID="Label1" runat="server" Text="Login Page"></asp:Label>
            <br />
            <br />
            <br />
            UserName
            <asp:TextBox ID="nametxt" runat="server"></asp:TextBox>
            <br />
            <br />
            Password&nbsp;
            <asp:TextBox ID="passtxt" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Login" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label2" runat="server"></asp:Label>
           
        </div>
    </form>
</body>
</html>
