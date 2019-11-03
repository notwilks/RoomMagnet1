<%@ Page Title="" Language="C#" MasterPageFile="~/RoomMagnet.master" AutoEventWireup="true" CodeFile="EditProperty.aspx.cs" Inherits="EditProperty" %>

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
<form id="form1" runat="server">
<header style="margin-top: 8rem;">
      <div class="container">
        <h1>Edit Property Information</h1>
          <p>*Street Address is never displayed to potential tenants without your consent.*</p>
      </div>
</header>

    <section id="creation" style="margin-top: 2rem;">
      <div class="container">
          <div class="row" style="margin-top: 2rem">
            <div class="col">
                <label for="formGroupExampleInput">House Number</label>
                <asp:TextBox ID="HouseNumBox" runat="server" CssClass="form-control" placeholder="HouseNumber"></asp:TextBox>
            </div>
            <div class="col">
                <label for="formGroupExampleInput">Property Name</label>
                <asp:TextBox ID="PropNameBox" runat="server" CssClass="form-control" placeholder="Property Name"></asp:TextBox>
            </div> <!--end col-->
          </div> <!--end row class-->
          <div class="row" style="margin-top: 2rem">
            <div class="col">
                <label for="formGroupExampleInput">Street</label>
                <asp:TextBox ID="StreetBox" runat="server" CssClass="form-control" placeholder="Street"></asp:TextBox>
            </div>

            <div class="col">
               <label for="formGroupExampleInput">Price</label>
               <asp:TextBox ID="Price" runat="server" CssClass="form-control" placeholder="Price"></asp:TextBox>
            </div> <!--end col-->
          </div> <!--end row class-->

          <div class="row" style="margin-top: 2rem">
            <div class="col">
                <label for="formGroupExampleInput">City</label>
                <asp:TextBox ID="cityBox" runat="server" CssClass="form-control" placeholder="City"></asp:TextBox>
            </div>
            <div class="col">
                <label for="formGroupExampleInput">Number of Tenants</label>
                <asp:TextBox ID="NumOfTenantsBox" runat="server" CssClass="form-control" placeholder="Number of Tenants"></asp:TextBox>
            </div> <!--end col-->
          </div> <!--end row class-->

          <div class="row" style="margin-top: 2rem">
            <div class="col">
                <label for="formGroupExampleInput">State</label>
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
            </div>

            <div class="col">
               <label for="formGroupExampleInput">Neighborhood</label>
               <asp:TextBox ID="neighborhoodBox" runat="server" CssClass="form-control" placeholder="Neighborhood"></asp:TextBox>
            </div> <!--end col-->
          </div> <!--end row class-->

          <div class="row" style="margin-top: 2rem">
            <div class="col">
                <label for="formGroupExampleInput">Zip Code</label>
                <asp:TextBox ID="ZipBox" runat="server" CssClass="form-control" placeholder="Zip Code"></asp:TextBox>
            </div>

            <div class="col">
               <label for="formGroupExampleInput">Room Type</label>
               <asp:DropDownList ID="RoomTypeList" runat="server" cssclass="form-control">
                        <asp:ListItem Value="private">Private Room</asp:ListItem>
                        <asp:ListItem Value="separate">Seperate Private Building</asp:ListItem>
                        <asp:ListItem Value="Other">Other</asp:ListItem>
                    </asp:DropDownList>
            </div> <!--end col-->
          </div> <!--end row class-->

          <div class="row" style="margin-top: 2rem">
            <div class="col">
            </div>

            <div class="col">
               <label for="formGroupExampleInput">If Other, please describe</label>
               <asp:TextBox ID="otherBox" runat="server" CssClass="form-control" placeholder="Room Type"></asp:TextBox>
            </div> <!--end col-->
          </div> <!--end row class-->

          <div class="row" style="margin-top: 3rem">
            <div class="col">
               <label for="formGroupExampleInput">Property Description</label>
               <asp:TextBox ID="PropDescriptionBox" runat="server" CssClass="form-control" placeholder="Property Description" Height="100px" TextMode="MultiLine"></asp:TextBox>
            </div> <!--end col-->
          </div> <!--end row class-->

          <div class="row" style="margin-top: 3rem">
            <div class="col">
                <label for="formGroupExampleInput">Upload the main image for your property</label>
                <label for="formGroupExampleInput" style="font-size: smaller; color:dimgrey">(This will be the first image tenants see when they search for your property)</label>
                <asp:FileUpload ID="mainImage" runat="server" CssClass="btn form-control"/>
            </div> <!--end col-->
              <div class="col">
                <label for="formGroupExampleInput">Upload more images of your property</label>
                <asp:FileUpload ID="image2" runat="server" CssClass="btn form-control"/>
                  <asp:FileUpload ID="image3" runat="server" CssClass="btn"/>
            </div> <!--end col-->
          </div> <!--end row class-->

          <div class="row" style="margin-top: 3rem">
            <div class="col">
                <asp:Button ID="SaveButton" runat="server" Text="Save" cssclass="btn" OnClick="SaveButton_Click"/>
            </div> <!--end col-->
          </div> <!--end row class-->
     
        
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

