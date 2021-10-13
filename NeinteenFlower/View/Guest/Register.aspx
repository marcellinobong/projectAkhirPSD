<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="NeinteenFlower.View.Guest.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Register</h1>

    <hr />
    <asp:Label ID="LabelEmail" runat="server" Text="Email"></asp:Label>
    <asp:TextBox ID="emailTxt" runat="server" TextMode="Email"></asp:TextBox>

    <br /><br />

    <asp:Label ID="LabelPassword" runat="server" Text="Password"></asp:Label>
    <asp:TextBox ID="passwordTxt" runat="server" TextMode="Password"></asp:TextBox>

    <br /><br />

    <asp:Label ID="LabelName" runat="server" Text="Name"></asp:Label>
    <asp:TextBox ID="nameTxt" runat="server"></asp:TextBox>

    <br /><br />

    <asp:Label ID="LabelAge" runat="server" Text="Age"></asp:Label>
    <asp:TextBox ID="ageTxt" runat="server" TextMode="Date"></asp:TextBox>

    <br /><br />

    <asp:Label ID="LabelGender" runat="server" Text="Gender"></asp:Label>
    <select id="InputGender" name="InputGender">
        <option value="Male">Male</option>
        <option value="Female">Female</option>
    </select>

    <br /><br />

    <asp:Label ID="LabelPhonenumber" runat="server" Text="Phone Number"></asp:Label>
    <asp:TextBox ID="phonenumberTxt" runat="server" TextMode="Number"></asp:TextBox>

    <br /><br />

    <asp:Label ID="LabelAddress" runat="server" Text="Address"></asp:Label>
    <asp:TextBox ID="addressTxt" runat="server" TextMode="MultiLine"></asp:TextBox>

    <br /><br />

    <asp:Button ID="registerButton" runat="server" Text="Register" OnClick="registerButton_Click" />
    <br />
    <asp:Label ID="registerMsg" runat="server" Text=""></asp:Label>
    <br /><br />
</asp:Content>
