using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace APM_website
{
    //This is the page C# code for registration
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Visible = false;
        }

        //handle the event when clicking the button
        protected void BtnRegistration(object sender, EventArgs e)
        {
            DAL_User aLayer = new DAL_User();

            string UID = txtUserID.Text;
            string UserName = txtUserName.Text;
            string Password = txtPassword.Text;
            string ConfirmPassword = txtConfirmPassword.Text;

            //validations for input
            if (Password != ConfirmPassword)
            {
                showMessage("Please type the same password to confirm!");
            }
            else if (string.IsNullOrEmpty(UID) || string.IsNullOrEmpty(UserName) 
                || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(ConfirmPassword))
            {
                showMessage("Please fill all fields to finish the registration!");
            } else
            {
                aLayer.RegisterUser(UID, UserName, Password);
            }
        }

        //show the message in the label field
        private void showMessage(string message)
        {
            lblMessage.Visible = true;
            lblMessage.Text = message;
        }
    }
}