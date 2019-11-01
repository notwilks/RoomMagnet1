﻿using System;
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
        sc.Open();

        SqlCommand select = new SqlCommand();
        select.Connection = sc;

        select.CommandText = "Select houseNumber, street, state, zipCode, price, numOfTenants, neighborhood, description, roomType, extrainfo " +
            "from Accommodation where HostId in (Select HostID from Host where email = @email)";

        select.Parameters.Add(new System.Data.SqlClient.SqlParameter("@email", Convert.ToString(Session["userEmail"])));

        SqlDataReader reader = select.ExecuteReader();

        while (reader.Read())
        {
            HouseNumBox.Text = reader.GetString(0);
            StreetBox.Text = reader.GetString(1);
            stateBox.SelectedValue = reader.GetString(2);
            ZipBox.Text = reader.GetString(3);
            Price.Text = reader.GetDecimal(4).ToString();
            NumOfTenantsBox.Text = reader.GetInt32(5).ToString();
            neighborhoodBox.Text = reader.GetString(6);
            PropNameBox.Text = reader.GetString(7);
            RoomTypeList.SelectedValue = Convert.ToString(reader.GetString(8));
            PropDescriptionBox.Text = reader.GetString(9);
            
        }
        sc.Close();
    }

    protected void SaveButton_Click(object sender, EventArgs e)
    {
        sc.Open();

        SqlCommand update = new SqlCommand();
        update.Connection = sc;


        //THIS IS NOT UPDATING CORRECTLY A OF NOW ITS RUNNING BUT IT DOESNT THROW ANY ERROR
        update.CommandText = "Update Accommodation Set " +
            "houseNumber = @houseNumber, " +
            "street = @street, " +
            "state = @state, " +
            "zipCode = @zip, " +
            "price = @price, " +
            "numOfTenants = @numTen, " +
            "neighborhood = @neighborhood, " +
            "description = @propName, " +
            "roomType = @roomType, " +
            "extraInfo = @bio where hostID in (Select hostID from Host where email = @email1)";

        update.Parameters.Add(new System.Data.SqlClient.SqlParameter("@houseNumber", HouseNumBox.Text));
        update.Parameters.Add(new System.Data.SqlClient.SqlParameter("@street", StreetBox.Text));
        update.Parameters.Add(new System.Data.SqlClient.SqlParameter("@state", stateBox.SelectedValue));
        update.Parameters.Add(new System.Data.SqlClient.SqlParameter("@zip", ZipBox.Text));
        update.Parameters.Add(new System.Data.SqlClient.SqlParameter("@price", Price.Text));
        update.Parameters.Add(new System.Data.SqlClient.SqlParameter("@numTen", NumOfTenantsBox.Text));
        update.Parameters.Add(new System.Data.SqlClient.SqlParameter("@neighborhood", neighborhoodBox.Text));
        update.Parameters.Add(new System.Data.SqlClient.SqlParameter("@propName", PropNameBox.Text));
        update.Parameters.Add(new System.Data.SqlClient.SqlParameter("@roomType", RoomTypeList.SelectedIndex.ToString()));
        update.Parameters.Add(new System.Data.SqlClient.SqlParameter("@bio", PropDescriptionBox.Text));
        update.Parameters.Add(new System.Data.SqlClient.SqlParameter("@email1", Convert.ToString(Session["userEmail"])));

        update.ExecuteNonQuery();

        sc.Close();

        Response.Redirect("HostDashboard.aspx");
    }
}