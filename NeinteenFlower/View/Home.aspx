<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="NeinteenFlower.View.Home2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        header {
            display: flex;
            justify-content: space-between;
        }
        header nav {
            display: flex;
            justify-content: center;
            align-items: center;
        }
        header nav input {
            margin-right: 20px;
        }
        body {
            background-color: #E5E5E5;
        }
        input {
            padding: 5px 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="LabelHello" runat="server" Text="Label"></asp:Label>
    
    <hr />

    <header>
        <h1>NeinteenFlower</h1>
        <nav>
            <asp:Button ID="BtnHome" runat="server" Text="Home" OnClick="BtnHome_Click" />
            <asp:Button ID="BtnLogout" runat="server" Text="Logout" OnClick="BtnLogout_Click" />
            <% if (activeUser.role.Equals("Administrator") || activeUser.role.Equals("Admin")){ %>
                <asp:Button ID="BtnManageMember" runat="server" Text="Manage Member" OnClick="BtnManageMember_Click" />
                <asp:Button ID="BtnManageEmployee" runat="server" Text="Manage Employee" OnClick="BtnManageEmployee_Click" />
            <% } %>
        
            <% if (activeUser.role.Equals("Employee")){ %>
                <asp:Button ID="BtnManageFlower" runat="server" Text="Manage Flower" OnClick="BtnManageFlower_Click" />
            <% } %>

            <% if (activeUser.role.Equals("Member")){ %>
                <asp:Button ID="BtnViewTransactionHistory" runat="server" Text="View Transaction History" OnClick="BtnViewTransactionHistory_Click" />
            <% } %>    
        </nav>       
    </header>

    <main>
        <asp:Repeater ID="RepeaterFlower" runat="server">
            <ItemTemplate>
                <img src="<%# Page.Request.Url.Scheme + "://" + Request.Url.Host + (Request.Url.IsDefaultPort ? "" : ":" + Request.Url.Port + "/") + Eval("FlowerImage") %>" alt="flower pic" width="250" />
                <h2>Name: <%# Eval("FlowerName") %></h2>
                <p>Type: <%# Eval("FlowerTypeName") %></p>
                <p>Description: <%# Eval("FlowerDescription") %></p>
                <p>Price: <%# Eval("FlowerPrice") %></p>

                <asp:Button CommandArgument='<%# Eval("FlowerId") %>' OnCommand="BtnPreOrderFlower_Command" ID="BtnPreOrderFlower" runat="server" Text="PreOrder" />
                
                <hr />
            </ItemTemplate>
        </asp:Repeater>
    </main>
    
    
</asp:Content>
