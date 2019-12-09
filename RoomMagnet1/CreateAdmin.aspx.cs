using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;

public partial class CreateAdmin : System.Web.UI.Page
{
    

    SqlConnection sc = new SqlConnection(WebConfigurationManager.ConnectionStrings["RoomMagnetAWS"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["userType"]) == "" || Convert.ToString(Session["userEmail"]) == "")
        {
            Response.Redirect("HomePage.aspx");
        }
        else
        {

        }
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
            if (EmailBox.Text.Contains("@") && EmailBox.Text.Length > 0 && ConfirmEmailBox.Text.Length > 0)
            {
                EmailErrorLbl.Text = "";

                if (EmailBox.Text == ConfirmEmailBox.Text)
                {
                    EmailErrorLbl.Text = "";
                    ConfirmEmailErrorLbl.Text = "";
                    PasswordErrorLbl.Text = "";
                    ConfirmPasswordErrorLbl.Text = "";

                    if (PasswordBox.Text.Length >= 8 && ConfirmPasswordBox.Text.Length >= 8)
                    {
                        PasswordErrorLbl.Text = "";
                        ConfirmPasswordErrorLbl.Text = "";

                        if (PasswordBox.Text.Contains("!") || PasswordBox.Text.Contains("@") || PasswordBox.Text.Contains("#") || PasswordBox.Text.Contains("$") || PasswordBox.Text.Contains("%")
                            || PasswordBox.Text.Contains("^") || PasswordBox.Text.Contains("&") || PasswordBox.Text.Contains("*") || PasswordBox.Text.Contains("(") || PasswordBox.Text.Contains(")")
                            || PasswordBox.Text.Contains("-") || PasswordBox.Text.Contains("_") || PasswordBox.Text.Contains("+") || PasswordBox.Text.Contains("="))
                        {
                            PasswordErrorLbl.Text = "";
                            ConfirmPasswordErrorLbl.Text = "";

                            if (PasswordBox.Text.Contains("0") || PasswordBox.Text.Contains("1") || PasswordBox.Text.Contains("2") || PasswordBox.Text.Contains("3") || PasswordBox.Text.Contains("4")
                                || PasswordBox.Text.Contains("5") || PasswordBox.Text.Contains("6") || PasswordBox.Text.Contains("7") || PasswordBox.Text.Contains("8") || PasswordBox.Text.Contains("9"))
                            {
                                PasswordErrorLbl.Text = "";
                                ConfirmPasswordErrorLbl.Text = "";

                                if (PasswordBox.Text == ConfirmPasswordBox.Text)
                                {
                                    PasswordErrorLbl.Text = "";
                                    ConfirmPasswordErrorLbl.Text = "";

                                    setPass.CommandText = "INSERT INTO [dbo].[Passwords] (email, password, userType, lastUpdated, lastUpdatedBy) VALUES " +
                                                    "(@email, @password, @userType, @lastUpdated, @lastUpdatedBy)";

                                    setPass.Parameters.Add(new SqlParameter("@email", EmailBox.Text));
                                    setPass.Parameters.Add(new SqlParameter("@password", PasswordHash.HashPassword(PasswordBox.Text)));
                                    setPass.Parameters.Add(new SqlParameter("@userType", "A"));
                                    setPass.Parameters.Add(new SqlParameter("@lastUpdatedBy", "Joe Muia"));
                                    setPass.Parameters.Add(new SqlParameter("@lastUpdated", DateTime.Now));

                                    setPass.ExecuteNonQuery();

                                    OutputLabel.Text = "Account successfully created.";
                                    EmailBox.Text = "";
                                    ConfirmEmailBox.Text = "";
                                    PasswordBox.Text = "";
                                    ConfirmPasswordBox.Text = "";
                                }
                                else
                                {
                                    PasswordErrorLbl.Text = "Please make sure both passwords match.";
                                    ConfirmPasswordErrorLbl.Text = "Please make sure both passwords match.";
                                }
                            }
                            else
                            {
                                PasswordErrorLbl.Text = "Passsword must contain a number.";

                                if (ConfirmPasswordBox.Text != PasswordBox.Text)
                                {
                                    ConfirmPasswordErrorLbl.Text = "Please make sure passwords match.";
                                }
                            }
                        }
                        else
                        {
                            PasswordErrorLbl.Text = "Password must contain a special character.";

                            if (ConfirmPasswordBox.Text != PasswordBox.Text)
                            {
                                ConfirmPasswordErrorLbl.Text = "Please make sure passwords match.";
                            }
                        }
                    }
                    else
                    {
                        PasswordErrorLbl.Text = "Password must be at least 8 characters long.";

                        if (ConfirmPasswordBox.Text != PasswordBox.Text)
                        {
                            ConfirmPasswordErrorLbl.Text = "Please make sure passwords match.";
                        }
                    }
                }
                else
                {
                    EmailErrorLbl.Text = "Please make sure both emails match.";
                    ConfirmEmailErrorLbl.Text = "Please make sure both emails match.";

                    if (PasswordBox.Text == "")
                    {
                        PasswordErrorLbl.Text = "Please enter a valid password.";
                    }

                    if (ConfirmPasswordErrorLbl.Text == "")
                    {
                        ConfirmPasswordErrorLbl.Text = "Please enter a valid password.";
                    }
                }
            }
            else
            {
                EmailErrorLbl.Text = "Please enter a valid email address.";

                if (ConfirmEmailBox.Text == "")
                {
                    ConfirmEmailErrorLbl.Text = "Please enter a valid email address.";
                }

                if (PasswordBox.Text == "")
                {
                    PasswordErrorLbl.Text = "Please enter a valid password.";
                }

                if (ConfirmPasswordBox.Text == "")
                {
                    ConfirmPasswordErrorLbl.Text = "Please enter a valid password.";
                }
            }
        }

        catch (Exception ex)
        {
            //OutputLabel.Text = "An account with this email already exists.";
        }
    }
}