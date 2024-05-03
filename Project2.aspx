<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Project2.aspx.cs" Inherits="PracticeProject2.Project2" %>

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
                    <td>Name:  </td>
                    <td>
                        <asp:TextBox ID="txtname" runat="server"> </asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td>Age: </td>
                    <td>
                        <asp:TextBox ID="txtage" runat="server">  </asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td>Gender </td>
                    <td>
                        <asp:RadioButtonList ID="rblGender" runat="server" RepeatColumns="3"></asp:RadioButtonList>
                        
                    </td>
                </tr>

                    <tr>
                        <td>HomeAddress: </td>
                        <td>
                            <asp:TextBox ID="txtHomeAddress" runat="server"> </asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td>Country </td>
                        <td>
                            <asp:DropDownList ID="ddlCountry" runat="server" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged" AutoPostBack="true" ></asp:DropDownList>
                        </td>
                    </tr>

                    <tr>
                        <td>State </td>
                        <td>
                            <asp:DropDownList ID="ddlState" runat="server"></asp:DropDownList>
                        </td>
                        </tr>

                        <tr>
                            <td></td>
                            <td>
                                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                            </td>
                        </tr>
                    

                    <tr>
                        <td></td>
                        <td>
                            <asp:GridView ID="gvPatient" runat="server" AutoGenerateColumns="false" OnRowCommand="gvPatient_RowCommand">
                                <Columns>
                                    <asp:TemplateField HeaderText="Patient Id">
                                        <ItemTemplate>
                                            <%#Eval("Id") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="PatientName">
                                        <ItemTemplate>
                                            <%#Eval("Name") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="PatientAge">
                                        <ItemTemplate>
                                            <%#Eval("Age") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Address">
                                        <ItemTemplate>
                                            <%#Eval("HomeAddress") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Gender">
                                        <ItemTemplate>
                                            <%#Eval("GName") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Country">
                                        <ItemTemplate>
                                            <%#Eval("CName") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="State">
                                        <ItemTemplate>
                                            <%#Eval("SName") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btndelete" runat="server" Text="Delete" CommandName="A" CommandArgument='<%#Eval("Id") %>'> </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="State">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnEdit" runat="server" Text="Edit" CommandArgument='<%#Eval("Id") %>'> </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>




                                </Columns>

                            </asp:GridView>
                        </td>
                    </tr>
            </table>


        </div>
    </form>
</body>
</html>
