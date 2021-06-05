using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
namespace PTSJadaraWebApplication
{
    public class Driver
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-RM0C6BI;Initial Catalog=PTSJADARADB;Integrated Security=True");

        public int AddDriver(string DriverNID, string DriverFullName)
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
                com.CommandText = "insert into Driver values (@DriverNID, @DriverFullName)";
                com.Parameters.AddWithValue("@DriverNID", DriverNID);
                com.Parameters.AddWithValue("@DriverFullName", DriverFullName);

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


        public DataTable ViewDriver()
        {
            DataTable Drivers = new DataTable(); ;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandText = "select * from Driver";

                SqlDataAdapter adapter = new SqlDataAdapter(com);
                adapter.Fill(Drivers);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return Drivers;
        }

        public List<string> GetDrivers()
        {
            List<string> Drivers = new List<string>();
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandText = "select * from Driver";

                SqlDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    Drivers.Add(reader["DriverFullName"].ToString());
                    Drivers.Add(reader["DriverNID"].ToString());
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
            return Drivers;
        }
    }
}