<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="SIPPayment.aspx.cs" Inherits="Openend_SIP.Modules.SIPHandling.SIPPayment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<title>SIP Payment | </title>
  <link rel="icon" href="/Styles/Images/apple-icon-57x57.png" type="image/gif" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"> 
<script src="../../JsLibrary/khalti-checkout.iffe.js" type="text/javascript"></script>


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
        <asp:HiddenField ID="PayAppIdLoginSIPPayment" runat="server"></asp:HiddenField>

        <asp:HiddenField ID="LoginSIPPaymentURL" runat="server"></asp:HiddenField>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:HiddenField ID="forgeryToken" runat="server"/>

 <div id="Container" style="font-family: -webkit-body;">
        <div class="card">
            <div class="card-header">
             
                 <h3 align="center" style="font-weight: bold;">
                    SIP Installment Payment
                </h3>
                <h3 align="center" style="font-weight: bold;font-size: 18px;">
                   [ किस्ता भुक्तानी ]
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
                </div>
                 <div class="row">
                 <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                 <div class="form-group">
                             <button data-bind="click:CheckSHolders" title="Click To Proceed" id="LOAD" value="Proceed" 
                                class="btn btn-primary btn-md" id="Button1">
                                load
                            </button>
                        </div>
                        </div>
                        </div>
                <div class="table-responsive" style=" padding-top: 10px;">
              <table class="table table-striped mt32 customers-list" id="tblfund">
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
                        <th style="display:none">
                           SIP Reg_No
                        </th>
                        <th style="display:none">
                           SIP Amount
                        </th>
                        <th> SIP Amount</th>
                        <th  style="display:none">
                            Balance Amount
                        </th>
                         <th>
                            Action Date
                        </th>
                         <th>
                            Due Day
                        </th>
                        <th style="display:none">
                            ShHolderNo
                        </th>
                        <th style="display:none" >
                            scheme_code
                        </th>
                        <th style="display:none" >
                            ccode
                        </th>
                            
                    </tr>
                  </thead>
                   <tbody id="myTable" data-bind="foreach: ShHolders">
                        <tr class="Preview"  data-bind="attr:{index:$(index),text: $index() +1"  >
                            <td class="checkboxselect" style="display: block">
                                            <input type="checkbox" class="case" name="case[]" data-bind="event:{change:$root.checkValidation}" />
                                        </td>
                             <td data-bind="text:Interval_Seq_No" > </td>
                            <td data-bind="text:SIP_Reg_No" style="display:none"> </td>
                            <td  data-bind="text:Sip_amt" style="display:none"> </td>
                            <td data-bind="text:ReceivedAmt">
                           
                            </td>
                            <td data-bind="text:BalanceAmt"  style="display:none"></td>
                            <td data-bind="text:Action_Date"> </td>
                             <td data-bind="text:SIP_Due_Day"> </td>
                            <td data-bind="text:ShHolderNo"  style="display:none">

                            </td>
                            <td data-bind="text:scheme_code" style="display:none">
                            </td>
                            <td data-bind="text:ccode" style="display:none"></td>
                          
                        
                        </tr>
                       
                  </tbody>
              </table>
        </div>
                <br /> 

                     <div class="row">
                 <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                 <div class="form-group">
                            <label for="Username" style="font-weight: bold;">
                             Total Amount  </label><span class="mandatory">*</span>
                            <input type="text" data-bind="value:TotalAmount" value ="0.00" disabled="disabled" class="form-control Existing Submit"
                                id="TotalAmount" maxlength="50">
                        </div>
                        </div>
                        </div>
             <div class="row">
                <div class="col-md-4padding-left-15 margin-top-15 pull-right">
                     <button data-bind="click:DispalyPaymentOptions" title="Click To Proceed" value="Proceed" 
                        class="btn btn-primary btn-md" id="btnProceed">
                        Proceed For Payment
                    </button>
                     <button title="Click To Cancel" data-bind="click:Clearcontrol" value="Cancel" class="btn btn-primary btn-md " 
                        id="btnCancel">
                        Cancel
                    </button>
                    <button title="Click To Submit" data-bind="click:SubmitPayment" value="Cancel"
                        disabled="disabled" class="btn btn-primary btn-md " id="BtnSubmit">
                        Submit
                    </button>
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
                   <h4 class="modal-title" id="H3" style="color: white;padding-top: 15px;padding-left: 12px;">
                        PROCEED PAYMENT BY</h4>
                </div>
                <div class="modal-body" style="min-height: 168px;">
                 <img src="/Styles/Images/working.gif" id="loader1" alt="working" style="display: none ;position: absolute;top: 75%;left: 47%;transform: translate(-50%, -50%);-ms-transform: translate(-50%, -50%);text-align: center;">
                    <table>
                        <tbody>
                            <tr>
                                <td data-bind="foreach: $root.PaymentTypeLists">
                                    <span data-bind="if: PaymentCode() == '07'">
                                        <img class="link"  style="height: 77px; margin: 10px;" data-bind="attr: { src: PaymentFileName }, click: function (data, event) { $root.SavePayment('07') }">
                                    </span>
                                </td>

                                <td data-bind="foreach: $root.PaymentTypeLists">
                                    <span data-bind="if: PaymentCode() == '09'">
                                        <img class="link" id="payment-button" data-bind="attr: { src: PaymentFileName }" style="height: 77px; margin: 10px;" />
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

    <script src="../../Scripts/SIPHandling/SIPPaymentByLogin.js?v=0.1" type="text/javascript"></script>
</asp:Content>
