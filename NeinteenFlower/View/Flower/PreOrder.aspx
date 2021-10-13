<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master.Master" AutoEventWireup="true" CodeBehind="PreOrder.aspx.cs" Inherits="NeinteenFlower.View.Flower.PreOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>PreOrder Flower</h1>

    <asp:Label ID="LabelName" runat="server" Text="Label"></asp:Label>
    <br />
    <br />
    <asp:Label ID="LabelPrice" runat="server" Text="Label"></asp:Label>
    <br />
    <br />
    <asp:Label ID="LabelInputQuantity" runat="server" Text="Quantity"></asp:Label>
    <br />
    <br />
    <asp:TextBox ID="InputQuantity" runat="server"></asp:TextBox>

    <asp:Button ID="BtnPreOrder" OnClick="BtnPreOrder_Click" runat="server" Text="Pre Order Now!" />

    <br />
    <br />
    <asp:Label ID="LabelAlertMessage" runat="server" Text=""></asp:Label>
</asp:Content>
