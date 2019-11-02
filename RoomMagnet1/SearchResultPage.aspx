<%@ Page Title="" Language="C#" MasterPageFile="~/RoomMagnet.master" AutoEventWireup="true" CodeFile="SearchResultPage.aspx.cs" Inherits="SearchResultPage" %>

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
<form id="form1" runat="server">

<header><!-- start header -->
    </header><!-- end header -->
<h1 style="margin-top: 8rem;" class="container">Search for your perfect space.</h1>
<div class="row" style="margin-top: 3rem;">
<ul class="nav container">
  
  <li class="nav-item" style="padding-right: 2rem;">
        <asp:TextBox ID="CitySearchBox" runat="server" CssClass="form-control" style="" placeholder="Search By City"></asp:TextBox>
  </li>
  <li class="nav-item" style="padding-right: 2rem;">
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
  <li class="nav-item">
      <asp:Button ID="SearchButton" runat="server" Text="Search" CssClass="form-control" style="background-color: #B23325; color: white;" OnClick="SearchButton_Click"/>
  </li>
</ul>
</div>

<div class="row" style="margin-top: 1.5rem;">
    <label class="container">Filter By:</label>
<ul class="nav container">
  <li class="nav-item" style="padding-right: 1rem;">
        <asp:CheckBox ID="PrivateEntranceBox" runat="server" Text="Private Entrance" cssclass="form-control" style="background-color: white; color: #B23325" OnCheckedChanged="PrivateEntranceBox_CheckedChanged"/>
  </li>

  <li class="nav-item" style="padding-right: 1rem;">
        <asp:CheckBox ID="PrivateBathroomBox" runat="server" Text="Private Bathroom" cssclass="form-control" style="background-color: white; color: #B23325" OnCheckedChanged="PrivateBathroomBox_CheckedChanged"/>
  </li>

  <li class="nav-item" style="padding-right: 1rem;">
        <asp:CheckBox ID="FurnishedBox" runat="server" Text="Furnished" cssclass="form-control" style="background-color: white; color: #B23325" OnCheckedChanged="FurnishedBox_CheckedChanged"/>
  </li>

  <li class="nav-item" style="padding-right: 1rem;">
        <asp:CheckBox ID="StorageSpaceBox" runat="server" Text="Storage Space" cssclass="form-control" style="background-color: white; color: #B23325" OnCheckedChanged="StorageSpaceBox_CheckedChanged"/>
  </li>

  <li class="nav-item" style="padding-right: 1rem;">
        <asp:CheckBox ID="HasPetsBox" runat="server" Text="Does not have Pets" cssclass="form-control" style="background-color: white; color: #B23325" OnCheckedChanged="HasPetsBox_CheckedChanged"/>
  </li>

  <li class="nav-item" style="padding-right: 1rem;">
        <asp:CheckBox ID="AllowsSmokingBox" runat="server" Text="Allows Smoking" cssclass="form-control" style="background-color: white; color: #B23325" OnCheckedChanged="AllowsSmokingBox_CheckedChanged"/>
  </li>
</ul><!-- end nav -->
</div><!-- end row -->

<div class="row" style="margin-top: 1rem;">
<ul class="nav container">
  <li class="nav-item" style="padding-right: 1rem;">
        <asp:CheckBox ID="WifiBox" runat="server" Text="WiFi" cssclass="form-control" style="background-color: white; color: #B23325" OnCheckedChanged="WifiBox_CheckedChanged"/>
  </li>

  <li class="nav-item" style="padding-right: 1rem;">
        <asp:CheckBox ID="ParkingBox" runat="server" Text="Private Parking" cssclass="form-control" style="background-color: white; color: #B23325" OnCheckedChanged="ParkingBox_CheckedChanged"/>
  </li>

  <li class="nav-item" style="padding-right: 1rem;">
        <asp:CheckBox ID="KitchenBox" runat="server" Text="Private Kitchen" cssclass="form-control" style="background-color: white; color: #B23325" OnCheckedChanged="KitchenBox_CheckedChanged"/>
  </li>

  <li class="nav-item" style="padding-right: 1rem;">
        <asp:CheckBox ID="CableBox" runat="server" Text="Cable TV" cssclass="form-control" style="background-color: white; color: #B23325" OnCheckedChanged="CableBox_CheckedChanged"/>
  </li>

  <li class="nav-item" style="padding-right: 1rem;">
        <asp:CheckBox ID="AllowsPetsBox" runat="server" Text="Allows Pets" cssclass="form-control" style="background-color: white; color: #B23325" OnCheckedChanged="AllowsPetsBox_CheckedChanged"/>
  </li>

  <li class="nav-item" style="padding-right: 1rem;">
        <asp:CheckBox ID="LaundryBox" runat="server" Text="Laundry Access" cssclass="form-control" style="background-color: white; color: #B23325" OnCheckedChanged="LaundryBox_CheckedChanged"/>
  </li>
</ul><!-- end nav -->
</div><!-- end row -->

<div class="row" style="margin-top: 1.5rem; margin-bottom: 3rem">
    <label class="container">Price:</label>
    <ul class="nav container">

      <li class="nav-item" style="padding-right: 1rem;">
          <asp:TextBox ID="MinPriceBox" runat="server" CssClass="form-control" placeholder="Min" Width="110px"></asp:TextBox>
      </li>

      <li class="nav-item" style="padding-right: 1rem;">
          <asp:TextBox ID="MaxPriceBox" runat="server" CssClass="form-control" placeholder="Max" Width="110px"></asp:TextBox>
      </li>

      <li class="nav-item">
          <asp:DropDownList ID="SortByDropDown" runat="server" CssClass="form-control">
              <asp:ListItem Value="">Sort By</asp:ListItem>
              <asp:ListItem Value="PriceAscending">Price: Low - High</asp:ListItem>
              <asp:ListItem Value="PriceDescending">Price: High - Low</asp:ListItem>
          </asp:DropDownList>
      </li>

    </ul>
</div>

      
 
    
<section style="margin-left: 8rem" id="ResultList" runat="server">
    <div class="row " style="margin-top: 2rem; border-bottom: solid; border-bottom-width: 1px; ">
            <h5><asp:Label ID="countLabel" runat="server" Text=""></asp:Label></h5>
        </div>
    <div class="row " style="margin-top: 1rem; border-bottom-width: 1px; ">
        <div class="col-md-4" >
            
        </div>
        <div class="col-md-2" style="margin-top: .5rem;">
            
        </div>
        <div class="col-md-5" style="margin-top: .5rem; float: right; margin-bottom: 1rem;">
           
        </div>
        
    </div><!-- end div row -->

</section>

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

