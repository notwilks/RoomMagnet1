using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class CreateProperty : System.Web.UI.Page
{
    SqlConnection sc = new SqlConnection(WebConfigurationManager.ConnectionStrings["RoomMagnetAWS"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        // User Name Display Label
        //OutputLabel.Text = "" + Convert.ToString(Session["userType"]);

        //Session["userEmail"] = "A";
    }

    protected void TextBox4_TextChanged(object sender, EventArgs e)
    {

    }

    protected void AddressBox_TextChanged(object sender, EventArgs e)
    {

    }

    protected void NextButton_Click(object sender, EventArgs e)
    {
        sc.Open();

        System.Data.SqlClient.SqlCommand insert = new System.Data.SqlClient.SqlCommand();
        insert.Connection = sc;
        try
        {
            Accommodation tempAccom = new Accommodation();
            String address = "";
            String houseNumber = "";
            String street = "";
            String apartment = "";
            int accommodationID;
            int hostID;


            insert.CommandText = "SELECT MAX(AccommodationID) FROM HOST";
            insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@email", Session["userEmail"]));
            accommodationID = Convert.ToInt32(insert.ExecuteScalar()) + 1;

            insert.CommandText = "SELECT hostID FROM HOST WHERE email = @email2";
            insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@email2", Session["userEmail"]));
            hostID = Convert.ToInt32(insert.ExecuteScalar());


            if (apartment == "")
            {
                // do nothing
            }
            else
            {
                address = address + " " + apartment;
            }

            if (AddressBox.Text == "" || CityBox.Text == "" || ZipBox.Text == "" || stateBox.SelectedIndex == 0)
            {
                // Please fill out all valid datafields
            }
            else if (AddressBox.Text != "")
            {
                address = AddressBox.Text;
                int space = address.IndexOf(" ");
                houseNumber = address.Substring(0, space);
                street = address.Substring(space, address.Length);

                tempAccom.SetHostID(hostID);
                tempAccom.SetHouseNumber(houseNumber);
                street = street + " " + apartment;
                tempAccom.SetStreet(street);
                tempAccom.SetState(stateBox.SelectedValue);
                tempAccom.SetZip(ZipBox.Text);
                tempAccom.SetDescription(DescriptBox.Text);
                tempAccom.SetRoomType(RoomTypeList.SelectedValue);
                tempAccom.SetExtraInfo(ExtraInfoBox.Text);

                insert.CommandText = "INSERT INTO Accommodation (hostID, houseNumber, street, state, zipCode, description, roomType) " +
                    "VALUES (@hostID, @houseNumber, @street, @state, @zipCode, @description, @roomType)";

                insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@hostID", tempAccom.GetHostID()));
                insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@houseNumber", HttpUtility.HtmlEncode(tempAccom.GetHouseNumber())));
                insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@street", HttpUtility.HtmlEncode(tempAccom.GetStreet())));
                insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@state", HttpUtility.HtmlEncode(tempAccom.GetState())));
                insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@zipCode", HttpUtility.HtmlEncode(tempAccom.GetZip())));
                insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@description", HttpUtility.HtmlEncode(tempAccom.GetDescription())));
                insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@roomType", HttpUtility.HtmlEncode(tempAccom.GetRoomType())));
                insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@extraInfo", HttpUtility.HtmlEncode(tempAccom.GetExtraInfo())));

                insert.ExecuteNonQuery();

                String bathroom = "";
                String entrance = "";
                String storage = "";
                String furnished = "";
                String smoker = "";
                String pets = "";

                if (PrivateBathroom.SelectedValue == "T")
                {
                    bathroom = "T";
                }
                else if (PrivateBathroom.SelectedValue == "F")
                {
                    bathroom = "F";
                }

                if (PrivateEntrance.SelectedValue == "T")
                {
                    entrance = "T";
                }
                else if (PrivateEntrance.SelectedValue == "F")
                {
                    entrance = "F";
                }

                if (StorageSpace.SelectedValue == "T")
                {
                    storage = "T";
                }
                else if (StorageSpace.SelectedValue == "F")
                {
                    storage = "F";
                }

                if (Furnished.SelectedValue == "T")
                {
                    furnished = "T";
                }
                else if (Furnished.SelectedValue == "F")
                {
                    furnished = "F";
                }

                if (Smokers.SelectedValue == "T")
                {
                    smoker = "T";
                }
                else if (Smokers.SelectedValue == "F")
                {
                    smoker = "F";
                }

                if (Pets.SelectedValue == "T")
                {
                    pets = "T";
                }
                else if (Pets.SelectedValue == "F")
                {
                    pets = "F";
                }

                insert.CommandText = "INSERT INTO AccommodationAmenity (accommodationID, bathroom, entrance, storage, furnished, smoker, pets, extraInfo) VALUES (@accommodationID," +
                    " @bathroom, @entrance, @storage, @furnished, @smoker, @pets, @extraInfo)";

                insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@accommodationID", accommodationID));
                insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@bathroom", bathroom));
                insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@entrance", entrance));
                insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@storage", storage));
                insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@furnished", furnished));
                insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@smoker", smoker));
                insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@pets", pets));

                insert.ExecuteNonQuery();

                Response.Redirect("Dashboard.aspx");

            }
        }
        catch (Exception)
        {

        }
    }
    protected void SkipButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("Dashboard.aspx");
    }
}