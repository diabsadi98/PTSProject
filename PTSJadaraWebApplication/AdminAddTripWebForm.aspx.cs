using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PTSJadaraWebApplication
{
    public partial class AdminAddTripWebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DropDownListFromCity.Items.Add("--- Select ---");
                DropDownListFromCity.Items.Add("Amman");
                DropDownListFromCity.Items.Add("Irbid");
                DropDownListFromCity.Items.Add("Ajloun");

                DropDownListToCity.Items.Add("--- Select ---");
                DropDownListToCity.Items.Add("Amman");
                DropDownListToCity.Items.Add("Irbid");
                DropDownListToCity.Items.Add("Ajloun");

                DropDownListStartTime.Items.Add("--- Select ---");
                for (int i = 6; i <= 9; i++)
                {
                    DropDownListStartTime.Items.Add("0" + i + ":00 AM");
                }
                for (int i = 10; i <= 11; i++)
                {
                    DropDownListStartTime.Items.Add(i + ":00 AM");
                }
                DropDownListStartTime.Items.Add("12:00 PM");

                for (int i = 1; i <= 6; i++)
                {
                    DropDownListStartTime.Items.Add("0" + i + ":00 PM");
                }

                DropDownListEndTime.Items.Add("--- Select ---");
                for (int i = 7; i <= 9; i++)
                {
                    DropDownListEndTime.Items.Add("0" + i + ":00 AM");
                }
                for (int i = 10; i <= 11; i++)
                {
                    DropDownListEndTime.Items.Add(i + ":00 AM");
                }
                DropDownListEndTime.Items.Add("12:00 PM");

                for (int i = 1; i <= 7; i++)
                {
                    DropDownListEndTime.Items.Add("0" + i + ":00 PM");
                }

                DropDownListDriverName.Items.Add("--- Select ---");
                Driver driver = new Driver();
                List<string> Drivers = new List<string>();
                Drivers = driver.GetDrivers();
                for (int i = 0; i < Drivers.Count; i += 2)
                {
                    DropDownListDriverName.Items.Add(new ListItem(Drivers[i].ToString(), Drivers[i + 1].ToString()));
                }
            }
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            if(DropDownListFromCity.Text== "--- Select ---")
            {
                Response.Write("<script>alert('Please Select Source City');</script>");
            }
            else
            {
                if (DropDownListToCity.Text == "--- Select ---")
                {
                    Response.Write("<script>alert('Please Select Destination City');</script>");
                }
                else
                {
                    if (DropDownListFromCity.SelectedItem.ToString() == DropDownListToCity.SelectedItem.ToString())
                    {
                        Response.Write("<script>alert('Please Select a valid City');</script>");
                    }
                    else
                    {
                        if(Convert.ToInt32( TextBoxPassengerNo.Text)<1)
                        {
                            Response.Write("<script>alert('Please Enter a valid Passenger No');</script>");
                        }
                        else
                        {
                            if (Convert.ToInt32(TextBoxAdultPrice.Text) < 1)
                            {
                                Response.Write("<script>alert('Please Enter a valid Adult Price');</script>");
                            }
                            else
                            {
                                if (Convert.ToInt32(TextBoxChildPrice.Text) < 1)
                                {
                                    Response.Write("<script>alert('Please Enter a valid Child Price');</script>");
                                }
                                else
                                {
                                    if (DropDownListStartTime.Text == "--- Select ---")
                                    {
                                        Response.Write("<script>alert('Please Select Start Time');</script>");
                                    }
                                    else
                                    {
                                        if (DropDownListEndTime.Text == "--- Select ---")
                                        {
                                            Response.Write("<script>alert('Please Select End Time');</script>");
                                        }
                                        else
                                        {
                                            if (DropDownListStartTime.SelectedItem.ToString() == DropDownListEndTime.SelectedItem.ToString())
                                            {
                                                Response.Write("<script>alert('Please Select a valid Time');</script>");
                                            }
                                            else
                                            {
                                                if(DropDownListDriverName.Text == "--- Select ---")
                                                {
                                                    Response.Write("<script>alert('Please Select Driver Name');</script>");
                                                }
                                                else
                                                {
                                                    Trips trips = new Trips();
                                                    if(trips.AddTrip(DropDownListFromCity.SelectedItem.ToString(),
                                                        DropDownListToCity.SelectedItem.ToString(),TextBoxPassengerNo.Text,
                                                        TextBoxAdultPrice.Text,TextBoxChildPrice.Text,DropDownListStartTime.SelectedItem.ToString(),
                                                        DropDownListEndTime.SelectedItem.ToString(),
                                                        Convert.ToDateTime( TextBoxTripDate.Text).ToString("yyyy-MM-dd"),
                                                        DropDownListDriverName.SelectedValue.ToString(), Session["Username"].ToString()) > 0)
                                                    {
                                                        Response.Write("<script>alert('Trip Added');</script>");
                                                    }
                                                    else
                                                    {
                                                        Response.Write("<script>alert('Error');</script>");
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}