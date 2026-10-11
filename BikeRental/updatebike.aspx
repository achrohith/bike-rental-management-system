<%@ Page Title="" Language="C#" MasterPageFile="~/site1.Master" AutoEventWireup="true" CodeBehind="updatebike.aspx.cs" Inherits="BikeRental.updatebike" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        section{
            padding-top:10rem;
        }
       
.styled-gridview {
    width: 100%;
    border-collapse: collapse;
    margin: auto;
    font-size: 1.6rem;
    text-align: center;
}

.styled-gridview th, .styled-gridview td {
    padding: 12px 15px;
    border: 1px solid black;
}

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section>

  <asp:GridView ID="gvBikes" runat="server" AutoGenerateColumns="False" OnRowCommand="gvBikes_RowCommand" CssClass="styled-gridview">
    <Columns>
        <asp:TemplateField HeaderText="Bike ID">
            <ItemTemplate>
                <asp:Label ID="lblBikeId" runat="server" Text='<%# Eval("bike_id") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Bike Name">
            <ItemTemplate>
                <asp:Label ID="lblBikeName" runat="server" Text='<%# Eval("bike_name") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Availability">
            <ItemTemplate>
                <asp:Label ID="lblAvailability" runat="server" Text='<%# Eval("availability") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Max Availability">
            <ItemTemplate>
                <asp:Label ID="lblMaxAvailability" runat="server" Text='<%# Eval("max_availability") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:Button ID="btnIncrease" runat="server" CommandName="Increase" CommandArgument='<%# Eval("bike_id") %>' Text="Increase" CssClass="btn" />
                <asp:Button ID="btnDecrease" runat="server" CommandName="Decrease" CommandArgument='<%# Eval("bike_id") %>' Text="Decrease" CssClass="btn" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>

        </section>
</asp:Content>
