<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Students.aspx.cs" Inherits="Curd.Students" %>

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
                    <td>RegNo</td>
                    <td><asp:TextBox ID="RegNoTextBox" runat="server"></asp:TextBox>
                        <asp:HiddenField ID="StudentIdHiddenField" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td><label>Name</label></td>
                    <td><asp:TextBox ID="NameTextBox" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                   <td><label>Email</label></td>
                    <td><asp:TextBox ID="EmailTextBox" runat="server"></asp:TextBox></td>
                </tr>
              
                <tr>
                    <td><label>Address</label></td>
                    <td><asp:TextBox ID="AddressTextBox" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Button ID="Save" runat="server" Text="Save" OnClick="Save_Click" /></td>
                    <td><asp:Button ID="Show" runat="server" Text="Show" OnClick="Show_Click" /></td>
                </tr>
            </table>
            <h4>Student List</h4>
            <asp:GridView runat="server" ID="studentGridView" AutoGenerateColumns="False">
                <Columns>
                    
                    <asp:TemplateField HeaderText="ID">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%#Eval("Id") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Registration Number">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%#Eval("RegNo") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Student Name">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Email">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%#Eval("Email") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Address">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%#Eval("Address") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl=' <%#string.Format("StudentEntryUI.aspx?regNo={0}",Eval("RegNo")) %>'>Edit</asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
