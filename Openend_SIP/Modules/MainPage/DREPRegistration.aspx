<%@ Page Title="" Language="C#" MasterPageFile="~/LoginMaster.Master" AutoEventWireup="true" CodeBehind="DREPRegistration.aspx.cs" Inherits="Openend_SIP.Modules.MainPage.DREPRegistration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <title>Dividend Re-Investment Plan Registration Form | </title>
   <link rel="icon" href="/Styles/Images/apple-icon-57x57.png" type="image/gif" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<style type="text/css">
        label
        {
            font-weight: bold;
            font-size: 15px;
        }
        
        h4
        {
            text-align: center !important;
            color: white !important;
            background-color: #1d4583;
        }
        .nepalistyle
        {
            font-size: 13px;
        }
        .btn
        {
            background-color: #1e4483;
        }
        
        .footer
        {
            position: inherit !important;
        }
    </style>
    <script>
        $(function () {
            $('.link').click(function () {
                $(this).addClass('selected');
            });
        });
    </script>
    <style>
        .disabledbutton
        {
            pointer-events: none;
            opacity: 0.4;
        }
        .link
        {
            border: 1px solid #fff;
        }
        .link:hover, .selected
        {
            -webkit-box-shadow: 0px 1px 13px 0px rgba(69,197,232,0.52);
            -moz-box-shadow: 0px 1px 13px 0px rgba(69,197,232,0.52);
            box-shadow: 0px 1px 13px 0px rgba(69,197,232,0.52);
            border: 1px solid #00adef;
        }
    </style>
    <script>
        function validate(input) {
            if (/^\s/.test(input.value))
                input.value = '';
        }
    </script>
       <form id ="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:HiddenField ID="forgeryToken" runat="server"/>
