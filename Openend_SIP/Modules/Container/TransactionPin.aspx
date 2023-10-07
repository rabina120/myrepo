<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="TransactionPin.aspx.cs" Inherits="Openend_SIP.Modules.Container.TransactionPin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Transaction Pin | NIBL ACE Capital </title>
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
        <h3 style="text-align: center;">
            Transaction Pin</h3>
       
        <div class="row">
            <div class="col-md-11">
                <div class="tab">
                    <button class="tablinks active" onclick="openTab(event, 'Profile')" id="defaultOpen">
                        Change Transaction Pin</button>
                    <button class="tablinks" onclick="openTab(event, 'ChangePassword')">
                        New Transaction Pin</button>
                </div>
            </div>
        </div>
        <div id="Profile" class="tabcontent t in active">
            <div class="card-body " id="statusHide">
                <div class="col-md-6" style="border: 1px solid #e5e5e5;">
                    <div class="row">
                        <div class="col-md-7 col-xs-12 col-lg-8 col-sm-12 ">
                            <div class="form-group">
                                <label for="Username">
                                    Current Transaction Pin <span class="mandatory">*</span></label>
                                <input type="password" onkeypress="return isNumberKey(event)" id="Text3" class="form-control fadeIn second "
                                    name="newpass" placeholder="Enter 6 Digit Transaction Pin (Number Only)" data-bind="value:OldPin" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-7 col-xs-12 col-lg-8 col-sm-12 ">
                            <div class="form-group">
                                <label for="Username">
                                    New Transaction Pin <span class="mandatory">*</span></label>
                                <input type="password" onkeypress="return isNumberKey(event)" id="Text1" class="form-control fadeIn second "
                                    name="newpass" placeholder="Enter 6 Digit Transaction Pin (Number Only)" data-bind="value:NewPin" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-7 col-xs-12 col-lg-8 col-sm-12 ">
                            <div class="form-group">
                                <label for="Username">
                                    Confirm New Transaction Pin <span class="mandatory">*</span></label>
                                <input type="password" onkeypress="return isNumberKey(event)" id="Text2" class="form-control fadeIn third "
                                    name="newpass" placeholder="Confirm 6 Digit Transaction Pin (Number Only)" data-bind="value:ReNewPin" />
                            </div>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label for="txtStatus" class="col-sm-12 col-md-5 col-form-label">
                        </label>
                        <div class="col-md-2 padding-left-15 margin-top-15 pull-right">
                            <button class="btn btn-primary" id="btnSave" data-bind="click:UpdatePin">
                                Update</button>
                        </div>
                    </div>
                </div>
            </div>
            <div class=" col-md-5 ">
                <fieldset>
                    <p style="background-color: #bce8f1; font-size: 16px;">
                        <i class="fa fa-caret-square-o-up"></i>Notes For Transaction Policy:
                    </p>
                    <p>
                        <i class="fa fa-fw fa-star"></i>Your Transaction Pin Must Include 6 Digit Numerical
                        Value.<br />
                    </p>
                    <p>
                        <i class="fa fa-fw fa-star"></i>Transaction Pin Will Be Used To Confirm Your
                        Payment Transaction.
                    </p>
                </fieldset>
            </div>
        </div>
        <div id="ChangePassword" class="tabcontent">
            <div class="card-body ">
                <div class="col-md-6" style="border: 1px solid #e5e5e5;">
                    <div class="row">
                        <div class="col-md-7 col-xs-12 col-lg-8 col-sm-12 ">
                            <div class="form-group">
                                <label for="Username">
                                    New Transaction Pin <span class="mandatory">*</span></label>
                                <input type="password" onkeypress="return isNumberKey(event)" id="NewPassword" class="form-control fadeIn second "
                                    name="newpass" placeholder="Enter 6 Digit Transaction Pin (Number Only)" data-bind="value:CNewPin" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-7 col-xs-12 col-lg-8 col-sm-12 ">
                            <div class="form-group">
                                <label for="Username">
                                    Confirm New Transaction Pin <span class="mandatory">*</span></label>
                                <input type="password" onkeypress="return isNumberKey(event)" id="retypepass" class="form-control fadeIn third "
                                    name="newpass" placeholder="Confirm 6 Digit Transaction Pin (Number Only)" data-bind="value:CReNewPin" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="padding-left-15 margin-top-15 margin-bottom-15 pull-right">
                            <button data-bind="click:ForgetPin" title="Click To Change Pin" value="Proceed" class="btn btn-primary btn-md fadeIn fourth"
                                id="btnProceed">
                                Submit
                            </button>
                        </div>
                    </div>
                </div>
                <div class=" col-md-5 ">
                    <fieldset>
                        <p style="background-color: #bce8f1; font-size: 16px;">
                            <i class="fa fa-caret-square-o-up"></i>Notes For Transaction Policy:
                        </p>
                        <p>
                            <i class="fa fa-fw fa-star"></i>Your Transaction Pin Must Include 6 Digit Numerical
                            Value.<br />
                        </p>
                        <p>
                            <i class="fa fa-fw fa-star"></i>Transaction Pin Will Be Used To Confirm Your
                            Payment Transaction.
                        </p>
                    </fieldset>
                </div>
            </div>
            <div id="Verify" style="font-family: -webkit-body;">
                <div class="card">
                    <div class="modal fade" id="VerifySercurity" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
                        aria-hidden="true" style="padding: 20px">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                        <span aria-hidden="true">&times;</span></button>
                                    <h4 class="modal-title" id="H3">
                                        Security Verification</h4>
                                </div>
                                <div class="modal-body">
                                    <div class="form-group row">
                                        <div class="col-sm-4">
                                            <label for="Username" class=" col-form-label">
                                                Email OTP</label>
                                            <label class=" nepalistyle col-form-label">
                                                [ओटिपी]
                                            </label>
                                            <span class="mandatory">*</span>
                                        </div>
                                        <div class="col-sm-8">
                                            <div class="col-sm-12">
                                                <input type="text" class="form-control" data-bind="value:EmailOTP">
                                            </div>
                                        </div>
                                    </div>
                                    <div class=" form-group row">
                                        <div class="col-md-2 padding-left-15 margin-top-15 pull-right">
                                            <button data-bind="click:VerifyPIn" title="Click To Save" value="Save" class="btn btn-primary btn-md "
                                                id="Button1">
                                                Submit
                                            </button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
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
    <script src="../../Scripts/Container/TransactionPin.js?v=0.1" type="text/javascript"></script>
</asp:Content>
