using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PTSJadaraWebApplication
{
    public partial class AdminViewDriverWebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonView_Click(object sender, EventArgs e)
        {
            Driver driver = new Driver();
            GridViewDrivers.DataSource = driver.ViewDriver();
            GridViewDrivers.DataBind();
        }
    }
}