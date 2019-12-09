using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LogoutPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["userType"]) == "" || Convert.ToString(Session["userEmail"]) == "")
        {
            Response.Redirect("HomePage.aspx");
        }
        else
        {

        }
    }

    protected void YesButton_Click(object sender, EventArgs e)
    {
        Session["userEmail"] = "";
        Session["userType"] = "";
        Response.Redirect("HomePage.aspx");
    }

    protected void NoButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("HomePage.aspx");
    }
}