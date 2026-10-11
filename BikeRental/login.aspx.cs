
using BikeRental.APPCODE;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace BikeRental
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(WebForm4));

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["signup"] == "success")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Signup successful!, Please Login');", true);
                logger.Info("Signup successful alert shown to the user.");
            }
        }
        protected void Signup_btn(object sender, EventArgs e)
        {
            logger.Info("signup button is clicked");
            Response.Redirect("signup.aspx", false);
        }

        protected void login_btn(object sender, EventArgs e)
        {
            string email = EmailTextBox.Text.Trim();
            string password = PasswordTextBox.Text.Trim();
            logger.Info($"Login attempt for email: {email}");

            BL ob = new BL();
            string role = ob.Login(email, password);

            if (!string.IsNullOrEmpty(role))
            {
                if (role == "admin")
                {
                    Session["Admin Email"] = email;
                    logger.Info($"Admin login successful for email: {email}");
                    Response.Redirect("index.aspx");
                }
                else
                {
                    Session["User Email"] = email;
                    logger.Info($"User login successful for email: {email}");
                    Response.Redirect("index.aspx");
                }
            }
            else
            {
                ErrorMessageLabel.Text = "Invalid username or password";
                logger.Warn($"Invalid login attempt for email: {email}");
            }
        }
    }
}
