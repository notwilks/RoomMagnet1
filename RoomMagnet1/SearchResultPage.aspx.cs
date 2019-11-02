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

    }

    protected void SearchButton_Click(object sender, EventArgs e)
    {
        int count = 0;
        sc.Open();
        SqlCommand counter = new SqlCommand();
        counter.Connection = sc;

        counter.CommandText = "Select h.firstName, h.lastName, a.description, a.extraInfo from Host h inner join Accommodation a on a.hostID = h.HostID where UPPER(a.city) = @city and a.state = 'VA'";

        counter.Parameters.Add(new System.Data.SqlClient.SqlParameter("@city", CitySearchBox.Text.ToUpper()));
        counter.Parameters.Add(new System.Data.SqlClient.SqlParameter("@state", stateBox.SelectedValue));

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
            String hostFull = hostfirst + "" + hostLast;

            var hostName = new HtmlGenericControl("h2")
            {
                InnerText = hostFull
            };

            insidediv.Controls.Add(hostName);
            hostName.Style.Add("margin-top", "1rem;");


            String PropTempName = reader.GetString(2);

            var PropName = new HtmlGenericControl("h5")
            {
                InnerText = PropTempName
            };

            insidediv.Controls.Add(PropName);


            String PropTempBio = reader.GetString(3);

            var PropBio = new HtmlGenericControl("p")
            {
                InnerText = PropTempBio
            };

            insidediv.Controls.Add(PropBio);
            PropBio.Attributes.Add("class", "list-group-item-text");

            var badge1 = new HtmlGenericControl("img")
            {

            };

            insidediv.Controls.Add(badge1);
            badge1.Attributes.Add("src", "images/private-entrance.png");
            badge1.Style.Add("max-width", "130px;");

            var midCol = new HtmlGenericControl("div")
            {

            };

            div1.Controls.Add(midCol);
            midCol.Attributes.Add("class", "col-md-2");
            midCol.Style.Add("margin-top", ".5rem;");

            var approved = new HtmlGenericControl("img")
            {

            };

            midCol.Controls.Add(approved);
            approved.Attributes.Add("src", "images/icons-07.png");
            approved.Style.Add("max-width", "30px;");

            var rightCol = new HtmlGenericControl("div")
            {

            };

            div1.Controls.Add(rightCol);
            rightCol.Attributes.Add("class", "col-md-5");
            rightCol.Style.Add("margin-top", ".5rem;");
            rightCol.Style.Add("float", "right");
            rightCol.Style.Add("margin-bottom", "1rem;");

            var messageBadge = new HtmlGenericControl("img")
            {

            };

            rightCol.Controls.Add(messageBadge);
            messageBadge.Attributes.Add("src", "images/message-badge.png");
            messageBadge.Style.Add("max-width", "100px;");

            var favoriteBadge = new HtmlGenericControl("img")
            {

            };

            rightCol.Controls.Add(favoriteBadge);
            favoriteBadge.Attributes.Add("src", "images/favorite-badge.png");
            favoriteBadge.Style.Add("max-width", "90px;");

            var viewProfileBadge = new HtmlGenericControl("img")
            {

            };

            rightCol.Controls.Add(viewProfileBadge);
            viewProfileBadge.Attributes.Add("src", "images/favorite-badge.png");
            viewProfileBadge.Style.Add("max-width", "90px;");

            var mainImage = new HtmlGenericControl("img")
            {
                
            };

            rightCol.Controls.Add(mainImage);
            mainImage.Attributes.Add("src", "images/kitchen.jpeg");
            mainImage.Style.Add("max-height", "300px;");
            mainImage.Style.Add("margin-top", "1rem;");

            count++;
        }
        sc.Close();
        countLabel.Text = "Your search returned " + count + " results";
    }
}