<%@ Page Title="" Language="C#" MasterPageFile="~/LoginMaster.Master" AutoEventWireup="true"
    CodeBehind="UnitPurchase.aspx.cs" Inherits="Openend_SIP.Modules.MainPage.UnitPurchase" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Unit Purchase | </title>
    <link rel="icon" href="/Styles/Images/apple-icon-57x57.png" type="image/gif" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../JsLibrary/khalti-checkout.iffe.js" type="text/javascript"></script>
    <script type="text/javascript">
       
    </script>
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
    <form method="post" id="NiblResponseData" runat="server">
        <asp:HiddenField ID="resbankid" runat="server"></asp:HiddenField>
        <asp:HiddenField ID="respref" runat="server"></asp:HiddenField>
        <asp:HiddenField ID="resamount" runat="server"></asp:HiddenField>
        <asp:HiddenField ID="resbid" runat="server"></asp:HiddenField>
        <asp:HiddenField ID="rescustreftype" runat="server"></asp:HiddenField>

        <asp:HiddenField ID="Khaltiref" runat="server"></asp:HiddenField>
        <asp:HiddenField ID="ConnectIpsiref" runat="server"></asp:HiddenField>
        <asp:HiddenField ID="EBankingPID" runat="server"></asp:HiddenField>
        <asp:HiddenField ID="EBankingLoginURL" runat="server"></asp:HiddenField>
        <asp:HiddenField ID="Esewascd" runat="server"></asp:HiddenField>
        <asp:HiddenField ID="ESewaRef" runat="server"></asp:HiddenField>

        <asp:HiddenField ID="PayMarchantId" runat="server"></asp:HiddenField>
        <asp:HiddenField ID="PayAppIdUnitPurchase" runat="server"></asp:HiddenField>

        <asp:HiddenField ID="UnitPurchaseURL" runat="server"></asp:HiddenField>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:HiddenField ID="forgeryToken" runat="server"/></asp:HiddenField>
          
   
   
    <div class="container" style="margin-bottom: 25px; margin-top: 156px;">
        <h3 align="center" style="font-weight: bold;">
            UNIT PURCHASE APPLICATION
        </h3>
        <h3 align="center" style="font-weight: bold; font-size: 18px;">
            [ इकाई खरिद दरखास्त फाराम ]
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
            <div class="row" style="display: none">
                <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                    <div class="form-group">
                        <label for="Username">
                            Charge Type
                        </label>
                        <label class="nepalistyle">
                            [ चार्ज प्रकार ]
                        </label>
                        <span class="mandatory">*</span>
                        <select id="dllChargeTypes" disabled="disabled" class="form-control" data-bind='options:ChargeTypes, optionsText:"SDescription", value:SelectedCharge, optionsCaption:"--- Select Charge Type ---"'>
                        </select>
                    </div>
                </div>
                <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                    <div class="form-group">
                        <label for="Username">
                            Face Value Per Unit
                        </label>
                        <label class="nepalistyle">
                            [ इकाईमा प्रति मान ]
                        </label>
                        <span class="mandatory">*</span>
                        <input type="text" id="NAV" disabled="disabled" data-bind="value:face_val" class="form-control" />
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                    <div class="form-group">
                        <label for="Username">
                            Apply Date
                        </label>
                        <label class="nepalistyle">
                            [लागू मिति ]
                        </label>
                        <span class="mandatory">*</span>
                        <input type="date" id="txtapplydt" autocomplete="off" class="form-control Submit" data-bind="value:APPLY_DT, valueUpdate: 'input', executeOnEnter:GetNavValue, event{blur:GetNavValue}" />
                    </div>
                </div>
                <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                    <div class="form-group">
                        <label for="Username">
                            Applicable NAV
                        </label>
                        <label class="nepalistyle">
                            [ प्रति एकाई खुद सम्पती मुल्य ]
                        </label>
                        <span class="mandatory">*</span>
                        <input type="text" id="Date1" disabled="disabled" data-bind="value:current_nav" class="form-control " />
                    </div>
                </div>
                <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12" style="display: none">
                    <div class="form-group">
                        <label for="Username">
                            NAV Date <span class="mandatory">*</span></label>
                        <input type="date" id="txtnavdate" disabled="disabled" data-bind="value:nav_date"
                            class="form-control input-sm" />
                    </div>
                </div>
            </div>
            <h4 class="margin-bottom-15 margin-top-0 text-left" style="font-weight: bold; padding-top: 5px">
                APPLICANT DETAILS
                <label class="nepalistyle" style="font-size: medium">
                    [ आवेदक विवरणहरू ]
                </label>
                <%--[ आवेदक विवरणहरू ]--%>
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
                        <select id="dp"  autocomplete="off"class="form-control Existing Submit" data-bind='options:Depo, optionsText:"DPName", value:SelectedDp, optionsCaption:"   --- Select DP --- "'>
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
                        <input type="text" id="txtSHolder" autocomplete="off" onkeypress="return isNumberKey(event)" class="form-control Existing Submit"
                            maxlength="8" data-bind="value:Boid_No , valueUpdate: 'input', executeOnEnter:CheckSHolders, event{blur:CheckSHolders}" />
                    </div>
                </div>
                <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12 NoneExistingHeader" style="display: none">
                    <div class="form-group">
                        <label for="Username">
                            Name
                        </label>
                        <label class="nepalistyle">
                            [ आवेदकको नाम ]
                        </label>
                        <span class="mandatory">*</span>
                        <input type="text" id="txtfname" autocomplete="off" class="form-control Existing Submit" disabled="disabled"
                            data-bind="value:Name" maxlength="50" />
                        <%--  <input type="text" id="txtfname" onkeypress='return (event.charCode >= 65 && event.charCode <= 122)  || event.charCode == 32'
                              class="form-control Existing Submit" disabled="disabled" data-bind="value:Name" maxlength="50" /> --%>
                    </div>
                </div>
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
                        <input type="email"  id='txtemail' data-bind="value:Email,valueUpdate: 'input'" autocomplete="off" class="form-control Clicklogin Submit"
                            id="Text1" maxlength="50">
                    </div>
                </div>

                <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12  ">
                        <div class="form-group">
                        <label for="Contact">
                            Contact No
                        </label>
                        <label class="nepalistyle">
                            [ सम्पर्क नम्बर ]
                        </label>
                        <span class="mandatory">*</span>
                        <input type="text" onkeypress="return isNumberKey(event)" autocomplete="off" id="txttelno" class="form-control Clicklogin Submit"
                            maxlength="10" data-bind="value:P_Tel_No" />
                    </div>
                </div>
               <div class="col-md-2 col-xs-12 col-lg-2 col-sm-12 Hidden">
                        <div class="form-group">
                        <label for="Email" style="font-weight: bold;">
                            <small>OTP [ ओटिपी ]<span class="mandatory">*</span></small>
                        </label>
                        <input type="text" id='txtotp' data-bind="value:OTPPass,valueUpdate: 'input'" autocomplete="off" class="form-control Submit"
                            maxlength="6">
                       <%-- <input type="text" data-bind="value:OTPPass,valueUpdate: 'input'" autocomplete="off" class="form-control Submit"
                            maxlength="4">--%>
                    </div>
                </div>
                 <div class="col-md-2 col-xs-12 col-lg-2 col-sm-12 Hidden">
                        <div class="form-group" style="">  
                       <label  class="col-md-12 hidden-xs margin-bottom-0"> &nbsp;</label>
                        <button class="btn btn-sm" style="background-color: #5d2e8e; color: white;" autocomplete="off" data-bind="click:GenerateOTP"
                            type="submit">
                            GET OTP</button>
                            <button class="btn btn-sm " id='Verifyotp'  style="background-color: #21ba45;display:none; color: white;" autocomplete="off" data-bind="click:CHECKOTP"
                            type="submit">
                            Verify OTP</button>
                    </div>
                   
                </div>
             
            </div>
            <div class="row ">
                   <%--<div class="col-md-4 col-xs-12 col-lg-4 col-sm-12  ">
                        <div class="form-group">
                        <label for="Contact">
                            Contact No
                        </label>
                        <label class="nepalistyle">
                            [ सम्पर्क नम्बर ]
                        </label>
                        <span class="mandatory">*</span>
                        <input type="text" onkeypress="return isNumberKey(event)" autocomplete="off" id="txttelno" class="form-control Clicklogin Submit"
                            maxlength="10" data-bind="value:P_Tel_No" />
                    </div>
                </div>--%>
               <%--  <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12 Hidden">
                    <div class="form-group">
                        <label for="ContactOTP" style="font-weight: bold;">
                            OTP
                        </label>
                        <label class="nepalistyle">
                            [ ओटिपी ]</label><span class="mandatory">*</span>
                        <input type="text" id='txtContactOTP' data-bind="value:OTPContactPass,valueUpdate: 'input'" autocomplete="off" class="form-control Submit"
                            maxlength="6">
                    </div>
                </div>--%>
             <%--   <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12 Hidden">
                    <div class="form-group" style="">
                    <label  class="col-md-12 hidden-xs"> &nbsp;</label>
                        <button class="btn " style="background-color: #5d2e8e; color: white;" autocomplete="off" data-bind="click:GenerateContactNoOTP"
                            type="submit">
                            GET OTP</button>
                            <button class="btn " id='VerifyContactotp'  style="background-color: #21ba45; display:none; color: white;" autocomplete="off" data-bind="click:CheckContactNoOTP"
                            type="submit">
                            Verify OTP</button>
                    </div>
                   
                </div>--%>

                

                <div class="col-md-4 col-xs-12 col-lg-4 col-sm-4 ">
                    <div class="form-group">
                        <label for="Username">
                            Contact No
                        </label>
                        <label class="nepalistyle">
                            [ सम्पर्क नम्बर ]
                        </label>
                        <input type="text" id="Text8" onkeypress="return isNumberKey(event)" autocomplete="off" class="form-control  Submit"
                            minlength="10" maxlength="10" data-bind="value:P_Mobile_no" />
                    </div>
                </div>


                <div class="row NoneExistingHeader" style="display: none">
                <div class="col-md-3 col-xs-12 col-lg-3 col-sm-12 ">
                    <div class="form-group">
                        <label for="Username">
                            DOB <span class="mandatory">*</span></label>
                        <input type="date" id="Date2" data-bind="value:DOB" class="form-control Submit" autocomplete="off" />
                    </div>
                </div>
                <div class="col-md-3 col-xs-12 col-lg-3 col-sm-12 ">
                    <div class="form-group">
                        <label for="Username">
                            Citizenship Number <span class="mandatory">*</span></label>
                        <input type="text" id="Text5" data-bind="value:CitizenshipNo" class="form-control Submit" autocomplete="off" />
                    </div>
                </div>
            </div>
              </div>
                
            
            <div class="row  NoneExistingHeader " style="display: none">
                <div class="col-md-5 col-xs-12 col-lg-5 col-sm-12">
                    <div class="form-group">
                        <label for="Username">
                            HolderType
                        </label>
                        <label class="nepalistyle">
                            [इकाईधनीको किसिम]
                        </label>
                        <span class="mandatory">*</span>
                        <input type="radio" class="Existing Submit" autocomplete="off" name="HolderType" id="Company" value="True"
                            data-bind="checked:HolderType" />
                        Company
                        <input type="radio" class="Existing Submit" name="HolderType" id="Individual" value="False"
                            data-bind="checked:HolderType" autocomplete="off"/>
                        Individual
                    </div>
                </div>
            </div>
            <h4 class="margin-bottom-15 margin-top-0 text-left NoneExistingHeader" style="font-weight: bold;
                display: none; text-align: center !important; padding-top: 5px">
                BANK DETAILS
                <label class="nepalistyle" style="font-size: medium">
                    [ बैंक विवरण ]
                </label>
                <%--[ बैंक विवरण ]--%></h4>
            <div class="row NoneExistingHeader " style="display: none">
                <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                    <div class="form-group">
                        <label for="Username">
                            Bank Name
                        </label>
                        <label class="nepalistyle">
                            [ बैंकको नाम ]
                        </label>
                        <span class="mandatory">*</span>
                        <select id="ddlBankName" class="form-control Submit Existing" data-bind='options:Banks, optionsText:"bankname", value:SelectedBank, optionsCaption:"--- Select Bank ---"'>
                        </select>
                    </div>
                </div>
                <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                    <div class="form-group">
                        <label for="Username">
                            Account No
                        </label>
                        <label class="nepalistyle">
                            [ खाता नम्बर ]
                        </label>
                        <span class="mandatory">*</span>
                        <input type="text" id="txtaccountno" class="form-control Submit Existing" data-bind="value:Bank_Account_No" />
                    </div>
                </div>
            </div>
            <h4 class="margin-bottom-15 margin-top-0 text-left" style="font-weight: bold; padding-top: 5px">
                APPLICATION DETAILS
                <label class="nepalistyle" style="font-size: medium">
                    [ दर्ता विवरणहरू ]
                </label>
                <a id="myAnchor"></a>
            </h4>
            <div class="row">
                <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                    <div class="form-group">
                        <label for="Username" style="font-weight: bold;">
                            PayeeName</label><label class="nepalistyle">
                                [ भुक्तानीकर्ताको नाम ]</label>
                        <input type="txtpname" data-bind="value:payeename" class="form-control Submit" id="Txtpname1"
                            maxlength="50">
                    </div>
                </div>
                <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                    <div class="form-group">
                        <label for="Username" style="font-weight: bold;">
                            Payee Contact No
                        </label>
                        <label class="nepalistyle">
                            [ भुक्तानीकर्ताको सम्पर्क नम्बर ]
                        </label>
                        <input type="txtpname" onkeypress="return isNumberKey(event)" data-bind="value:PayeeContactNo"
                            class="form-control Submit" id="txtpayeecotacno" maxlength="10">
                    </div>
                </div>
            </div>
            <div class="row" id="calculation">
                <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                    <div class="form-group">
                        <label for="Username">
                            Applied Units
                        </label>
                        <label class="nepalistyle">
                            [ खरिद इकाई ]</label><span class="mandatory">*</span>
                        <input type="text" id="txtapplyunit" class="form-control fixed Submit" onkeypress="return isNumberKey(event)"
                            onkeyup="this.value=this.value.replace(/[^\d]/,'')" data-bind="value:APPLY_UNIT, executeOnEnter:LoadValue, event{blur:LoadValue}" />
                    </div>
                </div>
                <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                    <div class="form-group">
                        <label for="Username">
                            Total With Face Value
                        </label>
                        <label class="nepalistyle">
                            [ कुल रकम]
                        </label>
                        <span class="mandatory">*</span>
                        <input type="text" id="txttfv" class="form-control" disabled="disabled" data-bind="value:tot_with_face_value" />
                    </div>
                </div>
                <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                </div>
            </div>
            <div class="row">
                <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                    <div class="form-group">
                        <label for="Username">
                            DP Fee
                        </label>
                        <label class="nepalistyle">
                            [ डिपी शुल्क ]</label><span class="mandatory">*</span>
                        <input type="text" id="Text4" disabled="disabled" onkeypress="return isNumberKey(event)"
                            data-bind="value:other_charges, executeOnEnter:LoadTotalAmount, event{blur:LoadTotalAmount}"
                            class="form-control " />
                    </div>
                </div>
                <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                    <div class="form-group">
                        <label for="Username">
                            SEBON Fee
                        </label>
                        <label class="nepalistyle">
                            [ सेबोन शुल्क]
                        </label>
                        <span class="mandatory">*</span>
                        <input type="text" id="Text6" disabled="disabled" onkeypress="return isNumberKey(event)"
                            data-bind="value:SEBON_Fee" class="form-control " />
                    </div>
                </div>
                <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                    <div class="form-group">
                        <label for="Username">
                            Entry Load
                        </label>
                        <label class="nepalistyle">
                            [ बिक्री शुल्क]
                        </label>
                        <span class="mandatory">*</span>
                        <input type="text" id="txtchargeamount" disabled="disabled" data-bind="value:charge_amount"
                            class="form-control" />
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                    <div class="form-group">
                        <label for="Username">
                            Total With Nav Value</label><label class="nepalistyle">
                                [ कुल खुद सम्पती रकम]
                            </label>
                        <span class="mandatory">*</span>
                        <input type="text" id="txttwnv" class="form-control" disabled="disabled" data-bind="value:tot_with_Nav_value" />
                    </div>
                </div>
                <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                    <div class="form-group">
                        <label for="Username">
                            Total Required Amount
                        </label>
                        <label class="nepalistyle">
                            [ कुल आवश्यक रकम ]</label><span class="mandatory">*</span>
                        <input type="text" id="txtrequiredamt" class="form-control" disabled="disabled" data-bind="value:tot_reqd_amt" />
                    </div>
                </div>
                <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                    <div class="form-group">
                        <label for="Username">
                            Deposit Amount
                        </label>
                        <label class="nepalistyle">
                            [ भुक्तानी रकम ]</label><span class="mandatory">*</span>
                        <input type="text" id="Text12" class="form-control" disabled="disabled" data-bind="value:AMOUNT"
                            onkeypress="return isNumberKey(event)" />
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12 col-xs-12 col-lg-12 col-sm-12">
                    <div class="form-group">
                        <h5>
                            <u><b>Declaration [ घोषणा ]:</b></u>
                        </h5>
                        <p style="text-align: justify;">
                            <span><i class="fa fa-fw fa-star"></i>I/we hereby declare that I/we am/are applying
                                with the above mentioned details to purchase the units of the scheme only after
                                carefully reading the prospectus/scheme related documents published by the Fund
                                Manager and completely understanding the risk associated with it.</span> <span class="nepalistyle">
                                    म / हामी घोषणा गर्दैछु/गर्दछौं कि योजना व्यवस्थापकले जारी गरेको योजनासंग सम्बन्धित
                                    विवरण पुस्तिका लगायत कागजातहरुको ध्यानपूर्वक अध्ययन गरी यससंग सम्बन्धित जोखीम समेत
                                    राम्ररी बुझेको छु/छौं र योजनाको माथि उल्लेखित एकाईहरु खरिद गर्न आवेदन दिएको छु/छौं
                                    ।</span>
                        </p>
                        <p style="text-align: justify;">
                            <span><i class="fa fa-fw fa-star"></i>I/we hereby declare that the information provided
                                in my/our beneficial owner account completely resembles with my/our personal information
                                and agree that the information in aforementioned BOID in this application form can
                                be used for KYC purpose. </span><span class="nepalistyle">यस आवेदनमा उल्लेख गरिएको हितग्राही
                                    खातामा रहेको मेरो व्यक्तिगत विवरणहरु फरक नपर्नेगरी दिएको हुनाले सो विवरण नै यस आवेदनको
                                    ग्राहक परिचय प्रयोजनका लागि प्रयोग गर्नुभएमा समेत मेरो पूर्ण मञजुरी रहेकोछ ।
                            </span>
                        </p>
                        <p style="text-align: justify;">
                            <span><i class="fa fa-fw fa-star"></i><b>Source of Fund (for NPR 1 Million and above)</b>
                            </span><span class="nepalistyle"><b>आयको श्रोत (रु. १० लाख र सो भन्दा बढीको लागी):</b></span><br />
                            <span>I/we hereby declare that the deposited amount to purchase the units is received
                                from following legitimate source of fund and is not intended for money laundering
                                and/or terrorist financing. </span><span class="nepalistyle">म/हामी घोषणा गर्दैछु/गर्दछौं
                                    कि इकाईहरू खरीद गर्न भुक्तान गरिएको रकम तल उल्लेखित बैधानिक स्रोतद्वारा प्राप्त
                                    गरिएको र यो सम्पत्ति शुद्धिकरण वा आतंकवादी कार्यमा लगानीको आशयले गरिएको होइन् ।</span>
                            <p style="text-align: justify;">
                            </p>
                        </p>
                        <br />
                        <label>
                            <input type="radio" name="optionsRadios" id="optionsRadios1" value="Salary" data-bind="checked:amtDetail"
                                checked>
                            Salary
                        </label>
                        <label class="nepalistyle">
                            [तलब]</label>
                        <label style="padding-left: 3%">
                            <input type="radio" name="optionsRadios" id="optionsRadios2" value="Business" data-bind="checked:amtDetail">
                            Business
                        </label>
                        <label class="nepalistyle">
                            [व्यपारिक कारोवार]</label>
                        <label style="padding-left: 3%">
                            <input type="radio" name="optionsRadios" id="Radio1" value="Assets" data-bind="checked:amtDetail">
                            Sales of Assets
                        </label>
                        <label class="nepalistyle">
                            [सम्पत्तिको बिक्री]</label>
                        <label style="padding-left: 3%">
                            <input type="radio" name="optionsRadios" id="Radio2" value="Loan" data-bind="checked:amtDetail">
                            Loan
                        </label>
                        <label class="nepalistyle">
                            [कर्जा]</label>
                        <label style="padding-left: 3%">
                            <input type="radio" name="optionsRadios" id="Radio3" value="Others" data-bind="checked:amtDetail">
                            Others
                        </label>
                        <label class="nepalistyle">
                            [अन्य]</label>
                        <label style="padding-left: 3%">
                            <input type="text" id="other" class="form-control" style="display: none" data-bind="value:othersource , valueUpdate: 'input'" /></label>
                        <span id="other1" style="display: none" class="mandatory">*</span>
                    </div>
                </div>
            </div>
            <p style="text-align: justify; color: red;">
                <span>(Please upload related documents like; Owner’s Citizenship, Relationship proof
                    documents, your Citizenship etc. if you are applying on behalf of others)</span>
                <span class="nepalistyle">यदि तपाई अन्य कसैको नाममा आवेदन दिदै हुनुहुन्छ भने कृपया आवेदकको
                    नागरिकता, नाता खुल्ने कागजात वा आफ्नो नागरिकता मध्ये कुनै एक तल Upload गरी जानकारी
                    गराउनु होला ।</span>
            </p>
            <div class="row">
                <div class="col-md-4">
                    <div class="form-group">
                        <label for="textinput" style="font-weight: bold;">
                            Proof of Evidence
                        </label>
                        <input id="ImgFile1" type="file" class="form-control  Submit" />
                        <input id="ProofFileName" type="text" class="btn-link" style="display: none" data-bind="value:ProofFileName , click:ViewFile" />
                    </div>
                </div>
              <%--  <div class="col-md-6">
                    <div class="form-group ProofsFileName2">
                        <label for="textinput" style="font-weight: bold;">
                           Citizenship and Relationship Proof (if any)
                        </label> <span class="mandatory">*</span>
                        <input id="ImgFile2" type="file" class="form-control  Submit" />
                        <input id="ProofFileName2" type="text" class="btn-link" style="display: none; margin-top: -26px; margin-left: 310px;" data-bind="value:ProofFileName2 , click:ViewFile2" readonly />
                    </div>
                </div>--%>
            </div>
              <%--<div class="row">
               <div class="col-md-6">
                    <div class="form-group ProofsFileName3" >
                        <label for="textinput" style="font-weight: bold;">
                           BO Confirmation
                        </label> <span class="mandatory">*</span>
                        <input id="ImgFile3" type="file" class="form-control  Submit" />
                        <input id="ProofFileName3"  type="text" class="btn-link" style="display: none" data-bind="value:ProofFileName3 , click:ViewFile3" readonly />
                    </div>
                </div>
              </div>--%>
            <p style="text-align: justify; color: red;">
                <span>( Document size must be less than 1 mb and jpeg, png and jpg format is only acceptable)</span>
            </p>
            <div class="row" id="loginView" style="display: none">
                <div class="col-md-8 col-xs-12 col-lg-8 col-sm-12">
                    <div class="form-group">
                        <label for="Username">
                            Do you want to create Login Account?
                        </label>
                        <label class="nepalistyle">
                            [के तपाइँ आफ्नो लगइन लिन चाहानुहुन्छ?]</label><span class="mandatory">*</span>
                        <input type="checkbox" id="chklogin" value="1" data-bind='checked:IsOnline, event{change:OpenModal}' />
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12" id="Username" style="display: none">
                    <div class="form-group">
                        <label for="Username">
                            UserName <span class="mandatory">*</span></label>
                        <input type="text" id="txtUserName" data-bind="value:UserName,valueUpdate: 'input', executeOnEnter:validateUserName, event{blur:validateUserName}"
                            class="form-control" oninput="validate(this)" />
                    </div>
                </div>
            </div>
            <div class="row" id="HasDividend" style="display: none">
                <div class="col-md-12 col-xs-12 col-lg-12 col-sm-12">
                    <div class="form-group">
                        <label for="Username">
                            <strong style='font-weight: bold;'>Do You Want To Enroll In Dividend Re-Investment Plan?
                            </strong><span class="mandatory"></span>
                        </label>
                        <input type="checkbox" class="Submit" value='0' data-bind="checked:HasDividend">
                    </div>
                </div>
                <div style="padding-left: 16px;">
                    <h5>
                        <u><b>Declaration [ घोषणा ]:</b></u>
                    </h5>
                    <p class="text-justify">
                        <span><i class="fa fa-fw fa-star"></i>I/We would like to register in the Dividend Re-Investment
                            Plan (DRep) under NIBL Sahabhagita Fund (an Open Ended Scheme) with the following
                            details. Further, I/We hereby agree to re-invest my/our all dividend amount in the
                            scheme as per aforementioned instruction after deducting the applicable tax and
                            DP fees and declare that the instruction remains in force till further information
                            from me in writing.</span> <span class="nepalistyle">म/हामी निम्न बमोजिमको जानकारी संगै
                                एनआइबिएल सहभागिता फण्ड (खुलामुखी योजना) अन्तर्गतको लाभांश पुन: लगानी योजनामा दर्ता
                                हुन चाहन्छौं । साथै, म/हामीले उक्त्त योजनाबाट प्राप्त गर्ने लाभांश रकममा आवश्यक
                                कर तथा &nbsp;डिपी शूल्क कट्टा गरी (घटाई) प्राप्त गर्ने रकमलाई यसै निवेदन बमोजिम
                                योजनामा पुन: लगानी गर्न मञ्जुर गर्दछु/छौँ र यो निवेदन म/हामीले अर्को लिखीत जानकारी
                                नगराए सम्मका लागि लागु रहने उद्घोष गर्दछु/छौँ । </span>
                    </p>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4padding-left-15 margin-top-15 pull-right">
                    <button data-bind="click:DispalyPaymentOptions" title="Click To Proceed" value="Proceed"
                        class="btn btn-primary btn-md" id="btnProceed">
                        Proceed For Payment
                    </button>
                    <button title="Click To Cancel" data-bind="click:ClearControls" value="Cancel" class="btn btn-primary btn-md "
                        id="btnCancel">
                        Cancel
                    </button>
                    <button title="Click To Cancel" data-bind="click:SavePurchaseEntry" value="Cancel"
                        disabled="disabled" class="btn btn-primary btn-md " id="BtnSave">
                        Submit
                    </button>
                </div>
            </div>
            <br />
        </div>
    </div>
    <div class="modal fade" id="ViewSign">
        <div class="modal-dialog" style="width: 1200px">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span></button>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-6 col-sm-12 col-xs-12 col_lg-6">
                            <fieldset>
                                <div class="img imageContainer" style="width: 1100px; height: 1100px">
                                    <img alt="" id="upImage" data-bind="attr: {src: Sh_File()}" disabled="disabled" class="img-responsive"
                                        data-content="Preview Uploaded File!!!" />
                                </div>
                            </fieldset>
                        </div>
                    </div>
                    <div class="modal-footer nbdr-top">
                        <div id="Div4" style="margin: auto; display: none;">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="modalShHolder" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
        aria-hidden="true">
        <div class="modal-dialog" style="width: 1100px">
            <div class="modal-content col-md-12 col-xs-7">
                <div class="modal-header">
                    <%--  <button type="button" class="close" data-dismiss="modal" aria-label="Close">--%>
                    <span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title" id="H1">
                        Sign Verification</h4>
                </div>
                <div class="modal-body">
                    <div class="col-md-6" style="border: 1px solid #e5e5e5;">
                        <div class="row" style="padding-top: 10px;">
                        </div>
                        <div class="row">
                            <div class="col-md-6 col-xs-12 col-lg-6 col-sm-12 ">
                                <div class="form-group">
                                    <label for="Username">
                                        Name <span class="mandatory">*</span></label>
                                    <input type="text" id="txtName" data-bind="value:ClientName" class="form-control" />
                                </div>
                            </div>
                            <div class="col-md-6 col-xs-12 col-lg-6 col-sm-12">
                                <div class="form-group">
                                    <label for="Username">
                                        Email <span class="mandatory">*</span></label>
                                    <input type="text" id="Text3" data-bind="value:Email_ID,valueUpdate: 'input', executeOnEnter:WebCheckEmail, event{blur:WebCheckEmail}"
                                        class="form-control" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6 col-xs-12 col-lg-6 col-sm-12 ">
                                <div class="form-group">
                                    <label for="Email" style="font-weight: bold;">
                                        OTP
                                    </label>
                                    <label class="nepalistyle">
                                        [ ओटिपी ]</label><span class="mandatory">*</span>
                                    <input type="text" data-bind="value:OTPPassSign,valueUpdate: 'input'" class="form-control"
                                        maxlength="4">
                                </div>
                            </div>
                            <div class="col-md-6 col-xs-12 col-lg-6 col-sm-12 ">
                                <div class="form-group" style="margin-top: 6%;">
                                    <button class="btn " style="background-color: #5d2e8e; color: white;" data-bind="click:GenerateOTPSign"
                                        type="submit">
                                        GET OTP</button>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6 col-xs-12 col-lg-6 col-sm-12">
                                <div class="form-group">
                                    <label for="Username">
                                        UserName <span class="mandatory">*</span></label>
                                    <input type="text" id="Text2" data-bind="value:UserName,valueUpdate: 'input', executeOnEnter:validateUserName, event{blur:validateUserName}"
                                        class="form-control" oninput="validate(this)" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6 col-xs-12 col-lg-6 col-sm-12 ">
                                <div class="form-group">
                                    <label for="Username">
                                        Contact No <span class="mandatory">*</span></label>
                                    <input type="text" id="Text7" onkeypress="return isNumberKey(event)" maxlength="10"
                                        data-bind="value:Contact_No1" class="form-control" />
                                </div>
                            </div>
                            <div class="col-md-6 col-xs-12 col-lg-6 col-sm-12 ">
                                <div class="form-group">
                                    <label for="Username">
                                        Contact No 2</label>
                                    <input type="text" id="txtContact_No" onkeypress="return isNumberKey(event)" maxlength="10"
                                        data-bind="value:Contact_No2" class="form-control" />
                                </div>
                            </div>
                        </div>
                        <p style="text-align: justify; color: red;">
                            <span>* If the information has not updated yet in your Demat account or to Fund Manager
                                then you can simply download the Login Registration Form from below link and fill
                                up the form properly with valid signature of your Demat Account and upload the form
                                along with your citizenship here for your Login Registration. </span><span class="nepalistyle">
                                    [ यदि तँपाईको व्यक्तिगत विवरण आफ्नो हितग्राहि खातामा वा योजना व्यवस्थापकसँग अद्यावधीक
                                    रहेको छैन् भने कृपया निम्म लिंकमार्फत Login Registration Form डाउनलोड गरी आफ्नो
                                    हितग्राहि खातामा रहेको हस्ताक्षर गरी आफ्नो नागरिकताको साथमा Upoad गरी Login विवरण
                                    प्राप्त गर्न सक्नुहुनेछ ।]</span><br />
                            <button type="button" class="btn-link" data-bind="click:openpdfe">
                                Click Here to Download the Form</button>
                        </p>
                        <div class="row">
                            <div class="col-md-6 col-xs-12 col-lg-6 col-sm-12">
                                <div class="form-group">
                                    <label for="Username">
                                        Upload File
                                    </label>
                                    <input type="file" id="txtUploadFile" data-bind="value:UploadFile" class="form-control" />
                                </div>
                            </div>
                            <div class="col-md-6 col-xs-12 col-lg-6 col-sm-12">
                                <div class="form-group">
                                    <label for="Username">
                                        Citizenship
                                    </label>
                                    <input type="file" id="txtSign" data-bind="value:Signature1" class="form-control" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="padding-left-15 margin-top-15 margin-bottom-15 pull-right">
                                <button data-bind="click:SaveSignUp" title="Click To Proceed" value="Proceed" class="btn btn-primary btn-md"
                                    id="Button1">
                                    Save
                                </button>
                                <button title="Click To Cancel" data-bind="click:ClearSignUp" value="Cancel" class="btn btn-primary btn-md "
                                    id="Button2">
                                    Clear
                                </button>
                                <button title="Click To Cancel" data-dismiss="modal" data-bind="click:Close" value="Cancel"
                                    class="btn btn-primary btn-md " id="Button3">
                                    Close
                                </button>
                            </div>
                        </div>
                    </div>
                    <div class=" col-md-6">
                        <fieldset>
                            <p style="background-color: #bce8f1; font-size: 16px;">
                                <i class="fa fa-caret-square-o-up"></i>Notes For Login Registration :</strong>
                            </p>
                            <p>
                                <i class="fa fa-fw fa-star"></i>Please fill up the form properly as per the record
                                maintained in your Demat Account or information provided to Fund Manager.<span class="nepalistyle">[कृपया
                                    हितग्राहि खातामा वा योजना व्यवस्थापकमा रहेको आफ्नो विवरण भरी बुझाउनु होला ।]</span></p>
                            <p>
                                <i class="fa fa-fw fa-star"></i>If the information provided in this form shall not
                                be verified with the records in Demat Account or Fund Manger’s record then the application
                                shall be rejected. <span class="nepalistyle">[यदि यस फारममा मार्फत बुझाइएको विवरण हितग्राहि
                                    खातामा वा योजना व्यवस्थापकमा रहेका विवरणसँग रुजु नभएमा यस आवेदन स्वतः खारेज हुनेछ
                                    ।]</span></p>
                            <p>
                                <i class="fa fa-fw fa-star"></i>The Login details shall be sent to the e-mail address
                                provided in this form after verification of the information within 3 working days
                                and if it takes some more days then please contact to Fund Manager.<br />
                                <span class="nepalistyle">[Login विवरण यस आवेदनमा उल्लेख भएको ईमेलमा ३ कार्य दिन भित्रमा
                                    प्रदान गरीनेछ र यदि सो दिन भित्रमा ईमेल प्राप्त नभएमा कृपया योजना व्यवस्थापकलाई
                                    सम्पर्क गर्नुहोला ।]</span></p>
                            <p>
                                <i class="fa fa-fw fa-star"></i>The unit-holders will be fully liable of all transaction
                                made with the Login Details. <span class="nepalistyle">[यस Login मार्फत गरीएको सम्पूर्ण
                                    कारोबारहरुको जिम्बेवार स्वंम इकाईधनी नै रहनेछन् ।]</span></p>
                            <p>
                                <i class="fa fa-fw fa-star"></i>The Fund Manager shall have all rights to cancel/block/reject
                                the Login Registration without inform to Unit-holders.<span class="nepalistyle">[इकाईधनीलाई
                                    सूचित गरी वा नगरी यस Login Registration रद्द/रोक्का वा फिर्ता गर्न सक्ने सम्पूर्ण
                                    अधिकार योजना व्यवस्थापक सँग रहेको हुन्छ ।]</span></p>
                            <p>
                                <i class="fa fa-fw fa-star"></i>Please keep your Login details confedential and
                                if you lost, change it or inform to Fund Manager immediately.<span class="nepalistyle">[इकाईधनीले
                                    आफ्नो Login विवरण सुरक्षित तथा गोप्य रुपमा राख्नुपर्नेछ र सो विवरण हराएमा वा बिर्सिएमा
                                    तुरुन्त परिवर्तन गर्नुपर्नेछ वा योजना व्यवस्थापकलाई जानकारी गराउनु पर्नेछ ।]</span></p>
                        </fieldset>
                    </div>
                </div>
            </div>
        </div>
        <div class="modal-footer
    nbdr-top">
            <div id="Div2" style="margin: auto; display: none;">
            </div>
        </div>
    </div>
    <div class="modal fade in" id="PaymentType" tabindex="-1" style="top: 15%;" role="dialog"
        aria-labelledby="myModalLabel" aria-hidden="false" style="display: block;">
        <div class="modal-dialog" style="height: 126px; width: 645px; padding: 0px;">
            <div class="modal-content ">
                <div class="" style="background-color: #1d4583;">
                    <span aria-hidden="true"></span>
                    <h4 class="modal-title" id="H3" style="padding-top: 15px;">
                        PROCEED PAYMENT BY</h4>
                </div>
                <div class="modal-body" style="min-height: 168px;">
                    <img src="/Styles/Images/working.gif" id="loader1" alt="working" style="display: none;
                        position: absolute; top: 75%; left: 47%; transform: translate(-50%, -50%); -ms-transform: translate(-50%, -50%);
                        text-align: center;">
                    <table>
                        <tbody>
                            <tr>
                                <td data-bind="foreach: $root.PaymentTypeLists">
                                    <span data-bind="if: PaymentCode() == '07'">
                                        <img class="link" style="height: 77px; margin: 10px;" data-bind="attr: { src: PaymentFileName }, click: function (data, event) { $root.SaveData('07') }">
                                    </span>
                                </td>
                                <td data-bind="foreach: $root.PaymentTypeLists">
                                    <span data-bind="if: PaymentCode() == '09'">
                                        <img class="link" id="payment-button" data-bind="attr: { src: PaymentFileName }"
                                            style="height: 77px; margin: 10px;" />
                                    </span>
                                </td>
                                <td data-bind="foreach: $root.PaymentTypeLists">
                                    <span data-bind="if: PaymentCode() == '10'">
                                        <img class="link" style="height: 77px; margin: 10px;" data-bind="attr: { src: PaymentFileName }, click: function (data, event) { $root.SaveData('10') }" />
                                    </span>
                                </td>
                                 <td data-bind="foreach: $root.PaymentTypeLists">
                                    <span data-bind="if: PaymentCode() == '12'">
                                        <img class="link" style="height: 77px; margin: 10px;" data-bind="attr: { src: PaymentFileName }, click: function (data, event) { $root.SaveData('12') }" />
                                    </span>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <div class="row">
                        <div class=" pull-right">
                            <button title="Click To Cancel" data-dismiss="modal" value="Cancel" class="btn btn-primary btn-md "
                                id="Button6">
                                Close
                            </button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
    <script src="../../Scripts/MainPage/UnitPurchase.js?v=0.1" type="text/javascript"></script>
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
</asp:Content>
