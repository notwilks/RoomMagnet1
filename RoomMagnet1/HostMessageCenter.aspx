﻿<%@ Page Title="" Language="C#" MasterPageFile="~/RoomMagnet.master" AutoEventWireup="true" CodeFile="HostMessageCenter.aspx.cs" Inherits="HostMessageCenter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!doctype html>

    <script type="text/javascript">
        function ShowPopup() {

            $("#composeMessageModal").modal("show");
        }
        function ClosePopup() {

            $('#composeMessageModal').modal('hide');
            location.reload();
        }
       


    </script>

    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js" integrity="sha384-ZMP7rVo3mIykV+2+9J3UJ46jBk0WLaUAdn689aCwoqbBJiSnjAK/l8WvCWPIPm49" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js" integrity="sha384-ChfqqxuZUCnJSK3+MXmPNIyE6ZbWh2IMqE241rYiqJxyMiZ6OW/JmZQ5stwEULTy" crossorigin="anonymous"></script>


<html>
    <body>



    <form runat="server">
        <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" EnablePartialRendering="true" runat="server" />

        <div class="container" style="border: solid; border-color: black; background-color: #ebebeb; border-width: 1px; border-radius: 20px; margin-bottom: 5rem; margin-top: 8rem; padding: 1rem;">
        <div class="row" style="margin-top: 2rem; margin-left: 1rem; margin-right: 1rem">
            <div class="col" style="border-bottom-style: solid; border-bottom-color: #D0D0D0;">
                <h1>Message Center</h1>
            </div>
            <div class="col" style="padding-bottom: 15px; margin-top: 1rem;">
                <asp:Button ID="btnComposeNew" CssClass="btn float-left" runat="server" Text="Compose New Message" OnClick="ComposeNew_Click" />


                <div class="dropdown" id="dropdownDiv" runat="server">
                    <asp:DropDownList ID="DropDownList3" AutoPostBack="true" Visible="false" runat="server" CssClass="form-control btn btn-outline-secondary">
                        <asp:ListItem Value="0">Your Contacts</asp:ListItem>
                    </asp:DropDownList>

                </div>
            </div>
            <!--end col-->
        </div>
        <!--end row-->
        <div class="row" runat="server">
            <div class="col" runat="server">
                <div class="row" style="margin-left: 1rem;" runat="server">


                    <div class="col-md-4" id="leftDiv" runat="server" style="border-right-style: solid; border-right-color: #D0D0D0;">
                        <div class="row" runat="server" style="border-bottom-style: solid; border-bottom-color: #D0D0D0; margin-bottom: 1rem;">
                            <h4>Your Conversations</h4>
                        </div>
                    </div>


                    <div class="col-md-8" id="rightDiv" runat="server">
                        <div class="row">
                            <div class="col" runat="server">
                                <div class="row" id="conversationDiv" runat="server" style="margin-top: 1rem; margin-bottom: 1rem; min-height: 50px; max-height: 300px; overflow: auto;">

                                    <!-- conversation goes here -->

                                </div>

                                <p>
                                    <asp:TextBox ID="txtBoxReply" runat="server" TextMode="MultiLine" Style="height: 50px; width: 75%; font-size: 14pt;" ForeColor="Gray" Placeholder="Write a message..."></asp:TextBox>
                                </p>
                            </div>
                        </div>
                        <div class="col" runat="server">
                            <p>
                                <asp:Button ID="btnSendRepy" CssClass="btn float-left" runat="server" Text="Send" OnClick="Send_Click"/>
                                <asp:Button ID="videoCall" runat="server" Text="Video Chat" onclick="videoCall_Click" style="margin-left: 1rem;" CssClass="btn btn-dark"/>
                            </p>

                        </div>

                    </div>
                </div>
                </div>
            <!--end row-->
            </div>
            <!--end col-sm-9-->
        </div>
        <!--end row-->

        <!--end container-fluid-->




        <!-- Compose message modal -->

        <div class="modal fade" id="composeMessageModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered" role="document">

                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title" id="modalTitle">Send a Message</h4>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <div class="container-fluid">
                                    <div class="row">
                                        <div class="col-md-12" style="padding-bottom: 15px;">
                                            <div class="dropdown" id="Div1" runat="server">
                                                <asp:DropDownList ID="DropDownList1" AutoPostBack="true" runat="server" CssClass="form-control btn btn-outline-secondary">
                                                    <asp:ListItem Value="0">Your Contacts</asp:ListItem>
                                                </asp:DropDownList>
                                                <p style="font-size: 10pt;">*Contacts based on tenants who have favorited your property</p>

                                                <div class="row">
                                                    <div class="col-md-12" style="padding-bottom: 15px;">
                                                        <p>
                                                            <asp:TextBox ID="txtBoxMessage" runat="server" TextMode="MultiLine" Style="height: 200px; width: 100%; margin-top: 1rem; font-size: 14pt;" ForeColor="Gray" placeholder="Compose Message"></asp:TextBox>
                                                        </p>

                                                        <asp:Button ID="btnSendNewMessage" CssClass="btn float-right" runat="server" Text="Send" OnClick="SendNewMessage_Click" />
                                                    </div>


                                                </div>
                                            </div>
                                        </div>

                                        <!--end col-->
                                    </div>
                                    <!--end row-->

                                </div>
                                <!--end container-fluid-->
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <!--end modal-body-->


                </div>
                <!--end modal header-->

            </div>
            <!--end modal content-->

        </div>
        <!--end modal-dialog div-->




    </form>

           <footer class="footer mt-auto py-3 footer-expand-lg"><!-- start footer! -->
           <div class="row" style="padding-left: 3rem;">
            <div class="col-md-4" style="padding-left: 3rem;">   
            <h3 class="din">Room Magnet</h3>
            <p>Support:<br>
            540-123-4567<br>
            <a href="mailto:help@roommagnet.com">help@roommagnet.com</a></p>
            </div>
       
            <div class="col-md-4" style="padding-left: 3rem;">   
            <h4 class="din">Site Map</h4>
                <p><a href="#">Home-Owners</a><br>
                <a href="#">Tenants</a><br>
                <a href="#">Safety</a><br>
                <a href="#">FAQ</a><br>
                <a href="#">Contact Us</a>
            </p>
            </div>
    
            <div class="col-md-4" style="padding-left: 3rem;">   
            <h4 class="din">Stay Connected</h4>
            <p>
            <a href="#"><img src="images/social-icons-02.png" class="img-fluid" style="max-width: 180px;"></a></p>
            </div>
       
            </div>
        </footer><!-- end footer! -->


    </body>
</html>



</asp:Content>

