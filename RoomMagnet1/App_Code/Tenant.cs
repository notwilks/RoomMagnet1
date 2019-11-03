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
    private String firstName;
    private String lastName;
    private String houseNumber;
    private String street;
    private String city;
    private String zip;
    private String state;
    private String country;
    private String email;
    private String phoneNumber;
    private String password;
    private DateTime birthDate;
    private String tenantType;
    private String biography;
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
    public void SetFirstName(String firstName)
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
    public String GetFirstName()
    {
        return this.firstName;
    }
    public void SetLastName(String lastName)
    {
        String name = lastName[0].ToString().ToUpper();
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
    public String GetLastName()
    {
        return this.lastName;
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

    public String GetHouseNumber()
    {
        return this.houseNumber;
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
    public String GetStreet()
    {
        return this.street;
    }
    public void SetCity(String city)
    {
        this.city = city;
    }
    public String GetCity()
    {
        return this.city;
    }
    public void SetZip(String zip)
    {
        this.zip = zip;
    }
    public String GetZip()
    {
        return this.zip;
    }
    public void SetState(String state)
    {
        this.state = state;
    }
    public String GetState()
    {
        return this.state;
    }
    public void SetCountry(String country)
    {
        this.country = country;
    }
    public String GetCountry()
    {
        return this.country;
    }

    public void SetEmail(String email)
    {
        this.email = email;
    }
    public String GetEmail()
    {
        return this.email;
    }

    public void SetPhoneNumber(String phoneNumber)
    {
        this.phoneNumber = phoneNumber;
    }
    public String GetPhoneNumber()
    {
        return this.phoneNumber;
    }
    public void SetPassword(String password)
    {
        this.password = password;
    }
    public String GetPassword()
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
    public void SetTenantType(String tenantType)
    {
        this.tenantType = tenantType;
    }
    public String GetTenantType()
    {
        return this.tenantType;
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