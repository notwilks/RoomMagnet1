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
                                             <h6>Your Conversations</h6>
                                         </div>
                                         <div class="col-md-10" id="rightDiv" runat="server">
                                             <h5><asp:Label ID="lblSender" runat="server"></asp:Label></h5>
                                             <h6><asp:Label ID="lblDate" runat="server"></asp:Label></h6>
                                             <p><asp:Label ID="lblMessageText" runat="server"></asp:Label></p>
                                             <p><asp:TextBox ID="txtBoxReply" runat="server" TextMode="MultiLine" style="height:50px; width:75%; font-size:14pt;" ForeColor="Gray" Text="Write a reply..."></asp:TextBox></p>
                                             <!--<asp:Button ID="btnSendRepy" CssClass="btn float-right" runat="server" Text="Send" OnClick="Send_Click"/>-->
                                             
                                                 
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

