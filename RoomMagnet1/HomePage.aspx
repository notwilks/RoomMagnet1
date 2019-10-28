<%@ Page Title="" Language="C#" MasterPageFile="~/RoomMagnet.master" AutoEventWireup="true" CodeFile="HomePage.aspx.cs" Inherits="HomePage" %>

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
</head>

<body>
    <header style="margin-top: 6rem;">
  <div class="row" style="background-image: url(images/foldimg_A0_Rectangle_2_pattern.png); background-repeat: no-repeat; background-size:cover; margin-top: 6rem;">
   
      <div class="col-md-4  ctahome" style="margin-top: 8rem; margin-bottom: 8rem; ">
       <div class="card card-inverse" style="width: 25rem; margin-top: 2rem; margin-bottom: 2rem; margin-right: 1rem; padding-top: 1rem;">
              <div class="card-body">
                <h3 class="card-title tan" style="text-align: center;">Room Magnet</h3>
                <p class="card-text tan" style="text-align: center; line-height: 2;">An intergenerational rental matching service that attracts the best option for your needs.</p>
               <p style="text-align: center;">
                   <a href="#" class="btn " style="margin-right: 1rem;">Rent My Room</a>
                   <a href="#" class="btn " style="margin-left: 1rem;">Find a Room</a>
                  </p>
              </div>
            </div>
    </div><!-- end div col! -->
      
      
    </div><!-- end div row! -->
    
   <div class="row" style="margin-top: 5rem;">
    
    <div class="col-md-6 " >
       <div class="card" style="width: 30rem; border: none; margin: 0 auto;">
          <img src="images/scott-webb-1ddol8rgUH8-unsplash.jpg" class="card-img-top" alt="picture of a house">
          <div class="card-body">
            <p style="text-align: center; "><a href="#" class="btn " style="font-size: 20px;">Your safety is our #1 concern.</a></p>
          </div>
        </div>
    </div><!-- end div col! -->
       
    <div class="col-md-6">
       
       <div class="card" style="width: 30rem; border: none; margin: 0 auto;;">
          <img src="images/ben-o-bro-wpU4veNGnHg-unsplash.jpg" class="card-img-top" alt="picture of a house">
          <div class="card-body">
            <p style="text-align: center; "><a href="#" class="btn " style="font-size: 20px;">Search by city &amp; preferences.</a></p>
          </div>
        </div>
        
    </div><!-- end div col! -->
       
    </div> <!-- end div row! -->
    
    
    <div class="row" style="margin-top: 5rem; margin-left: 1rem;">
        <div class="col-md-12">
        <h3>Hear From Some Happy Customers</h3>
        </div>    
    </div><!-- end div row! -->
    
    <div class="row">
        <div class="col-md-12">
        <div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel">
          <ol class="carousel-indicators">
            <li data-target="#carouselExampleIndicators" data-slide-to="0" class="active"></li>
            <li data-target="#carouselExampleIndicators" data-slide-to="1"></li>
            <li data-target="#carouselExampleIndicators" data-slide-to="2"></li>
          </ol>
            
              <div class="carousel-inner"> 
                  <div class="carousel-item active">
                    <img src="images/testimonials-01.png"  class="d-block w-100" alt="We had such a wonderful experience with Room Magnet. Our house-mate has been a blessing. said Karen and Steve H of Harrisonburg Virginia.">
                </div>
                  <div class="carousel-item">
                    <img src="images/testimonials-02.png"  class="d-block w-100" alt="Renting out our extra room was a great way to save some money. And our house-mate has become part of the family. said Maria and Scott R of Harrisonburg Virginia.">
                </div>
                  <div class="carousel-item">
                    <img src="images/testimonials-03.png"  class="d-block w-100" alt="Room Magent allows me to live close to my Grad School for an affordable price. My house-mates feel more like my grandparents. said Jordan T of Harrisonburg Virginia.">
                </div>
                  
          <a class="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-slide="prev">
            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
            <span class="sr-only">Previous</span>
          </a>
          <a class="carousel-control-next" href="#carouselExampleIndicators" role="button" data-slide="next">
            <span class="carousel-control-next-icon" aria-hidden="true"></span>
            <span class="sr-only">Next</span>
          </a>
        </div> 
            </div>    
        </div><!-- end div carousel! -->
    </div><!-- end div row! -->
    
    
    <div class="row" style="margin-top: 5rem; margin-left: 1rem;">
        <div class="col-md-12">
        <h3>How We Work</h3>
        </div>    
    </div><!-- end div row! -->
    
    
    <div class="row">
        <div class="col-md-2" style="margin: 0 auto;">
            <p style="text-align: center;"><img src="images/icons-01.png" style="max-width: 150px;"></p>
            <p style="text-align: center; margin: 0 auto; font-size: 18px;">Create a profile.</p>
        </div>
      <div class="col-md-1  ">
            <p  class="arrowr" style="text-align: center; font-size: 5rem; margin: 0 auto; margin-top: 2rem;">&#8594;</p>
             <p  class="arrowd" style="text-align: center; font-size: 5rem; margin: 0 auto; margin-top: 2rem;">&#8595;</p>
        </div>
        
         <div class="col-md-2" style="margin: 0 auto;">
            <p style="text-align: center;"><img src="images/icons-02.png" style="max-width: 150px;"></p>
            <p style="text-align: center; margin: 0 auto; font-size: 18px;">Fill out your preferences.</p>
        </div>
        <div class="col-md-1 ">
            <p  class="arrowr" style="text-align: center; font-size: 5rem; margin: 0 auto; margin-top: 2rem;">&#8594;</p>
             <p  class="arrowd" style="text-align: center; font-size: 5rem; margin: 0 auto; margin-top: 2rem;">&#8595;</p>
        </div>
        
         <div class="col-md-2" style="margin: 0 auto;">
            <p style="text-align: center;"><img src="images/icons-03.png" style="max-width: 150px;"></p>
            <p style="text-align: center; margin: 0 auto; font-size: 18px;">Get cleared.</p>
        </div>
        <div class="col-md-1  ">
            <p  class="arrowr" style="text-align: center; font-size: 5rem; margin: 0 auto; margin-top: 2rem;">&#8594;</p>
             <p  class="arrowd" style="text-align: center; font-size: 5rem; margin: 0 auto; margin-top: 2rem;">&#8595;</p>
        </div>
         <div class="col-md-2" style="margin: 0 auto;">
            <p style="text-align: center; "><img src="images/icons-04.png" style="max-width: 150px;"></p>
            <p style="text-align: center; margin: 0 auto; font-size: 18px;">Find your housing match.</p>
        </div>
    
    </div><!-- end div row! -->
    
    
   <div class="row" style="margin-top: 5rem; margin-bottom: 2rem;">
        <div class="col-md-12">
            <p style="text-align: center; font-size: 50px;" class="din">1,203</p>
            <p style="text-align: center; font-size: 20px;">housing matches made this year.<br>Be the next one.</p>
            <p style="text-align: center;">
                <a href="#" class="btn " style="margin-right: 1rem; margin: 0 auto; font-size: 22px;">Get Started</a>
            </p> 
        </div>    
    </div><!-- end div row! --> 
    
    
    
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

