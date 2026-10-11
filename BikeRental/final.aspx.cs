
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using log4net;

namespace BikeRental
{
    public partial class final : System.Web.UI.Page
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(final)); 

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User Email"] == null)
            {
                logger.Warn("User not logged in. Redirecting to login.aspx."); 
                Response.Redirect("login.aspx");
            }
            else
            {
                logger.Info("User " + Session["User Email"].ToString() + " accessed the final page.");
            }
        }

        protected void View(object sender, EventArgs e)
        {
            logger.Info("User " + Session["User Email"].ToString() + " requested to view their bookings."); 
            Response.Redirect("mybookings.aspx");
        }
    }
}
