<%@ Page Title="" Language="C#" MasterPageFile="~/RoomMagnet.master" AutoEventWireup="true" CodeFile="CreateAdmin.aspx.cs" Inherits="CreateAdmin" %>

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
                        <li class="">
                            <a class="nav-link" href="AdminDashboard.aspx">Search Users</a>
                        </li>
                        <li class="">
                            <a class="nav-link" href="AdminStats.aspx">Site Statistics</a>
                        </li>
                        <li class="active">
                            <a class="nav-link" href="CreateAdmin.aspx">Create New Admin</a>
                        </li>
                    </ul>
            </div>
        </nav>

      </div>

      <div class="col-md-1">

      </div>
 
        </div>

    <div class="container">
        <div class="row">
            <div class="col">
                <h2>Create New Admin Account</h2>
            </div>
            <div class="col">
            </div>
        </div>
        <div class="row">
            <div class="col">
              <label for="formGroupExampleInput" style="margin-top: 4rem;">Email</label>
                <asp:TextBox ID="EmailBox" runat="server" CssClass="form-control" placeholder="Email"></asp:TextBox>
                <asp:Label ID="EmailErrorLbl" runat="server" Text="" Font-Size="Small" ForeColor="Red"></asp:Label>
            </div>
            <div class="col">
              
            </div> <!--end col-->
          </div> <!--end row class-->

          <div class="row">
            <div class="col">
              <label for="formGroupExampleInput" style ="margin-top: 2rem;">Confirm Email</label>
                <asp:TextBox ID="ConfirmEmailBox" runat="server" CssClass="form-control" placeholder="Confirm Email"></asp:TextBox>
                <asp:Label ID="ConfirmEmailErrorLbl" runat="server" Text="" Font-Size="Small" ForeColor="Red"></asp:Label>
            </div>
            <div class="col">
              
            </div> <!--end col-->
          </div> <!--end row class-->
          
          <div class="row">
            <div class="col">
                <label for="formGroupExampleInput" style="margin-top: 2rem;">Password</label>
              <asp:TextBox ID="PasswordBox" runat="server" TextMode ="Password" CssClass="form-control" placeholder="Password"></asp:TextBox>
                <asp:Label ID="PasswordErrorLbl" runat="server" Text="" Font-Size="Small" ForeColor="Red"></asp:Label>
            </div>

            <div class="col">
              <label for="formGroupExampleInput"class="alert-light" style="margin-top: 2rem;">*Password must be at least 8 characters long</label>
              <label for="formGroupExampleInput"class="alert-light">*Password must conatain at least 1 number.</label>
                <label for="formGroupExampleInput"class="alert-light">*Password must conatain at least 1 special character (!@#$%^&*()-_+=).</label>
            </div> <!--end col-->
          </div> <!--end row class-->

          <div class="row">
            <div class="col">
              <label for="formGroupExampleInput">Confirm Password</label>
              <asp:TextBox ID="ConfirmPasswordBox" runat="server" TextMode ="Password" CssClass="form-control" placeholder="Confirm Password"></asp:TextBox>
                <asp:Label ID="ConfirmPasswordErrorLbl" runat="server" Text="" Font-Size="Small" ForeColor="Red"></asp:Label>
              
            </div>
            <div class="col">
              
            </div> <!--end col-->
          </div> <!--end row class-->

        <div class="row" style="margin-top: 2rem;">
            <div class="col">
                <asp:Label ID="OutputLabel" runat="server" Text=""></asp:Label>
              <asp:Button ID="NextButton" runat="server" Text="Create Admin Account" CausesValidation="True" CssClass="btn" style="margin-right: 1rem;" OnClick="NextButton_Click"/>
            </div>
            <div class="col">

            </div> <!--end col-->
          </div> <!--end row class-->
    </div>

    </form>
</body>
</html>
</asp:Content>

