<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Goods.aspx.cs" Inherits="Dijabetes.Goods" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 150px;
            height: 68px;
        }
        .auto-style2 {
            margin-left: 7px;
            margin-right: 8px;
        }
        .auto-style3 {
            width: 199px;
            height: 68px;
        }
        .auto-style5 {
            width: 183px;
            height: 68px;
        }
        .auto-style6 {
            width: 158px;
            height: 68px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div id="dvGrid" style="padding: 10px; width: 450px">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false"
                        DataKeyNames="Id" OnRowEditing="OnRowEditing" OnRowCancelingEdit="OnRowCancelingEdit" PageSize="5" AllowPaging="true" OnPageIndexChanging="OnPaging"
                        OnRowUpdating="OnRowUpdating" OnRowDeleting="OnRowDeleting" EmptyDataText="No records has been added."
                        Width="813px">
                        <Columns>
                            <asp:TemplateField HeaderText="Name" ItemStyle-Width="150">
                                <ItemTemplate>
                                    <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtName" runat="server" Text='<%# Eval("Name") %>' Width="140"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                         
                            <asp:TemplateField HeaderText="Energy in kcal" ItemStyle-Width="150">
                                <ItemTemplate>
                                    <asp:Label ID="lblEnergy_kcal" runat="server" Text='<%# Eval("Energy_kcal") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtEnergy_kcal" runat="server" Text='<%# Eval("Energy_kcal") %>' Width="140"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                           

                            <asp:TemplateField HeaderText="Energy in kJ" ItemStyle-Width="150">
                                <ItemTemplate>
                                    <asp:Label ID="lblEnergy_kJ" runat="server" Text='<%# Eval("Energy_kJ") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtEnergy_kJ" runat="server" Text='<%# Eval("Energy_kJ") %>' Width="140"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                           

                            <asp:TemplateField HeaderText="Type" ItemStyle-Width="150">
                                <ItemTemplate>
                                    <asp:Label ID="lblIDType" runat="server" Text='<%# Eval("IDType") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtIDType" runat="server" Text='<%# Eval("IDType") %>' Width="140"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            

                            <asp:TemplateField HeaderText="Measuring Unit" ItemStyle-Width="150">
                                <ItemTemplate>
                                    <asp:Label ID="lblIDMeasuringUnit" runat="server" Text='<%# Eval("IDMeasuringUnit") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtIDMeasuringUnit" runat="server" Text='<%# Eval("IDMeasuringUnit") %>' Width="140"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField ButtonType="Link" ShowEditButton="true" ShowDeleteButton="true"
                                ItemStyle-Width="150" />

                        </Columns>
                    </asp:GridView>
                    <table border="1" cellpadding="0" cellspacing="0" style="border-collapse: collapse">
                        <tr>
                            <td class="auto-style1">
                                <br />
                                Name:<br />
                                <asp:TextBox ID="txtName" runat="server" Width="140" />
                            </td>
                            <td class="auto-style1">
                                <br />
                                Energy in kcal:<br />
                                <asp:TextBox ID="txtEnergyInKcal" runat="server" Width="140" />
                            </td>
                            <td class="auto-style1">
                                <br />
                                Energy in kJ:<br />
                                <asp:TextBox ID="txtEnergyInkJ" runat="server" Width="140px" Height="19px" />
                            </td>
                            <td class="auto-style6">Type (1,2,3) for (Carb, Fat, Protein):<br />
                                <asp:TextBox ID="txtType" runat="server" Width="140px" Height="21px" />
                            </td>
                            <td class="auto-style3">Measuring Unit (number):<br />
                                <asp:TextBox ID="txtMeasuringUnit" runat="server" Width="140" />
                            </td>
                            <td class="auto-style5">
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
