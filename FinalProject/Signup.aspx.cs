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
        private static string password = "";
        private static string confirmedPassword = "";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("Insert into Users (userId, userName, userPassword) values(@id, @username, @password)", connection);
            //cmd.Parameters.AddWithValue("@id", ---);
            cmd.Parameters.AddWithValue("@username",txtUsername.Text);
            cmd.Parameters.AddWithValue("@password",txtConfirmPassword.Text);

            if (txtPassword.Text.Equals(txtConfirmPassword.Text))
            {
                lblUsernameError.Text = "SAME PASS";
                try
                {
                    connection.Open();
                    //STORE THIS IN DATABASE
                    string passhash = Security.Sha256(txtPassword.Text);
                    //int[] bush = new int[10];

                    SqlCommand count = new SqlCommand("SELECT * from Users", connection);
                    SqlDataReader reader;
                    reader = count.ExecuteReader();
                    int bush = (int) reader["userID"];
                    lblErrorMessages.Text = bush.ToString();
                    

                }
                catch (Exception er)
                {
                    lblPasswordError.Text = er.ToString();
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
                        lblErrorMessages.Text = "Username already taken, choose another.";
                        return;
                    }
                }
                lblErrorMessages.Text = "Username available!";

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