<%@ Page Title="" Language="C#" MasterPageFile="~/RoomMagnet.master" AutoEventWireup="true" CodeFile="HostDashboard.aspx.cs" Inherits="HostDashboard" %>

<asp:Content ID="HostDashboard" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!doctype html>
    <script type="text/javascript">
        function ShowPopup() {
            
            $("#viewReplyModal").modal("show");
        }

        
        
    </script>

    <script type="text/javascript">
        function ShowPopup2() {
            
            $("#composeMessageModal").modal("show");
        }

        
        
    </script>
   
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js" integrity="sha384-ZMP7rVo3mIykV+2+9J3UJ46jBk0WLaUAdn689aCwoqbBJiSnjAK/l8WvCWPIPm49" crossorigin="anonymous"></script>
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js" integrity="sha384-ChfqqxuZUCnJSK3+MXmPNIyE6ZbWh2IMqE241rYiqJxyMiZ6OW/JmZQ5stwEULTy" crossorigin="anonymous"></script>

    <script>
/* When the user clicks on the button, 
toggle between hiding and showing the dropdown content */
function myFunction() {
  document.getElementById("myDropdown").classList.toggle("show");
}

// Close the dropdown if the user clicks outside of it
window.onclick = function(event) {
  if (!event.target.matches('.dropbtn')) {
    var dropdowns = document.getElementsByClassName("dropdown-content");
    var i;
    for (i = 0; i < dropdowns.length; i++) {
      var openDropdown = dropdowns[i];
      if (openDropdown.classList.contains('show')) {
        openDropdown.classList.remove('show');
      }
    }
  }
}
</script>

<html lang="en">



<head>
<meta charset="UTF-8">
<meta name="description" content="Room Magnet">
<meta name="keywords" content="room magnet, roommate, housing, matchmaking, house, apartment, living arrangement">
<meta name="author" content="Room Magnet">
<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
<title>Dashboard</title>

<!-- Bootstrap v4 -->
<link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" media="screen">
<!-- custom css -->
<link href="css/custom.css" rel="stylesheet" type="text/css" media="screen">
<link rel="shortcut icon" href="images/logo-03.png" type="image/x-icon"/>
<link href="https://fonts.googleapis.com/css?family=Oswald:400|Raleway:300&display=swap" rel="stylesheet">    
<style>

  h3 {
    font-size: 24px
  }
  h5 {
    font-size: 18px;
  }

</style>
</head>

