using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PTSJadaraWebApplication
{
  
    public partial class AdminAddBalanceWebForm : System.Web.UI.Page
    {
        Passenger passenger = new Passenger();
        Balance balance = new Balance();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DropDownListPassengerNID.Items.Add("--- Select ---");

                List<string> passengers = new List<string>();
                passengers = passenger.GetPassengers();
                for (int i = 0; i < passengers.Count; i += 2)
                {
                    DropDownListPassengerNID.Items.Add(new ListItem(passengers[i].ToString(), passengers[i + 1].ToString()));
                }
            }
        }
        
        protected void DropDownListPassengerNID_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            GridViewBalance.DataSource = balance.ViewBalance(DropDownListPassengerNID.SelectedValue.ToString());
            GridViewBalance.DataBind();
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (DropDownListPassengerNID.Text == "--- Select ---")
            {
                Response.Write("<script>alert('Please select Passenger');</script>");
            }
            else
            {
                decimal CurrentBalance = balance.GetPassengerBalance(DropDownListPassengerNID.SelectedValue.ToString());
                CurrentBalance += Convert.ToDecimal(TextBoxValue.Text);
                balance.UpdateBalance(DropDownListPassengerNID.SelectedValue.ToString(), CurrentBalance.ToString());
                Response.Redirect("AdminAddBalanceWebForm.aspx");
            }
        }
    }
}