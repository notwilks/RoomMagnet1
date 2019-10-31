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

        SqlCommand select = new SqlCommand();
        select.Connection = sc;
 
            select.CommandText = "Select (firstName + ' ' + lastName) from host where email = @email";
            select.Parameters.Add(new System.Data.SqlClient.SqlParameter("@email", Session["userEmail"]));
            String userName = Convert.ToString(select.ExecuteScalar());
            FirstNameLastNameHeader.Text = userName + "'s Dashboard";
            HostName.Text = userName.ToString();

            //Header.Text = "Host Dashboard.";
            //select.CommandText = "Select (firstName + ' ' + lastName) from host where email = @email1";
            //select.Parameters.Add(new System.Data.SqlClient.SqlParameter("@email1", Session["userEmail"]));
            //String hostName = Convert.ToString(select.ExecuteScalar());
            //ProfileHeader.Text = "Welcome " + hostName;
        
    }
    protected void EditProfileBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("EditAccountInformation.aspx");
    }
    protected void SearchProperties_Click(object sender, EventArgs e)
    {
        Response.Redirect("SearchResultPage.aspx");
    }
}