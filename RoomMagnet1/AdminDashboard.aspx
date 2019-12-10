<%@ Page Title="" Language="C#" MasterPageFile="~/RoomMagnet.master" AutoEventWireup="true" CodeFile="AdminDashboard.aspx.cs" Inherits="AdminDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!doctype html>
    <script type="text/javascript">
        function ShowPopup(body) {
            $("#exampleModal .modal-body").html(body)
            $("#exampleModal").modal("show");
        }

        function ShowPopupTenant(body) {
            $("#tenantModal .modal-body").html(body)
            $("#tenantModal").modal("show");
        }
    </script>
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

  <div class="row" style="margin-top: 7rem;">
      <h1><asp:Label ID="admindash" runat="server" Text="Admin Dashboard"></asp:Label></h1>
    </div><!-- end div row -->  
   
</div>
    <div class="row" style="margin-right: 4rem; margin-left: 4rem;">
    <div class="col-md-1">

      </div>

    <div class="col-md-10" style="margin-bottom: 2rem; margin-top: 2rem">
        
        
         <nav class="navbar navbar-expand-lg navbar-dark bg-dark">

                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                        <span class="navbar-toggler-icon"></span>
                </button>
                
             <div class="collapse navbar-collapse" id="navbarNav">
                    <ul class="navbar-nav">
                        <li class="active">
                            <a class="nav-link" href="AdminDashboard.aspx">Search Users <span class="sr-only">(current)</span></a>
                        </li>
                        <li class="">
                            <a class="nav-link" href="AdminStats.aspx">Site Statistics</a>
                        </li>
                        <li class="">
                            <a class="nav-link" href="CreateAdmin.aspx">Create New Admin</a>
                        </li>
                    </ul>
            </div>
        </nav>

      </div>

      <div class="col-md-1">

      </div>
        </div>

   <!--Start First Module -->
   <div class="row " style="margin-top: 1rem;">
        <div class="col" style="border: solid; border-color: white;">
            <h5 class="nav justify-content-center" style="margin-top: 1rem;">Search users by last name:</h5>
            <ul class="nav justify-content-center" style="margin-top: 1rem;">
                <li class="nav-item" style="padding-right: 1rem;">
                    <asp:TextBox ID="lastNameSearchBox" runat="server" CssClass="form-control" style="" placeholder="Last Name"></asp:TextBox>
                </li>
                <li class="nav-item" style="padding-right: 1rem;">
                    <asp:Button ID="SearchButton" runat="server" Text="Search" CssClass="btn" OnClick="SearchButton_Click"/>
                </li>
            </ul>
        </div>
    </div>
        
        <div  class="row"  Style="margin-top: 1rem; margin-bottom: 1rem; margin-right: 5rem; margin-left: 5rem; padding-bottom: 1rem;" id="propertyModule" runat="server" >
            <div class="col-md-1">

            </div>
                    <div class="col-md-5" id="HostResults" runat="server" style="background-color: #ebebeb; border: solid; border-width: 2px;">
                        <h3 style="border-bottom:solid; margin-bottom: 2rem">Host Accounts</h3>
                        <asp:Button ID="approveButton" runat="server" Text="Button" OnClick="approveButton_Click"/>
                        <asp:Button ID="approveTenant" runat="server" Text="Button" OnClick="approveTenant_Click"/>
                        
                        <div  class="row" style="border-bottom: solid; border-bottom-width: 1px;">
                            <div class="col-md-3">
                                <h5>Name</h5>
                            </div>
                            <div class="col-md-4">
                                <h5>Email</h5>
                            </div>
                            <div class="col-md-5">
                                <h5>Actions</h5>
                            </div>
                        </div>
                    </div> <!-- end col class-->

                    <div class="col-md-5" id="TenantResults" runat="server" style="background-color: #ebebeb; margin-left:1rem; border: solid; border-width: 2px;">
                        <h3 style="border-bottom:solid; margin-bottom: 2rem">Tenant Accounts</h3>

                        <div  class="row" style="border-bottom: solid; border-bottom-width: 1px;">
                            <div class="col-md-3">
                                <h5>Name</h5>
                            </div>
                            <div class="col-md-4">
                                <h5>Email</h5>
                            </div>
                            <div class="col-md-5">
                                <h5>Actions</h5>
                            </div>
                        </div>

                    </div> <!-- end col class-->
                <div class="col-md-1">

                </div>
        </div> 

    <!-- Host Modal -->
    <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="exampleModalLabel">Are you sure you would like to deactivate this account?</h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body" runat="server" id="modalbody">
              
          </div>
          <div class="modal-footer">
            <asp:Button ID="yesDelete" runat="server" Text="Yes, Deactivate" CssClass="btn" OnClick="YesDeleteHost"/>
            <asp:Button ID="noDelete" runat="server" Text="Cancel"/>
          </div>
        </div>
      </div>
    </div>

    <!-- Tenant Modal -->
    <div class="modal fade" id="tenantModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="tenantModalLabel">Are you sure you would like to deactivate this account?</h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body" runat="server" id="Div1">
              
          </div>
          <div class="modal-footer">
            <asp:Button ID="Button1" runat="server" Text="Yes, Deactivate" CssClass="btn" OnClick="YesDeleteTenant"/>
            <asp:Button ID="Button2" runat="server" Text="Cancel" CssClass="btn btn-secondary"/>
          </div>
        </div>
      </div>
    </div>
    


<footer class="footer mt-auto py-3 footer-expand-lg"><!-- start footer! chnage-->
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

