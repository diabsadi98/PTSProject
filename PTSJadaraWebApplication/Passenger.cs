using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
namespace PTSJadaraWebApplication
{
    public class Passenger
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-RM0C6BI;Initial Catalog=PTSJADARADB;Integrated Security=True");

        public int Register(string PassengerNID, string PassengerFullName, string PassengerAge, string PassengerMobile, string Passengerloginname, string PassengerPassword)
        {
            int effectedrows = 0;
            try
            {
                if(con.State== ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandText = "insert into Passenger values (@PassengerNID, @PassengerFullName, @PassengerAge, @PassengerMobile, @Passengerloginname, @PassengerPassword)";
                com.Parameters.AddWithValue("@PassengerNID", PassengerNID);
                com.Parameters.AddWithValue("@PassengerFullName", PassengerFullName);
                com.Parameters.AddWithValue("@PassengerAge", PassengerAge);
                com.Parameters.AddWithValue("@PassengerMobile", PassengerMobile);
                com.Parameters.AddWithValue("@Passengerloginname", Passengerloginname);
                com.Parameters.AddWithValue("@PassengerPassword", PassengerPassword);

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

        public long Login(string Passengerloginname, string PassengerPassword)
        {
            long PassengerNID = 0;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandText = "select PassengerNID from Passenger where Passengerloginname = @Passengerloginname and PassengerPassword = @PassengerPassword";
                com.Parameters.AddWithValue("@Passengerloginname", Passengerloginname);
                com.Parameters.AddWithValue("@PassengerPassword", PassengerPassword);

                SqlDataReader reader = com.ExecuteReader();

                if(reader.Read())
                {
                    PassengerNID = Convert.ToInt64(reader["PassengerNID"].ToString());
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
            return PassengerNID;
        }


        public string GetFullName(string PassengerNID)
        {
            string PassengerFullName = "";
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandText = "select PassengerFullName from Passenger where PassengerNID = @PassengerNID";
                com.Parameters.AddWithValue("@PassengerNID", PassengerNID);

                SqlDataReader reader = com.ExecuteReader();

                if (reader.Read())
                {
                    PassengerFullName = reader["PassengerFullName"].ToString();
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
            return PassengerFullName;
        }

        public List<string> GetPassengers()
        {
            List<string> Passengers = new List<string>();
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandText = "select PassengerFullName ,PassengerNID  from Passenger";

                SqlDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    Passengers.Add(reader["PassengerFullName"].ToString());
                    Passengers.Add(reader["PassengerNID"].ToString());
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
            return Passengers;
        }
    }
}