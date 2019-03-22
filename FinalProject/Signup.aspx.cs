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

        private string connectionString = Security.getConnection();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand insert = new SqlCommand("INSERT into Users (userID, userName, userPassword, timeCreated) values(@userid, @username, @password, @time)", connection);
            SqlCommand count = new SqlCommand("Select max(userID) from Users", connection);
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
                    insert.Parameters.AddWithValue("@userid", newUserID);
                    insert.Parameters.AddWithValue("@username", txtUsername.Text);
                    insert.Parameters.AddWithValue("@password", passhash);
                    insert.Parameters.AddWithValue("@time", DateTime.Now);

                    reader = insert.ExecuteReader();
                    Session["Username"] = txtUsername.Text;
                    Session["UserID"] = newUserID;
                    Response.Redirect("Home.aspx");
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
            else
            {
                lblPasswordError.Text = "Passwords do not match!";
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