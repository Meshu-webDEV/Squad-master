<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SuccessPage.aspx.cs" Inherits="ssm_mvc_demo1.SuccessPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <br />
    <br />
    <div class="container-fluid">

        <div class="col">

            <div class="row justify-content-center">

                <svg id="i-checkmark" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 32 32" width="80" height="60" fill="none" stroke="green" stroke-linecap="round" stroke-linejoin="round" stroke-width="1.5">
                    <path d="M2 20 L12 28 30 4" />
                </svg>

            </div>

            <hr />
            <br />
            <div class="row justify-content-center">
            <h5 >Successfully added a new field!</h5>
            </div>
            
            

        </div>

        

    </div>


    <script>

        $(document).ready(function () {

            var url = $(location).attr("href");

            for (var i = 0; i < url.length; i++){

                if (url.charAt(i) == "=") {

                    var courtId = url.substr(i + 1, url.length+1)

                }

            }

            //alert(courtId);


            setTimeout(
                function () {
                    $(location).attr("href", "Court.aspx?courtId=" + courtId);
                }, 2200)

        });

    </script>

</asp:Content>
