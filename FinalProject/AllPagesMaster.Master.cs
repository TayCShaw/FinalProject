using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //check for cookie if exzists use the values if not ignore this
            if (!IsPostBack)
            {

            }
        }

        protected void btnSignup_Click(object sender, EventArgs e)
        {
            Response.Redirect("Signup.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        public void setBtnLogin(string state)
        {
            // check if cookie is made
            //update the cookie values
            if (Response.Cookies["buttonText"] != null)
            {
                if (state.Equals("logout"))
                {
                    btnLogin.Text = Response.Cookies["ButtonText"]["outtext"];
                    btnLogin.PostBackUrl = Response.Cookies["ButtonText"]["outredirect"];
                }
                else
                {

                    //btnLogin.Text = buttonText;
                    //btnLogin.PostBackUrl = redirect;
                }
            }


            // if not make cookie set values

        }
    }
}