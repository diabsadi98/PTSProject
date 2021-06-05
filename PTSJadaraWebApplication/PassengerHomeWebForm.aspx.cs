using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PTSJadaraWebApplication
{
    public partial class PassengerHomeWebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["PassengerNID"] == null)
            {
                Response.Redirect("ClientLoginWebForm.aspx");
            }
            else
            {
                Passenger passenger = new Passenger();
                LabelFullName.Text = passenger.GetFullName( Session["PassengerNID"].ToString());
            }
        }
    }
}