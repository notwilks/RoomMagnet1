<%@ Page Title="" Language="C#" MasterPageFile="~/RoomMagnet.master" AutoEventWireup="true" CodeFile="LoginPage.aspx.cs" Inherits="LoginPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!DOCTYPE html>

<html>
    <title>RoomMagnet - Login</title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 91px;
        }
        .auto-style3 {
            width: 259px;
        }
    </style>
    <h1 class="container">Login</h1>

<body>
<header style="margin-top: 8rem;">
    <form id="form1" runat="server">
        <header style="margin-top: 8rem;">
      <div class="container">
        <h1>Welcome Back.</h1>
        <p>Login to your account.</p>
      </div>
</header>

    <section id="creation" style="margin-top: 2rem;">
      <div class="container">
        <form>
          <div class="row">
            <div class="col">
              <label for="formGroupExampleInput">Email</label>
                <asp:TextBox ID="EmailBox" runat="server" CssClass="form-control" placeholder="Email"></asp:TextBox>
            </div>
            <div class="col">
              
            </div> <!--end col-->
          </div> <!--end row class-->
          <br />
          <div class="row">
            <div class="col">
                <label for="formGroupExampleInput">Password</label>
              <asp:TextBox ID="PasswordBox" runat="server" TextMode ="Password" CssClass="form-control" placeholder="Password"></asp:TextBox>
                <a href="ForgotPassword.aspx">Forgot Password?</a>
            </div>

            <div class="col">
              <asp:Label ID="OutputLabel" runat="server" Text="" CssClass="alert-danger"></asp:Label>
            </div> <!--end col-->
          </div> <!--end row class-->

          <div class="row">
            <div class="col">
              <br />
              <asp:Button ID="NextButton" runat="server" Text="Login" CausesValidation="True" CssClass="btn" OnClick="NextButton_Click"/>
            </div>
            <div class="col">
              
            </div> <!--end col-->
          </div> <!--end row class-->
        </form> <!--end form-->
        <br>
        
        <div class="row" style="margin-bottom: 3rem;"> 
          <div class="col-md-6"></div>
            
             <div class="col-md-6">
                 
             </div>
                <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
            
        </div>     
      </div> <!--end container-->
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
    
<!-- jQuery and Bootstrap links - do not delete! -->
<!-- jQuery first, then Popper.js, then Bootstrap JS -->
<script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js" integrity="sha384-ZMP7rVo3mIykV+2+9J3UJ46jBk0WLaUAdn689aCwoqbBJiSnjAK/l8WvCWPIPm49" crossorigin="anonymous"></script>
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js" integrity="sha384-ChfqqxuZUCnJSK3+MXmPNIyE6ZbWh2IMqE241rYiqJxyMiZ6OW/JmZQ5stwEULTy" crossorigin="anonymous"></script>
<!-- end of do not delete -->

                   
                        
               
                        
               
                        
                   

    </form>
</body>
</html>
    </header>
</asp:Content>

