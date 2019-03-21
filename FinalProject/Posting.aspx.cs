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
            // IF USER IS REPLYING TO A THREAD, HIDE THE SUBJECT LABEL AND TEXTBOX, SHOW THE NAME OF THE THREAD

            
            if (String.IsNullOrEmpty(Request.QueryString["pfvers"]))
            {
                //Somehow accessed
                lblErrorMessage.Text = "ERROR. UNABLE TO FIND THREAD.";
                btnSubmit.Visible = false;
            }
            //else if (String.IsNullOrEmpty(Request.Cookies["UserID"].Value))// Keep getting a null error here, but no shit im checking for null dipfuck
            else if(String.IsNullOrEmpty(Session["UserID"].ToString()))
            {
                lblErrorMessage.Text = "You must be logged in to post.";
                lblSubject.Visible = false;
                txtSubject.Visible = false;
                txtMessage.ReadOnly = true;
            }
            else if (Request.QueryString["pfvers"].Equals("1"))
            {
                //Replying to a thread
                lblThreadname.Text = "RE: " + Session["threadName"].ToString();
                lblSubject.Visible = false;
                txtSubject.Visible = false;

            }
            else if (Request.QueryString["pfvers"].Equals("2"))
            {
                //Creating a new thread
                lblThreadname.Text = "New Thread";
                makingAThread = true;
            }


        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // Variable definitions
            
            string insertThreadString = "INSERT into Threads(threadID, threadSubject, timeCreated, userID, threadReplies, threadViews, timeModified) " +
                                    "values (@threadid, @threadsubject, @timecreated, @userid, @threadreplies, @threadviews, @timemodified)";
            string insertPostString = "INSERT into Posts(postID, postContent, timeCreated, threadID, userID) values (@postid, @postcontent, @timecreated, @threadid, @userid)";

            //Grab userID from cookie to use in posting
            //if (String.IsNullOrWhiteSpace(Request.Cookies["UserID"].Value))
            if(String.IsNullOrEmpty(Session["UserID"].ToString()))
            {
                lblSubject.Text = "shits fucked";
            }
            else
            {
                //string usrID = Request.Cookies["UserID"].ToString();
                string usrID = Session["UserID"].ToString() ;
                int userID = 0;
                if(!Int32.TryParse(usrID, out userID))
                {
                    lblThreadname.Text = "ERROR CONVERTING USERID TO INT";
                }
                else
                {
                    lblSubject.Text = userID.ToString();
                }


                // SQL Defintions
                SqlConnection connection = new SqlConnection(connectionString);
                SqlDataReader reader;
                SqlDataReader reader2;
                SqlCommand insertThread = new SqlCommand(insertThreadString, connection);
                SqlCommand insertPost = new SqlCommand(insertPostString, connection);
                SqlCommand maxThread = new SqlCommand("SELECT max(threadID) from Threads", connection);
                SqlCommand maxPost = new SqlCommand("SELECT max(postID) from Posts", connection);
                SqlCommand updateReply = new SqlCommand("UPDATE Threads SET threadReplies = threadReplies + 1 WHERE threadID = @threadid",connection);

                connection.Open();
            // Creating the command to enter post into the Posts table
                int newPostID = 0;
                newPostID = (Int32)maxPost.ExecuteScalar() + 1;
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
                        newThreadID = (Int32)maxThread.ExecuteScalar() + 1; // New threadID
                        connection.Close();

                        insertThread.Parameters.AddWithValue("@threadID", newThreadID);
                        insertThread.Parameters.AddWithValue("@threadsubject", threadSubject);
                        insertThread.Parameters.AddWithValue("@timecreated", DateTime.Now);
                        insertThread.Parameters.AddWithValue("@userid", userID);
                        insertThread.Parameters.AddWithValue("@threadreplies", 0);
                        insertThread.Parameters.AddWithValue("@threadviews", 0);
                        insertThread.Parameters.AddWithValue("@timemodified", DateTime.Now);




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
                    }
                    catch (Exception er)
                    {
                        lblErrorMessage.Text = er.ToString();
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

                        //PASS IN THREADID HERE FROM COOKIE (NOT CREATED/IMPLEMENTED YET)
                        insertPost.Parameters.AddWithValue("@postid", newPostID);
                        insertPost.Parameters.AddWithValue("@postcontent", txtMessage.Text);
                        insertPost.Parameters.AddWithValue("@timecreated", DateTime.Now);
                        // insertPost.Parameters.AddWithValue("@threadid", ); // PASS IN HERE
                        insertPost.Parameters.AddWithValue("@userid", userID);

                        reader = insertPost.ExecuteReader();

                        //Update reply count on the thread
                        reader = updateReply.ExecuteReader();


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