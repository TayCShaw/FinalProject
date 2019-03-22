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
            string updateViews = "UPDATE Threads SET threadViews = @threadviews WHERE threadID = @threadID";

            string search = "SELECT DISTINCT Users.userName, Posts.postContent, Posts.timeCreated, Threads.threadSubject, Threads.threadViews " +
                "FROM Posts INNER JOIN Threads ON Posts.threadID = Threads.threadID INNER JOIN Users ON Posts.userID = Users.userID AND Posts.threadID = @threadid " +
                "ORDER BY Posts.timeCreated ASC";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand threadInformation = new SqlCommand(search, connection);
            SqlCommand viewInformation = new SqlCommand(updateViews, connection);
            SqlDataReader reader;

                try
                {
                    // Grabs the threadID needed for viewing the correct thread
                    this.threadID = Convert.ToInt32(Request.QueryString["threadID"]);
                    threadInformation.Parameters.AddWithValue("@threadid", threadID);

                    // Opens database connection, sends the SELECT command to grab the posts in the thread
                    connection.Open();
                    reader = threadInformation.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                int threadViews = 0;
                    while (reader.Read())
                    {
                        //Grab needed information from record
                        string postContent = reader["postContent"].ToString();
                        string dateCreation = reader["timeCreated"].ToString();
                        string userPosted = reader["Username"].ToString();
                        Int32.TryParse(reader["threadViews"].ToString(), out threadViews);
                        

                    threadName = reader["threadSubject"].ToString();
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
                if (!IsPostBack)
                {
                    threadViews += 1;
                }



                viewInformation.Parameters.AddWithValue("@threadviews", threadViews);
                    viewInformation.Parameters.AddWithValue("@threadid", threadID);
                    reader.Close();
                    connection.Open();
                    reader = viewInformation.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                    
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
            Session["threadName"] = threadName;
            Response.Redirect(redirect);

        }
    }
}