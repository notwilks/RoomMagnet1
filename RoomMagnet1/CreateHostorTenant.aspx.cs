using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CreateHostorTenant : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void hostButton_Click(object sender, EventArgs e)
    {
        Session["userType"] = "H";
        Response.Redirect("CreateEmailandPassword.aspx", false);
    }

    protected void tenantButton_Click(object sender, EventArgs e)
    {
        Session["userType"] = "T";
        Response.Redirect("CreateEmailandPassword.aspx", false);
    }
}