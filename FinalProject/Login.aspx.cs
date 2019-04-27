using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject
{

    public partial class WebForm3 : System.Web.UI.Page
    {
        private string connectionString = Security.getConnection();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand search = new SqlCommand("SELECT * FROM Users WHERE userName = @username", connection);
            SqlDataReader reader;

            search.Parameters.AddWithValue("@username", txtUsername.Text);
            try
            {
                connection.Open();
                reader = search.ExecuteReader();
                reader.Read();

                if (!reader.HasRows)
                {
                    lblErrorMessages.Text = "Incorrect username or password";
                }
                else
                {
                    string pass = txtPassword.Text;
                    pass = Security.Sha256(pass);

                    if (!pass.Equals(reader["userPassword"]))
                    {
                        lblErrorMessages.Text = "Incorrect username or password";
                    }
                    else
                    {
                        Session["Username"] = reader["userName"];
                        Session["UserID"] = reader["userID"];
                        Response.Redirect("~/Home.aspx");
                    }
                }
            }
            catch (Exception er)
            {
                lblErrorMessages.Text = er.ToString();
            }
            finally
            {
                connection.Close();
            }
        }
    }
}