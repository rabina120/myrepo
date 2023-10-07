<%@ Page Title="" Language="C#" MasterPageFile="~/LoginMaster.Master" AutoEventWireup="true"
    CodeBehind="SIPPayment.aspx.cs" Inherits="Openend_SIP.Modules.MainPage.SIPPayment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>SIP Payment | </title>
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
            position: initial !important;
        }
    </style>
    <script>
        $(function () {
            $('.link').click(function () {
                $(this).addClass('selected');
            });
        });
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
        <asp:HiddenField ID="PayAppIdSIPPayment" runat="server"></asp:HiddenField>

        <asp:HiddenField ID="SIPPaymentURL" runat="server"></asp:HiddenField>
        
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:HiddenField ID="forgeryToken" runat="server"/>
 
    <style>
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
    <div class="container" style="margin-bottom: 25px; margin-top: 156px;">
        <h3 align="center" style="font-weight: bold;">
            SIP Installment Payment
        </h3>
        <h3 align="center" style="font-weight: bold; font-size: 18px;">
            [ किस्ता भुक्तानी ]
        </h3>
        <br />
        <br />
        <div class="card-body">
            <form class="bootstrap-form needs-validation" novalidate>
            <div class="form">
                <div class="row">
                    <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                        <div class="form-group">
                            <label for="Username" style="font-weight: bold;">
                                Depository Participants
                            </label>
                            <label class="nepalistyle">
                                [ निक्षेप सदस्य]</label><span class="mandatory">*</span>
                            <select id="dp" class="form-control Submit Existing" data-bind='options:Depo, optionsText:"DPName", value:SelectedDp, optionsCaption:"   --- Select DP --- "'>
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
                            <input type="text" id="txtBOID" onkeypress="return isNumberKey(event)" class="form-control Submit Existing"
                                maxlength="8" data-bind="value:BOID , valueUpdate: 'input', executeOnEnter:CheckSHolders, event{blur:CheckSHolders}">
                        </div>
                    </div>
                    <%--<div class="col-md-4 col-xs-12 col-lg-4 col-sm-12 ">
                        <div class="form-group">
                            <label for="Username" style="font-weight: bold;">
                                Installment Date  </label><label class="nepalistyle"> [ किस्ता मिति ]</label><span class="mandatory">*</span>
                            <input type="text" data-bind="value:InstallDate" disabled="disabled" class="form-control Existing Submit"
                                id="txtUsername" maxlength="50">
                        </div>
                    </div>--%>
                </div>
                <div class="row">
                    <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                        <div class="form-group">
                            <label for="Username" style="font-weight: bold;">
                                Name
                            </label>
                            <span class="mandatory">*</span>
                            <input type="text" data-bind="value:Name" disabled="disabled" class="form-control Existing Submit"
                                id="Name" maxlength="50">
                        </div>
                    </div>
                    <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                        <div class="form-group">
                            <label for="Username" style="font-weight: bold;">
                                Contact No1
                            </label>
                            <span class="mandatory">*</span>
                            <input type="text" data-bind="value:Contact1" disabled="disabled" class="form-control Existing Submit"
                                id="Contact1" maxlength="50">
                        </div>
                    </div>
                    <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                        <div class="form-group">
                            <label for="Username" style="font-weight: bold;">
                                Contact No2
                            </label>
                            <span class="mandatory">*</span>
                            <input type="text" data-bind="value:Contact2" disabled="disabled" class="form-control Existing Submit"
                                id="Contact2" maxlength="50">
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12 col-xs-12 col-lg-12 col-sm-12">
                        <div class="table-responsive" style="padding-top: 10px;">
                            <table border="0" class="dataTable table table-bordered table-condensed  sort" id="tblfund">
                                <thead style="background-color: #4b9bd8;">
                                    <tr>
                                        <th class="checkboxselect">
                                            Select
                                            <label for="option" id="selectall">
                                                <span><span></span></span>
                                            </label>
                                        </th>
                                        <th>
                                            Installment No
                                        </th>
                                        <th style="display: none">
                                            SIP Reg_No
                                        </th>
                                        <th style="display: none">
                                            SIP Amount
                                        </th>
                                        <th>
                                            SIP Amount
                                        </th>
                                        <th style="display: none">
                                            Balance Amount
                                        </th>
                                        <th>
                                            Action Date
                                        </th>
                                        <th>
                                            Due Day
                                        </th>
                                        <th style="display: none">
                                            ShHolderNo
                                        </th>
                                        <th style="display: none">
                                            scheme_code
                                        </th>
                                        <th style="display: none">
                                            ccode
                                        </th>
                                    </tr>
                                </thead>
                                <tbody id="myTable" data-bind="foreach: ShHolders">
                                    <tr class="Preview" data-bind="attr:{index:$(index),text: $index() +1">
                                        <td class="checkboxselect" style="display: block">
                                            <input type="checkbox" class="case" name="case[]" data-bind="event:{change:$root.checkValidation}" />
                                        </td>
                                        <td data-bind="text:Interval_Seq_No">
                                        </td>
                                        <td data-bind="text:SIP_Reg_No" style="display: none">
                                        </td>
                                        <td data-bind="text:Sip_amt" style="display: none">
                                        </td>
                                        <td data-bind="text:ReceivedAmt">
                                        </td>
                                        <td data-bind="text:BalanceAmt" style="display: none">
                                        </td>
                                        <td data-bind="text:Action_Date">
                                        </td>
                                        <td data-bind="text:SIP_Due_Day">
                                        </td>
                                        <td data-bind="text:ShHolderNo" style="display: none">
                                        </td>
                                        <td data-bind="text:scheme_code" style="display: none">
                                        </td>
                                        <td data-bind="text:ccode" style="display: none">
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                        <div class="form-group">
                            <label for="Username" style="font-weight: bold;">
                                Total Amount
                            </label>
                            <span class="mandatory">*</span>
                            <input type="text" data-bind="value:TotalAmount" value="0.00" disabled="disabled"
                                class="form-control Existing Submit" id="TotalAmount" maxlength="50">
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4padding-left-15 margin-top-15 pull-right">
                        <%-- <button data-bind="click:SavePayment" title="Click To Proceed" value="Proceed" 
                        class="btn btn-primary btn-md" id="btnProceed">
                        Proceed For Payment
                    </button>--%>
                        <button data-bind="click:DispalyPaymentOptions" title="Click To Proceed" value="Proceed"
                            class="btn btn-primary btn-md" id="btnProceed">
                            Proceed For Payment
                        </button>
                        <button title="Click To Cancel" data-bind="click:Clearcontrol" value="Cancel" class="btn btn-primary btn-md "
                            id="btnCancel">
                            Cancel
                        </button>
                        <button title="Click To Submit" data-bind="click:SubmitPayment" value="Cancel" disabled="disabled"
                            class="btn btn-primary btn-md " id="BtnSubmit">
                            Submit
                        </button>
                    </div>
                </div>
            </div>
            </form>
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
                                        <img class="link" style="height: 77px; margin: 10px;" data-bind="attr: { src: PaymentFileName }, click: function (data, event) { $root.SavePayment('07') }">
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
                                        <img class="link" style="height: 77px; margin: 10px;" data-bind="attr: { src: PaymentFileName }, click: function (data, event) { $root.SavePayment('10') }" />
                                    </span>
                                </td>
                                <td data-bind="foreach: $root.PaymentTypeLists">
                                    <span data-bind="if: PaymentCode() == '12'">
                                        <img class="link" style="height: 77px; margin: 10px;" data-bind="attr: { src: PaymentFileName }, click: function (data, event) { $root.SavePayment('12') }" />
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
    <script src="../../Scripts/MainPage/SIPPayment.js?v=0.1" type="text/javascript"></script>
</asp:Content>
