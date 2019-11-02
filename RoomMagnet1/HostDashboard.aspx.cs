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
    protected void Page_Load(object sender, EventArgs e)
    {
        
        sc.Open();

        SqlCommand select = new SqlCommand();
        select.Connection = sc;
            
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

        select.CommandText = "Select bathroom, entrance, storage, pets, furnished, smoker from AccommodationAmmenity WHERE accommodationID in (select accommodationID from Accommodation where hostID in " +
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
              
            }
            reader.Close();
        }

        string image1 = checkBadge(cBadge1, "images/private-bath.png");
        string image2 = checkBadge(cBadge2, "images/private-entrance.png");
        string image3 = checkBadge(cBadge3, "iamges/closet-space-badge.png");
        string image4 = checkBadge(cBadge4, "images/add-badges-badge.png");
        string image5 = checkBadge(cBadge5, "images/furnished-badge.png");
        string image6 = checkBadge(cBadge6, "images/non-smoker-badge.png");

        addBadge(image1);
        addBadge(image2);
        addBadge(image3);
        addBadge(image4);
        addBadge(image5);
        addBadge(image6);


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
            newImg.Attributes.Add("style","max-width: 150px; margin-top: 3px");

            

            newP.Controls.Add(newImg);

            Control newContent = (ContentPlaceHolder)this.Master.FindControl("ContentPlaceHolder1");
            //Control container = newContent.chi
            //container.Controls.Add(newP);
            newContent.Controls.Add(newP);
            
        } 
    }
}