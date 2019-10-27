<%@ Page Title="" Language="C#" MasterPageFile="~/RoomMagnet.master" AutoEventWireup="true" CodeFile="LoginPage.aspx.cs" Inherits="LoginPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!DOCTYPE html>

<html>

    <title>RoomMagnet - Login</title>
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
    <h1 class="container">Login</h1>

<body>
    <form id="form1" runat="server">
        <div class ="container">
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label1" runat="server" Text="Email: "></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:TextBox ID="EmailBox" runat="server" Width="208px" CssClass="form-control"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label2" runat="server" Text="Password: "></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:TextBox ID="PasswordBox" runat="server" Width="207px" TextMode ="Password" CssClass="form-control" OnTextChanged="PasswordBox_TextChanged"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="OutputLabel" runat="server" Text=""></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style3"><a href="ForgotPassword.aspx">Forgot Password?</a></td>
                        
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>                     
                    <td class="auto-style3">
                        <asp:Button ID="LoginButton" runat="server" Text="Login" Width="73px" OnClick="LoginButton_Click" cssclass="form-control btn btn-outline-success my-2 my-sm-0 form-inline"/>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
</asp:Content>

