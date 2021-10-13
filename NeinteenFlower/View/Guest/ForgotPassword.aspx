<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master.Master" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="NeinteenFlower.View.Guest.ForgotPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Forgot Password</h1>
    <hr />

    <asp:Label ID="LabelEmail" runat="server" Text="Email"></asp:Label>
    <asp:TextBox ID="emailTxt" runat="server" TextMode="Email"></asp:TextBox>

    <br /><br />

    <asp:Label ID="Labelcaptcha" runat="server" Text="Captcha : "></asp:Label>
    <asp:Label ID="captchaCode" runat="server" Text=""></asp:Label>
    
    <br /><br />
    <br />
    <asp:Label ID="LabelNewPassword" runat="server" Text="New Password"></asp:Label>
    
    <asp:TextBox ID="newpasswordTxt" runat="server" TextMode="Password"></asp:TextBox>

    <br /><br />

    <asp:Button ID="forgotpasswordButton" runat="server" Text="Submit" OnClick="forgotpasswordButton_Click" />
    <br />
    <asp:Label ID="forgotpasswordMsg" runat="server" Text=""></asp:Label>
    <br /><br />
</asp:Content>
