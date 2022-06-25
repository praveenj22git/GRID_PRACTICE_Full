<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Drillodown35.aspx.cs" Inherits="GRID_PRACTICE.Drillodown35" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ContinentId"  DataSourceID="ObjectDataSource1">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="ContinentId" HeaderText="ContinentId" SortExpression="ContinentId" />
                <asp:BoundField DataField="ContinentName"  HeaderText="ContinentName" SortExpression="ContinentName" />
            </Columns>
        </asp:GridView>
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="CountryId"  DataSourceID="ObjectDataSource2">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="CountryId" HeaderText="CountryId" SortExpression="CountryId" />
                <asp:BoundField DataField="CountryName" HeaderText="CountryName" SortExpression="CountryName" />
                <asp:BoundField DataField="ContinentId" HeaderText="ContinentId" SortExpression="ContinentId" />
            </Columns>
        </asp:GridView>
        <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" DataKeyNames="CityId" DataSourceID="ObjectDataSource3">
            <Columns>
                <asp:BoundField DataField="CityId" HeaderText="CityId" SortExpression="CityId" />
                <asp:BoundField DataField="CityName" HeaderText="CityName" SortExpression="CityName" />
                <asp:BoundField DataField="CountryId"  HeaderText="CountryId" SortExpression="CountryId" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAllContinents" TypeName="GRID_PRACTICE.ContinentDataAccessLayer"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetCountriesByContinent" TypeName="GRID_PRACTICE.CountryDataAccessLayer">
            <SelectParameters>
                <asp:ControlParameter ControlID="GridView1" Name="ContinentId" PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" SelectMethod="GetCitiesByCountryId" TypeName="GRID_PRACTICE.CityDataAccessLayer">
            <SelectParameters>
                <asp:ControlParameter ControlID="GridView2" Name="CountryId" PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </form>
</body>
</html>
