using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HomePage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //I really hope this works
        //
    }

    protected void SearchButton_Click(object sender, EventArgs e)
    {
        if (CitySearchBox.Text.Length > 0)
        {
            Session["CitySearch"] = CitySearchBox.Text;
            Session["StateSearch"] = stateBox.SelectedValue;
            Response.Redirect("SearchResultPage.aspx");
        }
        else
        {
            Session["StateSearch"] = stateBox.SelectedValue;
            Response.Redirect("SearchResultPage.aspx");
        }
    }
}