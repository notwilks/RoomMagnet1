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
        
        sc.Open();

        SqlCommand select = new SqlCommand();
        select.Connection = sc;
        SqlCommand findListing = new SqlCommand();
        findListing.Connection = sc;

        select.CommandText = "Select accommodationID from Accommodation where hostID in (Select hostID from Host where email = @hostEmail1)";
        select.Parameters.Add(new SqlParameter("@hostEmail1", Convert.ToString(Session["userEmail"])));

        int accomID = Convert.ToInt32(select.ExecuteScalar());

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
        
        //HostPrimaryImage.ImageUrl = Convert.ToString(select.ExecuteScalar());

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

        //Header.Text = "Host Dashboard.";
        //select.CommandText = "Select (firstName + ' ' + lastName) from host where email = @email1";
        //select.Parameters.Add(new System.Data.SqlClient.SqlParameter("@email1", Session["userEmail"]));
        //String hostName = Convert.ToString(select.ExecuteScalar());
        //ProfileHeader.Text = "Welcome " + hostName;

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

        // MESSAGE CENTER 

        // Retrieve a Host's existing messages from DB
        SqlCommand selectMessages = new SqlCommand("SELECT concat(t.firstName, ' ', t.lastName), messageText, t.tenantID, m.messageID, m.sender FROM MessageCenter m "
                                                    + "INNER JOIN Tenant t ON t.tenantID = m.tenantID "
                                                    + "WHERE m.hostID = @hID and sender = 'T'", sc);
        selectMessages.Parameters.AddWithValue("@hID", Convert.ToString(ViewState["hostID"]));
        sc.Open();
        reader = selectMessages.ExecuteReader();




        using (reader)
        {
            while (reader.Read())
            {
                // Create divs to display messages
                // Row div 
                var div1 = new HtmlGenericControl("div")
                {

                };
                messagesDashDiv.Controls.Add(div1);
                div1.Style.Add("margin-top", "1rem;");
                div1.Style.Add("border-bottom", "solid;");
                div1.Style.Add("border-bottom-width", "1px;");
                div1.Attributes.Add("class", "col-md-12");
                /*
               // New Message Header
               var newMessageHeader = new HtmlGenericControl("div")
               {

               };
               div1.Controls.Add(newMessageHeader);


               // Message div
               var messageDiv = new HtmlGenericControl("div")
               {

               };
               div1.Controls.Add(messageDiv);


               // Button div
               var btnMoreMessages = new HtmlGenericControl("div")
               {

               };
               div1.Controls.Add(btnDiv);
               btnDiv.Attributes.Add("class", "col-md-2");


               messageDiv.Attributes.Add("class", "col-md-7");
               */


                // Populate message divs
                // Sender name
                String name = reader.GetString(0);
                var senderName = new HtmlGenericControl("h3")
                {
                    InnerText = "New Message | " + name
                };
                div1.Controls.Add(senderName);

                // View message button
                Button view = new Button();
                view.ID = Convert.ToString(reader.GetInt32(3));
                view.Text = "View Chat";
                view.Attributes.Add("type", "button");
                view.Attributes.Add("class", "btn float-right");
                view.Attributes.Add("runat", "server");
                //view.Attributes.Add("data-toggle", "modal");
                //view.Attributes.Add("data-target", "#exampleModalCenter");
                view.Click += new EventHandler(ViewMessageHistory_Click);
                senderName.Controls.Add(view);

                // Message
                String message = reader.GetString(1);
                if (message.Length >= 140)
                {
                    message = message.Substring(0, 140) + "...";
                } 
                var messageText = new HtmlGenericControl("p")
                {
                    InnerText = message
                };
                div1.Controls.Add(messageText);

                
            }
            reader.Close();

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

    protected void ViewMessageHistory_Click(object sender, EventArgs e)
    {

        Button btn = (Button)sender;
        String mID = Convert.ToString(btn.ID);
        BuildMessageCenter(mID);

        ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup();", true);
    }



    protected void BuildMessageCenter(String mID)
    {

        // Retrieve contacts (Tenants that have favorited this host's property) 
        SqlCommand selectContacts = new SqlCommand("SELECT concat(t.firstName,' ', t.lastName), t.tenantID, h.hostID "
                                                    + "FROM Tenant t "
                                                    + "INNER JOIN FavoriteProperty f ON f.tenantID = t.tenantID "
                                                    + "INNER JOIN Accommodation a ON f.accommodationID = a.accommodationID "
                                                    + "INNER JOIN Host h ON a.hostID = h.hostID "
                                                    + "WHERE h.hostID = @hID", sc);
        selectContacts.Parameters.AddWithValue("@hID", Convert.ToString(ViewState["hostID"]));

        SqlDataReader reader = selectContacts.ExecuteReader();






        // Add contacts to dropdown

        while (reader.Read())
        {
            if (CheckExistingContacts(Convert.ToString(reader.GetInt32(1))) == false) {
                ListItem contact = new ListItem(reader.GetString(0), Convert.ToString(reader.GetInt32(1)));
                DropDownList1.Items.Add(contact);
            }



        }
        reader.Close();
        // Get tenantID 
        SqlCommand selectTenant = new SqlCommand("SELECT tenantID FROM messageCenter WHERE messageID = @mID", sc);
        selectTenant.Parameters.AddWithValue("@mID", mID);
        String tID = Convert.ToString(selectTenant.ExecuteScalar());
        // Get Message History from particular sender
        SqlCommand selectMessages = new SqlCommand("SELECT concat(t.firstName, ' ', t.lastName), m.messageText, t.tenantID, m.dateSent, m.messageID, concat(h.firstName, ' ', h.lastName), m.sender FROM Host h "
                                                            + "INNER JOIN MessageCenter m ON h.hostID = m.hostID "
                                                            + "INNER JOIN Tenant t ON t.tenantID = m.tenantID "
                                                    + "WHERE m.hostID = @hID and t.tenantID = @tID "
                                                    + "ORDER BY dateSent DESC", sc);
        selectMessages.Parameters.AddWithValue("@hID", Convert.ToString(ViewState["hostID"]));
        selectMessages.Parameters.AddWithValue("@tID", tID);

        reader = selectMessages.ExecuteReader();



        while (reader.Read())
        {


            // Populate Left column
            // Sender 
            String senderType = reader.GetString(6);
            String senderName;
            if (senderType == "T")
            {
                senderName = reader.GetString(0);
            }
            else
            {
                senderName = reader.GetString(5);
            }
            var leftSenderHeader = new HtmlGenericControl("h5")
            {
                InnerText = senderName
            };
            leftSenderHeader.Attributes.Add("style", "font-size: 17px");
            leftDiv.Controls.Add(leftSenderHeader);

            // View message button
            Button viewMessage = new Button();
            viewMessage.ID = Convert.ToString(reader.GetInt32(4));
            viewMessage.Text = "View";
            viewMessage.Attributes.Add("type", "button");
            viewMessage.Attributes.Add("class", "btn btn-sm float-right");
            viewMessage.Attributes.Add("runat", "server");
            viewMessage.Attributes.Add("OnClientClick", "ViewFullMessage_Click");
            //view.Attributes.Add("data-toggle", "modal");
            //view.Attributes.Add("data-target", "#exampleModalCenter");
            //viewMessage.Click += new EventHandler(ViewFullMessage_Click);
            leftSenderHeader.Controls.Add(viewMessage);

            // Date 
            String date = reader.GetDateTime(3).ToShortDateString();
            var leftDateSent = new HtmlGenericControl("p")
            {
                InnerText = date
            };
            leftDateSent.Attributes.Add("style", "font-size: 13px");
            leftDiv.Controls.Add(leftDateSent);

            // Message
            String message = reader.GetString(1);
            if (message.Length >= 20)
            {
                message = message.Substring(0, 20) + "...";
            }
            var leftMessageText = new HtmlGenericControl("p")
            {
                InnerText = message
            };
            leftDiv.Controls.Add(leftMessageText);
        }
        reader.Close();

        // Populate Right column
        SqlCommand selectClickedMessage = new SqlCommand("SELECT concat(t.firstName, ' ', t.lastName), m.messageText, t.tenantID, m.dateSent, m.messageID FROM MessageCenter m "
                                                    + "INNER JOIN Tenant t ON t.tenantID = m.tenantID "
                                                    + "WHERE m.hostID = @hID and t.tenantID = @tID and m.messageID = @mID "
                                                    + "ORDER BY dateSent DESC", sc);
        selectClickedMessage.Parameters.AddWithValue("@hID", Convert.ToString(ViewState["hostID"]));
        selectClickedMessage.Parameters.AddWithValue("@tID", tID);
        selectClickedMessage.Parameters.AddWithValue("@mID", mID);
        reader = selectClickedMessage.ExecuteReader();

        while (reader.Read())
        {
            lblSender.Text = reader.GetString(0);
            lblDate.Text = reader.GetDateTime(3).ToShortDateString();
            lblMessageText.Text = reader.GetString(1);
            Button send = new Button();
            send.ID = Convert.ToString(reader.GetInt32(4));
            send.Text = "Send";
            send.Attributes.Add("type", "button");
            send.Attributes.Add("class", "btn float-right");
            send.Attributes.Add("runat", "server");
            //view.Attributes.Add("data-toggle", "modal");
            //view.Attributes.Add("data-target", "#exampleModalCenter");
            send.Click += new EventHandler(Send_Click);
            rightDiv.Controls.Add(send);
        }
        reader.Close();
         


    }


    protected Boolean CheckExistingContacts(String tenantID)
    {
        Boolean contactExists = false;

        foreach (ListItem li in DropDownList1.Items)
        {
            if (li.Value == tenantID)
            {
                contactExists = true;
            }
        }
        return contactExists;
    }

    protected void ViewFullMessage_Click(object sender, EventArgs e)
    {
        
        Button btn1 = (Button)sender;
        String mID = Convert.ToString(btn1.ID);

        SqlCommand selectFullMessage = new SqlCommand("SELECT concat(t.firstName, ' ', t.lastName), m.messageText, t.tenantID, m.dateSent, m.messageID, concat(h.firstName,' ', h.lastName), m.sender FROM Host h "
                                                            + "INNER JOIN MessageCenter m ON h.hostID = m.hostID "
                                                            + "INNER JOIN Tenant t ON t.tenantID = m.tenantID "
                                                            + "WHERE m.messageID = @mID", sc);
        selectFullMessage.Parameters.AddWithValue("@mID", mID);
        SqlDataReader reader = selectFullMessage.ExecuteReader();
        while (reader.Read())
        {
            String senderType = reader.GetString(6);;
            if (senderType == "T")
            {
                lblSender.Visible = true;
                lblSender.Text = reader.GetString(0);
                lblDate.Visible = true;
                lblDate.Text = reader.GetDateTime(3).ToShortDateString();
                lblMessageText.Visible = true;
                lblMessageText.Text = reader.GetString(1);
                txtBoxReply.Visible = false;
                btnSendRepy.Visible = false;
            }
            if(senderType == "H")
            {
                lblSender.Visible = true;
                lblSender.Text = reader.GetString(5);
                lblDate.Visible = true;
                lblDate.Text = reader.GetDateTime(3).ToShortDateString();
                lblMessageText.Visible = true;
                lblMessageText.Text = reader.GetString(1);
                txtBoxReply.Visible = true;
                btnSendRepy.Visible = true;
            }




        }

        reader.Close();
        ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup();", true);

    }


    protected void Send_Click(object sender, EventArgs e)
    {
        Button sendBtn = (Button)sender;
        String tID = Convert.ToString(sendBtn.ID);
        SqlCommand sendMessage = new SqlCommand("INSERT INTO MessageCenter(hostID, tenantID, messageText, dateSent) VALUES(@hostID, @tenantID, @msg, @date", sc);
        sendMessage.Parameters.AddWithValue("@hostID", Convert.ToString(ViewState["hostID"]));
        sendMessage.Parameters.AddWithValue("@tenantID", tID);
    }


}