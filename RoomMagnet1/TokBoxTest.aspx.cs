using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using OpenTokSDK;

public partial class TokBoxTest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Set the following constants with the API key and API secret
        int apiKey = 46464112;
        String secret = "e5f22b10715a9fda37245b80b9388714ce7d0bd1";

        // that you receive when you sign up to use the OpenTok API:
        //OpenTok opentok = new OpenTok(apiKey, secret);

        // Replace with meaningful metadata for the connection.
        //string connectionMetadata = "username=Bob,userLevel=4";

        // Generate a token. Use the Role value appropriate for the user.
        //string sessionId = opentok.CreateSession().Id;

        //string token = opentok.GenerateToken(sessionId);

        
    }
}