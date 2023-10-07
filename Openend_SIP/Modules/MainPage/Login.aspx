<%@ Page Title="" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Openend_SIP.Modules.MainPage.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<title> Login |  </title>
  <link rel="icon" href="/Styles/Images/apple-icon-57x57.png" type="image/gif" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <form id ="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:HiddenField ID="forgeryToken" runat="server"/>
<div class="wrapper fadeInDown">
  <div id="formContent">
    <!-- Tabs Titles -->

    <!-- Icon -->
    <div class="fadeIn first">
    <img src="" id="img3" style="PADDING-TOP:10PX">
    </div>

    <!-- Login Form -->
          <input type="text" id="login" class="fadeIn second"  placeholder="Username" data-bind="value:UserName" name="Username"/ >
          <input type="password" id="password" class="fadeIn third"  data-bind="value:Password" name="Password" placeholder="Password"/><br />
          <input type="submit" class="fadeIn fourth" value="Log In" data-bind="click:LoginUser">

    <div id="lock-modal"></div>
    <div id="loading-circle"></div>
    <!-- Remind Passowrd -->
     <div class="col-md-12 links">
		<center><small>Back To <a href="/Modules/HomePage.aspx">Home Page</a></small>
        <small><a href="/Modules/MainPage/Forgotpassword.aspx"">Forgot your password?</a></small><br />
        <small><a href="/Modules/MainPage/ForgotUsername.aspx"">Forgot your UserName?</a></small></center>
     <br /><br />
	</div>
  </div>
</div>
</form>
    <script src="../../Scripts/MainPage/LoginUser.js?v=0.1" type="text/javascript"></script>
   
</asp:Content>
