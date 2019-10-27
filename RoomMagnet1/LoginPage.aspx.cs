using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;
public partial class LoginPage : System.Web.UI.Page
{
    SqlConnection sc = new SqlConnection(WebConfigurationManager.ConnectionStrings["RoomMagnetAWS"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void LoginButton_Click(object sender, EventArgs e)
    {
        try
        {
            sc.Open();
            System.Data.SqlClient.SqlCommand findPass = new System.Data.SqlClient.SqlCommand();
            findPass.Connection = sc;

            System.Data.SqlClient.SqlCommand select = new System.Data.SqlClient.SqlCommand();
            select.Connection = sc;
            // SELECT PASSWORD STRING WHERE THE ENTERED USERNAME MATCHES
            findPass.CommandText = "select password from Passwords where email = @email";
            findPass.Parameters.Add(new System.Data.SqlClient.SqlParameter("@email", HttpUtility.HtmlEncode(EmailBox.Text)));

            SqlDataReader reader = findPass.ExecuteReader();

            if (reader.HasRows) // if the username exists, it will continue
            {
                while (reader.Read()) // this will read the single record that matches the entered username
                {
                    string storedHash = reader["password"].ToString(); // store the database password into this variable

                    if (PasswordHash.ValidatePassword(PasswordBox.Text, storedHash)) // if the entered password matches what is stored, it will show success
                    {
                        OutputLabel.Text = "Success!";
                        LoginButton.Enabled = false;
                        EmailBox.Enabled = false;
                        PasswordBox.Enabled = false;

                        //Then, open the database and 
                        sc.Close();
                        sc.Open();
                        //select.CommandText = "select userType from Passwords where email = @email";
                        //select.Parameters.Add(new System.Data.SqlClient.SqlParameter("@email", EmailBox.Text));
                        //String userType = Convert.ToString(select.ExecuteScalar());

                        select.CommandText = "select userType from Passwords where email = @email2";
                        select.Parameters.Add(new System.Data.SqlClient.SqlParameter("@email2", EmailBox.Text));
                        Session["userType"] = Convert.ToString(select.ExecuteScalar());

                        select.CommandText = "Select email from Passwords where email = @email3";
                        select.Parameters.Add(new System.Data.SqlClient.SqlParameter("@email3", EmailBox.Text));
                        Session["userEmail"] = Convert.ToString(select.ExecuteScalar());

                        Response.Redirect("Dashboard.aspx");
                        sc.Close();
                    }
                    else
                        OutputLabel.Text = "Password is wrong.";
                }
            }
            else // if the username doesn't exist, it will show failure
            {
                OutputLabel.Text = "Login failed.";
            }
            
        }
        catch (Exception ex)
        {
            OutputLabel.Text = "Database Error." + ex;
        }

    }

    protected void PasswordBox_TextChanged(object sender, EventArgs e)
    {

    }
}