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
        //CitySearchBox.Text = Convert.ToString(Session["CitySearch"]);
        //stateBox.SelectedValue = Convert.ToString(Session["StateSearch"]);

        //if(CitySearchBox.Text.Length > 0 && !IsPostBack)
        //{
        //    SearchButton_Click(sender, e);
        //    Session["CitySearch"] = "";
        //    Session["StateSearch"] = "";
        //}
        //Session["CitySearch"] = "";
        //Session["StateSearch"] = "";
    }

    protected void SearchButton_Click(object sender, EventArgs e)
    {
        String bathroom = "%";
        String bathroomBadge = "images/private-bath.png";
        String entrance = "%";
        String entranceBadge = "images/private-entrance.png";
        String storage = "%";
        String storageBadge = "images/closet-space-badge.png";
        String furnished = "%";
        String furnishedBadge = "images/furnished-badge.png";
        String pets = "%";
        String smoker = "%";
        String smokerBadge = "images/non-smoker-badge.png";
        String wifi = "%";
        String parking = "%";
        String kitchen = "%";
        String KitchenBadge = "images/kitchen-badge.png";
        String laundry = "%";
        String cable = "%";
        String allowsPets = "%";

        if (PrivateEntranceBox.Checked)
        {
            entrance = "T";
        }
        else
        {
            entrance = "%";
        }

        if(PrivateBathroomBox.Checked)
        {
            bathroom = "T";
        }
        else
        {
            bathroom = "%";
        }

        if(StorageSpaceBox.Checked)
        {
            storage = "T";
        }
        else
        {
            storage = "%";
        }

        if(FurnishedBox.Checked)
        {
            furnished = "T";
        }
        else
        {
            furnished = "%";
        }

        if(HasPetsBox.Checked)
        {
            pets = "F";
        }
        else
        {
            pets = "%";
        }

        if(AllowsSmokingBox.Checked)
        {
            smoker = "T";
        }
        else
        {
            smoker = "%";
        }

        if(WifiBox.Checked)
        {
            wifi = "T";
        }
        else
        {
            wifi = "%";
        }

        if(ParkingBox.Checked)
        {
            parking = "T";
        }
        else
        {
            parking = "%";
        }

        if(KitchenBox.Checked)
        {
            kitchen = "T";
        }
        else
        {
            kitchen = "%";
        }

        if(LaundryBox.Checked)
        {
            laundry = "T";
        }
        else
        {
            laundry = "%";
        }

        if(CableBox.Checked)
        {
            cable = "T";
        }
        else
        {
            cable = "%";
        }

        if(AllowsPetsBox.Checked)
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

        counter.CommandText = "Select h.firstName, h.lastName, a.description, a.extraInfo, a.price, a.roomType, a.numOfTenants, aa.bathroom, aa.entrance, aa.furnished, aa.storage, aa.smoker, aa.kitchen, a.zipCode, ai.mainImage from Host h " +
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
            "and a.price < @maxPrice " +
            "Order By " + order;

        //Select h.firstName, h.lastName, a.description, a.extraInfo from Host h inner join Accommodation a on a.hostID = h.HostID inner join AccommodationAmmenity aa on a.accommodationID = aa.accommodationID where UPPER(a.city) = @city and a.state = @state and aa.bathroom like @bathroom and aa.entrance like @entrance and aa.furnished like @furnished and aa.storage like @storage and aa.pets like @pets and aa.smoker like @smoker and aa.wifi like @wifi and aa.parking like @parking and aa.kitchen like @kitchen and aa.laundry like @laundry and aa.cable like @cable and aa.allowPets like @allowsPets

        counter.Parameters.Add(new System.Data.SqlClient.SqlParameter("@city", CitySearchBox.Text.ToUpper()));
        counter.Parameters.Add(new System.Data.SqlClient.SqlParameter("@state", stateBox.SelectedValue));
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

        if(MaxPriceBox.Text.Length > 0)
        {
            maxPrice = Convert.ToInt32(MaxPriceBox.Text);
        }
        counter.Parameters.Add(new System.Data.SqlClient.SqlParameter("@maxPrice", maxPrice));

        SqlDataReader reader = counter.ExecuteReader();

        while(reader.Read())
        {
            
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

            //property badge 2
            var badge2 = new HtmlGenericControl("img")
            {

            };

            insidediv.Controls.Add(badge2);
            if (reader.GetSqlString(7) == "T")
            {
                badge2.Attributes.Add("src", bathroomBadge);
            }
            badge2.Style.Add("max-width", "130px;");

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

            //property badge 4
            var badge4 = new HtmlGenericControl("img")
            {

            };
            
            insidediv.Controls.Add(badge4);
            if (reader.GetSqlString(9) == "T")
            {
                badge4.Attributes.Add("src", furnishedBadge);
            }
            badge4.Style.Add("max-width", "130px;");

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

            //property badge 6
            var badge6 = new HtmlGenericControl("img")
            {

            };

            insidediv.Controls.Add(badge6);
            if (reader.GetSqlString(12) == "T")
            {
                badge6.Attributes.Add("src", KitchenBadge);
            }
            badge6.Style.Add("max-width", "130px;");

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
            approved.Attributes.Add("src", "images/icons-07.png");
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

            //message badge
            var messageBadge = new HtmlGenericControl("img")
            {

            };

            rightCol.Controls.Add(messageBadge);
            messageBadge.Attributes.Add("src", "images/message-badge.png");
            messageBadge.Style.Add("max-width", "100px;");
            messageBadge.Style.Add("margin-right", "1rem;");

            //favorite badge
            var favoriteBadge = new HtmlGenericControl("img")
            {

            };

            rightCol.Controls.Add(favoriteBadge);
            favoriteBadge.Attributes.Add("src", "images/favorite-badge.png");
            favoriteBadge.Style.Add("max-width", "90px;");
            favoriteBadge.Style.Add("margin-right", "1rem;");

            //view profile badge
            var viewProfileBadge = new HtmlGenericControl("img")
            {

            };

            rightCol.Controls.Add(viewProfileBadge);
            viewProfileBadge.Attributes.Add("src", "images/view-profile-badge.png");
            viewProfileBadge.Style.Add("max-width", "90px;");
            viewProfileBadge.Style.Add("margin-right", "1rem;");

            //main property image
            String propImage = reader.GetString(14);
            Image newImg = new Image()
            {
                ImageUrl = propImage,

            };

            rightCol.Controls.Add(newImg);
            newImg.Style.Add("max-height", "300px;");
            newImg.Style.Add("margin-top", "1rem;");

            count++;
        }
        sc.Close();
        countLabel.Text = "Your search returned " + count + " result(s) for '" + CitySearchBox.Text + ", " + stateBox.SelectedValue.ToString() + "'";
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
}