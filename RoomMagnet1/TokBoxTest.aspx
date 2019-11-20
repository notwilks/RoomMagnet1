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

                    #subscriber {
                        position: absolute;
                        left: 0;
                        top: 0;
                        width: 200px;
                        height: 200px;
                        z-index: 10;
                    }

                    #publisher {
                        position: absolute;
                        width: 360px;
                        height: 240px;
                        bottom: 10px;
                        left: 10px;
                        z-index: 100;
                        border: 3px solid white;
                        border-radius: 3px;
                    }
            </style>
            <script type="text/javascript">
                var apiKey = "46464112";
                var sessionId = "2_MX40NjQ2NDExMn5-MTU3NDI3NzAzMDU1OX5OV3ZoZ09OcUE4MkhvRE9IelZvQnhUeFB-UH4";
                var token = "T1==cGFydG5lcl9pZD00NjQ2NDExMiZzaWc9NTNjNjM0OTg3MjAxZjk3ZmZhNGUzM2Y3YjZkMDE5YmRlYzQ0ODAwMTpzZXNzaW9uX2lkPTJfTVg0ME5qUTJOREV4TW41LU1UVTNOREkzTnpBek1EVTFPWDVPVjNab1owOU9jVUU0TWtodlJFOUllbFp2UW5oVWVGQi1VSDQmY3JlYXRlX3RpbWU9MTU3NDI3NzA1OCZub25jZT0wLjIzMzU1ODAyODQyNjY0ODMmcm9sZT1wdWJsaXNoZXImZXhwaXJlX3RpbWU9MTU3NDI5ODY1NyZpbml0aWFsX2xheW91dF9jbGFzc19saXN0PQ==";

                // (optional) add server code here
                initializeSession();

                // Handling all of our errors here by alerting them
                function handleError(error) {
                  if (error) {
                    alert(error.message);
                  }
                }

                function initializeSession() {
                  var session = OT.initSession(apiKey, sessionId);

                  // Subscribe to a newly created stream

                  // Create a publisher
                  var publisher = OT.initPublisher('publisher', {
                    insertMode: 'append',
                    width: '100%',
                    height: '100%'
                  }, handleError);

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

                session.on('streamCreated', function(event) {
                session.subscribe(event.stream, 'subscriber', {
                insertMode: 'append',
                width: "200px",
                height: '200px'
                }, handleError);
                });
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

