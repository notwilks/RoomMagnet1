using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Security.Cryptography;

public partial class CreateEmailPassword : System.Web.UI.Page
{
    SqlConnection sc = new SqlConnection(WebConfigurationManager.ConnectionStrings["RoomMagnetAWS"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        OutputLabel.Text = "" + Convert.ToString(Session["userType"]);
    }

    protected void NextButton_Click(object sender, EventArgs e)
    {
        sc.Open();

        System.Data.SqlClient.SqlCommand insert = new System.Data.SqlClient.SqlCommand();
        insert.Connection = sc;

        System.Data.SqlClient.SqlCommand setPass = new System.Data.SqlClient.SqlCommand();
        setPass.Connection = sc;

        System.Data.SqlClient.SqlCommand select = new System.Data.SqlClient.SqlCommand();
        select.Connection = sc;
        try
        {
            if (PasswordBox.Text == ConfirmPasswordBox.Text)
            {
                if (EmailBox.Text == ConfirmEmailBox.Text)
                {


                    if (PasswordBox.Text.Length >= 8)
                    {
                        setPass.CommandText = "INSERT INTO [dbo].[Passwords] (email, password, userType, lastUpdated, lastUpdatedBy) VALUES " +
                                            "(@email, @password, @userType, @lastUpdated, @lastUpdatedBy)";

                        setPass.Parameters.Add(new SqlParameter("@email", EmailBox.Text));
                        setPass.Parameters.Add(new SqlParameter("@password", PasswordHash.HashPassword(PasswordBox.Text)));
                        setPass.Parameters.Add(new SqlParameter("@userType", Convert.ToString(Session["userType"])));
                        setPass.Parameters.Add(new SqlParameter("@lastUpdatedBy", Environment.UserName));
                        setPass.Parameters.Add(new SqlParameter("@lastUpdated", DateTime.Now));

                        setPass.ExecuteNonQuery();

                        Session["userEmail"] = EmailBox.Text;

                        Session["userType"] = Convert.ToString(Session["userType"]);

                        Response.Redirect("CreatePersonalInfo.aspx");

                    }

                    else
                    {
                        OutputLabel.Text = "Password must be at least 8 characters long.";
                    }
                }
                else
                {
                    OutputLabel.Text = "Emails do not match.";

                }
            }
            else
            {
                OutputLabel.Text = "Passwords do not match.";
            }
        }
        catch(Exception ex)
        {
            OutputLabel.Text = "An account with this email already exists." + ex;
        }
    }
}