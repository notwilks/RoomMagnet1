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
<div  class="container">

  <div class="row " style="margin-top: 7rem;">
    <div class="col-md-12">
        <h1 style="font-size: 60px"><asp:Label ID="FirstNameLastNameHeader" runat="server"></asp:Label></h1><!-- += 's Dashboard -->
      </div>

    </div><!-- end div row -->  
    
    
   <div class="row " style="margin-top: 1rem;">
    <div class="col-md-6" style="border: solid; border-color: black; background-color: #ebebeb; border-width: 1px; border-radius: 20px;">
        <div class="row">
            <div class="col-md-6">
               <h1>Your Profile</h1> 
            </div>
            <div class="col-md-6">
                <asp:Button ID="EditProfileBtn" runat="server" OnClick="EditProfileBtn_Click" Text="Edit Profile" cssclass="btn" style="margin-top: 1rem;"/>
            </div>
        </div>
        
        <div  class="row" style="background-color: #ebebeb; margin-top: 1rem; margin-bottom: 1rem; padding-bottom: 1rem;" id="badgeModule" runat="server" >
            <div class="col-md-6" style="margin-top: 1rem;">
                <asp:Image ID="TenantPrimaryImage" ImageURl="images/noimageyet420.png" runat="server" CssClass="img-fluid"/>
                <div class="row" style="margin-top: 1rem;">
                    <div class="col-md-6">
                        <asp:Image ID="TenantImage2" ImageURl="" runat="server" CssClass="img-fluid"/>
                    </div>
                    <div class="col-md-6">
                        <asp:Image ID="TenantImage3" ImageURl="" runat="server" CssClass="img-fluid"/>
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
       
       <div class="col-md-6" style="border: solid; border-color: black; border-color: black; background-color: #ebebeb; border-width: 1px; border-radius: 20px;">
        <div class="row">
            <h1 style="margin-left: 1rem;">Your Favorites</h1>
        </div>
           
        <div class="row" style="background-color: #ebebeb; margin-top: 1rem;" id="favorites" runat="server">
            <div class="col-md-6" style="margin-top: 1rem;">

            </div>
             <div class="col-md-6" style="margin-top: 1rem;">

            </div>
        </div>         
      </div>          
    </div><!-- end div big row -->
    
    
     <div class="row " style="margin-top: 1rem;">
        <div class="col-md-6"  style="border: solid; border-color: black; border-color: black; background-color: #ebebeb; border-width: 1px; border-radius: 20px;">
            <div class="row" runat="server">
                <div class="col-md-12">
                   <h2 >Message Board<asp:Button ID="btnCompose" CssClass="btn float-right" runat="server" Text="Compose" Style="margin-top: 1rem"/></h2>
                
              </div>
            </div>

            <div class="row" id="messageCenterDiv" runat="server" style="background-color: #ebebeb; margin-top: 1rem; margin-bottom: 1rem;" >
                
                </div>
            
          </div>


        <div class="col-md-6" style="border: solid; border-color: black; background-color: #ebebeb; border-width: 1px; border-radius: 20px;">
        <div class="row">
            <div class="col-md-12">
               <h1>Background Check Status</h1> 
            </div>
            
        </div>
        
        <div class="row" style="background-color: #ebebeb; margin-top: 1rem; margin-bottom: 1rem; " >
            <div class="col-md-12" style="margin-top: 1rem;">
                <h3><asp:Label ID="TenantBackgroundStatusWords" runat="server" Text=""></asp:Label></h3>
                <p style="text-align: center;"><asp:Image ID="TenantBackgroundStatusImage" runat="server" ImageURL="images/icons-07.png" style="max-width: 75px;"/></p>
                <p><asp:Label ID="TenantBackgroundStatusDescrip" runat="server" Text=""></asp:Label></p>
                    
            </div>
             
        </div>
      </div>
    
    </div><!-- end div big row -->
    
   <div style="border: solid; border-color: black; background-color: #ebebeb; border-width: 1px; border-radius: 20px; margin-top: 1rem; padding: 1rem; margin-bottom: 1rem;">
        <div class="row " style="margin-top: 1rem;">
            <div class="col-md-12"  >
                <h2>Your Rental Agreements</h2>
              </div>
        </div><!-- end div big row -->  
    
        <div class="row " style="margin-top: 1rem; margin-bottom: 1rem;">
            <div class="col-md-12"  style=" margin-top: 1rem;">
                <p>When you have a rental agreement, it will be indicated here. We hope you find your perfect housing match so that you can have some wonderful rental agreements.</p>
              </div>
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
<script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js" integrity="sha384-ZMP7rVo3mIykV+2+9J3UJ46jBk0WLaUAdn689aCwoqbBJiSnjAK/l8WvCWPIPm49" crossorigin="anonymous"></script>
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js" integrity="sha384-ChfqqxuZUCnJSK3+MXmPNIyE6ZbWh2IMqE241rYiqJxyMiZ6OW/JmZQ5stwEULTy" crossorigin="anonymous"></script>
<!-- end of do not delete -->
</form>
</body>
</html>
</asp:Content>

