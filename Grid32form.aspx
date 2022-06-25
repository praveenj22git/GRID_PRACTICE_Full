<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Grid32form.aspx.cs" Inherits="GRID_PRACTICE.Grid32form" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:GridView ID="GridView1" runat="server" 
    AutoGenerateColumns="False">
    <Columns>
        <asp:BoundField DataField="DepartmentId" 
            HeaderText="Department Id" />
        <asp:BoundField DataField="DepartmentName" 
            HeaderText="Department Name" />
        <asp:TemplateField HeaderText="Employees">
            <ItemTemplate>
                <asp:GridView ID="GridView2" runat="server" 
                    DataSource='<%# Bind("Employees") %>'>
                </asp:GridView>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
    </form>
</body>
</html>
