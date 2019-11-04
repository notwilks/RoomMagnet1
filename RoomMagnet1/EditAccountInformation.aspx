<%@ Page Title="" Language="C#" MasterPageFile="~/RoomMagnet.master" AutoEventWireup="true" CodeFile="EditAccountInformation.aspx.cs" Inherits="EditAccountInformation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <form id="form1" style="margin-top: 7rem;" runat="server">
        <header style="margin-top: 8rem;">
      <div class="container">
        <h1>Edit Personal Information</h1>
          <p style="color:dimgrey">*Phone number is not displayed to potential hosts.*</p>
      </div>
</header>

        <section id="creation" style="margin-top: 2rem;">
            <div class="container">

                <div class="row" style="margin-top: 2rem">
                    <div class="col">
                        <label for="formGroupExampleInput">First Name</label>
                        <asp:TextBox ID="FirstNameBox" runat="server" MaxLength ="25" CssClass="form-control"></asp:TextBox>       
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="FirstNameBox" ErrorMessage="This field is required" Font-Size="Small" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="FirstNameBox" Font-Size="Small" Operator="DataTypeCheck" ForeColor="Red" Type="String" Text ="Invalid characters" />
                    </div>
                    <div class="col">
                        <label for="formGroupExampleInput">Last Name</label>
                        <asp:TextBox ID="LastNameBox" runat="server" MaxLength ="25" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="LastNameBox" ErrorMessage="This field is required" Font-Size="Small" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="LastNameBox" Text="Invalid characters" Font-Size="Small" Operator="DataTypeCheck" ForeColor="Red">Invalid characters</asp:CompareValidator>
                    </div> <!--end col-->
                </div> <!--end row class-->

                <div class="row" style="margin-top: 2rem">
                    <div class="col">
                        <label for="formGroupExampleInput">Gender</label>
                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control">
                            <asp:ListItem Value="M">Male</asp:ListItem>
                            <asp:ListItem Value="F">Female</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col">
                        <label for="formGroupExampleInput">Date of Birth</label>
                        <asp:TextBox ID="dobBox" runat="server" placeholder ="MM/DD/YYY" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="dobBox" ErrorMessage="This field is required" Font-Size="Small" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="dobBox" Text="Invalid DOB" Type="Date" Operator="DataTypeCheck" Font-Size="Small" ForeColor="Red" Display="Static"></asp:CompareValidator>
                    </div> <!--end col-->
                </div> <!--end row class-->

                <div class="row" style="margin-top: 2rem">
                    <div class="col">
                        <label for="formGroupExampleInput">Phone Number</label>
                        <asp:TextBox ID="phoneNumberBox" runat="server" placeholder ="xxx-xxx-xxxx" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col">

                    </div> <!--end col-->
                </div> <!--end row class-->

                <div class="row" style="margin-top: 2rem">
                    <div class="col">
                        <label for="formGroupExampleInput">Upload your profile picture</label><br />
                        <asp:FileUpload ID="mainImage" runat="server" CssClass="form-control"/>
                    </div>
                        
                    <div class="col">
                        <label for="formGroupExampleInput">Upload more images of yourself</label>
                        <asp:FileUpload ID="image2" runat="server" CssClass="form-control"/>
                        <asp:FileUpload ID="image3" runat="server" CssClass="form-control" style="margin-top: 1rem;"/>
                    </div> <!--end col-->
                </div> <!--end row class-->

                <div class="row" style="margin-top: 2rem">
                    <div class="col">
                        <asp:Button ID="Button1" runat="server" Text="Update Information" OnClick="Button1_Click" CausesValidation="False" CssClass="btn"/>
                    </div>
                    <div class="col">
                        <asp:Label ID="OutputLabel" runat="server" Text=""></asp:Label>
                    </div> <!--end col-->
                </div> <!--end row class-->

                
 
                </div>
            </section>
    </form>
    <h2></h2>
</asp:Content>

