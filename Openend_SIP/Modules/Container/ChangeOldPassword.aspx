<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="ChangeOldPassword.aspx.cs" Inherits="Openend_SIP.Modules.Container.ChangeOldPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Change Password | NIBL ACE Capital </title>
    <link rel="icon" href="/Styles/Images/apple-icon-57x57.png" type="image/gif" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
    .card-body
    {
        padding: 1rem !important;
           
    }


/* Style the tab */
.tab {
  overflow: hidden;
  border: 1px solid #ccc;
  background-color: #f1f1f1;
}
   label
        {
            font-weight: bold;
            font-size: 15px;
        }

/* Style the buttons inside the tab */
.tab button {
  background-color: inherit;
  float: left;
  border: none;
  outline: none;
  cursor: pointer;
  padding: 14px 16px;
  transition: 0.3s;
  font-size: 17px;
}

/* Change background color of buttons on hover */
.tab button:hover {
  background-color: #ddd;
}

/* Create an active/current tablink class */
.tab button.active {
  background-color: #ccc;
}

/* Style the tab content */
.tabcontent {
  display: none;
  padding: 6px 12px;
  -webkit-animation: fadeEffect 1s;
  animation: fadeEffect 1s;
}

/* Fade in tabs */
@-webkit-keyframes fadeEffect {
  from {opacity: 0;}
  to {opacity: 1;}
}

@keyframes fadeEffect {
  from {opacity: 0;}
  to {opacity: 1;}
}

    .mandatory
        {
            color: red;
        }
        
   
