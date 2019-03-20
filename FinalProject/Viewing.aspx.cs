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
         * LEFT OFF AT: FRIENDLY URLS 
         */ 
        private string connectionString = Security.getConnection();
        private int threadID = 0;
        private string threadName = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            // Update Views
            /* FIRST OFF, PUT IT AT THE BOTTOM OF THE TRY SECTION
             * 1. Grab the current count of viewCount based off of threadID
             * 2. Make a statement that says "Update Threads.(viewCount?) to Count + 1"
             */


            string search = "SELECT distinct Users.userName, Posts.postContent, Posts.timeCreated " +
                "FROM Users, Posts, Threads " +
                "WHERE Posts.userID = Users.userID AND Posts.threadID = @threadid";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand threadInformation = new SqlCommand(search, connection);
            SqlDataReader reader;

            //if (!String.IsNullOrEmpty(Request.QueryString["threadID"])) {
                try
                {
                    // Grabs the threadID needed for viewing the correct thread
                    this.threadID = Convert.ToInt32(Request.QueryString["threadID"]);
                    threadInformation.Parameters.AddWithValue("@threadid", threadID);

                    // Opens database connection, sends the SELECT command to grab the posts in the thread
                    connection.Open();
                    reader = threadInformation.ExecuteReader();

                    while (reader.Read())
                    {
                        //Grab needed information from record
                        string postContent = reader["postContent"].ToString();
                        string dateCreation = reader["timeCreated"].ToString();
                        string userPosted = reader["Username"].ToString();
 //                       threadName = reader["threadSubject"].ToString();
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
           // else
           // {
           //     lblErrorMessages.Text = "ERROR: NO THREAD FOUND OR SELECTED.";
        

        protected void btnReply_Click(object sender, EventArgs e)
        {
            string redirect = "Posting.aspx?pfvers=1&thrpt=" + this.threadID.ToString();
//            Session["threadName"] = Convert.ToString(threadName);
            Response.Redirect(redirect);

        }
    }
}