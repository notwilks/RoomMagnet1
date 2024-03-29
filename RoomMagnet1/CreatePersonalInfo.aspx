﻿<%@ Page Title="" Language="C#" MasterPageFile="~/RoomMagnet.master" AutoEventWireup="true" CodeFile="CreatePersonalInfo.aspx.cs" Inherits="CreatePersonalInfo" %>

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
        <h1>Tell us about yourself.</h1>
        <p>Let us find you the perfect space.</p>
      </div>

    </header>

    <section id="creation"">
      <div class="container">
        <form>

            <div class="row">
                    <div class="col promar" >
                        <div class="progress" >
                            <div class="progress-bar progress-bar-striped" role="progressbar" style="width: 50%; background-color: #CC6559" aria-valuenow="25" ></div>
                        </div>
                    </div><!--end col-->
               </div><!--end row class-->

          <div class="row">
            <div class="col">
              <label for="formGroupExampleInput"  style="margin-top: 4rem;">First Name</label>
                <asp:TextBox ID="FirstNameBox" runat="server" MaxLength ="25" CssClass="form-control" placeholder="First Name"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="FirstNameBox" ErrorMessage="This field is required" Font-Size="Small" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="FirstNameBox" Font-Size="Small" Operator="DataTypeCheck" ForeColor="Red" Type="String" Text ="Invalid characters" />
            </div> <!-- end col class-->

            <div class="col">
              <label for="formGroupExampleInput" style="margin-top: 4rem;">Last Name</label>
              <asp:TextBox ID="LastNameBox" runat="server" MaxLength ="25" CssClass="form-control" placeholder="Last Name"></asp:TextBox>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="LastNameBox" ErrorMessage="This field is required" Font-Size="Small" ForeColor="Red"></asp:RequiredFieldValidator>
              <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="LastNameBox" Text="Invalid characters" Font-Size="Small" Operator="DataTypeCheck" ForeColor="Red">Invalid characters</asp:CompareValidator>
            </div> <!--end col-->
          </div> <!--end row class-->
          
          <div class="row">          
            <div class="col">
              <label for="formGroupExampleInput">Date of Birth</label>
              <asp:TextBox ID="dobBox" runat="server" placeholder ="MM/DD/YYYY" CssClass="form-control"></asp:TextBox>
              <asp:Label ID="dobErrorLbl" runat="server" Text="" ForeColor="Red" Font-Size="Small"></asp:Label>
              <asp:RequiredFieldValidator ID="DoBValidator" runat="server" ControlToValidate="dobBox" ErrorMessage="This field is required" Font-Size="Small" ForeColor="Red"></asp:RequiredFieldValidator>
              <asp:CompareValidator ID="DoBCompareValidator" runat="server" ControlToValidate="dobBox" Text="Please enter date in 'MM/DD/YYYY' format." Type="Date" Operator="DataTypeCheck" Font-Size="Small" ForeColor="Red"></asp:CompareValidator>
            </div> <!--end col-->
            <div class="col">
            
            </div> <!--end col-->
          </div> <!--end row class-->
         <div class="row">
             <div class="col">
              <label for="formGroupExampleInput" >Gender</label>
              <asp:DropDownList ID="DropDownList1" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true" runat="server" CssClass="form-control btn btn-outline-secondary">                     
                            <asp:ListItem Value="">Select Option:</asp:ListItem>
                            <asp:ListItem Value="F">Female</asp:ListItem>
                            <asp:ListItem Value="M">Male</asp:ListItem>
                            <asp:ListItem Value="O">Other</asp:ListItem>
                        </asp:DropDownList>
              <asp:RequiredFieldValidator ID="SelectGender" runat="server" ControlToValidate="DropDownList1" InitialValue="" ErrorMessage="Please Select Gender" Font-Size="Small" ForeColor="Red" />
             </div><!-- end col class-->
             <div class="col">
                <label for="formGroupExampleInput" id="OtherGenderLbl" runat="server" visible="false" >Other</label>
                <asp:TextBox ID="OtherGenderBox" runat="server" visible="false" cssclass="form-control"></asp:TextBox>
                <asp:Label ID="GenderErrorLbl" runat="server" Text="" ForeColor="Red" Font-Size="Small"></asp:Label>
            </div><!-- end col class -->
             
         </div>

          <div class="row">
            <div class="col">
              <label for="formGroupExampleInput">Phone Number</label>
              <asp:TextBox ID="phoneNumberBox" runat="server" placeholder ="###-###-####" CssClass="form-control"></asp:TextBox>
                <asp:Label ID="pNumBoxErrorLbl" runat="server" Text="" ForeColor="Red" Font-Size="Small"></asp:Label>
                <asp:RequiredFieldValidator ID="PhoneNumberValidator" runat="server" ControlToValidate="phoneNumberBox" ErrorMessage="This field is required" Font-Size="Small" ForeColor="Red"></asp:RequiredFieldValidator>
            </div> <!-- end col class-->
            <div class="col">
            
            </div> <!--end col-->
          </div> <!--end row class-->

        <div class="row">
            <div class="col">
                <label for="formGroupExampleInput" id="TenantTypeLbl" runat="server">Tenant Type</label>
                <asp:DropDownList ID="TenantTypeBox"   OnSelectedIndexChanged="TenantTypeBox_SelectedIndexChanged" AutoPostBack="true" runat="server" CssClass="form-control btn btn-outline-secondary">
                    <asp:ListItem Value ="">Select A Tenant Type</asp:ListItem>
                    <asp:ListItem Value ="Medical">Medical Student</asp:ListItem>
                    <asp:ListItem Value ="Doctorate">Docorate Student</asp:ListItem>
                    <asp:ListItem Value ="Undergraduate">Undergraduate Student</asp:ListItem>
                    <asp:ListItem Value ="Graduate">Graduate Student</asp:ListItem>
                    <asp:ListItem Value ="Other">Other</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="SelectTenantType" runat="server" ControlToValidate="TenantTypeBox" InitialValue="" ErrorMessage="Please Select Tenant Type" Font-Size="Small" ForeColor="Red" />
             </div> <!-- end col class -->
            <div class="col">
                <label for="formGroupExampleInput" id="OtherTenantLbl" visible="false" runat="server">Other</label>
                <asp:TextBox ID="OtherTBox" runat="server" visible="false" cssclass="form-control"></asp:TextBox>
                <asp:Label ID="OtherErrorLbl" runat="server" Text="" ForeColor="Red" Font-Size="Small"></asp:Label>
            </div>
        </div> <!--end row class-->

        <div class="row">
            <div class="col">
              <label for="formGroupExampleInput" style="margin-top:2rem;">Biography</label>
              <asp:TextBox ID="bioBox" runat="server" placeholder ="Please write a short description about yourself." CssClass="form-control" Height="150px" TextMode="MultiLine"></asp:TextBox>
                <asp:Label ID="bioBoxErrorLbl" runat="server" Text="" ForeColor="Red" Font-Size="Small"></asp:Label>
                <asp:RequiredFieldValidator ID="BioValidator" runat="server" ControlToValidate="bioBox" ErrorMessage="This field is required" Font-Size="Small" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
          </div> <!--end row class-->

        </form> <!--end form-->
        <br>
        
        <div class="row" style="margin-bottom: 3rem;"> 
          <div class="col-md-6"></div>
            
             <div class="col-md-6">
                 <asp:Button ID="Button1" runat="server" Text="Next" CausesValidation="True" CssClass="btn" style="float: right; margin-right: 1rem;" OnClick="Button1_Click1"/>
                 <asp:Button ID="Button2" runat="server" Text="Populate" CausesValidation="False" CssClass="btn" style="float: right; margin-right: 1rem;" OnClick="PopulateBtn_Click"/>
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

