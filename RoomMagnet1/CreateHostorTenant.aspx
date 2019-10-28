<%@ Page Title="" Language="C#" MasterPageFile="~/RoomMagnet.master" AutoEventWireup="true" CodeFile="CreateHostorTenant.aspx.cs" Inherits="CreateHostorTenant" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <!DOCTYPE html>
        <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 91px;
        }
        .auto-style3 {
            width: 259px;
        }
    </style>
<html>
    <title>RoomMagnet - Create Account</title>
<body>
<div class="container">

<form id="form1" style="margin-top: 6rem;" runat="server">
    <br />
    <asp:Label ID="label1" runat="server" Text="I would like to:"></asp:Label>

    <br />

    <asp:Button ID="hostButton" runat="server" Text="Host my room" cssclass="btn btn-outline-warning" OnClick="hostButton_Click"/>

    <br />
    <br />

    <asp:Button ID="tenantButton" runat="server" Text="Find a place to live" cssclass="btn btn-outline-warning" OnClick="tenantButton_Click"/>


    </form>
</div>
</body>
</html> 
</asp:Content>

