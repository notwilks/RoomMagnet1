﻿<%@ Page Title="" Language="C#" MasterPageFile="~/RoomMagnet.master" AutoEventWireup="true" CodeFile="EditAccountInformation.aspx.cs" Inherits="EditAccountInformation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <form id="form1" style="margin-top: 7rem;" runat="server">
        <h2>Edit Personal Information</h2>
        <div class="container">
            <table class="auto-style1">
                <tr>
                    <td class="auto-style6">
                        &nbsp;</td>
                    <td class="auto-style8">

                        &nbsp;</td>
                    <td class="auto-style9">
                        &nbsp;</td>
                    <td class="auto-style10">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style6">
                        
                        <asp:Label ID="Label8" runat="server" Text="First Name: "></asp:Label>
                        
                    </td>
                    <td class="auto-style8">
                
                <asp:TextBox ID="FirstNameBox" runat="server" Width="223px" MaxLength ="25" CssClass="form-control"></asp:TextBox>
           
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="FirstNameBox" ErrorMessage="This field is required" Font-Size="Small" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="FirstNameBox" Font-Size="Small" Operator="DataTypeCheck" ForeColor="Red" Type="String" Text ="Invalid characters" />
                    </td>
                    <td class="auto-style9">
                        <asp:Label ID="Label2" runat="server" Text="Last Name:"></asp:Label>
                    </td>
                    <td class="auto-style10">
                        <asp:TextBox ID="LastNameBox" runat="server" Width="212px" MaxLength ="25" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="LastNameBox" ErrorMessage="This field is required" Font-Size="Small" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="LastNameBox" Text="Invalid characters" Font-Size="Small" Operator="DataTypeCheck" ForeColor="Red">Invalid characters</asp:CompareValidator>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style6">
                        <asp:Label ID="Label9" runat="server" Text="Gender: "></asp:Label>
                    </td>
                    <td class="auto-style8">
                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control btn btn-light" Width="97px">
                            <asp:ListItem Value="M">Male</asp:ListItem>
                            <asp:ListItem Value="F">Female</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style9">
                        <asp:Label ID="Label7" runat="server" Text="Date of Birth:"></asp:Label>
                    </td>
                    <td class="auto-style10">
                        <asp:TextBox ID="dobBox" runat="server" Width="212px" placeholder ="MM/DD/YYY" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="dobBox" ErrorMessage="This field is required" Font-Size="Small" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="dobBox" Text="Invalid DOB" Type="Date" Operator="DataTypeCheck" Font-Size="Small" ForeColor="Red" Display="Static"></asp:CompareValidator>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style6">
                        &nbsp;</td>
                    <td class="auto-style8">
                        &nbsp;</td>
                    <td class="auto-style9">
                        <asp:Label ID="Label10" runat="server" Text="Phone Number: "></asp:Label>
                    </td>
                    <td class="auto-style10">
                        <asp:TextBox ID="phoneNumberBox" runat="server" Width="212px" placeholder ="xxx-xxx-xxxx" CssClass="form-control"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style11"></td>
                    <td class="auto-style12"></td>
                    <td class="auto-style13"></td>
                    <td class="auto-style14"></td>
                    <td class="auto-style15"></td>
                    <td class="auto-style15"></td>
                </tr>
                <tr>
                    <td class="auto-style6">
                        &nbsp;</td>
                    <td class="auto-style8">
                        &nbsp;</td>
                    <td class="auto-style9">&nbsp;</td>
                    <td class="auto-style10">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style6">
                        &nbsp;</td>
                    <td class="auto-style8">
                        &nbsp;</td>
                    <td class="auto-style9">&nbsp;</td>
                    <td class="auto-style10">
                        <asp:Label ID="OutputLabel" runat="server" Text=""></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style6">&nbsp;</td>
                    <td class="auto-style8">&nbsp;</td>
                    <td class="auto-style9">&nbsp;</td>
                    <td class="auto-style10">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style6">&nbsp;</td>
                    <td class="auto-style8">
                        <asp:Button ID="Button1" runat="server" Text="Update Information" OnClick="Button1_Click" CausesValidation="False" CssClass="form-control btn btn-outline-success my-2 my-sm-0 form-inline"/>
                    </td>
                    <td class="auto-style9">&nbsp;</td>
                    <td class="auto-style10">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style6">&nbsp;</td>
                    <td class="auto-style8">&nbsp;</td>
                    <td class="auto-style9">&nbsp;</td>
                    <td class="auto-style10">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style6">&nbsp;</td>
                    <td class="auto-style8">&nbsp;</td>
                    <td class="auto-style9">&nbsp;</td>
                    <td class="auto-style10">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style6">&nbsp;</td>
                    <td class="auto-style8">&nbsp;</td>
                    <td class="auto-style9">&nbsp;</td>
                    <td class="auto-style10">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
    <h2></h2>
</asp:Content>

