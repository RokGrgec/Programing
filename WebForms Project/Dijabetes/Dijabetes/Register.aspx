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
            <br />
            Email:&nbsp;
            <asp:TextBox ID="emailtxt" runat="server"></asp:TextBox>
            &nbsp;<asp:Label ID="NotUniqueEmail" runat="server"></asp:Label>
            <br />
            <br />
            <br />
            Password:&nbsp;
            <asp:TextBox ID="passtxt" runat="server"></asp:TextBox>
            <br />
            <br />
            <br />
            Diabetes Type:&nbsp; 
             <asp:RadioButtonList runat="server" OnSelectedIndexChanged="Unnamed1_SelectedIndexChanged">
                 <asp:ListItem Text="Type 1" ID="RbtnType1" />
                 <asp:ListItem Text="Type 2" ID="RbtnType2" />
             </asp:RadioButtonList>
            <br />
            Activity:&nbsp; 
            <asp:RadioButtonList runat="server" OnSelectedIndexChanged="Unnamed1_SelectedIndexChanged">
                <asp:ListItem Text="Rarely" ID="RbtnActivity1" />
                <asp:ListItem Text="Occasionally" ID="RbtnActivity2" />
                <asp:ListItem Text="Frequently" ID="RbtnActivity3" />
            </asp:RadioButtonList>
            <br />
            Gender:
            <asp:RadioButtonList runat="server" OnSelectedIndexChanged="Unnamed1_SelectedIndexChanged">
                <asp:ListItem Text="Male" ID="RbtnGender1" /> <asp:ListItem Text="Female" ID="RbtnGender2" />
            </asp:RadioButtonList>
            <br />
            Age:
            <asp:TextBox ID="agetxt" runat="server"></asp:TextBox>
            <br />
            <br />
            Height(cm):
            <asp:TextBox ID="heighttxt" runat="server"></asp:TextBox>
            <br />
            <br />
            Weight(kg): <asp:TextBox ID="weighttxt" runat="server"></asp:TextBox>
            <br />
        &nbsp;<br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Register" />

        </div>
    </form>
</body>
</html>
