<%@ Page Title="" Language="C#" MasterPageFile="~/RoomMagnet.master" AutoEventWireup="true" CodeFile="CreateHostProperty.aspx.cs" Inherits="CreateHostProperty" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="form2" runat="server">
        <asp:Label ID="Label1" runat="server" Text="Tell us about your property."></asp:Label>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Let us find you the perfect housemate."></asp:Label>
        <br />
        <br />
        <table class="w-100">
            <tr>
                <td style="width: 82px">
                    <asp:Label ID="Label3" runat="server" Text="Address 1*: "></asp:Label>
                </td>
                <td style="width: 123px" colspan="2">
                    <asp:TextBox ID="AddressBox" runat="server" Width="349px"></asp:TextBox>
                </td>
                <td style="width: 191px">
                    <asp:Label ID="Label4" runat="server" Text="Apartment # (if applicable): "></asp:Label>
                </td>
                <td style="width: 358px" colspan="2">
                    <asp:TextBox ID="TextBox1" runat="server" Width="351px"></asp:TextBox>
                </td>
                <td style="width: 66px">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 82px">&nbsp;</td>
                <td style="width: 123px" colspan="2">&nbsp;</td>
                <td style="width: 191px">&nbsp;</td>
                <td style="width: 358px" colspan="2">&nbsp;</td>
                <td style="width: 66px">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 82px">
                    <asp:Label ID="Label5" runat="server" Text="City: "></asp:Label>
                </td>
                <td style="width: 123px" colspan="2">
                    <asp:TextBox ID="TextBox2" runat="server" Width="349px"></asp:TextBox>
                </td>
                <td style="width: 191px">
                    <asp:Label ID="Label6" runat="server" Text="State: "></asp:Label>
                </td>
                <td style="width: 358px" colspan="2">
                    <asp:DropDownList ID="stateBox" runat="server">
                    <asp:ListItem>Select a state</asp:ListItem>
                    <asp:ListItem Value="AL">Alabama</asp:ListItem>
                    <asp:ListItem Value="AK">Alaska</asp:ListItem>
                    <asp:ListItem Value="AZ">Arizona</asp:ListItem>
                    <asp:ListItem Value="AR">Arkansas</asp:ListItem>
                    <asp:ListItem Value="CA">California</asp:ListItem>
                    <asp:ListItem Value="CO">Colorado</asp:ListItem>
                    <asp:ListItem Value="CT">Connecticut</asp:ListItem>
                    <asp:ListItem Value="DE">Delaware</asp:ListItem>
                    <asp:ListItem Value="FL">Florida</asp:ListItem>
                    <asp:ListItem Value="GA">Georgia</asp:ListItem>
                    <asp:ListItem Value="HI">Hawaii</asp:ListItem>
                    <asp:ListItem Value="ID">Idaho</asp:ListItem>
                    <asp:ListItem Value="IL">Illinois</asp:ListItem>
                    <asp:ListItem Value="IN">Indiana</asp:ListItem>
                    <asp:ListItem Value="IA">Iowa</asp:ListItem>
                    <asp:ListItem Value="KS">Kansas</asp:ListItem>
                    <asp:ListItem Value="KY">Kentucky</asp:ListItem>
                    <asp:ListItem Value="LA">Louisiana</asp:ListItem>
                    <asp:ListItem Value="ME">Maine</asp:ListItem>
                    <asp:ListItem Value="MD">Maryland</asp:ListItem>
                    <asp:ListItem Value="MA">Massachusetts</asp:ListItem>
                    <asp:ListItem Value="MI">Michigan</asp:ListItem>
                    <asp:ListItem Value="MN">Minnesota</asp:ListItem>
                    <asp:ListItem Value="MS">Mississippi</asp:ListItem>
                    <asp:ListItem Value="MO">Missouri</asp:ListItem>
                    <asp:ListItem Value="MT">Montana</asp:ListItem>
                    <asp:ListItem Value="NE">Nebraska</asp:ListItem>
                    <asp:ListItem Value="NV">Nevada</asp:ListItem>
                    <asp:ListItem Value="NH">New Hampshire</asp:ListItem>
                    <asp:ListItem Value="NJ">New Jersey</asp:ListItem>
                    <asp:ListItem Value="NM">New Mexico</asp:ListItem>
                    <asp:ListItem Value="NY">New York</asp:ListItem>
                    <asp:ListItem Value="NC">North Carolina</asp:ListItem>
                    <asp:ListItem Value="ND">North Dakota</asp:ListItem>
                    <asp:ListItem Value="OH">Ohio</asp:ListItem>
                    <asp:ListItem Value="OK">Oklahoma</asp:ListItem>
                    <asp:ListItem Value="OR">Oregon</asp:ListItem>
                    <asp:ListItem Value="PA">Pennsylvania</asp:ListItem>
                    <asp:ListItem Value="RI">Rhode Island</asp:ListItem>
                    <asp:ListItem Value="SC">South Carolina</asp:ListItem>
                    <asp:ListItem Value="SD">South Dakota</asp:ListItem>
                    <asp:ListItem Value="TN">Tennessee</asp:ListItem>
                    <asp:ListItem Value="TX">Texas</asp:ListItem>
                    <asp:ListItem Value="UT">Utah</asp:ListItem>
                    <asp:ListItem Value="VT">Vermont</asp:ListItem>
                    <asp:ListItem Value="VA">Virginia</asp:ListItem>
                    <asp:ListItem Value="WA">Washington</asp:ListItem>
                    <asp:ListItem Value="WV">West Virginia</asp:ListItem>
                    <asp:ListItem Value="WI">Wisconsin</asp:ListItem>
                    <asp:ListItem Value="WY">Wyoming</asp:ListItem>
                </asp:DropDownList>
                </td>
                <td style="width: 66px">
                    <asp:Label ID="Label7" runat="server" Text="Zip Code: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 82px">
                    &nbsp;</td>
                <td style="width: 123px" colspan="2">
                    &nbsp;</td>
                <td style="width: 191px">
                    &nbsp;</td>
                <td style="width: 358px" colspan="2">
                    &nbsp;</td>
                <td style="width: 66px">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 82px">&nbsp;</td>
                <td colspan="5">
                    <asp:Label ID="Label8" runat="server" Text="Don't fret, only city, state, and zip code will appear on your profile to potential housemates."></asp:Label>
                </td>
                <td style="width: 66px">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 82px; height: 26px;"></td>
                <td style="width: 123px; height: 26px;" colspan="2"></td>
                <td style="width: 191px; height: 26px;"></td>
                <td style="width: 358px; height: 26px;" colspan="2"></td>
                <td style="width: 66px; height: 26px;"></td>
                <td style="height: 26px"></td>
            </tr>
            <tr>
                <td style="width: 82px">&nbsp;</td>
                <td style="width: 123px" colspan="2">&nbsp;</td>
                <td style="width: 191px">&nbsp;</td>
                <td style="width: 358px" colspan="2">&nbsp;</td>
                <td style="width: 66px">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="8">
                    <asp:Label ID="Label9" runat="server" Text="Describe Your Property for Rent Briefly: "></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="8">
                    <asp:TextBox ID="TextBox4" runat="server" Width="1201px" OnTextChanged="TextBox4_TextChanged"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 82px">&nbsp;</td>
                <td style="width: 123px" colspan="2">&nbsp;</td>
                <td style="width: 191px">&nbsp;</td>
                <td style="width: 358px" colspan="2">&nbsp;</td>
                <td style="width: 66px">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="3" style="height: 26px">
                    <asp:Label ID="Label10" runat="server" Text="What Best Describes Your Property for Rent: "></asp:Label>
                </td>
                <td style="width: 191px; height: 26px;"></td>
                <td style="width: 358px; height: 26px;" colspan="2"></td>
                <td style="width: 66px; height: 26px;"></td>
                <td style="height: 26px"></td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:DropDownList ID="PropertyTypeList" runat="server" Width="429px">
                        <asp:ListItem>Single Room</asp:ListItem>
                        <asp:ListItem>Apartment</asp:ListItem>
                        <asp:ListItem>Single Room with Private Entrance</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="width: 191px">&nbsp;</td>
                <td style="width: 358px" colspan="2">&nbsp;</td>
                <td style="width: 66px">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="3">
                    &nbsp;</td>
                <td style="width: 191px">&nbsp;</td>
                <td style="width: 358px" colspan="2">&nbsp;</td>
                <td style="width: 66px">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="2" style="height: 26px">
                    <asp:Label ID="Label11" runat="server" Text="Does the space have a private bathroom?"></asp:Label>
                </td>
                <td colspan="3" style="height: 26px">
                    <asp:Label ID="Label12" runat="server" Text="Does the space have a private entrance?"></asp:Label>
                </td>
                <td colspan="3" style="height: 26px">
                    <asp:Label ID="Label13" runat="server" Text="Does the space have closet/storage space?"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="height: 26px">
                    <asp:RadioButton ID="RadioButton1" runat="server" />
                    <asp:Label ID="Label14" runat="server" Text="Yes"></asp:Label>
                    &nbsp&nbsp
                    <asp:RadioButton ID="RadioButton2" runat="server" />
                    <asp:Label ID="Label15" runat="server" Text="No"></asp:Label>
                </td>
                <td colspan="3" style="height: 26px">
                    <asp:RadioButton ID="RadioButton3" runat="server" />
                    <asp:Label ID="Label16" runat="server" Text="Yes"></asp:Label>
                    &nbsp&nbsp
                    <asp:RadioButton ID="RadioButton4" runat="server" />
                    <asp:Label ID="Label17" runat="server" Text="No"></asp:Label>
                </td>
                <td colspan="3" style="height: 26px">
                    <asp:RadioButton ID="RadioButton5" runat="server" />
                    <asp:Label ID="Label18" runat="server" Text="Yes"></asp:Label>
                    &nbsp&nbsp
                    <asp:RadioButton ID="RadioButton6" runat="server" />
                    <asp:Label ID="Label19" runat="server" Text="No"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="height: 26px">
                </td>
                <td style="width: 191px; height: 26px;"></td>
                <td style="width: 358px; height: 26px;" colspan="2"></td>
                <td style="width: 66px; height: 26px;"></td>
                <td style="height: 26px"></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="Label20" runat="server" Text="Is the space furnished?"></asp:Label>
                </td>
                <td colspan="3">
                    <asp:Label ID="Label21" runat="server" Text="Do you smoke/allow smokers?"></asp:Label>
                </td>
                <td colspan="3">
                    <asp:Label ID="Label22" runat="server" Text="Do you have pets?"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:RadioButton ID="RadioButton7" runat="server" />
                    <asp:Label ID="Label23" runat="server" Text="Yes"></asp:Label>
                    &nbsp&nbsp
                    <asp:RadioButton ID="RadioButton8" runat="server" />
                    <asp:Label ID="Label24" runat="server" Text="No"></asp:Label>
                </td>
                <td colspan="3">
                    <asp:RadioButton ID="RadioButton9" runat="server" />
                    <asp:Label ID="Label25" runat="server" Text="Yes"></asp:Label>
                    &nbsp&nbsp
                    <asp:RadioButton ID="RadioButton10" runat="server" />
                    <asp:Label ID="Label26" runat="server" Text="No"></asp:Label>
                </td>
                <td colspan="3">
                    <asp:RadioButton ID="RadioButton11" runat="server" />
                    <asp:Label ID="Label27" runat="server" Text="Yes"></asp:Label>
                    &nbsp&nbsp
                    <asp:RadioButton ID="RadioButton12" runat="server" />
                    <asp:Label ID="Label28" runat="server" Text="No"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    &nbsp;</td>
                <td style="width: 191px">&nbsp;</td>
                <td style="width: 358px" colspan="2">&nbsp;</td>
                <td style="width: 66px">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Label ID="Label29" runat="server" Text="Tell us more about your rental space."></asp:Label>
                </td>
                <td style="width: 191px">&nbsp;</td>
                <td style="width: 358px" colspan="2">&nbsp;</td>
                <td style="width: 66px">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="8">
                    <asp:TextBox ID="TextBox5" runat="server" Height="121px" Width="1200px"></asp:TextBox>
                </td>
            </tr>
        </table>
    </form>
</asp:Content>

