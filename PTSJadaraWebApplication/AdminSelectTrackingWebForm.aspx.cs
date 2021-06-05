using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PTSJadaraWebApplication
{
    public partial class AdminSelectTrackingWebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                Trips trips = new Trips();
                DropDownListTripID.Items.Add("--- Select ---");
                foreach (var item in trips.GetTripIDs())
                {
                    DropDownListTripID.Items.Add(item.ToString());
                }
            }
        }

        protected void ButtonTrack_Click(object sender, EventArgs e)
        {
            if (DropDownListTripID.Text == "--- Select ---")
            {
                Response.Write("<script>alert('Please Select Trip ID');</script>");
            }
            else
            {
                Location location = new Location();
                string triplocation = location.GetLocation(DropDownListTripID.SelectedItem.ToString());

                if (Session["triplocation"] == null)
                {
                    Session.Add("triplocation", triplocation);
                }
                else
                {
                    Session["triplocation"] = triplocation;
                }
                Response.Redirect("AdminViewTrackingWebForm.aspx");
            }
        }
    }
}