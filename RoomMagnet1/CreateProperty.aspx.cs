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
        try
        {
            SqlCommand insert = new System.Data.SqlClient.SqlCommand();


            Accommodation tempAccom = new Accommodation();
            String address = "";
            String houseNumber = "";
            String street = "";
            String apartment = "";
            int accommodationID;
            int hostID;

            SqlCommand FindHostID = new SqlCommand();
            FindHostID.Connection = sc;
            sc.Open();

            FindHostID.CommandText = "SELECT hostID FROM HOST WHERE email = @email";
            FindHostID.Parameters.Add(new SqlParameter("@email", Session["userEmail"]));
            hostID = Convert.ToInt32(FindHostID.ExecuteScalar());

            sc.Close();

            if (apartment == "")
            {
                // do nothing
            }
            else
            {
                address = address + " " + apartment;
            }

            String bathroom = " ";
            String entrance = " ";
            String storage = " ";
            String furnished = " ";
            String smoker = " ";
            String pets = " ";

            // RadioButton Value Declaration If Statements
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
            // End of RadioButton Declarations If Statements

            // Radio Button If Statements that display errors if an option is not selected
            if (bathroom == "" || entrance == "" || storage == "" || furnished == "" || smoker == "" || pets == "")
            {
                if (bathroom == "")
                {
                    BathroomErrorLbl.Text = "Please select an option.";
                }
                else
                {
                    BathroomErrorLbl.Text = "";
                }

                if (entrance == "")
                {
                    EntranceErrorLbl.Text = "Please select an option.";
                }
                else
                {
                    EntranceErrorLbl.Text = "";
                }

                if (storage == "")
                {
                    StorageErrorLbl.Text = "Please select an option.";
                }
                else
                {
                    StorageErrorLbl.Text = "";
                }

                if (furnished == "")
                {
                    FurnishedErrorLbl.Text = "Please select an option.";
                }
                else
                {
                    FurnishedErrorLbl.Text = "";
                }

                if (smoker == "")
                {
                    SmokerErrorLbl.Text = "Please select an option.";
                }
                else
                {
                    SmokerErrorLbl.Text = "";
                }

                if (pets == "")
                {
                    PetsErrorLbl.Text = "Please select an option";
                }
                else
                {
                    PetsErrorLbl.Text = "";
                }
            } // End of Radio Button If Statements

            // TextBox If Statements that display error labels if left blank
            if (AddressBox.Text == "" || CityBox.Text == "" || ZipBox.Text == "" || stateBox.SelectedIndex == 0 || PriceBox.Text == "" || Convert.ToDouble(PriceBox.Text) < 0 || TNumBox.Text == ""
                || NeighborhoodBox.Text == "" || DescriptBox.Text == "" || EffectiveDateBox.Text == "" || TerminationDateBox.Text == "" || RoomTypeList.SelectedValue == "Select a Room Type")
            {
                if (AddressBox.Text == "")
                {
                    AddressErrorLbl.Text = "Please enter an address.";
                }
                else
                {
                    AddressErrorLbl.Text = "";
                }

                if (CityBox.Text == "")
                {
                    CityErrorLbl.Text = "Please enter a city";
                }
                else
                {
                    CityErrorLbl.Text = "";
                }

                if (stateBox.SelectedIndex == 0)
                {
                    StateErrorLbl.Text = "Please select a state.";
                }
                else
                {
                    StateErrorLbl.Text = "";
                }

                if (ZipBox.Text == "")
                {
                    ZipErrorLbl.Text = "Please enter a zip code.";
                }
                else
                {
                    ZipErrorLbl.Text = "";
                }

                if (PriceBox.Text == "")
                {
                    PriceErrorLbl.Text = "Please enter a monthly price.";
                }
                else
                {
                    PriceErrorLbl.Text = "";
                }

                if (TNumBox.Text == "")
                {
                    TNumErrorLbl.Text = "Please enter the number of tenants in this residence.";
                } // had to push

                if (NeighborhoodBox.Text == "")
                {
                    HoodErrorLbl.Text = "Please enter a neighborhood";
                }
                else
                {
                    HoodErrorLbl.Text = "";
                }

                if (DescriptBox.Text == "")
                {
                    DescriptErrorLbl.Text = "Please give your property a name";
                }
                else
                {
                    DescriptErrorLbl.Text =  "";
                }
            } // End of Textbox If Statement.

            // If Statement that allows the create statements to be sent through
            if (PriceBox.Text != "" && AddressBox.Text != "" && CityBox.Text != "" && ZipBox.Text != "" && stateBox.SelectedIndex != 0 && PriceBox.Text != "" && Convert.ToDouble(PriceBox.Text) > 0 &&
                  TNumBox.Text != "" && NeighborhoodBox.Text != "" && DescriptBox.Text != "" && EffectiveDateBox.Text != "" && TerminationDateBox.Text != "" && RoomTypeList.SelectedValue != "Select a Room Type"
                  && bathroom != "" && entrance != "" && storage != "" && furnished != "" && smoker != "" && pets != "")
            {
                 address = AddressBox.Text;
                 int space = address.IndexOf(" ");
                 houseNumber = address.Substring(0, address.IndexOf(' '));
                 street = address.Substring(address.IndexOf(' ') + 1, address.Length - address.IndexOf(' ') - 1);

                 tempAccom.SetHostID(hostID);
                 tempAccom.SetHouseNumber(houseNumber);
                 street = street + " " + apartment;
                 tempAccom.SetStreet(street);
                 tempAccom.SetCity(CityBox.Text);
                 tempAccom.SetState(stateBox.SelectedValue);
                 tempAccom.SetZip(ZipBox.Text);
                 tempAccom.SetPrice(Convert.ToDouble(PriceBox.Text));
                 tempAccom.SetTenants(Convert.ToInt32(TNumBox.Text));
                 tempAccom.SetNeighborhood(NeighborhoodBox.Text);
                 tempAccom.SetDescription(DescriptBox.Text);
                 tempAccom.SetRoomType(RoomTypeList.SelectedValue);
                 tempAccom.SetEffectiveDate(Convert.ToDateTime(EffectiveDateBox.Text));
                 tempAccom.SetTerminationDate(Convert.ToDateTime(EffectiveDateBox.Text));
                 tempAccom.SetExtraInfo(ExtraInfoBox.Text);

                 insert.Connection = sc;
                 sc.Open();

                 insert.CommandText = "INSERT INTO Accommodation (hostID, houseNumber, street, city, state, country, zipCode, price, numOfTenants, neighborhood, description, roomType, effectiveDate, terminationDate, lastUpdated, lastUpdatedBy, extraInfo) " +
                     "VALUES (@hostID, @houseNumber, @street, @city, @state, @country, @zipCode, @price, @tNum, @hood, @description, @roomType, @eDate, @tDate, @lastU, @lastUB, @extraInfo)";

                 insert.Parameters.Add(new SqlParameter("@hostID", tempAccom.GetHostID()));
                 insert.Parameters.Add(new SqlParameter("@houseNumber", HttpUtility.HtmlEncode(tempAccom.GetHouseNumber())));
                 insert.Parameters.Add(new SqlParameter("@street", HttpUtility.HtmlEncode(tempAccom.GetStreet())));
                 insert.Parameters.Add(new SqlParameter("@city", HttpUtility.HtmlEncode(tempAccom.GetCity())));
                 insert.Parameters.Add(new SqlParameter("@state", tempAccom.GetState()));
                 insert.Parameters.Add(new SqlParameter("@country", "US"));
                 insert.Parameters.Add(new SqlParameter("@zipCode", HttpUtility.HtmlEncode(tempAccom.GetZip())));
                 insert.Parameters.Add(new SqlParameter("@price", HttpUtility.HtmlEncode(tempAccom.GetPrice())));
                 insert.Parameters.Add(new SqlParameter("@tNum", HttpUtility.HtmlEncode(tempAccom.GetGuests())));
                 insert.Parameters.Add(new SqlParameter("@hood", HttpUtility.HtmlEncode(tempAccom.GetNeighborhood())));
                 insert.Parameters.Add(new SqlParameter("@description", HttpUtility.HtmlEncode(tempAccom.GetDescription())));
                 insert.Parameters.Add(new SqlParameter("@roomType", tempAccom.GetRoomType()));
                 insert.Parameters.Add(new SqlParameter("@eDate", tempAccom.GetEffectiveDate()));
                 insert.Parameters.Add(new SqlParameter("@tDate", tempAccom.GetTerminationDate()));
                 insert.Parameters.Add(new SqlParameter("@lastU", DateTime.Now));
                 insert.Parameters.Add(new SqlParameter("@lastUB", "Joe Muia"));
                 insert.Parameters.Add(new SqlParameter("@extraInfo", HttpUtility.HtmlEncode(tempAccom.GetExtraInfo())));

                 insert.ExecuteNonQuery();
                 sc.Close();

                 SqlCommand insertAmenity = new SqlCommand();
                 SqlCommand FindAccomID = new SqlCommand();

                 // Pulls the Accommodation ID to insert into the AccommodationAmenity
                 FindAccomID.Connection = sc;
                 sc.Open();
                 FindAccomID.CommandText = "SELECT MAX(AccommodationID) FROM Accommodation";
                 accommodationID = Convert.ToInt32(FindAccomID.ExecuteScalar());
                 sc.Close();

                 insertAmenity.Connection = sc;
                 sc.Open();

                 insertAmenity.CommandText = "INSERT INTO AccommodationAmmenity (accommodationID, bathroom, entrance, storage, furnished, smoker, pets, lastUpdated, lastUpdatedBy) VALUES (@accommodationID," +
                     " @bathroom, @entrance, @storage, @furnished, @smoker, @pets, @lU, @lUB)";

                 insertAmenity.Parameters.Add(new SqlParameter("@accommodationID", accommodationID));
                 insertAmenity.Parameters.Add(new SqlParameter("@bathroom", bathroom));
                 insertAmenity.Parameters.Add(new SqlParameter("@entrance", entrance));
                 insertAmenity.Parameters.Add(new SqlParameter("@storage", storage));
                 insertAmenity.Parameters.Add(new SqlParameter("@furnished", furnished));
                 insertAmenity.Parameters.Add(new SqlParameter("@smoker", smoker));
                 insertAmenity.Parameters.Add(new SqlParameter("@pets", pets));
                 insertAmenity.Parameters.Add(new SqlParameter("@lU", DateTime.Now));
                 insertAmenity.Parameters.Add(new SqlParameter("@lUB", "Joe Muia"));
                 
                 insertAmenity.ExecuteNonQuery();
                 sc.Close();

                 Response.Redirect("HostAccountConfirmation.aspx");

            } // End of If Statement that sends DB commands
        }
        catch (System.ArgumentOutOfRangeException)
        {
            //OutputLabel.Text = "Please provide a house number and street name in the \"Street Address\" textbox.";
        }
    }
    protected void SkipButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("Dashboard.aspx");
    }
}