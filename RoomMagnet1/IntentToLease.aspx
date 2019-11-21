<%@ Page Title="" Language="C#" MasterPageFile="~/RoomMagnet.master" AutoEventWireup="true" CodeFile="IntentToLease.aspx.cs" Inherits="IntentToLease" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <!DOCTYPE html>

<html>
    <body>
        <form runat="server">
            <div class="container justify-content-center" style="border:solid; border-width: 1px; margin-top: 8rem; padding: 1rem; margin-bottom: 3rem;">
                <div class="row" style="margin-top: 1rem;">

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

                <div class="row" style="margin-top: 2rem; margin-left: 1rem; margin-right: 1rem;">
                    <p>This letter of intent (Intent to Lease) sets forth the general terms of the proposal.</p>
                    <p>The provisions of this letter of intent shall serve as the basis for a definitive lease agreement to be negotiated and entered into between the tenant and landlord (the lease).</p>
                </div>

                <div class="row" style="margin-top: 2rem;">
                    <div class="col">
                    <p>Tenant Name: <asp:TextBox ID="tenantName" runat="server" Text="Label" style="margin-right: 3rem; display:inline-block" Width="300px" ReadOnly="true" CssClass="form-control"></asp:TextBox>
                       Background Screen complete:
                        <asp:CheckBox ID="tenantYes" runat="server" Text="Yes" style="margin-left: 1rem;" onclick="return false;"/>
                        <asp:CheckBox ID="tenantNo" runat="server" Text="No" style="margin-left: 1rem;" onclick="return false;"/>
                    </p> 
                    </div>
                </div>

                <div class="row" style="margin-top: 2rem;">
                    <div class="col">
                    <p>Landlord Name: <b><asp:TextBox ID="landlordName" runat="server" Text="" style="margin-right: 3rem; display:inline-block" Width="300px" ReadOnly="true" CssClass="form-control"></asp:TextBox></b>
                       Background Screen complete:
                        <asp:CheckBox ID="hostYes" runat="server" Text="Yes" style="margin-left: 1rem;"/>
                        <asp:CheckBox ID="hostNo" runat="server" Text="No" style="margin-left: 1rem;"/>
                    </p> 
                    </div>
                </div>

                <div class="row" style="margin-top: 2rem;">
                    <div class="col">
                    <p>Property address: <asp:TextBox ID="streetAddress" runat="server" Text="" CssClass="form-control" style="margin-right: 3rem; display:inline-block" Width="300px" ReadOnly="true"></asp:TextBox>
                        <asp:Label ID="Label1" runat="server" Text="City: "></asp:Label>
                        <asp:TextBox ID="cityBox" runat="server" Text="" CssClass="form-control" style="display:inline-block" Width="200px" ReadOnly="true"></asp:TextBox>
                        <asp:Label ID="Label2" runat="server" Text="State: " style="margin-left: 1rem;"></asp:Label>
                        <asp:TextBox ID="stateBox" runat="server" Text="" CssClass="form-control" style="display:inline-block" Width="80px" ReadOnly="true"></asp:TextBox>
                    </p> 
                    </div>
                </div>

                <div class="row" style="margin-top: 2rem;">
                    <div class="col">
                    <p>Lease Term: <asp:TextBox ID="leaseTermBox" runat="server" Text="" CssClass="form-control" style="margin-right: 3rem; display:inline-block" Width="300px" ReadOnly="true"></asp:TextBox>
                    </p> 
                    </div>
                </div>

                <div class="row" style="margin-top: 2rem;">
                    <div class="col">
                    <p>Available Date: <asp:TextBox ID="AvailableDateBox" runat="server" Text="" CssClass="form-control" style="margin-right: 3rem; display:inline-block" Width="300px" ReadOnly="true"></asp:TextBox>
                    </p> 
                    </div>
                </div>

                <div class="row" style="margin-top: 2rem;">
                    <div class="col">
                    <p>Rental Price: <asp:TextBox ID="PriceBox" runat="server" Text="" CssClass="form-control" style="margin-right: 3rem; display:inline-block" Width="300px" ReadOnly="true"></asp:TextBox>
                    </p> 
                    </div>
                </div>

                <div class="row" style="margin-top: 5rem;">
                    <div class="col">
                    <p><b>Tenant and Host acknowledge that RoomMagnet’s match service fee will be deducted from the first month’s rent.</b></p> 
                    </div>
                </div>

                <div class="row" style="margin-top: 2rem;">
                    <div class="col">
                    <p><em>By typing your name below you agree to the terms set forth above.</em></p> 
                    </div>
                </div>

                <div class="row" style="margin-top: 2rem;">
                    <div class="col">
                    <p>Tenant Signature: <asp:TextBox ID="TenantSignature" runat="server" Text="" CssClass="form-control" style="margin-right: 3rem; display:inline-block" Width="300px"></asp:TextBox>
                    </p> 
                    </div>

                    <div class="col">
                    <p>Host Signature: <asp:TextBox ID="HostSignature" runat="server" Text="" CssClass="form-control" style="margin-right: 3rem; display:inline-block" Width="300px"></asp:TextBox>
                    </p>
                    </div>
                </div>

            </div>
            <div class="row">
                    <div class="col">
                        <asp:Button ID="saveButton" runat="server" Text="Save and send to Host" OnClick="saveButton_Click" CssClass="btn"/>
                    </div>
                    <div class="col" id="cancelArea" runat="server">
                        
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

