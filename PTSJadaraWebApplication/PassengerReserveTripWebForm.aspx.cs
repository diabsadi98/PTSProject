using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QRCoder;
namespace PTSJadaraWebApplication
{
    public partial class PassengerReserveTripWebForm : System.Web.UI.Page
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
            }
        }

        protected void ButtonView_Click(object sender, EventArgs e)
        {
            if (DropDownListFromCity.Text == "--- Select ---")
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
                        Trips trips = new Trips();
                        GridViewTrips.DataSource = trips.GetTripsforReserve(DropDownListFromCity.SelectedItem.ToString(), DropDownListToCity.SelectedItem.ToString(), TextBoxTripDate.Text); 
                        GridViewTrips.DataBind();
                        
                    }
                }
            }
        }
        static string TripID = "";
        static string AdultPrice = "";
        static string ChildPrice = "";
        protected void GridViewTrips_SelectedIndexChanged(object sender, EventArgs e)
        {
            TripID = GridViewTrips.SelectedRow.Cells[1].Text;
            AdultPrice = GridViewTrips.SelectedRow.Cells[4].Text;
            ChildPrice = GridViewTrips.SelectedRow.Cells[5].Text;
        }
        Balance balance = new Balance();
        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            if(RadioButtonAdult.Checked==false && RadioButtonChild.Checked== false)
            {
                Response.Write("<script>alert('Please Select Passenger Type');</script>");
            }
            else
            {
                decimal CurrentPrice = 0;
                if (RadioButtonAdult.Checked)
                {
                    CurrentPrice = Convert.ToDecimal(AdultPrice);
                }
               else  if (RadioButtonChild.Checked)
                {
                    CurrentPrice = Convert.ToDecimal(ChildPrice);
                }
               
                if (balance.GetPassengerBalance(Session["PassengerNID"].ToString()) - CurrentPrice < 0)
                {
                    Response.Write("<script>alert('Please Check your Balance');</script>");
                }
                else
                {
                    
                    Reservation reservation = new Reservation();
                    Trips trips = new Trips();

                    if (reservation.GetCurrentPassengerCount(TripID.ToString()) >= trips.GetPassengerNo(TripID.ToString()))
                    {
                        Response.Write("<script>alert('Trip is Full');</script>");
                    }
                    else
                    {
                        string QRText = Session["PassengerNID"].ToString() + ";" + TripID;
                        QRCodeGenerator qrGenerator = new QRCodeGenerator();

                        QRCodeData qrCodeData = qrGenerator.CreateQrCode(QRText, QRCodeGenerator.ECCLevel.Q);
                        QRCode qrCode = new QRCode(qrCodeData);
                        Bitmap qrCodeImage = qrCode.GetGraphic(20);

                        MemoryStream ms = new MemoryStream();

                        qrCodeImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        byte[] byteImage = ms.ToArray();
                        ImageQR.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);


                        if (reservation.AddReservation(TripID, Session["PassengerNID"].ToString(), QRText) > 0)
                        {
                            decimal newbalance = balance.GetPassengerBalance(Session["PassengerNID"].ToString()) - CurrentPrice;
                            balance.UpdateBalance(Session["PassengerNID"].ToString(), newbalance.ToString());
                            Response.Write("<script>alert('Done . . .');</script>");
                        }
                        else
                        {
                            Response.Write("<script>alert('Error . . .');</script>");
                        }
                    }
                }

            }
        }
    }
}