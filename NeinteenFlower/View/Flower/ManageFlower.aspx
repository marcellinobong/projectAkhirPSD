<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master.Master" AutoEventWireup="true" CodeBehind="ManageFlower.aspx.cs" Inherits="NeinteenFlower.View.Flower.ManageFlower" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>List Flower</h1>

    <br />

    <asp:Repeater ID="RepeaterFlower" runat="server">
        <ItemTemplate>
            <img src="<%# Page.Request.Url.Scheme + "://" + Request.Url.Host + (Request.Url.IsDefaultPort ? "" : ":" + Request.Url.Port + "/") + Eval("FlowerImage") %>" alt="flower pic" width="250" />
            <h2>Name: <%# Eval("FlowerName") %></h2>
            <p>Type: <%# Eval("FlowerTypeName") %></p>
            <p>Description: <%# Eval("FlowerDescription") %></p>
            <p>Price: <%# Eval("FlowerPrice") %></p>

            <asp:Button CommandArgument='<%# Eval("FlowerId") %>' OnCommand="BtnEditFlower_Command" ID="BtnEditFlower" runat="server" Text="Edit" />
            <asp:Button CommandArgument='<%# Eval("FlowerId") %>' OnCommand="BtnRemoveFlower_Command" ID="BtnRemoveFlower" runat="server" Text="Remove" />
                
            <hr />
        </ItemTemplate>
    </asp:Repeater>

    <asp:Button ID="BtnAddNewFlower" OnClick="BtnAddNewFlower_Click" runat="server" Text="Add new Flower" />
</asp:Content>
