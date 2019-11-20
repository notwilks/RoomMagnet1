<%@ Page Title="" Language="C#" MasterPageFile="~/RoomMagnet.master" AutoEventWireup="true" CodeFile="IntentToLease.aspx.cs" Inherits="IntentToLease" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <!DOCTYPE html>

<html>
    <body>
        <form runat="server">
            <div class="container justify-content-center">
                <div class="row" style="margin-top: 8rem;">

                    <div class="col">

                    </div>

                    <div class="col">
                    <h2>Intent to Lease</h2>
                    </div>

                    <div class="col">

                    </div>

                    </div>
                <div class="row" style="margin-top: 1rem;">

                    <div class="col-md-2" style="display:inline-block">
                    <p>Date<asp:TextBox ID="DateBox" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox></p>
                    </div>

                    <div class="col-md-10">
                    </div>
                </div>

                <div class="row" style="margin-top: 2rem;">
                    <p>This letter of intent (Intent to Lease) sets forth the general terms of the proposal. The provisions of this letter of intent shall serve as the basis for a definitive lease agreement to be negotiated and entered into between the tenant and landlord (the lease).</p>
                </div>

                <div class="row" style="margin-top: 2rem;">
                    <div class="col">
                    <p>Tenant Name: <b><asp:Label ID="tenantName" runat="server" Text="Label"></asp:Label></b></p> 
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

</asp:Content>

