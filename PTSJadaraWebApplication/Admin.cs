using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace PTSJadaraWebApplication
{
    public class Admin
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-RM0C6BI;Initial Catalog=PTSJADARADB;Integrated Security=True");
        public string Login(string Username, string UserPassword)
        {
            string FullName = "";
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandText = "select FullName from Admin where Username = @Username and UserPassword = @UserPassword";
                com.Parameters.AddWithValue("@Username", Username);
                com.Parameters.AddWithValue("@UserPassword", UserPassword);

                SqlDataReader reader = com.ExecuteReader();

                if (reader.Read())
                {
                    FullName = reader["FullName"].ToString();
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
            return FullName;
        }
    }
}