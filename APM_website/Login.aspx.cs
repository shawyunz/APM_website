using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace APM_website
{
    //This is the page C# code for Login
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Visible = false;
        }

        //handle the event when clicking the button
        protected void Login_Click(object sender, EventArgs e)
        {
            DAL_User aLayer = new DAL_User();
            if (aLayer.LoginUser(txtUID.Text, txtPassword.Text))
            {
                Response.Redirect("MainForm.aspx");
            } else
            {
                //error message
                lblMessage.Visible = true;
                lblMessage.Text = "Login failed! Please try again!";
            }
        }
    }
}