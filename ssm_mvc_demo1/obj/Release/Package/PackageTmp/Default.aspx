<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ssm_mvc_demo1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div id="slides" class="carousel slide" data-ride="carousel">
        <ul class="carousel-indicators">
            <li data-target="#slides" data-slide-to="0" class="active"></li>
            <li data-target="#slides" data-slide-to="1"></li>
            <li data-target="#slides" data-slide-to="2"></li>
        </ul>
        <div style="height: 150px;" class="carousel-inner">
            <div class="carousel-item active">
                <img class="img-fluid" src="/images/slider/1.png" alt="" />
            </div>
            <div class="carousel-item">
                <img class="img-fluid" src="/images/slider/2.png" alt="" />
            </div>
            <div class="carousel-item">
                <img class="img-fluid" src="/images/slider/3.png" alt="" />
            </div>
        </div>
    </div>

    <div class="card text-center">
        <div class="card-body card-body-createMatch">
            <a href="/CreateMatchForm.aspx" id="creatematch" class="btn btn-success btn-createMatch" runat="server">Create a match</a>
        </div>
    </div>

    <hr />

    <div id="upmatchBlock" style="display:none;" runat="server" class="upmatch-block">
    </div>

    <h5 id="errorMessage" runat="server"></h5>

 

    <%--    <h5 id="errorMessage" runat="server"></h5>

    <asp:Button Text="test" runat="server" OnClick="Unnamed_Click" />


    <div id="test" runat="server"></div>--%>


    <script>

        $(document).ready(function () {

            $("#MainContent_upmatchBlock").fadeIn(1200);

        });

    </script>



</asp:Content>
