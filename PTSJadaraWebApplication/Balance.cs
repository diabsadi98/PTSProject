using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace PTSJadaraWebApplication
{
    public class Balance
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-RM0C6BI;Initial Catalog=PTSJADARADB;Integrated Security=True");

        public int AddBalance(string PassengerNID, string PassengerBalance)
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
                com.CommandText = "insert into Balance values (@PassengerNID, @PassengerBalance)";
                com.Parameters.AddWithValue("@PassengerNID", PassengerNID);
                com.Parameters.AddWithValue("@PassengerBalance", PassengerBalance);

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


        public decimal GetPassengerBalance(string PassengerNID)
        {
            decimal PassengerBalance = 0;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandText = "select PassengerBalance from Balance where PassengerNID = @PassengerNID";
                com.Parameters.AddWithValue("@PassengerNID", PassengerNID);
                SqlDataReader reader = com.ExecuteReader();

                if (reader.Read())
                {
                    PassengerBalance = Convert.ToDecimal( reader["PassengerBalance"].ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
            finally
            {
                con.Close();
            }
            return PassengerBalance;
        }

        public int UpdateBalance(string PassengerNID, string PassengerBalance)
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
                com.CommandText = "update  Balance set  PassengerBalance = @PassengerBalance where PassengerNID = @PassengerNID";
                com.Parameters.AddWithValue("@PassengerNID", PassengerNID);
                com.Parameters.AddWithValue("@PassengerBalance", PassengerBalance);

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

        public DataTable ViewBalance(string PassengerNID)
        {
            DataTable PassengerBalance = new DataTable(); ;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandText = "select * from Balance  where PassengerNID = @PassengerNID";
                com.Parameters.AddWithValue("@PassengerNID", PassengerNID);

                SqlDataAdapter adapter = new SqlDataAdapter(com);
                adapter.Fill(PassengerBalance);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return PassengerBalance;
        }

    }
}