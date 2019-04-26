using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] != null)
            {
                btnLogin.Text = "Logout";
                btnSignup.Visible = false;
            }
            else
            {
                btnLogin.Text = "Login";
                btnSignup.Visible = true;
            }
        }
    
        protected void btnSignup_Click(object sender, EventArgs e)
        {

            Response.Redirect("~/Signup.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (Session["Username"] != null)
            {
                Session["Username"] = null;
                Session["UserID"] = null;
                Response.Redirect("Home.aspx");

            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }
        
    }
}