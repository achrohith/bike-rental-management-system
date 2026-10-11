<%@ Page Title="" Language="C#" MasterPageFile="~/site1.Master" AutoEventWireup="true" CodeBehind="bikkedetail.aspx.cs" Inherits="BikeRental.bikkedetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
/*        section {
            padding-top: 10rem;
            display: flex;
            justify-content: center;
            grid-column-gap:20px;
        }

        .d {
            flex-basis: 50%;
            padding-top: 1rem;
            padding-bottom: 1rem;
        }

        .name {
            font-size: 2rem;
        }

        .bill {
            padding: 2.5rem;
            border: 2px solid rgba(0, 0, 0, 0.6);
            box-shadow: 2px 2px 2px rgba(0, 0, 0, 0.3);
        }
        .check{
            font-size:2rem;
            width:20px;
        }
        .text-input{
            width:100%;
            padding:10px;
            height:50px;
            border:1px solid gray;
            font-size:2rem;
            border-radius:5px;
            margin-bottom:1rem;
            margin-top:1rem;
        }
        .disable{
            width:100%;
            padding:10px;
            font-size:2rem;


        }
        .check input[type="checkbox"] {
    transform: scale(1);
    width: 20px;
    height: 20px; 
}
        .gap{height:2px;
             background-color:black;
        }
        .bill p{
            margin-bottom:1rem;
        }
        img{
            height:300px;
        }*/
 section {
        padding-top: 10rem;
        display: flex;
        flex-direction: column; /* Stack vertically on small screens */
        align-items: center; /* Center items */
    }

    @media (min-width: 768px) {
        section {
            flex-direction: row; /* Arrange in a row on larger screens */
            justify-content: center;
            grid-column-gap: 20px;
        }
    }

    .d {
        flex-basis: 100%; /* Take full width on mobile */
        padding: 1rem;
    }

    @media (min-width: 768px) {
        .d {
            flex-basis: 50%; /* Half width on larger screens */
        }
    }

    .name {
        font-size: 2rem;
    }

    .bill {
        padding: 2.5rem;
        border: 2px solid rgba(0, 0, 0, 0.6);
        box-shadow: 2px 2px 2px rgba(0, 0, 0, 0.3);
    }

    .check {
        font-size: 2rem;
        width: 20px;
    }

    .text-input {
        width: 100%;
        padding: 10px;
        height: 50px;
        border: 1px solid gray;
        font-size: 2rem;
        border-radius: 5px;
        margin-bottom: 1rem;
        margin-top: 1rem;
    }

    .disable {
        width: 100%;
        padding: 10px;
        font-size: 2rem;
    }

    .check input[type="checkbox"] {
        transform: scale(1);
        width: 20px;
        height: 20px;
    }

    .gap {
        height: 2px;
        background-color: black;
    }

    .bill p {
        margin-bottom: 1rem;
    }

    img {
        height: auto; /* Set to auto for better responsiveness */
        max-width: 100%; /* Limit the maximum width */
    }

    /* Additional styling for error messages */
    .error-message {
        color: red;
        display: none; /* Hidden by default, will be shown with JS */
    }

    @media (max-width: 767px) {
        .name {
            font-size: 1.5rem; /* Smaller font on mobile */
        }

        .bill {
            padding: 1.5rem; /* Less padding on mobile */
        }
    }

    </style>
    <script>
        function validateForm() {
            var checkBox1 = document.getElementById('<%= CheckBox1.ClientID %>');
            var checkBox2 = document.getElementById('<%= CheckBox2.ClientID %>');
            var textBox = document.getElementById('<%= TextBox.ClientID %>');
    var submitButton = document.getElementById('<%= SubmitButton.ClientID %>');
            var errorLabel = document.getElementById('<%= AadharErrorLabel.ClientID %>');

            var aadharRegex = /^\d{12}$/;

            if (checkBox1.checked && checkBox2.checked && aadharRegex.test(textBox.value.trim())) {
                submitButton.disabled = false;
                submitButton.classList.add("btn");
                submitButton.classList.remove("disable");
                errorLabel.style.display = "none"; 
            } else {
                submitButton.disabled = true;
                submitButton.classList.add("disable");
                submitButton.classList.remove("btn");
                errorLabel.style.display = "block"; 
                errorLabel.innerText = "Please enter a valid 12-digit Aadhaar number.";
            }
        }
        function confirmBooking() {
            return confirm("Are you sure you want to confirm this booking?");
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
       
        <div class="content d">
            <asp:Image ID="BikeImage" runat="server" CssClass="bike-image" />
              <div class="gap"></div>
            <p><asp:Label ID="BikeNameLabel" runat="server" CssClass="name"></asp:Label></p>
            <p><asp:Label ID="BikePriceLabel" runat="server" CssClass="name"></asp:Label></p>
            <p class="name"> Pickup Date: <asp:Label ID="PickupDate" runat="server"></asp:Label></p>
            <p class="name">Delivery Date: <asp:Label ID="DeliveryDate" runat="server"></asp:Label></p>
            
            <asp:Label ID="ErrorMessageLabel" runat="server" CssClass="error-message" Visible="false"></asp:Label>
              <div class="gap"></div>
        </div>

        <div class="bill d">

            <p><asp:Label ID="Label1" runat="server" CssClass="name b"></asp:Label></p>
            <p><asp:Label ID="TotalAmountLabel" runat="server" CssClass="name b"></asp:Label></p>
            <p><asp:Label ID="TaxLabel" runat="server" CssClass="name b"></asp:Label></p>
            <p><asp:Label ID="NetAmountLabel" runat="server" CssClass="name b"></asp:Label></p>
            <asp:TextBox runat="server" Visible="false" id="amt"></asp:TextBox>
            
              <div class="gap" style="margin-top:1.5rem;margin-bottom:1.5rem"></div>
        
            <asp:CheckBox ID="CheckBox1" runat="server" Text=" Confirm that you are above 18 years of age" CssClass="check b" onchange="validateForm()" />
            <br />
            <asp:CheckBox ID="CheckBox2" runat="server" Text=" The original Driving license needs to be submitted at the time of pickup and the same will be returned at the time of dropping the vehicle." CssClass="check b" onchange="validateForm()" />
            <br />
            <hr />

           
            <asp:TextBox ID="TextBox" runat="server" CssClass="text-input" placeholder="Enter Aadhar number" onkeyup="validateForm()"></asp:TextBox>
            <br /> 
            <asp:Label ID="AadharErrorLabel" runat="server" CssClass="error-message" Visible="false"></asp:Label>
            <div class="gap" style="margin-top:1.5rem;margin-bottom:1.5rem"></div>
        <p style="color:red;font-size:1.6rem;"><sup>*</sup>Cancellation is not allowed after the pickup date</p>

            <asp:Button ID="SubmitButton" runat="server" Text="Submit Booking" style="width:100%;height:50px;" 
    OnClick="SubmitBooking" 
    OnClientClick="return confirm('Are you sure you want to submit the booking?');" />
          
            
        </div>
    </section>

    
</asp:Content>