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
using System.Data;
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
        if (Convert.ToString(Session["userType"]) == "" || Convert.ToString(Session["userEmail"]) == "")
        {
            Response.Redirect("HomePage.aspx");
        }
        else
        {

        }

        if (Convert.ToString(Session["userEmail"]).Equals(""))
        {
            Response.Redirect("HomePage.aspx");
        }
        else
        {

            sc.Open();

            SqlCommand select = new SqlCommand();
            select.Connection = sc;
            SqlCommand findListing = new SqlCommand();
            findListing.Connection = sc;

            select.CommandText = "Select accommodationID from Accommodation where hostID in (Select hostID from Host where email = @hostEmail1)";
            select.Parameters.Add(new SqlParameter("@hostEmail1", Convert.ToString(Session["userEmail"])));

            int accomID = Convert.ToInt32(select.ExecuteScalar());

            select.CommandText = "Select cleared from Host where email = '" + Session["userEmail"] + "'";
            string cleared = Convert.ToString(select.ExecuteScalar());

            if (cleared == "T")
            {
                TenantBackgroundStatusImage.ImageUrl = "images/icons-07.png";
                TenantBackgroundStatusDescrip.Text = "You are a verified user! Your background check has been completed and you are cleared.";
                TenantBackgroundStatusWords.Text = "Completed";
            }
            else
            {
                TenantBackgroundStatusImage.ImageUrl = "images/icons-08.png";
                TenantBackgroundStatusDescrip.Text = "Your background check has either not yet been submitted or is currently under review.";
                TenantBackgroundStatusWords.Text = "Not Completed";
            }

            select.CommandText = "Select hostID from Host where email = @hostEmail2";
            select.Parameters.Add(new SqlParameter("@hostEmail2", Convert.ToString(Session["userEmail"])));

            ViewState["hostID"] = Convert.ToInt32(select.ExecuteScalar());

            select.CommandText = "Select ISNULL(mainImage, ''), ISNULL(image2, ''), ISNULL(image3, '') FROM AccommodationImages where accommodationID = " + accomID;
            SqlDataReader reader = select.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    HostPrimaryImage.ImageUrl = HttpUtility.HtmlEncode(reader.GetString(0));
                    HostImage2.ImageUrl = HttpUtility.HtmlEncode(reader.GetString(1));
                    HostImage3.ImageUrl = HttpUtility.HtmlEncode(reader.GetString(2));
                }
                reader.Close();
            }

            sc.Close();

            sc.Open();
            select.CommandText = "Select ISNULL(mainImage, ''), ISNULL(image2, ''), ISNULL(image3, '') FROM HostImages where hostID = " + Convert.ToString(ViewState["hostID"]);
            reader = select.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    Image1.ImageUrl = HttpUtility.HtmlEncode(reader.GetString(0));
                    Image2.ImageUrl = HttpUtility.HtmlEncode(reader.GetString(1));
                    Image3.ImageUrl = HttpUtility.HtmlEncode(reader.GetString(2));
                }
                reader.Close();
            }

            //select host bio
            select.CommandText = "Select biography from Host where hostID = " + Convert.ToString(ViewState["hostID"]);
            HostBio.Text = Convert.ToString(select.ExecuteScalar());

            //selecting name info
            select.CommandText = "Select (firstName + ' ' + lastName) from host where email = @email";
            select.Parameters.Add(new System.Data.SqlClient.SqlParameter("@email", Convert.ToString(Session["userEmail"])));
            String userName = HttpUtility.HtmlEncode(Convert.ToString(select.ExecuteScalar()));
            FirstNameLastNameHeader.Text = userName + "'s Dashboard";
            HostName.Text = userName.ToString();

            //selecting property name
            select.CommandText = "Select description from Accommodation where hostID in (select hostID from Host where email = @email1)";
            select.Parameters.Add(new System.Data.SqlClient.SqlParameter("@email1", Convert.ToString(Session["userEmail"])));
            PropertyName.Text = HttpUtility.HtmlEncode(Convert.ToString(select.ExecuteScalar()));

            //selecting description on the property
            select.CommandText = "Select extraInfo from Accommodation where hostID in (select hostID from Host where email = @email2)";
            select.Parameters.Add(new System.Data.SqlClient.SqlParameter("@email2", Convert.ToString(Session["userEmail"])));
            PropertyInfo.Text = HttpUtility.HtmlEncode(Convert.ToString(select.ExecuteScalar()));


            select.CommandText = "Select bathroom, entrance, storage, pets, furnished, smoker, wifi, parking, kitchen, laundry, cable, allowPets from AccommodationAmmenity WHERE accommodationID in (select accommodationID from Accommodation where hostID in " +
            "(select hostID from Host where email = @email3))";

            select.Parameters.Add(new SqlParameter("@email3", Convert.ToString(Session["userEmail"])));
            reader = select.ExecuteReader();
            using (reader)
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
            findListing.Parameters.Add(new SqlParameter("@email", Convert.ToString(Session["userEmail"])));
            listing = HttpUtility.HtmlEncode(Convert.ToString(findListing.ExecuteScalar()));

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
                EditPropertyButton.Visible = false;
            }

            sc.Close();

            //Rental Agreement
            SqlCommand rental = new SqlCommand();
            rental.Connection = sc;

            sc.Open();

            rental.CommandText = "select hostID from Host where email = '" + Session["userEmail"] + "';";
            int hostID = Convert.ToInt32(rental.ExecuteScalar());

            rental.CommandText = "Select t.tenantID, t.FirstName, t.biography, a.accommodationID from RentalAgreement ra " +
                "inner join tenant t on ra.tenantID = t.tenantID " +
                "inner join host h on ra.hostID = h.hostID " +
                "inner join accommodation a on a.hostID = h.hostID " +
                "where ra.hostID = " + hostID + " and a.hostID = " + hostID;

            SqlDataReader readerRental = rental.ExecuteReader();
            while (readerRental.Read())
            {
                var divRental = new HtmlGenericControl("div")
                {

                };
                divRental.Style.Add("border-top", "solid");
                divRental.Style.Add("border-top-width", "1px;");
                divRental.Style.Add("border-bottom", "solid");
                divRental.Style.Add("border-bottom-width", "1px;");
                rentalAgreementArea.Controls.Add(divRental);

                var hostNameAgreement = new HtmlGenericControl("h3")
                {

                };
                hostNameAgreement.InnerText = Convert.ToString(readerRental.GetString(1));
                divRental.Controls.Add(hostNameAgreement);


                var propDescAgreement = new HtmlGenericControl("p")
                {

                };
                propDescAgreement.InnerText = readerRental.GetString(2);
                divRental.Controls.Add(propDescAgreement);

                Button viewPropAgreement = new Button();
                viewPropAgreement.Text = "View Rental Agreement";
                viewPropAgreement.Style.Add("display", "inline-block");
                viewPropAgreement.Style.Add("margin-left", "3rem");
                viewPropAgreement.ID = Convert.ToString(readerRental.GetInt32(3)) + "R";
                viewPropAgreement.Click += new EventHandler(ViewLeaseProp);
                viewPropAgreement.Attributes.Add("class", "btn");
                propDescAgreement.Controls.Add(viewPropAgreement);
            }
            sc.Close();
            readerRental.Close();

            // MESSAGE CENTER 
            // Display notification for new messages 
            SqlCommand newMessage = new SqlCommand("SELECT messageID from MessageCenter WHERE hostID = @hID and sender = 'T'", sc);
            newMessage.Parameters.AddWithValue("hID", Convert.ToString(ViewState["hostID"]));
            sc.Open();
           
            
            var div1 = new HtmlGenericControl("div");
            {
            };
            messagesDashDiv.Controls.Add(div1);
            String notification = "";
            var messageNotification = new HtmlGenericControl("p")
            {
                
            };
            
            if (newMessage.ExecuteScalar() == DBNull.Value)
            {
                notification = "You do not have any new messages";
            }
            else
            {
                notification = "You have a new message! Visit Message Center to view it.";
            }
            messageNotification.InnerText = notification;
            div1.Controls.Add(messageNotification);
            sc.Close();


        }

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

        setList.CommandText = "UPDATE Accommodation SET Listed = @listed, dateListed = @dateListed WHERE HostID = @hostID";
        setList.Parameters.Add(new SqlParameter("@hostID", hID));
        setList.Parameters.Add(new SqlParameter("@listed", listing));
        setList.Parameters.Add(new SqlParameter("@dateListed", DateTime.Now));

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
            propertyModule.Controls.Add(newImg);
        }
    }

    protected void MessageCenter_Click(object sender, EventArgs e)
    {
        Response.Redirect("HostMessageCenter.aspx");
        
    }

    protected void ViewLeaseProp(object sender, EventArgs e)
    {
        Button b = sender as Button;
        String ID = b.ID.Substring(0, b.ID.Length - 1);
        Session["propertyID"] = ID;
        Response.Redirect("PropertyInfo.aspx");
    }

}