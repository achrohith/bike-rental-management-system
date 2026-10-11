using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using Microsoft.SqlServer.Server;
using static BikeRental.APPCODE.BL;

namespace BikeRental.APPCODE
{
    public class BL

    {

        DL ob = new DL();

        public object Response { get; private set; }

        public void adddata(string name, String email, string phone, string password)
        {
            string q = "INSERT INTO users (name,email,phone,password) values('" + name + "','" + email + "','" + phone + "','" + password + "')";
            ob.savedata(q);

        }


        public string Login(string email, string password)
        {
            return ob.ValidateUser(email, password);
        }

        public List<Bike> GetBikes(int maxBikeId)
        {
            List<Bike> bikes = new List<Bike>();
            using (SqlDataReader reader = ob.GetBikes(maxBikeId))
            {
                while (reader.Read())
                {
                    Bike bike = new Bike
                    {
                        BikeId = Convert.ToInt32(reader["bike_id"]),
                        BikeName = reader["bike_name"].ToString(),
                        BikePrice = Convert.ToDecimal(reader["bike_price"]),
                        Availability = Convert.ToInt32(reader["availability"])
                    };
                    bikes.Add(bike);
                }
            }
            return bikes;

        }


        public Bike GetBikeDetails(int bikeId)
        {
            using (SqlDataReader reader = ob.GetBikeDetails(bikeId))
            {
                if (reader.Read())
                {
                    Bike bike = new Bike
                    {
                        BikeId = Convert.ToInt32(reader["bike_id"]),
                        BikeName = reader["bike_name"].ToString(),
                        BikePrice = Convert.ToDecimal(reader["bike_price"]),
                        Availability = Convert.ToInt32(reader["availability"])
                    };
                    return bike;
                }
            }
            return null; 
        }

        public bool CreateBooking(string userEmail, int bikeId, DateTime pickupDate, DateTime deliveryDate, decimal payableAmount, DateTime currentDateTime, string aadharNumber)
        {
            
            bool isBookingSuccessful = ob.CreateBooking(userEmail, bikeId, pickupDate, deliveryDate, payableAmount, currentDateTime, aadharNumber);

            if (isBookingSuccessful)
            {
                
                ob.DecreaseBikeAvailability(bikeId);
            }

            return isBookingSuccessful; 
        }

        public List<Booking> GetUserBookings(string userEmail)
        {
            return ob.GetUserBookings(userEmail);
        }
        public List<Booking> GetBookings(string userEmail)
        {
            return ob.GetBookings(userEmail);
        }
      


        public bool CancelBooking(string bookingId)
        {
            
            BookingDetails bookingDetails =ob.GetBookingDetails(bookingId);

            
            if (DateTime.Now < bookingDetails.PickupDate)
            {
                
                ob.CancelBooking(bookingId);
               
                ob.IncreaseBikeAvailability(bookingDetails.BikeId);
                return true; 
            }

            return false; 
        }
        public DataTable GetAllBikes()
        {
            return ob.GetAllBikes();
        }
        public void IncreaseAvailability(int bikeId)
        {
            ob.IncreaseAvailability(bikeId);
        }
        public void DecreaseAvailability(int bikeId)
        {
            ob.DecreaseAvailability(bikeId);
        }





















    }
   


    public class Bike
        {
            public int BikeId { get; set; }
            public string BikeName { get; set; }
            public decimal BikePrice { get; set; }
            public int Availability { get; set; }




        
    }
  

}

