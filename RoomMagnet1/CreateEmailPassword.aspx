<%@ Page Title="" Language="C#" MasterPageFile="~/RoomMagnet.master" AutoEventWireup="true" CodeFile="CreateEmailPassword.aspx.cs" Inherits="CreateEmailandPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <!DOCTYPE html>
<html>

<body>
<div class="container">
<form id="form1" style="margin-top: 7rem;" runat="server">
    <h4>Create Email and Password</h4>
    <br />
    <asp:Label ID="Label1" runat="server" Text="Email:"></asp:Label>
    <asp:TextBox ID="EmailBox" runat="server" Width="225px" CssClass="form-control"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="EmailBox" ErrorMessage="This field is required" Font-Size="Small" ForeColor="Red"></asp:RequiredFieldValidator>

    <br />

    <asp:Label ID="Label4" runat="server" Text="Password: "></asp:Label>

    <asp:TextBox ID="PasswordBox" runat="server" Width="218px" TextMode ="Password" CssClass="form-control"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="PasswordBox" ErrorMessage="This field is required" Font-Size="Small" ForeColor="Red"></asp:RequiredFieldValidator>
        
    <br />
              
    <asp:Label ID="Label5" runat="server" Text="Confirm Password: " ></asp:Label>
                   
    <asp:TextBox ID="ConfirmPasswordBox" runat="server" Width="219px" TextMode ="Password" CssClass="form-control" OnTextChanged="ConfirmPasswordBox_TextChanged"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ConfirmPasswordBox" ErrorMessage="This field is required" Font-Size="Small" ForeColor="Red"></asp:RequiredFieldValidator>

    <br />

    <asp:Button ID="nextButton" runat="server" Text="Next" cssclass="btn btn-outline-success" OnClick="nextButton_Click"/>

    <br />
    <br />

    <asp:Label ID="OutputLabel" runat="server" Text="" CssClass="alert-danger"></asp:Label>
    </form>
</div>
    
</body>
</html>                    
</asp:Content>