<body>
<form runat="server">     
<div id="containerDiv" class="container">

  <div class="row " style="margin-top: 7rem;">
    <div class="col-md-9">
        <h1 style="font-size: 60px"><asp:Label ID="FirstNameLastNameHeader" runat="server" Text="Host Dashboard"></asp:Label></h1><!-- += 's Dashboard -->
      </div>
    </div><!-- end div row -->  
    
   <!--Start First Module -->
   <div class="row " style="margin-top: 1rem;">
    <div class="col-md-6" style="border: solid; border-color: black; background-color: #ebebeb; border-width: 1px; border-radius: 20px;">
        <div class="row">
            <div class="col-md-6">
               <h2 >Your Property</h2>                
            </div>
            <div>
                <asp:Button ID="EditPropertyButton" runat="server" Text="EditProperty" cssclass="btn" OnClick="EditPropertyButton_Click"/>
            </div>         
            <div class ="col">
                <asp:Button ID="ListPropertyButton" runat="server" Text="List Property" CssClass="btn" OnClick ="ListPropertyButton_Clicked" AutoPostBack="true" style="margin-top: .5rem;"/>
                <asp:Button ID="UnlistPropertyButton" runat="server" Text="Unlist Property" CssClass="btn" OnClick="UnlistPropertyButton_Clicked" AutoPostBack="true" style="margin-top: .5rem;"/>
                <asp:Button ID="CreatePropertyButton" runat="server" Text="Create Property" CssClass="btn" OnClick="CreatePropertyButton_Clicked" AutoPostBack="true" style="margin-top: .5rem;"/>
            </div>
        </div> <!--end Row Class -->
        
        <div  class="row" style="background-color: #ebebeb; margin-top: 1rem; margin-bottom: 1rem; padding-bottom: 1rem;" id="propertyModule" runat="server" >
            <div class="col-md-6" style="margin-top: 1rem;">
                <asp:Image ID="HostPrimaryImage" ImageURl="images/noimageyet420.png" runat="server" CssClass="img-fluid"/>
                <div class="row" style="margin-top: 1rem;">
                    <div class="col-md-6">
                        <asp:Image ID="HostImage2" ImageURl="" runat="server" CssClass="img-fluid"/>
                    </div>
                    <div class="col-md-6">
                        <asp:Image ID="HostImage3" ImageURl="" runat="server" CssClass="img-fluid"/>
                    </div>
                </div>
            </div>
             <div class="col-md-6" style="margin-top: 1rem;" runat="server">
                 <h3><asp:Label ID="PropertyName" runat="server" Text="Example Property in Harrisonburg 22801"></asp:Label></h3>
                    <p><asp:Label ID="PropertyInfo" runat="server" Text="This is a brief description of the property"></asp:Label></p>
            </div>
        </div>
      </div>
    <!--End First Module -->   

    <!--Start Second Module -->
    <div class="col-md-6" style="border: solid; border-color: black; background-color: #ebebeb; border-width: 1px; border-radius: 20px;">
        <div class="row">
            <div class="col-md-6">
               <h2 >Your Profile</h2> 
            </div>
            <div class="col-md-6">
                <asp:Button ID="EditProfileButton" runat="server" OnClick="EditProfileBtn_Click" Text="Edit Profile" cssclass="btn" style="margin-top: .5rem;"/>
            </div>
        </div>
        
        <div class="row" style="background-color: #ebebeb; margin-top: 1rem; margin-bottom: 1rem; padding-bottom: 1rem;" >
            <div class="col-md-6" style="margin-top: 1rem;">
                <asp:Image ID="Image1" ImageURl="images/noimageyet420.png" runat="server" CssClass="img-fluid"/>
                <div class="row" style="margin-top: 1rem;">
                    <div class="col-md-6">
                        <asp:Image ID="Image2" ImageURl="" runat="server" CssClass="img-fluid"/>
                    </div>
                    <div class="col-md-6">
                        <asp:Image ID="Image3" ImageURl="" runat="server" CssClass="img-fluid"/>
                    </div>
                </div>
            </div>
             <div class="col-md-6" style="margin-top: 1rem;">
                 <h3><asp:Label ID="HostName" runat="server" Text="First Last"></asp:Label></h3>
                    <p><asp:Label ID="HostBio" runat="server" Text="This is a brief bio of the host."></asp:Label></p>
                    <p><asp:Image ID="Image4" runat="server" ImageUrl="images/non-smoker-badge.png" style="max-width: 150px; margin-top: 3px"></asp:Image></p>
                    <p><asp:Image ID="Image5" runat="server" ImageUrl="images/undergrad-badge.png" style="max-width: 150px; margin-top: 3px"></asp:Image></p>
                    <p><asp:Image ID="Image6" runat="server" ImageUrl="" style="max-width: 150px; margin-top: 3px"></asp:Image></p>
                    <p><asp:Image ID="Image7" runat="server" ImageUrl="" style="max-width: 150px; margin-top: 3px"></asp:Image></p>
                    <p><asp:Image ID="Image8" runat="server" ImageUrl="" style="max-width: 150px; margin-top: 3px"></asp:Image></p>
            </div>
        </div>
      </div> 
       <!--End Second Module -->   
             
    </div><!-- end div big row -->
    
    
     <div class="row " style="margin-top: 1rem;">
        <div class="col-md-6"  style="border: solid; border-color: black; background-color: #ebebeb; border-width: 1px; border-radius: 20px;">
            <div class="row">
              <div class="col-md-12">
                <h2 >Message Board<asp:Button ID="btnCompose" CssClass="btn float-right" runat="server" Text="Compose" OnClick="Compose_Click" style="margin-top: .5rem;"/></h2>
                
              </div>
            </div>

            <div class="row" id="messagesDashDiv" runat="server" style="background-color: #ebebeb; margin-top: 1rem; margin-bottom: 1rem;" >
                
                <!-- New message previews are populated here in the code behind -->


            </div>
            </div>
         
          
                   <!-- Modal -->
         <div class="modal fade" id="viewReplyModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true" >
             <div class="modal-dialog modal-dialog-centered" role="document">
                 <div class="modal-content">
                     <div class="modal-header">
                         <h4 class="modal-title" id="exampleModalLongTitle">Messages</h4>
                         <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                             <span aria-hidden="true">&times;</span>
                         </button>
                     </div>
                     <div class="modal-body">
                         <div class="container-fluid">
                             <div class="row">
                                 <div class="col-md-12 ml-auto" style="padding-bottom: 15px;">
                                     <div class="dropdown" id="dropdownDiv" runat="server">
                                         <asp:DropDownList ID="DropDownList1" AutoPostBack="true" runat="server" CssClass="form-control btn btn-outline-secondary">
                                             <asp:ListItem Value="0">Your Contacts</asp:ListItem>
                                         </asp:DropDownList>

                                     </div>
                                 </div>
                                 <!--end col-->
                             </div>
                             <!--end row-->
                             <div class="row">
                                 <div class="col-sm-12">
                                     <div class="row">
                                         <div class="col-sm-6" id="leftDiv" runat="server" style="border-right-style: solid; border-right-color: #D0D0D0;">
                                         </div>
                                         <div class="col-sm-6" id="rightDiv" runat="server">
                                             <h5><asp:Label ID="lblSender" runat="server"></asp:Label></h5>
                                             <h6><asp:Label ID="lblDate" runat="server"></asp:Label></h6>
                                             <p><asp:Label ID="lblMessageText" runat="server"></asp:Label></p>
                                             <p><asp:TextBox ID="txtBoxReply" runat="server" TextMode="MultiLine" style="height:200px; font-size:14pt;" ForeColor="Gray" Text="Write a reply..."></asp:TextBox></p>
                                             <!--<asp:Button ID="btnSendRepy" CssClass="btn float-right" runat="server" Text="Send" OnClick="Send_Click"/>-->
                                             
                                                 
                                         </div>
                                     </div>
                                     <!--end row-->
                                 </div>
                                 <!--end col-sm-9-->
                             </div>
                             <!--end row-->
                         </div>
                         <!--end container-fluid-->
                     </div>
                     <!--end modal-body-->
                     <div class="modal-footer">
                         <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                     </div>
                     
                 </div>
                 <!--end modal header-->
         
             </div>
             <!--end modal content-->
         </div>
         <!--end modal-dialog div-->






                          <!-- Compose message modal -->
         <div class="modal fade" id="composeMessageModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true" >
             <div class="modal-dialog modal-dialog-centered" role="document">
                 <div class="modal-content">
                     <div class="modal-header">
                         <h4 class="modal-title" id="modalTitle">Send a Message</h4>
                         <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                             <span aria-hidden="true">&times;</span>
                         </button>
                     </div>
                     <div class="modal-body">
                         <div class="container-fluid">
                             <div class="row">
                                 <div class="col-md-12 ml-auto" style="padding-bottom: 15px;">
                                     <div class="dropdown" id="Div1" runat="server">
                                         <asp:DropDownList ID="DropDownList2" AutoPostBack="true" runat="server" CssClass="form-control btn btn-outline-secondary">
                                             <asp:ListItem Value="0">Your Contacts</asp:ListItem>
                                         </asp:DropDownList>
                                         
                                             <div class="row">
                                                 <div class="col-md-12 ml-auto" style="padding-bottom: 15px;">
                                         <p><asp:TextBox ID="txtBoxMessage" runat="server" TextMode="MultiLine" style="height:200px; font-size:14pt;" ForeColor="Gray" Text="Write a reply..."></asp:TextBox></p>
                                            <asp:Button ID="btnSendNewMessage" CssClass="btn float-right" runat="server" Text="Send" OnClick="SendNewMessage_Click"/>
                                                     </div>
                                         

                                                 </div>
                                     </div>
                                 </div>

                                 <!--end col-->
                             </div>
                             <!--end row-->
                            
                         </div>
                         <!--end container-fluid-->
                     </div>
                     <!--end modal-body-->
                     <div class="modal-footer">
                         <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                     </div>
                     
                 </div>
                 <!--end modal header-->
         
             </div>
             <!--end modal content-->
         </div>
         <!--end modal-dialog div-->






         
     
        
 

        <div class="col-md-6" style="border: solid; border-color: black; background-color: #ebebeb; border-width: 1px; border-radius: 20px;" >
        <div class="row">
            <div class="col-md-12">
               <h2 >Background Check Status</h2> 
            </div>
            
        </div>
        
        <div class="row" style="background-color: #ebebeb; margin-top: 1rem; margin-bottom: 1rem; " >
            <div class="col-md-12" style="margin-top: 1rem;">
                <h3><asp:Label ID="TenantBackgroundStatusWords" runat="server" Text="Status Goes Here"></asp:Label></h3>
                <p style="text-align: center;"><asp:Image ID="TenantBackgroundStatusImage" runat="server" ImageURL="images/icons-07.png" style="max-width: 75px;"/></p>
                <p><asp:Label ID="TenantBackgroundStatusDescrip" runat="server" Text="You are a verified user! Your background check has been successful and you are cleared."></asp:Label></p>
                    
            </div>
             
        </div>
      </div>
    
    </div><!-- end div big row -->
    
