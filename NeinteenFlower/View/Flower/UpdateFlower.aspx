<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master.Master" AutoEventWireup="true" CodeBehind="UpdateFlower.aspx.cs" Inherits="NeinteenFlower.View.Flower.EditFlower" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Edit Flower</h1>

    <hr />

    <asp:TextBox ID="InputId" runat="server" Visible="false"></asp:TextBox>

    <asp:Label ID="LabelName" runat="server" Text="Flower Name"></asp:Label>
    <asp:TextBox ID="InputName" runat="server"></asp:TextBox>

    <br /><br />

    <asp:Label ID="LabelType" runat="server" Text="Flower Type"></asp:Label>
    <select id="InputTypeId" name="InputTypeId">
        <asp:Repeater ID="RepeaterFlowerType" runat="server">
            <ItemTemplate>
                <option value='<%# Eval("FlowerTypeId")%>' <%# Eval("FlowerTypeId").Equals(flower.FlowerTypeId) ? "selected" : "" %>> <%# Eval("FlowerTypeName")%></option>
            </ItemTemplate>
        </asp:Repeater>
    </select>

    <br /><br />
    
    <asp:Label ID="LabelDescription" runat="server" Text="Flower Description"></asp:Label>
    <br />
    <asp:TextBox ID="InputDescription" TextMode="MultiLine" Columns="50" Rows="2" runat="server"></asp:TextBox>

    <br /><br />
    
    <asp:Label ID="LabelPrice" runat="server" Text="FlowerPrice"></asp:Label>
    <asp:TextBox ID="InputPrice" runat="server" TextMode="Number"></asp:TextBox>

    <br /><br />

    <asp:Label ID="LabelImage" runat="server" Text="Flower Image"></asp:Label>
    <asp:FileUpload ID="InputImage" runat="server" AllowMultiple="false" />

    <br /><br />

    <asp:Button ID="ButtonUpdate" runat="server" Text="Update" OnClick="ButtonUpdate_Click" />

    <br /><br />
    <asp:Label ID="LabelAlertMessage" runat="server" Text=""></asp:Label>
</asp:Content>
