<%@ Page Title="" Language="C#" MasterPageFile="~/RoomMagnet.master" AutoEventWireup="true" CodeFile="CreateHostorTenant.aspx.cs" Inherits="CreateHostorTenant" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <!DOCTYPE html>

<html>

    <title>RoomMagnet - Create Account</title>
<body>
    
<div class="container">
<form id="form1" runat="server">
      <header style="margin-top: 8rem;">
            <div>
                <h1>Welcome to the first step in finding your perfect housemate.</h1>
                <p>Will you be finding a place to live or hosting someone to live with you?</p>
            </div>   
      </header>
    <section id="creation">
      <div class="container">
        <form>
            <div class="row">
                    <div class="col promar" >
                        <div class="progress" >
                            <div class="progress-bar progress-bar-striped" role="progressbar" style="width: 10%; background-color: #CC6559" aria-valuenow="25" ></div>
                        </div>
                    </div><!--end col-->
               </div><!--end row class-->

          <div class="row" style="margin-top: 4rem;">
            <div class="col align-content-center">
              <asp:ImageButton ID="hostButton" ImageURL="images/rent-my-room.png" runat="server" Text="Host my room" cssclass=""  OnClick="hostButton_Click"/>
                <br />
                <label for="formGroupExampleInput" style="">Rent My Room</label>
            </div>
            <div class="col align-content-center">
                <asp:ImageButton ID="tenantButton" ImageURL="images/find-a-room.png" runat="server" Text="Find a place to live" cssclass="" style="" OnClick="tenantButton_Click"/>
                <br />
                <label for="formGroupExampleInput" style="">Find A Room</label>
            </div> <!--end col-->
          </div> <!--end row class-->
          
          <div class="row">
            <div class="col">
                
            </div>

            <div class="col">
              
            </div> <!--end col-->
          </div> <!--end row class-->

          <div class="row">
            <div class="col">
              
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
                <asp:Label ID="OutputLabel" runat="server" Text=""></asp:Label>
            
        </div>     
      </div> <!--end container-->
    </section>
</form>
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
    <p>
    <a href="#"><img src="images/social-icons-02.png" class="img-fluid" style="max-width: 180px;"></a></p>
    </div>
       
    </div>
</footer><!-- end footer! -->
</body>
</html> 
</asp:Content>

