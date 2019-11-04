using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using Google.Cloud.Translation.V2;
using System.Web.UI.HtmlControls;

public partial class TenantDashboard : System.Web.UI.Page
{
    SqlConnection sc = new SqlConnection(WebConfigurationManager.ConnectionStrings["RoomMagnetAWS"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {

        

        

        // Load database data into local variables to be displayed on dashboard
        sc.Open();
        SqlCommand selectTenantInfo = new SqlCommand("SELECT concat(firstName, ' ', lastName), email," +
            "phoneNumber, birthDate, isnull(biography, 'bio goes here') FROM [Tenant] where email = @email", sc);
        selectTenantInfo.Parameters.AddWithValue("@email", Session["userEmail"]);
        SqlDataReader reader = selectTenantInfo.ExecuteReader();
        String name = "";
        String email = "";
        String phoneNumber = "";
        DateTime DOB = DateTime.Now;
        DateTime today = DateTime.Now;
        String age = "";
        String bio = "";
        char badge1 = 'F';
        char badge2 = 'F';
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

        SqlCommand selectBadge = new SqlCommand("SELECT undergraduateBage, graduateBadge FROM TenantBadges where email = email2", sc);
        selectBadge.Parameters.AddWithValue("@email", Session["userEmail"]);
        reader = selectBadge.ExecuteReader();
        while (reader.Read())
        {
            badge1 = Convert.ToChar(reader["undergraduateBadge"]);
            badge2 = Convert.ToChar(reader["graduateBadge"]);
        }
        reader.Close();

        string image1 = checkBadge(badge1, "images/undergrad-badge.png");
        string image2 = checkBadge(badge2, "images/masters-badge.png");

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

    protected string checkBadge(char badge, string img)
    {
        string image = "";

        if (badge.Equals('T'))
            image = img;

        return image;
    }

    protected void addBadge(string image)
    {
        if (image != "")
        {


            HtmlGenericControl newP = new HtmlGenericControl("p")
            {

            };

            Image newImg = new Image()
            {
                ImageUrl = image,

            };
            newImg.Attributes.Add("style", "max-width: 150px; margin-top: 3px; margin-right: 2rem;");

            newP.Controls.Add(newImg);
            badgeModule.Controls.Add(newImg);
        }
    }
}