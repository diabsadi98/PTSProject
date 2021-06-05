using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace PTSJadaraWebApplication
{
    public class Trips
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-RM0C6BI;Initial Catalog=PTSJADARADB;Integrated Security=True");

        public int AddTrip(string FromCity, string ToCity, string PassengerNo, string AdultPrice, string ChildPrice, string StartTime, string EndTime, string TripDate, string DriverNID, string AdminUsername)
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
                com.CommandText = "insert into Trips (FromCity, ToCity, PassengerNo, AdultPrice, ChildPrice, StartTime, EndTime, TripDate, DriverNID, AdminUsername) values (@FromCity, @ToCity, @PassengerNo, @AdultPrice, @ChildPrice, @StartTime, @EndTime, @TripDate, @DriverNID, @AdminUsername)";
                com.Parameters.AddWithValue("@FromCity", FromCity);
                com.Parameters.AddWithValue("@ToCity", ToCity);
                com.Parameters.AddWithValue("@PassengerNo", PassengerNo);
                com.Parameters.AddWithValue("@AdultPrice", AdultPrice);
                com.Parameters.AddWithValue("@ChildPrice", ChildPrice);
                com.Parameters.AddWithValue("@StartTime", StartTime);

                com.Parameters.AddWithValue("@EndTime", EndTime);
                com.Parameters.AddWithValue("@TripDate", TripDate);
                com.Parameters.AddWithValue("@DriverNID", DriverNID);
                com.Parameters.AddWithValue("@AdminUsername", AdminUsername);

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

        public DataTable GetTrips(string TripDate)
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
                com.CommandText = "select t.TripID [ID] , t.FromCity , t.ToCity , t.AdultPrice , t.ChildPrice , t.StartTime , t.EndTime , d.DriverFullName , a.FullName from Trips as t inner join Driver as d on t.DriverNID = d.DriverNID join Admin as a on t.AdminUsername = a.Username where t.TripDate = @TripDate";
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


        public DataTable GetTripsforReserve(string FromCity , string ToCity, string TripDate)
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
                com.CommandText = "select t.TripID [ID] , t.FromCity , t.ToCity , t.AdultPrice , t.ChildPrice , t.StartTime , t.EndTime , d.DriverFullName , a.FullName from Trips as t inner join Driver as d on t.DriverNID = d.DriverNID join Admin as a on t.AdminUsername = a.Username where t.TripDate = @TripDate and t.FromCity = @FromCity and t.ToCity = @ToCity";
                com.Parameters.AddWithValue("@TripDate", TripDate);
                com.Parameters.AddWithValue("@FromCity", FromCity);
                com.Parameters.AddWithValue("@ToCity", ToCity);
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


        public DataTable GetTripsByDate( string TripDate)
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
                com.CommandText = "select t.TripID [ID] , t.FromCity , t.ToCity , t.AdultPrice , t.ChildPrice , t.StartTime , t.EndTime , d.DriverFullName , a.FullName from Trips as t inner join Driver as d on t.DriverNID = d.DriverNID join Admin as a on t.AdminUsername = a.Username where t.TripDate = @TripDate ";
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
        public int GetPassengerNo(string TripID)
        {
           int PassengerNo = 0;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandText = "select PassengerNo from Trips where TripID = @TripID";
                com.Parameters.AddWithValue("@TripID", TripID);
                SqlDataReader reader = com.ExecuteReader();

                if (reader.Read())
                {
                    PassengerNo = Convert.ToInt32(reader["PassengerNo"]);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return PassengerNo;
        }


        public int UpdateTrip(string FromCity, string ToCity, string PassengerNo, string AdultPrice, string ChildPrice, string StartTime, string EndTime, string TripDate, string DriverNID, string AdminUsername , string TripID)
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
                com.CommandText = "update Trips set FromCity = @FromCity , ToCity = @ToCity, PassengerNo = @PassengerNo , AdultPrice = @AdultPrice , ChildPrice = @ChildPrice , StartTime = @StartTime , EndTime = @EndTime , TripDate = @TripDate , DriverNID = @DriverNID , AdminUsername = @AdminUsername where TripID = @TripID";
                com.Parameters.AddWithValue("@FromCity", FromCity);
                com.Parameters.AddWithValue("@ToCity", ToCity);
                com.Parameters.AddWithValue("@PassengerNo", PassengerNo);
                com.Parameters.AddWithValue("@AdultPrice", AdultPrice);
                com.Parameters.AddWithValue("@ChildPrice", ChildPrice);
                com.Parameters.AddWithValue("@StartTime", StartTime);

                com.Parameters.AddWithValue("@EndTime", EndTime);
                com.Parameters.AddWithValue("@TripDate", TripDate);
                com.Parameters.AddWithValue("@DriverNID", DriverNID);
                com.Parameters.AddWithValue("@AdminUsername", AdminUsername);
                com.Parameters.AddWithValue("@TripID", TripID);
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

        public List<string> GetTripIDs()
        {
            List<string> TripIDs = new List<string>();
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandText = "select TripID from Trips";

                SqlDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    TripIDs.Add(reader["TripID"].ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return TripIDs;
        }
    }
}