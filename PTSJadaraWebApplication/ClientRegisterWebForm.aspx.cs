using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PTSJadaraWebApplication
{
    public partial class ClientRegisterWebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonRegister_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Passenger passenger = new Passenger();
                if (passenger.Register(TextBoxNationalID.Text, TextBoxFullName.Text, TextBoxAge.Text, TextBoxMobile.Text, TextBoxloginname.Text, TextBoxPassword.Text) > 0)
                {
                    Balance balance = new Balance();
                    if (balance.AddBalance(TextBoxNationalID.Text,"0") > 0)
                    {
                        Response.Write("<script>alert('Passenger Added');</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Error');</script>");
                }
            }
        }
    }
}