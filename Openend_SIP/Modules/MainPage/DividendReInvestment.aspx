<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="DividendReInvestment.aspx.cs" Inherits="Openend_SIP.Modules.RequestHandling.DividendReInvestment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Dividend Re-Investment Registration |  </title>
    <link rel="icon" href="/Styles/Images/apple-icon-57x57.png" type="image/gif" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        .mandatory {
            color: red;
        }

        .nepalistyle {
            font-size: 13px;
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
    <form id ="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:HiddenField ID="forgeryToken" runat="server"/>

    <div id="Container" style="font-family: -webkit-body;">
        <div class="card">
            <div class="card-header">
                <h3 align="center" style="font-weight: bold;">Dividend Re-Investment Plan Registration Form
                </h3>
                <h3 align="center" style="font-weight: bold; font-size: 18px;">[ लाभांश पुन: लगानी योजना दर्ता फाराम ]
                </h3>
            </div>
            <br />
            <br />
            <div class="card-body" style="padding-left: 10px;">
                <div class="row">
                    <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                        <div class="form-group">
                            <label class="control-label text-top padding-left-0" for="textinput" style="font-weight: bold;">
                                Scheme Name
                            </label>
                            <label class="nepalistyle">
                                [ योजनाको नाम ]</label><span class="mandatory">*</span>
                            <select id="dllscheme" disabled="disabled" class="form-control" data-bind='options:Schemes, optionsText:"SchemeEnName", value:SelectedScheme, optionsCaption:"--- Select Scheme ---"'>
                            </select>
                        </div>
                    </div>
                </div>
                <h4 class="margin-bottom-15 margin-top-0 text-left" style="font-weight: bold;">APPLICANT DETAILS [ आवेदक विवरणहरू ]
                </h4>
                <hr />
                <div class="row">
                    <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                        <div class="form-group">
                            <label for="Username">
                                Depository Participants
                            </label>
                            <label class="nepalistyle">
                                [ निक्षेप सदस्य ]</label><span class="mandatory">*</span>
                            <select id="dp" disabled="disabled" class="form-control Existing " data-bind='options:Depo, optionsText:"DPName", value:SelectedDp, optionsCaption:"   --- Select DP --- "'>
                            </select>
                        </div>
                    </div>
                    <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                        <div class="form-group">
                            <label for="Username">
                                BOID No.
                            </label>
                            <label class="nepalistyle">
                                [ हितग्राही खाता नम्बर ]</label><span class="mandatory">*</span>
                            <input type="text" disabled="disabled" id="txtSHolder" onkeypress="return isNumberKey(event)"
                                class="form-control Existing " maxlength="8" data-bind="value:Boid_No " />
                        </div>
                    </div>
                    <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                        <div class="form-group">
                            <label for="Username">
                                Holder No.
                            </label>
                            <label class="nepalistyle">
                                [ हितग्राही धारक नम्बर ]</label><span class="mandatory">*</span>
                            <input type="text" disabled="disabled" onkeypress="return isNumberKey(event)" data-bind="value: ShHolderNo"
                                class="form-control Existing " />
                        </div>
                    </div>
                    <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                        <div class="form-group">
                            <label for="Username">
                                Name
                            </label>
                            <label class="nepalistyle">
                                [ आवेदकको नाम ]</label><span class="mandatory">*</span>
                            <input type="text" id="txtfname" class="form-control Existing " disabled="disabled"
                                data-bind="value:Name" />
                        </div>
                    </div>
                    <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                        <div class="form-group">
                            <label for="Username">
                                Contact No
                            </label>
                            <label class="nepalistyle">
                                [ सम्पर्क नम्बर ]</label><span class="mandatory">*</span>
                            <input type="text" id="txttelno" class="form-control" data-bind="value:P_Tel_No"
                                disabled="disabled" maxlength="10" />
                        </div>
                    </div>
                    <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                        <div class="form-group">
                            <input type="hidden" id="Text1" class="form-control" data-bind="value:HasDrep" disabled="disabled"
                                maxlength="10" />
                        </div>
                    </div>
                </div>
                <div class="row" style="margin: 1%; margin-left: 0%;">
                    <!-- ko if: HasDrep() == false -->
                    <!--ko if: IsPosted()== "UNPOSTED"-->
                    <p class="text-justify" style="color: Red;">
                        Your Request for Enrollment for DReP has been sent. Please wait for approval.
                    </p>
                    <p class="text-justify" style="color: Red;">
                        एनआइबिएल सहभागिता फण्डका लागि नामांकनको लागि तपाईंको अनुरोध पठाइएको छ। अनुमोदनको
                        लागि प्रतीक्षा गर्नुहोस्।
                    </p>
                    <!-- /ko -->
                    <!-- ko if: IsPosted() == "null" -->
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
                    <p class="text-justify" style="color: Red;">
                        Do you want to enroll in DReP ?
                    </p>
                    <p class="text-justify" style="color: Red;">
                        के तपाईं एनआइबिएल सहभागिता फण्डमा दर्रता गर्न चाहनु हुन्छ ? &nbsp;&nbsp;<input id="enrollDrep"
                            type="checkbox" value="enroll" data-bind='"checked:IsEnroll", event{change:CheckEnroll}' />
                    </p>
                    <br />
                    <button title="Enroll In DReP" disabled="disabled" data-bind="click:ErollDReP" id="btnEnroll"
                        class="btn btn-primary btn-md ">
                        Enroll in DReP
                    </button>
                    <!-- /ko -->
                    <!-- ko if: IsPosted() == "POSTED" -->
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
                    <p class="text-justify" style="color: Red;">
                        Do you want to enroll in DReP ?
                    </p>
                    <p class="text-justify" style="color: Red;">
                        के तपाईं एनआइबिएल सहभागिता फण्डमा दर्रता गर्न चाहनु हुन्छ ? &nbsp;&nbsp;<input id="enrollDrep"
                            type="checkbox" value="enroll" data-bind='"checked:IsEnroll", event{change:CheckEnroll}' />
                    </p>
                    <br />
                    <button title="Enroll In DReP" disabled="disabled" data-bind="click:ErollDReP" id="btnEnroll"
                        class="btn btn-primary btn-md ">
                        Enroll in DReP
                    </button>
                    <!-- /ko -->
                    <!-- /ko -->
                    <!-- ko if: HasDrep() != false -->
                    <!--ko if: IsPosted() == "POSTED" -->
                    <p class="text-justify" style="color: Red;">
                        Do you want to cancel your DReP enrollment ?
                    </p>
                    <p class="text-justify" style="color: Red;">
                        के तपाईं एनआइबिएल सहभागिता फण्ड रद्द गर्न चाहनु हुन्छ ? &nbsp;&nbsp;<input id="cancelDrep"
                            type="checkbox" data-bind='"checked:CancelEnroll", event{change:CheckCancelEnroll}' />
                    </p>
                    <button title="Cancel DReP" disabled="disabled" data-bind="click:CancelDReP" id="btnCancel"
                        class="btn btn-primary btn-md ">
                        Cancel DReP
                    </button>
                    <!-- /ko -->
                    <!--ko ifnot: IsPosted() == "POSTED" -->
                    <p class="text-justify" style="color: Red;">
                        Your Request for Cancellation nof DReP has been sent. Please wait for approval.
                    </p>
                    <p class="text-justify" style="color: Red;">
                        तपाईंको अनुरोध एनआइबिएल सहभागिता फण्ड रद्दको लागि पठाइएको छ। अनुमोदनको लागि प्रतीक्षा
                        गर्नुहोस्।
                    </p>
                    <!-- /ko -->
                    <!-- /ko -->
                </div>
            </div>
        </div>
    </div>
   </form>
    <style type="text/css">
        .select2 select2-container select2-container--default select2-container--disabled {
            width: 344px;
        }
    </style>
    <script src="../../Scripts/RequestHandling/DividendReInvestment.js?v=0.1" type="text/javascript"></script>
</asp:Content>
