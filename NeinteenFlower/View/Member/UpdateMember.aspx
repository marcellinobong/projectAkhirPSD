<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master.Master" AutoEventWireup="true" CodeBehind="UpdateMember.aspx.cs" Inherits="NeinteenFlower.View.Member.EditMember" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Edit Member</h1>
    <asp:Button ID="ButtonBackToManagePage" runat="server" Text="Back" OnClick="ButtonBackToManagePage_Click"/>

    <hr />

    <asp:TextBox ID="InputId" runat="server" Visible="false"></asp:TextBox>

    <asp:Label ID="LabelName" runat="server" Text="Member Name"></asp:Label>
    <asp:TextBox ID="InputName" runat="server"></asp:TextBox>

    <br /><br />

    <asp:Label ID="LabelDOB" runat="server" Text="Member DOB"></asp:Label>
    <asp:TextBox ID="InputDOB" runat="server" TextMode="Date"></asp:TextBox>

    <br /><br />

    <asp:Label ID="LabelGender" runat="server" Text="Member Gender"></asp:Label>
    <select id="InputGender" name="InputGender">
        <option value="Male" <%# "Male" == member.MemberGender ? "selected" : "" %>>Male</option>
        <option value="Female" <%# "Female" == member.MemberGender ? "selected" : "" %>>Female</option>
    </select>

    <br /><br />
    
    <asp:Label ID="LabelAddress" runat="server" Text="Member Address"></asp:Label>
    <br />
    <asp:TextBox ID="InputAddress" TextMode="MultiLine" Columns="50" Rows="2" runat="server"></asp:TextBox>

    <br /><br />
    
    <asp:Label ID="LabelPhone" runat="server" Text="Member Phone"></asp:Label>
    <asp:TextBox ID="InputPhone" runat="server"></asp:TextBox>

    <br /><br />

    <asp:Label ID="LabelEmail" runat="server" Text="Member Email"></asp:Label>
    <asp:TextBox ID="InputEmail" runat="server" TextMode="Email"></asp:TextBox>

    <br /><br />

    <asp:Label ID="LabelPassword" runat="server" Text="Member Password"></asp:Label>
    <asp:TextBox ID="InputPassword" runat="server" TextMode="Password"></asp:TextBox>

    <br /><br />

    <asp:Button ID="ButtonSubmit" runat="server" Text="Submit" OnClick="ButtonSubmit_Click" />

    <br /><br />
    <asp:Label ID="LabelAlertMessage" runat="server" Text=""></asp:Label>
</asp:Content>
