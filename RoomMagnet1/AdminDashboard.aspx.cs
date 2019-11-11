using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class AdminDashboard : System.Web.UI.Page
{
    SqlConnection sc = new SqlConnection(WebConfigurationManager.ConnectionStrings["RoomMagnetAWS"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        approveButton.Visible = false;
        if (IsPostBack)
        {
            
            SearchButton_Click(sender, e);
        }
    }

    protected void SearchButton_Click(object sender, EventArgs e)
    {
        Session["userLast"] = lastNameSearchBox.Text;
        sc.Open();

        SqlCommand select = new SqlCommand();
        select.Connection = sc;

        select.CommandText = "select hostID, (lastName + ', ' + firstName) AS 'Host Accounts', email, cleared from Host where lastName = @lastName";
        select.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lastName", Session["userLast"]));

        SqlDataReader reader = select.ExecuteReader();

        while (reader.Read())
        {
            //row div creation for hosts
            var div1 = new HtmlGenericControl("div")
            {

            };

            HostResults.Controls.Add(div1);
            div1.Style.Add("margin-top", "1rem;");
            div1.Style.Add("border-bottom", "solid;");
            div1.Style.Add("border-bottom-width", "1px;");
            div1.Attributes.Add("class", "row");

            //Name div
            var leftDiv = new HtmlGenericControl("div")
            {

            };

            div1.Controls.Add(leftDiv);
            leftDiv.Attributes.Add("class", "col-md-4");

            //email div
            var emailDiv = new HtmlGenericControl("div")
            {

            };

            div1.Controls.Add(emailDiv);
            emailDiv.Attributes.Add("class", "col-md-4");

            //buttons div
            var butDiv = new HtmlGenericControl("div")
            {

            };

            div1.Controls.Add(butDiv);
            butDiv.Attributes.Add("class", "col-md-4");

            //host last and first name
            String hostLF = reader.GetString(1);
            var hostName = new HtmlGenericControl("p")
            {
                InnerText = hostLF
            };

            leftDiv.Controls.Add(hostName);

            //host email
            String hostE = reader.GetString(2);
            var hostEmail = new HtmlGenericControl("p")
            {
                InnerText = hostE
            };

            emailDiv.Controls.Add(hostEmail);

            Button clear = new Button();
            clear.ID = Convert.ToString(reader.GetInt32(0));
            //if (reader.GetString(3) == "T")
            //{
                clear.Text = "Approve";
                clear.Attributes.Add("class", "btn btn-success");
            //}
            //else
            //{
            //    clear.Text = "Un-Approve";
            //    clear.Attributes.Add("class", "btn btn-danger");
            //}
            
            clear.Style.Add("margin-bottom", "1rem;");
            clear.Attributes.Add("runat", "server");
            //clear.Attributes.Add("OnClick", "approveHost");
            //clear.Click += approveButton_Click;
            clear.Click += new EventHandler(approveButton_Click);
            butDiv.Controls.Add(clear);
            
        }
        
        sc.Close();
    }

    protected void clear_Click(object sender, EventArgs e)
    {

        //Button b = sender as Button;
        //SqlCommand clear = new SqlCommand();
        //clear.Connection = sc;

        //clear.CommandText = "Update Host SET cleared = 'T' where hostID = " + b.ID;

        Response.Redirect("HomePage.aspx");
    }

    protected void approveButton_Click(object sender, EventArgs e)
    {
        sc.Open();
        Button b = sender as Button;
        SqlCommand clear = new SqlCommand();
        clear.Connection = sc;

        clear.CommandText = "Update Host SET cleared = 'T' where hostID = " + b.ID;
        clear.ExecuteNonQuery();
        //Response.Redirect("HomePage.aspx");
        sc.Close();
    }
}