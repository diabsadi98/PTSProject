using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace PTSJadaraWebApplication
{
    public class Reservation
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-RM0C6BI;Initial Catalog=PTSJADARADB;Integrated Security=True");

        public int AddReservation(string TripID, string PassengerNID, string QRCode)
        {
            int effectedrows = 0;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandText = "insert into Reservation (TripID, PassengerNID, QRCode) values (@TripID, @PassengerNID, @QRCode)";
                com.Parameters.AddWithValue("@TripID", TripID);
                com.Parameters.AddWithValue("@PassengerNID", PassengerNID);
                com.Parameters.AddWithValue("@QRCode", QRCode);
                effectedrows = com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return effectedrows;
        }

        public DataTable GetReservation(string PassengerNID , string TripDate)
        {
            DataTable Trips = new DataTable(); ;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandText = "select  r.ReserveID , r.PassengerNID , t.FromCity , t.ToCity , r.QRCode  from Reservation as r join Trips as t on r.TripID = t.TripID where t.TripDate = @TripDate and r.PassengerNID = @PassengerNID";
                com.Parameters.AddWithValue("@TripDate", TripDate);
                com.Parameters.AddWithValue("@PassengerNID", PassengerNID);
                SqlDataAdapter adapter = new SqlDataAdapter(com);
                adapter.Fill(Trips);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return Trips;
        }

        public DataTable GetReservationByID( string TripDate)
        {
            DataTable Trips = new DataTable(); ;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandText = "select  r.ReserveID , r.PassengerNID , t.FromCity , t.ToCity , r.QRCode  from Reservation as r join Trips as t on r.TripID = t.TripID where t.TripDate = @TripDate ";
                com.Parameters.AddWithValue("@TripDate", TripDate);

                SqlDataAdapter adapter = new SqlDataAdapter(com);
                adapter.Fill(Trips);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return Trips;
        }
        public int GetCurrentPassengerCount(string TripID)
        {
            int CurrentPassengerCount = 0;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandText = "select count(*) from Reservation where TripID = @TripID";
                com.Parameters.AddWithValue("@TripID", TripID);
  
                CurrentPassengerCount =Convert.ToInt32( com.ExecuteScalar());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return CurrentPassengerCount;
        }
    }
}