<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="PurchaseRequestEntry.aspx.cs" Inherits="Openend_SIP.Modules.RequestHandling.PurchaseRequestEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<title> Unit Purchase | </title>
  <link rel="icon" href="/Styles/Images/apple-icon-57x57.png" type="image/gif" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <script src="../../JsLibrary/khalti-checkout.iffe.js" type="text/javascript"></script>

    <script type="text/javascript">
 
    </script>

    <style type="text/css">
         .mandatory
        {
            color: red;
        }
        .nepalistyle
        {
            font-size: 13px
        }
        .disabledbutton {
            pointer-events: none;
            opacity: 0.4;
        }

        .link {
            border: 1px solid #fff;
        }

            .link:hover, .selected {
                -webkit-box-shadow: 0px 1px 13px 0px rgba(69,197,232,0.52);
                -moz-box-shadow: 0px 1px 13px 0px rgba(69,197,232,0.52);
                box-shadow: 0px 1px 13px 0px rgba(69,197,232,0.52);
                border: 1px solid #00adef;
            }
    </style>
     <script>
         $(function () {
             $('.link').click(function () {
                 $(this).addClass('selected');
             });
         });
</script>
<style type="text/css">
    

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
        <asp:HiddenField ID="PayAppIdLoginUnitPurchase" runat="server"></asp:HiddenField>

        <asp:HiddenField ID="LoginUnitPurchaseURL" runat="server"></asp:HiddenField>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:HiddenField ID="forgeryToken" runat="server"/>
    

    <div id="Container" style="font-family: -webkit-body;">
        <div class="card">
            <div class="card-header">
             
                <h3 align="center" style="font-weight: bold;">
                   UNIT PURCHASE REQUEST 
                </h3>
                <h3 align="center" style="font-weight: bold;font-size: 18px;">
                   [ इकाई खरिद दरखास्त फाराम ]
                 </h3>
            </div>
            <br />
            <br />
            <div class="card-body" style="padding-left: 10px;">
                <div class="row">
                    <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                        <div class="form-group">
                            <label class="control-label text-top padding-left-0" for="textinput" style="font-weight: bold;">
                                Scheme Name </label> <label class="nepalistyle">[ योजनाको नाम ]</label><span class="mandatory">*</span>
                            <select id="dllscheme" disabled="disabled" class="form-control" data-bind='options:Schemes, optionsText:"SchemeEnName", value:SelectedScheme, optionsCaption:"--- Select Scheme ---"'>
                            </select>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                        <div class="form-group">
                            <label for="Username">
                                Apply Date </label> <label class="nepalistyle">[लागू मिति ] </label><span class="mandatory">*</span>
                            <input type="date" id="txtapplydt" class="form-control Submit" data-bind="value:APPLY_DT, valueUpdate: 'input', executeOnEnter:GetNavValue, event{blur:GetNavValue}" />
                        </div>
                    </div>
                    <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                        <div class="form-group">
                            <label for="Username">
                                Applicable NAV </label> <label class="nepalistyle">[ प्रति एकाई खुद सम्पती मुल्य ]</label><span class="mandatory">*</span>
                            <input type="text" id="Date1" disabled="disabled" data-bind="value:current_nav" class="form-control " />
                        </div>
                    </div>
                    <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12" style="display: none">
                        <div class="form-group">
                            <label for="Username">
                                NAV date <span class="mandatory">*</span></label>
                            <input type="date" id="txtnavdate" disabled="disabled" data-bind="value:nav_date"
                                class="form-control input-sm Submit" />
                        </div>
                    </div>
                </div>
                <div class="row" style="display: none">
                    <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                        <div class="form-group">
                            <label for="Username">
                                Charge Type  </label> <label class="nepalistyle">[ चार्ज प्रकार ]</label><span class="mandatory">*</span>
                            <select id="dllChargeTypes" disabled="disabled" class="form-control Submit" data-bind='options:ChargeTypes, optionsText:"SDescription", value:SelectedCharge, optionsCaption:"--- Select Charge Type ---"'>
                            </select>
                        </div>
                    </div>
                    <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                        <div class="form-group">
                            <label for="Username">
                                Face Value Per Unit </label> <label class="nepalistyle">[ इकाईमा प्रति मान ] </label><span class="mandatory">*</span>
                            <input type="text" id="NAV" disabled="disabled" data-bind="value:face_val" class="form-control Submit" />
                        </div>
                    </div>
                </div>
                  <h4 class="margin-bottom-15 margin-top-0 text-left" style="font-weight: bold;">
                    APPLICANT DETAILS [ आवेदक विवरणहरू ]
                </h4><hr />
                <div class="row">
                    <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                        <div class="form-group">
                            <label for="Username">
                                Depository Participants </label> <label class="nepalistyle">[ निक्षेप सदस्य ]</label><span class="mandatory">*</span>
                            <select id="dp" disabled="disabled" class="form-control Existing " data-bind='options:Depo, optionsText:"DPName", value:SelectedDp, optionsCaption:"   --- Select DP --- "'>
                            </select>
                        </div>
                    </div>
                    <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                        <div class="form-group">
                            <label for="Username">
                                BOID No.  </label> <label class="nepalistyle">[ हितग्राही खाता नम्बर  ]</label><span class="mandatory">*</span>
                            <input type="text" disabled="disabled" id="txtSHolder" onkeypress="return isNumberKey(event)"
                                class="form-control Existing " maxlength="8" data-bind="value:Boid_No " />
                        </div>
                    </div>
                    <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                        <div class="form-group">
                            <label for="Username">
                                Name  </label> <label class="nepalistyle">[ आवेदकको नाम ]</label><span class="mandatory">*</span>
                            <input type="text" id="txtfname" class="form-control Existing " disabled="disabled"
                                data-bind="value:Name" />
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                        <div class="form-group">
                            <label for="Username">
                                Contact No </label> <label class="nepalistyle">[ सम्पर्क नम्बर ]</label><span class="mandatory">*</span>
                            <input type="text" id="txttelno" class="form-control  " disabled="disabled" maxlength="10"
                                data-bind="value:P_Tel_No" />
                        </div>
                    </div>
                    <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                        <div class="form-group">
                            <label for="Username">
                                Contact No</label> <label class="nepalistyle">[ सम्पर्क नम्बर  ] </label>
                            <input type="text" id="txtmobno" class="form-control " disabled="disabled" maxlength="10"
                                data-bind="value:P_Mobile_no" />
                        </div>
                    </div>
                </div>

                <h4 class="margin-bottom-15 margin-top-0 text-left " style="font-weight: bold;">
                    BANK DETAILS [ बैंक विवरण ]</h4><hr />
      
                <div class="row NoneExisting">
                    <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                        <div class="form-group">
                            <label for="Username">
                                Bank Name  </label> <label class="nepalistyle">[ बैंकको नाम ]</label><span class="mandatory">*</span>
                            <select id="ddlBankName" class="form-control " disabled="disabled" data-bind='options:Banks, optionsText:"bankname", value:SelectedBank, optionsCaption:"--- Select Bank ---"'>
                            </select>
                        </div>
                    </div>
                    <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                        <div class="form-group">
                            <label for="Username">
                                Account No </label> <label class="nepalistyle">[ खाता नम्बर ]</label><span class="mandatory">*</span>
                            <input type="text" id="txtaccountno" disabled="disabled" class="form-control " data-bind="value:Bank_Account_No" />
                        </div>
                    </div>
                </div>
                <h4 class="margin-bottom-15 margin-top-0 text-left" style="font-weight: bold;">
                    APPLICATION DETAILS [ दर्ता विवरणहरू ]</h4><hr />
             
                <div class="row">
                    <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                        <div class="form-group">
                            <label for="Username">
                                Applied Units </label> <label class="nepalistyle">[ खरिद इकाई ]</label><span class="mandatory">*</span>
                            <input  type="text" id="txtapplyunit" onkeyup="this.value=this.value.replace(/[^\d]/,'')" class="form-control fixed Submit" onkeypress="return isNumberKey(event)"
                                data-bind="value:APPLY_UNIT, executeOnEnter:LoadValue, event{blur:LoadValue}" />
                        </div>
                    </div>
                    <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                        <div class="form-group">
                            <label for="Username">
                                Total With Face Value </label><label class="nepalistyle"> [ कुल रकम] </label><span class="mandatory">*</span>
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
                                DP Fee </label><label class="nepalistyle"> [ डिपी शुल्क ]</label><span class="mandatory">*</span>
                            <input type="text" id="Text4" disabled="disabled" onkeypress="return isNumberKey(event)"
                                data-bind="value:other_charges, executeOnEnter:LoadTotalAmount, event{blur:LoadTotalAmount}"
                                class="form-control " />
                        </div>
                    </div>
                    <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                        <div class="form-group">
                            <label for="Username">
                                SEBON Fee </label><label class="nepalistyle"> [ सेबोन शुल्क]  </label><span class="mandatory">*</span>
                            <input type="text" id="Text6" disabled="disabled" onkeypress="return isNumberKey(event)"
                                data-bind="value:SEBON_Fee" class="form-control " />
                        </div>
                    </div>
                    <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                        <div class="form-group">
                            <label for="Username">
                                Entry Load  </label><label class="nepalistyle"> [ बिक्री शुल्क] </label><span class="mandatory">*</span>
                            <input type="text" id="txtchargeamount" disabled="disabled" data-bind="value:charge_amount"
                                class="form-control" />
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                        <div class="form-group">
                            <label for="Username">
                                Total With Nav Value</label><label class="nepalistyle"> [ कुल खुद सम्पती रकम] </label><span class="mandatory">*</span>
                            <input type="text" id="txttwnv" class="form-control" disabled="disabled" data-bind="value:tot_with_Nav_value" />
                        </div>
                    </div>
                    <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                        <div class="form-group">
                            <label for="Username">
                                Total Required Amount </label><label class="nepalistyle"> [ कुल आवश्यक रकम ]</label><span class="mandatory">*</span>
                            <input type="text" id="txtrequiredamt" class="form-control" disabled="disabled" data-bind="value:tot_reqd_amt" />
                        </div>
                    </div>
                    <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                        <div class="form-group">
                            <label for="Username">
                                Deposit Amount </label><label class="nepalistyle"> [ भुक्तानी रकम ]</label><span class="mandatory">*</span>
                            <input type="text" id="Text12" class="form-control" disabled="disabled" data-bind="value:AMOUNT"
                                onkeypress="return isNumberKey(event)" />
                        </div>
                    </div>
                </div>
             
                 <div class="row">
                    <div class="col-md-12 col-xs-12 col-lg-12 col-sm-12">
                        <div class="form-group">
                            <h5>
                             <u><b>Declaration [ घोषणा ]:</b></u>    </h5>
                            <p style="text-align: justify;">
                            <span><i class="fa fa-fw fa-star"></i> I/we hereby declare that I/we am/are applying with the above mentioned details to purchase the units of the scheme only after carefully reading the prospectus/scheme related documents published by the Fund Manager and completely understanding the risk associated with it.</span>
                            <span class="nepalistyle">    म / हामी घोषणा गर्दैछु/गर्दछौं कि योजना व्यवस्थापकले जारी गरेको योजनासंग सम्बन्धित विवरण पुस्तिका लगायत कागजातहरुको ध्यानपूर्वक अध्ययन गरी यससंग सम्बन्धित जोखीम समेत राम्ररी बुझेको छु/छौं र योजनाको माथि उल्लेखित एकाईहरु खरिद गर्न आवेदन दिएको छु/छौं ।</span>
                             
                            </p>
                            <p style="text-align: justify;">
                            <span><i class="fa fa-fw fa-star"></i> I/we hereby declare that the information provided in my/our beneficial owner account completely resembles with my/our personal information and agree that the information in aforementioned BOID in this application form can be used for KYC purpose. </span>
                            <span class="nepalistyle"> यस आवेदनमा उल्लेख गरिएको हितग्राही खातामा रहेको मेरो व्यक्तिगत विवरणहरु फरक नपर्नेगरी दिएको हुनाले सो विवरण नै यस आवेदनको ग्राहक परिचय प्रयोजनका लागि प्रयोग गर्नुभएमा समेत मेरो पूर्ण मञजुरी रहेकोछ । </span>
                                
                            </p>
                              <p style="text-align: justify;">
                                <span><i class="fa fa-fw fa-star"></i><b>Source of Fund (for NPR 1 Million and above)</b> </span>
                                <span class="nepalistyle"><b>आयको श्रोत (रु. १० लाख र सो भन्दा बढीको लागी):</b></span><br />
                                <span>I/we hereby declare that the deposited amount to purchase the units is received from following legitimate source of fund and is not intended for money laundering and/or terrorist financing. </span>
                                <span class="nepalistyle">म/हामी घोषणा गर्दैछु/गर्दछौं कि इकाईहरू खरीद गर्न भुक्तान गरिएको रकम तल उल्लेखित बैधानिक स्रोतद्वारा प्राप्त गरिएको र यो सम्पत्ति शुद्धिकरण वा आतंकवादी कार्यमा लगानीको आशयले गरिएको होइन् ।</span>
                                <p style="text-align: justify;"></p> 
                            </p> 
                               
                        
                            <label>
                                <input type="radio" name="optionsRadios" id="Radio3" value="Salary" data-bind="checked:amtDetail"
                                    >
                                Salary 
                            </label>
                            <label class="nepalistyle"> [तलब]</label>
                            <label style="padding-left: 2%">
                                <input type="radio" name="optionsRadios" id="Radio4" class="Submit" value="Business" data-bind="checked:amtDetail">
                                Business 
                            </label>
                            <label class="nepalistyle"> [व्यपारिक कारोवार]</label>
                            <label style="padding-left: 2%">
                                <input type="radio" name="optionsRadios" id="Radio5" class="Submit" value="Assets" data-bind="checked:amtDetail">
                                Sales of Assets 
                            </label>
                            <label class="nepalistyle"> [सम्पत्तिको बिक्री]</label>
                            <label style="padding-left: 2%">
                                <input type="radio" name="optionsRadios" id="Radio6"  class="Submit" value="Loan" data-bind="checked:amtDetail">
                                Loan
                            </label>
                            <label class="nepalistyle"> [कर्जा]</label>
                             <label style="padding-left: 2%">
                                <input type="radio" name="optionsRadios" id="Radio7" class="Submit" value="Others" data-bind="checked:amtDetail">
                                Others
                            </label>
                            <label class="nepalistyle"> [अन्य]</label>
                             <label style="padding-left: 3%"><input type="text" id="other" class="Submit"  style="display:none"
                            data-bind="value:othersource , valueUpdate: 'input'" /></label>  <span id="other1" style="display:none" class="mandatory">*</span>
                        </div>
                    </div>
                </div>
                <div class="row">
            <div class="col-md-4">
                <div class="form-group">
                    <label for="textinput" style="font-weight: bold;">
                        Proof of Evidence
                    </label>
                    <input id="ImgFile1" type="file" class="form-control  Submit"  />
                   <input id="ProofFileName" type="text" class="btn-link" style="display:none"  data-bind="value:ProofFileName , click:ViewFile" />
                    
                </div>
            </div>
        </div>
           <div class="row" id="HasDividend" style="display: none">
                <div class="col-md-12 col-xs-12 col-lg-12 col-sm-12">
                    <div class="form-group">
                        <label for="Username">
                            <strong style='font-weight: bold;'>Do You Want To Enroll In Dividend Re-Investment Plan?
                            </strong><span class="mandatory"></span></label>
                        <input type="checkbox" class="Submit" value='0' data-bind="checked:HasDividend">
                    </div>
                </div>
                <div style="padding-left: 16px;">
                    <h5>
                        <u><b>Declaration [ घोषणा ]:</b></u>   
                    </h5>
                    <p class="text-justify">

                        <span><i class="fa fa-fw fa-star"></i> I/We would like to register in the Dividend Re-Investment Plan (DRep) under NIBL Sahabhagita Fund (an Open Ended Scheme) with the following details. Further, I/We hereby agree to re-invest my/our all dividend amount in the scheme
                        as per aforementioned instruction after deducting the applicable tax and DP fees and declare that the instruction remains in force till further information from me in writing.</span>
                        <span class="nepalistyle"> म/हामी निम्न बमोजिमको जानकारी संगै एनआइबिएल सहभागिता फण्ड (खुलामुखी
                            योजना) अन्तर्गतको लाभांश पुन: लगानी योजनामा दर्ता हुन चाहन्छौं । साथै, म/हामीले उक्त्त योजनाबाट प्राप्त गर्ने लाभांश 
                            रकममा आवश्यक कर तथा &nbsp;डिपी शूल्क कट्टा गरी (घटाई) प्राप्त गर्ने रकमलाई यसै निवेदन बमोजिम योजनामा पुन: लगानी 
                            गर्न मञ्जुर गर्दछु/छौँ र यो निवेदन म/हामीले अर्को लिखीत जानकारी नगराए सम्मका लागि लागु रहने उद्घोष गर्दछु/छौँ ।  </span>
                    </p>
                </div>
            </div>
                <div class="row">
                    <div class="col-md-4 padding-left-15 margin-top-15 pull-right">
                      <button data-bind="click:DispalyPaymentOptions" title="Click To Proceed" value="Proceed" class="btn btn-primary btn-md"
                        id="btnProceed">
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
                                <div class="img imageContainer" style="width: 1100px;height:1100px">
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
        <div class="modal-dialog" style="height: 126px; width: 645px; padding: 0px;">
            <div class="modal-content ">
                <div class="" style="background-color: #1d4583;">
                    <span aria-hidden="true"></span>
                    <h4 class="modal-title" id="H3" style="padding-top: 15px;">
                        PROCEED PAYMENT BY</h4>
                </div>
                <div class="modal-body" style="min-height: 168px;">
                 <img src="/Styles/Images/working.gif" id="loader1" alt="working" style="display: none ;position: absolute;top: 75%;left: 47%;transform: translate(-50%, -50%);-ms-transform: translate(-50%, -50%);text-align: center;">
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
                                        <img class="link" id="payment-button" data-bind="attr: { src: PaymentFileName }" style="height: 77px; margin: 10px;" />

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
    <style type="text/css">
        .select2 select2-container select2-container--default select2-container--disabled
        {
            width: 344px;
        }
    </style>

     <script src="../../Scripts/RequestHandling/PurchaseRequestEntry.js?v=0.1" type="text/javascript"></script>

</asp:Content>
