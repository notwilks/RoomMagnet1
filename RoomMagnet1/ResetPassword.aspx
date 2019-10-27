<%@ Page Title="" Language="C#" MasterPageFile="~/RoomMagnet.master" AutoEventWireup="true" CodeFile="ResetPassword.aspx.cs" Inherits="ResetPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="form1" runat="server">
    <div>
            <h2>Reset Password</h2>

        </div>
        <asp:Label ID="newPass" Width="150px" runat="server" Text="New Password"/>
        <asp:TextBox ID="newPassField" Width="150px" runat="server" />
        <br />
        <asp:Label ID="confirmPass" Width="150px" runat="server" Text="Confirm Password" />
        <asp:TextBox ID="confirmPassField" runat="server"/>
        <br />
        <asp:Button ID="changePassBtn" runat="server" OnClick="changePassBtn_Click" Text="Change Password" />
        <asp:Label ID="outputField" runat="server" Text=""></asp:Label>
        </form>
</asp:Content>

