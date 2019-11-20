<%@ Page Title="" Language="C#" MasterPageFile="~/RoomMagnet.master" AutoEventWireup="true" CodeFile="CreateProperty.aspx.cs" Inherits="CreateProperty" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!doctype html>
<html>
<head>
<meta charset="UTF-8">
<meta name="description" content="Room Magnet">
<meta name="keywords" content="room magnet, roommate, housing, matchmaking, house, apartment, living arrangement">
<meta name="author" content="Room Magnet">
<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
<title>Room Magnet</title>

<!-- Bootstrap v4 -->

<!-- custom css -->

<link rel="shortcut icon" href="images/logo-03.png" type="image/x-icon"/>
</head>

<body>
    <form id="form1" runat="server">
   <header style="margin-top: 8rem;">
      <div class="container">
        <h1>Tell us about your property</h1>
        <p>Let us find you the perfect housemate</p>
      </div>

    </header>

    <section id="creation"">
      <div class="container">
        <form>
            <div class="row">
            <div class="col">
                <div class="col promar" >
                        <div class="progress" >
                            <div class="progress-bar progress-bar-striped" role="progressbar" style="width: 75%; background-color: #CC6559" aria-valuenow="25" ></div>
                        </div>
                    </div>
            </div>
          </div> <!--end row class-->

          <div class="row">
            <div class="col">
               <label for="formGroupExampleInput" style="margin-top: 3rem;">Street Address</label>
                <asp:TextBox ID="AddressBox" runat="server" cssclass="form-control" placeholder="Street Address"></asp:TextBox>
                <asp:Label ID="AddressErrorLbl" runat="server" Text="" ForeColor="Red" Font-Size="Small"></asp:Label>
                <asp:CompareValidator ID="AddressValidator" runat="server" ErrorMessage="" ControlToValidate="AddressBox" ForeColor ="Red" Font-Size="Small" Text="Please enter an address." Operator="DataTypeCheck" Type="String"></asp:CompareValidator>
            </div>

            <div class="col">
              <label for="formGroupExampleInput" style="margin-top: 3rem;">Apartment (if appilicable)</label>
              <asp:TextBox ID="ApartmentBox" runat="server" cssclass="form-control" placeholder="Apartment"></asp:TextBox>
            </div>

              <div class="col">
              
              </div><!--end col-->
 
          </div> <!--end row class-->

          
          <div class="row" style="margin-top: 2rem;">
            <div class="col">
              <label for="formGroupExampleInput">City</label>
              <asp:TextBox ID="CityBox" runat="server" cssclass="form-control" placeholder="City"></asp:TextBox>
                <asp:Label ID="CityErrorLbl" runat="server" Text="" ForeColor="Red" Font-Size="Small"></asp:Label>
            </div>
            <div class="col">
              <label for="formGroupExampleInput">State</label>
               <asp:DropDownList ID="stateBox" runat="server" CssClass="form-control">
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
                <asp:Label ID="StateErrorLbl" runat="server" Text="" ForeColor="Red" Font-Size="Small"></asp:Label>
            </div>

              <div class="col">
              <label for="formGroupExampleInput">Zip Code</label>
                    <asp:TextBox ID="ZipBox" runat="server" cssclass="form-control" placeholder="Zip Code"></asp:TextBox>
                  <asp:Label ID="ZipErrorLbl" runat="server" Text="" ForeColor="Red" Font-Size="Small"></asp:Label>
                  <asp:CompareValidator ID="ZipValidator" runat="server" ErrorMessage="" ControlToValidate="ZipBox" Text="Please enter a zip code." ForeColor="Red" Font-Size="Small" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
              </div> <!--end col-->
          </div> <!--end row class-->

            <div class="row">
            <div class="col">
               <label for="formGroupExampleInput" style="margin-top: 0rem;">Don't fret, only city, state, and zip code will appear on your profile to potential housemates.</label>
            </div><!--end col-->
          </div> <!--end row class-->


           <div class="row" style="margin-top: 3rem;">
            <div class="col">
              <label for="formGroupExampleInput">Monthly Price</label>
              <asp:TextBox ID="PriceBox" runat="server" cssclass="form-control" placeholder="000.00"></asp:TextBox>
                <asp:Label ID="PriceErrorLbl" runat="server" Text="" ForeColor="Red" Font-Size="Small"></asp:Label>
                <asp:CompareValidator ID="PriceValidator" runat="server" ErrorMessage="" ControlToValidate="PriceBox" Text="Please enter numbers greater than 0 only." Font-Size="Small" Operator="DataTypeCheck" Type="Currency" ForeColor="Red"></asp:CompareValidator>
            </div> <!--end col-->
               
            <div class="col">
                <label for="formGroupExampleInput" style="margin-top: 0rem;">Number of Current Residents</label>
                <asp:TextBox ID ="TNumBox" runat ="server" CssClass="form-control" placeholder="0"></asp:TextBox>
                <asp:Label ID="TNumErrorLbl" runat="server" Text="" ForeColor="Red" Font-Size="Small"></asp:Label>
                <asp:CompareValidator ID="TNumValidator" runat="server" ErrorMessage="" ControlToValidate="TNumBox" Operator="DataTypeCheck" Type="Integer" Text="Please enter a number." ForeColor="Red" Font-Size="Small"></asp:CompareValidator>
            </div> <!--end col-->

            <div class="col">
                <label for="formGroupExampleInput" style="margin-top: 0rem;">Neighborhood</label>
                <asp:TextBox ID ="NeighborhoodBox" runat ="server" CssClass="form-control" placeholder="Neighborhood"></asp:TextBox>
                <asp:Label ID="HoodErrorLbl" runat="server" Text="" ForeColor="Red" Font-Size="Small"></asp:Label>
            </div> <!--end col-->
          </div> <!--end row class-->

            <div class="row" style="margin-top: 3rem;">
            <div class="col">
              <label for="formGroupExampleInput">Expected Start Date (earliest potential date for a tenant to move in)</label>
              <asp:TextBox ID="EffectiveDateBox" runat="server" cssclass="form-control" placeholder="MM/DD/YYYY"></asp:TextBox>
                <asp:Label ID="eDateErrorLbl" runat="server" Text="" ForeColor="Red" Font-Size="Small"></asp:Label>
                <asp:CompareValidator ID="eDateValidator" runat="server" ErrorMessage="" ControlToValidate="EffectiveDateBox" Operator="DataTypeCheck" Type="Date" Font-Size="Small" Text="Date must be in MM/DD/YYYY format." ForeColor="Red"></asp:CompareValidator>
            </div> <!--end col-->
            <div class="col">
              <label for="formGroupExampleInput">Expected Termination Date (latest potential date for a tenant to move out)</label>
              <asp:TextBox ID="TerminationDateBox" runat="server" cssclass="form-control" placeholder="MM/DD/YYYY"></asp:TextBox>
                <asp:Label ID="tDateErrorLbl" runat="server" Text="" ForeColor="Red" Font-Size="Small"></asp:Label>
              <asp:CompareValidator ID="tDateValidator" runat="server" ErrorMessage="" ControlToValidate="TerminationDateBox" Operator="DataTypeCheck" Type="Date" Font-Size="Small" Text="Date must be in MM/DD/YYYY format." ForeColor="Red"></asp:CompareValidator>
            </div> <!--end col-->

            <div class="col">

            </div> <!--end col-->
          </div> <!--end row class-->


          <div class="row" style="margin-top: 3rem;">
            <div class="col">
              <label for="formGroupExampleInput">Give your property a name (Example: 1 Bedroom with Private Bathroom in Harrisonburg, VA)</label>
              <asp:TextBox ID="DescriptBox" runat="server" cssclass="form-control" placeholder="Property Name"></asp:TextBox>
                <asp:Label ID="DescriptErrorLbl" runat="server" Text="" ForeColor="Red" Font-Size="Small"></asp:Label>
            </div> <!--end col-->
          </div> <!--end row class-->

            <div class="row" style="margin-top: 3rem;">
            <div class="col">
                <label for="formGroupExampleInput">What Best Describes Your Property for Rent?</label>
                <asp:DropDownList ID="RoomTypeList" runat="server" cssclass="form-control">
                        <asp:ListItem Value="Select a Room Type">Select a Room Type</asp:ListItem>
                        <asp:ListItem Value="Private Room">Private Room</asp:ListItem>
                        <asp:ListItem Value="Sep Private Building">Seperate Private Building</asp:ListItem>
                        <asp:ListItem Value="Other">Other</asp:ListItem>
                    </asp:DropDownList>
                <asp:Label ID="RoomTypeErrorLbl" runat="server" Text="" ForeColor="Red" Font-Size="Small"></asp:Label>
            </div>

            <div class="col">
                <label for="formGroupExampleInput">If 'Other' please explain</label>
                <asp:TextBox ID="OtherBox" runat="server" cssclass="form-control"></asp:TextBox>
                <asp:Label ID="OtherErrorLbl" runat="server" Text="" ForeColor="Red" Font-Size="Small"></asp:Label>
            </div>

            <div class="col">

            </div> <!--end col-->
          </div> <!--end row class-->

            <!-- START OF PROPERTY AMENTITIES -->
            <div class="row" style="margin-top: 3rem">

            <div class="col">
                <!-- space holder -->
            </div> <!-- end col class -->

            <div class="col">
                <!-- space holder -->
            </div> <!-- end col class -->

                <div class ="col">
                    <h2>
                        <asp:Label ID="PropAmenLbl" runat="server" Text="Property Amenities (Please select all that apply.)" CssClass="text-nowrap"></asp:Label>
                    </h2>
                </div> <!-- end col class -->

            <div class="col">
                <!-- space holder -->
            </div> <!-- end col class -->

            <div class="col">
                <!-- space holder -->
            </div> <!-- end col class -->

            <div class="col">
                <!-- space holder -->
            </div> <!-- end col class -->

            </div> <!-- end of row class -->

            <div class="row" style="margin-top: 1rem;">
            <div class="col">
                <!-- space holder -->
            </div> <!-- end col class -->

            <div class="col">
                <label for="formGroupExampleInput">Private Bathroom?</label>
                <asp:CheckBox ID="PrivateBathroom" runat="server" />
                <asp:Label ID="BathroomErrorLbl" runat="server" Text="" ForeColor="Red" Font-Size="Small"></asp:Label>
            </div> <!-- end col class -->

            <div class="col">
                <label for="formGroupExampleInput">Private Entrance?</label>
                <asp:CheckBox ID="PrivateEntrance" runat="server"/>
                <asp:Label ID="EntranceErrorLbl" runat="server" Text="" ForeColor="Red" Font-Size="Small"></asp:Label>
            </div> <!--end col class-->

            <div class="col">
                <!-- space holder-->
            </div> <!--end col-->

          </div> <!--end row class-->
            <div class="row" style ="margin-top: 1rem;">
                <div class="col">
                    <!-- space holder -->
                </div> <!-- end col class -->

                <div class="col">
                    <label for="formGroupExampleInput">Closet/Storage Space?</label>
                <asp:CheckBox ID="StorageSpace" runat="server" />
                <asp:Label ID="StorageErrorLbl" runat="server" Text="" ForeColor="Red" Font-Size="Small"></asp:Label>
                </div> <!-- end col class-->

                <div class="col">
                    <label for="formGroupExampleInput">Private Parking?</label>
                    <asp:CheckBox ID="Parking" runat="server" />
                    <asp:Label ID="ParkingErrorLbl" runat="server" Text="" ForeColor="Red" Font-Size="Small"></asp:Label>
                </div> <!-- end col class -->

                <div class="col">
                <!-- space holder -->
            </div> <!-- end col class -->

            </div> <!-- end row class-->

            <div class="row" style="margin-top: 1rem;">

            <div class="col">
                <!-- space holder -->
            </div> <!-- end of col class-->

            <div class="col">
                <label for="formGroupExampleInput">Furnished?</label>
                <asp:CheckBox ID="Furnished" runat="server" />
                <asp:Label ID="FurnishedErrorLbl" runat="server" Text="" ForeColor="Red" Font-Size="Small"></asp:Label>
            </div> <!-- end col class -->

            <div class="col">
                <label for="formGroupExampleInput">Allow Smokers?</label>
                <asp:CheckBox ID="Smoker" runat="server" />
                <asp:Label ID="SmokerErrorLbl" runat="server" Text="" ForeColor="Red" Font-Size="Small"></asp:Label>
            </div> <!-- end col class-->

            <div class="col">
                <!-- space holder -->
            </div> <!-- end of col class-->

          </div> <!--end row class-->             

            <div class="row" style="margin-top: 1rem;">

            <div class="col">
                <!-- space holder -->
            </div> <!-- end of col class-->

             <div class="col">
                <label for="formGroupExampleInput">Pets in Residence?</label>
                 <asp:CheckBox ID="HavePets" runat="server" />
                <asp:Label ID="PetsErrorLbl" runat="server" Text="" ForeColor="Red" Font-Size="Small"></asp:Label>
             </div> <!-- end col class-->

            <div class="col">
                <label for="formGroupExampleInput">Allow Pets?</label>
                <asp:CheckBox ID="AllowPets" runat="server" />
                <asp:Label ID="AllowPetsErrorLbl" runat="server" Text="" ForeColor="Red" Font-Size="Small"></asp:Label>
            </div> <!--end col-->

            <div class="col">
                <!-- space holder -->
            </div> <!-- end of col class-->

            </div> <!--end row class-->


            <div class="row" style="margin-top: 1rem;">

            <div class="col">
                <!-- space holder -->
            </div> <!-- end of col class-->

            <div class="col">
                <label for="formGroupExampleInput">Private Kitchen?</label>
                <asp:CheckBox ID="PrivateKitchen" runat="server" />
                <asp:Label ID="KitchenErrorLbl" runat="server" Text="" ForeColor="Red" Font-Size="Small"></asp:Label>
            </div> <!-- end col class-->

            <div class="col">
                <label for="formGroupExampleInput">Laundry Access?</label>
                <asp:CheckBox ID="PrivateLaundry" runat="server" />
                <asp:Label ID="LaundryErrorLbl" runat="server" Text="" ForeColor="Red" Font-Size="Small"></asp:Label>
            </div> <!--end col-->

            <div class="col">
                <!-- space holder -->
            </div> <!-- end of col class-->

            </div> <!-- end row class -->

            <div class="row" style="margin-top: 1rem;">

            <div class="col">
                <!-- space holder -->
            </div> <!-- end of col class-->

            <div class="col">
                <label for="formGroupExampleInput">Wifi?</label>
                <asp:CheckBox ID="Wifi" runat="server" />
                <asp:Label ID="WifiErrorLbl" runat="server" Text="" ForeColor="Red" Font-Size="Small"></asp:Label>
            </div> <!-- end of col class-->

            <div class="col">
                <label for="formGroupExampleInput">Cable TV?</label>
                <asp:CheckBox ID="CableTV" runat="server" />
                <asp:Label ID="CableErrorLbl" runat="server" Text="" ForeColor="Red" Font-Size="Small"></asp:Label>
            </div> <!-- end of col class-->

            <div class="col">
                <!-- space holder -->
            </div> <!-- end of col class-->

          </div> <!--end row class-->


            <div class="row" style="margin-top: 3rem;">
            <div class="col">
                <label for="formGroupExampleInput">Please describe your property in detail (this can be edited later)</label>
                <asp:TextBox ID="ExtraInfoBox" runat="server" CssClass="form-control" Height = "200px" TextMode ="MultiLine"></asp:TextBox>
            </div> <!--end col-->
          </div> <!--end row class-->

        </form> <!--end form-->
        <br>
        
        <div class="row" style="margin-bottom: 3rem;"> 
          <div class="col-md-6"></div>
            
             <div class="col-md-6">
                 
                 <asp:Button ID="NextButton" runat="server" Text="Next" CausesValidation="True" OnClick="NextButton_Click" CssClass="btn" style="float: right; margin-right: 2rem"/>
                 &nbsp;&nbsp;
                 <asp:Button ID="SkipButton" runat="server" Text="Skip & Continue" CausesValidation="True" OnClick="SkipButton_Click" CssClass="btn btn-secondary" style="float: right; margin-right: 1rem;"/>
                 <asp:Button ID="PopulateButton" runat="server" Text="Populate" CausesValidation="False" OnClick="PopulateButton_Click" CssClass="btn" style="float: right; margin-right: 1rem;"/>
             </div>
                <asp:Label ID="OutputLabel" runat="server" Text=""></asp:Label>
            
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
</asp:Content>

