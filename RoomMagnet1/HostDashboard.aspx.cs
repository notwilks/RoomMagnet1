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
public partial class HostDashboard : System.Web.UI.Page
{
    SqlConnection sc = new SqlConnection(WebConfigurationManager.ConnectionStrings["RoomMagnetAWS"].ConnectionString);
    char cBadge1;
    char cBadge2;
    char cBadge3;
    char cBadge4;
    char cBadge5;
    char cBadge6;
    char cBadge7;
    char cBadge8;
    char cBadge9;
    char cBadge10;
    char cBadge11;
    char cBadge12;
    
    String listing = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        
        sc.Open();

        SqlCommand select = new SqlCommand();
        select.Connection = sc;
        SqlCommand findListing = new SqlCommand();
        findListing.Connection = sc;

        //selecting name info
        select.CommandText = "Select (firstName + ' ' + lastName) from host where email = @email";
            select.Parameters.Add(new System.Data.SqlClient.SqlParameter("@email", Session["userEmail"]));
            String userName = HttpUtility.HtmlEncode(Convert.ToString(select.ExecuteScalar()));
            FirstNameLastNameHeader.Text = userName + "'s Dashboard";
            HostName.Text = userName.ToString();

            //selecting property name
            select.CommandText = "Select description from Accommodation where hostID in (select hostID from Host where email = @email1)";
            select.Parameters.Add(new System.Data.SqlClient.SqlParameter("@email1", Session["userEmail"]));
            PropertyName.Text = HttpUtility.HtmlEncode(Convert.ToString(select.ExecuteScalar()));

            //selecting description on the property
            select.CommandText = "Select extraInfo from Accommodation where hostID in (select hostID from Host where email = @email2)";
            select.Parameters.Add(new System.Data.SqlClient.SqlParameter("@email2", Session["userEmail"]));
            PropertyInfo.Text = HttpUtility.HtmlEncode(Convert.ToString(select.ExecuteScalar()));

        //Header.Text = "Host Dashboard.";
        //select.CommandText = "Select (firstName + ' ' + lastName) from host where email = @email1";
        //select.Parameters.Add(new System.Data.SqlClient.SqlParameter("@email1", Session["userEmail"]));
        //String hostName = Convert.ToString(select.ExecuteScalar());
        //ProfileHeader.Text = "Welcome " + hostName;

        select.CommandText = "Select bathroom, entrance, storage, pets, furnished, smoker, wifi, parking, kitchen, laundry, cable, allowPets from AccommodationAmmenity WHERE accommodationID in (select accommodationID from Accommodation where hostID in " +
        "(select hostID from Host where email = @email3))";

        select.Parameters.Add(new SqlParameter("@email3", Session["userEmail"]));
        using (SqlDataReader reader = select.ExecuteReader())
        {
            while (reader.Read())
            {
                cBadge1 = Convert.ToChar(reader["bathroom"]);
                cBadge2 = Convert.ToChar(reader["entrance"]);
                cBadge3 = Convert.ToChar(reader["storage"]);
                cBadge4 = Convert.ToChar(reader["pets"]);
                cBadge5 = Convert.ToChar(reader["furnished"]);
                cBadge6 = Convert.ToChar(reader["smoker"]);
                cBadge7 = Convert.ToChar(reader["wifi"]);
                cBadge8 = Convert.ToChar(reader["parking"]);
                cBadge10 = Convert.ToChar(reader["kitchen"]);
                cBadge9 = Convert.ToChar(reader["laundry"]);
                cBadge11 = Convert.ToChar(reader["cable"]);
                cBadge12 = Convert.ToChar(reader["allowPets"]);
              
            }
            reader.Close();
        }

        string image1 = checkBadge(cBadge1, "images/private-bath.png");
        string image2 = checkBadge(cBadge2, "images/private-entrance.png");
        string image3 = checkBadge(cBadge3, "images/closet-space-badge.png");
        string image4 = checkBadge(cBadge4, "images/add-badges-badge.png");
        string image5 = checkBadge(cBadge5, "images/furnished-badge.png");
        string image6 = checkBadge(cBadge6, "images/non-smoker-badge.png");
        string image7 = checkBadge(cBadge7, "images/add-badges-badge.png");
        string image8 = checkBadge(cBadge8, "images/add-badges-badge.png");
        string image9 = checkBadge(cBadge9, "images/add-badges-badge.png");
        string image10 = checkBadge(cBadge10, "images/kitchen-badge.png");
        string image11 = checkBadge(cBadge11, "images/add-badges-badge.png");
        string image12 = checkBadge(cBadge12, "images/add-badges-badge.png");

