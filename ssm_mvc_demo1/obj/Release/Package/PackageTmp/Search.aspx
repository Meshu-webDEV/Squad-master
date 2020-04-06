<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="ssm_mvc_demo1.Search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">



    <div class="container-fluid h-100">

        <div class="content h-100">

            <h4 class="text-center w-100 my-4"> - Search - </h4>

            <div id="searchBar" class="row mt-4">

                <div id="bar" class="col-9">
                    <asp:TextBox runat="server" id="searchQ" CssClass="form-control" placeholder="search query"/>
                </div>

                <div id="searchBtn" class="col-3">
                    <asp:Button Text="Search" runat="server" CssClass="btn btn-info" OnClick="Search_Click"/>
                </div>

            </div>

            <div class="row my-2">

                    <asp:RadioButtonList ID="searchFilter" runat="server" RepeatDirection="Horizontal" CssClass="w-100 my-3">
                        <asp:ListItem Text="User" id="filterUser" class="p-2 m-3" Value="1" Selected/>
                        <asp:ListItem Text="Match" id="filterMatch" class="p-2 m-3" Value="2" />
                        <asp:ListItem Text="Field" id="filterCourt" class="p-2 m-3" Value="3"/>
                        
                    </asp:RadioButtonList>
              


            </div>

            <hr class="my-2"/>

            <div class="row">

                <div class="col" id="searchResults" runat="server">

                </div>

            </div>

            <h4 id="errorMsg" runat="server"></h4>

        </div>

    </div>



</asp:Content>
