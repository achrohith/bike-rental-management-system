<%@ Page Title="" Language="C#" MasterPageFile="~/site1.Master" AutoEventWireup="true" CodeBehind="bikemenu.aspx.cs" Inherits="BikeRental.bikemenu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <style>
        .bike {
    padding-top: 8rem;
}

.unavl {
    width:100%;
    text-align: center;
    margin-top: 1rem;
    background-color: #eee;
    padding: 0.8rem;
    border-radius: 5px;
    cursor: not-allowed;
}

.btn {
    width: 100%;
    margin-top: 0.8rem;
}

p {
    font-size: 1.6rem;
    font-weight: 600;
    margin-bottom: .6rem;
}

.bname {
    font-size: 2rem;
    font-weight: 600;
}

.bike-container, .scooty-container {
    display: grid;
    grid-template-columns: repeat(auto-fit,minmax(25rem,1fr));
    gap: 1.5rem;
    padding-top:9rem;
}

.bike-cart {
    padding: 2rem;
    background: #fff;
    box-shadow: var(--box-shadow);
    border-radius: .5rem;
    position: relative;
}

img {
    width: 100%;
    height: 170px;
    object-fit:cover;
}

input[type="date"] {
    width: calc(50% - 5px);
    padding: 8px;
    margin-bottom: 5px;
    box-sizing: border-box;
    border: 1px solid #ccc;
    border-radius: 4px;
    display: inline-block;
}

label {
    display: inline-block;
    width: calc(50% - 5px);
    font-size: 1.3rem;
}

.left {
    position: absolute;
    font-size: 1.2rem;
    top: 10px;
    right: 0;
    padding: .4rem 1.2rem;
    border-top-left-radius: 5px;
    border-bottom-left-radius: 5px;
    color: black;
    background-color: var(--light-yellow);
}

.hidden {
    display: none;
}

.dropbtn {
    background-color: white;
    font-size: 1.8rem;
    padding-right: 1rem;
}

    .dropbtn:hover, .dropbtn:focus {
        color: var(--light-yellow);
    }

.dropdown {
    position: relative;
    display: inline-block;
}

.dropdown-content {
    display: none;
    position: absolute;
    background-color: #f9f9f9;
    min-width: 160px;
    box-shadow: 0px 8px 16px 0px rgba(0,0,0,0.2);
    z-index: 1;
}

    .dropdown-content a {
        color: black;
        padding: 12px 16px;
        text-decoration: none;
        display: block;
    }

.dropdown:hover .dropdown-content {
    display: block;
}




    </style>
    <script>
        document.addEventListener("DOMContentLoaded", function () {
            const pickupDateElements = document.querySelectorAll(".pickup-date");
            const deliveryDateElements = document.querySelectorAll(".delivery-date");

            function updateDateConstraints(pickupDateEl, deliveryDateEl) {
                const today = new Date();
                const maxPickupDate = new Date(today);
                maxPickupDate.setDate(today.getDate() + 30); 

       
                pickupDateEl.min = today.toISOString().split("T")[0];
                pickupDateEl.max = maxPickupDate.toISOString().split("T")[0];

               
                pickupDateEl.addEventListener("change", function () {
                    const pickupDate = new Date(pickupDateEl.value);

                    if (pickupDate > maxPickupDate) {
                        alert("Pickup date must be within 30 days from today.");
                        pickupDateEl.value = "";
                        return;
                    }

                    const minDeliveryDate = new Date(pickupDate);
                    const maxDeliveryDate = new Date(pickupDate);
                    maxDeliveryDate.setDate(maxDeliveryDate.getDate() + 7);

                    deliveryDateEl.min = minDeliveryDate.toISOString().split("T")[0];
                    deliveryDateEl.max = maxDeliveryDate.toISOString().split("T")[0];

                    
                    if (deliveryDateEl.value) {
                        const deliveryDate = new Date(deliveryDateEl.value);
                        if (deliveryDate < minDeliveryDate || deliveryDate > maxDeliveryDate) {
                            deliveryDateEl.value = "";
                        }
                    }
                });
            }

            pickupDateElements.forEach((pickupDateEl, index) => {
                const deliveryDateEl = deliveryDateElements[index];
                updateDateConstraints(pickupDateEl, deliveryDateEl);
            });

            deliveryDateElements.forEach(function (deliveryDateEl) {
                deliveryDateEl.addEventListener("change", function () {
                    const pickupDateEl = document.getElementById(deliveryDateEl.id.replace("delivery", "pickup"));
                    const pickupDate = new Date(pickupDateEl.value);
                    const deliveryDate = new Date(deliveryDateEl.value);
                    const maxDeliveryDate = new Date(pickupDate);
                    maxDeliveryDate.setDate(pickupDate.getDate() + 7);

                    if (deliveryDate < pickupDate || deliveryDate > maxDeliveryDate) {
                        alert("Delivery date must be within one week of the pickup date.");
                        deliveryDateEl.value = "";
                    }
                });
            });
        });


       
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="bike-container" id="bike-container">
        <asp:Repeater ID="BikeRepeater" runat="server">
            <ItemTemplate>
                <div class="bike-cart">
                    <asp:Panel ID="AvailabilityPanel" runat="server" Visible='<%# Convert.ToInt32(Eval("Availability")) > 0 %>'>
                        <div class="left">
                            <%# Convert.ToInt32(Eval("Availability")) == 1 ? "Available" : Eval("Availability").ToString() + " Left" %>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="UnavailablePanel" runat="server" Visible='<%# Convert.ToInt32(Eval("Availability")) <= 0 %>'>
                        <div class="left">Booked</div>
                    </asp:Panel>
                    <img src='<%# "bike/" + Eval("BikeId") + ".jpg" %>' alt='<%# Eval("BikeName") %>' />
                    <p class="bname"><%# Eval("BikeName") %></p>
                    <p>Price: <%# Eval("BikePrice") %>/day</p>


                    <asp:HiddenField ID="BikeId" runat="server" Value='<%# Eval("BikeId") %>' />
  
                    <label for="pickup_date_<%# Eval("BikeId") %>">Pickup Date:</label>
    <asp:TextBox ID="TextBox1" runat="server" TextMode="Date" CssClass="pickup-date" Enabled='<%# Convert.ToInt32(Eval("Availability")) > 0 %>' />
  
    <label for="delivery_date_<%# Eval("BikeId") %>">Delivery Date:</label>
    <asp:TextBox ID="TextBox2" runat="server" TextMode="Date" CssClass="delivery-date" Enabled='<%# Convert.ToInt32(Eval("Availability")) > 0 %>' />
   <asp:Panel ID="BookNowPanel" runat="server" Visible='<%# Convert.ToInt32(Eval("Availability")) > 0 %>'>
       <asp:Button ID="BookNowButton" runat="server" Text="Book Now" CssClass="btn" ValidationGroup="" OnClick="BookNowButton_Click" CommandArgument='<%# Eval("BikeId") %>' />
   </asp:Panel>
                    <asp:Panel ID="BookedPanel" runat="server" Visible='<%# Convert.ToInt32(Eval("Availability")) <= 0 %>'>
                        <asp:Button ID="BookedButton" runat="server" Text="Booked" CssClass="unavl" Enabled="false" />
                    </asp:Panel>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </section>
</asp:Content>


