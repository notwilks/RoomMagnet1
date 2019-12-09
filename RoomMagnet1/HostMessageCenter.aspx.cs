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

public partial class HostMessageCenter : System.Web.UI.Page
{
    SqlConnection sc = new SqlConnection(WebConfigurationManager.ConnectionStrings["RoomMagnetAWS"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["userType"]) == "" || Convert.ToString(Session["userEmail"]) == "")
        {
            Response.Redirect("HomePage.aspx");
        }
        else
        {

        }

        // Retrieve HostID to be used in queries
        SqlCommand selectHostID = new SqlCommand("SELECT hostID FROM Host WHERE email = @email", sc);
        selectHostID.Parameters.AddWithValue("@email", Convert.ToString(Session["userEmail"]));
        sc.Open();
        ViewState["hostID"] = Convert.ToInt32(selectHostID.ExecuteScalar());
        sc.Close();

        
        // Reply box and send button not visible until a conversation is selected
        txtBoxReply.Visible = false;
        btnSendRepy.Visible = false;

        
            DisplayConversationPreview();
        

    }  // END PAGE LOAD


    

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

    protected void ViewConversation_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        ViewState["tenantID"] = Convert.ToString(btn.ID);
        DisplayConversation();

        

    }

    protected void Send_Click(object sender, EventArgs e)
    {

       
        SqlCommand sendMessage = new SqlCommand("INSERT INTO MessageCenter(hostID, tenantID, messageText, dateSent, sender) VALUES(@hostID2, @tenantID2, @msg2, @date2, @sender2, @lastUpdated2, @lastUpdatedBy2)", sc);
        sendMessage.Parameters.AddWithValue("@hostID2", Convert.ToString(ViewState["hostID"]));
        sendMessage.Parameters.AddWithValue("@tenantID2", Convert.ToString(ViewState["tenantID"]));
        sendMessage.Parameters.AddWithValue("@msg2", txtBoxReply.Text);
        sendMessage.Parameters.AddWithValue("@date2", DateTime.Now);
        sendMessage.Parameters.AddWithValue("@sender2", "H");
        sendMessage.Parameters.AddWithValue("@lastUpdated2", DateTime.Now);
        sendMessage.Parameters.AddWithValue("@lastUpdatedBy2", "Joe Muia");
        sc.Open();
        sendMessage.ExecuteNonQuery();
        sc.Close();

        DisplayConversation();
        DisplayConversationPreview();
        txtBoxReply.Text = "";
    }


    protected void ComposeNew_Click(object sender, EventArgs e)
    {
        AddToDropdown();
        ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup();", true);


    }
    protected void SendNewMessage_Click(object sender, EventArgs e)
    {
        SqlCommand sendMessage = new SqlCommand("INSERT INTO MessageCenter(hostID, tenantID, messageText, dateSent, sender) VALUES(@hostID3, @tenantID3, @msg3, @date3, @sender3, @lastUpdated3, @lastUpdatedBy3)", sc);
        sendMessage.Parameters.AddWithValue("@hostID3", Convert.ToString(ViewState["hostID"]));
        sendMessage.Parameters.AddWithValue("@tenantID3", Convert.ToString(DropDownList1.SelectedValue));
        sendMessage.Parameters.AddWithValue("@msg3", Convert.ToString(txtBoxMessage.Text));
        sendMessage.Parameters.AddWithValue("@date3", DateTime.Now);
        sendMessage.Parameters.AddWithValue("@sender3", "H");
        sendMessage.Parameters.AddWithValue("@lastUpdated3", DateTime.Now);
        sendMessage.Parameters.AddWithValue("@lastUpdatedBy3", "Joe Muia");
        sc.Open();
        sendMessage.ExecuteNonQuery();
        sc.Close();
        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Pop", "$('#composeMessageModal').modal('hide');", true);
        Response.Redirect("HostMessageCenter.aspx");

    }
    protected void AddToDropdown()
    {
        // Retrieve contacts (Tenants that have favorited this host's property) 
        SqlCommand selectContacts = new SqlCommand("SELECT concat(t.firstName,' ', t.lastName), t.tenantID, h.hostID "
                                                    + "FROM Tenant t "
                                                    + "INNER JOIN FavoriteProperty f ON f.tenantID = t.tenantID "
                                                    + "INNER JOIN Accommodation a ON f.accommodationID = a.accommodationID "
                                                    + "INNER JOIN Host h ON a.hostID = h.hostID "
                                                    + "WHERE h.hostID = @hID", sc);
        selectContacts.Parameters.AddWithValue("@hID", Convert.ToString(ViewState["hostID"]));
        sc.Open();
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
        
    }

    protected void DisplayConversationPreview()
    {
        // Get Message History grouped by contact
        SqlCommand selectMessages = new SqlCommand("SELECT m.tenantID, m.hostID, m.messageText, m.dateSent, concat(t.firstName, ' ', t.lastName), concat(h.firstName, ' ', h.lastName), m.sender FROM Host h "
                                                    + "INNER JOIN MessageCenter m on h.hostID = m.hostID "
                                                    + "INNER JOIN tenant t on m.tenantID = t.tenantID "
                                                    + "WHERE m.dateSent in (select max(dateSent) from MessageCenter group by tenantID) and m.hostID = @hID "
                                                    + "group by m.dateSent, m.tenantID, m.messageText, t.firstName, t.lastName, h.firstName, h.lastName, m.hostID, m.sender "
                                                    + "order by m.dateSent desc", sc);
        selectMessages.Parameters.AddWithValue("@hID", Convert.ToString(ViewState["hostID"]));
        sc.Open();
        SqlDataReader reader = selectMessages.ExecuteReader();



        while (reader.Read())
        {


            // Populate Left column
            // Sender 
            String senderType = reader.GetString(6);
            String tenantName = reader.GetString(4);

            var leftSenderHeader = new HtmlGenericControl("h5")
            {
                InnerText = tenantName
            };
            leftSenderHeader.Attributes.Add("style", "font-size: 17px");
            leftSenderHeader.Attributes.Add("runat", "server");
            leftDiv.Controls.Add(leftSenderHeader);

            // View conversation button
            Button viewConvo = new Button();
            viewConvo.ID = Convert.ToString(reader.GetInt32(0));
            viewConvo.Text = "View";
            viewConvo.Attributes.Add("type", "button");
            viewConvo.Attributes.Add("class", "btn btn-sm float-right");
            viewConvo.Attributes.Add("runat", "server");
            viewConvo.Attributes.Add("CausesValidation", "false");
            //view.Attributes.Add("data-toggle", "modal");
            //view.Attributes.Add("data-target", "#exampleModalCenter");
            viewConvo.Click += new EventHandler(ViewConversation_Click);
            leftSenderHeader.Controls.Add(viewConvo);
           
            // Date 
            String date = reader.GetDateTime(3).ToShortDateString();
            var leftDateSent = new HtmlGenericControl("p")
            {
                InnerText = date
            };
            leftDateSent.Attributes.Add("style", "font-size: 13px");
            leftDiv.Controls.Add(leftDateSent);

            // Message
            String message = reader.GetString(2);
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
        sc.Close();
    }


    protected void DisplayConversation()
    {
        sc.Close();
        //Get message history with particular tenant
        SqlCommand selectConversation = new SqlCommand("SELECT m.tenantID, m.dateSent, m.messageText, m.sender, t.firstName FROM MessageCenter m "
                                                        + "INNER JOIN tenant t on m.tenantID = t.tenantID "
                                                        + "where m.hostID = @hID1 and m.tenantID = @tID1 "
                                                        + "order by dateSent asc", sc);
        selectConversation.Parameters.AddWithValue("@hID1", Convert.ToString(ViewState["hostID"]));
        selectConversation.Parameters.AddWithValue("@tID1", Convert.ToString(ViewState["tenantID"]));
        sc.Open();

        SqlDataReader reader = selectConversation.ExecuteReader();

        while (reader.Read())
        {
            // Create divs to display messages
            // Row div 
            var div1 = new HtmlGenericControl("div")
            {

            };
            conversationDiv.Controls.Add(div1);
            div1.Style.Add("margin-top", ".5rem;");
            //div1.Style.Add("border-bottom", "solid;");
            //div1.Style.Add("border-bottom-width", "1px;");
            div1.Style.Add("border-top", "solid;");
            div1.Style.Add("border-top-width", "1px;");
            div1.Attributes.Add("class", "col-md-12");

            // Sender name
            String name = "";

            var senderName = new HtmlGenericControl("h5")
            {

            };
            senderName.Style.Add("margin-top", "1rem");
            if (reader.GetString(3) == "T")
            {
                name = reader.GetString(4);
            }
            else
            {
                name = "You";
                senderName.Style.Add("text-align", "right");
            }
            senderName.InnerText = name;
            div1.Controls.Add(senderName);

            // Message
            String message = reader.GetString(2);

            var messageText = new HtmlGenericControl("p")
            {
                InnerText = message
            };
            // Align text right for sent messages
            if (reader.GetString(3) == "H")
            {
                messageText.Style.Add("Text-Align", "right");
            }
            div1.Controls.Add(messageText);
        }
        sc.Close();
        // Make reply box and send message button visible 
        txtBoxReply.Visible = true;
        btnSendRepy.Visible = true;
    }
    
}