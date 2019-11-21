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
<%--<link href="https://fonts.googleapis.com/css?family=Oswald:400|Raleway:300&display=swap" rel="stylesheet">--%>    
</head>

<body>
<form id="form1" runat="server">

  <div class="row" style="background-image: url(images/home.jpg); background-repeat: no-repeat; background-size:cover; margin-top: 6rem;">

        <div class="col-md-4  ctahome" style="margin-top: 8rem; margin-bottom: 8rem; ">
            <div class="card card-inverse" style="width: 25rem; margin-top: 2rem; margin-bottom: 2rem; margin-right: 1rem;">
                <div class="card-body">
                    <h3 class="card-title" style="text-align: center;">Room Magnet</h3>
                    <p class="card-text" style="text-align: center;">A safe, secure, long-term rental service geared towards the aging population and empty nesters who are looking to rent their extra rooms at a competitive price.</p>
                    <p style="text-align: center;">
                        <a href="CreateHostorTenant.aspx" class="btn " style="margin-right: 1rem;">Get Started</a>
                        
                    </p>

                    
                </div>
            </div>
        </div><!-- end div col! -->


    </div><!-- end div row! -->

     <h5 class="nav justify-content-center" style="margin-top: 2rem;">Find a Property</h5>
                  
                  <ul class="nav justify-content-center">
                      <li class="nav-item" >
                            <asp:TextBox ID="CitySearchBox" runat="server" CssClass="form-control" style="margin-right:1rem;" placeholder="Search By City"></asp:TextBox>
                      </li>
                      <li class="nav-item" >
                            <asp:DropDownList ID="stateBox" runat="server" CssClass="form-control" style="">
                                        <asp:ListItem>Select a state</asp:ListItem>
                                        <asp:ListItem Value="AL">Alabama</asp:ListItem>
                                        <asp:ListItem Value="AK">Alaska</asp:ListItem>
                                        <asp:ListItem Value="AZ">Arizona</asp:ListItem>
                                        <asp:ListItem Value="AR">Arkansas</asp:ListItem>
                                        <asp:ListItem Value="CA">California</asp:ListItem>
                                        <asp:ListItem Value="CO">Colorado</asp:ListItem>
                                        <asp:ListItem Value="CT">Connecticut</asp:ListItem>
                                        <asp:ListItem Value="DE">Delaware</asp:ListItem>
                                        <asp:ListItem Value="FL">Florida</asp:ListItem>
                                        <asp:ListItem Value="GA">Georgia</asp:ListItem>
                                        <asp:ListItem Value="HI">Hawaii</asp:ListItem>
                                        <asp:ListItem Value="ID">Idaho</asp:ListItem>
                                        <asp:ListItem Value="IL">Illinois</asp:ListItem>
                                        <asp:ListItem Value="IN">Indiana</asp:ListItem>
                                        <asp:ListItem Value="IA">Iowa</asp:ListItem>
                                        <asp:ListItem Value="KS">Kansas</asp:ListItem>
                                        <asp:ListItem Value="KY">Kentucky</asp:ListItem>
                                        <asp:ListItem Value="LA">Louisiana</asp:ListItem>
                                        <asp:ListItem Value="ME">Maine</asp:ListItem>
                                        <asp:ListItem Value="MD">Maryland</asp:ListItem>
                                        <asp:ListItem Value="MA">Massachusetts</asp:ListItem>
                                        <asp:ListItem Value="MI">Michigan</asp:ListItem>
                                        <asp:ListItem Value="MN">Minnesota</asp:ListItem>
                                        <asp:ListItem Value="MS">Mississippi</asp:ListItem>
                                        <asp:ListItem Value="MO">Missouri</asp:ListItem>
                                        <asp:ListItem Value="MT">Montana</asp:ListItem>
                                        <asp:ListItem Value="NE">Nebraska</asp:ListItem>
                                        <asp:ListItem Value="NV">Nevada</asp:ListItem>
                                        <asp:ListItem Value="NH">New Hampshire</asp:ListItem>
                                        <asp:ListItem Value="NJ">New Jersey</asp:ListItem>
                                        <asp:ListItem Value="NM">New Mexico</asp:ListItem>
                                        <asp:ListItem Value="NY">New York</asp:ListItem>
                                        <asp:ListItem Value="NC">North Carolina</asp:ListItem>
                                        <asp:ListItem Value="ND">North Dakota</asp:ListItem>
                                        <asp:ListItem Value="OH">Ohio</asp:ListItem>
                                        <asp:ListItem Value="OK">Oklahoma</asp:ListItem>
                                        <asp:ListItem Value="OR">Oregon</asp:ListItem>
                                        <asp:ListItem Value="PA">Pennsylvania</asp:ListItem>
                                        <asp:ListItem Value="RI">Rhode Island</asp:ListItem>
                                        <asp:ListItem Value="SC">South Carolina</asp:ListItem>
                                        <asp:ListItem Value="SD">South Dakota</asp:ListItem>
                                        <asp:ListItem Value="TN">Tennessee</asp:ListItem>
                                        <asp:ListItem Value="TX">Texas</asp:ListItem>
                                        <asp:ListItem Value="UT">Utah</asp:ListItem>
                                        <asp:ListItem Value="VT">Vermont</asp:ListItem>
                                        <asp:ListItem Value="VA">Virginia</asp:ListItem>
                                        <asp:ListItem Value="WA">Washington</asp:ListItem>
                                        <asp:ListItem Value="WV">West Virginia</asp:ListItem>
                                        <asp:ListItem Value="WI">Wisconsin</asp:ListItem>
                                        <asp:ListItem Value="WY">Wyoming</asp:ListItem>
                                    </asp:DropDownList>
                      </li>
                      <li class="nav-item" style="margin-bottom:1rem; " >
                          <asp:Button ID="SearchButton" runat="server" Text="Search" CssClass="btn" OnClick="SearchButton_Click"/>
                      </li>
                    </ul>

    <div class="row" style="margin-top: 5rem; margin-bottom: 2rem; margin-left: 6rem">
    <div class="col-sm">
        <!-- empty-->
    </div>

    <div class="col-sm">
        <!-- empty -->
    </div>

    <div class="col-sm">
        <h3>
            <asp:Label ID="HWW" runat="server" Text="How We Work" CssClass="text-nowrap"></asp:Label>
        </h3>
    </div>

    <div class="col-sm">
        <!-- empty -->
    </div>

    <div class="col-sm">
        <!-- empty -->
    </div>
    </div><!-- end div row! -->

    <div class="row">
        <div class="col-md-2" style="margin: 0 auto;">
            <p style="text-align: center;"><img src="images/icons-01.png" style="max-width: 150px;"></p>
            <p style="text-align: center; margin: 0 auto; font-size: 18px;">Create and customize your profile.</p>
        </div>
      <div class="col-md-1  ">
            <p  class="arrowr" style="text-align: center; font-size: 5rem; margin: 0 auto; margin-top: 2rem;">&#8594;</p>
             <p  class="arrowd" style="text-align: center; font-size: 5rem; margin: 0 auto; margin-top: 2rem;">&#8595;</p>
        </div>
        
         <div class="col-md-2" style="margin: 0 auto;">
            <p style="text-align: center;"><img src="images/icons-02.png" style="max-width: 150px;"></p>
            <p style="text-align: center; margin: 0 auto; font-size: 18px;">Search for your potential housing match.</p>
        </div>
        <div class="col-md-1 ">
            <p  class="arrowr" style="text-align: center; font-size: 5rem; margin: 0 auto; margin-top: 2rem;">&#8594;</p>
             <p  class="arrowd" style="text-align: center; font-size: 5rem; margin: 0 auto; margin-top: 2rem;">&#8595;</p>
        </div>
        
         <div class="col-md-2" style="margin: 0 auto;">
            <p style="text-align: center;"><img src="images/icons-03.png" style="max-width: 150px;"></p>
            <p style="text-align: center; margin: 0 auto; font-size: 18px;">Wait for your background check to be cleared.</p>
        </div>
        <div class="col-md-1  ">
            <p  class="arrowr" style="text-align: center; font-size: 5rem; margin: 0 auto; margin-top: 2rem;">&#8594;</p>
             <p  class="arrowd" style="text-align: center; font-size: 5rem; margin: 0 auto; margin-top: 2rem;">&#8595;</p>
        </div>
         <div class="col-md-2" style="margin: 0 auto;">
            <p style="text-align: center; "><img src="images/icons-04.png" style="max-width: 150px;"></p>
            <p style="text-align: center; margin: 0 auto; font-size: 18px;">Agree on your housing match.</p>
        </div>
    
    </div><!-- end div row! -->
      
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
    
   <div class="row" style="margin-top: 1rem; margin-bottom: 2rem;">
        <div class="col-md-12">
            <p style="text-align: center; font-size: 50px;" class="din" id="listedProperties" runat="server"></p>
            <p style="text-align: center; font-size: 20px;">Properties are currently listed.<br>Find your perfect fit.</p>
            <p style="text-align: center;">
                <asp:Button ID="GetStartedBtn" runat="server" Text="Get Started" OnClick ="GetStartedBtn_Clicked" CssClass="btn" />
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
    
</form>
</body>
</html>

</asp:Content>

