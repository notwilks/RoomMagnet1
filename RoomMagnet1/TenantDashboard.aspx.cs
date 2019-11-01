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
        SqlCommand select = new SqlCommand("SELECT concat(firstName, ' ', lastName), email," +
            "phoneNumber, birthDate, isnull(biography, 'bio goes here') FROM [Tenant] where email = @email", sc);
        select.Parameters.AddWithValue("@email", Session["userEmail"]);
        SqlDataReader reader = select.ExecuteReader();
        String name = "";
        String email = "";
        String phoneNumber = "";
        DateTime DOB = DateTime.Now;
        DateTime today = DateTime.Now;
        String age = "";
        String bio = "";
        while (reader.Read())
        {
            name = reader.GetString(0);
            email = reader.GetString(1);
            phoneNumber = reader.GetString(2);
            DOB = Convert.ToDateTime(reader.GetDateTime(3));
            today = DateTime.Now;
            age = CalculateAge(reader.GetDateTime(3)).ToString(); ;
            bio = reader.GetString(4);
            
            

        }
        

        FirstNameLastNameHeader.Text = HttpUtility.HtmlEncode(name) + "'s Dashboard";
        FirstNameLastNameAge.Text = HttpUtility.HtmlEncode(name) + ", " + age;
        BioLabel.Text = HttpUtility.HtmlEncode(bio);





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