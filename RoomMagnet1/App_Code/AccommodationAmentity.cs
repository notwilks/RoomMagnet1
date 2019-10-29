using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AccommodationAmentity
/// </summary>
public class AccommodationAmentity
{
    private int accommodationID;
    private String bathroom;
    private String entrance;
    private String storage;
    private String furnished;
    private String smoker;
    private String pets;

    public AccommodationAmentity()
    {
        SetAccommodationID(accommodationID);
        SetBathroom(bathroom);
        SetEntrance(entrance);
        SetStorage(storage);
        SetFurnished(furnished);
        SetSmoker(smoker);
        SetPets(pets);
    }

    public AccommodationAmentity(int accommodationID, String bathroom, String entrance, String storage, String furnished, String smoker, String pets)
    {
        SetAccommodationID(accommodationID);
        SetBathroom(bathroom);
        SetEntrance(entrance);
        SetStorage(storage);
        SetFurnished(furnished);
        SetSmoker(smoker);
        SetPets(pets);
    }

    // ALL SETTORS 
    public void SetAccommodationID(int accommodationID)
    {
        this.accommodationID = accommodationID;
    }

    public void SetBathroom(String bathroom)
    {
        this.bathroom = bathroom;
    }

    public void SetEntrance(String entrance)
    {
        this.entrance = entrance;
    }

    public void SetStorage(String storage)
    {
        this.storage = storage;
    }

    public void SetFurnished(String furnished)
    {
        this.furnished = furnished;
    }

    public void SetSmoker(String smoker)
    {
        this.smoker = smoker;
    }

    public void SetPets(String pets)
    {
        this.pets = pets;
    }

    // ALL GETTORS
    public int GetAccommodationID()
    {
        return accommodationID;
    }

    public String GetBathroom()
    {
        return bathroom;
    }

    public String GetEntrance()
    {
        return entrance;
    }

    public String GetStorage()
    {
        return storage;
    }

    public String GetFurnished()
    {
        return furnished;
    }

    public String GetSmoker()
    {
        return smoker;
    }

    public String GetPets()
    {
        return pets;
    }
}