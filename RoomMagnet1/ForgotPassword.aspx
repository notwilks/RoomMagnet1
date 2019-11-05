<%@ Page Title="" Language="C#" MasterPageFile="~/RoomMagnet.master" AutoEventWireup="true" CodeFile="ForgotPassword.aspx.cs" Inherits="ForgotPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">  
        <!DOCTYPE html>

<html>
<body>
    
    <form id="form1" runat="server" style="margin-top: 8rem;">    
    <div class="container">
            <h1 style="margin-bottom: 3rem;">Change Password</h1>
            <asp:Label ID="ForgotPass" runat="server" Text="Enter Email: "></asp:Label>
            <asp:TextBox ID="emailField" Width="250px" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="container">            
            <asp:Button ID="GetPass" runat="server" OnClick="GetPass_Click" Text="Send Reset Password Link" CssClass="btn" style="margin-top: 1rem;"/>    
        </div>
        <div class="container">
            <asp:Label ID="outputField" runat="server" Text=""></asp:Label>
        </div>
        </form>

</body>
</html>
</asp:Content>

