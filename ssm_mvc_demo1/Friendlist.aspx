<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Friendlist.aspx.cs" Inherits="ssm_mvc_demo1.Friendlist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">



    <div class="container-fluid w-100">

        <div class="content w-100">

            <div id="dynamicBody" runat="server"></div>

            <!-- empty friendlist -->
            <div id="flEmpty" class="fl-empty" runat="server" visible="false">Your friend list is empty 😓 </div>
            <!-- empty friendlist -->


            <%--            <div class="row d-flex w-100 mt-2 mb-2 mr-0 ml-0 m-0 p-2 friend align-items-center">

                <div class="col-8">

                    <div class="">Hello</div>

                </div>

                <div class="col-4 d-flex m-0 p-0 justify-content-end">
                    <div class="btn btn-sm btn-warning" id="21" onclick="removeFriend(this);return true;"> Remove </div>
                </div>

            </div>--%>

            <%--            <h5 runat="server" id="test"></h5>--%>


            <h3 id="test" runat="server"></h3>

        </div>

    </div>

    <asp:HiddenField ID="removedID" ClientIDMode="Static" Value="" runat="server" />
    <asp:HiddenField ID="invitedID" ClientIDMode="Static" Value="" runat="server" />
    <asp:Button Text="" Style="display: none;" ID="invite" OnClick="invite_Click" runat="server" />
    <asp:Button Text="" Style="display: none;" ID="remove" OnClick="remove_Click" runat="server" />


    <script>

        $(document).ready(function () {

            var urlParam = new URLSearchParams(window.location.search);
            if (urlParam.get("status") == "1")
                alert("Successfully removed ✔️");

            const urlParams = new URLSearchParams(window.location.search);
            const myParam = urlParams.get('invited');

            if (myParam == "yes")
                alert("Invite sent successfully 👌")


        });

        function removeFriend(element) {

            $("#removedID").attr("value", $(element).attr("id"));

            $("#MainContent_remove").click();

        }
        function sendInvite(element) {
            $("#invitedID").attr("value", $(element).attr("id"));

            call();

        }

        function successfulRemove() {
            alert("Successfully removed");
        }

        function call() {
            $("#MainContent_invite").click();
            $("#invite").click();
        }

    </script>


</asp:Content>
