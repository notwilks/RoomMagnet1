using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;
//using System.Windows.Forms;

public partial class MessageCenter : System.Web.UI.Page
{
    SqlConnection sc = new SqlConnection(WebConfigurationManager.ConnectionStrings["RoomMagnetAWS"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        String tenantID;


        
        


        // Functionality for Host Users 
        if (Session["userType"].ToString().Equals("H"))
        {
            sc.Open();
            // Retrieve hostID of current user to be inserted into MessageCenter
            SqlCommand selectHostID = new SqlCommand("Select hostID from Host where email = @hemail1", sc);
            selectHostID.Parameters.AddWithValue("@hemail1", Convert.ToString(Session["userEmail"]));
            ViewState["hostID"] = selectHostID.ExecuteScalar().ToString();

            // Retrieve contacts (Tenants that have favorited this host's property) 
            SqlCommand selectContacts = new SqlCommand("SELECT t.firstName, t.lastName, t.tenantID, h.hostID "
                                                        + "FROM Tenant t "
                                                        + "INNER JOIN FavoriteProperty f ON f.tenantID = t.tenantID "
                                                        + "INNER JOIN Accommodation a ON f.accommodationID = a.accommodationID "
                                                        + "INNER JOIN Host h ON a.hostID = h.hostID "
                                                        + "WHERE h.email = @hemail2", sc);
            selectContacts.Parameters.AddWithValue("@hemail2", Convert.ToString(Session["userEmail"]));

            SqlDataReader reader = selectContacts.ExecuteReader();

            while (reader.Read())
            {

                string contactName = reader.GetString(0).ToString() + " " + reader.GetString(1).ToString();
                int tenID = reader.GetInt32(2);
                AddToDropdown(contactName, tenID);
            }
            reader.Close();


            

            // Retrieve a Host's existing messages from DB
            SqlCommand selectMessages = new SqlCommand("SELECT concat(t.firstName, ' ', t.lastName), m.subjectLine, t.tenantID FROM MessageCenter m "
                                                        + "INNER JOIN Tenant t ON t.tenantID = m.tenantID " 
                                                        + "WHERE m.hostID = @hID", sc);
            selectMessages.Parameters.AddWithValue("@hID", Convert.ToString(ViewState["hostID"]));
            reader = selectMessages.ExecuteReader();
            while (reader.Read())
            {
                // Create divs to display messages
                // Row div 
                var div1 = new HtmlGenericControl("div")
                {

                };
                messages.Controls.Add(div1);
                div1.Style.Add("margin-top", "1rem;");
                div1.Style.Add("border-bottom", "solid;");
                div1.Style.Add("border-bottom-width", "1px;");
                div1.Attributes.Add("class", "row");

                // Name div
                var nameDiv = new HtmlGenericControl("div")
                {

                };
                div1.Controls.Add(nameDiv);
                nameDiv.Attributes.Add("class", "col-md-4");

                // Subject div
                var subjectDiv = new HtmlGenericControl("div")
                {

                };
                div1.Controls.Add(subjectDiv);
                subjectDiv.Attributes.Add("class", "col-md-4");

                // Button div
                var btnDiv = new HtmlGenericControl("div")
                {

                };
                div1.Controls.Add(btnDiv);
                btnDiv.Attributes.Add("class", "col-md-4");

                // Populate message divs
                // Sender name
                String name = reader.GetString(0);
                var senderName = new HtmlGenericControl("p")
                {
                    InnerText = name
                };
                nameDiv.Controls.Add(senderName);

                // Subject
                String subject = reader.GetString(1);
                var subjectLine = new HtmlGenericControl("p")
                {
                    InnerText = subject
                };
                subjectDiv.Controls.Add(subjectLine);

                // View message button
                Button view = new Button();
                view.ID = Convert.ToString(reader.GetInt32(2));
                view.Text = "View Message";
                view.Attributes.Add("class", "btn btn-success btn-sm");
                view.Style.Add("margin-bottom", "1rem;");
                view.Attributes.Add("runat", "server");
                view.Click += new EventHandler(ViewMessage_Click);
                btnDiv.Controls.Add(view);
            }
            reader.Close();
            sc.Close();
        }

        // Functionality for Tenant Users
        if (Session["userType"].ToString().Equals("T"))
        {
            // Retrieve tenantID of current user to be inserted into MessageCenter
            SqlCommand selectTenantID = new SqlCommand("SELECT tenantID FROM Tenant WHERE email = @temail1", sc);
            selectTenantID.Parameters.AddWithValue("@temail1", Convert.ToString(Session["userEmail"]));
            sc.Open();
            ViewState["tenantID"] = selectTenantID.ExecuteScalar().ToString();


            // Retrieve contacts (Tenants that have favorited this host's property) 
            SqlCommand selectContacts = new SqlCommand("SELECT h.firstName, h.lastName, h.hostID "
                                                        + "FROM Tenant t "
                                                        + "INNER JOIN FavoriteProperty f ON f.tenantID = t.tenantID "
                                                        + "INNER JOIN Accommodation a ON f.accommodationID = a.accommodationID "
                                                        + "INNER JOIN Host h ON a.hostID = h.hostID "
                                                        + "WHERE t.email = @temail2", sc);
            selectContacts.Parameters.AddWithValue("@temail2", Convert.ToString(Session["userEmail"]));

            SqlDataReader reader = selectContacts.ExecuteReader();

            while (reader.Read())
            {

                string contactName = reader.GetString(0).ToString() + " " + reader.GetString(1).ToString();
                int hostID = reader.GetInt32(2);
                AddToDropdown(contactName, hostID);
            }
            reader.Close();

            // Retrieve a Host's existing messages from DB
            SqlCommand selectMessages = new SqlCommand("SELECT concat(h.firstName, ' ', h.lastName), m.subjectLine, m.hostID FROM MessageCenter m "
                                                        + "INNER JOIN host h ON h.hostID = m.hostID "
                                                        + "WHERE tenantID = @tID", sc);
            selectMessages.Parameters.AddWithValue("@tID", Convert.ToString(ViewState["tenantID"]));
            reader = selectMessages.ExecuteReader();
            while (reader.Read())
            {
                // Create divs to display messages
                // Row div 
                var div1 = new HtmlGenericControl("div")
                {

                };
                messages.Controls.Add(div1);
                div1.Style.Add("margin-top", "1rem;");
                div1.Style.Add("border-bottom", "solid;");
                div1.Style.Add("border-bottom-width", "1px;");
                div1.Attributes.Add("class", "row");

                // Name div
                var nameDiv = new HtmlGenericControl("div")
                {

                };
                div1.Controls.Add(nameDiv);
                nameDiv.Attributes.Add("class", "col-md-4");

                // Subject div
                var subjectDiv = new HtmlGenericControl("div")
                {

                };
                div1.Controls.Add(subjectDiv);
                subjectDiv.Attributes.Add("class", "col-md-4");

                // Button div
                var btnDiv = new HtmlGenericControl("div")
                {

                };
                div1.Controls.Add(btnDiv);
                btnDiv.Attributes.Add("class", "col-md-4");

                // Populate message divs
                // Sender name
                String name = reader.GetString(0);
                var senderName = new HtmlGenericControl("p")
                {
                    InnerText = name
                };
                nameDiv.Controls.Add(senderName);

                // Subject
                String subject = reader.GetString(1);
                var subjectLine = new HtmlGenericControl("p")
                {
                    InnerText = subject
                };
                subjectDiv.Controls.Add(subjectLine);

                // View message button
                Button view = new Button();
                view.ID = Convert.ToString(reader.GetInt32(2));
                view.Text = "View Message";
                view.Attributes.Add("class", "btn btn-success btn-sm");
                view.Style.Add("margin-bottom", "1rem;");
                view.Attributes.Add("runat", "server");
                view.Click += new EventHandler(ViewMessage_Click);
                btnDiv.Controls.Add(view);
            }
            reader.Close();
            sc.Close();







        }
        if (Session["userType"].ToString().Equals("A"))
        {


        }

    }


    protected void btnSendMessage_click(object sender, EventArgs e)
    {
        if (Session["userType"].ToString().Equals("H"))
        {
            SqlCommand insertMessage = new SqlCommand("INSERT INTO MessageCenter(tenantID, hostID, messageText, opened) VALUES(@tID, @hID, @text, 'F')", sc);
            insertMessage.Parameters.AddWithValue("@tID", dropdownContacts.SelectedValue.ToString());
            insertMessage.Parameters.AddWithValue("@hID", Convert.ToString(ViewState["hostID"]));
            insertMessage.Parameters.AddWithValue("@text", txtBoxMessage.Text.ToString());
            sc.Open();
            insertMessage.ExecuteNonQuery();
            sc.Close();
        }

        if (Session["userType"].ToString().Equals("T"))
        {
            SqlCommand insertMessage = new SqlCommand("INSERT INTO MessageCenter(tenantID, hostID, messageText, opened) VALUES(@tID, @hID, @text, 'F')", sc);
            insertMessage.Parameters.AddWithValue("@tID", Convert.ToString(ViewState["tenantID"]));
            insertMessage.Parameters.AddWithValue("@hID", dropdownContacts.SelectedValue.ToString());
            insertMessage.Parameters.AddWithValue("@text", txtBoxMessage.Text.ToString());
            sc.Open();
            insertMessage.ExecuteNonQuery();
            sc.Close();
        }
    }

    protected void AddToDropdown(string name, int recipientID)
    {
        ListItem contact = new ListItem();
        contact.Text = name;
        contact.Value = recipientID.ToString();

        dropdownContacts.Items.Add(contact);
    }

    protected void ViewMessage_Click(object sender, EventArgs e)
    {
        string title = "Greetings";
        string body = "Welcome to ASPSnippets.com";
        ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + title + "', '" + body + "');", true);
    }

}