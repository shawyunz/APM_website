using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
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

            //strong password check
            string patdi = @"\d+"; //match digits
            string patupp = @"[A-Z]+"; //match upper cases
            string patlow = @"[a-z]+"; //match lower cases
            //string patsym = @"[`~!@$%^&\\-\\+*/_=,;.':|\\(\\)\\[\\]\\{\\}]+"; //match symbols
            string patsym = @"[!@#$%^&*()_+=\[{\]};:<>|./?,-]"; //match symbols
            //string patsym = @"[`~!@$%^&]+"; //match symbols
            Match id = Regex.Match(Password, patdi);
            Match upp = Regex.Match(Password, patupp);
            Match low = Regex.Match(Password, patlow);
            Match sym = Regex.Match(Password, patsym);

            ////another option
            //var hasNumber = new Regex(@"[0-9]+");
            //var hasUpperChar = new Regex(@"[A-Z]+");
            //var hasMiniMaxChars = new Regex(@".{8,15}");
            //var hasLowerChar = new Regex(@"[a-z]+");
            //var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");
            //if (!hasLowerChar.IsMatch(input))
            //{
            //    ErrorMessage = "Password should contain At least one lower case letter";
            //    return false;
            //}

            //validations for input
            if (Password != ConfirmPassword)
            {
                showMessage("Please type the same password to confirm!");
            }
            else if (string.IsNullOrEmpty(UID) || string.IsNullOrEmpty(UserName) 
                || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(ConfirmPassword))
            {
                showMessage("Please fill all fields to finish the registration!");
            }
            else if (!new EmailAddressAttribute().IsValid(UID))
            {
                showMessage("Please use a valid email address!");
            }

            else if (Password.Length < 6)
            {
                showMessage("Please use a stronger password with at least 6 length!");
            }
            else if (!(id.Success && upp.Success && low.Success && sym.Success))
            {
                showMessage("Please use a stronger password!");
            }
            else
            {
                aLayer.RegisterUser(UID, UserName, Password);
                Response.Redirect("Login.aspx");
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