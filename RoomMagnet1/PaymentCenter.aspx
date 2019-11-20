<%@ Page Title="" Language="C#" MasterPageFile="~/RoomMagnet.master" AutoEventWireup="true" CodeFile="PaymentCenter.aspx.cs" Inherits="PaymentCenter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<!-- Stripe API -->
<script src="https://js.stripe.com/v3/"></script>

<form action="/charge" method="post" id="payment-form">
  <div class="form-row">
    <label for="card-element">
      Credit or debit card
    </label>
    <div id="card-element">
      <!-- A Stripe Element will be inserted here. -->
    </div>

    <!-- Used to display Element errors. -->
    <div id="card-errors" role="alert"></div>
  </div>

  <button>Submit Payment</button>

</form>
</asp:Content>

