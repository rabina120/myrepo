<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="SIP_Registration.aspx.cs" Inherits="Openend_SIP.Modules.SIPHandling.SIP_Registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>SIP Registration |  </title>
    <link rel="icon" href="/Styles/Images/apple-icon-57x57.png" type="image/gif" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <script src="../../JsLibrary/khalti-checkout.iffe.js" type="text/javascript"></script>
      <style type="text/css">
        .mandatory
        {
            color: red;
        }
        .nepalistyle
        {
            font-size: 13px;
        }
    </style>
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
        <asp:HiddenField ID="PayAppIdLoginSIPRegistration" runat="server"></asp:HiddenField>

        <asp:HiddenField ID="LoginSIPRegistrationURL" runat="server"></asp:HiddenField>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:HiddenField ID="forgeryToken" runat="server"/>
    
    <div id="Container" style="font-family: -webkit-body;">
        <div class="card">
            <div class="card-header">
                <h3 align="center" style="font-weight: bold;">
                    SIP REGISTRATION DETAIL
                </h3>
                <h3 align="center" style="font-weight: bold; font-size: 18px;">
                    [ व्यवस्थित लगानी योजना दर्ता ]
                </h3>
            </div>
            <br />
            <br />
            <div class="card-body" style="padding-left: 10px;">
                <div class="row" id="Existing">
                    <div class="col-md-6 col-xs-12 col-lg-6 col-sm-12">
                        <div class="table-responsive">
                            <table class="table">
                                <tr>
                                    <th>
                                        BOID
                                        <label class="nepalistyle">
                                            [ हितग्राही खाता ]</label>
                                    </th>
                                    <td data-bind="text:Bo_Account_No">
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        SIP Installment Amount<label class="nepalistyle">
                                            [ किस्ता रकम ]</label>
                                    </th>
                                    <td data-bind="text:PSIP_Amt">
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        SIP Start Date<label class="nepalistyle">
                                        </label>
                                        [ सुरुवात मिति ]
                                    </th>
                                    <td data-bind="text:PSIP_Reg_Date">
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        Terms<label class="nepalistyle">
                                            [ अवधि तोकिएको ]</label>
                                    </th>
                                    <td data-bind="text:PTerms">
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        Model Of SIP<label class="nepalistyle">
                                            [ योजनाको किसिम ]</label>
                                    </th>
                                    <td data-bind="text:PModel_of_Sip">
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <div class="col-md-6 col-xs-12 col-lg-6 col-sm-12">
                        <div class="table-responsive">
                            <table class="table">
                                <tr>
                                    <th>
                                        Name
                                        <label class="nepalistyle">
                                            [ आवेदकको नाम ]</label>
                                    </th>
                                    <td data-bind="text:PName">
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        SIP Interval
                                        <label class="nepalistyle">
                                            [ अन्तराल ]</label>
                                    </th>
                                    <td data-bind="text:PSIP_Interval">
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        SIP Active Date
                                        <label class="nepalistyle">
                                            [ प्रभावकारी मिति ]</label>
                                    </th>
                                    <td data-bind="text:PEffective_Dt">
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        SIP Last_Date<label class="nepalistyle">
                                            [ अन्तिम मिति ]</label>
                                    </th>
                                    <td data-bind="text:PLast_Date">
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
                <div id="New">
                    <div class="row">
                        <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                            <div class="form-group">
                                <label class="control-label text-top padding-left-0" for="textinput" style="font-weight: bold;">
                                    Scheme Name
                                </label>
                                <label class="nepalistyle">
                                    [ योजनाको नाम ]</label><span class="mandatory">*</span>
                                <select id="dllscheme" disabled="disabled" class="form-control" autocomplete="off"
                                    data-bind='options:Schemes, optionsText:"SchemeEnName", value:SelectedScheme, optionsCaption:"--- Select Scheme ---"'>
                                </select>
                            </div>
                        </div>
                    </div>
                    <h4 class="margin-bottom-15 margin-top-0 text-left" style="font-weight: bold;">
                        APPLICANT DETAILS [ आवेदक विवरणहरू ]
                    </h4>
                    <hr />
                    <div class="row">
                        <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                            <div class="form-group">
                                <label for="Username" style="font-weight: bold;">
                                    Depository Participants</label>
                                <label class="nepalistyle">
                                    [ निक्षेप सदस्य ]</label><span class="mandatory">*</span>
                                <select id="dp" class="form-control  Existing" data-bind='options:Depo, optionsText:"DPName", value:SelectedDp, optionsCaption:"   --- Select DP --- "'>
                                </select>
                            </div>
                        </div>
                        <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                            <div class="form-group">
                                <label class="control-label text-top padding-left-0" for="textinput" style="font-weight: bold;">
                                    BOID No.
                                </label>
                                <label class="nepalistyle">
                                    [ हितग्राही खाता नम्बर ]</label><span class="mandatory">*</span>
                                <input type="text" id="txtBOID" onkeypress="return isNumberKey(event)" class="form-control  Existing"
                                    maxlength="8" data-bind="value:BOID , valueUpdate: 'input'">
                            </div>
                        </div>
                        <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                            <div class="form-group">
                                <label for="Username" style="font-weight: bold;">
                                    Name
                                </label>
                                <label class="nepalistyle">
                                    [ आवेदकको नाम ]</label><span class="mandatory">*</span>
                                <input type="text" data-bind="value:Name" disabled="disabled" class="form-control Existing "
                                    id="txtUsername" maxlength="50">
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                            <div class="form-group">
                                <label for="Email" style="font-weight: bold;">
                                    Contact No
                                </label>
                                <label class="nepalistyle">
                                    [ सम्पर्क नम्बर]</label><span class="mandatory">*</span>
                                <input type="text" onkeypress="return isNumberKey(event)" data-bind="value:Contact1"
                                    disabled="disabled" maxlength="10" class="form-control Existing" id="txtCnt1"
                                    maxlength="10">
                            </div>
                        </div>
                        <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                            <div class="form-group">
                                <label for="Email" style="font-weight: bold;">
                                    Contact No
                                </label>
                                <label class="nepalistyle">
                                    [ सम्पर्क नम्बर ]</label><span class="mandatory">*</span>
                                <input type="text" onkeypress="return isNumberKey(event)" data-bind="value:Contact2"
                                    disabled="disabled" maxlength="10" class="form-control Existing" id="txtCnt2"
                                    maxlength="10">
                            </div>
                        </div>
                    </div>
                    <h4 class="margin-bottom-15 margin-top-0 text-left" style="font-weight: bold;">
                        APPLICATION DETAILS [ दर्ता विवरणहरू ]
                    </h4>
                    <hr />
                    <div class="row">
                        <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                            <div class="form-group">
                                <label for="Username" style="font-weight: bold;">
                                    PayeeName</label><label class="nepalistyle">
                                        [ भुक्तानीकर्ताको ]</label><span class="mandatory">*</span>
                                <input type="txtpname" data-bind="value:payeename" class="form-control Submit" id="Text6"
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
                                <span class="mandatory">*</span>
                                <input type="txtpname" onkeypress="return isNumberKey(event)" data-bind="value:PayeeContactNo"
                                    class="form-control Submit" id="txtpayeecotacno" maxlength="10">
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                            <div class="form-group">
                                <label for="Username" style="font-weight: bold;">
                                    SIP Installment Amount
                                </label>
                                <label class="nepalistyle">
                                    [ किस्ता रकम ]</label><span class="mandatory">*</span>
                                <input type="text" onkeyup="this.value=this.value.replace(/[^\d]/,'')" onkeypress="return isNumberKey(event)"
                                    data-bind="value:Sip_amt,executeOnEnter:amountCheck, event{blur:amountCheck}"
                                    class="form-control Submit" id="Password3" maxlength="50">
                            </div>
                        </div>
                        <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                            <div class="form-group">
                                <label for="Username" style="font-weight: bold;">
                                    SIP Registration Date</label><label class="nepalistyle">
                                        [ दर्ता मिति ]</label><span class="mandatory">*</span>
                                <input type="date" disabled="disabled" id="txtsipdt" class="form-control " data-bind="value:SIP_DT, valueUpdate: 'input'" />
                            </div>
                        </div>
                        <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                            <div class="form-group">
                                <label id="Label1" style="font-weight: bold;">
                                    SIP Start Date
                                </label>
                                <label class="nepalistyle">
                                    [ सुरुवात मिति ]</label><span class="mandatory">*</span>
                                <input type="date" disabled="disabled" id="txteffdate" class="form-control" data-bind="value:Effective_Dt, valueUpdate: 'input'" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                            <div class="form-group">
                                <label for="Username" style="font-weight: bold;">
                                    Payment Mode
                                </label>
                                <label class="nepalistyle">
                                    [ भुक्तानीको किसिम ]</label><span class="mandatory">*</span>
                                <select id="dllPaymentlists" class="form-control Submit" data-bind='options:PaymentLists, optionsText:"PaymentMode", value:SelPayments, optionsCaption:"--Select-- "'>
                                </select>
                            </div>
                        </div>
                        <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                            <div class="form-group">
                                <label for="Username" style="font-weight: bold;">
                                    Model Of SIP
                                </label>
                                <label class="nepalistyle">
                                    [ योजनाको किसिम ]</label><span class="mandatory">*</span>
                                <select id="sipmodel" class="form-control Submit" data-bind='options:SipModels,value:SelectedModel, optionsText:"ModelName", optionsCaption:"--- Select Model Of SIP ---", event{change:Getdate}'>
                                </select>
                            </div>
                        </div>
                        <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                            <div class="form-group">
                                <label for="Username" style="font-weight: bold;">
                                    SIP Interval</label><label class="nepalistyle">
                                        [ अन्तराल ]</label><span class="mandatory">*</span>
                                <select id="sipint" class="form-control Submit" data-bind='options:Intervals, optionsText:"SIP_Interval", value:SelectedInterval, optionsCaption:"--Select SIP Interval-- ", event{change:ClearInterval}'>
                                </select>
                            </div>
                        </div>
                    </div>
                    <div class="row" id="Limited" style="display: none">
                        <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                            <div class="form-group">
                                <label for="Username" id="terms" style="font-weight: bold;">
                                    Terms
                                </label>
                                <label class="nepalistyle">
                                    [ अवधि तोकिएको ]</label><span class="mandatory">*</span>
                                <input type="text" id="txtnum" class="form-control Submit" data-bind="value:termno, event{blur:LoadLastDate}" />
                            </div>
                        </div>
                        <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12 Submit">
                            <div class="form-group">
                                <label for="Username" id="termtype" style="font-weight: bold;">
                                    <span class="mandatory">*</span></label>
                                <select id="txttermtype" class="form-control Submit " data-bind='options:TermTypes, optionsText:"TermTypeName", value:Selterm, optionsCaption:"--Select-- ", event{change:LoadLastDate}'>
                                </select>
                            </div>
                        </div>
                        <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12 Submit ">
                            <div class="form-group">
                                <label id="lstDt" style="font-weight: bold;">
                                    SIP Last Date</label><label class="nepalistyle">
                                        [ अन्तिम मिति ]</label><span class="mandatory">*</span>
                                <input type="date" id="txtlstdt" disabled="disabled" class="form-control Submit"
                                    data-bind="value:Last_Dt, valueUpdate: 'input'" />
                            </div>
                        </div>
                    </div>
                    <h4 class="margin-bottom-15 margin-top-0 text-left" style="font-weight: bold;">
                        BANK DETAILS [ बैंक विवरण ]
                    </h4>
                    <hr />
                    <div class="row">
                        <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                            <div class="form-group">
                                <label for="Username">
                                    Bank Name
                                </label>
                                <label class="nepalistyle">
                                    [ बैंक नाम ]</label><span class="mandatory">*</span>
                                <select id="Select1" class="form-control Submit" data-bind='options:Banks, optionsText:"bankname", value:SelectedBank, optionsCaption:"--- Select Bank ---"'>
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
                                <input type="text" id="txtaccountno" class="form-control Submit" data-bind="value:acc_no" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                            <div class="form-group">
                                <label class="control-label text-top padding-left-0" for="textinput" style="font-weight: bold;">
                                    Citizenship
                                </label>
                                <label class="nepalistyle">
                                    [ नागरिकता ]</label>
                                <br />
                                <input id="ImgFile1" type="file" class="form-control Update Submit" />
                                <input id="ImgFileUpload1" type="text" class="btn-link" style="display: none" data-bind="value:FileName1 , click:ViewFile1"
                                    readonly />
                                <p style="text-align: justify; color: red;">
                                    <span>( Document size must be less than 1 mb and jpeg, png and jpg format is only acceptable)</span>
                                </p>
                            </div>
                        </div>
                        <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                            <div class="form-group ">
                                <label class="control-label text-top padding-left-0" for="textinput" style="font-weight: bold;">
                                    Others
                                </label>
                                <label class="nepalistyle">
                                    [ अन्य ]</label>
                                <br />
                                <input id="ImgFile2" type="file" class="form-control Update Submit" />
                                <input id="ImgFileUpload2" type="text" class="btn-link" style="display: none" data-bind="value:FileName2 , click:ViewFile2"
                                    readonly />
                                <p style="text-align: justify; color: red;">
                                    <span>( Document size must be less than 1 mb and jpeg, png and jpg format is only acceptable)</span>
                                </p>
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
                                        with the above mentioned details to enroll in Systematic Investment Plan (SIP) under
                                        the scheme only after carefully reading the prospectus/scheme related documents
                                        published by the fund manager and completely understanding the risk associated with
                                        it. </span><span class="nepalistyle">म / हामी घोषणा गर्दैछु/गर्दछौं कि योजना व्यवस्थापकले
                                            जारी गरेको योजनासंग सम्बन्धित विवरण पुस्तिका लगायत कागजातहरुको ध्यानपूर्वक अध्ययन
                                            गरी यससंग सम्बन्धित जोखीम समेत राम्ररी बुझेको छु/छौं र योजनाको व्यवस्थित लगानी योजनामा
                                            दर्ता गर्न आवेदन दिएको छु/छौं । </span>
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
                                </p>
                                <label>
                                    <input type="radio" name="optionsRadios" id="optionsRadios1" class="Submit" value="Salary"
                                        data-bind="checked:amtDetail" checked>
                                    Salary
                                </label>
                                <label class="nepalistyle">
                                    [तलब]</label>
                                <label style="padding-left: 2%">
                                    <input type="radio" name="optionsRadios" id="optionsRadios2" class="Submit" value="Business"
                                        data-bind="checked:amtDetail">
                                    Business
                                </label>
                                <label class="nepalistyle">
                                    [व्यपारिक कारोवार]</label>
                                <label style="padding-left: 2%">
                                    <input type="radio" name="optionsRadios" id="Radio1" class="Submit" value="Assets"
                                        data-bind="checked:amtDetail">
                                    Sales of Assets
                                </label>
                                <label class="nepalistyle">
                                    [सम्पत्तिको बिक्री]</label>
                                <label style="padding-left: 2%">
                                    <input type="radio" name="optionsRadios" id="Radio2" class="Submit" value="Loan"
                                        data-bind="checked:amtDetail">
                                    Loan
                                </label>
                                <label class="nepalistyle">
                                    [कर्जा]</label>
                                <label style="padding-left: 2%">
                                    <input type="radio" name="optionsRadios" id="Radio3" class="Submit" value="Others"
                                        data-bind="checked:amtDetail">
                                    Others
                                </label>
                                <label class="nepalistyle">
                                    [अन्य]</label>
                                <label>
                                    <input data-bind="value:othersource" type="text" id="other" class="Submit" class="form-control"
                                        style="display: none" /></label>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group">
                                <label for="textinput" style="font-weight: bold;">
                                    Proof of Evidence
                                </label>
                                <input id="ImgFile3" type="file" class="form-control Update Submit" />
                                <input id="ImgFileUpload3" type="text" style="display: none" class="btn-link" data-bind="value:FileName3 , click:ViewFile3"
                                    readonly />
                            </div>
                            <p style="text-align: justify; color: red;">
                                <span>(Document size must be less than 1 mb and jpeg, png and jpg format is only acceptable)</span>
                            </p>
                        </div>
                    </div>
                    <div class="row" id="Drep" style="display:none" >
                        <div class="col-md-12 col-xs-12 col-lg-12 col-sm-12 " style="padding-top: 26px;">
                            <div class="form-group" >
                                <label for="Username" style="font-weight: bold;">
                                    Do You Want To Enroll In Dividend Re-Investment Plan? 
                                </label>
                                <input type="checkbox" id="DrepCheckbox" class="Submit" value='0' data-bind="checked:HasDrep" />
                            </div>
                        </div>
                        <div style="padding-left: 16px;">
                         <div class="form-group">
                          
                            <h5>
                                <u><b>Declaration [ घोषणा ]:</b></u>
                            </h5>
                        </div>
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
                        <div class="col-md-4  padding-left-15 margin-top-15 pull-right">
                            <button data-bind="click:DispalyPaymentOptions" title="Click To Proceed" value="Proceed"
                                class="btn btn-primary btn-md" id="btnProceed">
                                Proceed For Payment
                            </button>
                            <button title="Click To Cancel" data-bind="click:ClearControls" value="Cancel" class="btn btn-primary btn-md "
                                id="btnCancel">
                                Cancel
                            </button>
                            <button title="Click To Submit" data-bind="click:SaveSipRegistration" value="Cancel"
                                disabled="disabled" class="btn btn-primary btn-md " id="BtnSave">
                                Submit
                            </button>
                        </div>
                    </div>
                </div>
                
            </div>
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
    <div class="modal fade in" id="PaymentType" tabindex="-1" style="top: 15%;" role="dialog"
        aria-labelledby="myModalLabel" aria-hidden="false" style="display: block;">
        <div class="modal-dialog" style="height: 126px; width: 655px; padding: 0px;">
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

    <script src="../../Scripts/SIPHandling/SIP_Registration.js?v=0.1" type="text/javascript"></script>
</asp:Content>
