<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpcomingBlock.aspx.cs" Inherits="ssm_mvc_demo1.UpcomingBlock" %>

<form runat="server" class="m-0 p-0 h-100 w-100">

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" class="m-0 p-0">
<head runat="server">
    
    <link href="Content/jquery-ui.css" rel="stylesheet" />
    <link href="Content/jquery-ui.structure.css" rel="stylesheet" />
    <link href="Content/jquery-ui.theme.css" rel="stylesheet" />
    <link href="Content/Site.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
    <script src="https://code.jquery.com/jquery-3.4.1.js" integrity="sha256-WpOohJOqMqqyKL9FccASB9O0KwACQJpFTUBLTYOVvVU=" crossorigin="anonymous"></script>
    <script src="Scripts/bootstrap.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>

</head>
<body class="m-0 p-0">

    <div id="blockslide" class="upmatch-block">
        <div class="d-flex justify-content-center">
            <div class="row w-100 justify-items-center align-items-center">
                 <div id="Mname" runat="server" class="col-5"></div>
                 <div id="plyers" runat="server" class="col-2 text-center">20/20</div>
                 <div class="col-4 text-center">
                     <div id="Mtime" runat="server" class="row-1 px-2"></div>
                     <div id="Mdate" runat="server" class="row-1 px-2"></div>
                 </div>
                
                <div class="col-1 text-center p-0 w-100">
                    
                <asp:Button ID="btnslideup" runat="server" CssClass="unbutton upcoming-info w-100" OnClick="Goto_Click" OnClientClick="slideUp()" />
                 </div>

                
            </div>
        </div>
        <hr class="my-1" />
    </div>

</body>

<script>

    function slideUp() {
        window.top.$("#MainContent_upmatchBlock").slideUp("fast");
    }

</script>

</html>

    </form>