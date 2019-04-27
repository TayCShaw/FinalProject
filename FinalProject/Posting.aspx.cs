using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        public string connectionString = Security.getConnection();
        bool makingAThread = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Request.QueryString["pfvers"]))
            {
                // If somehow accessed without clicking on "New Thread" or "Reply"
                lblErrorMessage.Text = "ERROR: UNABLE TO FIND THREAD.";
                btnSubmit.Visible = false;
            }
            else if (HttpContext.Current.Session["UserID"] == null)
            {
                //Not logged in
                lblErrorMessage.Text = "ERROR: You must be logged in to post.";
                lblSubject.Visible = false;
                txtSubject.Visible = false;
                txtMessage.ReadOnly = true;
                btnSubmit.Text = "Sign in";
                btnSubmit.PostBackUrl = "~/Login.aspx";

            }
            else if (Request.QueryString["pfvers"].Equals("1"))
            {
                //Replying to a thread
                if (HttpContext.Current.Session["threadName"] != null)
                {
                    lblThreadname.Text = "RE: " + Session["threadName"].ToString();
                    lblSubject.Visible = false;
                    txtSubject.Visible = false;
                }
                else
                {
                    lblErrorMessage.Text = "ERROR: No Thread";
                }

            }
            else if (Request.QueryString["pfvers"].Equals("2"))
            {
                //Creating a new thread
                lblThreadname.Text = "";

                //Set to true for use in the btnSubmit_Click function
                makingAThread = true;
            }


        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // Variable definitions

            string insertThreadString = "INSERT into Threads(threadID, threadSubject, timeCreated, userID, threadReplies, threadViews, timeModified) " +
                                    "values (@threadid, @threadsubject, @timecreated, @userid, @threadreplies, @threadviews, @timemodified)";
            string insertPostString = "INSERT into Posts(postID, postContent, timeCreated, threadID, userID) values (@postid, @postcontent, @timecreated, @threadid, @userid)";

            if (HttpContext.Current.Session["UserID"] == null)
            {
                lblSubject.Text = "ERROR: You must login to post a reply.";
            }
            else
            {
                string usrID = Session["UserID"].ToString();
                int userID = 0;
                if (!Int32.TryParse(usrID, out userID))
                {
                    lblErrorMessage.Text = "Error 32";
                }
                /*               else
                               {
                                   lblSubject.Text = userID.ToString();
                               }
               */

                // SQL Defintions
                SqlConnection connection = new SqlConnection(connectionString);
                SqlDataReader reader;
                SqlDataReader reader2;
                SqlCommand insertThread = new SqlCommand(insertThreadString, connection);
                SqlCommand insertPost = new SqlCommand(insertPostString, connection);
                SqlCommand maxThread = new SqlCommand("SELECT max(threadID) from Threads", connection);
                SqlCommand maxPost = new SqlCommand("SELECT max(postID) from Posts", connection);
                SqlCommand updateReply = new SqlCommand("UPDATE Threads SET threadReplies = threadReplies + 1 WHERE threadID = @threadid", connection);

                connection.Open();
                // Creating the postID
                int newPostID = 0;
                try
                {
                    newPostID = (Int32)maxPost.ExecuteScalar() + 1; // New postID
                }
                catch (InvalidCastException) // Caught if there is no data in the post table
                {
                    newPostID = 1;
                }

                connection.Close();
                //Determine if making a thread or making a post/reply
                if (makingAThread)
                {
                    int newThreadID = 0;
                    string threadSubject = txtSubject.Text;

                    try
                    {
                        connection.Open();
                        // Creating the command to enter post into the Threads table
                        try
                        {
                            newThreadID = (Int32)maxThread.ExecuteScalar() + 1; // New threadID
                        }
                        catch (InvalidCastException) // Caught if there is no data in the thread table
                        {
                            newThreadID = 1;
                        }

                        connection.Close();

                        // Filling in the command to insert the thread into DB
                        insertThread.Parameters.AddWithValue("@threadID", newThreadID);
                        insertThread.Parameters.AddWithValue("@threadsubject", threadSubject);
                        insertThread.Parameters.AddWithValue("@timecreated", DateTime.Now);
                        insertThread.Parameters.AddWithValue("@userid", userID);
                        insertThread.Parameters.AddWithValue("@threadreplies", 0);
                        insertThread.Parameters.AddWithValue("@threadviews", 0);
                        insertThread.Parameters.AddWithValue("@timemodified", DateTime.Now);

                        // Filling in the command to insert the post into DB
                        insertPost.Parameters.AddWithValue("@postid", newPostID);
                        insertPost.Parameters.AddWithValue("@postcontent", txtMessage.Text);
                        insertPost.Parameters.AddWithValue("@timecreated", DateTime.Now);
                        insertPost.Parameters.AddWithValue("@threadid", newThreadID);
                        insertPost.Parameters.AddWithValue("@userid", userID);


                        // Open database, attempt to insert into tables
                        connection.Open();
                        reader = insertThread.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                        reader.Close();
                        connection.Open();
                        reader2 = insertPost.ExecuteReader();
                        Response.Redirect(string.Format("~/Viewing.aspx?threadID={0}", newThreadID));
                    }
                    catch (Exception er)
                    {
                        //lblErrorMessage.Text = er.ToString();
                        lblErrorMessage.Text = "ERROR: Max post length 2000 characters";
                    }
                    finally
                    {
                        connection.Close();
                    }

                }
                else // If post is a reply to an already started thread
                {
                    //Grab a new postID by taking max of threadID column + 1
                    try
                    {

                        connection.Open();
                        insertPost.Parameters.AddWithValue("@postid", newPostID);
                        insertPost.Parameters.AddWithValue("@postcontent", txtMessage.Text);
                        insertPost.Parameters.AddWithValue("@timecreated", DateTime.Now);
                        insertPost.Parameters.AddWithValue("@threadid", Request.QueryString["thrpt"]);
                        insertPost.Parameters.AddWithValue("@userid", userID);

                        updateReply.Parameters.AddWithValue("@threadid", Request.QueryString["thrpt"]);

                        reader = insertPost.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                        reader.Close();

                        connection.Open();
                        //Update reply count on the thread
                        reader = updateReply.ExecuteReader();

                        // Redirect to the thread that was just replied to
                        Response.Redirect(string.Format("~/Viewing.aspx?threadID={0}", Request.QueryString["thrpt"]));

                    }
                    catch (Exception er)
                    {
                        lblErrorMessage.Text = userID.ToString() + " " + er.ToString();
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }
    }
}