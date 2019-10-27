using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// John Gregory, Nick Garcia, Nick Landau, Wyatt Wilkinson, Matt Crump
public class Search
{
    int searchID;
    int tenantID;
    int accommodationID;
    DateTime searchDate;
    String searchText;

    public Search()
    {
        searchID = 0;
        tenantID = 0;
        accommodationID = 0;
        searchDate = DateTime.Now;
        searchText = "";
    }


    public Search (int searchID, int tenantID, int accommodationID, DateTime searchDate, String searchText)
    {
        this.searchID = searchID;
        this.tenantID = tenantID;
        this.accommodationID = accommodationID;
        this.searchDate = searchDate;
        this.searchText = searchText;
    }

    // ALL GETTORS

    public int GetSearchID ()
    {
        return this.searchID;
    }

    public int GetTenantID()
    {
        return this.tenantID;
    }

    public int GetAccommodationID()
    {
        return this.accommodationID;
    }

    public DateTime GetSearchDate()
    {
        return this.searchDate;
    }

    public String GetSearchText()
    {
        return this.searchText;
    }

    // ALL SETTORS

    public void SetSearchID(int sID)
    {
        this.searchID = sID;
    }

    public void SetTenantID(int tID)
    {
        this.tenantID = tID;
    }

    public void SetAccommodationID(int aID)
    {
        this.accommodationID = aID;
    }

    public void SetSearchDate(DateTime sDate)
    {
        this.searchDate = sDate;
    }

    public void SetSearchText(String sText)
    {
        this.searchText = sText;
    }

}