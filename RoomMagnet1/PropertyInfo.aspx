<%@ Page Title="" Language="C#" MasterPageFile="~/RoomMagnet.master" AutoEventWireup="true" CodeFile="PropertyInfo.aspx.cs" Inherits="PropertyInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!doctype html>
<html lang="en">
<head>
<meta charset="UTF-8">
<meta name="description" content="Room Magnet">
<meta name="keywords" content="room magnet, roommate, housing, matchmaking, house, apartment, living arrangement">
<meta name="author" content="Room Magnet">
<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
<title>Room Magnet</title>

<!-- Bootstrap v4 -->
<link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" media="screen">
<!-- custom css -->
<link href="css/custom.css" rel="stylesheet" type="text/css" media="screen">
<link rel="shortcut icon" href="images/logo-03.png" type="image/x-icon"/>
<link href="https://fonts.googleapis.com/css?family=Oswald:400|Raleway:300&display=swap" rel="stylesheet">    

<style>

.propertyc {
	max-height: 500px;
	object-fit: contain;
}

@media only screen and (min-width: 900px) {
    .prop{
        margin-top: 180px;
    }
} 
    
@media only screen and (max-width: 900px) {
    .prop{
        margin-top: 190px;
    }
}
    
@media only screen and (max-width: 885px) {
    .prop{
        margin-top: 220px;
    }
}

 @media only screen and (max-width: 800px) {
    .prop{
        margin-top: 220px;
    }
} 
@media only screen and (max-width: 765px) {
    .prop{
        margin-top: 310px;
    }
}    
    
</style>   
    
    
</head>
    
