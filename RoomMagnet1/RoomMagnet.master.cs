using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI.HtmlControls;

public partial class RoomMagnet : System.Web.UI.MasterPage
{
    SqlConnection sc = new SqlConnection(WebConfigurationManager.ConnectionStrings["RoomMagnetAWS"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        String table = "";
        if(Convert.ToString(Session["userEmail"]) != "")
        {
            leftButton.InnerText = "My Profile";
            rightButton.InnerText = "Logout";
            rightButton.Attributes.Add("href", "LogoutPage.aspx");
            if (Convert.ToString(Session["userType"]) == "T")
            {
                leftButton.Attributes.Add("href", "TenantDashboard.aspx");
                table = "Tenant";
            }
            else if(Convert.ToString(Session["userType"]) == "H")
            {
                leftButton.Attributes.Add("href", "HostDashboard.aspx");
                table = "Host";
            }
            else if (Convert.ToString(Session["userType"]) == "A")
            {
                leftButton.Attributes.Add("href", "AdminDashboard.aspx");

            }

            sc.Open();

            SqlCommand select = new SqlCommand();
            select.Connection = sc;

            try
            {
                select.CommandText = "Select CONCAT(firstName, ' ' , lastName) from " + table + " where email = @email";
                select.Parameters.Add(new System.Data.SqlClient.SqlParameter("@email", Session["userEmail"]));
                String s1 = Convert.ToString(select.ExecuteScalar());
                signedInUser.InnerText = "Hi, " + HttpUtility.HtmlEncode(s1);
            }
            catch
            {
                signedInUser.InnerText = "Hi, Admin";
            }
            sc.Close();
            

        }
        else
        {
            leftButton.InnerText = "Create Account";
            rightButton.InnerText = "Login";
            leftButton.Attributes.Add("href", "CreateHostorTenant.aspx");
            rightButton.Attributes.Add("href", "LoginPage.aspx");
        }
    }
}
