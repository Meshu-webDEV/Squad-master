<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="location.aspx.cs" Inherits="ssm_mvc_demo1.location" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


   <!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCnNjMT1Fgq3lntEYEq_8yNQuqFL1BNMqk&libraries=places&sensor=false"></script>
    <script src="LocationSearch.js" type="text/javascript"></script>
    <link href="style.css" rel="stylesheet" type="text/css" />
    <style>
        #mapCanvas {
            width: 500px;
            height: 400px;
            float: left;
        }

        #infoPanel {
            float: left;
            margin-left: 10px;
        }

            #infoPanel div {
                margin-bottom: 5px;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <div style="height: 300px; width: 500px;" id="mapCanvas"></div>
            <div id="infoPanel">
                <b>Current position:</b>
                <div id="info"></div>
                <asp:Button ID="btnSubmit" ClientIDMode="Static" Text="Show Link" runat="server" OnClientClick="ShowLocation(); return false;" Visible="true" />
                <asp:HiddenField runat="server" ID="hiddenValue" />
                <asp:HiddenField runat="server" ID="hiddenValue1" />
            </div>
            
        </div>
    </form>
</body>
</html>


</asp:Content>