<body>
<form runat="server">    
<div  class="container">

  <div class="row fixed-top" style="margin-top: 6.35rem; background-color: white; ">
    <div class="col-md-1" >
        <asp:Button ID="BackButton" runat="server" Text="Back" style="margin-top: 1.5rem; margin-left: .5rem;" CssClass="btn" OnClick="BackButton_Click"/>
      </div>
    <div class="col-md-8" style="margin-top: 1rem; "> 
          <h1><asp:Label ID="HostNameLabel" runat="server" Text="Someone's Property"></asp:Label><img src="images/icons-07.png" style="max-width: 30px;" alt="background check approved icon"></h1> 
        </div> <!--end col-->
      <div class="col-md-3" style="margin-top: 1.5rem; "> 
          <p style=" float: center; "><asp:ImageButton ID="MessageButton" runat="server" style="max-width: 100px;" alt="message icon" ImageUrl="images/message-badge.png" OnClick="MessageButton_Click"/>
            <asp:ImageButton ID="FavoriteButton" runat="server" style="max-width: 90px;" alt="favorite icon" ImageUrl="images/favorite-badge.png" OnClick="FavoriteButton_Click"/> </p>
        </div> <!--end col-->
    </div><!-- end div row -->  

    <div class="row prop" style="border-bottom: solid; border-bottom-width: 1px; border-bottom-color: #D0D0D0;">
    	<div class="col-md-12">
    		<h3><asp:Label ID="PropTitle" runat="server" Text="Title of Space"></asp:Label></h3>
    	</div>
    	<div class="col-md-12" style="margin-top: .5rem;  margin-bottom: 1rem;">
            <div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel">
                <div class="carousel-inner"> <!-- house pics div -->
                	<div class="carousel-item active">
                		<img src="images/kitchen.jpeg"  class="d-block w-100 propertyc">
                	</div>
                	<a class="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-slide="prev" style="background-color:lightgray;">
                		<span class="carousel-control-prev-icon" aria-hidden="true"></span>
                		<span class="sr-only">Previous</span>
                	</a>
                	<a class="carousel-control-next" href="#carouselExampleIndicators" role="button" data-slide="next" style="background-color:lightgray;">
                		<span class="carousel-control-next-icon" aria-hidden="true"></span>
                		<span class="sr-only">Next</span>
                	</a>
                </div> <!--end carousel-inner-->
            </div> <!--end carousel div-->
        </div> <!--end col div-->
        <div class="col-md-7" style="padding: 20px; padding-left: 40px;">
            <h5>Harrisonburg, 22801</h5>
            <p >The brief bio that a homeowner would write about their home would go here. This is a room in an old home, but it's not haunted I swear. Haunted houses are seriously so scary, like how do people live in them? This is more of the bio because what if people have a lot to say?</p>
        </div>
        <div class="col-md-5" style="padding: 20px;">
            <img src="images/badges-03.png" style="max-width: 130px; padding-top: 5px;">
            <img src="images/badges-03.png" style="max-width: 130px; padding-top: 5px;">
            <img src="images/badges-03.png" style="max-width: 130px; padding-top: 5px;">
        </div>
    </div><!-- end div row --> 
    
    <div class="row" style="margin-top: 1rem;">
    	<div class="col-md-12">
    		<h3>Host(s) Name Here</h2>
    	</div>
    	<div class="col-md-4" style="margin-top: .5rem;  margin-bottom: 1rem;">
             <div id="carousel2" class="carousel slide" data-ride="carousel">
             	<div class="carousel-inner">
             		<div class="carousel-item active">
             			<img src="images/johnsmith1.jpeg"  class="d-block w-100">
             		</div>
             		<div class="carousel-item">
             			<img src="images/johnsmith1.jpeg"  class="d-block w-100">
             		</div>
             		<a class="carousel-control-prev" href="#carousel2" role="button" data-slide="prev">
             			<span class="carousel-control-prev-icon" aria-hidden="true"></span>
             			<span class="sr-only">Previous</span>
             		</a>
             		<a class="carousel-control-next" href="#carousel2" role="button" data-slide="next">
             			<span class="carousel-control-next-icon" aria-hidden="true"></span>
             			<span class="sr-only">Next</span>
             		</a>
             	</div> <!-- end carousel-inner -->
            </div> <!--end carousel -->
        </div> <!-- end col div -->
        <div class="col-md-8" style="padding-bottom: 10px; padding-left: 30px; padding-right: 30px;">
            <h5>Title of host's goes here.</h5>
            <p >The brief bio of a host would go here. I am a nice person to live with, I am a retired teacher, I enjoy knitting, cooking and watching movies. </p>
            <img src="images/badges-03.png" style="max-width: 130px; padding-top: 5px;">
            <img src="images/badges-03.png" style="max-width: 130px; padding-top: 5px;">
            <img src="images/badges-03.png" style="max-width: 130px; padding-top: 5px;">
        </div>
    </div><!-- end div row -->
    
    <!-- Modal -->
                   <div class="modal fade" id="exampleModalCenter" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
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
                                <div class="dropdown">
                                  <button class="btn btn-secondary dropdown-toggle" type="button" id="dropdownMenuButton" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">More Contacts</button>
                                  <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                                    <a class="dropdown-item" href="#">Sender</a>
                                    <a class="dropdown-item" href="#">Another Sender</a>
                                    <a class="dropdown-item" href="#">Another Sender</a>
                                  </div>
                                </div>
                              </div> <!--end col-->
                            </div> <!--end row-->
                            <div class="row">
                              <div class="col-sm-12">
                                <div class="row">
                                  <div class="col-sm-6" style="border-right-style: solid; border-right-color: #D0D0D0;">
                                    <h5 style="font-size: 17px;">Sender</h5>
                                    <p style="font-size: 13px;">Date</p>
                                    <p>Preview of message blah blah blah working through living stuff</p>
                                    <h5 style="font-size: 17px;">Sender</h5>
                                    <p style="font-size: 13px;">Date</p>
                                    <p>Preview of message blah blah blah working through living stuff</p>
                                    <h5 style="font-size: 17px;">Sender</h5>
                                    <p style="font-size: 13px;">Date</p>
                                    <p>Preview of message blah blah blah working through living stuff</p>
                                  </div>
                                  <div class="col-sm-6">
                                    <p>Messages go here.</p>
                                  </div>
                                </div> <!--end row-->
                              </div> <!--end col-sm-9-->
                            </div> <!--end row-->
                          </div> <!--end container-fluid-->
                        </div> <!--end modal-body-->
                        <div class="modal-footer">
                          <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                        </div>
                      </div> <!--end modal header-->
                    </div> <!--end modal content-->
                  </div> <!--end modal-dialog div-->
    
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

