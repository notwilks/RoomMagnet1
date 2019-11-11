using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;

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


            sc.Close();

            // Retrieve a Host's existing messages from DB
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
            SqlCommand insertMessage = new SqlCommand("INSERT INTO MessageCenter(tenantID, hostID, messageText) VALUES(@tID, @hID, @text)", sc);
            insertMessage.Parameters.AddWithValue("@tID", dropdownContacts.SelectedValue.ToString());
            insertMessage.Parameters.AddWithValue("@hID", Convert.ToString(ViewState["hostID"]));
            insertMessage.Parameters.AddWithValue("@text", txtBoxMessage.Text.ToString());
            sc.Open();
            insertMessage.ExecuteNonQuery();
            sc.Close();
        }

        if (Session["userType"].ToString().Equals("T"))
        {
            SqlCommand insertMessage = new SqlCommand("INSERT INTO MessageCenter(tenantID, hostID, messageText) VALUES(@tID, @hID, @text)", sc);
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
}