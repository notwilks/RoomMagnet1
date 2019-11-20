using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PaymentCenter : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Set your secret key: remember to change this to your live secret key in production
        // See your keys here: https://dashboard.stripe.com/account/apikeys
        //StripeConfiguration.ApiKey = "sk_test_wNMtikQIT2150fUjCaDsMLEG00yag0mNiR";

        //var service = new ChargeService();
        //var createOptions = new ChargeCreateOptions
        //{
        //    Amount = 1000,
        //    Currency = "usd",
        //    Source = "tok_visa",
        //}

        //var requestOptions = new RequestOptions();
        //requestOptions.StripeAccount = "{{CONNECTED_STRIPE_ACCOUNT_ID}}";
        //service.Create(createOptions, requestOptions)
    }
}