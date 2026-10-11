
using BikeRental.APPCODE;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.UI;
using log4net;

namespace BikeRental
{
    public partial class bikkedetail : System.Web.UI.Page
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(bikkedetail));

        protected void Page_Load(object sender, EventArgs e)
        {
            logger.Info("Page loaded: bikkedetail"); 

            if (!IsPostBack)
            {
                string bikeIdStr = Request.QueryString["BikeId"];
                string pickupDateStr = Request.QueryString["PickupDate"];
                string deliveryDateStr = Request.QueryString["DeliveryDate"];

                if (string.IsNullOrEmpty(bikeIdStr) || string.IsNullOrEmpty(pickupDateStr) || string.IsNullOrEmpty(deliveryDateStr))
                {
                    logger.Warn("Redirecting to bikemenu.aspx due to missing query parameters.");
                    Response.Redirect("bikemenu.aspx");
                }

                if (int.TryParse(bikeIdStr, out int bikeId) &&
                    DateTime.TryParse(pickupDateStr, out DateTime pickupDate) &&
                    DateTime.TryParse(deliveryDateStr, out DateTime deliveryDate))
                {
                    LoadBikeDetails(bikeId, pickupDate, deliveryDate);
                }
                else
                {
                    ErrorMessageLabel.Text = "Required information is missing or invalid.";
                    ErrorMessageLabel.Visible = true;
                    logger.Error("Invalid query parameters."); 
                }
            }
        }

        public void LoadBikeDetails(int bikeId, DateTime pickupDate, DateTime deliveryDate)
        {
            decimal netAmount = 0;
            BL bikeBL = new BL();
            Bike bikeDetails = bikeBL.GetBikeDetails(bikeId);

            if (bikeDetails != null)
            {
                BikeNameLabel.Text = bikeDetails.BikeName;
                BikePriceLabel.Text = $"Price: {bikeDetails.BikePrice:C}/day";
                BikeImage.ImageUrl = $"bike/{bikeDetails.BikeId}.jpg";

                PickupDate.Text = pickupDate.ToString("dd-MM-yyyy");
                DeliveryDate.Text = deliveryDate.ToString("dd-MM-yyyy");

                TimeSpan duration = deliveryDate - pickupDate;
                int numberOfDays = (int)duration.TotalDays + 1;

                decimal totalAmount = numberOfDays * bikeDetails.BikePrice;
                decimal taxRate = 0.18m;
                decimal taxAmount = totalAmount * taxRate;

                netAmount = totalAmount + taxAmount;

                amt.Text = netAmount.ToString();

                TotalAmountLabel.Text = $"Total Amount: {totalAmount:C}";
                TaxLabel.Text = $"Tax (18%): {taxAmount:C}";
                NetAmountLabel.Text = $"Net Amount: {netAmount:C}";

                logger.Info($"Bike details loaded for Bike ID: {bikeId}. Total Amount: {totalAmount:C}, Net Amount: {netAmount:C}"); 
            }
            else
            {
                ErrorMessageLabel.Text = "Bike details not available.";
                ErrorMessageLabel.Visible = true;
                logger.Warn($"No bike details found for Bike ID: {bikeId}."); 
            }
        }

        protected void SubmitBooking(object sender, EventArgs e)

            
        {

            try
            {
                string userEmail = Session["User Email"]?.ToString();
                int bikeId = Convert.ToInt32(Request.QueryString["BikeId"]);
                DateTime pickupDate = DateTime.ParseExact(PickupDate.Text, "dd-MM-yyyy", null);
                DateTime deliveryDate = DateTime.ParseExact(DeliveryDate.Text, "dd-MM-yyyy", null);
                decimal payableAmount = Convert.ToDecimal(amt.Text);
                string aadharNumber = TextBox.Text;
                DateTime currentDateTime = DateTime.Now;

                BL bikeBL = new BL();

                bool isBookingSuccessful = bikeBL.CreateBooking(userEmail, bikeId, pickupDate, deliveryDate, payableAmount, currentDateTime, aadharNumber);

                if (isBookingSuccessful)
                {
                    logger.Info($"Booking successful for user: {userEmail}, Bike ID: {bikeId}. Redirecting to final.aspx.");
                    Response.Redirect("final.aspx");
                }
                else
                {
                    ErrorMessageLabel.Text = "There was an error creating your booking. Please try again.";
                    ErrorMessageLabel.Visible = true;
                    logger.Error("Booking creation failed.");
                }
            }
            catch(Exception ex)
            {
                logger.Error("error occurred in submit booking " + ex.Message, ex);
            }
        }
    }
}