</style>
    <div class="container">
       <%-- <h3 style="text-align: center;">
           User Profile Setup</h3>--%>
        <h4 style="text-align: center;">
          Change Password</h4>
        <div class="row">
            <div class="col-md-11">
                <div class="tab">
               <%--     <button class="tablinks active" onclick="openTab(event, 'Profile')" id="defaultOpen">
                        Change Details</button>--%>
                    <button class="tablinks active" onclick="openTab(event, 'ChangePassword')" id="defaultOpen">
                        Change Password</button>
                </div>
            </div>
        </div>
     <%--   <div id="Profile" class="tabcontent t in active">
            <div class="panel-body" id="statusHide">
                <div class="form-group row">
                    <label for="txtSubmissionDate" class="col-sm-12 col-md-2 col-form-label">
                        DP Name:</label>
                    <div class="col-sm-12 col-md-4">
                        <input type="text" readonly class="form-control" id="Text1" style="cursor: pointer;"
                            data-bind="value:DP_NAME()" />
                    </div>
                </div>
                <div class="form-group row">
                    <label for="txtStatus" class="col-sm-12 col-md-2 col-form-label">
                        BOID No:</label>
                    <div class="col-sm-12 col-md-4">
                        <input type="text" readonly class="form-control" style="cursor: pointer;" id="txtStatus"
                            data-bind="value:Bo_Account_No()" />
                    </div>
                </div>
                <div class="form-group row">
                    <label for="txtStatus" class="col-sm-12 col-md-2 col-form-label">
                        Name:</label>
                    <div class="col-sm-12 col-md-4">
                        <input type="text" class="form-control" id="Text2" data-bind="value:Name" />
                    </div>
                </div>
                <div class="form-group row">
                    <label for="txtStatus" class="col-sm-12 col-md-2 col-form-label">
                        Account Status:</label>
                    <div class="col-sm-12 col-md-4">
                        <input type="text" readonly class="form-control" style="cursor: pointer;" id="Text3"
                            data-bind="value:ActiveStatus()" />
                    </div>
                </div>
                <div class="form-group row">
                    <label for="txtStatus" class="col-sm-12 col-md-2 col-form-label">
                        Date of Birth:</label>
                    <div class="col-sm-12 col-md-4">
                        <input type="date" class="form-control" style="cursor: pointer;" id="Text4" data-bind="value:DOB" />
                    </div>
                </div>
                <div class="form-group row">
                    <label for="txtStatus" class="col-sm-12 col-md-2 col-form-label">
                        Citizenship Number:</label>
                    <div class="col-sm-12 col-md-4">
                        <input type="text" readonly class="form-control" style="cursor: pointer;" id="Text5"
                            data-bind="value:Citizenship_No()" />
                    </div>
                </div>
                <div class="form-group row">
                    <label for="txtStatus" class="col-sm-12 col-md-2 col-form-label">
                        Account Open Date:</label>
                    <div class="col-sm-12 col-md-4">
                        <input type="date" readonly class="form-control" style="cursor: pointer;" id="Text6"
                            data-bind="value:CreatedDate()" />
                    </div>
                </div>
                <div class="form-group row">
                    <label for="txtStatus" class="col-sm-12 col-md-2 col-form-label">
                        Contact Number:</label>
                    <div class="col-sm-12 col-md-4">
                        <input type="text" class="form-control" style="cursor: pointer;" id="Date1" data-bind="value:Contact_No" />
                    </div>
                </div>
                <div class="form-group row">
                    <label for="txtStatus" class="col-sm-12 col-md-2 col-form-label">
                        Email:</label>
                    <div class="col-sm-12 col-md-4">
                        <input type="text" class="form-control" style="cursor: pointer;" id="Date2" data-bind="value:Email" />
                    </div>
                </div>
                <div class="form-group row">
                    <label for="txtStatus" class="col-sm-12 col-md-2 col-form-label">
                        Bank Name:</label>
                    <div class="col-sm-12 col-md-4">
                        <input type="text" readonly class="form-control" style="cursor: pointer;" id="Date3"
                            data-bind="value:bankname()" />
                    </div>
                </div>
                <div class="form-group row">
                    <label for="txtStatus" class="col-sm-12 col-md-2 col-form-label">
                        Account Number:</label>
                    <div class="col-sm-12 col-md-4">
                        <input type="text" readonly class="form-control" style="cursor: pointer;" id="Date4"
                            data-bind="value:Bank_Account_No()" />
                    </div>
                </div>
                <div class="form-group row">
                    <label for="txtStatus" class="col-sm-12 col-md-5 col-form-label">
                    </label>
                    <div class="col-sm-12 col-md-4">
                        <button class="btn btn-primary" id="btnSave" data-bind="click:UpdateProfile">
                            Update</button>
                    </div>
                </div>
            </div>
        </div>--%>
        <div id="ChangePassword" class="tabcontent t in active">
            <div class="card-body ">
                <div class="col-md-6" style="border: 1px solid #e5e5e5;">
                    <div class="row">
                        <div class="col-md-6 col-xs-12 col-lg-6 col-sm-12 ">
                            <div class="form-group">
                                <label for="Username">
                                    Old Password <span class="mandatory">*</span></label>
                                <input type="password" id="txtOldPass" class="form-control fadeIn first" name="OldPass"
                                    placeholder="Old Password" data-bind="value:OldPass,valueUpdate: 'input'" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6 col-xs-12 col-lg-6 col-sm-12 ">
                            <div class="form-group">
                                <label for="Username">
                                    New Password <span class="mandatory">*</span></label>
                                <input type="password" id="NewPassword" class="form-control fadeIn second " name="newpass"
                                    placeholder="New Password" data-bind="value:Password,event:{ change: $data.ValidatePassword }" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6 col-xs-12 col-lg-6 col-sm-12 ">
                            <div class="form-group">
                                <label for="Username">
                                    Confirm New Password <span class="mandatory">*</span></label>
                                <input type="password" id="retypepass" class="form-control fadeIn third " name="newpass"
                                    placeholder="ReType Password" data-bind="value:ReNewPass" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="padding-left-15 margin-top-15 margin-bottom-15 pull-right">
                            <button data-bind="click:CheckAndChangeOldPass" title="Click To Change Password"
                                value="Proceed" class="btn btn-primary btn-md fadeIn fourth" id="btnProceed">
                                Change Password
                            </button>
                        </div>
                    </div>
                </div>
                <div class=" col-md-5 ">
                    <fieldset>
                        <p style="background-color: #bce8f1; font-size: 16px;">
                            <i class="fa fa-caret-square-o-up"></i>Notes For Password Policy:
                        </p>
                        <p>
                            <i class="fa fa-fw fa-star"></i>Lower Case and Upper Case Letters in password.<br />
                        </p>
                        <p>
                            <i class="fa fa-fw fa-star"></i>Password Must Contain Special Character [`@#$%^&`].</p>
                        <p>
                            <i class="fa fa-fw fa-star"></i>Password Minimum Length is 8.</p>
                        <%-- <p>
                        <i class="fa fa-fw fa-star"></i>Password must be changed on every 180 days</p>--%>
                    </fieldset>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function openTab(evt, tabName) {
            var i, tabcontent, tablinks;
            tabcontent = document.getElementsByClassName("tabcontent");
            for (i = 0; i < tabcontent.length; i++) {
                tabcontent[i].style.display = "none";
            }
            tablinks = document.getElementsByClassName("tablinks");
            for (i = 0; i < tablinks.length; i++) {
                tablinks[i].className = tablinks[i].className.replace(" active", "");
            }
            document.getElementById(tabName).style.display = "block";
            evt.currentTarget.className += " active";
        }

        // Get the element with id="defaultOpen" and click on it
        document.getElementById("defaultOpen").click();
    </script>
    <script src="../../Scripts/Container/ChangeOldPassword.js?v=0.1" type="text/javascript"></script>
</asp:Content>
