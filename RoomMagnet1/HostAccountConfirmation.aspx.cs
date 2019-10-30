using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HostAccountConfirmation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void IUnderstand_Click(object sender, EventArgs e)
    {
        Response.Redirect("HostDashboard.aspx");
    }
}