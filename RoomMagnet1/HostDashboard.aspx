<%@ Page Title="" Language="C#" MasterPageFile="~/RoomMagnet.master" AutoEventWireup="true" CodeFile="HostDashboard.aspx.cs" Inherits="HostDashboard" %>

<asp:Content ID="HostDashboard" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="form2" style="margin-top: 7rem;" runat="server">
        <div class="" style="float:right;">
                <asp:label ID = "navBarName" runat="server" text="" CssClass=""></asp:label>
        &ensp;
            <asp:button ID ="logoutButton" runat="server" text="Logout" Height="30px" Width="67px" cssclass="form-control btn btn-sm btn-outline-warning" OnClick="logoutButton_Click"/>
        &nbsp;
        </div>
    <h1><asp:Label ID="Header" runat="server" Text="Welcome" CssClass="container"></asp:Label></h1>
    <h3><asp:Label ID="ProfileHeader" runat="server" Text="Your Profile" CssClass="container"></asp:Label>
        <asp:Button ID="EditProfileBtn" runat="server" OnClick="EditProfileBtn_Click" Text="Edit Profile" />
    </h3>
        
    </form>
</asp:Content>

