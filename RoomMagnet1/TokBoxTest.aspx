<%@ Page Title="" Language="C#" MasterPageFile="~/RoomMagnet.master" AutoEventWireup="true" CodeFile="TokBoxTest.aspx.cs" Inherits="TokBoxTest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!doctype html>
    <html>
        <head>
            <title> OpenTok Getting Started </title>
            <link href="css/app.css" rel="stylesheet" type="text/css">
            <script src="https://static.opentok.com/v2/js/opentok.min.js"></script>
            <style>
                body, html {
                background-color: gray;
                height: 100%;
                }

                    #videos {
                        position: relative;
                        width: 200px;
                        height: 200px;
                        margin-left: 5rem;
                        margin-right: 5rem;
                        margin-top: 10rem;
                    }

                    #publisher {
                        position: absolute;
                        left: 0;
                        top: 0;
                        width: 200px;
                        height: 200px;
                        z-index: 10;
                    }

                    #subscriber {
                        position: absolute;
                        width: 360px;
                        height: 240px;
                        bottom: 10px;
                        left: 10px;
                        z-index: 100;
                    }
            </style>
            <script type="text/javascript">
                var apiKey = "46464112";
                var sessionId = "1_MX40NjQ2NDExMn5-MTU3NDMwNzc1OTIyMX5oeUJWOWdiUEVxUnBDV0JFbU0wWDBRaHR-UH4";
                var token = "T1==cGFydG5lcl9pZD00NjQ2NDExMiZzaWc9NjM5Zjg5YTdhZDFlZjQxZmZiNzViZDcwODc4NWU1OWRiNDlhMDY4ZjpzZXNzaW9uX2lkPTFfTVg0ME5qUTJOREV4TW41LU1UVTNORE13TnpjMU9USXlNWDVvZVVKV09XZGlVRVZ4VW5CRFYwSkZiVTB3V0RCUmFIUi1VSDQmY3JlYXRlX3RpbWU9MTU3NDMwNzc3MyZub25jZT0wLjYwMjIyMDc5MzYxNzQwMiZyb2xlPXB1Ymxpc2hlciZleHBpcmVfdGltZT0xNTc0OTEyNTczJmluaXRpYWxfbGF5b3V0X2NsYXNzX2xpc3Q9";

                // Handling all of our errors here by alerting them
                function handleError(error) {
                  if (error) {
                    alert(error.message);
                  }
                }

                // (optional) add server code here
                initializeSession();

                function initializeSession() {
                  var session = OT.initSession(apiKey, sessionId);

                    // Create a publisher
                  var publisher = OT.initPublisher('publisher', {
                    insertMode: 'append',
                    width: '100%',
                    height: '100%'
                    }, handleError);

                  // Subscribe to a newly created stream
                      session.on('streamCreated', function(event) {
                      session.subscribe(event.stream, 'subscriber', {
                      insertMode: 'append',
                      width: '100%',
                      height: '100%'
                      }, handleError);
                      });

                  

                  // Connect to the session
                  session.connect(token, function(error) {
                    // If the connection is successful, publish to the session
                    if (error) {
                      handleError(error);
                    } else {
                      session.publish(publisher, handleError);
                    }
                  });
                }
            </script>

        </head>
        <body style="margin: 20rem;">
            <form runat="server">
                <div style="margin-top: 8rem;">

                    <div id="videos">
                        <div id="subscriber"></div>
                        <div id="publisher"></div>
                    </div>

                    <script type="text/javascript"></script>

                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                </div>
            </form>
        </body>
    </html>
</asp:Content>

