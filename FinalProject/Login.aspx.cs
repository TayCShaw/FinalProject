using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject
{

    /*
     * BASICALLY DONE, NEED TO REDIRECT TO HOME AND STORE USER DATA IN A COOKIE.
     * PLUS ANY OTHER WORK THOUGHT OF AFTER THAT
     * 
     * */
    public partial class WebForm3 : System.Web.UI.Page
    {
        private string connectionString = Security.getConnection();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand search = new SqlCommand("SELECT * FROM Users WHERE userName = @username",connection);
            SqlDataReader reader;

            search.Parameters.AddWithValue("@username", txtUsername.Text);
            try
            {
                connection.Open();
                reader = search.ExecuteReader();
                reader.Read();

                if (!reader.HasRows)
                {
                    lblErrorMessages.Text = "USER NOT FOUND!!";
                }
                else
                {
                    string pass = txtPassword.Text;
                    pass = Security.Sha256(pass);

                    if (!pass.Equals(reader["userPassword"]))
                    {
                        lblErrorMessages.Text = "Incorrect password";

                    }
                    else
                    {
                        // MAKE A COOKIE, STORE THIS INFORMATION IN A COOKIE
                        Session["loggedin"] = true;
                        Session["userID"] = reader["userID"];
                        
                        lblErrorMessages.Text = Session["userID"].GetType().ToString();
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