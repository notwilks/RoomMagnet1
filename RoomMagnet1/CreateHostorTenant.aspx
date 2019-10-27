<%@ Page Title="" Language="C#" MasterPageFile="~/RoomMagnet.master" AutoEventWireup="true" CodeFile="CreateHostorTenant.aspx.cs" Inherits="CreateHostorTenant" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <!DOCTYPE html>

<html>

    <title>RoomMagnet - Create Account</title>
<body>
<div class="container"
<form id="form1" runat="server">
    <br />
    <asp:Label ID="label1" runat="server" Text="I would like to:"></asp:Label>

    <br />

    <asp:Button ID="hostButton" runat="server" Text="Host my room" cssclass="btn btn-outline-warning" OnClick="hostButton_Click"/>

    <br />
    <br />

    <asp:Button ID="tenantButton" runat="server" Text="Find a place to live" cssclass="btn btn-outline-warning" OnClick="tenantButton_Click"/>

</div>
    </form>
</body>
</html> 
</asp:Content>

