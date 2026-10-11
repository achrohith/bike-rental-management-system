<%@ Page Title="" Language="C#" MasterPageFile="~/site1.Master" AutoEventWireup="true" CodeBehind="bookings.aspx.cs" Inherits="BikeRental.bookings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        .booking{
            padding-top:10rem;
            font-size:1.6rem;

        }
         table {
             border-collapse: collapse; 
             width: 100%;
             padding:1rem;
         }

            table, th, td {
              border: 1px solid black;
                 text-align:center;
                 padding: 18px 15px;
         }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <section class="booking">
          <table border="1" cellspacing="0">
              <tr>
                  <th>Date Of Booking</th>

                  <th>Booking ID</th>
                  <th>User Email</th>

                  <th>Bike Name
                  </th>
               
                  <th>Payable Amount</th>
              </tr>
<asp:Repeater ID="BookingRepeater" runat="server">


      <ItemTemplate>

          <tr>
                  <td> <%# Eval("DateOfBooking", "{0:yyyy-MM-dd}") %></td>
              <td> <%# Eval("BookingId") %></td>
              <td> <%# Eval("UserEmail") %></td>
              <td><%# Eval("BikeName") %></td>

          
              <td> <%# Eval("PayableAmount", "{0:C}") %></td>


              </tr>
        
      </ItemTemplate>
  </asp:Repeater>
              </table>

  </section>
</asp:Content>
