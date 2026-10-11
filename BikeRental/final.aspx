<%@ Page Title="" Language="C#" MasterPageFile="~/site1.Master" AutoEventWireup="true" CodeBehind="final.aspx.cs" Inherits="BikeRental.final" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .final{
          
            display:flex;
            justify-content:center;
            align-items:center;
            height:100vh;
            font-size:2rem;
            box-sizing:border-box;

        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="final">
        <div>
          <p style="font-size:3rem;font-weight:bold;">Thank You</p>  
            <p style="margin-bottom:5px;">Your booking was successful! We hope you enjoy your ride.😊</p>
            <asp:Button cssClass="btn" id="viewbtn" runat="server" Text="View Booking" OnClick="View"/>
        </div>
        
        </section>

                                                                       
</asp:Content>
