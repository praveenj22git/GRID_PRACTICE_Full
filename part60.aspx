<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="part60.aspx.cs" Inherits="GRID_PRACTICE.part60" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
<tr>
<td>
    <asp:GridView ID="GridView1" ShowHeader="false" 
        GridLines="None" AutoGenerateColumns="false"
        runat="server">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <table style="border: 1px solid #A55129; 
                        background-color: #FFF7E7">
                        <tr>
                            <td style="width: 200px">
                                <asp:Image ID="imgEmployee" 
                                    ImageUrl='<%# Eval("PhotoPath")%>' 
                                    runat="server" />
                            </td>
                            <td style="width: 200px">
                                <table>
                                    <tr>
                                        <td>
                                            <b>Id:</b>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblId" 
                                            runat="server" 
                                            Text='<%#Eval("EmployeeId") %>'>
                                            </asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <b>Name:</b>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblName" 
                                            runat="server" 
                                            Text='<%#Eval("Name") %>'>
                                            </asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <b>Gender:</b>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblGender" 
                                            runat="server" 
                                            Text='<%#Eval("Gender") %>'>
                                            </asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <b>City:</b>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblCity" 
                                            runat="server" 
                                            Text='<%#Eval("City") %>'>
                                            </asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</td>
<td>
    <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>
            <table style="border: 1px solid #A55129; 
                background-color: #FFF7E7">
                <tr>
                    <td style="width: 200px">
                        <asp:Image ID="imgEmployee" 
                        ImageUrl='<%# Eval("PhotoPath")%>' 
                        runat="server" />
                    </td>
                    <td style="width: 200px">
                        <table>
                            <tr>
                                <td>
                                    <b>Id:</b>
                                </td>
                                <td>
                                    <asp:Label ID="lblId" 
                                    runat="server" 
                                    Text='<%#Eval("EmployeeId") %>'>
                                    </asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>Name:</b>
                                </td>
                                <td>
                                    <asp:Label ID="lblName" 
                                    runat="server" 
                                    Text='<%#Eval("Name") %>'>
                                    </asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>Gender:</b>
                                </td>
                                <td>
                                    <asp:Label ID="lblGender" 
                                    runat="server" 
                                    Text='<%#Eval("Gender") %>'>
                                    </asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>City:</b>
                                </td>
                                <td>
                                    <asp:Label ID="lblCity" 
                                    runat="server" 
                                    Text='<%#Eval("City") %>'>
                                    </asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
        <SeparatorTemplate>
            <asp:Image ID="Image1" 
            ImageUrl="~/Images/1x1PixelImage.png" 
            runat="server" />
        </SeparatorTemplate>
    </asp:Repeater>
</td>
</tr>
</table>
        </div>
    </form>
</body>
</html>
