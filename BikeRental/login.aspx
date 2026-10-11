<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="BikeRental.WebForm4" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link rel="stylesheet" href="content/master.css" />
     <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.2/css/all.min.css"/>
 
  
</head>
<body>
    <div class="login-form-container">
        <a href="index.aspx">
            <span class="fas fa-times" id="close-login-form"></span>
        </a>
        <form id="form1" runat="server">
            <h3>LOGIN</h3>
            <asp:TextBox ID="EmailTextBox" type="email" placeholder="Email" class="box" runat="server" />
            <asp:TextBox ID="PasswordTextBox" type="password"  placeholder="Password" class="box" runat="server" />
                   <asp:Label runat="server" ID="ErrorMessageLabel" CssClass="error-message" ForeColor="Red" FontSize="20px"/>
         
            <asp:Button Text="LOGIN" class="btn" runat="server"  OnClick="login_btn"/>
            <p style="margin-top:4px;">
                Don't have an account? <!--<a class="signup-btn" href="signup.aspx">Signup</a>-->
                <asp:Button runat="server" ID="signup" Text="Signup" OnClick="Signup_btn" style="color:#f9d806;background-color:white;"/>
            </p>
         </form>
        
    </div>
</body>

</html>