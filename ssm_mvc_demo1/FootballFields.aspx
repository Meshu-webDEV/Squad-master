<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FootballFields.aspx.cs" Inherits="ssm_mvc_demo1.FootballFields" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <br />
    <div class="container-fluid">
        
        <div class="row justify-content-center"><h5>Add a new football field</h5></div>

        <div class="row justify-content-center">

            <a id="addFieldHref" runat="server" href="/AddFootballField.aspx"> 
                <h4 id="addFieldButton" runat="server" class="btn btn-success"> Add + </h4>
            </a> 

        </div>
            
        <br />
        <hr />
    </div>
    

</asp:Content>
