
using log4net.Repository.Hierarchy;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BikeRental
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(WebForm1));

        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.Config.XmlConfigurator.Configure();
            logger.Info("Page loaded: index.aspx");
        }

        protected void explore_btn(object sender, EventArgs e)
        {
            try
            {
                
                logger.Info("Explore button clicked.");

                if (Session["User Email"] != null || Session["Admin Email"] != null)
                {
                    logger.Info("Redirecting to bikemenu.aspx.");
                    Response.Redirect("bikemenu.aspx", false);
                }
                else
                {
                    logger.Warn("User not authenticated. Redirecting to login.aspx.");
                    Response.Redirect("login.aspx", false);
                }
            }
            catch (Exception ex)
            {
               
                logger.Error("An error occurred in explore_btn: " + ex.Message, ex);
            }
        }
    }
}

