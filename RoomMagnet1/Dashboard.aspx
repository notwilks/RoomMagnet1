<%@ Page Title="" Language="C#" MasterPageFile="~/RoomMagnet.master" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="HostDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="form2" runat="server">
        <div class="" style="float:right;">
                <asp:label ID = "navBarName" runat="server" text="" CssClass=""></asp:label>
        &ensp;
            <asp:button ID ="logoutButton" runat="server" text="Logout" Height="30px" Width="67px" cssclass="form-control btn btn-sm btn-outline-warning" OnClick="logoutButton_Click"/>
        &nbsp;
        </div>
    <h1><asp:Label ID="Header" runat="server" Text="Welcome" CssClass="container"></asp:Label></h1>
    <h3><asp:Label ID="welcome" runat="server" Text="" CssClass="container"></asp:Label></h3>
        
    </form>
</asp:Content>

