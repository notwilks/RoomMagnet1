using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class Accommodation
{
    private int accommodationID;
    private int hostID;
    private String houseNumber;
    private String street;
    private String city;
    private String state;
    private String country;
    private String zipCode;
    private String price;
    private int numOfTenants;
    private DateTime effectiveDate;
    private DateTime terminationDate;
    private String roomType;
    private String neighborhood;
    private String accomdDescription;
    private int[] favorites;
    private String extraInfo;

    public Accommodation()
    {
        SetAccommodationID(accommodationID);
        SetHostID(hostID);
        SetHouseNumber(houseNumber);
        SetStreet(street);
        SetCity(city);
        SetState(state);
        SetCountry(country);
        SetZip(zipCode);
        SetPrice(price);
        SetTenants(numOfTenants);
        SetEffectiveDate(effectiveDate);
        SetTerminationDate(terminationDate);
        SetRoomType(roomType);
        SetNeighborhood(neighborhood);
        SetDescription(accomdDescription);
        SetExtraInfo(extraInfo);
    }

    public Accommodation(int accommodationID, int hostID, String houseNumber, String street, String city, String state, String country,
        String zipCode, String price, int numOfTenants, DateTime effectiveDate, DateTime terminationDate, String roomType, String neighborhood, String accomdDescription, String extraInfo)
    {
        SetAccommodationID(accommodationID);
        SetHostID(hostID);
        SetHouseNumber(houseNumber);
        SetStreet(street);
        SetCity(city);
        SetState(state);
        SetCountry(country);
        SetZip(zipCode);
        SetPrice(price);
        SetTenants(numOfTenants);
        SetEffectiveDate(effectiveDate);
        SetTerminationDate(terminationDate);
        SetRoomType(roomType);
        SetNeighborhood(neighborhood);
        SetDescription(accomdDescription);
        SetExtraInfo(extraInfo);
    }
    public void SetAccommodationID(int accommodationID)
    {
        this.accommodationID = accommodationID;
    }
    public int GetAccommodationID()
    {
        return accommodationID;
    }
    public void SetHostID(int hostID)
    {
        this.hostID = hostID;
    }
    public int GetHostID()
    {
        return hostID;
    }
    public void SetHouseNumber(String houseNumber)
    {
        this.houseNumber = houseNumber;
    }
    public String GetHouseNumber()
    {
        return houseNumber;
    }
    public void SetStreet(String street)
    {
        this.street = street;
    }
    public String GetStreet()
    {
        return street;
    }
    public void SetCity (String city)
    {
        this.city = city;
    }
    public String GetCity()
    {
        return city;
    }
    public void SetState(String state)
    {
        this.state = state;
    }
    public String GetState()
    {
        return state;
    }
    public void SetCountry(String country)
    {
        this.country = country;
    }
    public String GetCountry()
    {
        return country;
    }
    public void SetZip(String zipCode) 
    {
        this.zipCode = zipCode;
    }
    public String GetZip()
    {
        return zipCode;
    }
    public void SetPrice(String price)
    {
        this.price = price;
    }
    public String GetPrice()
    {
        return price;
    }
    public void SetTenants(int numOfTenants)
    {
        this.numOfTenants = numOfTenants;
    }
    public int GetGuests()
    {
        return numOfTenants;
    }
    public void SetEffectiveDate(DateTime effectiveDate)
    {
        this.effectiveDate = effectiveDate;
    }
    public DateTime GetEffectiveDate()
    {
        return effectiveDate;
    }
    public void SetTerminationDate(DateTime terminationDate)
    {
        this.terminationDate = terminationDate;
    }
    public DateTime GetTerminationDate()
    {
        return terminationDate;
    }
    public void SetRoomType(String roomType)
    {
        this.roomType = roomType;
    }
    public String GetRoomType()
    {
        return price;
    }
    public void SetNeighborhood(String neighborhood)
    {
        this.neighborhood = neighborhood;
    }
    public String GetNeighborhood()
    {
        return neighborhood;
    }
    public void SetDescription(String accomdDescription)
    {
        this.accomdDescription = accomdDescription;
    }
    public String GetDescription()
    {
        return accomdDescription;
    }
    public void SetExtraInfo(String extraInfo)
    {
        this.extraInfo = extraInfo;
    }
    public String GetExtraInfo()
    {
        return extraInfo;
    }
}