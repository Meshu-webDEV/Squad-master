<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateMatchForm.aspx.cs" Inherits="ssm_mvc_demo1.CreateMatchForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script src="Scripts/jquery-ui.js"></script>
    <script src="Scripts/jquery-TimePicker-1.0.0.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/timepicker/1.3.5/jquery.timepicker.min.js"></script>
    <link rel="stylesheet" href="//cdnjs.cloudflare.com/ajax/libs/timepicker/1.3.5/jquery.timepicker.min.css">
    <link href="Content/jquery-ui.css" rel="stylesheet" />
    <link href="Content/jquery-ui.structure.css" rel="stylesheet" />
    <link href="Content/jquery-ui.theme.css" rel="stylesheet" />
    <script src="Scripts/courtIdSelect.js"></script>

    <div class="container mb-60">


        <div class="d-flex card-header justify-content-center">
            <h2>Create a match</h2>
        </div>

        <br />

        <div class="col justify-content-center">


            <%--MATCH NAME--%>
            <div class="row w-100">

                <h6>Match name</h6>

            </div>

            <div class="row mb-3">

                <asp:TextBox runat="server" ID="matchName" type="text" class="form-control" placeholder="Match name" />

            </div>
            <%-- ====== --%>

            <%-- ====== --%>

            <%--MATCH TYPE--%>
            <div class="row w-100">

                <h6>Match type</h6>

            </div>

            <div class="row mb-3">

                <asp:DropDownList runat="server" CssClass="form-control black-color-list" ID="matchType" ClientIDMode="Static">
                    <asp:ListItem Text="Public" />
                    <asp:ListItem Text="Private" />
                </asp:DropDownList>

            </div>
            <%-- ====== --%>


            <%--MATCH FIELD--%>
            <div class="row w-100">

                <h6>Match field</h6>

            </div>


            <div runat="server" class="row mb-3">

                <div runat="server" id="fieldCard" class="card w-100 h-25">
                </div>

            </div>
            <%-- ====== --%>

            <%--MATCH DATE AND TIME--%>
            <div class="row w-100">

                <h6>Match date</h6>

            </div>

            <div class="row mb-3">

                <asp:TextBox runat="server" ID="matchDate" class="form-control" ClientIDMode="Static" />

            </div>

            <div class="row w-100">

                <h6>Match time</h6>

            </div>

            <div class="row mb-3">

                <asp:TextBox runat="server" ID="matchTime" class="form-control" ClientIDMode="Static" />

            </div>
            <%-- ====== --%>

            <h4 id="test" runat="server"></h4>

            <asp:HiddenField ID="selectedId" runat="server" Value="" ClientIDMode="Static" />

            <div runat="server" class="row mb-3">

                <asp:Button Text="Create a match" runat="server" OnClick="createMatch_Click" CssClass="btn btn-success" />

            </div>

        </div>




    </div>

    <script>
        $(document).ready(function () {

            $('#matchTime').timepicker({
                timeFormat: "HH:mm p",
                interval: 60
            });
            $("#matchDate").datepicker({
                dateFormat: 'yy-mm-dd'
            });
        });
    </script>

</asp:Content>
