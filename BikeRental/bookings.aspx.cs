using BikeRental.APPCODE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BikeRental
{
    public partial class bookings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                LoadUserBookings(Session["Admin Email"].ToString());
            }

        }

        private void LoadUserBookings(string userEmail)
        {
            BL bookingBL = new BL();
            List<Booking> bookings = bookingBL.GetBookings(userEmail);
            BookingRepeater.DataSource = bookings;
            BookingRepeater.DataBind();
        }
    }
}