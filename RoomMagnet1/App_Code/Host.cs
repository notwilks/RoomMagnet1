using System;
using System.Globalization;


public class Host
{
    private int hostID;
    private String firstName;
    private String lastName;
    private String hostEmail;
    private String houseNumber;
    private String street;
    private String city;
    private String state;
    private String country;
    private String zip;
    private String password;
    private String phoneNumber;
    private DateTime lastUpdated;
    private String lastUpdatedBy;
    private DateTime birthDate;
    private int accommodationID;
    private String biography;

    public Host()
    {

    }

    public Host(int hostID, String firstName, String lastName, String hostEmail, String streetAddress, String city, String state,
        String country, String zip, String phoneNumber, DateTime lastUpdated, String lastUpdatedBy, int accommodationID)
    {
        SetHostID(hostID);
        SetFirstName(firstName);
        SetLastName(lastName);
        SetHostEmail(hostEmail);
        SetHouseNumber(streetAddress);
        SetStreet(streetAddress);
        SetCity(city);
        SetState(state);
        SetCountry(country);
        SetZip(zip);
        SetPhoneNumber(phoneNumber);
        SetLastUpdated(lastUpdated);
        SetLastUpdatedBy(lastUpdatedBy);
        this.accommodationID = accommodationID;
    }

    public DateTime GetBirthDate()
    {
        return this.birthDate;
    }

    public void SetBirthDate(DateTime dob)
    {
        this.birthDate = dob;
    }

    public void SetPassword(String password)
    {
        this.password = password;
    }

    public void SetHostID(int hostID)
    {
        this.hostID = hostID;
    }

    public void SetFirstName(String firstName)
    {
        String name = firstName[0].ToString().ToUpper();
        for (int i = 1; i < firstName.Length; i++)
        {
            if ((i >= 2) && (char.IsUpper(firstName[i])) && ((firstName.Substring(i - 2, 2) == "La") || (firstName.Substring(i - 2, 2) == "Mc")))
            {
                name += firstName[i].ToString().ToUpper();
            }
            else
            {
                name += firstName[i].ToString().ToLower();
            }

        }
        this.firstName = name;
    }

    public void SetLastName(String lastName)
    {
        String name = lastName[0].ToString().ToUpper();
        for (int i = 1; i < lastName.Length; i++)
        {
            // Keep capitalized letters for last names with a prefix
            if ((i >= 3) && (char.IsUpper(lastName[i])) && ((lastName.Substring(i - 2, 2) == "Mc") || (lastName.Substring(i - 2, 2) == "Di") || (lastName.Substring(i - 2, 2) == "De")))
            {
                name += lastName[i].ToString().ToUpper();
            }
            // Capitalize first letter of a multi part last name
            else if ((i >= 1) && char.IsWhiteSpace(lastName[i - 1]))
            {
                name += lastName[i].ToString().ToUpper();
            }
            // Otherwise, lowercase
            else
            {
                name += lastName[i].ToString().ToLower();
            }
        }
        this.lastName = name;
    }

    public void SetHostEmail(String email)
    {
        this.hostEmail = email;
    }

    public void SetHouseNumber(String streetAddress)
    {
        String houseNumber = "";
        for (int i = 0; i < streetAddress.Length; i++)
        {
            // Grab numbers only
            if (char.IsDigit(streetAddress[i]))
            {
                houseNumber += streetAddress[i];
            }
            // Break out of the loop once the first space is hit
            else if ((i >= 1) && char.IsWhiteSpace(streetAddress[i]))
            {
                break;
            }

        }
        this.houseNumber = houseNumber;
    }

    public void SetStreet(String streetAddress)
    {
        String street = "";
        for (int i = 0; i < streetAddress.Length; i++)
        {
            // Include spaces in street name
            if (char.IsWhiteSpace(streetAddress[i]))
            {
                street += streetAddress[i];
            }
            // Captitalize letters after spaces
            else if ((i >= 2) && (char.IsLetter(streetAddress[i])) && char.IsWhiteSpace(streetAddress[i - 1]))
            {
                street += streetAddress[i].ToString().ToUpper();
            }
            else
            {
                continue;
            }
        }
        // Remove space in between house number and street
        if (char.IsWhiteSpace(street[0]))
        {
            street = street.Substring(1);
        }
        this.street = street;
    }

    public void SetCity(String city)
    {
        TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

        String strCity = "";
        for (int i = 0; i < city.Length; i++)
        {
            if (char.IsLetter(city[i]) || char.IsWhiteSpace(city[i]))
            {
                strCity += city[i];
            }
            strCity = textInfo.ToTitleCase(strCity.ToLower());
        }
        this.city = strCity;
    }

    public void SetState(String state)
    {
        this.state = state;
    }

    public void SetCountry(String country)
    {
        this.country = country;
    }

    public void SetZip(String zip)
    {
        this.zip = zip;
    }

    public void SetPhoneNumber(String phoneNum)
    {
        this.phoneNumber = phoneNum;
    }

    public void SetLastUpdatedBy(String lub)
    {
        this.lastUpdatedBy = lub;
    }

    public void SetLastUpdated(DateTime lu)
    {
        this.lastUpdated = lu;
    }

    public void SetAccomodationID(int accomID)
    {
        this.accommodationID = accomID;
    }

    public String GetPassword()
    {
        return this.password;
    }

    public int GetHostID()
    {
        return this.hostID;
    }

    public String GetFistName()
    {
        return this.firstName;
    }

    public String GetLastName()
    {
        return this.lastName;
    }

    public String GetHostEmail()
    {
        return this.hostEmail;
    }

    public String GetHouseNumber()
    {
        return this.houseNumber;
    }

    public String GetStreet()
    {
        return this.street;
    }

    public String GetCity()
    {
        return this.city;
    }

    public String GetState()
    {
        return this.state;
    }

    public String GetCountry()
    {
        return this.country;
    }

    public String GetZip()
    {
        return this.zip;
    }

    public String GetPhoneNumber()
    {
        return this.phoneNumber;
    }

    public int GetAccomodationID()
    {
        return this.accommodationID;
    }

    public String GetLastUpdatedBy()
    {
        return this.lastUpdatedBy;
    }

    public DateTime GetLastUpdated()
    {
        return this.lastUpdated;
    }

    public void SetBiography(String bio)
    {
        this.biography = bio;
    }

    public String GetBiography()
    {
        return this.biography;
    }
}