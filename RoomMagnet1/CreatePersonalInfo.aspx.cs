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

        if (Convert.ToString(Session["userType"]) == "T")
        {
            TenantTypeLbl.InnerText = "Tenant Type";
            OtherTenantLbl.InnerText = "Other";
        }
        else if (Convert.ToString(Session["userType"]) == "H")
        {
            TenantTypeLbl.InnerText = "";
            TenantTypeBox.Visible = false;
            OtherTenantLbl.InnerText = "";
            OtherTBox.Visible = false;
        }
    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        String tenantType = "";
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

            try
            {
                // Validates whether all the textboxes have actual values in them
                if (FirstNameBox.Text != "" && LastNameBox.Text != "" && dobBox.Text != "" && phoneNumberBox.Text != "" && TenantTypeBox.SelectedValue != "0" && bioBox.Text != "")
                {
                    //TenantTypeErrorLbl.Text = "";

                    if (Convert.ToInt32(CalculateAge(Convert.ToDateTime(dobBox.Text))) > 17 && Convert.ToInt32(CalculateAge(Convert.ToDateTime(dobBox.Text))) < 150)
                    {
                        tempTenant.SetBirthDate(Convert.ToDateTime(HttpUtility.HtmlEncode(dobBox.Text)));

                        // Validates the phone number only contains - and #'s
                        if (phoneNumberBox.Text.Contains("A") || phoneNumberBox.Text.Contains("B") || phoneNumberBox.Text.Contains("C") || phoneNumberBox.Text.Contains("D") || phoneNumberBox.Text.Contains("E")
                            || phoneNumberBox.Text.Contains("F") || phoneNumberBox.Text.Contains("G") || phoneNumberBox.Text.Contains("H") || phoneNumberBox.Text.Contains("I") || phoneNumberBox.Text.Contains("J")
                            || phoneNumberBox.Text.Contains("K") || phoneNumberBox.Text.Contains("L") || phoneNumberBox.Text.Contains("M") || phoneNumberBox.Text.Contains("N") || phoneNumberBox.Text.Contains("O")
                            || phoneNumberBox.Text.Contains("P") || phoneNumberBox.Text.Contains("Q") || phoneNumberBox.Text.Contains("R") || phoneNumberBox.Text.Contains("S") || phoneNumberBox.Text.Contains("T")
                            || phoneNumberBox.Text.Contains("U") || phoneNumberBox.Text.Contains("V") || phoneNumberBox.Text.Contains("W") || phoneNumberBox.Text.Contains("X") || phoneNumberBox.Text.Contains("Y")
                            || phoneNumberBox.Text.Contains("Z") || phoneNumberBox.Text.Contains("!") || phoneNumberBox.Text.Contains("@") || phoneNumberBox.Text.Contains("#") || phoneNumberBox.Text.Contains("$")
                            || phoneNumberBox.Text.Contains("%") || phoneNumberBox.Text.Contains("^") || phoneNumberBox.Text.Contains("&") || phoneNumberBox.Text.Contains("*") || phoneNumberBox.Text.Contains("(")
                            || phoneNumberBox.Text.Contains(")") || phoneNumberBox.Text.Contains("_") || phoneNumberBox.Text.Contains("+") || phoneNumberBox.Text.Contains("=") || phoneNumberBox.Text.Length != 12)
                        {
                            pNumBoxErrorLbl.Text = "Please enter a phone number in '###-###-####' format.";
                        }
                        else
                        {
                            pNumBoxErrorLbl.Text = "";

                            // Validates the true value of the TenantTypeBox 
                            if (TenantTypeBox.SelectedValue == "Other")
                            {
                                if (OtherTBox.Text == "")
                                {
                                    OtherErrorLbl.Text = "Please enter a tenant type.";
                                    //TenantTypeErrorLbl.Text = "";
                                }
                                else
                                {
                                    tenantType = HttpUtility.HtmlEncode(OtherTBox.Text);
                                    OtherErrorLbl.Text = "";
                                    //TenantTypeErrorLbl.Text = "";
                                }
                            }

                            // Setting all the datafields in tempTenant
                            tempTenant.SetFirstName(FirstNameBox.Text);
                            tempTenant.SetLastName(LastNameBox.Text);
                            tempTenant.SetPhoneNumber(phoneNumberBox.Text);
                            tempTenant.SetBiography(bioBox.Text);

                            if (tenantType == "")
                            {
                                tempTenant.SetTenantType(TenantTypeBox.SelectedValue);
                            }
                            else
                            {
                                tempTenant.SetTenantType(tenantType);
                            }

                            //Insert user info into tenant table
                            insert.CommandText = "INSERT INTO [dbo].[Tenant] (firstName, lastName, email, phoneNumber, birthDate, gender, lastUpdated, lastUpdatedBy, biography, tenantType) VALUES " +
                                "(@firstName, @lastName, @email, @phone, @dob, @gender, @lastUpdated, @lastUpdatedBy, @biography, @tenantType)";

                            insert.Parameters.AddWithValue("@firstName", tempTenant.GetFirstName());
                            insert.Parameters.AddWithValue("@lastName", tempTenant.GetLastName());
                            insert.Parameters.AddWithValue("@email", Convert.ToString(Session["userEmail"]));
                            insert.Parameters.AddWithValue("@phone", tempTenant.GetPhoneNumber());
                            insert.Parameters.AddWithValue("@dob", tempTenant.GetBirthDate());
                            insert.Parameters.AddWithValue("@gender", DropDownList1.SelectedValue);
                            insert.Parameters.AddWithValue("@lastUpdatedBy", "Joe Muia");
                            insert.Parameters.AddWithValue("@lastUpdated", DateTime.Now);
                            insert.Parameters.AddWithValue("@biography", tempTenant.GetBiography());
                            insert.Parameters.AddWithValue("@tenantType", tempTenant.GetTenantType());

                            insert.ExecuteNonQuery();

                            //pulling current tenant ID for inserting images
                            insert.CommandText = "Select tenantID from Tenant where email = @tenEmail";
                            insert.Parameters.AddWithValue("@tenEmail", Convert.ToString(Session["userEmail"]));

                            int tenID = Convert.ToInt32(insert.ExecuteScalar());

                            insert.CommandText = "Insert into TenantImages (tenantID) VALUES (" + tenID + ")";
                            insert.ExecuteNonQuery();

                            Response.Redirect("TenantAccountConfirmation.aspx");
                        }
                    }
                    else
                    {
                        dobErrorLbl.Text = "Error, Invalid Age.";
                    }                 
                }
                else
                {
                    if (TenantTypeBox.SelectedValue == "0")
                    {
                        //TenantTypeErrorLbl.Text = "Please select an option.";
                    }
                }
            }
            catch (Exception ex)
            {
                OutputLabel.Text = "" + ex;
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
                if (FirstNameBox.Text != "" && LastNameBox.Text != "" && dobBox.Text != "" && phoneNumberBox.Text.Length == 12)
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
                        tempHost.SetBiography(bioBox.Text);
                        pNumBoxErrorLbl.Text = "";
                        //Insert user info into host table
                        insert.CommandText = "INSERT INTO [dbo].[Host] (firstName, lastName, email, birthDate, gender, phoneNumber, lastUpdatedBy, lastUpdated, biography) " +
                            "VALUES (@firstName, @lastName, @email, @dob, @gender, @phoneNumber, @lastUpdatedBy, @lastUpdated, @biography)";

                        insert.Parameters.Add(new SqlParameter("@firstName", tempHost.GetFistName()));
                        insert.Parameters.Add(new SqlParameter("@lastName", tempHost.GetLastName()));
                        insert.Parameters.Add(new SqlParameter("@email", Convert.ToString(Session["userEmail"])));
                        insert.Parameters.Add(new SqlParameter("@dob", tempHost.GetBirthDate()));
                        insert.Parameters.Add(new SqlParameter("@gender", DropDownList1.SelectedItem.Value));
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
    protected void PopulateBtn_Click(object sender, EventArgs e)
    {
        FirstNameBox.Text = "John";
        LastNameBox.Text = "Doe";
        dobBox.Text = "01/01/2019";
        bioBox.Text = "This is an example biography.";
        phoneNumberBox.Text = "540-111-1111";

    }

    protected void TenantTypeBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(TenantTypeBox.SelectedItem.Value.Equals("Other"))
        {
            OtherTenantLbl.Visible = true;
            OtherTBox.Visible = true;
        }
        else
        {
            OtherTenantLbl.Visible = false;
            OtherTBox.Visible = false;
        }
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedItem.Value.Equals("O"))
        {
            OtherGenderLbl.Visible = true;
            OtherGenderBox.Visible = true;
        }
        else
        {
            OtherGenderLbl.Visible = false;
            OtherGenderBox.Visible = false;
        }
    }

    public string CalculateAge(DateTime DOB)
    {
        DateTime dob = Convert.ToDateTime(DOB);
        DateTime today = DateTime.Today;
        int age = today.Year - dob.Year;

        if ((today.Month < dob.Month) || ((today.Month == dob.Month) && (today.Day < dob.Day)))
        {
            age--;
        }

        return age.ToString();
    }
}