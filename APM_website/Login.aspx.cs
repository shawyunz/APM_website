using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace APM_website
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login_Click(object sender, EventArgs e)
        {
            DAL_User aLayer = new DAL_User();
            if (aLayer.loginUser(txtUID.Text, txtPassword.Text))
            {
                Response.Redirect("MainForm.aspx");
            } else
            {
                //error message
                
            }
        }
    }
}