<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="signup.aspx.cs" Inherits="BikeRental.signup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link rel="stylesheet" href="content/master.css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.2/css/all.min.css"/>
</head>
<body>
      <div class="login-form-container signup-form-container">
        <a href="index.aspx"><span class="fas fa-times" id="close-login-form"></span></a>
        <form id="form1" runat="server">
            <h3>SIGNUP</h3>
            <asp:TextBox runat="server" ID="NameTextBox" placeholder="Name" CssClass="box" />
            
        
             <asp:TextBox runat="server" ID="PhoneTextBox"  placeholder="Phone No" CssClass="box" />
            <asp:TextBox runat="server" ID="EmailTextBox" TextMode="Email" placeholder="Email" CssClass="box" />
           
            <asp:TextBox runat="server" ID="PasswordTextBox" TextMode="Password" placeholder="Create Password" CssClass="box" />
            <asp:Label runat="server" ID="ErrorMessageLabel" CssClass="error-message" ForeColor="Red" FontSize="20px"/>
            <asp:Button runat="server" ID="SignupButton" Text="SIGNUP" CssClass="btn" OnClick="button_click" />
            <p>Already a customer?<asp:Button runat="server" ID="login" OnClick="Login_btn" Text="Login" style="color:#f9d806;background-color:white;" /></p>

        </form>
    </div>
 
     
        
    
</body>
</html>
