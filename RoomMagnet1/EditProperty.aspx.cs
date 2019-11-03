using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.IO;

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

            select.CommandText = "Select houseNumber, street, state, zipCode, price, numOfTenants, neighborhood, description, roomType, extrainfo, city " +
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
                        cityBox.Text = reader.GetString(10);

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
        String path = Server.MapPath("Images2/");
        SqlCommand updateImages = new SqlCommand();
        updateImages.Connection = sc;

        updateImages.CommandText = "Select accommodationID from Accommodation where hostID in (Select hostID from Host where email = @hostEmail1)";
        updateImages.Parameters.Add(new SqlParameter("@hostEmail1", Convert.ToString(Session["userEmail"])));

        int accomID = Convert.ToInt32(updateImages.ExecuteScalar());

        if (mainImage.HasFile)
        {
            String ext = Path.GetExtension(mainImage.FileName);

            if (ext == ".jpg" || ext == ".png" || ext == ".jpeg")
            {
                mainImage.SaveAs(path + accomID + mainImage.FileName);

                String name = "Images2/" + accomID + mainImage.FileName;

                try
                {
                    updateImages.CommandText = "INSERT INTO AccommodationImages (AccommodationID, mainImage) VALUES (" + accomID + ", @imageName)";
                    updateImages.Parameters.Add(new SqlParameter("@imageName", name));

                    updateImages.ExecuteNonQuery();
                }
                catch
                {
                    updateImages.CommandText = "update AccommodationImages set mainImage = @image where accommodationID = " + accomID;
                    updateImages.Parameters.Add(new SqlParameter("@image", name));

                    updateImages.ExecuteNonQuery();
                }
                

            }
        }

        if (image2.HasFile)
        {
            String ext = Path.GetExtension(image2.FileName);

            if (ext == ".jpg" || ext == ".png" || ext == ".jpeg")
            {
                image2.SaveAs(path + accomID + image2.FileName);

                String name = "Images2/" + accomID + image2.FileName;

                updateImages.CommandText = "update AccommodationImages set image2 = @image2 where accommodationID = " + accomID;
                updateImages.Parameters.Add(new SqlParameter("@image2", name));

                updateImages.ExecuteNonQuery();
            }
        }

        if (image3.HasFile)
        {
            String ext = Path.GetExtension(image3.FileName);

            if (ext == ".jpg" || ext == ".png" || ext == ".jpeg")
            {
                image3.SaveAs(path + accomID + image3.FileName);

                String name = "Images2/" + accomID + image3.FileName;

                updateImages.CommandText = "update AccommodationImages set image3 = @image3 where accommodationID = " + accomID;
                updateImages.Parameters.Add(new SqlParameter("@image3", name));

                updateImages.ExecuteNonQuery();
            }
        }



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
            "extraInfo = @bio, " +
            "city = @city " +
            "where hostID = @tempID";

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
        update.Parameters.Add(new SqlParameter("@city", cityBox.Text));

        update.ExecuteNonQuery();

        sc.Close();

        Response.Redirect("HostDashboard.aspx");
    }
}