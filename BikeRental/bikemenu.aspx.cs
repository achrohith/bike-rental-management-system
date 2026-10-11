
using BikeRental.APPCODE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using log4net; 

namespace BikeRental
{
    public partial class bikemenu : System.Web.UI.Page
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(bikemenu)); 

        protected void Page_Load(object sender, EventArgs e)
        {
            logger.Info("Page loaded: bikemenu"); 

            if (Session["User Email"] != null || Session["Admin Email"] != null)
            {
                if (!IsPostBack)
                {
                    LoadBikes();
                }
            }
            else
            {
                logger.Warn("Redirecting to login.aspx due to unauthorized access."); 
                Response.Redirect("login.aspx");
            }
        }

        private void LoadBikes()
        {
            BL ob = new BL();
            List<Bike> bikes = ob.GetBikes(12);
            BikeRepeater.DataSource = bikes;
            BikeRepeater.DataBind();

            logger.Info($"Loaded {bikes.Count} bikes."); 
        }

        protected void BookNowButton_Click(object sender, EventArgs e)
        {
            try
            {


                Button btn = (Button)sender;
                string bikeId = btn.CommandArgument;

                RepeaterItem item = (RepeaterItem)btn.NamingContainer;
                TextBox pickupDateTextBox = (TextBox)item.FindControl("TextBox1");
                TextBox deliveryDateTextBox = (TextBox)item.FindControl("TextBox2");

                string pickupDate = pickupDateTextBox.Text;
                string deliveryDate = deliveryDateTextBox.Text;

                if (string.IsNullOrEmpty(pickupDate) || string.IsNullOrEmpty(deliveryDate))
                {
                    logger.Warn("Booking attempt failed: pickup date or delivery date is missing.");
                    Response.Write("<script>alert('Please select both pickup date and delivery date');</script>");
                    return;
                }

                logger.Info($"Booking initiated for Bike ID: {bikeId}, Pickup Date: {pickupDate}, Delivery Date: {deliveryDate}");
                Response.Redirect($"bikkedetail.aspx?bikeId={bikeId}&pickupDate={pickupDate}&deliveryDate={deliveryDate}");
            }
            catch(Exception ex)
            {
                logger.Error("An error occurred in Book Now button: " + ex.Message, ex);
            }
        }
    }
}
