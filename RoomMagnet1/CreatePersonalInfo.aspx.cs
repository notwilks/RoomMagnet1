using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class CreatePersonalInfo : System.Web.UI.Page
{
    SqlConnection sc = new SqlConnection(WebConfigurationManager.ConnectionStrings["RoomMagnetAWS"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        OutputLabel.Text = "" + Convert.ToString(Session["userType"]);
    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        sc.Open();

        System.Data.SqlClient.SqlCommand insert = new System.Data.SqlClient.SqlCommand();
        insert.Connection = sc;

        System.Data.SqlClient.SqlCommand setPass = new System.Data.SqlClient.SqlCommand();
        setPass.Connection = sc;

        System.Data.SqlClient.SqlCommand select = new System.Data.SqlClient.SqlCommand();
        select.Connection = sc;

        if (Convert.ToString(Session["userType"]) == "T")
        {
            Tenant tempTenant = new Tenant();

            tempTenant.SetFirstName(FirstNameBox.Text);
            tempTenant.SetLastName(LastNameBox.Text);

            if (dobBox.Text.Length == 10)
            {
                tempTenant.SetBirthDate(Convert.ToDateTime(dobBox.Text));
            }

            try
            {
                //Insert user info into tenant table
                insert.CommandText = "INSERT INTO [dbo].[Tenant] (firstName, lastName, email, birthDate, gender) VALUES " +
                    "(@firstName, @lastName, @email, @dob, @gender)";

                insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@firstName", tempTenant.GetFirstName()));
                insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lastName", tempTenant.GetLastName()));
                insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@email", Convert.ToString(Session["userEmail"])));
                insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@dob", tempTenant.GetBirthDate()));
                insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@gender", DropDownList1.SelectedValue));

                insert.ExecuteNonQuery();

                Response.Redirect("Dashboard.aspx");
            }
            catch
            {
                OutputLabel.Text = "An error occured.";
            }

        }
        else if (Convert.ToString(Session["userType"]) == "H")
        {
            Host tempHost = new Host();

            tempHost.SetFirstName(FirstNameBox.Text);
            tempHost.SetLastName(LastNameBox.Text);
            tempHost.SetPhoneNumber(phoneNumberBox.Text);

            if (dobBox.Text.Length == 10)
            {
                tempHost.SetBirthDate(Convert.ToDateTime(dobBox.Text));
            }

            try
            {
                //Insert user info into host table
                insert.CommandText = "INSERT INTO [dbo].[Host] (firstName, lastName, email, birthDate, gender, phoneNumber) VALUES " +
                    "(@firstName, @lastName, @email, @dob, @gender, @phoneNumber)";

                insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@firstName", tempHost.GetFistName()));
                insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lastName", tempHost.GetLastName()));
                insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@email", Convert.ToString(Session["userEmail"])));
                insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@dob", tempHost.GetBirthDate()));
                insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@gender", DropDownList1.SelectedValue));
                insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@phoneNumber", tempHost.GetPhoneNumber()));

                insert.ExecuteNonQuery();

                Response.Redirect("CreateHostProperty.aspx");
            }
            catch
            {
                if (FirstNameBox.Text.Length > 0 && LastNameBox.Text.Length > 0 && dobBox.MaxLength == 10)
                {
                    OutputLabel.Text = "An account with this email already exists.";
                }
            }


        }

        else
        {
            OutputLabel.Text = "An error occured.";
        }
    }
}