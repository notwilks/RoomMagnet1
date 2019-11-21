using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IntentToLease : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var dateAndTime = DateTime.Now;
        var date = dateAndTime.Date;
        DateBox.Text = Convert.ToString(DateTime.Now.ToString("dd/MM/yyyy"));

        tenantName.Text = Convert.ToString(Session["tenantLease"]);

        if(Convert.ToString(Session["tenantCleared"]) == "T")
        {
            tenantYes.Checked = true;
        }
        else
        {
            tenantNo.Checked = true;
        }
    }
}