using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class GoogleMaps : System.Web.UI.Page
{
    SqlConnection sc = new SqlConnection(WebConfigurationManager.ConnectionStrings["RoomMagnetAWS"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        test.Text = getAddress();
    }
    protected string getAddress()
    {
        string address = "";
        SqlCommand select = new SqlCommand("select HouseNumber, street, neighborhood, state, country, zipCode from Accommodation WHERE HostID = 84");
        select.Connection = sc;
        sc.Open();

        using (SqlDataReader reader = select.ExecuteReader())
        {
            int i = 0;

            while (reader.Read())
            {
                address += (Convert.ToString(reader["HouseNumber"]) + " " + Convert.ToString(reader["street"]) + " " + Convert.ToString(reader["neighborhood"]) 
                    +  ", " + Convert.ToString(reader["state"]) + ", " + Convert.ToString(reader["country"]) + "A");
            }
        }
        return address;
    }
}