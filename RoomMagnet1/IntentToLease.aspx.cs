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
    SqlConnection sc = new SqlConnection(WebConfigurationManager.ConnectionStrings["RoomMagnetAWS"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
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

    }

    protected void CancelClick(object sender, EventArgs e)
    {
        Button b = sender as Button;
        String ID = b.ID;
        Session["propertyID"] = ID;
        Response.Redirect("PropertyInfo.aspx");
    }

    protected void saveButton_Click(object sender, EventArgs e)
    {
        String tCleared = "";
        String hCleared = "";
        SqlCommand save = new SqlCommand();
        save.Connection = sc;

        sc.Open();

        save.CommandText = "Insert into RentalAgreement (hostID, tenantID, date, tenantName, hostName, tenantCleared, hostCleared, streetAddress, city, state, rentalLength, " +
            "startDate, price, tSignature, hSignature) " +
            "VALUES (@hostID, @tenantID, isnull(@date, '01/01/2019'), @tenantName, @hostName, @tenantCleared, @hostCleared, @streetAddress, " +
            "@city, @state, @rentalLength, @startDate, @price, @tSignature, @hSignature) ";

        save.Parameters.Add(new System.Data.SqlClient.SqlParameter("@hostID", Convert.ToInt32(Session["hostIDLease"])));
        save.Parameters.Add(new System.Data.SqlClient.SqlParameter("@tenantID", Convert.ToInt32(Session["tenantIDLease"])));
        save.Parameters.Add(new System.Data.SqlClient.SqlParameter("@date", DateBox.Text));
        save.Parameters.Add(new System.Data.SqlClient.SqlParameter("@tenantName", tenantName.Text));
        save.Parameters.Add(new System.Data.SqlClient.SqlParameter("@hostName", landlordName.Text));

        if(tenantYes.Checked)
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

        sc.Close();

        Response.Redirect("TenantDashboard.aspx");
    }
}