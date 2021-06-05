using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PTSJadaraWebApplication
{
    public partial class PassengerViewTripWebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonView_Click(object sender, EventArgs e)
        {
            Reservation reservation = new Reservation();
            GridViewTrips.DataSource = reservation.GetReservation(Session["PassengerNID"].ToString(), TextBoxTripDate.Text);
            GridViewTrips.DataBind();
        }
       
        protected void GridViewTrips_SelectedIndexChanged(object sender, EventArgs e)
        {
            string QRText = GridViewTrips.SelectedRow.Cells[5].Text;

            QRCodeGenerator qrGenerator = new QRCodeGenerator();

            QRCodeData qrCodeData = qrGenerator.CreateQrCode(QRText, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);

            MemoryStream ms = new MemoryStream();

            qrCodeImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            byte[] byteImage = ms.ToArray();
            ImageQR.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
        }
    }
}