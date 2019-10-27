<%@ Page Title="" Language="C#" MasterPageFile="~/RoomMagnet.master" AutoEventWireup="true" CodeFile="ForgotPassword.aspx.cs" Inherits="ForgotPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">  
    <form id="form1" runat="server">    
    <div>
            <asp:Label ID="ForgotPass" runat="server" Text="Enter Email:"></asp:Label>
            <asp:TextBox ID="emailField" Width="250px" runat="server"></asp:TextBox>
        </div>
        <div>            
            <asp:Button ID="GetPass" runat="server" OnClick="GetPass_Click" Text="Send Reset Password Link" />    
        </div>
        <div>
            <asp:Label ID="outputField" runat="server" Text=""></asp:Label>
        </div>
        </form>
</asp:Content>