<div class="container" style="margin-bottom: 25px; margin-top: 156px;">
        <h3 align="center" style="font-weight: bold;">
            Dividend Re-Investment Plan Registration Form
        </h3>
        <h3 align="center" style="font-weight: bold; font-size: 18px;">
            [ लाभांश पुन: लगानी योजना दर्ता फाराम ]
        </h3>
        <br />
        <br />
        <div class="card-body">
            <div class="row">
                <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                    <div class="form-group">
                        <label class="control-label text-top padding-left-0" for="textinput" style="">
                            Scheme Name
                        </label>
                        <label class="nepalistyle">
                            [ योजनाको नाम ]</label><span class="mandatory">*</span>
                        <select id="dllscheme" disabled="disabled" class="form-control " data-bind='options:Schemes, optionsText:"SchemeEnName", value:SelectedScheme, optionsCaption:"--- Select Scheme ---"'>
                        </select>
                    </div>
                </div>
            </div>

            <h4 class="margin-bottom-15 margin-top-0 text-left" style="font-weight: bold; padding-top: 5px">
                APPLICANT DETAILS
                <label class="nepalistyle" style="font-size: medium">
                    [ आवेदक विवरणहरू ]
                </label>
            </h4>
            <div class="row">
                <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                    <div class="form-group">
                        <label for="Username">
                            Depository Participants
                        </label>
                        <label class="nepalistyle">
                            [ निक्षेप सदस्य ]
                        </label>
                        <span class="mandatory">*</span>
                        <select id="dp" class="form-control Existing Submit" data-bind='options:Depo, optionsText:"DPName", value:SelectedDp, optionsCaption:"   --- Select DP --- "'>
                        </select>
                    </div>
                </div>
                <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                    <div class="form-group">
                        <label for="Username">
                            BOID No
                        </label>
                        <label class="nepalistyle">
                            [ हितग्राही खाता नम्बर ]
                        </label>
                        <span class="mandatory">*</span>
                        <input type="text" id="txtBoid_No" onkeypress="return isNumberKey(event)" class="form-control Existing Submit"
                            maxlength="8" data-bind="value:Boid_No , valueUpdate: 'input', executeOnEnter:CheckSHolders, event{blur:CheckSHolders}" />
                    </div>
                </div>
                  <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12" >
                    <div class="form-group">
                        <label for="Username">
                            Name
                        </label>
                        <label class="nepalistyle">
                            [ आवेदकको नाम ]
                        </label>
                        <span class="mandatory">*</span>
                        <input type="text" id="txtfname" class="form-control"  data-bind="value:Name" maxlength="50" />
                    </div>
                </div>
              </div>
              <div  class ="row" id ="UNPOSTED" style="display:none">
                            <p class="text-justify"  style="color :Red;">Your Request for Enrollment for DReP has been sent. Please wait for approval.</p>
                            <p class="text-justify"  style="color :Red;">
                                एनआइबिएल सहभागिता फण्डका लागि नामांकनको लागि तपाईंको अनुरोध पठाइएको छ। अनुमोदनको लागि प्रतीक्षा गर्नुहोस्। </p>
                            </div>
              <div class="row">
               
                
              </div>
              <div class="row ">
                <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                    <div class="form-group">
                        <label for="Username">
                            Email
                        </label>
                        <label class="nepalistyle">
                            [ ईमेल ]
                        </label>
                        <span class="mandatory">*</span>
                        <input type="email"  id='txtemail' data-bind="value:Email,valueUpdate: 'input'" class="form-control Clicklogin Submit"
                             maxlength="50">
                    </div>
                </div>
                <div class="col-md-4 col-xs-7 col-lg-4 col-sm-7 Hidden">
                    <div class="form-group">
                        <label for="Email" style="font-weight: bold;">
                            OTP
                        </label>
                        <label class="nepalistyle">
                            [ ओटिपी ]</label><span class="mandatory">*</span>
                        <input type="text" id='txtotp' data-bind="value:OTPPass,valueUpdate: 'input'" class="form-control Submit"
                            maxlength="6">
                    </div>
                </div>
                <div class="col-md-4 col-xs-4 col-lg-4 col-sm-4 Hidden" style="padding-top: 22px;">
                    <div class="form-group" style="">
                        <button class="btn " style="background-color: #5d2e8e; color: white;" data-bind="click:GenerateOTP"
                            type="submit">
                            GET OTP</button>
                             <button class="btn " id='Verifyotp'  style="background-color: #21ba45; display:none; color: white;" autocomplete="off" data-bind="click:CHECKOTP"
                            type="submit">
                            Verify OTP</button>
                    </div>
                </div>
            </div>
            <div class="row ">
                <div class="col-md-4 col-xs-12 col-lg-4 col-sm-4 ">
                    <div class="form-group">
                        <label for="Username">
                            Contact No
                        </label>
                        <label class="nepalistyle">
                            [ सम्पर्क नम्बर ]
                        </label>
                        <span class="mandatory">*</span>
                        <input type="text" onkeypress="return isNumberKey(event)" id="txttelno" class="form-control Clicklogin Submit"
                            maxlength="10" data-bind="value:P_Tel_No" />
                    </div>
                </div>
               
                <div class="col-md-4 col-xs-12 col-lg-4 col-sm-4 ">
                    <div class="form-group">
                        <label for="Username">
                            Contact No
                        </label>
                        <label class="nepalistyle">
                            [ सम्पर्क नम्बर ]
                        </label>
                        <input type="text" id="Text8" onkeypress="return isNumberKey(event)" class="form-control  Submit"
                            minlength="10" maxlength="10" data-bind="value:P_Mobile_no" />
                    </div>
                </div>
            </div>

            <div class="row" >
                <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12 ">
                    <div class="form-group">
                        <label for="Username">
                            DOB <span class="mandatory">*</span></label>
                        <input type="date" id="Date2" data-bind="value:DOB" class="form-control Submit" />
                    </div>
                </div>
                <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12 ">
                    <div class="form-group">
                        <label for="Username">
                            Citizenship Number <span class="mandatory">*</span></label>
                        <input type="text" id="Text5" data-bind="value:CitizenshipNo" class="form-control Submit" />
                    </div>
                </div>
            </div>
        </div>
        <div class="row" style="margin:1%; margin-left: 0%;">
                         
                            <h5>
                             <u><b>Declaration [ घोषणा ]:</b></u>    </h5>
                            <p class="text-justify">

                               <span><i class="fa fa-fw fa-star"></i> I/We would like to register in the Dividend Re-Investment Plan (DRep) under NIBL Sahabhagita Fund (an Open Ended Scheme) with the following details. Further, I/We hereby agree to re-invest my/our all dividend amount in the scheme
                                as per aforementioned instruction after deducting the applicable tax and DP fees and declare that the instruction remains in force till further information from me in writing.</span>
                                <span class="nepalistyle"> म/हामी निम्न बमोजिमको जानकारी संगै एनआइबिएल सहभागिता फण्ड (खुलामुखी
                                 योजना) अन्तर्गतको लाभांश पुन: लगानी योजनामा दर्ता हुन चाहन्छौं । साथै, म/हामीले उक्त्त योजनाबाट प्राप्त गर्ने लाभांश 
                                 रकममा आवश्यक कर तथा &nbsp;डिपी शूल्क कट्टा गरी (घटाई) प्राप्त गर्ने रकमलाई यसै निवेदन बमोजिम योजनामा पुन: लगानी 
                                 गर्न मञ्जुर गर्दछु/छौँ र यो निवेदन म/हामीले अर्को लिखीत जानकारी नगराए सम्मका लागि लागु रहने उद्घोष गर्दछु/छौँ ।  </span>
                        </p>
      
                </div>
        <div class="row">
                <div class="col-md-4padding-left-15 margin-top-15 pull-right">
                    <button data-bind="click:SaveDividend" title="Click To Proceed" value="Proceed" disabled="disabled"
                        class="btn btn-primary btn-md" id="btnSubmit">
                       Submit
                    </button>
                    <button title="Click To Cancel" data-bind="click:ClearControls" value="Cancel" class="btn btn-primary btn-md "
                        id="btnCancel">
                        Cancel
                    </button> 
                </div>
         </div>
      <div id="lock-modal"></div>
      <div id="loading-circle"></div>
</div>
</form>
 <script>
     function testInputName(event) {
         var value = String.fromCharCode(event.which);
         var pattern = new RegExp(/[a-zåäö ]/i);
         if (!pattern.test(value)) {
             // msg("You Cann't Enter Numeric value!!!", 'ALERT')
         }
         return pattern.test(value);
     }

     $('#txtfname').bind('keypress', testInputName);
    </script>
<script src="../../Scripts/MainPage/DREPRegistartion.js?v=0.1" type="text/javascript"></script>
</asp:Content>
