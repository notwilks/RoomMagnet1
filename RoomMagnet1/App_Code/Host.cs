using System;
using System.Globalization;


public class Host
{
    private int hostID;
    private string firstName;
    private string lastName;
    private string hostEmail;
    private string houseNumber;
    private string street;
    private string city;
    private string state;
    private string country;
    private string zip;
    private string password;
    private string phoneNumber;
    private string lastUpdated;
    private DateTime birthDate;
    private int accommodationID;

    public Host()
    {

    }

    public Host(int hostID, string firstName, string lastName, string hostEmail, string streetAddress, string city, string state,
        string country, string zip, string phoneNumber, string lastUpdated, int accommodationID)
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

    public void SetPassword(string password)
    {
        this.password = password;
    }

    public void SetHostID(int hostID)
    {
        this.hostID = hostID;
    }

    public void SetFirstName(string firstName)
    {
        string name = firstName[0].ToString().ToUpper();
        for (int i = 1; i < firstName.Length; i++)
        {
            if ((i >= 3) && (char.IsUpper(firstName[i])) && ((firstName.Substring(i - 2, 2) == "La") || (firstName.Substring(i - 2, 2) == "Mc")))
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

    public void SetLastName(string lastName)
    {
        string name = lastName[0].ToString().ToUpper();
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

    public void SetHostEmail(string email)
    {
        this.hostEmail = email;
    }

    public void SetHouseNumber(string streetAddress)
    {
        string houseNumber = "";
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

    public void SetStreet(string streetAddress)
    {
        string street = "";
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

    public void SetCity(string city)
    {
        TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

        string strCity = "";
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

    public void SetState(string state)
    {
        this.state = state;
    }

    public void SetCountry(string country)
    {
        this.country = country;
    }

    public void SetZip(string zip)
    {
        this.zip = zip;
    }

    public void SetPhoneNumber(string phoneNum)
    {
        this.phoneNumber = phoneNum;
    }

    public void SetLastUpdated(string lastUpdated)
    {
        this.lastUpdated = lastUpdated;
    }

    public void SetAccomodationID(int accomID)
    {
        this.accommodationID = accomID;
    }

    public string GetPassword()
    {
        return this.password;
    }

    public int GetHostID()
    {
        return this.hostID;
    }

    public string GetFistName()
    {
        return this.firstName;
    }

    public string GetLastName()
    {
        return this.lastName;
    }

    public string GetHostEmail()
    {
        return this.hostEmail;
    }

    public string GetHouseNumber()
    {
        return this.houseNumber;
    }

    public string GetStreet()
    {
        return this.street;
    }

    public string GetCity()
    {
        return this.city;
    }

    public string GetState()
    {
        return this.state;
    }

    public string GetCountry()
    {
        return this.country;
    }

    public string GetZip()
    {
        return this.zip;
    }

    public string GetPhoneNumber()
    {
        return this.phoneNumber;
    }

    public int GetAccomodationID()
    {
        return this.accommodationID;
    }
}
