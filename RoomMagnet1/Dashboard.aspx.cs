using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class HostDashboard : System.Web.UI.Page
{
    SqlConnection sc = new SqlConnection(WebConfigurationManager.ConnectionStrings["RoomMagnetAWS"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        
        sc.Open();

        System.Data.SqlClient.SqlCommand select = new System.Data.SqlClient.SqlCommand();
        select.Connection = sc;

        if (Session["userType"].Equals(""))
        {
            logoutButton.Visible = false;
            navBarName.Text = "";
        }
        else if (Session["userType"].Equals("H"))
        {
            logoutButton.Visible = true;
            select.CommandText = "Select (firstName + ' ' + lastName) from host where email = @email";
            select.Parameters.Add(new System.Data.SqlClient.SqlParameter("@email", Session["userEmail"]));
            String userName = Convert.ToString(select.ExecuteScalar());
            navBarName.Text = "" + userName;

            Header.Text = "Host Dashboard.";
            select.CommandText = "Select (firstName + ' ' + lastName) from host where email = @email1";
            select.Parameters.Add(new System.Data.SqlClient.SqlParameter("@email1", Session["userEmail"]));
            String hostName = Convert.ToString(select.ExecuteScalar());
            welcome.Text = "Welcome " + hostName;
        }
        else
        {
            logoutButton.Visible = true;
            select.CommandText = "Select (firstName + ' ' + lastName) from tenant where email = @email2";
            select.Parameters.Add(new System.Data.SqlClient.SqlParameter("@email2", Session["userEmail"]));
            String userName = Convert.ToString(select.ExecuteScalar());
            navBarName.Text = "" + userName;

            Header.Text = "Tenant Dashboard.";
            select.CommandText = "Select (firstName + ' ' + lastName) from tenant where email = @email3";
            select.Parameters.Add(new System.Data.SqlClient.SqlParameter("@email3", Session["userEmail"]));
            String userName1 = Convert.ToString(select.ExecuteScalar());
            welcome.Text = "Welcome " + userName1;

        }



    }

    protected void logoutButton_Click(object sender, EventArgs e)
    {
        Session["userType"] = "";
        Session["userEmail"] = "";
        Response.Redirect("HomePage.aspx");
    }
}