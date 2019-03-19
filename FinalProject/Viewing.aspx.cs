using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

namespace FinalProject
{
    public partial class Viewing : System.Web.UI.Page
    {
        /*
         * LEFT OFF AT: FRIENDLY URLS, NEED TO PASS IN THE threadID IN ORDER TO
         * FIND THE POSTS IN THAT THREAD. 
         */ 
        //int passedInID = ;
        private string connectionString = Security.getConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            string search = "SELECT Users.Username, Posts.timeCreated, Posts.postContent " +
                "FROM Users INNER JOIN Posts ON Users.userID = Posts.userID " +
                "INNER JOIN Threads on Users.userID = Threads.userID " +
                "AND Posts.threadID = Threads.threadID " +
                "WHERE Posts.threadID = @threadid ORDER BY timeCreated";

            int threadID = Convert.ToInt32(Request.QueryString["threadID"]);
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand threadInformation = new SqlCommand(search, connection);
            threadInformation.Parameters.AddWithValue("@threadid", threadID);
            SqlDataReader reader;

            try
            {
                connection.Open();
                reader = threadInformation.ExecuteReader();

                while (reader.Read())
                {
                    //Grab needed information from record
                    string postContent = reader["postContent"].ToString();
                    string dateCreation = reader["timeCreated"].ToString();
                    string userPosted = reader["Username"].ToString();

                    HtmlGenericControl postText = new HtmlGenericControl("div");
                    postText.InnerHtml = postContent;

                    HtmlGenericControl innerDiv = new HtmlGenericControl("div");

                    HtmlGenericControl authorP = new HtmlGenericControl("p");
                    authorP.Attributes.Add("class", "author");
                    authorP.InnerHtml = userPosted + " " + dateCreation;

                    innerDiv.Controls.Add(authorP);
                    innerDiv.Controls.Add(postText);

                    HtmlGenericControl backgroundDiv = new HtmlGenericControl("div");
                    backgroundDiv.Attributes.Add("class", "post backgroundcolor-1");
                    backgroundDiv.Controls.Add(innerDiv);

                    this.Controls.Add(backgroundDiv);
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