<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master.Master" AutoEventWireup="true" CodeBehind="ManageEmployee.aspx.cs" Inherits="NeinteenFlower.View.Employee.ManageEmployee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>List Employee</h1>
    <asp:Button ID="ButtonBackToHomePage" runat="server" Text="Back" OnClick="ButtonBackToHomePage_Click"/>


    <br />

    <asp:GridView ID="EmployeeTable" ShowHeaderWhenEmpty="true" AutoGenerateColumns="false" runat="server">
        <Columns>
            <asp:TemplateField HeaderText="ID">
                <ItemTemplate>
                    <asp:Label ID="LabelID" runat="server" Text='<%# Eval("EmployeeId") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Name">
                <ItemTemplate>
                    <asp:Label ID="LabelName" runat="server" Text='<%# Eval("EmployeeName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Email">
                <ItemTemplate>
                    <asp:Label ID="LabelEmail" runat="server" Text='<%# Eval("EmployeeEmail") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Date of Birth">
                <ItemTemplate>
                    <asp:Label ID="LabelDOB" runat="server" Text='<%# Eval("EmployeeDOB", "{0:dd/M/yyyy}") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Gender">
                <ItemTemplate>
                    <asp:Label ID="LabelGender" runat="server" Text='<%# Eval("EmployeeGender") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Phone">
                <ItemTemplate>
                    <asp:Label ID="LabelPhone" runat="server" Text='<%# Eval("EmployeePhone") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Address">
                <ItemTemplate>
                    <asp:Label ID="LabelAddress" runat="server" Text='<%# Eval("EmployeeAddress") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Salary">
                <ItemTemplate>
                    <asp:Label ID="LabelSalary" runat="server" Text='<%# Eval("EmployeeSalary") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Role">
                <ItemTemplate>
                    <asp:Label ID="LabelRole" runat="server" Text='<%# Eval("EmployeeRole") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Actions">
                <ItemTemplate>
                    <asp:Button ID="btnUpdate" CommandArgument='<%# Eval("EmployeeId") %>' OnCommand="btnUpdate_Command" runat="server" Text="Update" ></asp:Button>
                    <asp:Button ID="btnDelete" CommandArgument='<%# Eval("EmployeeId") %>' OnCommand="btnDelete_Command" OnClientClick="return confirm('Are you sure you want to delete this employee?')" runat="server" Text="Delete"></asp:Button>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <br />

    <asp:Button ID="btnInsert" Text="Insert Employee" runat="server" OnClick="btnInsert_Click"/>
</asp:Content>
