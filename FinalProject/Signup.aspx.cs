using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;

namespace FinalProject
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        private static string connectionString = WebConfigurationManager.ConnectionStrings["UserConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("Insert into Users (userID, userName, userPassword, timeCreated) values(@userid, @username, @password, @time)", connection);
            SqlCommand count = new SqlCommand("Select count(userID) from Users", connection);
            SqlDataReader reader;

            if (txtPassword.Text.Equals(txtConfirmPassword.Text))
            {
                int newUserID = 0;
                lblPasswordError.Text = "SAME PASS";
                try
                {
                    connection.Open();
                    newUserID = (Int32)count.ExecuteScalar() + 1;

                    string passhash = Security.Sha256(txtPassword.Text);
                    cmd.Parameters.AddWithValue("@userid", newUserID);
                    cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                    cmd.Parameters.AddWithValue("@password", passhash);
                    cmd.Parameters.AddWithValue("@time", DateTime.Now);

                    reader = cmd.ExecuteReader();
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


        protected void txtUsername_TextChanged(object sender, EventArgs e)
        {
            lblErrorMessages.Text = "";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("Select userName from Users where userName = @username", connection);
            cmd.Parameters.AddWithValue("@username",txtUsername.Text);
            SqlDataReader reader;
            try
            {
               
                connection.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (txtUsername.Text.Equals(reader["userName"].ToString()))
                    {
                        lblUsernameError.Text = "Username already taken, choose another.";
                        return;
                    }
                }
                lblUsernameError.Text = "Username available!";

            }
            catch(Exception er)
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