<%@ Page Title="" Language="C#" MasterPageFile="~/RoomMagnet.master" AutoEventWireup="true" CodeFile="AdminStats.aspx.cs" Inherits="AdminStats" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <!doctype html>
    <script type="text/javascript">
        function ShowPopup(body) {
            $("#exampleModal .modal-body").html(body)
            $("#exampleModal").modal("show");
        }

        function ShowPopupTenant(body) {
            $("#tenantModal .modal-body").html(body)
            $("#tenantModal").modal("show");
        }
    </script>
<html>
<head>
<meta charset="UTF-8">
<meta name="description" content="Room Magnet">
<meta name="keywords" content="room magnet, roommate, housing, matchmaking, house, apartment, living arrangement">
<meta name="author" content="Room Magnet">
<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
<title>Dashboard</title>

<!-- Bootstrap v4 -->
<link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" media="screen">
<!-- custom css -->
<link href="css/custom.css" rel="stylesheet" type="text/css" media="screen">
<link rel="shortcut icon" href="images/logo-03.png" type="image/x-icon"/>
<link href="https://fonts.googleapis.com/css?family=Oswald:400|Raleway:300&display=swap" rel="stylesheet">    
</head>
    
<body>
<form runat="server">     
<div id="containerDiv" class="container">

  <div class="row" style="margin-top: 7rem;">
      <h1><asp:Label ID="admindash" runat="server" Text="Admin Dashboard"></asp:Label></h1>
    </div><!-- end div row -->  
   
</div>
    <div class="row" style="margin-right: 4rem; margin-left: 4rem;">
    <div class="col-md-1">

      </div>

    <div class="col-md-10" style="margin-bottom: 2rem; margin-top: 2rem">
        
        
         <nav class="navbar navbar-expand-lg navbar-dark bg-dark">

                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                        <span class="navbar-toggler-icon"></span>
                </button>
                
             <div class="collapse navbar-collapse" id="navbarNav">
                    <ul class="navbar-nav">
                        <li class="">
                            <a class="nav-link" href="AdminDashboard.aspx">Search Users</a>
                        </li>
                        <li class="active">
                            <a class="nav-link" href="AdminStats.aspx">Site Statistics</a>
                        </li>
                        <li class="">
                            <a class="nav-link" href="CreateAdmin.aspx">Create New Admin</a>
                        </li>
                    </ul>
            </div>
        </nav>

      </div>

      <div class="col-md-1">

      </div>
 
        </div>

    <div class="container">
        <div class='tableauPlaceholder' id='viz1574106484886' style='position: relative'><noscript><a href='#'><img alt=' ' src='https:&#47;&#47;public.tableau.com&#47;static&#47;images&#47;Te&#47;TestTableau_15741064639060&#47;Dashboard1&#47;1_rss.png' style='border: none' /></a></noscript><object class='tableauViz'  style='display:none;'><param name='host_url' value='https%3A%2F%2Fpublic.tableau.com%2F' /> <param name='embed_code_version' value='3' /> <param name='site_root' value='' /><param name='name' value='TestTableau_15741064639060&#47;Dashboard1' /><param name='tabs' value='no' /><param name='toolbar' value='yes' /><param name='static_image' value='https:&#47;&#47;public.tableau.com&#47;static&#47;images&#47;Te&#47;TestTableau_15741064639060&#47;Dashboard1&#47;1.png' /> <param name='animate_transition' value='yes' /><param name='display_static_image' value='yes' /><param name='display_spinner' value='yes' /><param name='display_overlay' value='yes' /><param name='display_count' value='yes' /><param name='filter' value='publish=yes' /></object></div>                <script type='text/javascript'>                    var divElement = document.getElementById('viz1574106484886');                    var vizElement = divElement.getElementsByTagName('object')[0];                    if ( divElement.offsetWidth > 800 ) { vizElement.style.width='1000px';vizElement.style.height='827px';} else if ( divElement.offsetWidth > 500 ) { vizElement.style.width='1000px';vizElement.style.height='827px';} else { vizElement.style.width='100%';vizElement.style.height='727px';}                     var scriptElement = document.createElement('script');                    scriptElement.src = 'https://public.tableau.com/javascripts/api/viz_v1.js';                    vizElement.parentNode.insertBefore(scriptElement, vizElement);                </script>
    </div>

    </form>
    </body>
    </html>
</asp:Content>

