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
        // UserType and UserEmail test code
        //OutputLabel.Text = "" + Convert.ToString(Session["userType"]) + Convert.ToString(Session["userEmail"]);
    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        sc.Open();

        SqlCommand insert = new SqlCommand();
        insert.Connection = sc;

        SqlCommand setPass = new SqlCommand();
        setPass.Connection = sc;

        SqlCommand select = new SqlCommand();
        select.Connection = sc;

        if (Convert.ToString(Session["userType"]) == "T")
        {
            Tenant tempTenant = new Tenant();

            if (dobBox.Text.Length == 10)
            {
                tempTenant.SetBirthDate(Convert.ToDateTime(dobBox.Text));
            }
            

            try
            {
                if (FirstNameBox.Text != "" && LastNameBox.Text != "" && dobBox.Text != "" && phoneNumberBox.Text.Length != 12)
                {
                    pNumBoxErrorLbl.Text = "";
                    phoneNumberBox.Text.ToUpper();

                    if (phoneNumberBox.Text.Contains("A") || phoneNumberBox.Text.Contains("B") || phoneNumberBox.Text.Contains("C") || phoneNumberBox.Text.Contains("D") || phoneNumberBox.Text.Contains("E")
                        || phoneNumberBox.Text.Contains("F") || phoneNumberBox.Text.Contains("G") || phoneNumberBox.Text.Contains("H") || phoneNumberBox.Text.Contains("I") || phoneNumberBox.Text.Contains("J")
                        || phoneNumberBox.Text.Contains("K") || phoneNumberBox.Text.Contains("L") || phoneNumberBox.Text.Contains("M") || phoneNumberBox.Text.Contains("N") || phoneNumberBox.Text.Contains("O")
                        || phoneNumberBox.Text.Contains("P") || phoneNumberBox.Text.Contains("Q") || phoneNumberBox.Text.Contains("R") || phoneNumberBox.Text.Contains("S") || phoneNumberBox.Text.Contains("T")
                        || phoneNumberBox.Text.Contains("U") || phoneNumberBox.Text.Contains("V") || phoneNumberBox.Text.Contains("W") || phoneNumberBox.Text.Contains("X") || phoneNumberBox.Text.Contains("Y")
                        || phoneNumberBox.Text.Contains("Z") || phoneNumberBox.Text.Contains("!") || phoneNumberBox.Text.Contains("@") || phoneNumberBox.Text.Contains("#") || phoneNumberBox.Text.Contains("$")
                        || phoneNumberBox.Text.Contains("%") || phoneNumberBox.Text.Contains("^") || phoneNumberBox.Text.Contains("&") || phoneNumberBox.Text.Contains("*") || phoneNumberBox.Text.Contains("(")
                        || phoneNumberBox.Text.Contains(")") || phoneNumberBox.Text.Contains("_") || phoneNumberBox.Text.Contains("+") || phoneNumberBox.Text.Contains("="))
                    {
                        pNumBoxErrorLbl.Text = "Please enter a phone number in '###-###-####' format.";
                    }
                    else
                    {
                        tempTenant.SetFirstName(FirstNameBox.Text);
                        tempTenant.SetLastName(LastNameBox.Text);
                        tempTenant.SetPhoneNumber(phoneNumberBox.Text);
                        tempTenant.SetBiography(bioBox.Text);
                        pNumBoxErrorLbl.Text = "";

                        //Insert user info into tenant table
                        insert.CommandText = "INSERT INTO [dbo].[Tenant] (firstName, lastName, email, phoneNumber, birthDate, gender, lastUpdated, lastUpdatedBy, biography) VALUES " +
                            "(@firstName, @lastName, @email, @phone, @dob, @gender, @lastUpdated, @lastUpdatedBy, @biography)";

                        insert.Parameters.AddWithValue("@firstName", tempTenant.GetFirstName());
                        insert.Parameters.AddWithValue("@lastName", tempTenant.GetLastName());
                        insert.Parameters.AddWithValue("@email", Convert.ToString(Session["userEmail"]));
                        insert.Parameters.AddWithValue("@phone", tempTenant.GetPhoneNumber());
                        insert.Parameters.AddWithValue("@dob", tempTenant.GetBirthDate());
                        insert.Parameters.AddWithValue("@gender", DropDownList1.SelectedValue);
                        insert.Parameters.AddWithValue("@lastUpdatedBy", Environment.UserName);
                        insert.Parameters.AddWithValue("@lastUpdated", DateTime.Now);
                        insert.Parameters.AddWithValue("@biography", tempTenant.GetBiography());

                        insert.ExecuteNonQuery();

                        Response.Redirect("TenantAccountConfirmation.aspx");
                    }
                }
                else
                {
                    pNumBoxErrorLbl.Text = "Please enter a phone number in '###-###-####' format.";
                }
            }
            catch(Exception ex)
            {
                OutputLabel.Text = "An error occured." + ex;
            }

        }
        else if (Convert.ToString(Session["userType"]) == "H")
        {
            Host tempHost = new Host();

            if (dobBox.Text.Length == 10)
            {
                tempHost.SetBirthDate(Convert.ToDateTime(dobBox.Text));
            }

            try
            {
                if (FirstNameBox.Text != "" && LastNameBox.Text != "" && dobBox.Text != "" && phoneNumberBox.Text.Length != 12)
                {
                    pNumBoxErrorLbl.Text = "";

                    if (phoneNumberBox.Text.Contains("A") || phoneNumberBox.Text.Contains("B") || phoneNumberBox.Text.Contains("C") || phoneNumberBox.Text.Contains("D") || phoneNumberBox.Text.Contains("E")
                        || phoneNumberBox.Text.Contains("F") || phoneNumberBox.Text.Contains("G") || phoneNumberBox.Text.Contains("H") || phoneNumberBox.Text.Contains("I") || phoneNumberBox.Text.Contains("J")
                        || phoneNumberBox.Text.Contains("K") || phoneNumberBox.Text.Contains("L") || phoneNumberBox.Text.Contains("M") || phoneNumberBox.Text.Contains("N") || phoneNumberBox.Text.Contains("O")
                        || phoneNumberBox.Text.Contains("P") || phoneNumberBox.Text.Contains("Q") || phoneNumberBox.Text.Contains("R") || phoneNumberBox.Text.Contains("S") || phoneNumberBox.Text.Contains("T")
                        || phoneNumberBox.Text.Contains("U") || phoneNumberBox.Text.Contains("V") || phoneNumberBox.Text.Contains("W") || phoneNumberBox.Text.Contains("X") || phoneNumberBox.Text.Contains("Y")
                        || phoneNumberBox.Text.Contains("Z") || phoneNumberBox.Text.Contains("!") || phoneNumberBox.Text.Contains("@") || phoneNumberBox.Text.Contains("#") || phoneNumberBox.Text.Contains("$")
                        || phoneNumberBox.Text.Contains("%") || phoneNumberBox.Text.Contains("^") || phoneNumberBox.Text.Contains("&") || phoneNumberBox.Text.Contains("*") || phoneNumberBox.Text.Contains("(")
                        || phoneNumberBox.Text.Contains(")") || phoneNumberBox.Text.Contains("_") || phoneNumberBox.Text.Contains("+") || phoneNumberBox.Text.Contains("="))
                    {
                        pNumBoxErrorLbl.Text = "Please enter a phone number in '###-###-####' format.";
                    }
                    else
                    {
                        tempHost.SetFirstName(FirstNameBox.Text);
                        tempHost.SetLastName(LastNameBox.Text);
                        tempHost.SetPhoneNumber(phoneNumberBox.Text);
                        pNumBoxErrorLbl.Text = "";
                        //Insert user info into host table
                        insert.CommandText = "INSERT INTO [dbo].[Host] (firstName, lastName, email, birthDate, gender, phoneNumber, lastUpdatedBy, lastUpdated, biography) " +
                            "VALUES (@firstName, @lastName, @email, @dob, @gender, @phoneNumber, @lastUpdatedBy, @lastUpdated, @biography)";

                        insert.Parameters.Add(new SqlParameter("@firstName", tempHost.GetFistName()));
                        insert.Parameters.Add(new SqlParameter("@lastName", tempHost.GetLastName()));
                        insert.Parameters.Add(new SqlParameter("@email", Convert.ToString(Session["userEmail"])));
                        insert.Parameters.Add(new SqlParameter("@dob", tempHost.GetBirthDate()));
                        insert.Parameters.Add(new SqlParameter("@gender", DropDownList1.SelectedValue));
                        insert.Parameters.Add(new SqlParameter("@phoneNumber", tempHost.GetPhoneNumber()));
                        insert.Parameters.Add(new SqlParameter("@lastUpdatedBy", "Joe Muia"));
                        insert.Parameters.Add(new SqlParameter("@lastUpdated", DateTime.Now));
                        insert.Parameters.Add(new SqlParameter("@biography", tempHost.GetBiography()));

                        insert.ExecuteNonQuery();

                        Response.Redirect("CreateProperty.aspx");
                    }
                }
                else
                {
                     pNumBoxErrorLbl.Text = "Please enter a phone number in '###-###-####' format.";
                }
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