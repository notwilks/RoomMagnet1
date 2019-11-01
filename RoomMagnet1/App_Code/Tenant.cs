using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// Tenant Class
/// Information included:
/// Name, Date of Birth, Current Address, Account Password, type of Tenant
/// 
public class Tenant
{
    private int tenantID;
    private string firstName;
    private string lastName;
    private string houseNumber;
    private string street;
    private string city;
    private string zip;
    private string state;
    private string country;
    private string email;
    private string phoneNumber;
    private string password;
    private DateTime birthDate;
    private string tenantType;
    public Tenant()
    {

    }
    public void SetTenantID(int tenantID)
    {
        this.tenantID = tenantID;
    }
    public int GetTenantID()
    {
        return this.tenantID;
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
    public string GetFirstName()
    {
        return this.firstName;
    }
    public void SetLastName(string lastName)
    {
        string name = lastName[0].ToString().ToUpper();
        for (int i = 1; i < lastName.Length; i++)
        {
            // Keep capitalized letters for last names with a prefix
            if ((i >= 2) && (char.IsUpper(lastName[i])) && ((lastName.Substring(i - 2, 2) == "Mc") || (lastName.Substring(i - 2, 2) == "Di") || (lastName.Substring(i - 2, 2) == "De")))
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
    public string GetLastName()
    {
        return this.lastName;
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

    public string GetHouseNumber()
    {
        return this.houseNumber;
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
    public string GetStreet()
    {
        return this.street;
    }
    public void SetCity(string city)
    {
        this.city = city;
    }
    public string GetCity()
    {
        return this.city;
    }
    public void SetZip(string zip)
    {
        this.zip = zip;
    }
    public string GetZip()
    {
        return this.zip;
    }
    public void SetState(string state)
    {
        this.state = state;
    }
    public string GetState()
    {
        return this.state;
    }
    public void SetCountry(string country)
    {
        this.country = country;
    }
    public string GetCountry()
    {
        return this.country;
    }

    public void SetEmail(string email)
    {
        this.email = email;
    }
    public string GetEmail()
    {
        return this.email;
    }

    public void SetPhoneNumber(string phoneNumber)
    {
        this.phoneNumber = phoneNumber;
    }
    public string GetPhoneNumber()
    {
        return this.phoneNumber;
    }
    public void SetPassword(string password)
    {
        this.password = password;
    }
    public string GetPassword()
    {
        return this.password;
    }
    public void SetBirthDate(DateTime birthDate)
    {
        this.birthDate = birthDate;
    }
    public DateTime GetBirthDate()
    {
        return this.birthDate;
    }
    public void SetTenantType(string tenantType)
    {
        this.tenantType = tenantType;
    }
    public string GetTenantType()
    {
        return this.tenantType;
    }
    
}