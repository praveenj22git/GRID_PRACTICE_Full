﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="products.aspx.cs" Inherits="GRID_PRACTICE.products" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="font-family: Arial">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:TemplateField HeaderText="ID">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" OnClick="LinkButton1_Click"
                                Text='<%#Eval("ID") %>' runat="server"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                    <asp:BoundField DataField="Price" HeaderText="Price" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
