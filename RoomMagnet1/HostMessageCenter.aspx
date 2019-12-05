<%@ Page Title="" Language="C#" MasterPageFile="~/RoomMagnet.master" AutoEventWireup="true" CodeFile="HostMessageCenter.aspx.cs" Inherits="HostMessageCenter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!doctype html>
    
        <form runat="server">

            
                             <div class="row" style="margin-top: 7rem; margin-left:1rem; margin-right:1rem">
                                 <div class="col-md-12" style="border-bottom-style: solid; border-bottom-color: #D0D0D0;">
                                 <h1>Message Center</h1>
                                 </div>
                                 <div class="col-md-9" style="padding-bottom: 15px; margin-top: 1rem;">
                                     <div class="dropdown" id="dropdownDiv" runat="server">
                                         <asp:DropDownList ID="DropDownList1" AutoPostBack="true" runat="server" CssClass="form-control btn btn-outline-secondary">
                                             <asp:ListItem Value="0">Your Contacts</asp:ListItem>
                                         </asp:DropDownList>

                                     </div>
                                 </div>
                                 <!--end col-->
                             </div>
                             <!--end row-->
                             <div class="row">
                                 <div class="col-md-12">
                                     <div class="row"style="margin-left:1rem;">
                                         <div class="col-md-2" id="leftDiv" runat="server" style="border-right-style: solid; border-right-color: #D0D0D0;" >
                                             <div class="row" style="border-bottom-style:solid; border-bottom-color: #D0D0D0; margin-bottom:1rem;">
                                             <h6>Your Conversations</h6>
                                             </div>
                                         </div>
                                         <div class="col-md-10" id="rightDiv" runat="server">
                                             <div class="row">
                                                 <div class="col-md-8" runat="server">
                                                     <div class="row" id="conversationDiv" runat="server" style="background-color: #ebebeb; margin-top: 1rem; margin-bottom: 1rem; min-height: 50px; max-height:300px; overflow:auto;" >

                                                         <!-- conversation goes here -->

                                                         </div>

                                             <p><asp:TextBox ID="txtBoxReply" runat="server" TextMode="MultiLine" style="height:50px; width:75%; font-size:14pt;" ForeColor="Gray" Text="Write a reply..."></asp:TextBox></p>
                                             </div>
                                                 </div>
                                                 <div class="col-md-2" runat="server">
                                                     <p><asp:Button ID="btnSendRepy" CssClass="btn float-left" runat="server" Text="Send" OnClick="Send_Click"/></p>
                                                 
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





        </form>
    






</asp:Content>

