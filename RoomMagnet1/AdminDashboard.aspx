<%@ Page Title="" Language="C#" MasterPageFile="~/RoomMagnet.master" AutoEventWireup="true" CodeFile="AdminDashboard.aspx.cs" Inherits="AdminDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!doctype html>
<html>
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
<div id="containerDiv" class="container">

  <div class="row " style="margin-top: 7rem; border-bottom: solid;">
    <div class="col-md-9" style="margin-bottom: 2rem; margin-top: 2rem">
        <h1><asp:Label ID="FirstNameLastNameHeader" runat="server" Text="Admin Dashboard"></asp:Label></h1>
        <h3><asp:Label ID="Label1" runat="server" Text="Powered By: "></asp:Label></h3> <asp:Image ID="Image4" runat="server" ImageUrl="images/companylogo-02.png" Height="100px" Width="180px"/>
      </div>
    </div><!-- end div row -->  
    
   <!--Start First Module -->
   <div class="row " style="margin-top: 1rem;">
        <div class="col" style="border: solid; border-color: white;">
           <h2 >Active Hosts</h2>                
        </div>

        <div class ="col">
            <h2 >Active Tenants</h2> 
        </div>
    </div>
        
        <div  class="row" style="background-color: #ebebeb; margin-top: 1rem; margin-bottom: 1rem; padding-bottom: 1rem;" id="propertyModule" runat="server" >
                    <div class="col">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="HostGridView">
                            <Columns>
                                <asp:BoundField DataField="FirstName" HeaderText="FirstName"/>
                                <asp:BoundField DataField ="LastName" HeaderText ="LastName" SortExpression="LastName" />
                                <asp:BoundField DataField="Email" HeaderText="Email"/>
                            </Columns>
                        </asp:GridView>
                            <asp:SqlDataSource ID="HostGridView" runat="server" ConnectionString="<%$ ConnectionStrings:RoomMagnetAWS %>" SelectCommand="SELECT FirstName, LastName, Email FROM HOST"></asp:SqlDataSource>
                    </div> <!-- end col class-->
                    <div class="col">
                        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="TenantGridView">
                            <Columns>
                                <asp:BoundField DataField="FirstName" HeaderText="FirstName"/>
                                <asp:BoundField DataField ="LastName" HeaderText ="LastName" SortExpression="LastName" />
                                <asp:BoundField DataField="Email" HeaderText="Email"/>
                            </Columns>
                        </asp:GridView>
                            <asp:SqlDataSource ID="TenantGridView" runat="server" ConnectionString="<%$ ConnectionStrings:RoomMagnetAWS %>" SelectCommand="SELECT FirstName, LastName, Email FROM TENANT"></asp:SqlDataSource>
                    </div>
        </div> 
    
        <div class="row " style="margin-top: 1rem;">
            <div class="col" style="border: solid; border-color: white;">
                <h2 >Listed Properties</h2>                
            </div>

            <div class ="col">
                <h2 >Unlisted Properties</h2> 
            </div>
        </div>
    
        <div  class="row" style="background-color: #ebebeb; margin-top: 1rem; margin-bottom: 1rem; padding-bottom: 1rem;" id="Div1" runat="server" >
                    <div class="col">
                         <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" DataSourceID="ActivePropGridView">
                         </asp:GridView>
                            <asp:SqlDataSource ID="ActivePropGridView" runat="server" ConnectionString="<%$ ConnectionStrings:RoomMagnetConnectionString %>" SelectCommand="SELECT H.firstName + ' ' + H.lastName AS 'Host Name', A.houseNumber + ' ' + A.street AS 'Street Address', A.state, A.country FROM Accommodation AS A INNER JOIN Host AS H ON H.hostID = A.hostID WHERE (A.listed = 'T')"></asp:SqlDataSource>
                    </div> <!-- end col class-->
                    <div class="col">

                    </div>
        </div> 
</div>

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

