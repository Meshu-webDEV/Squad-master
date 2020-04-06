<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MatchRoom.aspx.cs" Inherits="ssm_mvc_demo1.MatchRoom" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">



    <html class="h-100">

    <div class="container-fluid h-100 mb-5">

        <div class="content h-100">

            <h5 id="errorMsg" runat="server"></h5>

            <!-- Match info row -->
            <div id="row1" class="row">
                <div class="col">

                    <div id="pvt" runat="server" visible="false">
                        <div id="roomOpts" class="mr-opt mb-1">
                            <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 32 32" width="26" height="26" fill="none" stroke="currentcolor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2">
                                <path d="M28 6 L4 6 M28 16 L4 16 M28 26 L4 26 M24 3 L24 9 M8 13 L8 19 M20 23 L20 29" />
                            </svg>
                        </div>

                        <div class="toast" style="display: none;" data-autohide="false">
                            <div class="toast-header">
                                <strong class="mr-auto">Match options</strong>
                                <button type="button" class="ml-2 mb-1 close" data-dismiss="toast">&times;</button>
                            </div>
                            <div class="toast-body d-flex align-items-center justify-content-around">
                                <div>Change to</div>
                                <div class="btn btn-sm btn-warning" onclick="goPublic();return true;">Public</div>
                            </div>
                        </div>

                        <div id="roomPlus" class="mr-plus mt-2">
                            <div class="btn btn-xs btn-info p-1" onclick="inviteMatch();return true;">Invite frieds</div>
                        </div>
                    </div>

                    <div id="pvt1" runat="server" visible="false">
                        <div id="roomOpts1" class="mr-opt mb-1">
                            <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 32 32" width="26" height="26" fill="none" stroke="currentcolor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2">
                                <path d="M28 6 L4 6 M28 16 L4 16 M28 26 L4 26 M24 3 L24 9 M8 13 L8 19 M20 23 L20 29" />
                            </svg>
                        </div>

                        <div class="toast" style="display: none;" data-autohide="false">
                            <div class="toast-header">
                                <strong class="mr-auto">Match options</strong>
                                <button type="button" class="ml-2 mb-1 close" data-dismiss="toast">&times;</button>
                            </div>
                            <div class="toast-body d-flex align-items-center justify-content-around">
                                <div>Change to</div>
                                <div class="btn btn-sm btn-dark" onclick="goPrivate();return true;">Private</div>
                            </div>
                        </div>
                    </div>

                    <div class="flex-column justify-content-center align-content-center text-center">

                        <h5 id="matchName" runat="server"></h5>
                        <h6 id="status" class="subtitle-pvt" runat="server" visible="false"></h6>
                    </div>

                    <hr class="m-3" />

                    <div class="row d-flex align-items-center">

                        <label for="matchCity">
                            <svg id="i-location" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 32 32" width="20" height="20" fill="none" stroke="currentcolor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2">
                                <circle cx="16" cy="11" r="4" />
                                <path d="M24 15 C21 22 16 30 16 30 16 30 11 22 8 15 5 8 10 2 16 2 22 2 27 8 24 15 Z" />
                            </svg>
                        </label>
                        <h6 id="matchCity" runat="server" class="mx-2"></h6>
                    </div>


                    <div class="row d-flex align-items-center">
                        <label for="matchDate">
                            <svg id="i-clock" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 32 32" width="20" height="20" fill="none" stroke="currentcolor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2">
                                <circle cx="16" cy="16" r="14" />
                                <path d="M16 8 L16 16 20 20" />
                            </svg>
                        </label>
                        <h6 id="matchDate" runat="server" class="mx-2"></h6>
                    </div>



                    <div class="row d-flex justify-content-start align-content-center">


                        <svg id="i-user" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 32 32" width="20" height="20" fill="none" stroke="currentcolor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2">
                            <path d="M22 11 C22 16 19 20 16 20 13 20 10 16 10 11 10 6 12 3 16 3 20 3 22 6 22 11 Z M4 30 L28 30 C28 21 22 20 16 20 10 20 4 21 4 30 Z" />
                        </svg>
                        <h6 id="matchPlyrs" runat="server" class="mx-2">20/20</h6>

                    </div>


                </div>
            </div>
            <!-- /Match info row -->

            <hr class="m-3" />

            <!-- Court info row -->
            <div id="row2" class="row">

                <div class="col">

                    <!-- Court name -->
                    <div class="row mb-3">
                        <div class="col-9 d-flex justify-content-start">

                            <h6 id="courtName" runat="server"></h6>

                        </div>

                        <div class="col-3 d-flex justify-content-start">

                            <a href="" target="_blank" id="courtLocation" runat="server">
                                <img src="Content/images/map.jpg" height="20" width="20" />
                            </a>
                        </div>

                    </div>
                    <!-- /Court name -->


                    <!-- Court Images -->
                    <div class="row">

                        <div class="row d-flex w-100 m-0">
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
                                            <img id="img0" runat="server" class="img-fuild w-100 mr-imgs" src="Content/images/map.jpg" alt="First Image" />
                                        </div>
                                    </div>

                                    <!-- 2 -->
                                    <div id="imgblock1" class="carousel-item" runat="server">
                                        <div class="view w-100 d-flex justify-content-center">
                                            <img id="img1" runat="server" class="img-fuild w-100 mr-imgs" src="Content/images/map.jpg" alt="Second Image" />
                                        </div>
                                    </div>

                                    <!-- 3 -->
                                    <div id="imgblock2" class="carousel-item" runat="server">
                                        <div class="view w-100 d-flex justify-content-center">
                                            <img id="img2" runat="server" class="img-fuild w-100 mr-imgs" src="Content/images/map.jpg" alt="Third Image" />
                                        </div>
                                    </div>

                                    <!-- 4 -->
                                    <div id="imgblock3" class="carousel-item" runat="server">
                                        <div class="view w-100 d-flex justify-content-center">
                                            <img id="img3" runat="server" class="img-fuild w-100 mr-imgs" src="Content/images/map.jpg" alt="Fourth Image" />
                                        </div>
                                    </div>

                                    <!-- 5 -->
                                    <div id="imgblock4" class="carousel-item" runat="server">
                                        <div class="view w-100 d-flex justify-content-center">
                                            <img id="img4" runat="server" class="img-fuild w-100 mr-imgs" src="Content/images/map.jpg" alt="Fifth Image" />
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

                            <h4 id="notFound" runat="server" visible="false" class="w-75 text-center my-4" style="color: darkred;">No images found. </h4>


                        </div>

                    </div>
                    <!-- /Court Images -->

                </div>
            </div>
            <!-- /Court info row -->

            <hr class="m-3" />

            <!-- Players info row -->
            <div id="row3" class="row">


                <div class="col-5 text-center">

                    <div id="team1" runat="server">

                        <div id="Div0" class="row d-flex justify-content-center my-2 min-height blockquote-footer" runat="server" visible="false">Slot available!</div>
                        <div id="Div1" class="row d-flex justify-content-center my-2 min-height blockquote-footer" runat="server" visible="false">Slot available!</div>
                        <div id="Div2" class="row d-flex justify-content-center my-2 min-height blockquote-footer" runat="server" visible="false">Slot available!</div>
                        <div id="Div3" class="row d-flex justify-content-center my-2 min-height blockquote-footer" runat="server" visible="false">Slot available!</div>
                        <div id="Div4" class="row d-flex justify-content-center my-2 min-height blockquote-footer" runat="server" visible="false">Slot available!</div>
                        <div id="Div5" class="row d-flex justify-content-center my-2 min-height blockquote-footer" runat="server" visible="false">Slot available!</div>
                        <div id="Div6" class="row d-flex justify-content-center my-2 min-height blockquote-footer" runat="server" visible="false">Slot available!</div>
                        <div id="Div7" class="row d-flex justify-content-center my-2 min-height blockquote-footer" runat="server" visible="false">Slot available!</div>
                        <div id="Div8" class="row d-flex justify-content-center my-2 min-height blockquote-footer" runat="server" visible="false">Slot available!</div>
                        <div id="Div9" class="row d-flex justify-content-center my-2 min-height blockquote-footer" runat="server" visible="false">Slot available!</div>
                        <div id="Div10" class="row d-flex justify-content-center my-2 blockquote-footer" runat="server" visible="false">Slot available!</div>

                    </div>


                    <hr class="m-2" />

                    <asp:Button ID="JoinA" Text="Join team A!" CssClass="btn btn-sm btn-success" runat="server" OnClick="JoinA_Click" />
                    <asp:Button ID="LeaveA" Text="Leave" CssClass="btn btn-sm btn-warning" runat="server" OnClick="LeaveA_Click" Visible="false" />
                    <div id="teamAfull" runat="server" class="btn btn-sm btn-secondary disabled px-1 py-2" visible="false">Team A is full 😞 </div>

                </div>


                <!-- Col spacer -->
                <div class="col-2"></div>
                <!-- /Col spacer -->


                <div class="col-5 text-center">

                    <div id="team2" runat="server">

                        <div id="Div11" class="row d-flex justify-content-center my-2 min-height blockquote-footer" runat="server" visible="false">Slot available</div>
                        <div id="Div12" class="row d-flex justify-content-center my-2 min-height blockquote-footer" runat="server" visible="false">Slot available</div>
                        <div id="Div13" class="row d-flex justify-content-center my-2 min-height blockquote-footer" runat="server" visible="false">Slot available</div>
                        <div id="Div14" class="row d-flex justify-content-center my-2 min-height blockquote-footer" runat="server" visible="false">Slot available</div>
                        <div id="Div15" class="row d-flex justify-content-center my-2 min-height blockquote-footer" runat="server" visible="false">Slot available</div>
                        <div id="Div16" class="row d-flex justify-content-center my-2 min-height blockquote-footer" runat="server" visible="false">Slot available</div>
                        <div id="Div17" class="row d-flex justify-content-center my-2 min-height blockquote-footer" runat="server" visible="false">Slot available</div>
                        <div id="Div18" class="row d-flex justify-content-center my-2 min-height blockquote-footer" runat="server" visible="false">Slot available</div>
                        <div id="Div19" class="row d-flex justify-content-center my-2 min-height blockquote-footer" runat="server" visible="false">Slot available</div>
                        <div id="Div20" class="row d-flex justify-content-center my-2 min-height blockquote-footer" runat="server" visible="false">Slot available</div>
                        <div id="Div21" class="row d-flex justify-content-center my-2 min-height blockquote-footer" runat="server" visible="false">Slot available</div>

                    </div>

                    <hr class="m-2" />

                    <asp:Button ID="JoinB" Text="Join team B!" CssClass="btn btn-sm btn-success" runat="server" OnClick="JoinB_Click" />
                    <asp:Button ID="LeaveB" Text="Leave" CssClass="btn btn-sm btn-warning" runat="server" OnClick="LeaveB_Click" Visible="false" />
                    <div id="teamBfull" runat="server" class="btn btn-sm btn-secondary disabled px-1 py-2" visible="false">Team B is full 😞 </div>
                </div>

            </div>
            <!-- /Players info row -->

            <h3 runat="server" id="testy"></h3>

        </div>

    </div>

    <asp:Button Text="" Style="display: none;" ID="GoPublic" OnClick="GoPublic_Click" runat="server" ClientIDMode="Static" />
    <asp:Button Text="" Style="display: none;" ID="GoPrivate" OnClick="GoPrivate_Click" runat="server" ClientIDMode="Static" />
    <asp:Button Text="" Style="display: none;" ID="inviteMatch" OnClick="inviteMatch_Click" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="currentUser" runat="server" />
    <asp:HiddenField ID="currentTeam" runat="server" />

    <script>

        function goPublic() {

            $("#MainContent_GoPublic").click();
            $("#GoPublic").click();


        }

        function goPrivate() {

            $("#MainContent_GoPrivate").click();
            $("#GoPrivate").click();

        }

        function inviteMatch() {

            $("#MainContent_inviteMatch").click();
            $("#inviteMatch").click();

        }

        //$(document).ready(function () {


        //    var username = $("#MainContent_currentUser").val();
        //    var parent = $("div:contains('" + username + "')").filter(function () {

        //        return $(this).text() === username;

        //    }).parent().attr("id");


        //    if (parent == "MainContent_team1") {
        //        $("div:contains('" + username + "')").filter(function () {

        //            return $(this).text() === username;

        //        }).addClass("current-user-a");
        //    }

        //    if (parent == "MainContent_team2") {
        //        $("div:contains('" + username + "')").filter(function () {

        //            return $(this).text() === username;

        //        }).addClass("current-user-b");
        //    }

        //});


        $("#roomOpts").click(function (e) {

            $(".toast").fadeIn(50);
            $(".toast").animate({}, 400, function () {
                $(".toast").toast('show');
            });

        });

        $("#roomOpts1").click(function (e) {

            $(".toast").fadeIn(50);
            $(".toast").animate({}, 400, function () {
                $(".toast").toast('show');
            });

        });


    </script>

    </html>
</asp:Content>
