<%@ Page Title="" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true"
    CodeBehind="ChangePassword.aspx.cs" Inherits="Openend_SIP.Modules.MainPage.ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Change Password | </title>
    <link rel="icon" href="/Styles/Images/apple-icon-57x57.png" type="image/gif" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .card-body
        {
            padding: 1rem !important;
        }
        #passwordPolicy
        {
            text-align: justify;
            padding: 3%;
            color: red;
            font-size: 0.8em;
        }
    </style>
       <form id ="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:HiddenField ID="forgeryToken" runat="server"/>
    <div class="wrapper fadeInDown">
        <div id="formContent">
            <!-- Tabs Titles -->
            <h3 style="margin-top: 10px; font-family: -webkit-body; color: #22429a;">
                Change Password</h3>
            <hr />
            <!-- Icon -->
            <div class="fadeIn first">
                <img src="" id="img3">
            </div>
            <!-- Login Form -->
            <form>
            <input type="text" id="txtUsername" class="fadeIn second" placeholder="UserName"
                data-bind="value:UserName,valueUpdate: 'input'"
                name="UserName" class="form-control" id="txtUserName">
            <input type="password" class="fadeIn second" data-bind="value:OldPass," name="OldPass"
                class="form-control" placeholder="Password" id="txtOldPass">
            <input type="password" class="fadeIn second" data-bind="value:Password" name="NewPass"
                class="form-control" placeholder="New Password" id="txtNewPass">
            <input type="password" id="txEmail" class="fadeIn third" data-bind="value:ReNewPass"
                name="Password" placeholder="ReType Password" class="form-control" id="Password2">
                <p  id="passwordPolicy">
                Password Must Contain at least eight characters, at least one number and both lower and uppercase letters and special characters`@#$`
                </p>
            <input type="button" value="Submit" data-bind="click:ChangePassword" class="fadeIn fourth" />
            </form>
             <div id="lock-modal"></div>
             <div id="loading-circle"></div>
            <div class="col-md-12 links">
                <center>
                    <small>Back To <a href="/Modules/HomePage.aspx">Home Page</a></small>
                    <br />
                    <br />
            </div>
        </div>
    </div>
    </form>
    <script src="../../Scripts/MainPage/ChangePassword.js?v=0.1" type="text/javascript"></script>
    <%--<script src="../../Scripts/MainPage/ChangePassword.js" type="text/javascript"></script>--%>
</asp:Content>
