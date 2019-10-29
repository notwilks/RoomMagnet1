using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class EditAccountInformation : System.Web.UI.Page
{
    SqlConnection sc = new SqlConnection(WebConfigurationManager.ConnectionStrings["RoomMagnetAWS"].ConnectionString);
    string table;
    protected void Page_Load(object sender, EventArgs e)
    {
        //Grab userType to ensure the db query is selecting/updating the proper table.
        if (Convert.ToString(Session["userType"]).Equals("T"))
            table = "[dbo].[Tenant]";
        else
            table = "[dbo].[Host]";

        if (!IsPostBack)
        {
            //Using Session["userEmail"], load user information into the datafields. 
            sc.Open();
            SqlCommand load = new SqlCommand();
            load.Connection = sc;

            load.CommandText = "select firstName, lastName, phoneNumber, birthDate, gender from " + table + " where email = @email";
            load.Parameters.Add(new SqlParameter("@email", Convert.ToString(Session["userEmail"])));

            using (SqlDataReader reader = load.ExecuteReader())
            {
                if (reader.Read())
                {
                    FirstNameBox.Text = Convert.ToString(reader["firstName"]);
                    LastNameBox.Text = Convert.ToString(reader["lastName"]);
                    phoneNumberBox.Text = Convert.ToString(reader["phoneNumber"]);
                    dobBox.Text = Convert.ToDateTime(reader["birthDate"]).ToString("MM/dd/yyyy");
                    DropDownList1.SelectedItem.Value = Convert.ToString(reader["gender"]);

                }
            }
            sc.Close();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //Setup command/connnection with db.
        sc.Open();
        SqlCommand update = new SqlCommand();
        update.Connection = sc;

        //Create and execute query
        update.CommandText = "UPDATE " + table + " SET firstName = @f, lastName = @l, phoneNumber = @phone, birthDate = @bday, gender = @sex, lastUpdated = @lU, lastUpdatedBy = @lUB WHERE email = @email";
        update.Parameters.Add(new SqlParameter("@f", HttpUtility.HtmlEncode(FirstNameBox.Text)));
        update.Parameters.Add(new SqlParameter("@l", HttpUtility.HtmlEncode(LastNameBox.Text)));
        if (phoneNumberBox.Text.Length == 0)
        {
            update.Parameters.Add(new SqlParameter("@phone", DBNull.Value));
        }
        else
        {
            update.Parameters.Add(new SqlParameter("@phone", HttpUtility.HtmlEncode(phoneNumberBox.Text)));
            
        }
        update.Parameters.Add(new SqlParameter("@bday", HttpUtility.HtmlEncode(dobBox.Text)));
        update.Parameters.Add(new SqlParameter("@sex", DropDownList1.SelectedItem.Value));
        update.Parameters.Add(new SqlParameter("@email", Session["userEmail"]));
        update.Parameters.Add(new SqlParameter("@lUB", Environment.UserName));
        update.Parameters.Add(new SqlParameter("@lU", DateTime.Now));

        update.ExecuteNonQuery();
        sc.Close();

       //clear data fields after update
        FirstNameBox.Text = "";
        LastNameBox.Text = "";
        phoneNumberBox.Text = "";
        dobBox.Text = "";
    }
}