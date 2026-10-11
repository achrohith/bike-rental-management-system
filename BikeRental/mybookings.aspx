<%@ Page Title="" Language="C#" MasterPageFile="~/site1.Master" AutoEventWireup="true" CodeBehind="mybookings.aspx.cs" Inherits="BikeRental.mybookings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .booking{
            padding-top:9rem;
        }
        .booking-item{
            display:flex;
            gap:60px;
            font-size:1.5rem;
            width:100%;
            border:1px solid black;
            margin-bottom:2rem;
            padding:2rem;
        }
        .detail p{
            margin-top:0.7rem;
            margin-bottom:1rem;
        }
        img{
            height:250px;
            width:300px;
            object-fit:contain;
        }
         @media (max-width: 768px) {
            .booking-item {
                flex-direction: column;
                align-items: center;
                gap: 20px;
                padding: 1rem;
            }
            .booking-item img {
                width: 100%;
                max-width: 300px;
                height: auto;
            }
            .detail p {
                font-size: 1.2rem;
            }
            .booking-item {
                font-size: 1.2rem;
                padding: 1.5rem;
            }
        }
          @media (max-width: 480px) {
            .booking {
                padding-top: 8rem;
            }
            .booking-item {
                gap: 10px;
                padding: 1rem;
                font-size: 1rem;
            }
            .detail p {
                font-size: 1rem;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="booking">
  <asp:Repeater ID="BookingRepeater" runat="server">
        <ItemTemplate>
            <div class="booking-item">
                <div>  <img src='<%# "bike/" + Eval("BikeId") + ".jpg" %>' alt='<%# Eval("BikeName") %>' /></div>
              <div class="detail">

                    <p>Date of Booking: <%# Eval("DateOfBooking", "{0:yyyy-MM-dd}") %></p>

                    <p>Booking ID: <%# Eval("BookingId") %></p>
                <p>Bike Name: <%# Eval("BikeName") %></p>
                  
                <p>Pickup Date: <%# Eval("PickupDate", "{0:yyyy-MM-dd}") %></p>
                <p>Delivery Date: <%# Eval("DeliveryDate", "{0:yyyy-MM-dd}") %></p>
                <p>Payable Amount: <%# Eval("PayableAmount", "{0:C}") %></p>
                 
                   <asp:Label ID="lblErrorMessage" runat="server" CssClass="error-message" style="color:red;font-size:1.6rem;" Visible="false" />
                  
                   
                  <asp:Button ID="btnCancelBooking" runat="server" Text="Cancel Booking"  OnClientClick="return confirm('Are you sure you want to cancel this booking?');"  CommandArgument='<%# Eval("BookingId") %>' OnClick="CancelBooking_Click" Visible="true" style="padding:1rem;background-color:red;" />
                    <asp:Label ID="message" runat="server" CssClass="error-message" style="color:red;font-size:1.6rem;" Visible="false" />
                  </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
        

    </section>
</asp:Content>
