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
                "WHERE Posts.threadID = 1 ORDER BY timeCreated";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand threadInformation = new SqlCommand(search, connection);
            //threadInformation.Parameters.AddWithValue("@threadid", passedInID);
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

                    //Put into divs and on page
                    //Background div, handles page padding and background color
                    HtmlGenericControl backgroundDiv = new HtmlGenericControl("div");
                    backgroundDiv.Attributes.Add("class", "post");
                    backgroundDiv.Attributes.Add("class", "backgroundcolor-1");

                    //Handles the inside content of the actual thread post/reply
                    HtmlGenericControl innerDiv = new HtmlGenericControl("div");


                    //Div for the post/reply text, time posted, etc.
                    HtmlGenericControl postBody = new HtmlGenericControl("div");
                    postBody.Attributes.Add("class", "postbody");
                    HtmlGenericControl authorP = new HtmlGenericControl("p");
                    authorP.Attributes.Add("class", "author");

                    //Div for the actual post text
                    HtmlGenericControl postText = new HtmlGenericControl("div");
                    postText.InnerHtml = postContent;

                    postBody.Controls.Add(postText);
                    innerDiv.Controls.Add(authorP);
                    innerDiv.Controls.Add(postBody);
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