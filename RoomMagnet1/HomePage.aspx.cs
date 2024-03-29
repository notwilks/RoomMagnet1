﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HomePage : System.Web.UI.Page
{
    SqlConnection sc = new SqlConnection(WebConfigurationManager.ConnectionStrings["RoomMagnetAWS"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            sc.Open();

            SqlCommand select = new SqlCommand();
            select.Connection = sc;

            select.CommandText = "Select COUNT(accommodationID) from Accommodation WHERE listed = 'T'";
            listedProperties.InnerText = HttpUtility.HtmlEncode(Convert.ToString(select.ExecuteScalar()));
        }
        catch (Exception ex)
        {

        }

        String path = Server.MapPath("Images2/");
    }

    protected void SearchButton_Click(object sender, EventArgs e)
    {
        if (CitySearchBox.Text.Length > 0)
        {
            if (CitySearchBox.Text.Contains("0") || CitySearchBox.Text.Contains("1") || CitySearchBox.Text.Contains("2") || CitySearchBox.Text.Contains("3") || CitySearchBox.Text.Contains("4")
                && CitySearchBox.Text.Contains("5") || CitySearchBox.Text.Contains("6") || CitySearchBox.Text.Contains("7") || CitySearchBox.Text.Contains("8") || CitySearchBox.Text.Contains("9")
                && CitySearchBox.Text.Contains("!") || CitySearchBox.Text.Contains("@") || CitySearchBox.Text.Contains("#") || CitySearchBox.Text.Contains("$") || CitySearchBox.Text.Contains("%")
                && CitySearchBox.Text.Contains("^") || CitySearchBox.Text.Contains("&") || CitySearchBox.Text.Contains("*") || CitySearchBox.Text.Contains("(") || CitySearchBox.Text.Contains(")")
                && CitySearchBox.Text.Contains("-") || CitySearchBox.Text.Contains("_") || CitySearchBox.Text.Contains("+") || CitySearchBox.Text.Contains("="))
            {
                Session["CitySearch"] = CitySearchBox.Text;
                Session["StateSearch"] = stateBox.SelectedValue;
                Response.Redirect("SearchResultPage.aspx");
            }
                else
                {
                    Session["CitySearch"] = CitySearchBox.Text;
                    Session["StateSearch"] = stateBox.SelectedValue;
                    Response.Redirect("SearchResultPage.aspx");
                }
            }
            else
            {
                Session["CitySearch"] = CitySearchBox.Text;
                Session["StateSearch"] = stateBox.SelectedValue;
                Response.Redirect("SearchResultPage.aspx");
            }
    }

    protected void RentMyRoomBtn_Clicked(object sender, EventArgs e)
    {
        Session["userType"] = "H";
        Response.Redirect("CreateEmailPassword.aspx");
    }

    protected void FindARoomBtn_Clicked(object sender, EventArgs e)
    {
        Session["userType"] = "T";
        Response.Redirect("CreateEmailPassword.aspx");
    }

    protected void GetStartedBtn_Clicked(object sender, EventArgs e)
    {
        Response.Redirect("CreateHostorTenant.aspx");
    }
}