<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master.Master" AutoEventWireup="true" CodeBehind="ManageMember.aspx.cs" Inherits="NeinteenFlower.View.Member.ManageMember" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>List Member</h1>
    <asp:Button ID="ButtonBackToHomePage" runat="server" Text="Back" OnClick="ButtonBackToHomePage_Click"/>

    <br />
    <br />

    <asp:GridView ID="MemberTable" ShowHeaderWhenEmpty="true" AutoGenerateColumns="false" runat="server">
        <Columns>
            <asp:TemplateField HeaderText="ID">
                <ItemTemplate>
                    <asp:Label ID="LabelID" runat="server" Text='<%# Eval("MemberId") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Name">
                <ItemTemplate>
                    <asp:Label ID="LabelName" runat="server" Text='<%# Eval("MemberName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Email">
                <ItemTemplate>
                    <asp:Label ID="LabelEmail" runat="server" Text='<%# Eval("MemberEmail") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Date of Birth">
                <ItemTemplate>
                    <asp:Label ID="LabelDOB" runat="server" Text='<%# Eval("MemberDOB", "{0:dd/M/yyyy}") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Gender">
                <ItemTemplate>
                    <asp:Label ID="LabelGender" runat="server" Text='<%# Eval("MemberGender") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Phone">
                <ItemTemplate>
                    <asp:Label ID="LabelPhone" runat="server" Text='<%# Eval("MemberPhone") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Address">
                <ItemTemplate>
                    <asp:Label ID="LabelAddress" runat="server" Text='<%# Eval("MemberAddress") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Actions">
                <ItemTemplate>
                    <asp:Button ID="btnUpdateMember" CommandArgument='<%# Eval("MemberId") %>' OnCommand="btnUpdateMember_Command" runat="server" Text="Update" ></asp:Button>
                    <asp:Button ID="btnDeleteMember" CommandArgument='<%# Eval("MemberId") %>' OnCommand="btnDeleteMember_Command" OnClientClick="return confirm('Are you sure you want to delete this member?')" runat="server" Text="Delete"></asp:Button>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <br />
    <br />

    <asp:Button ID="BtnAddNewMember" OnClick="BtnAddNewMember_Click" runat="server" Text="Add new Member" />
</asp:Content>
