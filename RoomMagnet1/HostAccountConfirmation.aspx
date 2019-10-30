<%@ Page Title="" Language="C#" MasterPageFile="~/RoomMagnet.master" AutoEventWireup="true" CodeFile="HostAccountConfirmation.aspx.cs" Inherits="HostAccountConfirmation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!doctype html>
<html lang="en">
<head>
<meta charset="UTF-8">
<meta name="description" content="Room Magnet">
<meta name="keywords" content="room magnet, roommate, housing, matchmaking, house, apartment, living arrangement">
<meta name="author" content="Room Magnet">
<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
<title>Your Safety</title>

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
     
    <div class="row" style="margin-top: 7rem;">
        <div class="col-md-12">
            <h1>Your safety is crucial to us.</h1>
            <p>Let us find you the perfect space.</p>
                <div class="progress " >
                    <div class="progress-bar progress-bar-striped " role="progressbar" style="width: 75%; " aria-valuenow="75" ></div>
                   </div>
        </div>

    </div><!-- end div row -->

    <div class="row" style="margin-top: 3rem;">
        <div class="col-md-12">
            
            <p>In order to provide our customers with the best, most secure living and housemate matching experience, we ask that the home-owners and tenants alike go through a background check. This ensures a superior housemate matching matching process. You can read more about our standards on our safety page, once you've completed your profile.</p>
            <p>An email with more details will be sent to your inbox shortly.</p>
            <p>Other users will be able to see the state of your background check process, just as you will be able to see theirs.</p>
            <p>The following indicators will appear at the specified steps in the process:</p>
        </div>

    </div><!-- end div row --> 
    
    <div class="row" style="margin-top: 1rem;">
        <div class="col-md-12">
           <h4><img src="images/icons-07.png" alt="approved symbol" style="max-width: 50px;"> Approved</h4>  
            <p style="margin-left: 4rem;">This person has completed the background check process and has been cleared and approved by our standards.</p>
             <h4><img src="images/icons-09.png" alt="pending symbol" style="max-width: 50px;"> Pending</h4>  
            <p style="margin-left: 4rem;">This person has started the background check process but it has not yet been completed.</p>
             <h4><img src="images/icons-10.png" alt="not approved symbol" style="max-width: 50px;"> Not Begun</h4>  
            <p style="margin-left: 4rem;">This person has not yet begun the background check process. They might be a new user.</p>
              <h4><img src="images/icons-08.png" alt="not begun symbol" style="max-width: 50px;"> Not Approved</h4>  
            <p style="margin-left: 4rem;">This person has completed the background check process but was neither cleared nor approved by our standards.</p>
        </div>

    </div><!-- end div row --> 

    <div class="row" style="margin-top: 1rem; margin-bottom: 3rem;">
        <div class="col-md-2 offset-10">
            <asp:Button ID="IUnderstand" runat="server" Text="I Understand" OnClick="IUnderstand_Click" CssClass="btn"/>
        </div>
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