<div style="border: solid; border-color: black; background-color: #ebebeb; border-width: 1px; border-radius: 20px; margin-top: 1rem; padding: 1rem; margin-bottom: 1rem;">
    <div class="row " >
        <div class="col-md-12"  >
            <h2>Your Rental Agreements</h2>
          </div>
    </div><!-- end div big row -->  
    
    <div class="row " style="margin-top: 1rem; margin-bottom: 1rem;">
        <div class="col-md-12"  style=" margin-top: 1rem;">
            <p>When you have a rental agreement, it will be indicated here. We hope you find your perfect housing match so that you can have some wonderful rental agreements.</p>
          </div>
        <!-- Below is the dropdown list for a future google translate API boiii
            <div class="col-md-6">
                <asp:DropDownList ID ="translateList" runat="server" CssClass="form-control" style="">

                </asp:DropDownList>
            </div>
            -->
    </div><!-- end div big row -->  
</div>       
    
    
</div> <!-- end div container! -->    

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
        <p><a href="#"><img src="images/social-icons-02.png" class="img-fluid" style="max-width: 180px;"></a></p>
    </div>
       
    </div>
</footer><!-- end footer! --> 
    
<!-- jQuery and Bootstrap links - do not delete! -->
<!-- jQuery first, then Popper.js, then Bootstrap JS -->

<!-- end of do not delete -->
</form>
</body>
</html>
</asp:Content>

