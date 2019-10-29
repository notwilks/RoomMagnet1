﻿<%@ Page Title="" Language="C#" MasterPageFile="~/RoomMagnet.master" AutoEventWireup="true" CodeFile="CreateProperty.aspx.cs" Inherits="CreateProperty" %>

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
            <div class="col">
              
            </div> <!--end col-->
          </div> <!--end row class-->

          <div class="row">
            <div class="col">
               <label for="formGroupExampleInput" style="margin-top: 3rem;">Street Address</label>
                <asp:TextBox ID="AddressBox" runat="server" cssclass="form-control" placeholder="Street Address"></asp:TextBox>
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
            </div>

              <div class="col">
              <label for="formGroupExampleInput">Zip Code</label>
                    <asp:TextBox ID="ZipBox" runat="server" cssclass="form-control" placeholder="Zip Code"></asp:TextBox>
              </div> <!--end col-->
          </div> <!--end row class-->

            <div class="row">
            <div class="col">
               <label for="formGroupExampleInput" style="margin-top: 0rem;">Don't fret, only city, state, and zip code will appear on your profile to potential housemates.</label>
            </div><!--end col-->
          </div> <!--end row class-->

          <div class="row" style="margin-top: 3rem;">
            <div class="col">
              <label for="formGroupExampleInput">Give your property a name (Example: 1 Bedroom with Private Bathroom in Harrisonburg, VA)</label>
              <asp:TextBox ID="DescriptBox" runat="server" cssclass="form-control" placeholder="Property Name"></asp:TextBox>
            </div> <!--end col-->
          </div> <!--end row class-->

            <div class="row" style="margin-top: 3rem;">

            <div class="col">
                <label for="formGroupExampleInput">What Best Describes Your Property for Rent?</label>
                <asp:DropDownList ID="RoomTypeList" runat="server" cssclass="form-control">
                        <asp:ListItem>Private Room</asp:ListItem>
                        <asp:ListItem>Seperate Private Building</asp:ListItem>
                        <asp:ListItem Value="Other">Other</asp:ListItem>
                    </asp:DropDownList>
            </div>

            <div class="col">
                <label for="formGroupExampleInput">If 'Other' please explain</label>
                <asp:TextBox ID="OtherBox" runat="server" cssclass="form-control"></asp:TextBox>
            </div>

            <div class="col">

            </div> <!--end col-->


          </div> <!--end row class-->

            <div class="row" style="margin-top: 3rem;">

            <div class="col">
                <label for="formGroupExampleInput">Does the space have a private bathroom?</label>
                <asp:RadioButtonList ID="PrivateBathroom" runat="server" RepeatDirection="Horizontal" Width="200px">
                        <asp:ListItem Value="T">Yes</asp:ListItem>
                        <asp:ListItem Value="F">No</asp:ListItem>
                    </asp:RadioButtonList>
            </div>

            <div class="col">
                <label for="formGroupExampleInput">Does the space have a private entrance?</label>
                <asp:RadioButtonList ID="PrivateEntrance" runat="server" RepeatDirection="Horizontal" Width="200px">
                        <asp:ListItem Value="T">Yes</asp:ListItem>
                        <asp:ListItem Value="F">No</asp:ListItem>
                    </asp:RadioButtonList>
            </div>

            <div class="col">
                <label for="formGroupExampleInput">Does the space have closet/storage space?</label>
                <asp:RadioButtonList ID="StorageSpace" runat="server" RepeatDirection="Horizontal" Width="200px">
                        <asp:ListItem Value="T">Yes</asp:ListItem>
                        <asp:ListItem Value="F">No</asp:ListItem>
                    </asp:RadioButtonList>
            </div> <!--end col-->


          </div> <!--end row class-->

            <div class="row" style="margin-top: 3rem;">

            <div class="col">
                <label for="formGroupExampleInput">Is the space furnished?</label>
                <asp:RadioButtonList ID="Furnished" runat="server" RepeatDirection="Horizontal" Width="200px">
                        <asp:ListItem Value="T">Yes</asp:ListItem>
                        <asp:ListItem Value="F">No</asp:ListItem>
                    </asp:RadioButtonList>
            </div>

            <div class="col">
                <label for="formGroupExampleInput">Do you smoke/allow smokers?</label>
                <asp:RadioButtonList ID="Smokers" runat="server" RepeatDirection="Horizontal" Width="200px">
                        <asp:ListItem Value="T">Yes</asp:ListItem>
                        <asp:ListItem Value="F">No</asp:ListItem>
                    </asp:RadioButtonList>
            </div>

            <div class="col">
                <label for="formGroupExampleInput">Do you have pets?</label>
                <asp:RadioButtonList ID="Pets" runat="server" RepeatDirection="Horizontal" Width="200px">
                        <asp:ListItem Value="T">Yes</asp:ListItem>
                        <asp:ListItem Value="F">No</asp:ListItem>
                    </asp:RadioButtonList>
                
               
            </div> <!--end col-->


          </div> <!--end row class-->

            <div class="row" style="margin-top: 3rem;">
            <div class="col">
                <label for="formGroupExampleInput">Please describe your property in detail (this can be edited later)</label>
                <asp:TextBox ID="ExtraInfoBox" runat="server" CssClass="form-control" Height = "200px"></asp:TextBox>
            </div> <!--end col-->
          </div> <!--end row class-->

        </form> <!--end form-->
        <br>
        
        <div class="row" style="margin-bottom: 3rem;"> 
          <div class="col-md-6"></div>
            
             <div class="col-md-6">
                 
                 <asp:Button ID="NextButton" runat="server" Text="Next" CausesValidation="True" CssClass="btn" style="float: right; margin-right: 2rem"/>
                 &nbsp;&nbsp;
                 <asp:Button ID="SkipButton" runat="server" Text="Skip For Now" CausesValidation="True" OnClick="SkipButton_Click" CssClass="btn btn-secondary" style="float: right;"/>
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
