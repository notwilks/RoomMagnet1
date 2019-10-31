using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class TenantDashboard : System.Web.UI.Page
{
    SqlConnection sc = new SqlConnection(WebConfigurationManager.ConnectionStrings["RoomMagnetAWS"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {

        // Load database data into local variables to be displayed on dashboard
        sc.Open();
        SqlCommand select = new SqlCommand("SELECT concat(firstName, ' ', lastName, 'Name goes here'), email," +
            "NULLIF(phoneNumber, 'Phone number goes here'), birthDate FROM [Tenant] where email = @email", sc);
        SqlDataReader reader = select.ExecuteReader();
        while (reader.Read())
        {
            String name = reader.GetString(0);
            String email = reader.GetString(1);
            String phoneNumber = reader.GetString(2);
            DateTime DOB = Convert.ToDateTime(reader.GetDateTime(3));
            DateTime today = DateTime.Now;
            String age;
            if (reader.IsDBNull(3))
            {
                age = "Age goes here";
            }
            else
            {
                age = CalculateAge(reader.GetDateTime(3)).ToString();
            }
            
            
        }

        select.CommandText = "Select (firstName + ' ' + lastName) from host where email = @email";
        select.Parameters.Add(new System.Data.SqlClient.SqlParameter("@email", Session["userEmail"]));
        String userName = Convert.ToString(select.ExecuteScalar());
        FirstNameLastNameHeader.Text = userName + "'s Dashboard";
        

        //Header.Text = "Host Dashboard.";
        //select.CommandText = "Select (firstName + ' ' + lastName) from host where email = @email1";
        //select.Parameters.Add(new System.Data.SqlClient.SqlParameter("@email1", Session["userEmail"]));
        //String hostName = Convert.ToString(select.ExecuteScalar());
        //ProfileHeader.Text = "Welcome " + hostName;

    }
    protected void EditProfileBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("EditAccountInformation.aspx");
    }
    protected void SearchProperties_Click(object sender, EventArgs e)
    {
        Response.Redirect("SearchResultPage.aspx");
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