<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MeasuringUnits.aspx.cs" Inherits="Dijabetes.MeasuringUnits" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 208px;
            height: 61px;
        }
        .auto-style2 {
            width: 439px;
            height: 200px;
        }
        .auto-style3 {
            width: 246px;
            height: 61px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div id="dvGrid" style="padding: 10px; " class="auto-style2">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" 
                        DataKeyNames="Id" OnRowEditing="OnRowEditing" OnRowCancelingEdit="OnRowCancelingEdit" PageSize="5" AllowPaging="true" OnPageIndexChanging="OnPaging"
                        OnRowUpdating="OnRowUpdating" OnRowDeleting="OnRowDeleting" EmptyDataText="No records has been added."
                        Width="450">
                        <Columns>
                            <asp:TemplateField HeaderText="Name" ItemStyle-Width="150">
                                <ItemTemplate>
                                    <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtName" runat="server" Text='<%# Eval("Name") %>' Width="140"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <table border="1" cellpadding="0" cellspacing="0" style="border-collapse: collapse">
                        <tr>
                            <td class="auto-style1">Name Of New Measuring Unit: <br />
                                <asp:TextBox ID="txtName" runat="server" Width="176px" />
                            </td>
                            <td class="auto-style3">
                                <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="Insert" />
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
