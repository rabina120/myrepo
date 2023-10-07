<%@ Page Title="" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="Forgotpassword.aspx.cs" Inherits="Openend_SIP.Modules.MainPage.Forgotpassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Forgot Password |  </title>
    <link rel="icon" href="/Styles/Images/apple-icon-57x57.png" type="image/gif" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        .card-body {
            padding: 1rem !important;
        }
    </style>
       <form id ="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:HiddenField ID="forgeryToken" runat="server"/>
    <div class="wrapper fadeInDown">
        <div id="formContent">
            <!-- Tabs Titles -->
            <h3 style="margin-top: 10px; font-family: -webkit-body; color: #22429a;">Forgot Password</h3>
            <hr />
            <!-- Icon -->
            <div class="fadeIn first">
                <img src="" id="img3">
            </div>

            <!-- Login Form -->
            <form>
                <center>
                    <select style="width: 85%" id="dp" class="form-control Existing" data-bind='options: Depo, optionsText: "DPName", value: SelectedDp, optionsCaption: "   --- Select your DP --- "'>
                    </select>
                </center>
                <center>
                    <input type="text" id="txtboid" onkeypress="return isNumberKey(event)" class="form-control Existing"
                        maxlength="8" data-bind="value: Boid_No" placeholder="BOID No." />
                </center>
                <input type="text" id="txtUsername" class="fadeIn second" data-bind="value: UserName, valueUpdate: 'input'" placeholder="Username" name="Username" />
                <input type="text" id="txEmail" class="fadeIn third" data-bind="value: Email, valueUpdate: 'input' " name="Email" placeholder="Email" /><br />
                <input type="button" value="Submit" data-bind="click: SendEmail" class="fadeIn fourth" />
            </form>
            <div id="lock-modal"></div>
            <div id="loading-circle"></div>
            <div class="col-md-12 links">

                <small>Back To <a href="/Modules/HomePage.aspx">Home Page</a> <a href="/Modules/MainPage/Login.aspx">Login Page</a></small>

                <br />
                <br />
            </div>


        </div>
    </div>
    </form>
    <script src="../../Scripts/MainPage/ForgotPassword.js?v=0.1" type="text/javascript"></script>
</asp:Content>
