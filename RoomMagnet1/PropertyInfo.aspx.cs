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
    public int accomID = 0;
    public int hostID = 0;

    

    public string jsStreetName = "715 S Main St Harrisonburg, VA, USA";
    SqlConnection sc = new SqlConnection(WebConfigurationManager.ConnectionStrings["RoomMagnetAWS"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["userType"]) == "T")
        {
            intentToLease.Visible = true;
            MessageButton.Visible = true;
        }
        else
        {
            intentToLease.Visible = false;
            MessageButton.Visible = false;
        }
        String bathroomBadge = "images/private-bath.png";
        String entranceBadge = "images/private-entrance.png";
        String storageBadge = "images/storagespace.png";
        String furnishedBadge = "images/furnished-badge.png";
        String hasPetsBadge = "images/haspets.png";
        String smokerBadge = "images/non-smoker-badge.png";
        String wifiBadge = "images/wifi.png";
        String parkingBadge = "images/parking.png";
        String KitchenBadge = "images/kitchen-badge.png";
        String laundryBadge = "images/laundry.png";
        String cableBadge = "images/cable.png";
        String allowsPetsBadge = "images/allowspets.png";

        

        SqlCommand select = new SqlCommand();
        select.Connection = sc;
        sc.Open();

        select.CommandText = "Select h.firstName, ISNULL(h.cleared, 'F'), h.gender, h.birthDate, h.biography, " +
            "a.accommodationID, a.description, a.city, a.state, a.extraInfo, a.price, a.roomType, a.numOfTenants, a.zipCode, a.neighborhood, " +
            "aa.bathroom, aa.entrance, aa.furnished, aa.storage, aa.smoker, aa.kitchen, aa.allowPets, aa.cable, aa.laundry, aa.parking, aa.wifi, aa.pets, " +
            "ISNULL(ai.mainImage, ''), ISNULL(ai.image2, ''), ISNULL(ai.image3, ''), ISNULL(ai.image4, ''), ISNULL(ai.image5, ''), ISNULL(ai.image6, ''), " +
            "ISNULL(ai.image7, ''), ISNULL(ai.image8, ''),  ISNULL(ai.image9, ''),  ISNULL(ai.image10, ''), " +
            "ISNULL (hi.mainImage, ''), ISNULL(hi.image2, ''), ISNULL(hi.image3, ''), a.houseNumber, a.street, a.country, h.hostID " +
            "from Host h inner join Accommodation a on a.hostID = h.HostID " + 
            "inner join AccommodationAmmenity aa on a.accommodationID = aa.accommodationID " +
            "inner join AccommodationImages ai on a.accommodationID = ai.accommodationID " +
            "inner join HostImages hi on hi.hostID = h.hostID " +
            "where a.accommodationID = @propID";

        //FOR WYATT -- GOOGLE MAPS API ADDRESS
        //house number = reader.getString(40)
        //street = 41
        //city = 7
        //state = 8
        //country = 42
        //zip = 13

        select.Parameters.Add(new System.Data.SqlClient.SqlParameter("@propID", Session["propertyID"]));

        SqlDataReader reader = select.ExecuteReader();

        while(reader.Read())
        {
            jsStreetName = HttpUtility.HtmlEncode(reader.GetString(40) + " " + reader.GetString(41) + " " + reader.GetString(7) + ", " + reader.GetString(8) + ", " + reader.GetString(42));
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
            hostBio.Text = HttpUtility.HtmlEncode(reader.GetString(4));

            //setting Property title
            PropTitle.Text = HttpUtility.HtmlEncode(reader.GetString(6));

            //setting city, state, zip
            CityStateZip.Text = HttpUtility.HtmlEncode(reader.GetString(7)) + ", " + HttpUtility.HtmlEncode(reader.GetString(8)) + " " + HttpUtility.HtmlEncode(reader.GetString(13));

            //setting property bio
            PropBio.Text = HttpUtility.HtmlEncode(reader.GetString(9));

            //setting room type
            roomType.Text = HttpUtility.HtmlEncode(reader.GetString(11));

            //setting number of current residents
            numOfTenants.Text = Convert.ToString(HttpUtility.HtmlEncode(reader.GetInt32(12)));

            //setting neighborhood
            neighborhood.Text = HttpUtility.HtmlEncode(reader.GetString(14));

            //setting price
            price.Text = "$" + HttpUtility.HtmlEncode(reader.GetDecimal(10).ToString(".00")) + "/month";


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

            //Setting prop image 3
            String image3 = reader.GetString(29);
            if (image3.Length > 0)
            {
                var cDiv3 = new HtmlGenericControl("div")
                {

                };
                cDiv3.Attributes.Add("class", "carousel-item");
                carouselInner.Controls.Add(cDiv3);

                var propImage3 = new HtmlGenericControl("img")
                {

                };
                propImage3.Attributes.Add("src", image3);
                propImage3.Attributes.Add("class", "d-block w-100 propertyc");
                cDiv3.Controls.Add(propImage3);
            }

            //Setting prop image 4
            String image4 = reader.GetString(30);
            if (image4.Length > 0)
            {
                var cDiv4 = new HtmlGenericControl("div")
                {

                };
                cDiv4.Attributes.Add("class", "carousel-item");
                carouselInner.Controls.Add(cDiv4);

                var propImage4 = new HtmlGenericControl("img")
                {

                };
                propImage4.Attributes.Add("src", image4);
                propImage4.Attributes.Add("class", "d-block w-100 propertyc");
                cDiv4.Controls.Add(propImage4);
            }

            //Setting prop image 5
            String image5 = reader.GetString(31);
            if (image5.Length > 0)
            {
                var cDiv5 = new HtmlGenericControl("div")
                {

                };
                cDiv5.Attributes.Add("class", "carousel-item");
                carouselInner.Controls.Add(cDiv5);

                var propImage5 = new HtmlGenericControl("img")
                {

                };
                propImage5.Attributes.Add("src", image5);
                propImage5.Attributes.Add("class", "d-block w-100 propertyc");
                cDiv5.Controls.Add(propImage5);
            }

            //Setting prop image 6
            String image6 = reader.GetString(32);
            if (image6.Length > 0)
            {
                var cDiv6 = new HtmlGenericControl("div")
                {

                };
                cDiv6.Attributes.Add("class", "carousel-item");
                carouselInner.Controls.Add(cDiv6);

                var propImage6 = new HtmlGenericControl("img")
                {

                };
                propImage6.Attributes.Add("src", image6);
                propImage6.Attributes.Add("class", "d-block w-100 propertyc");
                cDiv6.Controls.Add(propImage6);
            }

            //Setting prop image 7
            String image7 = reader.GetString(33);
            if (image7.Length > 0)
            {
                var cDiv7 = new HtmlGenericControl("div")
                {

                };
                cDiv7.Attributes.Add("class", "carousel-item");
                carouselInner.Controls.Add(cDiv7);

                var propImage7 = new HtmlGenericControl("img")
                {

                };
                propImage7.Attributes.Add("src", image7);
                propImage7.Attributes.Add("class", "d-block w-100 propertyc");
                cDiv7.Controls.Add(propImage7);
            }

            //Setting prop image 8
            String image8 = reader.GetString(34);
            if (image8.Length > 0)
            {
                var cDiv8 = new HtmlGenericControl("div")
                {

                };
                cDiv8.Attributes.Add("class", "carousel-item");
                carouselInner.Controls.Add(cDiv8);

                var propImage8 = new HtmlGenericControl("img")
                {

                };
                propImage8.Attributes.Add("src", image8);
                propImage8.Attributes.Add("class", "d-block w-100 propertyc");
                cDiv8.Controls.Add(propImage8);
            }

            //Setting prop image 9
            String image9 = reader.GetString(35);
            if (image9.Length > 0)
            {
                var cDiv9 = new HtmlGenericControl("div")
                {

                };
                cDiv9.Attributes.Add("class", "carousel-item");
                carouselInner.Controls.Add(cDiv9);

                var propImage9 = new HtmlGenericControl("img")
                {

                };
                propImage9.Attributes.Add("src", image9);
                propImage9.Attributes.Add("class", "d-block w-100 propertyc");
                cDiv9.Controls.Add(propImage9);
            }

            //Setting prop image 10
            String image10 = reader.GetString(36);
            if (image10.Length > 0)
            {
                var cDiv10 = new HtmlGenericControl("div")
                {

                };
                cDiv10.Attributes.Add("class", "carousel-item");
                carouselInner.Controls.Add(cDiv10);

                var propImage10 = new HtmlGenericControl("img")
                {

                };
                propImage10.Attributes.Add("src", image10);
                propImage10.Attributes.Add("class", "d-block w-100 propertyc");
                cDiv10.Controls.Add(propImage10);
            }

            //setting host main image
            String hostmainImage = reader.GetString(37);
            if (hostmainImage.Length > 0)
            {
                var cDiv11 = new HtmlGenericControl("div")
                {

                };
                cDiv11.Attributes.Add("class", "carousel-item active");
                hostcarousel.Controls.Add(cDiv11);

                var hostImage = new HtmlGenericControl("img")
                {

                };
                hostImage.Attributes.Add("src", hostmainImage);
                hostImage.Attributes.Add("class", "d-block w-100");
                cDiv11.Controls.Add(hostImage);
            }

            //setting host image 2
            String hostImage2 = reader.GetString(38);
            if (hostImage2.Length > 0)
            {
                var cDiv12 = new HtmlGenericControl("div")
                {

                };
                cDiv12.Attributes.Add("class", "carousel-item");
                hostcarousel.Controls.Add(cDiv12);

                var hostprofileImage2 = new HtmlGenericControl("img")
                {

                };
                hostprofileImage2.Attributes.Add("src", hostImage2);
                hostprofileImage2.Attributes.Add("class", "d-block w-100 img-fluid");
                cDiv12.Controls.Add(hostprofileImage2);
            }

            //setting property badge 1
            var badge1 = new HtmlGenericControl("img")
            {

            };

            if (reader.GetSqlString(15) == "T")
            {
                badge1.Attributes.Add("src", bathroomBadge);
                badgeArea.Controls.Add(badge1);
            }
            badge1.Style.Add("max-width", "130px;");
            badge1.Style.Add("max-height", "30px;");
            badge1.Style.Add("margin-right", "5px;");
            badge1.Style.Add("margin-top", "5px;");

            //setting property badge 2
            var badge2 = new HtmlGenericControl("img")
            {

            };

            if (reader.GetSqlString(16) == "T")
            {
                badge2.Attributes.Add("src", entranceBadge);
                badgeArea.Controls.Add(badge2);
            }
            badge2.Style.Add("max-width", "130px;");
            badge2.Style.Add("max-height", "30px;");
            badge2.Style.Add("margin-right", "5px;");
            badge2.Style.Add("margin-top", "5px;");

            //setting property badge 3
            var badge3 = new HtmlGenericControl("img")
            {

            };

            if (reader.GetSqlString(17) == "T")
            {
                badge3.Attributes.Add("src", furnishedBadge);
                badgeArea.Controls.Add(badge3);
            }
            badge3.Style.Add("max-width", "130px;");
            badge3.Style.Add("max-height", "30px;");
            badge3.Style.Add("margin-right", "5px;");
            badge3.Style.Add("margin-top", "5px;");

            //setting property badge 4
            var badge4 = new HtmlGenericControl("img")
            {

            };

            if (reader.GetSqlString(18) == "T")
            {
                badge4.Attributes.Add("src", storageBadge);
                badgeArea.Controls.Add(badge4);
            }
            badge4.Style.Add("max-width", "130px;");
            badge4.Style.Add("max-height", "30px;");
            badge4.Style.Add("margin-right", "5px;");
            badge4.Style.Add("margin-top", "5px;");

            //setting property badge 5
            var badge5 = new HtmlGenericControl("img")
            {

            };

            if (reader.GetSqlString(19) == "F")
            {
                badge5.Attributes.Add("src", smokerBadge);
                badgeArea.Controls.Add(badge5);
            }
            badge5.Style.Add("max-width", "130px;");
            badge5.Style.Add("max-height", "30px;");
            badge5.Style.Add("margin-right", "5px;");
            badge5.Style.Add("margin-top", "5px;");

            //setting property badge 6
            var badge6 = new HtmlGenericControl("img")
            {

            };

            if (reader.GetSqlString(20) == "T")
            {
                badge6.Attributes.Add("src", KitchenBadge);
                badgeArea.Controls.Add(badge6);
            }
            badge6.Style.Add("max-width", "130px;");
            badge6.Style.Add("max-height", "30px;");
            badge6.Style.Add("margin-right", "5px;");
            badge6.Style.Add("margin-top", "5px;");

            //setting property badge 7
            var badge7 = new HtmlGenericControl("img")
            {

            };

            if (reader.GetSqlString(21) == "T")
            {
                badge7.Attributes.Add("src", allowsPetsBadge);
                badgeArea.Controls.Add(badge7);
            }
            badge7.Style.Add("max-width", "130px;");
            badge7.Style.Add("max-height", "30px;");
            badge7.Style.Add("margin-right", "5px;");
            badge7.Style.Add("margin-top", "5px;");

            //setting property badge 8
            var badge8 = new HtmlGenericControl("img")
            {

            };

            if (reader.GetSqlString(22) == "T")
            {
                badge8.Attributes.Add("src", cableBadge);
                badgeArea.Controls.Add(badge8);
            }
            badge8.Style.Add("max-width", "130px;");
            badge8.Style.Add("max-height", "30px;");
            badge8.Style.Add("margin-right", "5px;");
            badge8.Style.Add("margin-top", "5px;");

            //setting property badge 9
            var badge9 = new HtmlGenericControl("img")
            {

            };

            if (reader.GetSqlString(23) == "T")
            {
                badge9.Attributes.Add("src", laundryBadge);
                badgeArea.Controls.Add(badge9);
            }
            badge9.Style.Add("max-width", "130px;");
            badge9.Style.Add("max-height", "30px;");
            badge9.Style.Add("margin-right", "5px;");
            badge9.Style.Add("margin-top", "5px;");

            //setting property badge 10
            var badge10 = new HtmlGenericControl("img")
            {

            };

            if (reader.GetSqlString(24) == "T")
            {
                badge10.Attributes.Add("src", parkingBadge);
                badgeArea.Controls.Add(badge10);
            }
            badge10.Style.Add("max-width", "130px;");
            badge10.Style.Add("max-height", "30px;");
            badge10.Style.Add("margin-right", "5px;");
            badge10.Style.Add("margin-top", "5px;");

            //setting property badge 11
            var badge11 = new HtmlGenericControl("img")
            {

            };

            if (reader.GetSqlString(25) == "T")
            {
                badge11.Attributes.Add("src", wifiBadge);
                badgeArea.Controls.Add(badge11);
            }
            badge11.Style.Add("max-width", "130px;");
            badge11.Style.Add("max-height", "30px;");
            badge11.Style.Add("margin-right", "5px;");
            badge11.Style.Add("margin-top", "5px;");

            //setting property badge 12
            var badge12 = new HtmlGenericControl("img")
            {

            };

            if (reader.GetSqlString(26) == "T")
            {
                badge12.Attributes.Add("src", hasPetsBadge);
                badgeArea.Controls.Add(badge12);
            }
            badge12.Style.Add("max-width", "130px;");
            badge12.Style.Add("max-height", "30px;");
            badge12.Style.Add("margin-right", "5px;");
            badge12.Style.Add("margin-top", "5px;");

            //setting ID of favorite Button
            if(Convert.ToString(Session["userType"]) == "T")
            {
                FavoriteButton.ID = Convert.ToString(reader.GetSqlInt32(5));
                FavoriteButton.Click += new ImageClickEventHandler(FavoriteButton_Click);
                FavoriteButton.ImageUrl = "images/favorite-badge.png";
                FavoriteButton.Visible = true;
            }
            else
            {
                FavoriteButton.Click += new ImageClickEventHandler(NoFav);
                FavoriteButton.ImageUrl = "images/favorite-badge.png";
                FavoriteButton.Visible = true;
            }

            accomID = reader.GetInt32(5);
            hostID = reader.GetInt32(43);

        }
        sc.Close();
        reader.Close();

        SqlCommand fav = new SqlCommand();
        fav.Connection = sc;

        sc.Open();

        try
        {
            if (Convert.ToString(Session["userType"]) == "T")
            {
                

                fav.CommandText = "Select tenantID from Tenant where email = '" + Session["userEmail"] + "'";
                int tenID2 = Convert.ToInt32(fav.ExecuteScalar());

                fav.CommandText = "Select ISNULL(tenantID, 0) from FavoriteProperty where accommodationID = " + accomID + " and tenantID = " + tenID2;
                int tenID = Convert.ToInt32(fav.ExecuteScalar());

                if (tenID == tenID2)
                {
                    FavoriteButton.ImageUrl = "images/favorited.png";
                    FavoriteButton.Click += new ImageClickEventHandler(AlreadyFav);
                    FavoriteButton.Visible = true;
                }
                else
                {
                    FavoriteButton.ImageUrl = "images/favorite-badge.png";
                    FavoriteButton.Visible = true;
                }

                fav.CommandText = "Select tenantID from RentalAgreement where hostID = " + hostID;
                int tenIDRental = Convert.ToInt32(fav.ExecuteScalar());

                if (tenID2 == tenIDRental)
                {
                    intentToLease.Text = "View Rental Agreement";
                }
                else
                {
                    intentToLease.Text = "Request Rental Agreement";
                }
            }
        }
        catch
        {

        }
        sc.Close();


        
    }

    protected void MessageButton_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("TenantMessageCenter.aspx");
    }

    protected void FavoriteButton_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton b = sender as ImageButton;

        // Get tenantID to from Tenant to be inserted into FavoriteProperty
        SqlCommand selectTenantID = new SqlCommand("SELECT tenantID FROM Tenant WHERE email = @email", sc);
        selectTenantID.Parameters.AddWithValue("@email", Convert.ToString(Session["userEmail"]));
        sc.Open();
        String tenantID = selectTenantID.ExecuteScalar().ToString();


        String ID = b.ID;
        //Setting favorite
        SqlCommand insertFavorite = new SqlCommand("INSERT INTO FavoriteProperty(tenantID, accommodationID, lastUpdated, lastUpdatedBy) VALUES(@tID, @aID, @lastUpdated, @lastUpdatedBy)", sc);
        insertFavorite.Parameters.AddWithValue("@tID", tenantID);
        insertFavorite.Parameters.AddWithValue("@aID", b.ID);
        insertFavorite.Parameters.AddWithValue("@lastUpdated", DateTime.Now.ToString());
        insertFavorite.Parameters.AddWithValue("@lastUpdatedBy", "Joe Muia");
        insertFavorite.ExecuteNonQuery();
        sc.Close();
        b.Visible = false;

        FavoriteButton.Visible = true;
        FavoriteButton.ImageUrl = "images/favorited.png";
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

    protected void NoFav(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup();", true);
        FavoriteButton.Visible = true;
    }

    protected void AlreadyFav(object sender, EventArgs e)
    {
        SqlCommand fav = new SqlCommand();
        fav.Connection = sc;

        sc.Open();

        fav.CommandText = "Select tenantID from Tenant where email = '" + Session["userEmail"] + "'";
        int tenID2 = Convert.ToInt32(fav.ExecuteScalar());

        fav.CommandText = "Select ISNULL(tenantID, 0) from FavoriteProperty where accommodationID = " + accomID + " and tenantID = " + tenID2;
        int tenID = Convert.ToInt32(fav.ExecuteScalar());

        fav.CommandText = "Delete From FavoriteProperty where accommodationID = " + accomID + " and tenantID = " + tenID2;
        fav.ExecuteNonQuery();

        FavoriteButton.ImageUrl = "images/favorite-badge.png";
        FavoriteButton.Visible = true;
        sc.Close();
    }

    protected void intentToLease_Click(object sender, EventArgs e)
    {
        SqlCommand select = new SqlCommand();
        select.Connection = sc;

        sc.Open();

        select.CommandText = "Select (firstName + ' ' + LastName), isnull(cleared, 'F'), tenantID from Tenant where email = '" + Session["userEmail"] + "'";

        SqlDataReader reader = select.ExecuteReader();


        while (reader.Read())
        {
            Session["tenantLease"] = reader.GetString(0);
            Session["tenantCleared"] = reader.GetString(1);
            Session["tenantIDLease"] = reader.GetInt32(2);
        }

        Session["hostIDLease"] = hostID;
        Session["accomIDLease"] = accomID;

        Response.Redirect("IntentToLease.aspx");

        sc.Close();
    }
}