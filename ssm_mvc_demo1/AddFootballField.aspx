<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddFootballField.aspx.cs" Inherits="ssm_mvc_demo1.AddFootballField" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<head>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCnNjMT1Fgq3lntEYEq_8yNQuqFL1BNMqk&libraries=places&sensor=false"></script>
    <script src="Scripts/LocationSearch.js"></script>
</head>

    <br />

    <div class="container-fluid justify-content-center">
        
        <div class="row justify-content-center">

            <div class="card">
			<div class="card-header">
				<h3>Add a new field</h3>
				
			</div>

                <br />


                <div class="row justify-content-center">
                    
                    <div id="map"></div>
                    
                </div>


                <br />

			<div class="row justify-content-center">
                

                    <%--Field name--%>
					<div class="input-group form-group">
						<div class="input-group-prepend">
							<span class="input-group-text"><i class="fas fa-user"></i></span>
						</div>
						<asp:TextBox runat="server" ID="courtName" type="text" class="form-control" placeholder="Field name" />
					</div>
                    <%--================--%>

                    <%--Field City--%>
					<div class="input-group form-group">
						<div class="input-group-prepend">
							<span class="input-group-text"><i class="fas fa-key"></i></span>
						</div>
						<asp:TextBox runat="server" ID="courtCity" type="text" class="form-control" placeholder="Field city" />
					</div>
                    <%--================--%>

                    <%--Field limit--%>
					<div class="input-group form-group">
						<div class="input-group-prepend">
							<span class="input-group-text"><i class="fas fa-key"></i></span>
						</div>
						
                        <asp:DropDownList runat="server" CssClass="form-control black-color-list" ID="courtLimit" ClientIDMode="Static">
                            <asp:ListItem Text="4 vs 4"  /> 
                            <asp:ListItem Text="5 vs 5" />
                            <asp:ListItem Text="6 vs 6"  />
                            <asp:ListItem Text="7 vs 7" />
                            <asp:ListItem Text="8 vs 8" />
                            <asp:ListItem Text="9 vs 9"  />
                            <asp:ListItem Text="10 vs 10" />
                            <asp:ListItem Text="11 vs 11" />
                        </asp:DropDownList>
					</div>
                    <%--================--%>

                    
                     <%--Field images--%>
					<div class="input-group form-group" style="width:auto;">
						<div class="input-group-prepend">
							<span class="input-group-text"><i class="fas fa-user"></i></span>
						</div>

                        <div id="image-preview-container" class="form-control input d-flex align-items-center">
                            <span id="field-images-placeholder">Field images</span> 
                        </div>
                        <label class="custom-file-upload">
                            <asp:FileUpload ID="imageUpload" runat="server" onchange="filesSelected(this.files)" AllowMultiple="true" />
                            <svg id="svgIcon" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 32 32" width="25" height="25" fill="none" stroke="currentcolor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2">
                                <path d="M9 22 C0 23 1 12 9 13 6 2 23 2 22 10 32 7 32 23 23 22 M11 18 L16 14 21 18 M16 14 L16 29" />
                            </svg>
                        </label>
					</div>
                    <%--================--%>


                    <%--Add a field--%>
                    <div class="input-group form-group">
                        <asp:Button Text="Add" ID="addCourt" runat="server" OnClick="addCourt_Click" class="btn btn-success" />
                    </div>
                    <%--================--%>


			</div>
			<div class="card-footer">
				<div class="d-flex justify-content-center links">
				</div>
			</div>

            <div ID="errorMessage" runat="server"></div>
		</div>

            </div>


    </div>

    <asp:HiddenField runat="server" ID="hiddenValue" ClientIDMode="Static" />
    <asp:HiddenField runat="server" ID="hiddenValue1" ClientIDMode="Static" />


    <script>

        $(document).ready(function () {

            $("#image-preview-container").css("width", $("#MainContent_courtCity").width() + $(".input-group-prepend:first").width() - $("#svgIcon").width() - 13);

        });

        var upload = $("#uploadLabel");
        var placeholder = $("#field-images-placeholder");
           
        function cancel() {

                placeholder.fadeIn("fast", function () {

                    $("#imageUpload").val("");
                    $("#cancelLabel").replaceWith(upload);
                    $("#imgSelected").replaceWith(placeholder);
                });

            };
    
    
        function filesSelected(files) {

            var count = files.length;
            var cancel = "<div id='cancelLabel' class='custom-file-upload' onclick='cancel()'> <svg id='cancelIcon' xmlns='http://www.w3.org/2000/svg' viewBox='0 0 32 32' width='20' height='20' fill='none' stroke='red' stroke-linecap='round' stroke-linejoin='round' stroke-width='2'> <path d='M2 30 L30 2 M30 30 L2 2' /> </svg > </div> ";

            $("#uploadLabel").replaceWith(cancel).fadeIn("fast");
            $("#field-images-placeholder").replaceWith("<b id='imgSelected' style='color:green;font-size: 14px;'>" + count + " images(s) has been selected </b>")
           
        

        };


    </script>

</asp:Content>
