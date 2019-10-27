using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class ResetPassword : System.Web.UI.Page
{
    SqlConnection sc = new SqlConnection(WebConfigurationManager.ConnectionStrings["RoomMagnetAWS"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var url = System.Web.HttpUtility.ParseQueryString(HttpContext.Current.Request.Url.Query);
            Session["codeURL"] = url["code"];
            Session["emailURL"] = url["email"];
        }
    }

    protected void changePassBtn_Click(object sender, EventArgs e)
    {

        if (HttpUtility.HtmlEncode(newPassField.Text) == HttpUtility.HtmlEncode(confirmPassField.Text))
        {
            //Open up database and grab the corresponding code based on the email in the database  
            sc.Open();
            System.Data.SqlClient.SqlCommand grabCode = new System.Data.SqlClient.SqlCommand();
            grabCode.Connection = sc;
            grabCode.CommandText = "select resetCode from passwords where email = @emailURL";
            grabCode.Parameters.Add(new SqlParameter("@emailURL", Session["emailURL"].ToString()));
            string checkCode = Convert.ToString(grabCode.ExecuteScalar());
            sc.Close();

            //if statement to check that code in url matches most recent resetCode updated in the database. 
            //If so, perform password update and remove code from db so it can be used only once. 
            if (checkCode.Equals(Session["codeURL"]))
            {
                string hashPass = PasswordHash.HashPassword(HttpUtility.HtmlEncode(confirmPassField.Text));

                sc.Open();
                System.Data.SqlClient.SqlCommand insert = new System.Data.SqlClient.SqlCommand();
                insert.Connection = sc;
                insert.CommandText = "UPDATE [dbo].[passwords] SET [password]=@pass,[resetCode]=@emptyCode WHERE [email]=@email;";
                insert.Parameters.Add(new SqlParameter("@pass", hashPass));
                insert.Parameters.Add(new SqlParameter("@email", Session["emailURL"].ToString()));
                insert.Parameters.Add(new SqlParameter("@emptyCode", DBNull.Value));
                insert.ExecuteNonQuery();


                //Lastly, notify user of successful password change
                outputField.Text = "Password Successfully Changed, You will be redirected back to the login page shortly.";

                //redirect back to login page after 5 seconds YAH YEET

                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "redirectJS",
                    "setTimeout(function() { window.location.replace('LoginPage.aspx') }, 5000);", true);
            }
            //If not, provide notification that password reset link is no longer valid. 
            else
            {
                outputField.Text = "Error, Password Reset Link No Longer Valid.";
            }
            
        }
        else
        {
            outputField.Text = "Error, Passwords did not match.";
        }
    }
}