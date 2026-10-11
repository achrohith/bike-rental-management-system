<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="contact.aspx.cs" Inherits="BikeRental.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="contact">
        <div class="contact-location">
            <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3881.967475447189!2d74.78446427328514!3d13.35229853699919!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x3bbca593194d57f5%3A0xb8179da70dd8ad27!2sTiger%20Circle%20(TC)!5e0!3m2!1sen!2sin!4v1713071074613!5m2!1sen!2sin" width="600" height="450" style="border:0;" allowfullscreen="" loading="lazy" referrerpolicy="no-referrer-when-downgrade"></iframe>
        </div>
        <div class="contact-container">
            <p style="margin-top:2rem;" class="head">Contact Us</p>
            <p style="font-size:1.6rem;">
                Have questions or need assistance? Feel free to get in touch with us! At BIKERENTAL, we're committed to providing exceptional customer service and support. Whether you have inquiries about our bike rental services, need help with booking, or want to share feedback, our team is here to assist you every step of the way.
            </p>
            <div class="contacts">
                <div>
                    <a href="tel:+919035037695"><i class="fas fa-phone"></i>+91-9035037695</a>
                </div>
                <div style="text-align:center;">
                    <a href="mailto:rohithach113@gmail.com"><i class="fas fa-envelope"></i>rentabike@gmail.com</a>
                </div>
            </div>
        </div>
    </section>
</asp:Content>