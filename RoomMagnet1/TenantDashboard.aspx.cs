﻿using System;
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

            // Retrieve tenant ID 

            SqlCommand selectTenantID = new SqlCommand("Select tenantID from Tenant where email = @tenantEmail", sc);
            selectTenantID.Parameters.Add(new SqlParameter("@tenantEmail", Convert.ToString(Session["userEmail"])));
            sc.Open();
            ViewState["tenantID"] = Convert.ToInt32(selectTenantID.ExecuteScalar());
            sc.Close();


            // Load database data into local variables to be displayed on dashboard
            sc.Open();
            SqlCommand selectTenantInfo = new SqlCommand("SELECT concat(firstName, ' ', lastName), email," +
                "phoneNumber, birthDate, isnull(biography, 'bio goes here'), isnull(cleared, 'F') FROM [Tenant] where email = @email", sc);
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
                age = CalculateAge(reader.GetDateTime(3)).ToString();
                bio = reader.GetString(4);

                String cleared = reader.GetString(5);
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
            }
            reader.Close();
            sc.Close();

            SqlCommand selectBadge = new SqlCommand("SELECT undergraduate, graduate FROM TenantBadge where tenantID = (select tenantID from Tenant where email = @email2)", sc);
            selectBadge.Parameters.AddWithValue("@email2", Session["userEmail"]);
            sc.Open();
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

            SqlCommand selectImages = new SqlCommand();
            selectImages.Connection = sc;

            selectImages.CommandText = "Select tenantID from Tenant where email = @tenEmail";
            selectImages.Parameters.AddWithValue("@tenEmail", Session["userEmail"]);

            int tenantID = Convert.ToInt32(selectImages.ExecuteScalar());

            selectImages.CommandText = "Select ISNULL(mainImage, ''), ISNULL(image2, ''), ISNULL(image3, '') FROM TenantImages where tenantID = " + tenantID;
            reader = selectImages.ExecuteReader();

            while (reader.Read())
            {
                TenantPrimaryImage.ImageUrl = reader.GetString(0);
                TenantImage2.ImageUrl = reader.GetString(1);
                TenantImage3.ImageUrl = reader.GetString(2);
            }
            reader.Close();


            //Header.Text = "Host Dashboard.";
            //select.CommandText = "Select (firstName + ' ' + lastName) from host where email = @email1";
            //select.Parameters.Add(new System.Data.SqlClient.SqlParameter("@email1", Session["userEmail"]));
            //String hostName = Convert.ToString(select.ExecuteScalar());
            //ProfileHeader.Text = "Welcome " + hostName;

            SqlCommand select = new SqlCommand();
            select.Connection = sc;

            select.CommandText = "select a.accommodationID, a.description, h.firstName, isnull(h.cleared, 'F') from FavoriteProperty fp " +
                "inner join Accommodation a on a.accommodationID = fp.accommodationID " +
                "inner join Host h on h.hostID = a.hostID where fp.tenantID = @tenID";
            select.Parameters.AddWithValue("@tenID", Convert.ToString(ViewState["tenantID"]));

            reader = select.ExecuteReader();

            while (reader.Read())
            {
                //Generating the initial div
                var div1 = new HtmlGenericControl("div")
                {

                };
                div1.Attributes.Add("class", "col-md-6");
                //div1.Style.Add("margin-top", "1rem;");
                div1.Style.Add("border-top", "solid");
                div1.Style.Add("border-top-width", "1px");
                div1.Style.Add("border-bottom", "solid");
                div1.Style.Add("border-bottom-width", "1px");
                favorites.Controls.Add(div1);

                var hostName = new HtmlGenericControl("h4")
                {

                };
                hostName.InnerText = reader.GetString(2) + "'s Property";
                div1.Controls.Add(hostName);

                var propDesc = new HtmlGenericControl("h6")
                {

                };
                propDesc.InnerText = reader.GetString(1);
                div1.Controls.Add(propDesc);

                var div2 = new HtmlGenericControl("div")
                {

                };
                favorites.Controls.Add(div2);
                div2.Attributes.Add("class", "col-md-6");
                div2.Style.Add("border-top", "solid");
                div2.Style.Add("border-top-width", "1px");
                div2.Style.Add("border-bottom", "solid");
                div2.Style.Add("border-bottom-width", "1px");
                //div2.Style.Add("margin-top", "1rem;");

                Image status = new Image();
                String cleared = reader.GetString(3);
                if (cleared == "T")
                {
                    status.ImageUrl = "images/icons-07.png";
                }
                else
                {
                    status.ImageUrl = "images/icons-08.png";
                }
                status.Style.Add("max-width", "50px");
                div2.Controls.Add(status);

                Button viewProf = new Button();
                viewProf.ID = Convert.ToString(reader.GetInt32(0));
                viewProf.Text = "View Property";
                viewProf.Attributes.Add("class", "btn");
                viewProf.Style.Add("margin-left", "1rem");
                viewProf.Click += new EventHandler(ViewProfile_Click);
                div2.Controls.Add(viewProf);


            }
            sc.Close();
        reader.Close();

        //Rental Agreement
        SqlCommand rental = new SqlCommand();
        rental.Connection = sc;

        sc.Open();
        rental.CommandText = "Select ra.hostID, h.firstName, a.description, a.accommodationID from RentalAgreement ra " +
            "inner join host h on ra.hostID = h.hostID " +
            "inner join Accommodation a on ra.hostID = a.hostID where tenantID = " + tenantID;

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
            viewPropAgreement.Text = "View Property";
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

        // Retrieve a Tenant's existing messages from DB
        SqlCommand selectMessages = new SqlCommand("SELECT concat(h.firstName, ' ', h.lastName), m.messageText, h.hostID, m.messageID, m.sender FROM MessageCenter m "
                                                        + "INNER JOIN host h ON h.hostID = m.hostID "
                                                        + "WHERE m.tenantID = @tID and sender = @senderType", sc);
            selectMessages.Parameters.AddWithValue("@tID", Convert.ToString(ViewState["tenantID"]));
            selectMessages.Parameters.AddWithValue("@senderType", "H");
            sc.Open();
            reader = selectMessages.ExecuteReader();


            using (reader)
            {
                while (reader.Read())
                {
                    // Create div to display messages

                    var div2 = new HtmlGenericControl("div")
                    {

                    };
                    messageCenterDiv.Controls.Add(div2);
                    div2.Style.Add("margin-top", "1rem;");
                    //div1.Style.Add("border-bottom", "solid;");
                    //div1.Style.Add("border-bottom-width", "1px;");
                    div2.Style.Add("border-top", "solid;");
                    div2.Style.Add("border-top-width", "1px;");
                    div2.Attributes.Add("class", "col-md-12");

                    // Populate message divs
                    // Sender name
                    String sName = reader.GetString(0);
                    var senderName = new HtmlGenericControl("h3")
                    {
                        InnerText = "New Message | " + sName
                    };
                    senderName.Style.Add("margin-top", "1rem");
                    div2.Controls.Add(senderName);

                    // View message button
                    Button view = new Button();
                    view.ID = Convert.ToString(reader.GetInt32(3));
                    view.Text = "View Chat";
                    view.Attributes.Add("type", "button");
                    view.Attributes.Add("class", "btn float-right");
                    view.Attributes.Add("runat", "server");
                    view.Style.Add("margin-top", "1rem");
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
                    div2.Controls.Add(messageText);









                }
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

    protected void ViewProfile_Click(object sender, EventArgs e)
    {
        Button b = sender as Button;
        String ID = b.ID;
        Session["propertyID"] = ID;
        Response.Redirect("PropertyInfo.aspx");
    }

    protected void Compose_Click(object sender, EventArgs e)
    {
        try
        {

            // Retrieve contacts (hosts of favorited properties) 
            SqlCommand selectContacts = new SqlCommand("SELECT concat(h.firstName,' ', h.lastName), t.tenantID, h.hostID "
                                                        + "FROM Tenant t "
                                                        + "INNER JOIN FavoriteProperty f ON f.tenantID = t.tenantID "
                                                        + "INNER JOIN Accommodation a ON f.accommodationID = a.accommodationID "
                                                        + "INNER JOIN Host h ON a.hostID = h.hostID "
                                                        + "WHERE t.tenantID = @tID", sc);
            selectContacts.Parameters.AddWithValue("@tID", Convert.ToString(ViewState["tenantID"]));

            SqlDataReader reader = selectContacts.ExecuteReader();






            // Add contacts to dropdowns

            while (reader.Read())
            {
                if (CheckExistingContacts2(Convert.ToString(reader.GetInt32(2))) == false)
                {
                    ListItem contact = new ListItem(reader.GetString(0), Convert.ToString(reader.GetInt32(2)));
                    DropDownList2.Items.Add(contact);
                }



            }
            reader.Close();
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup2();", true);
        }
        catch
        {
            NoFavs.Text = "You cannot send a message until you favorite a property.";
        }
    }
    protected Boolean CheckExistingContacts2(String tenantID)
    {
        Boolean contactExists = false;
        foreach (ListItem li in DropDownList2.Items)
        {
            if (li.Value == tenantID)
            {
                contactExists = true;
            }
        }
        return contactExists;
    }

    protected void SendNewMessage_Click(object sender, EventArgs e)
    {
        // Get TenantID based on selected contact
        String hID = Convert.ToString(DropDownList2.SelectedValue);

        // Insert message into message center 
        SqlCommand sendMessage = new SqlCommand("INSERT INTO MessageCenter(tenantID, hostID, messageText, dateSent, sender) VALUES(@tID3, @hID3, @msgText3, @date3, @sender3)", sc);
        sendMessage.Parameters.AddWithValue("@tID3", Convert.ToString(ViewState["tenantID"]));
        sendMessage.Parameters.AddWithValue("@hID3", hID);
        sendMessage.Parameters.AddWithValue("@msgText3", txtBoxMessage.Text.ToString());
        sendMessage.Parameters.AddWithValue("date3", DateTime.Now.ToString());
        sendMessage.Parameters.AddWithValue("@sender3", "T");

        sendMessage.ExecuteNonQuery();
        sc.Close();
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

        // Retrieve contacts (Hosts of favorited properties) 
        SqlCommand selectContacts = new SqlCommand("SELECT concat(h.firstName,' ', h.lastName), t.tenantID, h.hostID "
                                                    + "FROM host h "
                                                    + "INNER JOIN Accommodation a ON h.hostID = a.hostID "
                                                    + "INNER JOIN FavoriteProperty f ON a.accommodationID = f.accommodationID "
                                                    + "INNER JOIN Tenant t ON f.tenantID = t.tenantID "
                                                    + "WHERE t.tenantID = @tenantID", sc);
        selectContacts.Parameters.AddWithValue("@tenantID", Convert.ToString(ViewState["tenantID"]));

        SqlDataReader reader = selectContacts.ExecuteReader();






        // Add contacts to dropdowns

        while (reader.Read())
        {
            if (CheckExistingContacts(Convert.ToString(reader.GetInt32(1))) == false)
            {
                ListItem contact = new ListItem(reader.GetString(0), Convert.ToString(reader.GetInt32(1)));
                DropDownList1.Items.Add(contact);
            }



        }
        reader.Close();
        // Get hostID 
        SqlCommand selectTenant = new SqlCommand("SELECT hostID FROM messageCenter WHERE messageID = @mID", sc);
        selectTenant.Parameters.AddWithValue("@mID", mID);
        String hID = Convert.ToString(selectTenant.ExecuteScalar());
        // Get Message History from particular sender
        SqlCommand selectMessages = new SqlCommand("SELECT concat(h.firstName, ' ', h.lastName), m.messageText, t.tenantID, m.dateSent, m.messageID, concat(t.firstName, ' ', t.lastName), m.sender FROM Host h "
                                                            + "INNER JOIN MessageCenter m ON h.hostID = m.hostID "
                                                            + "INNER JOIN Tenant t ON t.tenantID = m.tenantID "
                                                    + "WHERE m.hostID = @hID and t.tenantID = @tID "
                                                    + "ORDER BY dateSent DESC", sc);
        selectMessages.Parameters.AddWithValue("@hID", hID);
        selectMessages.Parameters.AddWithValue("@tID", Convert.ToString(ViewState["tenantID"]));

        reader = selectMessages.ExecuteReader();



        while (reader.Read())
        {


            // Populate Left column
            // Sender 
            String senderType = reader.GetString(6);
            String senderName;
            if (senderType == "H")
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
            viewMessage.Click += new EventHandler(ViewFullMessage_Click);
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
        selectClickedMessage.Parameters.AddWithValue("@hID", hID);
        selectClickedMessage.Parameters.AddWithValue("@tID", ViewState["tenantID"]);
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
            send.Click += new EventHandler(Send_Click);
            send.Attributes.Add("class", "btn float-right");
            send.Attributes.Add("runat", "server");
            //view.Attributes.Add("data-toggle", "modal");
            //view.Attributes.Add("data-target", "#exampleModalCenter");
            send.Attributes.Add("UseSubmitBehavior", "false");
            //send.Attributes.Add("data-dismiss", "modal");
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
    protected void Send_Click(object sender, EventArgs e)
    {
        Button sendBtn = (Button)sender;
        String mID = Convert.ToString(sendBtn.ID);

        // Get TenantID based on messageID passed from send button
        SqlCommand selectTenant = new SqlCommand("SELECT hostID FROM MessgeCenter WHERE MessageID = @msgID", sc);
        selectTenant.Parameters.AddWithValue("@msgID", mID);

        String hID = Convert.ToString(sendBtn.ID);

        SqlCommand sendMessage = new SqlCommand("INSERT INTO MessageCenter(hostID, tenantID, messageText, dateSent, sender) VALUES(@hostID2, @tenantID2, @msg2, @date2, @sender2)", sc);
        sendMessage.Parameters.AddWithValue("@hostID2", hID);
        sendMessage.Parameters.AddWithValue("@tenantID2", Convert.ToString(ViewState["tenantID"]));
        sendMessage.Parameters.AddWithValue("@msg2", txtBoxReply.Text);
        sendMessage.Parameters.AddWithValue("@date2", DateTime.Now.ToLongDateString());
        sendMessage.Parameters.AddWithValue("@sender2", "T");
        sc.Open();
        sendMessage.ExecuteNonQuery();
        sc.Close();



    }

    protected void ViewFullMessage_Click(object sender, EventArgs e)
    {

        Button btn1 = (Button)sender;
        String mID = Convert.ToString(btn1.ID);
        btnSendRepy.ID = mID;
        SqlCommand selectFullMessage = new SqlCommand("SELECT concat(t.firstName, ' ', t.lastName), m.messageText, t.tenantID, m.dateSent, m.messageID, concat(h.firstName,' ', h.lastName), m.sender FROM Host h "
                                                            + "INNER JOIN MessageCenter m ON h.hostID = m.hostID "
                                                            + "INNER JOIN Tenant t ON t.tenantID = m.tenantID "
                                                            + "WHERE m.messageID = @mID", sc);
        selectFullMessage.Parameters.AddWithValue("@mID", mID);

        SqlDataReader reader = selectFullMessage.ExecuteReader();
        while (reader.Read())
        {
            String senderType = reader.GetString(6); ;
            if (senderType == "H")
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
            if (senderType == "T")
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

            btnSendRepy.ID = mID;


        }

        reader.Close();
        ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup();", true);

    }
    protected void DropDownList1_IndexChanged(object sender, EventArgs e)
    {
        

        UpdatePanel1.Update();
    }

    protected void ViewLeaseProp(object sender, EventArgs e)
    {
        Button b = sender as Button;
        String ID = b.ID.Substring(0, b.ID.Length - 1);
        Session["propertyID"] = ID;
        Response.Redirect("PropertyInfo.aspx");
    }


}