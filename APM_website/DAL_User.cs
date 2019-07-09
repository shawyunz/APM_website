using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;

namespace APM_website
{
    //This is the database connection API file, defining the DB functions
    public class DAL_User
    {
        SqlConnection sqlConn;
        MySqlConnection conn;
        string connSQL = ConfigurationManager.ConnectionStrings["connDB"].ConnectionString;
        string connMySQL = ConfigurationManager.ConnectionStrings["connAzureDB"].ConnectionString;

        //for registration
        public void RegisterUser(string userID, string name, string password)
        {
            try
            {
                string query_save = "insert into tblAPM_user values ('"
                    + userID + "', '"
                    + name + "', '"
                    + getHashed(userID, password) + "')";

                //option1: sql server
                sqlConn = new SqlConnection(connSQL);
                sqlConn.Open();

                SqlCommand sqlCmd = new SqlCommand(query_save, sqlConn);
                sqlCmd.ExecuteNonQuery();
                sqlConn.Close();


                ////option2: mysql
                //conn = new MySqlConnection();
                //conn.ConnectionString = connMySQL;
                //conn.Open();

                //MySqlCommand cmd = conn.CreateCommand();
                //cmd.CommandText = query_save;
                //cmd.ExecuteNonQuery();
                //conn.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //for login
        public Boolean LoginUser(string userID, string password)
        {
            try
            {
                sqlConn = new SqlConnection(connSQL);
                sqlConn.Open();

                string query_select = "select * from tblAPM_user where UserID = '"
                    + userID + "' and Password = '"
                    + getHashed(userID, password) + "'";

                SqlCommand sqlCmd = new SqlCommand(query_select, sqlConn);
                SqlDataReader reader = sqlCmd.ExecuteReader();
                if (reader.HasRows)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private string getHashed(string str, string strSalt)
        {
            byte[] strByte = ASCIIEncoding.ASCII.GetBytes(str + strSalt + "AIS");
            byte[] hashByte = SHA256.Create().ComputeHash(strByte);
            return Convert.ToBase64String(hashByte);
        }
    }
}