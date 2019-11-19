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
      /* Always set the map height explicitly to define the size of the div
       * element that contains the map. */
      #map {
        height: 500px;
        width: 700px;
      }
      /* Optional: Makes the sample page fill the window. */
      html, body {
        height: 100%;
        margin: 0;
        padding: 0;
      }
      #description {
        font-family: Roboto;
        font-size: 15px;
        font-weight: 300;
      }

      #infowindow-content .title {
        font-weight: bold;
      }

      #infowindow-content {
        display: none;
      }

      #map #infowindow-content {
        display: inline;
      }

      .pac-card {
        margin: 10px 10px 0 0;
        border-radius: 2px 0 0 2px;
        box-sizing: border-box;
        -moz-box-sizing: border-box;
        outline: none;
        box-shadow: 0 2px 6px rgba(0, 0, 0, 0.3);
        background-color: #fff;
        font-family: Roboto;
      }

      #pac-container {
        padding-bottom: 12px;
        margin-right: 12px;
      }

      .pac-controls {
        display: inline-block;
        padding: 5px 11px;
      }

      .pac-controls label {
        font-family: Roboto;
        font-size: 13px;
        font-weight: 300;
      }

      #pac-input {
        background-color: #fff;
        font-family: Roboto;
        font-size: 15px;
        font-weight: 300;
        margin-left: 12px;
        padding: 0 11px 0 13px;
        text-overflow: ellipsis;
        width: 400px;
      }

      #pac-input:focus {
        border-color: #4d90fe;
      }

      #title {
        color: #fff;
        background-color: #4d90fe;
        font-size: 25px;
        font-weight: 500;
        padding: 6px 12px;
      }
      #target {
        width: 345px;
      }    
</style>   
    
    
</head>
    
