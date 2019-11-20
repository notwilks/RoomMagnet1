using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.IO;

public partial class EditAccountInformation : System.Web.UI.Page
{
    SqlConnection sc = new SqlConnection(WebConfigurationManager.ConnectionStrings["RoomMagnetAWS"].ConnectionString);
    string table;
    String imageTable;
    String userTypeID;
    protected void Page_Load(object sender, EventArgs e)
    {
        //Grab userType to ensure the db query is selecting/updating the proper table.
        if (Convert.ToString(Session["userType"]).Equals("T"))
        {
            table = "[dbo].[Tenant]";
            imageTable = "TenantImages";
            userTypeID = "tenantID";
        }
        else
        {
            table = "[dbo].[Host]";
            imageTable = "HostImages";
            userTypeID = "hostID";
        }

        if (!IsPostBack)
        {
            //Using Session["userEmail"], load user information into the datafields. 
            sc.Open();
            SqlCommand load = new SqlCommand();
            load.Connection = sc;

            load.CommandText = "select firstName, lastName, phoneNumber, birthDate, gender, biography from " + table + " where email = @email";
            load.Parameters.Add(new SqlParameter("@email", Convert.ToString(Session["userEmail"])));
            string tempGender = "";
            using (SqlDataReader reader = load.ExecuteReader())
            {
                if (reader.Read())
                {
                    FirstNameBox.Text = HttpUtility.HtmlEncode(Convert.ToString(reader["firstName"]));
                    LastNameBox.Text = HttpUtility.HtmlEncode(Convert.ToString(reader["lastName"]));
                    phoneNumberBox.Text = HttpUtility.HtmlEncode(Convert.ToString(reader["phoneNumber"]));
                    dobBox.Text = HttpUtility.HtmlEncode(Convert.ToDateTime(reader["birthDate"]).ToString("MM/dd/yyyy"));
                    tempGender = HttpUtility.HtmlEncode(Convert.ToString(reader["gender"]));
                    BioBox.Text = HttpUtility.HtmlEncode(Convert.ToString(reader["biography"]));

                }

                if(tempGender.Equals("F") || tempGender.Equals("M"))
                {
                    DropDownList1.SelectedValue = tempGender;
                }else if (tempGender.Equals(""))
                {
                    DropDownList1.SelectedValue = "";
                }
                else
                {
                    DropDownList1.SelectedValue = "O";
                    OtherGenderLbl.Visible = true;
                    OtherGenderBox.Visible = true;
                    OtherGenderBox.Text = "Need Other Gender Col in DB";
                }
            }
            sc.Close();

            sc.Open();

            load.CommandText = "Select " + userTypeID + " from " + table + " where email = @userEmaill";
            load.Parameters.Add(new SqlParameter("@userEmaill", Convert.ToString(Session["userEmail"])));

            int userID = Convert.ToInt32(load.ExecuteScalar());

            load.CommandText = "Select ISNULL(mainImage, '') from " + imageTable + " where " + userTypeID + " = " + userID;
            ProfilePic.ImageUrl = Convert.ToString(load.ExecuteScalar());
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //Setup command/connnection with db.
        sc.Open();
        SqlCommand update = new SqlCommand();
        update.Connection = sc;

        //inserting images to profile
        String path = Server.MapPath("Images2/");
        SqlCommand updateImages = new SqlCommand();
        updateImages.Connection = sc;

        updateImages.CommandText = "Select " + userTypeID + " from " + table + " where email = @userEmail";
        updateImages.Parameters.Add(new SqlParameter("@userEmail", Convert.ToString(Session["userEmail"])));

        int userID = Convert.ToInt32(updateImages.ExecuteScalar());

        if (mainImage.HasFile)
        {
            String ext = Path.GetExtension(mainImage.FileName);

            if (ext == ".jpg" || ext == ".png" || ext == ".jpeg")
            {
                mainImage.SaveAs(path + userID + mainImage.FileName);

                String name = "Images2/" + userID + mainImage.FileName;


                    updateImages.CommandText = "update " + imageTable + " set mainImage = @image where " + userTypeID + " = " + userID;
                    updateImages.Parameters.Add(new SqlParameter("@image", name));

                    updateImages.ExecuteNonQuery();
            }
        }

        if (image2.HasFile)
        {
            String ext = Path.GetExtension(image2.FileName);

            if (ext == ".jpg" || ext == ".png" || ext == ".jpeg")
            {
                image2.SaveAs(path + userID + image2.FileName);

                String name = "Images2/" + userID + image2.FileName;

                updateImages.CommandText = "update " + imageTable + " set image2 = @image2 where " + userTypeID + " = " + userID;
                updateImages.Parameters.Add(new SqlParameter("@image2", name));

                updateImages.ExecuteNonQuery();
            }
        }

        if (image3.HasFile)
        {
            String ext = Path.GetExtension(image3.FileName);

            if (ext == ".jpg" || ext == ".png" || ext == ".jpeg")
            {
                image3.SaveAs(path + userID + image3.FileName);

                String name = "Images2/" + userID + image3.FileName;

                updateImages.CommandText = "update " + imageTable + " set image3 = @image3 where " + userTypeID + " = " + userID;
                updateImages.Parameters.Add(new SqlParameter("@image3", name));

                updateImages.ExecuteNonQuery();
            }
        }

        //Create and execute query
        update.CommandText = "UPDATE " + table + " SET firstName = @f, lastName = @l, phoneNumber = @phone, birthDate = @bday, gender = @sex, lastUpdated = @lU, lastUpdatedBy = @lUB, biography = @bio WHERE email = @email";
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
        update.Parameters.Add(new SqlParameter("@bio", BioBox.Text));

        update.ExecuteNonQuery();
        sc.Close();

       //clear data fields after update
        FirstNameBox.Text = "";
        LastNameBox.Text = "";
        phoneNumberBox.Text = "";
        dobBox.Text = "";

        if (Session["userType"].Equals("T"))
        {
            Response.Redirect("TenantDashboard.aspx");
        }else if (Session["userType"].Equals("H")) {
            Response.Redirect("HostDashboard.aspx");
        }
             
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedItem.Value.Equals("O"))
        {
            OtherGenderLbl.Visible = true;
            OtherGenderBox.Visible = true;
        }
        else
        {
            OtherGenderLbl.Visible = false;
            OtherGenderBox.Visible = false;
        }
    }
}