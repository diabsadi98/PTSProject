using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PTSJadaraWebApplication
{
    public partial class ClientLoginWebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Passenger passenger = new Passenger();
                long PassengerNID = 0;
                PassengerNID = passenger.Login(TextBoxloginname.Text, TextBoxPassword.Text);
                if (PassengerNID > 0)
                {
                    if (Session["PassengerNID"] == null)
                    {
                        Session.Add("PassengerNID", PassengerNID);
                    }
                    else
                    {
                        Session["PassengerNID"] = PassengerNID;
                    }

                    Response.Redirect("PassengerHomeWebForm.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Error');</script>");
                }
            }
        }
    }
}