using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class AdminDashboard : System.Web.UI.Page
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

        approveButton.Visible = false;
        approveTenant.Visible = false;
        ArrayList hostNames = new ArrayList();

        sc.Open();

        SqlCommand select = new SqlCommand();
        select.Connection = sc;

        select.CommandText = "select ISNULL(hostID, 0), ISNULL((lastName + ', ' + firstName), ''), isnull(email, ''), isnull(cleared, 'F') from Host where lastName = @lastName";
        select.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lastName", lastNameSearchBox.Text));

        SqlDataReader reader = select.ExecuteReader();
        while (reader.Read())
        {
            
            String temp = HttpUtility.HtmlEncode(reader.GetString(1));
            hostNames.Add(temp);
            
            //row div creation for hosts
            var div1 = new HtmlGenericControl("div")
            {

            };

            HostResults.Controls.Add(div1);
            div1.Style.Add("margin-top", "1rem;");
            div1.Style.Add("border-bottom", "solid;");
            div1.Style.Add("border-bottom-width", "1px;");
            div1.Attributes.Add("class", "row");

            //Name div
            var leftDiv = new HtmlGenericControl("div")
            {

            };

            div1.Controls.Add(leftDiv);
            leftDiv.Attributes.Add("class", "col-md-3");

            //email div
            var emailDiv = new HtmlGenericControl("div")
            {

            };

            div1.Controls.Add(emailDiv);
            emailDiv.Attributes.Add("class", "col-md-4");

            //buttons div
            var butDiv = new HtmlGenericControl("div")
            {

            };

            div1.Controls.Add(butDiv);
            butDiv.Attributes.Add("class", "col-md-5");

            //host last and first name
            String hostLF = HttpUtility.HtmlEncode(reader.GetString(1));
            var hostName = new HtmlGenericControl("p")
            {
                InnerText = hostLF
            };

            leftDiv.Controls.Add(hostName);

            //host email
            String hostE = HttpUtility.HtmlEncode(reader.GetString(2));
            var hostEmail = new HtmlGenericControl("p")
            {
                InnerText = hostE
            };

            emailDiv.Controls.Add(hostEmail);

            //adding approve button
            String btnText = reader.GetString(3);
            Button clear = new Button();
            
            clear.ID = HttpUtility.HtmlEncode(Convert.ToString(reader.GetInt32(0)));

            if (btnText == "T")
            {
                clear.Text = "Revoke Background Check";
                clear.Attributes.Add("class", "btn btn-warning btn-sm");
            }
            if (btnText == "F")
            {
                clear.Text = "Complete Background Check";
                clear.Attributes.Add("class", "btn btn-success btn-sm");
            }
            clear.Style.Add("margin-bottom", "1rem;");
            clear.Attributes.Add("runat", "server");
            clear.Click += new EventHandler(approveButton_Click);
            butDiv.Controls.Add(clear);

            //delete account button
            Button delete = new Button();
            delete.ID = HttpUtility.HtmlEncode(Convert.ToString(reader.GetInt32(0) + "D"));
            delete.Style.Add("margin-bottom", "1rem;");
            delete.Attributes.Add("runat", "server");
            delete.Attributes.Add("class", "btn btn-danger btn-sm");
            delete.Style.Add("float", "right");
            delete.Text = "Delete Account";

            delete.Click += new EventHandler(DeleteHostButton_Click);
            butDiv.Controls.Add(delete);

        }
        reader.Close();

        //TENANT SIDE
        SqlCommand selectT = new SqlCommand();
        select.Connection = sc;

        select.CommandText = "select isnull(tenantID, 0), isnull((lastName + ', ' + firstName), ''), isnull(email, ''), ISNULL(cleared, 'F') from Tenant where lastName = @lastName1";
        select.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lastName1", lastNameSearchBox.Text));

        SqlDataReader readerT = select.ExecuteReader();

        while (readerT.Read())
        {
            //creating tenant row div
            var div2 = new HtmlGenericControl("div")
            {

            };

            TenantResults.Controls.Add(div2);
            div2.Style.Add("margin-top", "1rem;");
            div2.Style.Add("border-bottom", "solid;");
            div2.Style.Add("border-bottom-width", "1px;");
            div2.Attributes.Add("class", "row");

            //Name div
            var leftDiv = new HtmlGenericControl("div")
            {

            };

            div2.Controls.Add(leftDiv);
            leftDiv.Attributes.Add("class", "col-md-3");

            //email div
            var emailDiv = new HtmlGenericControl("div")
            {

            };

            div2.Controls.Add(emailDiv);
            emailDiv.Attributes.Add("class", "col-md-4");

            //buttons div
            var butDiv = new HtmlGenericControl("div")
            {

            };

            div2.Controls.Add(butDiv);
            butDiv.Attributes.Add("class", "col-md-5");

            //Tenant last and first name
            String tenantLF = HttpUtility.HtmlEncode(readerT.GetString(1));
            var tenantName = new HtmlGenericControl("p")
            {
                InnerText = tenantLF
            };

            leftDiv.Controls.Add(tenantName);

            //Tenant email
            String tenantE = HttpUtility.HtmlEncode(readerT.GetString(2));
            var tenantEmail = new HtmlGenericControl("p")
            {
                InnerText = tenantE
            };

            emailDiv.Controls.Add(tenantEmail);

            //adding approve button
            String btnText = HttpUtility.HtmlEncode(readerT.GetString(3));
            Button clear = new Button();

            clear.ID = HttpUtility.HtmlEncode(Convert.ToString(readerT.GetInt32(0)));
            if (btnText == "T")
            {
                clear.Text = "Revoke Background Check";
                clear.Attributes.Add("class", "btn btn-warning btn-sm");
            }
            if (btnText == "F")
            {
                clear.Text = "Complete Background Check";
                clear.Attributes.Add("class", "btn btn-success btn-sm");
            }
            clear.Style.Add("margin-bottom", "1rem;");
            clear.Attributes.Add("runat", "server");
            clear.Click += new EventHandler(approveTenant_Click);
            butDiv.Controls.Add(clear);

            //delete account button
            Button delete = new Button();
            delete.ID = HttpUtility.HtmlEncode(Convert.ToString(readerT.GetInt32(0) + "T"));
            delete.Style.Add("margin-bottom", "1rem;");
            delete.Attributes.Add("runat", "server");
            delete.Attributes.Add("class", "btn btn-danger btn-sm");
            delete.Style.Add("float", "right");
            delete.Text = "Delete Account";
            delete.Click += new EventHandler(DeleteTenantButton_Click);
            butDiv.Controls.Add(delete);
        }

        sc.Close();
        
    }

    protected void SearchButton_Click(object sender, EventArgs e)
    {

    }

    protected void approveButton_Click(object sender, EventArgs e)
    {

        sc.Open();
        Button b = sender as Button;
        SqlCommand clear = new SqlCommand();
        clear.Connection = sc;

        if (b.Text == "Complete Background Check")
        {
            clear.CommandText = "Update Host SET cleared = 'T' where hostID = " + b.ID;
            clear.ExecuteNonQuery();
            b.Text = "Revoke Background Check";
            b.Attributes.Add("class", "btn btn-warning btn-sm");
        }
        else
        {
            clear.CommandText = "Update Host SET cleared = 'F' where hostID = " + b.ID;
            clear.ExecuteNonQuery();
            b.Text = "Complete Background Check";
            b.Attributes.Add("class", "btn btn-success btn-sm");
        }

        sc.Close();
        
    }

    protected void approveTenant_Click(object sender, EventArgs e)
    {
        sc.Open();
        Button b = sender as Button;
        SqlCommand clear = new SqlCommand();
        clear.Connection = sc;

        if (b.Text == "Complete Background Check")
        {
            clear.CommandText = "Update Tenant SET cleared = 'T' where tenantID = " + b.ID;
            clear.ExecuteNonQuery();
            b.Text = "Revoke Background Check";
            b.Attributes.Add("class", "btn btn-warning btn-sm");
        }
        else
        {
            clear.CommandText = "Update Tenant SET cleared = 'F' where tenantID = " + b.ID;
            clear.ExecuteNonQuery();
            b.Text = "Complete Background Check";
            b.Attributes.Add("class", "btn btn-success btn-sm");
        }

        sc.Close();
    }

    protected void DeleteHostButton_Click(object sender, EventArgs e)
    {
        sc.Open();
        Button b = sender as Button;
        SqlCommand select = new SqlCommand();
        select.Connection = sc;

        String ID = b.ID.Substring(0, b.ID.Length - 1);
        select.CommandText = "select (lastName + ', ' + firstName + ': ' + email) from Host where hostID = " + ID;

        String hostLFModal = HttpUtility.HtmlEncode(Convert.ToString(select.ExecuteScalar()));

        ViewState["hostDeleteID"] = ID;
        
        ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + hostLFModal + "');", true);
    }

    protected void DeleteTenantButton_Click(object sender, EventArgs e)
    {
        sc.Open();
        Button b = sender as Button;
        SqlCommand select = new SqlCommand();
        select.Connection = sc;

        String ID = b.ID.Substring(0, b.ID.Length - 1);
        select.CommandText = "select (lastName + ', ' + firstName + ': ' + email) from tenant where tenantID = " + ID;

        String tenantLFModal = HttpUtility.HtmlEncode(Convert.ToString(select.ExecuteScalar()));

        ViewState["tenantDeleteID"] = ID;

        ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopupTenant('" + tenantLFModal + "');", true);
    }

    protected void YesDeleteHost(object sender, EventArgs e)
    {
        sc.Open();
        Button b = sender as Button;
        SqlCommand delete = new SqlCommand();
        delete.Connection = sc;

        delete.CommandText = "select accommodationID from Accommodation where hostID = " + ViewState["hostDeleteID"];
        String accomID = HttpUtility.HtmlEncode(Convert.ToString(delete.ExecuteScalar()));

        delete.CommandText = "select email from Host where hostID = " + ViewState["hostDeleteID"];
        String hostEmail = HttpUtility.HtmlEncode(Convert.ToString(delete.ExecuteScalar()));


        delete.CommandText = "Delete from FavoriteProperty where accommodationID = " + accomID;
        delete.ExecuteNonQuery();

        delete.CommandText = "Delete from AccommodationImages where accommodationID = " + accomID;
        delete.ExecuteNonQuery();

        delete.CommandText = "Delete from AccommodationAmmenity where accommodationID = " + accomID;
        delete.ExecuteNonQuery();

        delete.CommandText = "Delete from Accommodation where accommodationID = " + accomID;
        delete.ExecuteNonQuery();

        delete.CommandText = "Delete from HostImages where hostID = " + ViewState["hostDeleteID"];
        delete.ExecuteNonQuery();

        delete.CommandText = "Delete from MessageCenter where hostID = " + ViewState["hostDeleteID"];
        delete.ExecuteNonQuery();

        delete.CommandText = "Delete from RentalAgreement where hostID = " + ViewState["hostDeleteID"];
        delete.ExecuteNonQuery();

        delete.CommandText = "Delete from Host where hostID = " + ViewState["hostDeleteID"];
        delete.ExecuteNonQuery();

        delete.CommandText = "Delete from Passwords where email = '" + hostEmail + "'";
        delete.ExecuteNonQuery();

        SearchButton_Click(sender, e);
    }

    protected void YesDeleteTenant(object sender, EventArgs e)
    {
        sc.Open();
        Button b = sender as Button;
        SqlCommand delete = new SqlCommand();
        delete.Connection = sc;

        delete.CommandText = "select email from Tenant where tenantID = " + ViewState["tenantDeleteID"];
        String tenantEmail = HttpUtility.HtmlEncode(Convert.ToString(delete.ExecuteScalar()));

        delete.CommandText = "EXEC DeleteTenant " + ViewState["tenantDeleteID"];
        delete.ExecuteNonQuery();

        delete.CommandText = "Delete from Passwords where email = '" + tenantEmail + "'";
        delete.ExecuteNonQuery();

        SearchButton_Click(sender, e);

    }
}