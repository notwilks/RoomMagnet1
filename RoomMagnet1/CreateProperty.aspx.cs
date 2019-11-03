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

            String bathroom = " ";
            String entrance = " ";
            String storage = " ";
            String furnished = " ";
            String smoker = " ";
            String pets = " ";
            String wifi = " ";
            String parking = " ";
            String kitchen = " ";
            String laundry = " ";
            String cable = " ";
            String allowPets = " ";

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

            if (Parking.SelectedValue == "T")
            {
                parking = "T";
            }
            else if (Parking.SelectedValue == "F")
            {
                parking = "F";
            }

            if (PrivateKitchen.SelectedValue == "T")
            {
                kitchen = "T";
            }
            else if (PrivateKitchen.SelectedValue == "F")
            {
                kitchen = "F";
            }

            if (PrivateLaundry.SelectedValue == "T")
            {
                laundry = "T";
            }
            else if (PrivateLaundry.SelectedValue == "F")
            {
                laundry = "F";
            }

            if (Wifi.SelectedValue == "T")
            {
                wifi = "T";
            }
            else if (Wifi.SelectedValue == "F")
            {
                wifi = "F";
            }

            if (Cable.SelectedValue == "T")
            {
                cable = "T";
            }
            else if (Cable.SelectedValue == "F")
            {
                cable = "F";
            }

            if (AllowPets.SelectedValue == "T")
            {
                allowPets = "T";
            }
            else if (AllowPets.SelectedValue == "F")
            {
                allowPets = "F";
            }
            // End of RadioButton Declarations If Statements

            // Radio Button If Statements that display errors if an option is not selected
            if (bathroom == " " || entrance == " " || storage == " " || furnished == " " || smoker == " " || pets == " " || parking == " " || kitchen == " "
                || laundry == " " || wifi == " " || cable == " " && allowPets == " ")
            {
                if (bathroom == " ")
                {
                    BathroomErrorLbl.Text = "Please select an option.";
                }
                else
                {
                    BathroomErrorLbl.Text = "";
                }

                if (entrance == " ")
                {
                    EntranceErrorLbl.Text = "Please select an option.";
                }
                else
                {
                    EntranceErrorLbl.Text = "";
                }

                if (storage == " ")
                {
                    StorageErrorLbl.Text = "Please select an option.";
                }
                else
                {
                    StorageErrorLbl.Text = "";
                }

                if (furnished == " ")
                {
                    FurnishedErrorLbl.Text = "Please select an option.";
                }
                else
                {
                    FurnishedErrorLbl.Text = "";
                }

                if (smoker == " ")
                {
                    SmokerErrorLbl.Text = "Please select an option.";
                }
                else
                {
                    SmokerErrorLbl.Text = "";
                }

                if (pets == " ")
                {
                    PetsErrorLbl.Text = "Please select an option.";
                }
                else
                {
                    PetsErrorLbl.Text = "";
                }

                if (parking == " ")
                {
                    ParkingErrorLbl.Text = "Please select an option.";
                }
                else
                {
                    ParkingErrorLbl.Text = "";
                }

                if (kitchen == " ")
                {
                    KitchenErrorLbl.Text = "Please select an option.";
                }
                else
                {
                    KitchenErrorLbl.Text = "";
                }

                if (laundry == " ")
                {
                    LaundryErrorLbl.Text = "Please select an option";
                }
                else
                {
                    LaundryErrorLbl.Text = "";
                }

                if (wifi == " ")
                {
                    WifiErrorLbl.Text = "Please select an option.";
                }
                else
                {
                    WifiErrorLbl.Text = "";
                }

                if (cable == " ")
                {
                    CableErrorLbl.Text = "Please select an option.";
                }
                else
                {
                    CableErrorLbl.Text = "";
                }

                if (allowPets == " ")
                {
                    AllowPetsErrorLbl.Text = "Please select an option.";
                }
                else
                {
                    AllowPetsErrorLbl.Text = "";
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
                }
                else
                {
                    TNumErrorLbl.Text = "";
                }

                if (EffectiveDateBox.Text == "")
                {
                    eDateErrorLbl.Text = "Please enter a date.";
                }
                else
                {
                    eDateErrorLbl.Text = "";
                }

                if (TerminationDateBox.Text == "")
                {
                    tDateErrorLbl.Text = "Please enter a date.";
                }
                else
                {
                    tDateErrorLbl.Text = "";
                }

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
                    DescriptErrorLbl.Text = "";
                }

                if (RoomTypeList.SelectedValue == "Select a Room Type")
                {
                    RoomTypeErrorLbl.Text = "Please select an option";
                }
                else
                {
                    RoomTypeErrorLbl.Text = "";
                }
            } // End of Textbox If Statement.

            // If Statement that validates the "Other" field for RoomType if "Other" is the selected value
            String roomTypeOther = "";
            if (RoomTypeList.SelectedValue == "Other")
            {
                if (OtherBox.Text == "")
                {
                    OtherErrorLbl.Text = "Please enter a description.";
                    RoomTypeErrorLbl.Text = "";
                }
                else
                {
                    roomTypeOther = OtherBox.Text;
                    OtherErrorLbl.Text = "";
                    RoomTypeErrorLbl.Text = "";
                }
            } // End of RoomType validator If Statement

            // If Statement that allows the create statements to be sent through
            if (PriceBox.Text != "" && AddressBox.Text != "" && CityBox.Text != "" && ZipBox.Text != "" && stateBox.SelectedIndex != 0 && PriceBox.Text != "" && Convert.ToDouble(PriceBox.Text) > 0 &&
                  TNumBox.Text != "" && NeighborhoodBox.Text != "" && DescriptBox.Text != "" && EffectiveDateBox.Text != "" && TerminationDateBox.Text != "" && RoomTypeList.SelectedValue != "Select a Room Type"
                  && bathroom != " " && entrance != " " && storage != " " && furnished != " " && smoker != " " && pets != " " && parking != " " && kitchen != " " && laundry != " " && wifi != " " && cable != " " && allowPets != " ")
            {
                // Code that parses the address string and converts it to house number and street
                address = AddressBox.Text;
                int space = address.IndexOf(" ");
                houseNumber = address.Substring(0, address.IndexOf(' '));
                street = address.Substring(address.IndexOf(' ') + 1, address.Length - address.IndexOf(' ') - 1);

                // If Statement that adds apartment to the street column 
                if (ApartmentBox.Text != "")
                {
                    street = street + " " + ApartmentBox.Text;
                }
                else
                {
                    //do nothing
                } // End of Apartment If Statement 
                          
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
                // If Statement that changes the "Other" value to the text entered in the OtherBox for the SetRoomType method
                if (roomTypeOther == "")
                {
                   tempAccom.SetRoomType(RoomTypeList.SelectedValue);
                }
                else
                {
                   tempAccom.SetRoomType(roomTypeOther);
                }
                tempAccom.SetEffectiveDate(Convert.ToDateTime(EffectiveDateBox.Text));
                tempAccom.SetTerminationDate(Convert.ToDateTime(EffectiveDateBox.Text));
                tempAccom.SetExtraInfo(ExtraInfoBox.Text);

                insert.Connection = sc;
                sc.Open();

                insert.CommandText = "INSERT INTO Accommodation (hostID, houseNumber, street, city, state, country, zipCode, price, numOfTenants, neighborhood, description, roomType, effectiveDate, terminationDate, lastUpdated, lastUpdatedBy, extraInfo, listed) " +
                    "VALUES (@hostID, @houseNumber, @street, @city, @state, @country, @zipCode, @price, @tNum, @hood, @description, @roomType, @eDate, @tDate, @lastU, @lastUB, @extraInfo, @listed)";

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
                insert.Parameters.Add(new SqlParameter("@listed", "F"));

                insert.ExecuteNonQuery();

                insert.CommandText = "Select accommodationID from Accommodation where hostID in (Select hostID from Host where email = @hostEmail1)";
                insert.Parameters.Add(new SqlParameter("@hostEmail1", Convert.ToString(Session["userEmail"])));

                int accomID = Convert.ToInt32(insert.ExecuteScalar());

                insert.CommandText = "Insert into AccommodationImages (accommodationID) VALUES (" + accomID + ")";

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

                insertAmenity.CommandText = "INSERT INTO AccommodationAmmenity (accommodationID, bathroom, entrance, storage, furnished, smoker, pets, lastUpdated, lastUpdatedBy, parking, kitchen, laundry, wifi, cable, allowPets) " +
                   "VALUES (@accommodationID," + " @bathroom, @entrance, @storage, @furnished, @smoker, @pets, @lU, @lUB, @parking, @kitchen, @laundry, @wifi, @cable, @allowPets)";

                insertAmenity.Parameters.Add(new SqlParameter("@accommodationID", accommodationID));
                insertAmenity.Parameters.Add(new SqlParameter("@bathroom", bathroom));
                insertAmenity.Parameters.Add(new SqlParameter("@entrance", entrance));
                insertAmenity.Parameters.Add(new SqlParameter("@storage", storage));
                insertAmenity.Parameters.Add(new SqlParameter("@furnished", furnished));
                insertAmenity.Parameters.Add(new SqlParameter("@smoker", smoker));
                insertAmenity.Parameters.Add(new SqlParameter("@pets", pets));
                insertAmenity.Parameters.Add(new SqlParameter("@lU", DateTime.Now));
                insertAmenity.Parameters.Add(new SqlParameter("@lUB", "Joe Muia"));
                insertAmenity.Parameters.Add(new SqlParameter("@parking", parking));
                insertAmenity.Parameters.Add(new SqlParameter("@kitchen", kitchen));
                insertAmenity.Parameters.Add(new SqlParameter("@laundry", laundry));
                insertAmenity.Parameters.Add(new SqlParameter("@wifi", wifi));
                insertAmenity.Parameters.Add(new SqlParameter("@cable", cable));
                insertAmenity.Parameters.Add(new SqlParameter("@allowPets", allowPets));
                 
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
        Response.Redirect("HostDashboard.aspx");
    }
}