<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Image30.aspx.cs" Inherits="GRID_PRACTICE.Image30" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAllEmployees" TypeName="GRID_PRACTICE.EmployeeDataAccessLayer4"></asp:ObjectDataSource>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" DataSourceID="ObjectDataSource1">
                <Columns>
                    <asp:BoundField DataField="EmployeeId" HeaderText="EmployeeId" SortExpression="EmployeeId" />
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="Gender" HeaderText="Gender" SortExpression="Gender" />
                    <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
                    <asp:BoundField DataField="Photo" HeaderText="Photo" SortExpression="Photo" />
                    <asp:TemplateField HeaderText="Photo">
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" Height="100px"
                                Width="100px" ImageUrl='<%# Bind("Photo") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:ImageField HeaderText="Photo" DataImageUrlField="Photo"
                        ControlStyle-Height="100px" ControlStyle-Width="100px">
                    </asp:ImageField>
                </Columns>
                <EmptyDataTemplate>
                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# Bind("Photo") %>' />
                </EmptyDataTemplate>
                <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#FFF1D4" />
                <SortedAscendingHeaderStyle BackColor="#B95C30" />
                <SortedDescendingCellStyle BackColor="#F1E5CE" />
                <SortedDescendingHeaderStyle BackColor="#93451F" />
            </asp:GridView>
        </div>
    </form>
</body>
</html>
