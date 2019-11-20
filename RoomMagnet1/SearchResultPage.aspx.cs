using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class SearchResultPage : System.Web.UI.Page
{
    SqlConnection sc = new SqlConnection(WebConfigurationManager.ConnectionStrings["RoomMagnetAWS"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "initMap();", true);


            if (!Convert.ToString(Session["CitySearch"]).Equals("") || !Convert.ToString(Session["StateSearch"]).Equals(""))
            {
                CitySearchBox.Text = Convert.ToString(Session["CitySearch"]);
                stateBox.SelectedValue = Convert.ToString(Session["StateSearch"]);
                SearchButton_Click(sender, e);
            }

            if (IsPostBack)
            {
                Session["CitySearch"] = HttpUtility.HtmlEncode(CitySearchBox.Text);
                Session["StateSearch"] = HttpUtility.HtmlEncode(stateBox.SelectedValue);
                ViewState["AccommodationID"] = "";
            }

            SqlCommand insert = new SqlCommand();
            insert.Connection = sc;

            sc.Open();

            insert.CommandText = "Insert into Search(searchDate, lastUpdated, lastUpdatedBy, state, city) VALUES (@searchDate, @lastUp, @lastUpBy, @stateIN, @cityIN)";
            insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@searchDate", DateTime.Now));
            insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lastUp", DateTime.Now));
            insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lastUpBy", "Joe Muia"));
            insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@stateIN", Convert.ToString(Session["StateSearch"])));
            insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cityIN", Convert.ToString(Session["CitySearch"])));

            insert.ExecuteNonQuery();

            sc.Close();

            String bathroom = "%";
            String bathroomBadge = "images/private-bath.png";
            String entrance = "%";
            String entranceBadge = "images/private-entrance.png";
            String storage = "%";
            String storageBadge = "images/storagespace.png";
            String furnished = "%";
            String furnishedBadge = "images/furnished-badge.png";
            String pets = "%";
            String hasPetsBadge = "images/haspets.png";
            String smoker = "%";
            String smokerBadge = "images/non-smoker-badge.png";
            String wifi = "%";
            String wifiBadge = "images/wifi.png";
            String parking = "%";
            String parkingBadge = "images/parking.png";
            String kitchen = "%";
            String KitchenBadge = "images/kitchen-badge.png";
            String laundry = "%";
            String laundryBadge = "images/laundry.png";
            String cable = "%";
            String cableBadge = "images/cable.png";
            String allowsPets = "%";
            String allowsPetsBadge = "images/allowspets.png";

            if (PrivateEntranceBox.Checked)
            {
                entrance = "T";
            }
            else
            {
                entrance = "%";
            }

            if (PrivateBathroomBox.Checked)
            {
                bathroom = "T";
            }
            else
            {
                bathroom = "%";
            }

            if (StorageSpaceBox.Checked)
            {
                storage = "T";
            }
            else
            {
                storage = "%";
            }

            if (FurnishedBox.Checked)
            {
                furnished = "T";
            }
            else
            {
                furnished = "%";
            }

            if (HasPetsBox.Checked)
            {
                pets = "F";
            }
            else
            {
                pets = "%";
            }

            if (AllowsSmokingBox.Checked)
            {
                smoker = "T";
            }
            else
            {
                smoker = "%";
            }

            if (WifiBox.Checked)
            {
                wifi = "T";
            }
            else
            {
                wifi = "%";
            }

            if (ParkingBox.Checked)
            {
                parking = "T";
            }
            else
            {
                parking = "%";
            }

            if (KitchenBox.Checked)
            {
                kitchen = "T";
            }
            else
            {
                kitchen = "%";
            }

            if (LaundryBox.Checked)
            {
                laundry = "T";
            }
            else
            {
                laundry = "%";
            }

            if (CableBox.Checked)
            {
                cable = "T";
            }
            else
            {
                cable = "%";
            }

            if (AllowsPetsBox.Checked)
            {
                allowsPets = "T";
            }
            else
            {
                allowsPets = "%";
            }

            String order = "a.accommodationID";
            int minPrice = 0;
            int maxPrice = 50000;
            int count = 0;
            sc.Open();
            SqlCommand counter = new SqlCommand();
            counter.Connection = sc;

            if (SortByDropDown.SelectedValue == "PriceAscending")
            {
                order = "a.price asc";
            }

            if (SortByDropDown.SelectedValue == "PriceDescending")
            {
                order = "a.price desc";
            }

            if (SortByDropDown.SelectedValue == "DateNewOld")
            {
                order = "a.dateListed desc";
            }

            if (SortByDropDown.SelectedValue == "DateOldNew")
            {
                order = "a.dateListed asc";
            }

            counter.CommandText = "Select h.firstName, h.lastName, a.description, a.extraInfo, a.price, a.roomType, a.numOfTenants, aa.bathroom, aa.entrance, " +
                "aa.furnished, aa.storage, aa.smoker, aa.kitchen, a.zipCode, ai.mainImage, a.accommodationID, aa.wifi, aa.parking, aa.laundry, aa.cable, " +
                "aa.allowPets, aa.pets, h.cleared from Host h " +
                "inner join Accommodation a on a.hostID = h.HostID " +
                "inner join AccommodationAmmenity aa on a.accommodationID = aa.accommodationID " +
                "inner join AccommodationImages ai on a.accommodationID = ai.accommodationID " +
                "where UPPER(a.city) = @city " +
                "and a.state = @state " +
                "and aa.bathroom like @bathroom " +
                "and aa.entrance like @entrance " +
                "and aa.furnished like @furnished " +
                "and aa.storage like @storage " +
                "and aa.pets like @pets " +
                "and aa.smoker like @smoker " +
                "and aa.wifi like @wifi " +
                "and aa.parking like @parking " +
                "and aa.kitchen like @kitchen " +
                "and aa.laundry like @laundry " +
                "and aa.cable like @cable " +
                "and aa.allowPets like @allowsPets " +
                "and a.listed = 'T' " +
                "and a.price > @minPrice " +
                "and a.price <= @maxPrice " +
                "Order By " + order;



            //Select h.firstName, h.lastName, a.description, a.extraInfo from Host h inner join Accommodation a on a.hostID = h.HostID inner join AccommodationAmmenity aa on a.accommodationID = aa.accommodationID where UPPER(a.city) = @city and a.state = @state and aa.bathroom like @bathroom and aa.entrance like @entrance and aa.furnished like @furnished and aa.storage like @storage and aa.pets like @pets and aa.smoker like @smoker and aa.wifi like @wifi and aa.parking like @parking and aa.kitchen like @kitchen and aa.laundry like @laundry and aa.cable like @cable and aa.allowPets like @allowsPets

            counter.Parameters.Add(new System.Data.SqlClient.SqlParameter("@city", Convert.ToString(Session["CitySearch"])));
            counter.Parameters.Add(new System.Data.SqlClient.SqlParameter("@state", Convert.ToString(Session["StateSearch"])));
            counter.Parameters.Add(new System.Data.SqlClient.SqlParameter("@bathroom", bathroom));
            counter.Parameters.Add(new System.Data.SqlClient.SqlParameter("@entrance", entrance));
            counter.Parameters.Add(new System.Data.SqlClient.SqlParameter("@furnished", furnished));
            counter.Parameters.Add(new System.Data.SqlClient.SqlParameter("@storage", storage));
            counter.Parameters.Add(new System.Data.SqlClient.SqlParameter("@pets", pets));
            counter.Parameters.Add(new System.Data.SqlClient.SqlParameter("@smoker", smoker));
            counter.Parameters.Add(new System.Data.SqlClient.SqlParameter("@wifi", wifi));
            counter.Parameters.Add(new System.Data.SqlClient.SqlParameter("@parking", parking));
            counter.Parameters.Add(new System.Data.SqlClient.SqlParameter("@kitchen", kitchen));
            counter.Parameters.Add(new System.Data.SqlClient.SqlParameter("@laundry", laundry));
            counter.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cable", cable));
            counter.Parameters.Add(new System.Data.SqlClient.SqlParameter("@allowsPets", allowsPets));

            if (MinPriceBox.Text.Length > 0)
            {
                minPrice = Convert.ToInt32(MinPriceBox.Text);
            }
            counter.Parameters.Add(new System.Data.SqlClient.SqlParameter("@minPrice", minPrice));

            if (MaxPriceBox.Text.Length > 0)
            {
                maxPrice = Convert.ToInt32(MaxPriceBox.Text);
            }
            counter.Parameters.Add(new System.Data.SqlClient.SqlParameter("@maxPrice", maxPrice));

            SqlDataReader reader = counter.ExecuteReader();


            while (reader.Read())
            {
                //Get acommodationID to be inserted into FavoriteProperty in FavoriteBagdge_Click method
                //ViewState["AccommodationID"] = Convert.ToString(reader["a.accommodationID"]);
                //Generating the initial div
                var div1 = new HtmlGenericControl("div")
                {

                };

                ResultList.Controls.Add(div1);
                div1.Style.Add("margin-top", "1rem;");
                div1.Style.Add("border-bottom", "solid;");
                div1.Style.Add("border-bottom-width", "1px;");
                div1.Attributes.Add("class", "row");

                //generating the inside div
                var insidediv = new HtmlGenericControl("div")
                {

                };

                div1.Controls.Add(insidediv);
                insidediv.Attributes.Add("class", "col-md-4");


                SqlCommand select = new SqlCommand();
                select.Connection = sc;

                String hostfirst = reader.GetString(0);
                String hostLast = reader.GetString(1);
                String hostFull = hostfirst + "'s Property";

                //Host name in left column
                var hostName = new HtmlGenericControl("h2")
                {
                    InnerText = hostFull
                };

                insidediv.Controls.Add(hostName);
                hostName.Style.Add("margin-top", "1rem;");

                //Property name in left column
                String PropTempName = reader.GetString(2);
                var PropName = new HtmlGenericControl("h5")
                {
                    InnerText = PropTempName
                };

                insidediv.Controls.Add(PropName);

                String PropZip = "Zip code: " + reader.GetString(13);
                var propZip = new HtmlGenericControl("h6")
                {
                    InnerText = PropZip
                };

                insidediv.Controls.Add(propZip);

                //propery description in left column
                String PropTempBio = reader.GetString(3);
                var PropBio = new HtmlGenericControl("p")
                {
                    InnerText = PropTempBio
                };

                insidediv.Controls.Add(PropBio);
                PropBio.Attributes.Add("class", "list-group-item-text");

                //property badge 1
                var badge1 = new HtmlGenericControl("img")
                {

                };

                insidediv.Controls.Add(badge1);
                if (reader.GetSqlString(10) == "T")
                {
                    badge1.Attributes.Add("src", storageBadge);
                }
                badge1.Style.Add("max-width", "130px;");
                badge1.Style.Add("max-height", "30px;");
                badge1.Style.Add("margin-right", "5px;");
                badge1.Style.Add("margin-top", "5px;");

                //property badge 2
                var badge2 = new HtmlGenericControl("img")
                {

                };

                insidediv.Controls.Add(badge2);
                if (reader.GetSqlString(7) == "T")
                {
                    badge2.Attributes.Add("src", bathroomBadge);
                }
                badge2.Style.Add("max-width", "135px;");
                badge2.Style.Add("margin-right", "5px;");
                badge2.Style.Add("margin-top", "5px;");

                //property badge 3
                var badge3 = new HtmlGenericControl("img")
                {

                };

                insidediv.Controls.Add(badge3);
                if (reader.GetSqlString(8) == "T")
                {
                    badge3.Attributes.Add("src", entranceBadge);
                }
                badge3.Style.Add("max-width", "130px;");
                badge3.Style.Add("margin-right", "5px;");
                badge3.Style.Add("margin-top", "5px;");

                //property badge 4
                var badge4 = new HtmlGenericControl("img")
                {

                };

                insidediv.Controls.Add(badge4);
                if (reader.GetSqlString(9) == "T")
                {
                    badge4.Attributes.Add("src", furnishedBadge);
                }
                badge4.Style.Add("max-width", "110px;");
                badge4.Style.Add("max-height", "33px;");
                badge4.Style.Add("margin-right", "5px;");
                badge4.Style.Add("margin-top", "5px;");

                //property badge 5
                var badge5 = new HtmlGenericControl("img")
                {

                };

                insidediv.Controls.Add(badge5);
                if (reader.GetSqlString(11) == "F")
                {
                    badge5.Attributes.Add("src", smokerBadge);
                }
                badge5.Style.Add("max-width", "130px;");
                badge5.Style.Add("margin-right", "5px;");
                badge5.Style.Add("margin-top", "5px;");

                //property badge 6
                var badge6 = new HtmlGenericControl("img")
                {

                };

                insidediv.Controls.Add(badge6);
                if (reader.GetSqlString(12) == "T")
                {
                    badge6.Attributes.Add("src", KitchenBadge);
                }
                badge6.Style.Add("max-width", "100px;");
                badge6.Style.Add("max-height", "30px;");
                badge6.Style.Add("margin-right", "5px;");
                badge6.Style.Add("margin-top", "5px;");

                //property badge 7
                var badge7 = new HtmlGenericControl("img")
                {

                };

                if (reader.GetSqlString(16) == "T")
                {
                    badge6.Attributes.Add("src", wifiBadge);
                    insidediv.Controls.Add(badge7);
                }
                badge7.Style.Add("max-width", "100px;");
                badge7.Style.Add("max-height", "30px;");
                badge7.Style.Add("margin-right", "5px;");
                badge7.Style.Add("margin-top", "5px;");

                //property badge 8
                var badge8 = new HtmlGenericControl("img")
                {

                };

                if (reader.GetSqlString(17) == "T")
                {
                    badge8.Attributes.Add("src", parkingBadge);
                    insidediv.Controls.Add(badge8);
                }
                badge8.Style.Add("max-width", "130px;");
                badge8.Style.Add("max-height", "30px;");
                badge8.Style.Add("margin-right", "5px;");
                badge8.Style.Add("margin-top", "5px;");

                //property badge 9
                var badge9 = new HtmlGenericControl("img")
                {

                };

                if (reader.GetSqlString(18) == "T")
                {
                    badge9.Attributes.Add("src", laundryBadge);
                    insidediv.Controls.Add(badge9);
                }
                badge9.Style.Add("max-width", "100px;");
                badge9.Style.Add("max-height", "30px;");
                badge9.Style.Add("margin-right", "5px;");
                badge9.Style.Add("margin-top", "5px;");

                //property badge 10
                var badge10 = new HtmlGenericControl("img")
                {

                };

                if (reader.GetSqlString(19) == "T")
                {
                    badge10.Attributes.Add("src", cableBadge);
                    insidediv.Controls.Add(badge10);
                }
                badge10.Style.Add("max-width", "100px;");
                badge10.Style.Add("max-height", "30px;");
                badge10.Style.Add("margin-right", "5px;");
                badge10.Style.Add("margin-top", "5px;");

                //property badge 11
                var badge11 = new HtmlGenericControl("img")
                {

                };

                if (reader.GetSqlString(20) == "T")
                {
                    badge11.Attributes.Add("src", allowsPetsBadge);
                    insidediv.Controls.Add(badge11);
                }
                badge11.Style.Add("max-width", "100px;");
                badge11.Style.Add("max-height", "30px;");
                badge11.Style.Add("margin-right", "5px;");
                badge11.Style.Add("margin-top", "5px;");

                //property badge 12
                var badge12 = new HtmlGenericControl("img")
                {

                };

                if (reader.GetSqlString(21) == "T")
                {
                    badge12.Attributes.Add("src", hasPetsBadge);
                    insidediv.Controls.Add(badge12);
                }
                badge12.Style.Add("max-width", "100px;");
                badge12.Style.Add("max-height", "30px;");
                badge12.Style.Add("margin-right", "5px;");
                badge12.Style.Add("margin-top", "5px;");

                //new div for middle column
                var midCol = new HtmlGenericControl("div")
                {

                };

                div1.Controls.Add(midCol);
                midCol.Attributes.Add("class", "col-md-2");
                midCol.Style.Add("margin-top", ".5rem;");

                //background check status
                var approved = new HtmlGenericControl("img")
                {

                };

                midCol.Controls.Add(approved);
                if (reader.GetSqlString(22) == "T")
                {
                    approved.Attributes.Add("src", "images/icons-07.png");
                }
                else
                {
                    approved.Attributes.Add("src", "images/icons-08.png");
                }
                
                approved.Style.Add("max-width", "30px;");

                //price in middle column
                String Price = "$" + reader.GetDecimal(4).ToString(".00") + "/month";
                var price = new HtmlGenericControl("h4")
                {
                    InnerText = Price
                };

                midCol.Controls.Add(price);
                price.Attributes.Add("margin-top", "3rem;");

                //property type in middle column
                String propertyType = reader.GetString(5);
                var PropType = new HtmlGenericControl("h5")
                {
                    InnerText = propertyType
                };

                midCol.Controls.Add(PropType);

                //number of tenants in middle column
                String numOfTen = Convert.ToString(reader.GetInt32(6)) + " people live in this home";
                var tenants = new HtmlGenericControl("p")
                {
                    InnerText = numOfTen
                };

                midCol.Controls.Add(tenants);

                //adding new div for right column
                var rightCol = new HtmlGenericControl("div")
                {

                };

                div1.Controls.Add(rightCol);
                rightCol.Attributes.Add("class", "col-md-5");
                rightCol.Style.Add("margin-top", ".5rem;");
                rightCol.Style.Add("float", "right");
                rightCol.Style.Add("margin-bottom", "1rem;");

                //view profile badge
                ImageButton viewProfileBadge = new ImageButton();
                rightCol.Controls.Add(viewProfileBadge);
                viewProfileBadge.ImageUrl = "images/viewProp.png";
                viewProfileBadge.Style.Add("max-width", "90px;");
                viewProfileBadge.Style.Add("margin-right", "1rem;");
                viewProfileBadge.ID = Convert.ToString(reader.GetInt32(15)) + "P";
                viewProfileBadge.Click += new ImageClickEventHandler(ViewProfile_Click);


                if (Convert.ToString(Session["userType"]) == "T")
                {
                    //message badge
                    ImageButton messageBadge = new ImageButton();
                    rightCol.Controls.Add(messageBadge);
                    messageBadge.ImageUrl = "images/message-badge.png";
                    messageBadge.Style.Add("max-width", "100px;");
                    messageBadge.Style.Add("margin-right", "1rem;");

                }

                //main property image
                String propImage = reader.GetString(14);
                Image newImg = new Image()
                {
                    ImageUrl = propImage,

                };

                rightCol.Controls.Add(newImg);
                newImg.Style.Add("max-height", "300px;");
                newImg.Style.Add("margin-top", "1rem;");
                newImg.ImageUrl = propImage;

                count++;
            }
            sc.Close();
            countLabel.Text = "Your search returned " + count + " result(s) for '" + Convert.ToString(Session["CitySearch"]) + ", " + Convert.ToString(Session["StateSearch"]) + "'";
            Session["CitySearch"] = "";
            Session["StateSearch"] = "";

            //SqlCommand fav = new SqlCommand();
            //fav.Connection = sc;

            //sc.Open();

        }
    }

    protected void SearchButton_Click(object sender, EventArgs e)
    {
        
    }

    protected void PrivateEntranceBox_CheckedChanged(object sender, EventArgs e)
    {
        
    }

    protected void PrivateBathroomBox_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void FurnishedBox_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void StorageSpaceBox_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void HasPetsBox_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void AllowsSmokingBox_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void WifiBox_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void ParkingBox_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void KitchenBox_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void CableBox_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void AllowsPetsBox_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LaundryBox_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void FavoriteBadge_Click(object sender, EventArgs e)
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
    }

    protected void ViewProfile_Click(object sender, EventArgs e)
    {
        ImageButton b = sender as ImageButton;
        String ID = b.ID.Substring(0, b.ID.Length - 1);
        Session["propertyID"] = ID;
        Response.Redirect("PropertyInfo.aspx");
    }

}