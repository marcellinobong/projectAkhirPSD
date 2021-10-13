<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="NeinteenFlower.View.Guest.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Login</h1>

    <hr />
    <asp:Label ID="LabelEmail" runat="server" Text="Email"></asp:Label>
    <asp:TextBox ID="emailTxt" runat="server" TextMode="Email"></asp:TextBox>

    <br /><br />

    <asp:Label ID="LabelPassword" runat="server" Text="Password"></asp:Label>
    <asp:TextBox ID="passwordTxt" runat="server" TextMode="Password"></asp:TextBox>

    <br /><br />
    
    <asp:CheckBox ID="rememberMe" runat="server" /> RememberMe
    
    <br /><br />
    
    <asp:Button ID="loginButton" runat="server" Text="Login" OnClick="loginButton_Click" />
    <br />
    <asp:Label ID="loginMsg" runat="server" Text=""></asp:Label>
    <br /><br />

    <div style="display:flex; width:250px; justify-content:space-between">
        <asp:HyperLink ID="registerHyperLink" runat="server" href="Register.aspx">Register </asp:HyperLink>
        <asp:HyperLink ID="forgotpasswordHyperLink" runat="server" href="ForgotPassword.aspx"> Forgot Password</asp:HyperLink>
    </div>
</asp:Content>
