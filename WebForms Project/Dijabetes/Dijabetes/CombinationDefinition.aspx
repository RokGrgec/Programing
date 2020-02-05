<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CombinationDefinition.aspx.cs" Inherits="Dijabetes.CombinationDefinition" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style2 {
            width: 849px;
        }
    </style>
</head>
<body style="height: 223px">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager> 
        <div id="dvGrid" style="padding: 10px; " class="auto-style2">
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Number of meals"></asp:Label>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>      
                <td>
                    <asp:Button Text="Generate" runat="server" OnClick="Unnamed1_Click" />
                    
                </td>
            </tr>
        </table>
        <asp:Label ID="Label2" runat="server" Text="Valid From"></asp:Label>
&nbsp;<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
&nbsp;<br />
        Valid To <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <br />
       
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false"
                        DataKeyName="MealName" OnRowEditing="OnRowEditing" OnRowUpdating="OnRowUpdating"  OnRowCancelingEdit="OnRowCancelingEdit"
                        PageSize="3" AllowPaging="true" 
                        Width="842px">
                        <Columns>

                            <asp:TemplateField HeaderText="Id" ItemStyle-Width="150">
                                <ItemTemplate>
                                    <asp:Label ID="lblId" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtId" runat="server" Text='<%# Eval("Id") %>' Width="140"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Name" ItemStyle-Width="150">
                                <ItemTemplate>
                                    <asp:Label ID="lblName" runat="server" Text='<%# Eval("MealName") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtName" runat="server" Text='<%# Eval("MealName") %>' Width="140"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="% Of Fat" ItemStyle-Width="150">
                                <ItemTemplate>
                                    <asp:Label ID="lblFat" runat="server" Text='<%# Eval("Fat") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtFat" runat="server" Text='<%# Eval("Fat") %>' Width="140"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="% Of Carb" ItemStyle-Width="150">
                                <ItemTemplate>
                                    <asp:Label ID="lblPerCrb" runat="server" Text='<%# Eval("Carb") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtPerCarb" runat="server" Text='<%# Eval("Carb") %>' Width="140"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="% Of Protein" ItemStyle-Width="150">
                                <ItemTemplate>
                                    <asp:Label ID="lblPerProtein" runat="server" Text='<%# Eval("Protein") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtPerProtein" runat="server" Text='<%# Eval("Protein") %>' Width="140"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Total %" ItemStyle-Width="150">
                                <ItemTemplate>
                                    <asp:Label ID="lblTotalPer" runat="server" Text='<%# Eval("TotalPer") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtTotalPer" runat="server" Text='<%# Eval("TotalPer") %>' Width="140"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField ButtonType="Link" ShowEditButton="true" ShowDeleteButton="true"
                                ItemStyle-Width="150" />
                        </Columns>
                    </asp:GridView>
                    <table border="1" cellpadding="0" cellspacing="0" style="border-collapse: collapse">   
                        <asp:Button ID="btnSave" runat="server" Text="Save"/>    
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
