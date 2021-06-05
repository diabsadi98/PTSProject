using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PTSJadaraWebApplication
{
    public partial class AdminViewTripPassengersWebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonView_Click(object sender, EventArgs e)
        {
            Trips trips = new Trips();
            GridViewTrips.DataSource = trips.GetTripsByDate( TextBoxTripDate.Text);
            GridViewTrips.DataBind();
        }
        static string TripID = "";
        protected void GridViewTrips_SelectedIndexChanged(object sender, EventArgs e)
        {
            TripID = GridViewTrips.SelectedRow.Cells[1].Text;
            Reservation reservation = new Reservation();
            GridViewPassengers.DataSource = reservation.GetReservationByID( TextBoxTripDate.Text);
            GridViewPassengers.DataBind();
        }
    }
}