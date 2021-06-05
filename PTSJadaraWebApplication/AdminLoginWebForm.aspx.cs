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
    public partial class AdminLoginWebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Admin admin = new Admin();
                string FullName = "";
                FullName = admin.Login(TextBoxUsername.Text, TextBoxUserPassword.Text);
                if (FullName != "")
                {
                   if(Session["FullName"] == null)
                    {
                        Session.Add("FullName", FullName);
                    }
                   else
                    {
                        Session["FullName"] = FullName;
                    }

                    if (Session["Username"] == null)
                    {
                        Session.Add("Username", TextBoxUsername.Text);
                    }
                    else
                    {
                        Session["Username"] = TextBoxUsername.Text;
                    }

                    Response.Redirect("AdminHomeWebForm.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Error');</script>");
                }
            }
        }
    }
}