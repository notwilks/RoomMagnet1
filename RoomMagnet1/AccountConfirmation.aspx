<%@ Page Title="" Language="C#" MasterPageFile="~/RoomMagnet.master" AutoEventWireup="true" CodeFile="AccountConfirmation.aspx.cs" Inherits="AccountConfirmation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id ="form1" runat="server">
    <h1>Your safety is crucial to us.</h1>
    <h3>Let us find your the perfect space.</h3>
    <p>
      In order to provide customers with the best, most secure living and housemate matching experience, we ask that the home-owners and tenants alike go 
        through a background check. This ensures a superior housemate matching process. You can read more about our background check process and standards
          on our safety page after you've completed your profile.
    </p>
    <p>
        An email with more information on the background check process will be sent to your inbox shortly. 
    </p>
    <p> 
        Other users will be able to see the state of your background check process, just as you will be able to see theirs. The following indicators will
        appear at the specified steps in the process:
    </p>
    <p>
        Green Check Mark: Approved
        Yellow Check Mark: Pending
        Blue X: Not Begun
        Red X: Not Approved
    </p>
    <div>
        <asp:Button ID="confirmBtn" Text="I understand" runat="server" OnClick="confirmBtn_Click" />
    </div>
    </form>
</asp:Content>

