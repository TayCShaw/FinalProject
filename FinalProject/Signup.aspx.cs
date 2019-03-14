using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace FinalProject
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //h
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Boolean usernameFound = false;
            lblErrorMessages.Text = ""; // Incase error displayed
            String username = txtUsername.Text;
            String preparedQuery = "SELECT userName " +
                "FROM  Users WHERE userName = '" + username + "';";


            using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Taylor\\Source\\Repos\\TayCShaw\\FinalProject\\FinalProject\\App_Data\\Forum.mdf;Integrated Security=True"))
            {
                using (SqlCommand cmd = new SqlCommand(preparedQuery, connection))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(preparedQuery, connection);
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        if(username == (String)dataReader.GetValue(0))
                        {
                            lblErrorMessages.Text = "found the name " + username + ". Already taken.";
                            break;
                        }
                    }

                    if (!usernameFound)
                    {

                    }

                }
            }               
        }
    }
}