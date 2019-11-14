<%@ Page Title="" Language="C#" MasterPageFile="~/RoomMagnet.master" AutoEventWireup="true" CodeFile="MessageCenter.aspx.cs" Inherits="MessageCenter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!DOCTYPE html>

   
    <html>

        <script type="text/javascript">
    function ShowPopup(title, body) {
        $("#MyPopup .modal-title").html(title);
        $("#MyPopup .modal-body").html(body);
        $("#MyPopup").modal("show");
    }
</script>

    <head>
        <title>RoomMagnet - Create Account</title>
        <!-- Bootstrap v4 -->
        <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" media="screen">
        <!-- custom css -->
        <link href="css/custom.css" rel="stylesheet" type="text/css" media="screen">
        <link rel="shortcut icon" href="images/logo-03.png" type="image/x-icon" />
        <link href="https://fonts.googleapis.com/css?family=Oswald:400|Raleway:300&display=swap" rel="stylesheet">
    </head>
    <body>

        
            <form id="form1" runat="server">

                <section id="creation">
                    <div class="container">

                        <div class="row">
                            <div class="col promar">
                                <asp:Label ID="Label1" runat="server" Text="Enter a message"></asp:Label>
                            </div>
                        </div>
                        <!--end col-->
                    </div>
                    <!--end row class-->

                    <div class="row" style="margin-top: 10rem;">
                        <div class="col align-content-center">
                            <asp:TextBox ID="txtBoxMessage" runat="server" Text="Message Text"></asp:TextBox>
                            <asp:TextBox ID="txtBoxSubject" runat="server" Text="Subject"></asp:TextBox>
                            <asp:Button ID="btnSendMessage" runat="server" Text="Send Message" OnClick="btnSendMessage_click" />
                            <asp:DropDownList ID="dropdownContacts" runat="server" Width="200px">
                                <asp:ListItem Text="Choose someone to contact" Selected="true"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <br />

                    <div class="row" style="background-color: #ebebeb; margin-top: 1rem; margin-bottom: 1rem; padding-bottom: 1rem;" id="mesagesModule" runat="server">
                        <div class="col-md-1">
                        </div>
                        <div class="col-md-10" id="messages" runat="server">
                            <h3 style="border-bottom: solid; margin-bottom: 2rem">Your New Messages</h3>

                            <div class="row">
                                <div class="col-md-4">
                                    <h5>From</h5>
                                </div>
                                <div class="col-md-4">
                                    <h5>Subject</h5>
                                </div>
                                <div class="col-md-2">
                                    <h5>Action</h5>
                                </div>

                            </div>
                            <!-- end col class-->

                        </div>


                        <div class="col-md-1">
                        </div>

                    </div>
                    <!--end row class-->



<!-- Modal Popup -->
<div id="MyPopup" class="modal fade" role="dialog">
    <div class="modal-dialog">
        <!-- Modal content-->
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal">
                    &times;</button>
                <h4 class="modal-title">
                </h4>
            </div>
            <div class="modal-body">
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-danger" data-dismiss="modal">
                    Close</button>
            </div>
        </div>
    </div>
</div>


                    <!--end container-->
                </section>
            </form>
        
        <footer class="footer mt-auto py-3 footer-expand-lg">
            <!-- start footer! -->
            <div class="row" style="padding-left: 3rem;">
                <div class="col-md-4" style="padding-left: 3rem;">
                    <h3 class="din">Room Magnet</h3>
                    <p>
                        Support:<br>
                        540-123-4567<br>
                        <a href="mailto:help@roommagnet.com">help@roommagnet.com</a>
                    </p>
                </div>

                <div class="col-md-4" style="padding-left: 3rem;">
                    <h4 class="din">Site Map</h4>
                    <p>
                        <a href="#">Home-Owners</a><br>
                        <a href="#">Tenants</a><br>
                        <a href="#">Safety</a><br>
                        <a href="#">FAQ</a><br>
                        <a href="#">Contact Us</a>
                    </p>
                </div>

                <div class="col-md-4" style="padding-left: 3rem;">
                    <h4 class="din">Stay Connected</h4>
                    <p>
                        <a href="#">
                            <img src="images/social-icons-02.png" class="img-fluid" style="max-width: 180px;"></a>
                    </p>
                </div>

            </div>
        </footer>
        <!-- end footer! -->
    </body>

    </html>
</asp:Content>

