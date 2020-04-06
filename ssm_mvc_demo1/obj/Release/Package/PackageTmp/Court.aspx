<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Court.aspx.cs" Inherits="ssm_mvc_demo1.Court" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div class="container-fluid">

        

        

        <div class="row text-center justify-content-center align-items-center">
            <h4 id="courtName" runat="server"></h4>
        </div>

        <hr />

    <div class="row">
         <!-- Carousel wrapper -->
            <div id="carousel" class="d-flex w-100 carousel slide carousel-fade pointer-event" data-ride="carousel">

                <!-- Indicators -->
                <ol class="carousel-indicators">
                    <li data-target="#carousel" data-slide-to="0" class="active"></li>
                    <li data-target="#carousel" data-slide-to="1"></li>
                    <li data-target="#carousel" data-slide-to="2"></li>
                    <li data-target="#carousel" data-slide-to="3"></li>
                    <li data-target="#carousel" data-slide-to="4"></li>
                </ol>
                <!--/.Indicators-->


                <!-- Images -->
                <div class="carousel-inner" role="listbox">

                    <!-- 1 -->
                    <div id="imgblock0" class="carousel-item active" runat="server">
                        <div class="view w-100 d-flex justify-content-center">
                            <img id="img0" runat="server" class="img-fuild w-100 mr-imgs court-imgs" src="" alt="First Image" />
                        </div>
                    </div>

                    <!-- 2 -->
                    <div id="imgblock1" class="carousel-item" runat="server">
                        <div class="view w-100 d-flex justify-content-center">
                            <img id="img1" runat="server" class="img-fuild w-100 mr-imgs court-imgs" src="" alt="Second Image" />
                        </div>
                    </div>

                    <!-- 3 -->
                    <div id="imgblock2" class="carousel-item" runat="server">
                        <div class="view w-100 d-flex justify-content-center">
                            <img id="img2" runat="server" class="img-fuild w-100 mr-imgs court-imgs" src="" alt="Third Image" />
                        </div>
                    </div>

                    <!-- 4 -->
                    <div id="imgblock3" class="carousel-item" runat="server">
                        <div class="view w-100 d-flex justify-content-center">
                            <img id="img3" runat="server" class="img-fuild w-100 mr-imgs court-imgs" src="" alt="Fourth Image" />
                        </div>
                    </div>

                    <!-- 5 -->
                    <div id="imgblock4" class="carousel-item" runat="server">
                        <div class="view w-100 d-flex justify-content-center">
                            <img id="img4" runat="server" class="img-fuild w-100 mr-imgs court-imgs" src="" alt="Fifth Image" />
                        </div>
                    </div>

                </div>
                <!--/.Images -->

                <!--Controls-->
                <a class="carousel-control-prev" href="#carousel" role="button" data-slide="prev">
                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                    <span class="sr-only">Previous</span>
                </a>
                <a class="carousel-control-next" href="#carousel" role="button" data-slide="next">
                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                    <span class="sr-only">Next</span>
                </a>
                <!--/.Controls-->

            </div>
            <!-- /.Carousel wrapper -->

        <h4 id="notFound" runat="server" visible="false" class="w-75 text-center my-4" style="color: darkred;" > No images found. </h4>


        </div>

        
        <hr />

        <br />

        <div class="row text-center justify-content-center align-items-center">

            <h5 id="courtCity" class="col" runat="server"></h5>
            <h5 id="courtLimit" class="col" runat="server"></h5>

        </div>

        <br />

        <div class="row justify-content-center align-items-center">


            <a id="courtMap" runat="server" href="" target="_blank">
                <img id="court-map-icon" src="/images/marker.png" alt="" />
            </a>

        </div>

    </div>



</asp:Content>
