﻿<%@ Page Title="" Language="C#" MasterPageFile="~/RoomMagnet.master" AutoEventWireup="true" CodeFile="GoogleMaps.aspx.cs" Inherits="GoogleMaps" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style>
      /* Always set the map height explicitly to define the size of the div
       * element that contains the map. */
      #map {
        margin-top: 100px;
        height: 90%;
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
    <input id="pac-input" class="controls" type="text" placeholder="Search Box">
    <div id="map"></div>
    <div>
        <asp:Label ID="test" runat="server" Text=""></asp:Label>
    </div>
    <script>
        function initAutocomplete() {

            var map = new google.maps.Map(document.getElementById('map'), {
                center: { lat: -33.8688, lng: 151.2195 },
                zoom: 15,
                mapTypeId: 'roadmap'
            });

            // Create the search box and link it to the UI element.

            /*
            var input = document.getElementById('pac-input');
            var searchBox = new google.maps.places.SearchBox(input);
            map.controls[google.maps.ControlPosition.TOP_LEFT].push(input);
            */

            // Bias the SearchBox results towards current map's viewport.

            /*
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

                    //Add Marker based on geocoded position -- commented out because we don't want exact property locations. 

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
</asp:Content>
  


