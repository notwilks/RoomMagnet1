﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Security.Cryptography;

public partial class CreateEmailandPassword : System.Web.UI.Page
{
    SqlConnection sc = new SqlConnection(WebConfigurationManager.ConnectionStrings["RoomMagnetAWS"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        OutputLabel.Text = "" + Convert.ToString(Session["userType"]);
    }

    protected void nextButton_Click(object sender, EventArgs e)
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
                if (PasswordBox.Text.Length >= 8)
                {
                    setPass.CommandText = "INSERT INTO [dbo].[Passwords] (email, password, userType) VALUES " +
                                        "(@email, @password, @userType)";

                    setPass.Parameters.Add(new System.Data.SqlClient.SqlParameter("@email", EmailBox.Text));
                    setPass.Parameters.Add(new System.Data.SqlClient.SqlParameter("@password", PasswordHash.HashPassword(PasswordBox.Text)));
                    setPass.Parameters.Add(new System.Data.SqlClient.SqlParameter("@userType", Convert.ToString(Session["userType"])));

                    setPass.ExecuteNonQuery();

                    Session["userEmail"] = EmailBox.Text;

                    Session["userType"] = Convert.ToString(Session["userType"]);

                    Response.Redirect("CreateAccount.aspx", false);
                }

                else
                {
                    OutputLabel.Text = "Password must be at least 8 characters long.";
                }
            }
            else
            {
                OutputLabel.Text = "Passwords do not match.";
            }
        }
        catch
        {
                OutputLabel.Text = "An account with this email already exists.";
        }
    }

    protected void ConfirmPasswordBox_TextChanged(object sender, EventArgs e)
    {

    }
}