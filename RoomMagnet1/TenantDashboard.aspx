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

  <div class="row " style="margin-top: 7rem; ">
    <div class="col-md-9">
        <h1 >John Smith's Dashboard</h1>
      </div>
    <div class="col-md-3">
        <a href="#" class="btn " style="margin-top: 1rem;">Search Properties</a>
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
        
        <div class="row" style="background-color: #ebebeb; margin-top: 1rem; margin-bottom: 1rem;" >
            <div class="col-md-6" style="margin-top: 1rem;">
                <img src="images/johnsmith1.jpeg" class="img-fluid" >
                <div class="row" style="margin-top: 1rem;">
                    <div class="col-md-6">
                        <img src="images/johnsmith3.jpeg" class="img-fluid">
                    </div>
                    <div class="col-md-6">
                        <img src="images/johnsmith3.jpeg" class="img-fluid">
                    </div>
                </div>
            </div>
             <div class="col-md-6" style="margin-top: 1rem;">
                <h3>John Smith</h3>
                 <h5>John Smith's title here.</h5>
                 <p>The brief bio of this tenant would go here. This person is cool and also nice. They need a place to live, just like anyone alive. House them please.</p>
                 <img src="images/badges-01.png" style="max-width: 150px;">
            </div>
        </div>
      </div>
       
       
       <div class="col-md-6" style="border: solid; border-color: white; ">
        <div class="row">
            <h2 >Your Favorites</h2>
        </div>
           
        <div class="row" style="background-color: #ebebeb; margin-top: 1rem; border-bottom: solid; border-bottom-width: 1px;" >
            <div class="col-md-6" style="margin-top: 1rem;">
                <h3>Host Name</h3>
                <h5>Title of space goes here</h5>
            </div>
             <div class="col-md-6" style="margin-top: 1rem;">
                <img src="images/icons-07.png" style="max-width: 50px;">
                 <a href="#" class="btn  " style="margin-left: 1rem;">View Profile</a>
            </div>
        </div>
        <div class="row" style="background-color: #ebebeb; solid; border-bottom: solid; border-bottom-width: 1px" >
            <div class="col-md-6" style="margin-top: 1rem;">
                <h3>Host Name</h3>
                <h5>Title of space goes here</h5>
            </div>
             <div class="col-md-6" style="margin-top: 1rem;">
                <img src="images/icons-07.png" style="max-width: 50px;">
                 <a href="#" class="btn  " style="margin-left: 1rem;">View Profile</a>
            </div>
        </div> 
        <div class="row" style="background-color: #ebebeb; solid; border-bottom: solid; border-bottom-width: 1px" >
            <div class="col-md-6" style="margin-top: 1rem;">
                <h3>Host Name</h3>
                <h5>Title of space goes here</h5>
            </div>
             <div class="col-md-6" style="margin-top: 1rem;">
                <img src="images/icons-07.png" style="max-width: 50px;">
                 <a href="#" class="btn  " style="margin-left: 1rem;">View Profile</a>
            </div>
        </div>  
        
           <div class="row" style="background-color: #ebebeb; solid; border-bottom: solid; border-bottom-width: 1px" >
            <div class="col-md-6" style="margin-top: 1rem;">
                <h3>Host Name</h3>
                <h5>Title of space goes here</h5>
            </div>
             <div class="col-md-6" style="margin-top: 1rem;">
                <img src="images/icons-07.png" style="max-width: 50px;">
                 <a href="#" class="btn  " style="margin-left: 1rem;">View Profile</a>
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
               <h3>Status Goes Here</h3>
                <p style="text-align: center;"><img src="images/icons-07.png" style="max-width: 75px;"></p>
                <p>The status of your background check will be explained right here. Background checks are important to us, very important. We take your safety seriously.</p>
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

