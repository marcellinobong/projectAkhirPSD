<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master.Master" AutoEventWireup="true" CodeBehind="UpdateEmployee.aspx.cs" Inherits="NeinteenFlower.View.Employee.UpdateEmployee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Update Employee</h1>
    <asp:Button ID="ButtonBackToManagePage" runat="server" Text="Back" OnClick="ButtonBackToManagePage_Click"/>

    <hr />

    <asp:Label ID="LabelName" runat="server" Text="Employee Name"></asp:Label>
    <asp:TextBox ID="InputName" runat="server"></asp:TextBox>

    <br /><br />

    <asp:Label ID="LabelEmail" runat="server" Text="Employee Email"></asp:Label>
    <asp:TextBox ID="InputEmail" runat="server"></asp:TextBox>

    <br /><br />

    <asp:Label ID="LabelPassword" runat="server" Text="Employee Password"></asp:Label>
    <asp:TextBox ID="InputPassword" runat="server" TextMode="Password"></asp:TextBox>

    <br /><br />

    <asp:Label ID="LabelDOB" runat="server" Text="Employee DOB"></asp:Label><br />
    <asp:Button ID="ButtonCalendarDOBPrevYear" OnClick="ButtonCalendarDOBPrevYear_Click" runat="server" Text="Prev Year" />
    <asp:Calendar ID="CalendarDOB" SelectionMode="Day" runat="server"></asp:Calendar>
    <asp:Button ID="ButtonCalendarDOBNextYear" OnClick="ButtonCalendarDOBNextYear_Click" runat="server" Text="Next Year" />

    <br /><br />

    <asp:Label ID="LabelGender" runat="server" Text="Employee Gender"></asp:Label>
    <asp:RadioButton ID="RadioButtonMale" GroupName="EmployeeGender" Text="Male" runat="server" />
    <asp:RadioButton ID="RadioButtonFemale" GroupName="EmployeeGender" Text="Female" runat="server" />

    <br /><br />
    
    <asp:Label ID="LabelAddress" runat="server" Text="Employee Address"></asp:Label>
    <br />
    <asp:TextBox ID="InputAddress" TextMode="MultiLine" Columns="50" Rows="2" runat="server"></asp:TextBox>

    <br /><br />
    
    <asp:Label ID="LabelPhone" runat="server" Text="Employee Phone"></asp:Label>
    <asp:TextBox ID="InputPhone" runat="server" TextMode="Phone"></asp:TextBox>

    <br /><br />
    
    <asp:Label ID="LabelSalary" runat="server" Text="Employee Salary"></asp:Label>
    <asp:TextBox ID="InputSalary" runat="server"></asp:TextBox>

    <br /><br />

    <asp:Label ID="LabelRole" runat="server" Text="Employee Role"></asp:Label>
    <asp:DropDownList ID="DropDownListRole" runat="server">
        <asp:ListItem Value="Admin" Selected="True">Admin</asp:ListItem>
        <asp:ListItem Value="Employee">Employee</asp:ListItem>
    </asp:DropDownList>

    <br /><br />

    <asp:Button ID="ButtonSubmit" runat="server" Text="Submit" OnClick="ButtonSubmit_Click" />

    <br /><br />
    <asp:Label ID="LabelAlertMessage" runat="server" Text=""></asp:Label>
</asp:Content>
