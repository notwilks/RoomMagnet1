<%@ Page Title="" Language="C#" MasterPageFile="~/RoomMagnet.master" AutoEventWireup="true" CodeFile="MessageCenter.aspx.cs" Inherits="MessageCenter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!DOCTYPE html>

<html>

    <title>RoomMagnet - Create Account</title>
<body>
    
<div class="container">
<form id="form1" runat="server">
      
    <section id="creation">
      <div class="container">
        <form>
            <div class="row">
                    <div class="col promar" >
                       <asp:Label ID="Label1" runat="server" Text="Enter a message"></asp:Label>
                        </div>
                    </div><!--end col-->
               </div><!--end row class-->

          <div class="row" style="margin-top: 10rem;">
            <div class="col align-content-center">
                <asp:TextBox ID="txtBoxMessage" runat="server" Text="Message Text"></asp:TextBox>
                <asp:TextBox ID="txtBoxSubject" runat="server" Text="Subject"></asp:TextBox>
                <asp:Button ID="btnSendMessage" runat="server" Text="Send Message" OnClick="btnSendMessage_click" />
                <asp:DropDownList ID="dropdownContacts" runat="server" Width="200px">
                    <asp:ListItem Text="Choose someone to contact" Selected="true"></asp:ListItem>
                </asp:DropDownList>
                <br />
                <div  class="row" style="background-color: #ebebeb; margin-top: 1rem; margin-bottom: 1rem; padding-bottom: 1rem;" id="mesagesModule" runat="server" >
                    <div class="col" id="messages" runat="server">
                        <h3 style="border-bottom:solid; margin-bottom: 2rem">Your New Messages</h3>
                        <asp:Button ID="approveButton" runat="server" Text="Button" OnClick="approveButton_Click"/>
                        <div  class="row" >
                            <div class="col-md-4">
                                <h5>From</h5>
                            </div>
                            <div class="col-md-4">
                                <h5>Subject</h5>
                            </div>
                            <div class="col-md-4">
                                <h5>Action</h5>
                            </div>
                        </div>
                    </div> <!-- end col class-->

                    
                </div> 


                <asp:SqlDataSource ID="messagesDataSource" runat="server"></asp:SqlDataSource>


            </div>
            
          </div> <!--end row class-->
          
          <div class="row">
            <div class="col">
                
            </div>

            <div class="col">
              
            </div> <!--end col-->
          </div> <!--end row class-->

          <div class="row">
            <div class="col">
              
            </div>
            <div class="col">
              
            </div> <!--end col-->
          </div> <!--end row class-->
        </form> <!--end form-->
        <br>
        
        <div class="row" style="margin-bottom: 3rem;"> 
          <div class="col-md-6"></div>
            
             <div class="col-md-6">
                 
               
      </div> <!--end container-->
    </section>
</form>
</div>
    <footer class="footer mt-auto py-3 footer-expand-lg"><!-- start footer! -->
   <div class="row" style="padding-left: 3rem;">
    <div class="col-md-4" style="padding-left: 3rem;">   
    <h3 class="din">Room Magnet</h3>
    <p>Support:<br>
    540-123-4567<br>
    <a href="mailto:help@roommagnet.com">help@roommagnet.com</a></p>
    </div>
       
    <div class="col-md-4" style="padding-left: 3rem;">   
    <h4 class="din">Site Map</h4>
        <p><a href="#">Home-Owners</a><br>
        <a href="#">Tenants</a><br>
        <a href="#">Safety</a><br>
        <a href="#">FAQ</a><br>
        <a href="#">Contact Us</a>
    </p>
    </div>
    
    <div class="col-md-4" style="padding-left: 3rem;">   
    <h4 class="din">Stay Connected</h4>
    <p>
    <a href="#"><img src="images/social-icons-02.png" class="img-fluid" style="max-width: 180px;"></a></p>
    </div>
       
    </div>
</footer><!-- end footer! -->
</body>
</html> 
</asp:Content>

