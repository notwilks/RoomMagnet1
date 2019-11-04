<%@ Page Title="" Language="C#" MasterPageFile="~/RoomMagnet.master" AutoEventWireup="true" CodeFile="AdminDashboard.aspx.cs" Inherits="AdminDashboard" %>

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
<div id="containerDiv" class="container">

  <div class="row " style="margin-top: 7rem; border-bottom: solid;">
    <div class="col-md-9" style="margin-bottom: 2rem; margin-top: 2rem">
        <h1><asp:Label ID="FirstNameLastNameHeader" runat="server" Text="Admin Dashboard"></asp:Label></h1>
        <h3><asp:Label ID="Label1" runat="server" Text="Powered By: "></asp:Label></h3> <asp:Image ID="Image4" runat="server" ImageUrl="images/companylogo-02.png" Height="100px" Width="180px"/>
      </div>
    </div><!-- end div row -->  
    
   <!--Start First Module -->
   <div class="row " style="margin-top: 1rem;">
    <div class="col-md-6" style="border: solid; border-color: white;">
        <div class="row">
            <div class="col-md-6">
               <h2 >Active Hosts</h2>                
            </div>
            <div>
                
            </div>         
            <div class ="col">

            </div>
        </div> <!--end Row Class -->
        
        <div  class="row" style="background-color: #ebebeb; margin-top: 1rem; margin-bottom: 1rem; padding-bottom: 1rem;" id="propertyModule" runat="server" >
            <div class="col-md-6" style="margin-top: 1rem;">
                <div class="row" style="margin-top: 1rem;">
                    <div class="col-md-6">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="HostGridView">
                    <Columns>
                        <asp:BoundField DataField="FirstName" HeaderText="FirstName"/>
                        <asp:BoundField DataField ="LastName" HeaderText ="LastName" SortExpression="LastName" />
                        <asp:BoundField DataField="Email" HeaderText="Email"/>
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="HostGridView" runat="server" ConnectionString="<%$ ConnectionStrings:RoomMagnetAWS %>" SelectCommand="SELECT FirstName, LastName, Email FROM HOST"></asp:SqlDataSource>
                    </div> <!-- end col class-->
                </div> <!-- end row class-->
            </div> <!-- end col class-->
             <div class="col-md-6" style="margin-top: 1rem;" runat="server">
            </div> <!-- end col class-->
        </div> <!--end row class-->
      </div>
    <!--End First Module -->   

    <!--Start Second Module -->
    <div class="col-md-6" style="border: solid; border-color: white;">
        <div class="row">
            <div class="col-md-6">
               <h2 >Active Tenants</h2> 
            </div> <!-- end col class-->
            <div class="col-md-6">

            </div> <!-- end col class-->
        </div> <!-- end row class-->
        
        <div class="row" style="background-color: #ebebeb; margin-top: 1rem; margin-bottom: 1rem; padding-bottom: 1rem;" >
            <div class="col-md-6" style="margin-top: 1rem;">
                <asp:Image ID="Image1" ImageURl="" runat="server" CssClass="img-fluid"/>
                <div class="row" style="margin-top: 1rem;">
                    <div class="col-md-6">
                        <asp:Image ID="Image2" ImageURl="" runat="server" CssClass="img-fluid"/>
                    </div> <!-- end col class-->
                    <div class="col-md-6">
                        <asp:Image ID="Image3" ImageURl="" runat="server" CssClass="img-fluid"/>
                    </div> <!-- end col class-->
                </div> <!-- end row class-->
            </div> <!-- end col class-->
             <div class="col-md-6" style="margin-top: 1rem;">
                 <h3><asp:Label ID="HostName" runat="server" Text="Heading One"></asp:Label></h3>
            </div> <!-- end col class-->
        </div> <!-- end row class-->
      </div> <!-- end col class-->
       <!--End Second Module -->   
             
    </div><!-- end div big row -->
    
    
     <div class="row " style="margin-top: 1rem;">
        <div class="col-md-6"  style="border: solid; border-color: white;">
            <div class="row">
                <div class="col-md-12">
                   <h2 >GridView Three</h2> 
                </div>

            </div> <!-- end row class-->

            <div class="row" style="background-color: #ebebeb; margin-top: 1rem; margin-bottom: 1rem;" >
                <div class="col-md-12" style="margin-top: 1rem; border-bottom: solid; border-bottom-width: 1px;">
                   <h3>SubGridView One</h3>
                    <p>Random Statement In P Tags</p>
                </div>
                 <div class="col-md-12" style="margin-top: 1rem; border-bottom: solid; border-bottom-width: 1px;">
                   <h3>SubGridView Two
                   </h3>
                    <p>Random Statement in P Tags</p>
                </div> <!-- end col class-->
            </div> <!-- end row class-->
          </div> <!-- end col class-->


        <div class="col-md-6" style="border: solid; border-color: white;" >
        <div class="row">
            <div class="col-md-12">
               <h2 >GridView Four</h2> 
            </div>
            
        </div> <!-- end row class-->
        
        <div class="row" style="background-color: #ebebeb; margin-top: 1rem; margin-bottom: 1rem; " >
            <div class="col-md-12" style="margin-top: 1rem; border-bottom: solid; border-bottom-width: 1px;">
                <h3><asp:Label ID="HostBackgroundStatusWords" runat="server" Text="Status Goes Here"></asp:Label></h3>
                <p style="text-align: center;"><asp:Image ID="TenantBackgroundStatusImage" runat="server" ImageURL="images/icons-07.png" style="max-width: 75px;"/></p>
                <p><asp:Label ID="HostBackgroundStatusDescrip" runat="server" Text=""></asp:Label></p>
                    
            </div>
             
        </div> <!-- end row class-->
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
        <!-- Below is the dropdown list for a future google translate API boiii
            <div class="col-md-6">
                <asp:DropDownList ID ="translateList" runat="server" CssClass="form-control" style="">

                </asp:DropDownList>
            </div>
            -->
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

