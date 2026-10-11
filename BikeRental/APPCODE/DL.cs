using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
namespace BikeRental.APPCODE
{
    public class DL
    {


        string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;


        public void savedata(string query)
        {
            SqlConnection con = new SqlConnection(cs);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
        }
        public string ValidateUser(string email, string password)
        {
            string role = "";
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                string query = "SELECT role FROM users WHERE email = @Email AND password = @Password";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        role = reader["role"].ToString();
                    }
                }
            }
            return role;
        }


        public SqlDataReader GetBikes(int maxBikeId)
        {
            SqlConnection conn = new SqlConnection(cs);
            string query = "SELECT * FROM bikes WHERE bike_id <= @MaxBikeId";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@MaxBikeId", maxBikeId);
            conn.Open();
            return cmd.ExecuteReader();





        }
        public SqlDataReader GetBikeDetails(int bikeId)
        {
            SqlConnection conn = new SqlConnection(cs);
            string query = "SELECT * FROM bikes WHERE bike_id = @BikeId";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@BikeId", bikeId);
            conn.Open();
            return cmd.ExecuteReader();
        }
        public bool CreateBooking(string userEmail, int bikeId, DateTime pickupDate, DateTime deliveryDate, decimal payableAmount, DateTime currentDateTime, string aadharNumber)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                string insertBookingQuery = "INSERT INTO bookings (user_id, bike_id, pickup_date, delivery_date, payable_amount, currentdate, aadhar_number) VALUES (@UserEmail, @BikeId, @PickupDate, @DeliveryDate, @PayableAmount, @currentDateTime, @aadharNumber)";

                using (SqlCommand cmd = new SqlCommand(insertBookingQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@UserEmail", userEmail);
                    cmd.Parameters.AddWithValue("@BikeId", bikeId);
                    cmd.Parameters.AddWithValue("@PickupDate", pickupDate);
                    cmd.Parameters.AddWithValue("@DeliveryDate", deliveryDate);
                    cmd.Parameters.AddWithValue("@PayableAmount", payableAmount);
                    cmd.Parameters.AddWithValue("@currentDateTime", currentDateTime);
                    cmd.Parameters.AddWithValue("@aadharNumber", aadharNumber);


                    int result = cmd.ExecuteNonQuery();
                    return result > 0; 
                }
            }
        }

        public void DecreaseBikeAvailability(int bikeId)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                string updateAvailabilityQuery = "UPDATE Bikes SET availability = availability - 1 WHERE bike_id = @BikeId";

                using (SqlCommand cmd = new SqlCommand(updateAvailabilityQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@BikeId", bikeId);
                    cmd.ExecuteNonQuery();
                }
            }
        }




        public List<Booking> GetUserBookings(string userEmail)
        {
            List<Booking> bookings = new List<Booking>();

            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = "SELECT bk.booking_id, b.bike_id, b.bike_name, bk.pickup_date, bk.delivery_date, " +
                               "bk.payable_amount, bk.currentdate " +
                               "FROM bookings bk " +
                               "JOIN bikes b ON bk.bike_id = b.bike_id " +
                               "WHERE bk.user_id = @UserEmail " +
                               "AND canceled='N'" +
                               "ORDER BY bk.currentdate DESC"; 
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserEmail", userEmail);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Booking booking = new Booking
                        {
                            BookingId = Convert.ToInt32(reader["booking_id"]),
                            BikeId = Convert.ToInt32(reader["bike_id"]),
                            BikeName = reader["bike_name"].ToString(),
                            PickupDate = Convert.ToDateTime(reader["pickup_date"]),
                            DeliveryDate = Convert.ToDateTime(reader["delivery_date"]),
                            PayableAmount = Convert.ToDecimal(reader["payable_amount"]),
                            DateOfBooking = Convert.ToDateTime(reader["currentdate"])
                        };
                        bookings.Add(booking);
                    }
                }
            }

            return bookings;
        }
        public List<Booking> GetBookings(string userEmail)
        {
            List<Booking> bookings = new List<Booking>();

            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = "SELECT bk.booking_id, bk.user_id, b.bike_id, b.bike_name, bk.pickup_date, bk.delivery_date, " +
               "bk.payable_amount, bk.currentdate " +
               "FROM bookings bk " +
               "JOIN bikes b ON bk.bike_id = b.bike_id " +
               "ORDER BY bk.currentdate DESC";
                SqlCommand cmd = new SqlCommand(query, conn);
                
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Booking booking = new Booking
                        {
                            BookingId = reader["booking_id"] != DBNull.Value ? Convert.ToInt32(reader["booking_id"]) : 0,
                            BikeId = reader["bike_id"] != DBNull.Value ? Convert.ToInt32(reader["bike_id"]) : 0,
                            UserEmail = reader["user_id"] != DBNull.Value ? reader["user_id"].ToString() : string.Empty,

                            BikeName = reader["bike_name"] != DBNull.Value ? reader["bike_name"].ToString() : string.Empty,
                            PickupDate = reader["pickup_date"] != DBNull.Value ? Convert.ToDateTime(reader["pickup_date"]) : DateTime.MinValue,
                            //PickupDate = reader["pickup_date"] != DBNull.Value ? Convert.ToDateTime(reader["pickup_date"]) : DateTime.MinValue,

                            DeliveryDate = reader["delivery_date"] != DBNull.Value ? Convert.ToDateTime(reader["delivery_date"]) : DateTime.MinValue,
                            PayableAmount = reader["payable_amount"] != DBNull.Value ? Convert.ToDecimal(reader["payable_amount"]) : 0m,
                            DateOfBooking = reader["currentdate"] != DBNull.Value ? Convert.ToDateTime(reader["currentdate"]) : DateTime.MinValue
                        };
                        bookings.Add(booking);
                    }
                }
            }

            return bookings;
        }

        public BookingDetails GetBookingDetails(string bookingId)
        {
            BookingDetails bookingDetails = new BookingDetails();

            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                string query = "SELECT Pickup_Date, Bike_Id FROM Bookings WHERE Booking_Id = @BookingId";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@BookingId", bookingId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        ;
                        if (reader.Read())
                        {
                            bookingDetails.PickupDate = reader.GetDateTime(0);
                            bookingDetails.BikeId = reader.GetInt32(1).ToString();
                        }
                    }
                }
            }

            return bookingDetails;
        }

        public void CancelBooking(string bookingId)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
               
                string updateBookingQuery = "UPDATE Bookings SET Canceled = 'Y' WHERE Booking_Id = @BookingId";
                using (SqlCommand cmd = new SqlCommand(updateBookingQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@BookingId", bookingId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void IncreaseBikeAvailability(string bikeId)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                
                string updateAvailabilityQuery = "UPDATE Bikes SET Availability = Availability + 1 WHERE Bike_Id = @BikeId";
                using (SqlCommand cmd = new SqlCommand(updateAvailabilityQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@BikeId", bikeId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public DataTable GetAllBikes()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = "SELECT bike_id, bike_name, availability, max_availability FROM Bikes";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }
        public void IncreaseAvailability(int bikeId)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = @"
                    UPDATE Bikes
                    SET availability = CASE
                        WHEN availability < max_availability THEN availability + 1
                        ELSE availability
                    END
                    WHERE bike_id = @bikeId";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@bikeId", bikeId);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void DecreaseAvailability(int bikeId)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = @"
                    UPDATE Bikes
                    SET availability = CASE
                        WHEN availability > 0 THEN availability - 1
                        ELSE availability
                    END
                    WHERE bike_id = @bikeId";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@bikeId", bikeId);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }







    }


       
     

        
    
    public class BookingDetails
    {
        public DateTime PickupDate { get; set; }
        public string BikeId { get; set; } 
    }


        public class Booking
        {

            public string UserEmail { get; set; }
            public int BookingId { get; set; }
            public int BikeId { get; set; }
            public string BikeName { get; set; }
            public DateTime PickupDate { get; set; }
            public DateTime DeliveryDate { get; set; }
            public decimal PayableAmount { get; set; }
            public DateTime DateOfBooking { get; set; } 
        }





    }
