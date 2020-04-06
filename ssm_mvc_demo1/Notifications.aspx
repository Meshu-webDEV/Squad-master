<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Notifications.aspx.cs" Inherits="ssm_mvc_demo1.Notifications" %>

<form runat="server" class="m-0 p-0 h-100 w-100">

    <!DOCTYPE html>

    <html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <meta name="viewport" content="width=device-width, initial-scale=1.0" />
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

        <div class="d-flex justify-content-center h-100">
            <div class="row w-100">
                <div class="col">
                    <div class="row" runat="server" id="notif" style="display: none;">
                        <!--Insert from back end into this -->
                    </div>


                    <hr class="my-1 w-75" />


                </div>
            </div>


            <h3 id="test" runat="server"></h3>



        </div>

        <asp:HiddenField ID="acceptedID" Value="" runat="server" />
        <asp:HiddenField ID="declinedID" Value="" runat="server" />
        <asp:Button Text="" ID="accept" Style="display: none;" runat="server" OnClick="accept_Click" />
        <asp:Button Text="" ID="decline" Style="display: none;" runat="server" OnClick="decline_Click" />

    </body>


    <script>

        $(document).ready(function () {

            $("#notif").slideDown("slow");

        });

        function accepted(element) {

            $("#notif").slideUp("slow");
            $("#acceptedID").attr("value", $(element).attr("id"));
            $("#accept").click();

        }

        function decline(element) {

            $("#notif").slideUp("slow");
            $("#declinedID").attr("value", $(element).attr("id"));
            $("#decline").click();

        }

        function removeFriend(element) {

            $("#removedID").attr("value", $(element).attr("id"));

            $("#MainContent_remove").click()

        }

        function Goto(element) {

            var id = $(element).attr("id");

            var arr = id.split("#");
            // ID
            // 12345@Private
            //
            var arry = arr[1].split("@");
            // 12345
            // Private


            window.parent.location = "MatchRoom.aspx?match_id=" + arr[0] + "&type=" + arry[1] + "&code=" + arry[0];

        }

    </script>



    </html>
</form>
