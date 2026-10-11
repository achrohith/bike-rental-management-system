
using log4net; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BikeRental
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(Site1));

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin Email"] != null)
            {
                AdminLinks.Visible = true;
                UserLinks.Visible = false;
                LoginButton.Visible = false;
                LogoutButton.Visible = true;
                logger.Info("Admin user detected. Admin links displayed."); 
            }

            if (Session["User Email"] != null)
            {
                AdminLinks.Visible = false;
                UserLinks.Visible = true;
                LoginButton.Visible = false;
                LogoutButton.Visible = true;
                logger.Info("Regular user detected. User links displayed."); 
            }
        }
        protected void Home_btn(object sender, EventArgs e)
        {
            logger.Info("Home button is clicked");
            Response.Redirect("index.aspx");
        }
        protected void About_btn(object sender, EventArgs e)
        {
            logger.Info("About button is clicked");
            Response.Redirect("about.aspx");
        }
        protected void Contact_btn(object sender, EventArgs e)
        {
            logger.Info("Contact button is clicked");
            Response.Redirect("contact.aspx");

        }
        protected void LoginButton_Click(object sender, EventArgs e)
        {
            logger.Info("Login button clicked. Redirecting to login.aspx."); 
            Response.Redirect("login.aspx",false);
        }

        protected void LogoutButton_Click(object sender, EventArgs e)
        {
            logger.Info("Logout button clicked. Clearing session and redirecting to index.aspx."); 
            Session.Clear();
            Session.Abandon();
            Response.Redirect("index.aspx",false);
        }

        protected void Viewbooking(object sender, EventArgs e)
        {
            if (Session["User Email"] != null)
            {
                logger.Info("Redirecting to mybookings.aspx."); 
                Response.Redirect("mybookings.aspx",false);
            }
            else
            {
                logger.Warn("User not authenticated. Redirecting to login.aspx from Viewbooking."); 
                Response.Redirect("login.aspx",false);
            }
        }

        protected void Showbikes(object sender, EventArgs e)
        {
            if (Session["User Email"] != null)
            {
                logger.Info("Redirecting to bikemenu.aspx."); 
                Response.Redirect("bikemenu.aspx",false);
            }
            else
            {
                logger.Warn("User not authenticated. Redirecting to login.aspx from Showbikes."); 
                Response.Redirect("login.aspx",false);
            }
        }
    }
}
