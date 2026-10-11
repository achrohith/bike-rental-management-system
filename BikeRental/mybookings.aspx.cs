
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using BikeRental.APPCODE;
using log4net;  

namespace BikeRental
{
    public partial class mybookings : System.Web.UI.Page
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(mybookings)); 

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User Email"] != null)
            {
                if (!IsPostBack)
                {
                    logger.Info("Loading bookings for user: " + Session["User Email"].ToString()); 
                    LoadUserBookings(Session["User Email"].ToString());
                }
            }
            else
            {
                logger.Warn("User not logged in. Redirecting to login.aspx."); 
                Response.Redirect("login.aspx");
            }
        }

        private void LoadUserBookings(string userEmail)
        {
            BL bookingBL = new BL();
            List<Booking> bookings = bookingBL.GetUserBookings(userEmail);
            BookingRepeater.DataSource = bookings;
            BookingRepeater.DataBind();
            logger.Info("Loaded " + bookings.Count + " bookings for user: " + userEmail);
        }

        BL ob = new BL();
        protected void CancelBooking_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string bookingId = btn.CommandArgument;
            RepeaterItem item = (RepeaterItem)btn.NamingContainer;

            logger.Info("Attempting to cancel booking ID: " + bookingId); 
            bool isCanceled = ob.CancelBooking(bookingId);
            Label message = (Label)item.FindControl("message");
            Label lblErrorMessage = (Label)item.FindControl("lblErrorMessage");

            if (isCanceled)
            {
                logger.Info("Booking ID: " + bookingId + " has been canceled successfully."); 
                Response.Write("<script>alert('Booking Cancelled.');</script>");
                lblErrorMessage.Text = "Booking Cancelled.";
                lblErrorMessage.Visible = true;
                Button btnCancelBooking = (Button)item.FindControl("btnCancelBooking");
                btnCancelBooking.Visible = false;
            }
            else
            {
                logger.Warn("Cancellation attempt for booking ID: " + bookingId + " failed. Cancellation not allowed after pickup date."); 
                Response.Write("<script>alert('Cancellation is not allowed after the pickup date.');</script>");
                Button btnCancelBooking = (Button)item.FindControl("btnCancelBooking");
                btnCancelBooking.Visible = false;
            }
            LoadUserBookings(Session["User Email"].ToString());
        }
    }
}
