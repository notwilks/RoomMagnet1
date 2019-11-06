using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Text;

public partial class HostAccountConfirmation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void IUnderstand_Click(object sender, EventArgs e)
    {
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
        var to = new MailAddress(Convert.ToString(Session["userEmail"]));

        //Create url with token
        string token = Guid.NewGuid().ToString();

        //create email message
        string subject = "RoomMagnet Newly Created Account";
        StringBuilder body = new StringBuilder();

        //Body of the email, needs to be an HTML email that looks nice. 
        body.Append("This is a sample email");
        using (var message = new MailMessage(from, to)
        {
            Subject = subject,
            Body = body.ToString(),
            IsBodyHtml = true
        })
        {
            //Commented Out because we don't need to be spamming empty emails to fake email accounts while testing smtp.Send(message);
        }


        Response.Redirect("HostDashboard.aspx");
    }
}