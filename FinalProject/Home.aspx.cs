using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private string connectionString = Security.getConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["Username"] != null)
            {
                lblTest.Text = Request.Cookies["Username"].Value;
            }
        }


        //Creating a brand new thread, NOT a response to a thread
        protected void btnNewThread_Click(object sender, EventArgs e)
        {
            Response.Redirect("Posting.aspx?pfvers=2");
        }
    }
}