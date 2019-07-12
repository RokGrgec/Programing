<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Dijabetes__.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
</head>
<body>
    <form id="form1" runat="server">
        <div>

        
            Register Page<br />
            <br />
            Name:&nbsp;
            <asp:TextBox ID="nametxt" runat="server"></asp:TextBox>
            <br />
            <br />
            Email:&nbsp;
            <asp:TextBox ID="emailtxt" runat="server"></asp:TextBox>
            <br />
            <br />
            Password:&nbsp;
            <asp:TextBox ID="passtxt" runat="server"></asp:TextBox>
            <br />
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Register" />

        
        </div>
    </form>
</body>
</html>
