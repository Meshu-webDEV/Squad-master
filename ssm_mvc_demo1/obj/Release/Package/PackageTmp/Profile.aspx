<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="ssm_mvc_demo1.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div class="container-fluid h-100" runat="server" id="container">

        <div class="content h-100" runat="server" id="content">

            <div class="row w-100 m-0" id="p-avatar">

                <div class="col d-flex justify-content-center">

                    <div class="gear" id="gear" runat="server" onclick="gearHidden(); return true;">
                        <img src="images/gear.png" alt="" width="40" />
                    </div>

                    <img id="avatar" runat="server" class="image-object-fit-150" src="" />
                    <div id="shadow"></div>

                </div>

            </div>

            <div id="p-username" class="row w-100 mb-1 mt-2 ml-0 mr-0">

                <div class="col d-flex justify-content-center">

                    <h5 id="username" runat="server" class="p-1 username"></h5>

                </div>

            </div>

            <div id="p-bio" class="row w-100 m-0">

                <div class="col d-flex justify-content-center">

                    <div class="bio-outer w-100">
                        <asp:TextBox class="bio w-100 m-0 p-2" runat="server" ID="bio" placeholder="bio..." disabled TextMode="MultiLine" />
                        <textarea class="bio w-100 m-0 p-2" runat="server" id="editingbio" visible="false" aria-multiline></textarea>
                    </div>

                    <div class="bio-edit" id="plus" runat="server" onclick="plusHidden(); return true;">
                        <svg id="i-plus" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 32 32" width="25" height="24" fill="none" stroke="grey" stroke-linecap="round" stroke-linejoin="round" stroke-width="2">
                            <path d="M16 2 L16 30 M2 16 L30 16" />
                        </svg>
                    </div>

                </div>

            </div>

            <hr class="my-3" />

            <h5 id="infoTitle" runat="server" class="row w-100 mb- ml-0 mr-0 mt-0"></h5>

            <div id="p-info" class="row w-100 m-0 d-flex justify-content-center">

                <div id="p-matches" class="col-5 d-flex justify-content-center">

                    <div class="box d-flex flex-column">

                        <div class="info-title">
                            Matches played
                        </div>

                        <h5 id="matchesPlayed" runat="server"></h5>

                    </div>

                </div>

                <div id="p-spacer" class="col-1"></div>

                <div id="p-position" class="col-5 d-flex justify-content-center">

                    <div class="box d-flex flex-column">

                        <div class="info-title">
                            position
                        </div>

                        <asp:DropDownList runat="server" CssClass="btn ddl-profile dropdown-toggle" ID="ddlpos" Visible="false">
                            <asp:ListItem Text="GK" Value="GK" Selected />
                            <asp:ListItem Text="DF" Value="DF" />
                            <asp:ListItem Text="MF" Value="MF" />
                            <asp:ListItem Text="FW" Value="FW" />
                        </asp:DropDownList>

                        <h5 id="position" runat="server"></h5>

                    </div>

                </div>

            </div>

            <hr class="my-3 mt-5" />

            <div id="p-request" class="row w-100 m-0 d-flex justify-content-center">

                <asp:Button Text="Friend request" runat="server" CssClass="btn btn-info" ID="req" OnClick="req_Click" />
                <div class="btn btn-warning disabled-button" id="pending" runat="server" visible="false">Pending...</div>
                <asp:Button Text="Submit" CssClass="btn btn-info" ID="SubmitGear" OnClick="SubmitGear_Click" Visible="false" runat="server" />
            </div>

            <div id="test" runat="server"></div>

            <asp:Button ID="profEdit" ClientIDMode="Static" Text="" Style="display: none;" OnClick="ProfEdit_Click" runat="server" />
            <asp:Button ID="bioEdit" Text="" ClientIDMode="Static" Style="display: none;" OnClick="bioEdit_Click" runat="server" />

        </div>

    </div>

    <script>
        $(document).ready(function () {

        });

        function gearHidden() {

            $("#profEdit").click();


        }

        function plusHidden() {

            $("#bioEdit").click();

        }

    </script>

</asp:Content>
