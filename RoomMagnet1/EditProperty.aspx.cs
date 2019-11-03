using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class EditProperty : System.Web.UI.Page
{
    SqlConnection sc = new SqlConnection(WebConfigurationManager.ConnectionStrings["RoomMagnetAWS"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            sc.Open();
            SqlCommand select = new SqlCommand();
            select.Connection = sc;

            select.CommandText = "Select houseNumber, street, state, zipCode, price, numOfTenants, neighborhood, description, roomType, extrainfo " +
                "from Accommodation where HostId in (Select HostID from Host where email = @email)";

            select.Parameters.Add(new System.Data.SqlClient.SqlParameter("@email", Convert.ToString(Session["userEmail"])));


            using (SqlDataReader reader = select.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        HouseNumBox.Text = reader.GetString(0);
                        StreetBox.Text = reader.GetString(1);
                        stateBox.SelectedValue = reader.GetString(2);
                        ZipBox.Text = reader.GetString(3);
                        Price.Text = "$" + reader.GetDecimal(4).ToString(".00");
                        NumOfTenantsBox.Text = reader.GetInt32(5).ToString();
                        neighborhoodBox.Text = reader.GetString(6);
                        PropNameBox.Text = reader.GetString(7);
                        RoomTypeList.SelectedValue = Convert.ToString(reader.GetString(8));
                        PropDescriptionBox.Text = reader.GetString(9);

                    }
                }
                reader.Close();
            }
            sc.Close();
        }
    }

    protected void SaveButton_Click(object sender, EventArgs e)
    {
        sc.Open();

        SqlCommand update = new SqlCommand();
        update.Connection = sc;

        SqlCommand oof = new SqlCommand();
        oof.Connection = sc;

        oof.CommandText = "select HostID from Host where email = @hostEmail";
        oof.Parameters.Add(new SqlParameter("@hostEmail", Convert.ToString(Session["userEmail"])));

        using (SqlDataReader reader = oof.ExecuteReader())
        {
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ViewState["tempID"] = reader["HostID"];
                }
            }
            reader.Close();
        }

        //THIS IS NOT UPDATING CORRECTLY A OF NOW ITS RUNNING BUT IT DOESNT THROW ANY ERROR
        update.CommandText = "Update [dbo].[Accommodation] SET " +
            "houseNumber = @houseNumber, " +
            "street = @street, " +
            "state = @state, " +
            "zipCode = @zip, " +
            "price = @price, " +
            "numOfTenants = @numTen, " +
            "neighborhood = @neighborhood, " +
            "description = @propName, " +
            "roomType = @roomType, " +
            "extraInfo = @bio where hostID = @tempID";

        update.Parameters.Add(new SqlParameter("@houseNumber", HouseNumBox.Text));
        update.Parameters.Add(new SqlParameter("@street", StreetBox.Text));
        update.Parameters.Add(new SqlParameter("@state", stateBox.SelectedValue));
        update.Parameters.Add(new SqlParameter("@zip", ZipBox.Text));
        // Remove dollar sign if present to insert into database properly
        if (Price.Text.Substring(0,1) == "$")
        {
            update.Parameters.Add(new SqlParameter("@price", Convert.ToDouble(Price.Text.Substring(1))));
        }
        else
        {
            update.Parameters.Add(new SqlParameter("@price", Convert.ToDouble(Price.Text)));
        }
        update.Parameters.Add(new SqlParameter("@numTen", Convert.ToInt32(NumOfTenantsBox.Text)));
        update.Parameters.Add(new SqlParameter("@neighborhood", neighborhoodBox.Text));
        update.Parameters.Add(new SqlParameter("@propName", PropNameBox.Text));
        update.Parameters.Add(new SqlParameter("@roomType", RoomTypeList.SelectedIndex.ToString()));
        update.Parameters.Add(new SqlParameter("@bio", PropDescriptionBox.Text));
        update.Parameters.Add(new SqlParameter("@tempID", ViewState["tempID"]));

        update.ExecuteNonQuery();

        sc.Close();

        Response.Redirect("HostDashboard.aspx");
    }
}