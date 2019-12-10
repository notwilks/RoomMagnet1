using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class IntentToLease : System.Web.UI.Page
{
    int accomID;

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

        var dateAndTime = DateTime.Now;
        var date = dateAndTime.Date;
        DateBox.Text = Convert.ToString(DateTime.Now.ToString("MM/dd/yyyy"));

        tenantName.Text = Convert.ToString(Session["tenantLease"]);

        if(Convert.ToString(Session["tenantCleared"]) == "T")
        {
            tenantYes.Checked = true;
        }
        else
        {
            tenantNo.Checked = true;
        }

        Button cancel = new Button();
        cancel.Attributes.Add("class", "btn btn-secondary");
        cancel.Text = "Cancel";
        cancel.ID = Convert.ToString(Session["accomIDLease"]);
        cancel.Click += new EventHandler(CancelClick);
        cancelArea.Controls.Add(cancel);

        SqlCommand load = new SqlCommand();
        load.Connection = sc;

        sc.Open();

        try
        {
            load.CommandText = "Select date, tenantName, hostName, tenantCleared, hostCleared, tSignature, hSignature, accommodationID from RentalAgreement where accommodationID = " + Session["RAaccomID"];

            SqlDataReader reader = load.ExecuteReader();
            while (reader.Read())
            {
                DateBox.Text = Convert.ToString(DateTime.Now.ToString("MM/dd/yyyy"));
                tenantName.Text = HttpUtility.HtmlEncode(reader.GetString(1));
                landlordName.Text = HttpUtility.HtmlEncode(reader.GetString(2));
                TenantSignature.Text = HttpUtility.HtmlEncode(reader.GetString(5));
                HostSignature.Text = HttpUtility.HtmlEncode(reader.GetString(6));
                accomID = reader.GetInt32(7);
            }
            reader.Close();
            
        }
        catch
        {

        }
        sc.Close();

        if (Convert.ToString(Session["userType"]) == "H")
        {
            streetAddress.ReadOnly = false;
            cityBox.ReadOnly = false;
            stateBox.ReadOnly = false;
            leaseTermBox.ReadOnly = false;
            AvailableDateBox.ReadOnly = false;
            PriceBox.ReadOnly = false;
            TenantSignature.ReadOnly = true;
            landlordName.ReadOnly = false;
            saveButton.Text = "Save";
        }
        else if (Convert.ToString(Session["userType"]) == "T")
        {
            HostSignature.ReadOnly = true;
        }
        else
        {

        }

    }

    protected void CancelClick(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["userType"]) == "T")
        {
            Button b = sender as Button;
            String ID = b.ID;
            Session["propertyID"] = ID;
            Response.Redirect("PropertyInfo.aspx");
        }
        else
        {
            Response.Redirect("HostDashboard.aspx");
        }
    }

    protected void saveButton_Click(object sender, EventArgs e)
    {
        String tCleared = "";
        String hCleared = "";
        SqlCommand save = new SqlCommand();
        save.Connection = sc;

        sc.Open();

        if (Convert.ToString(Session["userType"]) == "T")
        {
            save.CommandText = "Insert into RentalAgreement (hostID, tenantID, date, tenantName, hostName, tenantCleared, hostCleared, streetAddress, city, state, rentalLength, " +
            "startDate, price, tSignature, hSignature, lastUpdated, lastUpdatedBy) " +
            "VALUES (@hostID, @tenantID, isnull(@date, '01/01/2019'), @tenantName, @hostName, @tenantCleared, @hostCleared, @streetAddress, " +
            "@city, @state, @rentalLength, @startDate, @price, @tSignature, @hSignature, @lastUpdated2, @lastUpdatedBy2) ";

            save.Parameters.Add(new System.Data.SqlClient.SqlParameter("@hostID", Convert.ToInt32(Session["hostIDLease"])));
            save.Parameters.Add(new System.Data.SqlClient.SqlParameter("@tenantID", Convert.ToInt32(Session["tenantIDLease"])));
            save.Parameters.Add(new System.Data.SqlClient.SqlParameter("@date", DateBox.Text));
            save.Parameters.Add(new System.Data.SqlClient.SqlParameter("@tenantName", tenantName.Text));
            save.Parameters.Add(new System.Data.SqlClient.SqlParameter("@hostName", landlordName.Text));
            save.Parameters.AddWithValue("@lastUpdated2", DateTime.Now);
            save.Parameters.AddWithValue("@lastUpdatedBy2", "Joe Muia");

            if (tenantYes.Checked)
            {
                tCleared = "T";
            }
            else
            {
                tCleared = "F";
            }
            save.Parameters.Add(new System.Data.SqlClient.SqlParameter("@tenantCleared", tCleared));

            if (hostYes.Checked)
            {
                hCleared = "T";
            }
            else
            {
                hCleared = "F";
            }
            save.Parameters.Add(new System.Data.SqlClient.SqlParameter("@hostCleared", hCleared));
            save.Parameters.Add(new System.Data.SqlClient.SqlParameter("@streetAddress", streetAddress.Text));
            save.Parameters.Add(new System.Data.SqlClient.SqlParameter("@city", cityBox.Text));
            save.Parameters.Add(new System.Data.SqlClient.SqlParameter("@state", stateBox.Text));
            save.Parameters.Add(new System.Data.SqlClient.SqlParameter("@rentalLength", leaseTermBox.Text));
            save.Parameters.Add(new System.Data.SqlClient.SqlParameter("@startDate", AvailableDateBox.Text));
            save.Parameters.Add(new System.Data.SqlClient.SqlParameter("@price", PriceBox.Text));
            save.Parameters.Add(new System.Data.SqlClient.SqlParameter("@tSignature", TenantSignature.Text));
            save.Parameters.Add(new System.Data.SqlClient.SqlParameter("@hSignature", HostSignature.Text));

            save.ExecuteNonQuery();

            Response.Redirect("TenantDashboard.aspx");
        }

        else if (Convert.ToString(Session["userType"]) == "H")
        {
            save.CommandText = "update RentalAgreement set date = @date1, hostName = @hostName1, streetAddress = @streetAddress1, city = @city1, " +
                "state = @state1, rentalLength = @rentalLength1, startDate = @startDate1, price = @price1, tSignature = @tSig1, hSignature = @hSig1, lastUpdated = @lastUpdated3, lastUpdatedBy = @lastUpdatedBy3 where accommodationID = " + accomID;

            save.Parameters.Add(new System.Data.SqlClient.SqlParameter("@date1", Convert.ToString(DateTime.Now.ToString("MM/dd/yyyy"))));
            save.Parameters.Add(new System.Data.SqlClient.SqlParameter("@hostName1", landlordName.Text));
            save.Parameters.Add(new System.Data.SqlClient.SqlParameter("@streetAddress1", streetAddress.Text));
            save.Parameters.Add(new System.Data.SqlClient.SqlParameter("@city1", cityBox.Text));
            save.Parameters.Add(new System.Data.SqlClient.SqlParameter("@state1", stateBox.Text));
            save.Parameters.Add(new System.Data.SqlClient.SqlParameter("@rentalLength1", leaseTermBox.Text));
            save.Parameters.Add(new System.Data.SqlClient.SqlParameter("@startDate1", AvailableDateBox.Text));
            save.Parameters.Add(new System.Data.SqlClient.SqlParameter("@price1", PriceBox.Text));
            save.Parameters.Add(new System.Data.SqlClient.SqlParameter("@tSig1", TenantSignature.Text));
            save.Parameters.Add(new System.Data.SqlClient.SqlParameter("@hSig1", HostSignature.Text));
            save.Parameters.AddWithValue("@lastUpdated3", DateTime.Now);
            save.Parameters.AddWithValue("@lastUpdatedBy3", "Joe Muia");

            save.ExecuteNonQuery();

            Response.Redirect("HostDashboard.aspx");
        }
        else
        {

        }
        sc.Close();
    }
}