<body>
<form runat="server">    
<div  class="container">

  <div class="row fixed-top" style="margin-top: 6.35rem; background-color: lightgray">
    <div class="col-md-1" >
        <asp:Button ID="BackButton" runat="server" Text="Back" style="margin-top: 1.5rem; margin-left: .5rem;" CssClass="btn" OnClick="BackButton_Click"/>
      </div>
    <div class="col-md-8" style="margin-top: 1rem; "> 
          <h1><asp:Label ID="HostNameLabel" runat="server" Text="Someone's Property"></asp:Label><asp:Image ID="backgroundCheckImage" runat="server" style="max-width: 30px;" ImageUrl=""/></h1> 
        </div> <!--end col-->
      <div class="col-md-3" style="margin-top: 1.5rem; "> 
          <p style=" float: center; "><asp:ImageButton ID="MessageButton" runat="server" style="max-width: 100px;" alt="message icon" ImageUrl="images/message-badge.png" OnClick="MessageButton_Click"/>
            <asp:ImageButton ID="FavoriteButton" runat="server" style="max-width: 90px;" alt="favorite icon" ImageUrl="images/favorite-badge.png" OnClick="FavoriteButton_Click"/> </p>
        </div> <!--end col-->
    </div><!-- end div row -->  

    <div class="row prop" style="border-bottom: solid; border-bottom-width: 1px; border-bottom-color: #D0D0D0;">
    	<div class="col-md-12">
    		
    	</div>
    	<div class="col-md-12" style="margin-top: .5rem;  margin-bottom: 1rem;">
            <div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel">
                <div class="carousel-inner" runat="server" id="carouselInner"> <!-- house pics div -->
                	
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
        <div class="row justify-content-center" style="margin-bottom: 1rem;">
            <h3><asp:Label ID="PropTitle" runat="server" Text="Title of Space"></asp:Label></h3>
        </div>
        <div class="col-md-7" style="padding: 20px; padding-left: 40px;">
            
            <h5><asp:Label ID="CityStateZip" runat="server" Text=""></asp:Label></h5>
            <p ><asp:Label ID="PropBio" runat="server" Text=""></asp:Label></p>
                <div class="row" style="margin-top: 3rem;">
                    <p>
                        <b>Price: </b> <asp:Label ID="price" runat="server" Text=""></asp:Label>
                            <br />
                            <br />
                        <b>Number of Current Residents: </b> <asp:Label ID="numOfTenants" runat="server" Text=""></asp:Label>
                            <br />
                            <br />
                        <b>Room Type: </b> <asp:Label ID="roomType" runat="server" Text=""></asp:Label>
                            <br />
                            <br />
                        <b>Neighborhood: </b> <asp:Label ID="neighborhood" runat="server" Text=""></asp:Label>
                    </p>
                </div>
        <div class="col-md-5" style="padding: 20px;">
            <img src="images/add-badges-badge.png" style="max-width: 130px; padding-top: 5px;">
        </div>
        <!--
        <input id="pac-input" class="controls" type="text" placeholder="Search Box">
            -->
        <div id="map"></div>
    </div><!-- end div row --> 
    
    <div class="row" style="margin-top: 1rem; border-top: solid; border-top-width: 1px;">
    	<div class="col-md-12">
    		<h2>About the host</h2>
    	</div>
    	<div class="col-md-4" style="margin-top: .5rem;  margin-bottom: 1rem;">
             <div id="carousel2" class="carousel slide" data-ride="carousel">
             	<div class="carousel-inner" runat="server" id="hostcarousel">

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
            <h3><asp:Label ID="hostName2" runat="server" Text=""></asp:Label></h3>
            <br />
            <h6><asp:Label ID="hostGender" runat="server" Text=""></asp:Label></h6>
            <p ><asp:Label ID="hostBio" runat="server" Text=""></asp:Label></p>
            <img src="images/add-badges-badge.png" style="max-width: 130px; padding-top: 5px;">
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
<script>
    function initAutocomplete() {

        var map = new google.maps.Map(document.getElementById('map'), {
            center: { lat: -33.8688, lng: 151.2195 },
            zoom: 15,
            mapTypeId: 'roadmap',
            disableDefaultUI: true,
            zoomControl: true,
            
        });

        // Create the search box and link it to the UI element.
        //Commented out because not needed for this functionality.
        /*
        var input = document.getElementById('pac-input');
        var searchBox = new google.maps.places.SearchBox(input);
        map.controls[google.maps.ControlPosition.TOP_LEFT].push(input);

        // Bias the SearchBox results towards current map's viewport.
        map.addListener('bounds_changed', function () {
            searchBox.setBounds(map.getBounds());
        });
        */

        var markers = [];
        var circles = [];

        //Do geocoding stuff
        var geocoder = new google.maps.Geocoder();
        var hardPlace = "715 S Main St Harrisonburg, VA, USA";

        geocoder.geocode({ 'address': hardPlace }, function (results, status) {
            if (status == 'OK') {
                map.setCenter(results[0].geometry.location);

                /*
                markers.push(new google.maps.Marker({
                    map: map,
                    position: results[0].geometry.location
                }));
                */

                //Create Circle around marker
                circles.push(new google.maps.Circle({
                    strokeColor: '#FF0000',
                    strokeOpacity: 0.7,
                    strokeWeight: 2,
                    fillColor: '#FF0000',
                    fillOpacity: 0.25,
                    map: map,
                    center: results[0].geometry.location,
                    radius: 804
                }));
            } else {
                alert('Geocode was not successful for the following reason: ' + status);
            }
        });

        // Listen for the event fired when the user selects a prediction and retrieve
        // more details for that place.

        /*
        searchBox.addListener('places_changed', function () {
            var places = searchBox.getPlaces();

            if (places.length == 0) {
                return;
            }

            // Clear out the old markers.
            markers.forEach(function (marker) {
                marker.setMap(null);
            });

            // Clear out radii for old markers
            circles.forEach(function (circle) {
                circles.setMap(null);
            });

            markers = [];
            circles = [];

            // For each place, get the icon, name and location.
            var bounds = new google.maps.LatLngBounds();
            places.forEach(function (place) {
                if (!place.geometry) {
                    console.log("Returned place contains no geometry");
                    return;
                }
                var icon = {
                    url: place.icon,
                    size: new google.maps.Size(71, 71),
                    origin: new google.maps.Point(0, 0),
                    anchor: new google.maps.Point(17, 34),
                    scaledSize: new google.maps.Size(25, 25)
                };

                // Create a marker for each place.
                
                markers.push(new google.maps.Marker({
                    map: map,
                    title: place.name,
                    position: place.geometry.location
                }));
                

                //Create Circle around marker
                circles.push(new google.maps.Circle({
                    strokeColor: '#FF0000',
                    strokeOpacity: 0.7,
                    strokeWeight: 2,
                    fillColor: '#FF0000',
                    fillOpacity: 0.25,
                    map: map,
                    center: place.geometry.location,
                    radius: 804
                }));

                if (place.geometry.viewport) {
                    // Only geocodes have viewport.
                    bounds.union(place.geometry.viewport);
                } else {
                    bounds.extend(place.geometry.location);
                }
            });
            map.fitBounds(bounds);
        });
        */       
    }

    function handleLocationError(browserHasGeolocation, infoWindow, pos) {
        infoWindow.setPosition(pos);
        infoWindow.setContent(browserHasGeolocation ?
            'Error: The Geolocation service failed.' :
            'Error: Your browser doesn\'t support geolocation.');
        infoWindow.open(map);
    }

    </script>

<script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyB_RtlDFF8z1UVZvm5W4LVRHF8JBxM9S1I&libraries=places&callback=initAutocomplete"
     async defer></script>
</form>
</body>
</html>
</asp:Content>

