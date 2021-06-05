using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
namespace PTSJadaraWebApplication
{
    public class Location
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-RM0C6BI;Initial Catalog=PTSJADARADB;Integrated Security=True");

        public string GetLocation(string TripID)
        {
            string TripLocation = "";
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandText = "select TripLocation from Location where TripID = @TripID";
                com.Parameters.AddWithValue("@TripID", TripID);
                SqlDataReader reader = com.ExecuteReader();

                if (reader.Read())
                {
                    TripLocation = reader["TripLocation"].ToString();
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
            return TripLocation;
        }
    }
}