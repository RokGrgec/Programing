<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginRedirect.aspx.cs" Inherits="Dijabetes.LoginRedirect" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <div>
            Hello,
            <asp:Label ID="usernametxt" runat="server"></asp:Label>
            !&nbsp;&nbsp;&nbsp;
            <asp:Button ID="LogOutBtn" runat="server" OnClick="LogOutBtn_Click" Text="LogOut" />
            <br />
            <br />
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="Surname" HeaderText="Surname" SortExpression="Surname" />
                    <asp:BoundField DataField="DateOfBirth" HeaderText="DateOfBirth" SortExpression="DateOfBirth" />
                    <asp:BoundField DataField="Height" HeaderText="Height" SortExpression="Height" />
                    <asp:BoundField DataField="Weight" HeaderText="Weight" SortExpression="Weight" />
                    <asp:BoundField DataField="Activity" HeaderText="Activity" SortExpression="Activity" />
                    <asp:BoundField DataField="DiaType" HeaderText="DiaType" SortExpression="DiaType" />
                    <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                    <asp:BoundField DataField="Gender" HeaderText="Gender" SortExpression="Gender" />
                    <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username" />
                    <asp:BoundField DataField="Password" HeaderText="Password" SortExpression="Password" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [User]"></asp:SqlDataSource>
            <br />
            <asp:Button ID="Exportbtn" runat="server" OnClick="Exportbtn_Click" Text="Export To CSV" />
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="MeasuringUnitsbtn_Click" Text="Measuring Units" />
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" OnClick="Goodbtn_Click" Text="Good" />
            <br />
            <br />
            <asp:Button ID="Button3" runat="server" OnClick="Mealsbtn_Click" Text="Meals" />
            <br />
            <asp:Button ID="Button4" runat="server" OnClick="MealCombbtn_Click" Text="MealComb" />

        </div>
    </form>
</body>
</html>
