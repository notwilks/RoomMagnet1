using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminDashboard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //select h.firstName, h.lastName, h.email, t.firstName, t.lastName, t.email from Host h inner join Tenant t n h.lastName = t.lastName
    }

    protected void SearchButton_Click(object sender, EventArgs e)
    {

    }
}