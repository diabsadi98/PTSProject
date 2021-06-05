using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PTSJadaraWebApplication
{
    public partial class AdminHomeWebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["FullName"] == null)
            {
                Response.Redirect("AdminLoginWebForm.aspx");
            }
            else
            {
                LabelFullName.Text = Session["FullName"].ToString();
            }
        }
    }
}