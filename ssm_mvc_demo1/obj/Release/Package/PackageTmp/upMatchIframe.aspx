<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="upMatchIframe.aspx.cs" Inherits="ssm_mvc_demo1.upMatchIframe" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" class="m-0">
<head runat="server">
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/jquery-ui.css" rel="stylesheet" />
    <link href="Content/jquery-ui.structure.css" rel="stylesheet" />
    <link href="Content/jquery-ui.theme.css" rel="stylesheet" />
    <link href="Content/Site.css" rel="stylesheet" />
    <link href="Content/bootstrap-theme.css" rel="stylesheet" />
    <link href="Content/bootstrap-theme.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
    <script src="https://code.jquery.com/jquery-3.4.1.js" integrity="sha256-WpOohJOqMqqyKL9FccASB9O0KwACQJpFTUBLTYOVvVU=" crossorigin="anonymous"></script>
    <script src="Scripts/bootstrap.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/jquery-3.4.1.intellisense.js"></script>
    <script src="Scripts/jquery-3.4.1.js"></script>
    <script src="Scripts/jquery-3.4.1.min.js"></script>
    <script src="Scripts/jquery-3.4.1.slim.js"></script>
    <script src="Scripts/jquery-3.4.1.slim.min.js"></script>
    <script src="Scripts/jquery-TimePicker-1.0.0.js"></script>
    <script src="Scripts/jquery-ui.js"></script>
    <script src="Scripts/ernizr-2.8.3.js"></script>
    <script src="Scripts/bootstrap.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/jquery-3.4.1.intellisense.js"></script>
    <script src="Scripts/jquery-3.4.1.js"></script>
    <script src="Scripts/jquery-3.4.1.min.js"></script>

</head>



<body class="p-0">

    <div class="container-fluid p-0">

        <div class="content">

            <div id="row1" class="row d-flex justify-content-center mb-1">
                <div class="col">
                    <div id="Mname" class="text-center my-2 h4" runat="server">
                    </div>

                    <div id="imgs" class="d-flex justify-content-center my-1" runat="server">
                        <!-- Carousel wrapper -->
                        <div id="carousel" runat="server" class="w-75 carousel slide carousel-fade" data-ride="carousel">


                            <!-- Images -->
                            <div class="carousel-inner" role="listbox">

                                <!-- 1 -->
                                <div id="imgblock0" class="carousel-item active" runat="server">
                                    <div class="view d-flex justify-content-center">
                                        <img id="img0" runat="server" class="img-fluid" src="" style="width: 90px;" alt="First Image" />
                                    </div>
                                </div>

                                <!-- 2 -->
                                <div id="imgblock1" class="carousel-item" runat="server">
                                    <div class="view d-flex justify-content-center">
                                        <img id="img1" runat="server" class="img-fluid" src="" style="width: 90px;" alt="Second Image" />
                                    </div>
                                </div>

                                <!-- 3 -->
                                <div id="imgblock2" class="carousel-item" runat="server">
                                    <div class="view d-flex justify-content-center">
                                        <img id="img2" runat="server" class="img-fluid" src="" style="width: 90px;" alt="Third Image" />
                                    </div>
                                </div>

                                <!-- 4 -->
                                <div id="imgblock3" class="carousel-item" runat="server">
                                    <div class="view d-flex justify-content-center">
                                        <img id="img3" runat="server" class="img-fluid" src="" style="width: 90px;" alt="Fourth Image" />
                                    </div>
                                </div>

                                <!-- 5 -->
                                <div id="imgblock4" class="carousel-item" runat="server">
                                    <div class="view d-flex justify-content-center">
                                        <img id="img4" runat="server" class="img-fluid" src="" style="width: 90px;" alt="Fifth Image" />
                                    </div>
                                </div>

                            </div>
                            <!--/.Images -->

                            <!--Controls-->
                            <a class="carousel-control-prev" href="#carousel" role="button" data-slide="prev">
                                <svg id="i-chevron-left" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 32 32" width="32" height="32" fill="none" stroke="#212529" stroke-linecap="round" stroke-linejoin="round" stroke-width="3">
                                    <path d="M20 30 L8 16 20 2" />
                                </svg>
                            </a>
                            <a class="carousel-control-next" href="#carousel" role="button" data-slide="next">
                                <svg id="i-chevron-right" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 32 32" width="32" height="32" fill="none" stroke="#212529" stroke-linecap="round" stroke-linejoin="round" stroke-width="3">
                                    <path d="M12 30 L24 16 12 2" />
                                </svg>
                            </a>
                            <!--/.Controls-->

                        </div>
                        <!-- /.Carousel wrapper -->

                        <h5 id="notFound" runat="server" visible="false" class="w-75 text-center my-4" style="color: darkred;"> No images available for the field. </h5>

                    </div>

                    <div id="Cname" class="text-center my-2" runat="server">
                    </div>
                </div>


            </div>

            <hr class="mb-2 mt-0" />

            <div id="row2" class="row d-flex justify-content-center w-100 m-auto">

                <div id="Minfo" class="justify-content-center align-self-center text-center m-0 p-1">

                    <div class="row my-1">
                        <span>
                            <svg id="i-user" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 32 32" width="14" height="14" fill="none" stroke="currentcolor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2">
                                <path d="M22 11 C22 16 19 20 16 20 13 20 10 16 10 11 10 6 12 3 16 3 20 3 22 6 22 11 Z M4 30 L28 30 C28 21 22 20 16 20 10 20 4 21 4 30 Z" />
                            </svg>
                        </span>
                        <div id="plyrs" runat="server" class="ml-1 h6">20/20</div>
                    </div>

                    <div class="row my-1">
                        <span>
                            <svg id="i-location" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 32 32" width="14" height="14" fill="none" stroke="currentcolor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2">
                                <circle cx="16" cy="11" r="4" />
                                <path d="M24 15 C21 22 16 30 16 30 16 30 11 22 8 15 5 8 10 2 16 2 22 2 27 8 24 15 Z" />
                            </svg>
                        </span>
                        <div id="Mcity" runat="server" class="ml-1 h6"></div>
                    </div>

                    <div class="row my-1">
                        <span>
                            <svg id="i-clock" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 32 32" width="14" height="14" fill="none" stroke="currentcolor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2">
                                <circle cx="16" cy="16" r="14" />
                                <path d="M16 8 L16 16 20 20" />
                            </svg>
                        </span>
                        <div id="Mdatetime" runat="server" class="ml-1 h6"></div>
                        <br />
                        <div id="Mtime" runat="server"></div>
                    </div>

                </div>

                

            </div>

            <hr class="my-2" />

            <div id="row3" class="row d-flex justify-content-center align-content-center my-1">
                
                <div id="Cmap" class="justify-content-center align-content-center d-flex ml-3">

                    <div id="Clocation" runat="server"> 

                    </div>

                </div>
                   
            </div>

        </div>

    </div>

</body>
</html>
