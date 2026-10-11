<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="BikeRental.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="home" id="home">
        <div class="home-container">
            <div class="img-container">
                <img src="img/gt.jpg">
            </div>
            <div class="home-text">
                <p>Explore the area, <br>by riding yourself</p>
                <div class="gap"></div>
                <asp:button Id="xploreButton" Text="EXPLORE" runat="server" onclick="explore_btn" class="btn"/>
            </div>
        </div>
    </section>
    <section class="icon-header-container">
        <p>Why <span>RENTA</span>BIKE?</p>
    </section>
    <section class="icon-container">
        <div class="icons">
            <img src="img/download.png">

            <div class="content">
                <span>24/7 Customer Support</span>
                <p>Our support team is available round the clock to assist customers.</p>
            </div>
        </div>
        <div class="icons">
            <img src="img/deposit.svg">
            <div class="content">
                <span>No Security Deposit</span>
                <p>Rent a bike without paying any security deposit upfront.</p>
            </div>
        </div>
        <div class="icons">
            <img src="img/Safe-Rides-Icon.svg">
            <div class="content">
                <span>Safe Rides</span>
                <p>Your safety is our priority by sanitizing all bikes before every use</p>
            </div>
        </div>
    </section>
    <section class="how">
        <p class="how-text">How <span>RENTA</span>BIKE works?</p>
        <div class="how-content">
            <div class="text-content">
                <div class="steps">
                    <img src="img/explore.svg">
                    <p><span>Explore and select</span><br>Choose from our wide range of bikes, select the pickup and return dates.</p>
                </div>
                <div class="steps">
                    <img src="img/book-confirm.svg">
                    <p><span>Book and confirm</span><br>Book your desired bike with just a few clicks.</p>
                </div>
                <div class="steps">
                    <img src="img/experience.svg">
                    <p><span>Experience a hassle-free ride.</span><br>Enjoy your premium driving experience with our top-quality service.</p>
                </div>
            </div>
            <div class="img">
                <img src="img/works.png">
            </div>
        </div>
    </section>
</asp:Content>