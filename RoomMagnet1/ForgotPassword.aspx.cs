using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Drawing;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Text;
using System.Web.Configuration;

public partial class ForgotPassword : System.Web.UI.Page
{
    SqlConnection sc = new SqlConnection(WebConfigurationManager.ConnectionStrings["RoomMagnetAWS"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void GetPass_Click(object sender, EventArgs e)
    {
        
        //Open database and check for corresponding email      
        sc.Open();
        System.Data.SqlClient.SqlCommand checkDb = new System.Data.SqlClient.SqlCommand();
        checkDb.Connection = sc;
        checkDb.CommandText = "Select [email] from [Passwords] Where [email] = @email";
        checkDb.Parameters.Add(new SqlParameter("@email", HttpUtility.HtmlEncode(emailField.Text)));

        //If email found, load pass and email int
        SqlDataReader reader = checkDb.ExecuteReader();
        if (reader.HasRows)
        {
            string tempEmail = "";
            while (reader.Read())
            {
                tempEmail = reader["email"].ToString();
            }
            sc.Close();

            //Create new smtp connection to our roommagnet gmail account
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                UseDefaultCredentials = false,
                Credentials = new System.Net.NetworkCredential("roommagnetjmu@gmail.com", "Fucktits1!"),
                EnableSsl = true,
                Timeout = 20000,
                DeliveryMethod = SmtpDeliveryMethod.Network,

            };

            //assign sender and reciever variables
            var from = new MailAddress("roommagnetjmu@gmail.com");
            var to = new MailAddress(tempEmail);

            //Create url with token
            string token = Guid.NewGuid().ToString();

            //create email message
            string subject = "RoomMagnet: Reset Password Link";
            StringBuilder body = new StringBuilder();
            body.Append("<a href=http://roommagnet1test.us-east-2.elasticbeanstalk.com/ResetPassword.aspx?email=" + HttpUtility.HtmlEncode(emailField.Text) + "&code=" + token + ">Change Password</a>");
            using (var message = new MailMessage(from, to)
            {
                Subject = subject,
                Body = body.ToString(),
                IsBodyHtml = true
            })
            {
                smtp.Send(message);
            }
            //
            sc.Open();
            checkDb.CommandText = "UPDATE [dbo].[passwords] SET [resetCode]=@code where [email] = @emailID";
            checkDb.Parameters.Add(new SqlParameter("@code", token));
            checkDb.Parameters.Add(new SqlParameter("@emailID", HttpUtility.HtmlEncode(emailField.Text)));
            checkDb.ExecuteNonQuery();
            sc.Close();
            outputField.Text = "Success, A link to reset password has been sent to " + emailField.Text + ".";
        }
        else
        {
            outputField.Text = "Error, Email not found.";
        }       
    }
}