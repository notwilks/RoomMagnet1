using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using Google.Cloud.Translation.V2;
using System.Web.UI.HtmlControls;
using System.Data;

public partial class HostMessageCenter : System.Web.UI.Page
{
    SqlConnection sc = new SqlConnection(WebConfigurationManager.ConnectionStrings["RoomMagnetAWS"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void Send_Click(object sender, EventArgs e)
    {
        Button sendBtn = (Button)sender;
        String mID = Convert.ToString(sendBtn.ID);

        // Get TenantID based on messageID passed from send button
        SqlCommand selectTenant = new SqlCommand("SELECT TenantID FROM MessgeCenter WHERE MessageID = @msgID", sc);
        selectTenant.Parameters.AddWithValue("@msgID", mID);

        String tID = Convert.ToString(sendBtn.ID);

        SqlCommand sendMessage = new SqlCommand("INSERT INTO MessageCenter(hostID, tenantID, messageText, dateSent, sender) VALUES(@hostID2, @tenantID2, @msg2, @date2, @sender2)", sc);
        sendMessage.Parameters.AddWithValue("@hostID2", Convert.ToString(ViewState["hostID"]));
        sendMessage.Parameters.AddWithValue("@tenantID2", tID);
        sendMessage.Parameters.AddWithValue("@msg2", txtBoxReply.Text);
        sendMessage.Parameters.AddWithValue("@date2", DateTime.Now.ToLongDateString());
        sendMessage.Parameters.AddWithValue("@sender2", "H");
        sc.Open();
        sendMessage.ExecuteNonQuery();
        sc.Close();



    }

}