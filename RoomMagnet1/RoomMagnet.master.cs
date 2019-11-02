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
        if(Convert.ToString(Session["userEmail"]) != "")
        {
            leftButton.InnerText = "My Profile";
            rightButton.InnerText = "Logout";
            rightButton.Attributes.Add("href", "LogoutPage.aspx");
            if (Convert.ToString(Session["userType"]) == "T")
            {
                leftButton.Attributes.Add("href", "TenantDashboard.aspx");
            }
            else if(Convert.ToString(Session["userType"]) == "H")
            {
                leftButton.Attributes.Add("href", "HostDashboard.aspx");
            }
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
