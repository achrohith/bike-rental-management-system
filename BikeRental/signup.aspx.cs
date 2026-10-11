using BikeRental.APPCODE;
using log4net; 
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BikeRental
{
    public partial class signup : System.Web.UI.Page
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(signup));

        protected void Page_Load(object sender, EventArgs e)
        {
            logger.Info("Signup page loaded."); 
        }
        protected void Login_btn(object sender, EventArgs e)
        {
            logger.Info("login button clicked");
            Response.Redirect("login.aspx", false);

        }
        protected void button_click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (string.IsNullOrWhiteSpace(NameTextBox.Text) ||
                    string.IsNullOrWhiteSpace(PhoneTextBox.Text) ||
                    string.IsNullOrWhiteSpace(EmailTextBox.Text) ||
                    string.IsNullOrWhiteSpace(PasswordTextBox.Text))
                {
                    ErrorMessageLabel.Text = "All fields must be filled out.";
                    logger.Warn("Signup attempt failed: All fields must be filled out."); 
                    return;
                }

                string name = NameTextBox.Text.Trim();
                string email = EmailTextBox.Text.Trim();
                string phone = PhoneTextBox.Text.Trim();
                string password = PasswordTextBox.Text.Trim();

                if (!IsValidPhoneNumber(phone))
                {
                    ErrorMessageLabel.Text = "Invalid phone number format.";
                    logger.Warn("Signup attempt failed: Invalid phone number format for " + phone);
                    return;
                }

                if (IsEmailExists(email))
                {
                    ErrorMessageLabel.Text = "Email already exists. Please use a different email.";
                    logger.Warn("Signup attempt failed: Email already exists for " + email); 
                    return;
                }

                if (!IsValidPassword(password))
                {
                    ErrorMessageLabel.Text = "Password must be at least 8 characters long, contain at least one uppercase letter, and one digit.";
                    logger.Warn("Signup attempt failed: Invalid password format.");
                    return;
                }

                try
                {
                    BL ob = new BL();
                    ob.adddata(name, email, phone, password);

                    logger.Info("New user signed up: " + email);
                    Response.Redirect("login.aspx?signup=success");
                }
                catch (Exception ex)
                {
                    logger.Error("Error during signup: " + ex.Message, ex);
                    ErrorMessageLabel.Text = "An error occurred during signup. Please try again.";
                }
            }
            else
            {
                ErrorMessageLabel.Text = "Signup was unsuccessful. Please check your input.";
                logger.Warn("Signup was unsuccessful. Input validation failed."); 
            }

            clear();
        }

        private void clear()
        {
            NameTextBox.Text = string.Empty;
            EmailTextBox.Text = string.Empty;
            PhoneTextBox.Text = string.Empty;
            PasswordTextBox.Text = string.Empty;
            logger.Info("Input fields cleared."); 
        }

        private bool IsValidPhoneNumber(string phone)
        {
            return phone.All(char.IsDigit) && phone.Length >= 10;
        }

        private bool IsValidPassword(string password)
        {
            return password.Length == 8 &&
                   password.Any(char.IsUpper) &&
                   password.Any(char.IsLower) &&
                   password.Any(char.IsDigit);
        }

        private bool IsEmailExists(string email)
        {
            string query = "SELECT COUNT(*) FROM Users WHERE Email = @Email";

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    con.Open();
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }
    }
}
