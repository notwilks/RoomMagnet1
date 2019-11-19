using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class PropertyInfo : System.Web.UI.Page
{
    SqlConnection sc = new SqlConnection(WebConfigurationManager.ConnectionStrings["RoomMagnetAWS"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlCommand select = new SqlCommand();
        select.Connection = sc;
        sc.Open();

        select.CommandText = "Select h.firstName, ISNULL(h.cleared, 'F'), h.gender, h.birthDate, h.biography, " +
            "a.accommodationID, a.description, a.city, a.state, a.extraInfo, a.price, a.roomType, a.numOfTenants, a.zipCode, a.neighborhood, " +
            "aa.bathroom, aa.entrance, aa.furnished, aa.storage, aa.smoker, aa.kitchen, aa.allowPets, aa.cable, aa.laundry, aa.parking, aa.wifi, aa.pets, " +
            "ISNULL(ai.mainImage, ''), ISNULL(ai.image2, ''), ISNULL(ai.image3, ''), ISNULL(ai.image4, ''), ISNULL(ai.image5, ''), ISNULL(ai.image6, ''), " +
            "ISNULL(ai.image7, ''), ISNULL(ai.image8, ''),  ISNULL(ai.image9, ''),  ISNULL(ai.image10, ''), " +
            "ISNULL (hi.mainImage, ''), ISNULL(hi.image2, ''), ISNULL(hi.image3, '') " +
            "from Host h inner join Accommodation a on a.hostID = h.HostID " +
            "inner join AccommodationAmmenity aa on a.accommodationID = aa.accommodationID " +
            "inner join AccommodationImages ai on a.accommodationID = ai.accommodationID " +
            "inner join HostImages hi on hi.hostID = h.hostID " +
            "where a.accommodationID = @propID";

        select.Parameters.Add(new System.Data.SqlClient.SqlParameter("@propID", Session["propertyID"]));

        SqlDataReader reader = select.ExecuteReader();

        while(reader.Read())
        {
            //setting fixed top bar name
            HostNameLabel.Text = HttpUtility.HtmlEncode(reader.GetString(0)) + "'s Property";
            hostName2.Text = HttpUtility.HtmlEncode(reader.GetString(0));

            //settingbackground check icon
            String checker = HttpUtility.HtmlEncode(reader.GetString(1));
            if (checker == "T")
            {
                backgroundCheckImage.ImageUrl = "Images/icons-07.png";
            }
            else
            {
                backgroundCheckImage.ImageUrl = "Images/icons-08.png";
            }

            //setting host gender and age
            String gender = HttpUtility.HtmlEncode(reader.GetString(2));
            String age = CalculateAge(reader.GetDateTime(3)).ToString();
            if (gender == "M")
            {
                hostGender.Text = "Male, " + age;
            }
            else if(gender == "F")
            {
                hostGender.Text = "Female, " + age;
            }
            else
            {
                hostGender.Text = "Other, " + age;
            }

            //Setting host Bio
            hostBio.Text = reader.GetString(4);

            //setting Property title
            PropTitle.Text = reader.GetString(6);

            //setting city, state, zip
            CityStateZip.Text = reader.GetString(7) + ", " + reader.GetString(8) + " " + reader.GetString(13);

            //setting property bio
            PropBio.Text = reader.GetString(9);

            //setting room type
            roomType.Text = reader.GetString(11);

            //setting number of current residents
            numOfTenants.Text = Convert.ToString(reader.GetInt32(12));

            //setting neighborhood
            neighborhood.Text = reader.GetString(14);

            //setting price
            price.Text = "$" + reader.GetDecimal(10).ToString(".00") + "/month";


            //setting main image
            String mainImage = reader.GetString(27);

            var cDiv1 = new HtmlGenericControl("div")
            {

            };
            cDiv1.Attributes.Add("class", "carousel-item active");
            carouselInner.Controls.Add(cDiv1);

            var mainPropImage = new HtmlGenericControl("img")
            {

            };
            mainPropImage.Attributes.Add("src", mainImage);
            mainPropImage.Attributes.Add("class", "d-block w-100 propertyc");
            cDiv1.Controls.Add(mainPropImage);

            //setting prop image 2
            String image2 = reader.GetString(28);
            if (image2.Length > 0)
            {
                var cDiv2 = new HtmlGenericControl("div")
                {

                };
                cDiv2.Attributes.Add("class", "carousel-item");
                carouselInner.Controls.Add(cDiv2);

                var propImage2 = new HtmlGenericControl("img")
                {

                };
                propImage2.Attributes.Add("src", image2);
                propImage2.Attributes.Add("class", "d-block w-100 propertyc");
                cDiv2.Controls.Add(propImage2);
            }
        }
    }

    protected void MessageButton_Click(object sender, ImageClickEventArgs e)
    {

    }

    protected void FavoriteButton_Click(object sender, ImageClickEventArgs e)
    {

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

    protected void BackButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("SearchResultPage.aspx");
    }
}