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
    String tenantActive;
    String hostActive;

    SqlConnection sc = new SqlConnection(WebConfigurationManager.ConnectionStrings["RoomMagnetAWS"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void NextButton_Click(object sender, EventArgs e)
    {

        try
        {


            sc.Open();
            System.Data.SqlClient.SqlCommand findPass = new System.Data.SqlClient.SqlCommand();
            findPass.Connection = sc;

            System.Data.SqlClient.SqlCommand select = new System.Data.SqlClient.SqlCommand();
            select.Connection = sc;

            // SELECT PASSWORD STRING WHERE THE ENTERED USERNAME MATCHES
            select.CommandText = "select userType from Passwords where email = @email0";
            select.Parameters.Add(new System.Data.SqlClient.SqlParameter("@email0", HttpUtility.HtmlEncode(EmailBox.Text)));
            String userType = Convert.ToString(select.ExecuteScalar());

            if (userType == "T")
            {
                select.CommandText = "Select active from tenant where email = @email11";
                select.Parameters.Add(new System.Data.SqlClient.SqlParameter("@email11", HttpUtility.HtmlEncode(EmailBox.Text)));
                tenantActive = Convert.ToString(select.ExecuteScalar());
            }
            else if(userType == "H")
            {
                select.CommandText = "Select active from host where email = @email12";
                select.Parameters.Add(new System.Data.SqlClient.SqlParameter("@email12", HttpUtility.HtmlEncode(EmailBox.Text)));
                hostActive = Convert.ToString(select.ExecuteScalar());
            }

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
                        NextButton.Enabled = false;
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
                        Session["userType"] = HttpUtility.HtmlEncode(Convert.ToString(select.ExecuteScalar()));

                        select.CommandText = "Select email from Passwords where email = @email3";
                        select.Parameters.Add(new System.Data.SqlClient.SqlParameter("@email3", EmailBox.Text));
                        Session["userEmail"] = HttpUtility.HtmlEncode(Convert.ToString(select.ExecuteScalar()));

                        //Create a cookie so we can check if browser session is still alive baby. 
                        HttpCookie httpCookie = new HttpCookie("Session");
                        httpCookie["loggedin"] = "true";
                        Response.Cookies.Add(httpCookie);

                        if(Convert.ToString(Session["userType"]) == "T")
                        {
                            if (tenantActive == "F")
                            {
                                OutputLabel.Text = "Your account has been deactivated. Please contact an administrator for more information.";
                                Session["userType"] = "";
                                Session["userEmail"] = "";
                                break;
                            }
                            else
                            {
                                Response.Redirect("TenantDashboard.aspx");
                            }
                            
                        }
                        else if (Convert.ToString(Session["userType"]) == "H")
                        {
                            if (hostActive == "F")
                            {
                                OutputLabel.Text = "Your account has been deactivated. Please contact an administrator for more information.";
                                Session["userType"] = "";
                                Session["userEmail"] = "";
                                break;
                            }
                            else
                            {
                                Response.Redirect("HostDashboard.aspx");
                            }
                            
                        }
                        else if (Convert.ToString(Session["userType"]) == "A")
                        {
                            Response.Redirect("AdminDashboard.aspx");
                        }
                        else
                        {
                            //nothing
                        }
                        
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