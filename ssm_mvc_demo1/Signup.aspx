﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="ssm_mvc_demo1.Signup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="d-flex justify-content-center h-100">
            <div class="card">
                <div class="card-header">
                    <h3>Sign up</h3>
                    <div class="d-flex justify-content-end social_icon">
                        <span><i class="fab fa-facebook-square"></i></span>
                        <span><i class="fab fa-google-plus-square"></i></span>
                        <span><i class="fab fa-twitter-square"></i></span>
                    </div>
                </div>
                <div class="card-body">

                    <%--Username--%>
                    <div class="input-group form-group">
                        <div class="input-group-prepend">
                            <span class="input-group-text"><i class="fas fa-user"></i></span>
                        </div>
                        <asp:TextBox runat="server" ID="username" type="text" class="form-control" placeholder="username" />
                    </div>
                    <%--================--%>

                     <%--Email--%>
                    <div class="input-group form-group">
                        <div class="input-group-prepend">
                            <span class="input-group-text"><i class="fas fa-user"></i></span>
                        </div>
                        <asp:TextBox runat="server" ID="email" type="text" class="form-control" placeholder="Email" />
                    </div>
                    <%--================--%>

                    <%--Password and confirm password--%>
                    <div class="input-group form-group">
                        <div class="input-group-prepend">
                            <span class="input-group-text"><i class="fas fa-key"></i></span>
                        </div>
                        <asp:TextBox runat="server" ID="password" type="password" class="form-control" placeholder="password" />
                    </div>
                    <div class="input-group form-group">
                        <div class="input-group-prepend">
                            <span class="input-group-text"><i class="fas fa-key"></i></span>
                        </div>
                        <asp:TextBox runat="server" ID="cpassword" type="password" class="form-control" placeholder="Confirm password" />
                    </div>
                    <%--================--%>

                    <%--Submit--%>
                    <div class="form-group">
                        <asp:Button Text="Submit" ID="signupButton" OnClick="signup_Click" runat="server" value="Login" class="btn float-right btn-primary" />
                    </div>
                    <%--================--%>
                </div>
                <div class="card-footer">
                    <div class="d-flex justify-content-center links">
					Have an account?<a href="/Login.aspx">Login</a>
				</div>
                </div>
            </div>
            <div id="errorMessage" runat="server"></div>
        </div>
    </div>

</asp:Content>
