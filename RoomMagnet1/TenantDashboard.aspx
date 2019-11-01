<%@ Page Title="" Language="C#" MasterPageFile="~/RoomMagnet.master" AutoEventWireup="true" CodeFile="TenantDashboard.aspx.cs" Inherits="TenantDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!doctype html>
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
</head>

<body>
<form runat="server">     
<div  class="container">

  <div class="row " style="margin-top: 7rem;">
    <div class="col-md-9">
        <h1><asp:Label ID="FirstNameLastNameHeader" runat="server"></asp:Label></h1><!-- += 's Dashboard -->
      </div>
    <div class="col-md-3">
        <asp:Button ID="SearchProperties" runat="server" Text="Search Properties" cssclass="btn" OnClick="SearchProperties_Click"/>
      </div>
    </div><!-- end div row -->  
    
    
   <div class="row " style="margin-top: 1rem;">
    <div class="col-md-6" style="border: solid; border-color: white;">
        <div class="row">
            <div class="col-md-6">
               <h2 >Your Profile</h2> 
            </div>
            <div class="col-md-6">
                <asp:Button ID="EditProfileBtn" runat="server" OnClick="EditProfileBtn_Click" Text="Edit Profile" cssclass="btn"/>
            </div>
        </div>
        
        <div class="row" style="background-color: #ebebeb; margin-top: 1rem; margin-bottom: 1rem; padding-bottom: 1rem;" >
            <div class="col-md-6" style="margin-top: 1rem;">
                <asp:Image ID="TenantPrimaryImage" ImageURl="images/johnsmith1.jpeg" runat="server" CssClass="img-fluid"/>
                <div class="row" style="margin-top: 1rem;">
                    <div class="col-md-6">
                        <asp:Image ID="TenantImage2" ImageURl="images/johnsmith2.jpeg" runat="server" CssClass="img-fluid"/>
                    </div>
                    <div class="col-md-6">
                        <asp:Image ID="TenantImage3" ImageURl="images/johnsmith3.jpeg" runat="server" CssClass="img-fluid"/>
                    </div>
                </div>
            </div>
             <div ID="BadgeDiv" class="col-md-6" style="margin-top: 1rem;">
                 <h3><asp:Label ID="FirstNameLastNameAge" runat="server" Text="First Last"></asp:Label></h3>
                    <p><asp:Label ID="BioLabel" runat="server" Text="This is a brief bio of the tenant."></asp:Label></p>
                    <p><asp:Image ID="Badge1" runat="server" ImageUrl="images/non-smoker-badge.png" style="max-width: 150px; margin-top: 3px"></asp:Image></p>
                    <p><asp:Image ID="Badge2" runat="server" ImageUrl="images/undergrad-badge.png" style="max-width: 150px; margin-top: 3px"></asp:Image></p>
                    <p><asp:Image ID="Badge3" runat="server" ImageUrl="" style="max-width: 150px; margin-top: 3px"></asp:Image></p>
                    <p><asp:Image ID="Badge4" runat="server" ImageUrl="" style="max-width: 150px; margin-top: 3px"></asp:Image></p>
                    <p><asp:Image ID="Badge5" runat="server" ImageUrl="" style="max-width: 150px; margin-top: 3px"></asp:Image></p>
            </div>
        </div>
      </div>
       
       
       <div class="col-md-6" style="border: solid; border-color: white; ">
        <div class="row">
            <h2 >Your Favorites</h2>
        </div>
           
        <div class="row" style="background-color: #ebebeb; margin-top: 1rem; border-bottom: solid; border-bottom-width: 1px;" >
            <div class="col-md-6" style="margin-top: 1rem;">
                <h3><asp:Label ID="HostName1" runat="server" Text="Host Name"></asp:Label></h3>
                <h5><asp:Label ID="PropertyName1" runat="server" Text="1 Room with Private Bath in Harrisonburg, VA"></asp:Label></h5>
            </div>
             <div class="col-md-6" style="margin-top: 1rem;">
                <asp:Image ID="HostBackgroundStatus1" ImageURl="images/icons-07.png" runat="server" style="max-width: 50px;"/>
                 <asp:Button ID="ViewProperty1" runat="server" Text="View Property" style="margin-left: 1rem;" CssClass="btn"/>
            </div>
        </div>
        <div class="row" style="background-color: #ebebeb; solid; border-bottom: solid; border-bottom-width: 1px" >
            <div class="col-md-6" style="margin-top: 1rem;">
                <h3><asp:Label ID="HostName2" runat="server" Text="Host Name"></asp:Label></h3>
                <h5><asp:Label ID="PropertyName2" runat="server" Text="1 Room with Private Bath in Harrisonburg, VA"></asp:Label></h5>
            </div>
             <div class="col-md-6" style="margin-top: 1rem;">
                <asp:Image ID="HostBackgroundStatus2" ImageURl="images/icons-07.png" runat="server" style="max-width: 50px;"/>
                <asp:Button ID="ViewProperty2" runat="server" Text="View Property" style="margin-left: 1rem;" CssClass="btn"/>
            </div>
        </div> 
        <div class="row" style="background-color: #ebebeb; solid; border-bottom: solid; border-bottom-width: 1px" >
            <div class="col-md-6" style="margin-top: 1rem;">
                <h3><asp:Label ID="HostName3" runat="server" Text="Host Name"></asp:Label></h3>
                <h5><asp:Label ID="PropertyName3" runat="server" Text="1 Room with Private Bath in Harrisonburg, VA"></asp:Label></h5>
            </div>
             <div class="col-md-6" style="margin-top: 1rem;">
                <asp:Image ID="HostBackgroundStatus3" ImageURl="images/icons-07.png" runat="server" style="max-width: 50px;"/>
                <asp:Button ID="ViewProperty3" runat="server" Text="View Property" style="margin-left: 1rem;" CssClass="btn"/>
            </div>
        </div>  
        
           <div class="row" style="background-color: #ebebeb; solid; border-bottom: solid; border-bottom-width: 1px" >
            <div class="col-md-6" style="margin-top: 1rem;">
                <h3><asp:Label ID="HostName4" runat="server" Text="Host Name"></asp:Label></h3>
                <h5><asp:Label ID="PropertyName4" runat="server" Text="1 Room with Private Bath in Harrisonburg, VA"></asp:Label></h5>
            </div>
             <div class="col-md-6" style="margin-top: 1rem;">
                <asp:Image ID="HostBackgroundStatus4" ImageURl="images/icons-07.png" runat="server" style="max-width: 50px;"/>
                <asp:Button ID="ViewProperty4" runat="server" Text="View Property" style="margin-left: 1rem;" CssClass="btn"/>
            </div>
        </div>  
        
      </div>      
    
    </div><!-- end div big row -->
    
    
     <div class="row " style="margin-top: 1rem;">
        <div class="col-md-6"  style="border: solid; border-color: white;">
            <div class="row">
                <div class="col-md-12">
                   <h2 >Message Board</h2> 
                </div>

            </div>

            <div class="row" style="background-color: #ebebeb; margin-top: 1rem; margin-bottom: 1rem;" >
                <div class="col-md-12" style="margin-top: 1rem; border-bottom: solid; border-bottom-width: 1px;">
                   <h3>New Message Sender Name</h3>
                    <p>Content of the message. Do you want to live at my house? I want to video chat with you first. When are you free to talk?</p>
                </div>
                 <div class="col-md-12" style="margin-top: 1rem; border-bottom: solid; border-bottom-width: 1px;">
                   <h3>New Message Sender Name</h3>
                    <p>Content of the message. Do you want to live at my house? I want to video chat with you first. When are you free to talk?</p>
                </div>
            </div>
          </div>


        <div class="col-md-6" style="border: solid; border-color: white;" >
        <div class="row">
            <div class="col-md-12">
               <h2 >Background Check Status</h2> 
            </div>
            
        </div>
        
        <div class="row" style="background-color: #ebebeb; margin-top: 1rem; margin-bottom: 1rem; " >
            <div class="col-md-12" style="margin-top: 1rem; border-bottom: solid; border-bottom-width: 1px;">
                <h3><asp:Label ID="TenantBackgroundStatusWords" runat="server" Text="Status Goes Here"></asp:Label></h3>
                <p style="text-align: center;"><asp:Image ID="TenantBackgroundStatusImage" runat="server" ImageURL="images/icons-07.png" style="max-width: 75px;"/></p>
                <p><asp:Label ID="TenantBackgroundStatusDescrip" runat="server" Text="You are a verified user! Your background check has been successful and you are cleared."></asp:Label></p>
                    
            </div>
             
        </div>
      </div>
    
    </div><!-- end div big row -->
    
   
    <div class="row " style="margin-top: 1rem;">
        <div class="col-md-12"  >
            <h2>Your Rental Agreements</h2>
          </div>
    </div><!-- end div big row -->  
    
    <div class="row " style="margin-top: 1rem; background-color: #ebebeb; margin-bottom: 3rem;">
        <div class="col-md-12"  style=" margin-top: 1rem;">
            <p>When you have a rental agreement, it will be indicated here. We hope you find your perfect housing match so that you can have some wonderful rental agreements.</p>
          </div>
    </div><!-- end div big row -->  
    
    
    
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
<script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js" integrity="sha384-ZMP7rVo3mIykV+2+9J3UJ46jBk0WLaUAdn689aCwoqbBJiSnjAK/l8WvCWPIPm49" crossorigin="anonymous"></script>
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js" integrity="sha384-ChfqqxuZUCnJSK3+MXmPNIyE6ZbWh2IMqE241rYiqJxyMiZ6OW/JmZQ5stwEULTy" crossorigin="anonymous"></script>
<!-- end of do not delete -->
</form>
</body>
</html>
</asp:Content>

