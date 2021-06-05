using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PTSJadaraWebApplication
{
    public partial class AdminAddDriverWebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Driver driver = new Driver();
                if (driver.AddDriver(TextBoxDriverNID.Text, TextBoxDriverFullName.Text) > 0)
                {
                    Response.Write("<script>lert('Driver Added');</script>");
                }
                else
                {
                    Response.Write("<script>lert('Error');</script>");
                }
            }
        }
    }
}