        addBadge(image1);
        addBadge(image2);
        addBadge(image3);
        addBadge(image4);
        addBadge(image5);
        addBadge(image6);
        addBadge(image7);
        addBadge(image8);
        addBadge(image9);
        addBadge(image10);
        addBadge(image11);
        addBadge(image12);


        // Finds whether the Host's Accommodation is currently being listed or not
        findListing.CommandText = "SELECT Listed FROM Accommodation WHERE HostID in (SELECT HostID FROM HOST WHERE Email = @email)";
        findListing.Parameters.Add(new SqlParameter("@email", Session["userEmail"]));
        listing = Convert.ToString(findListing.ExecuteScalar());

        if (listing == "F")
        {
            ListPropertyButton.Visible = true;
            UnlistPropertyButton.Visible = false;
            CreatePropertyButton.Visible = false;
        }
        else if (listing == "T")
        {
            ListPropertyButton.Visible = false;
            UnlistPropertyButton.Visible = true;
            CreatePropertyButton.Visible = false;
        }
        else
        {
            ListPropertyButton.Visible = false;
            UnlistPropertyButton.Visible = false;
            CreatePropertyButton.Visible = true;
        }

        sc.Close();
    }
    protected void EditProfileBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("EditAccountInformation.aspx");
    }
    protected void SearchProperties_Click(object sender, EventArgs e)
    {
        Response.Redirect("SearchResultPage.aspx");
    }

    protected void EditPropertyButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("EditProperty.aspx");
    }

    protected void ListPropertyButton_Clicked(object sender, EventArgs e)
    {
        SqlCommand setList = new SqlCommand();
        setList.Connection = sc;
        SqlCommand findHID = new SqlCommand();
        findHID.Connection = sc;
        int hID;

        sc.Open();

        findHID.CommandText = "SELECT HostID FROM HOST WHERE Email = @email";
        findHID.Parameters.Add(new SqlParameter("@email", Session["userEmail"]));
        hID = Convert.ToInt32(findHID.ExecuteScalar());

        listing = "T";

        setList.CommandText = "UPDATE Accommodation SET Listed = @listed WHERE HostID = @hostID";
        setList.Parameters.Add(new SqlParameter("@hostID", hID));
        setList.Parameters.Add(new SqlParameter("@listed", listing));

        setList.ExecuteNonQuery();

        Response.Redirect("HostDashboard.aspx");
    }

    protected void UnlistPropertyButton_Clicked(object sender, EventArgs e)
    {
        SqlCommand unsetList = new SqlCommand();
        unsetList.Connection = sc;
        SqlCommand findHID = new SqlCommand();
        findHID.Connection = sc;
        int hID;

        sc.Open();

        findHID.CommandText = "SELECT HostID FROM HOST WHERE Email = @email";
        findHID.Parameters.Add(new SqlParameter("@email", Session["userEmail"]));
        hID = Convert.ToInt32(findHID.ExecuteScalar());

        listing = "F";

        unsetList.CommandText = "UPDATE Accommodation SET Listed = @listed WHERE HostID = @hostID";
        unsetList.Parameters.Add(new SqlParameter("@listed", listing));
        unsetList.Parameters.Add(new SqlParameter("@hostID", hID));

        unsetList.ExecuteNonQuery();

        Response.Redirect("HostDashboard.aspx");
    }

    protected void CreatePropertyButton_Clicked(object sender, EventArgs e)
    {
        Response.Redirect("CreateProperty.aspx");
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
       if(image != "")
        {
            

            HtmlGenericControl newP = new HtmlGenericControl("p")
            {

            };
            
            Image newImg = new Image()
            {
                ImageUrl = image,
                
            };
            newImg.Attributes.Add("style","max-width: 150px; margin-top: 3px; margin-right: 2rem;");
            
            newP.Controls.Add(newImg);
            propertyModule.Controls.Add(newImg);
        } 
    }
}