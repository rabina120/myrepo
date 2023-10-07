<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="UnitRedemption.aspx.cs" Inherits="Openend_SIP.Modules.RequestHandling.UnitRedemption" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Unit Redemption |  </title>
    <link rel="icon" href="/Styles/Images/apple-icon-57x57.png" type="image/gif" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <form id ="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:HiddenField ID="forgeryToken" runat="server"/><style>
        .mandatory
        {
            color: red;
        }
        .nepalistyle
        {
            font-size: 13px;
        }
        tr th
        {
            background-color: #3c8dbc;
        }
        .mandatory
        {
            color: red;
        }
        .nepalistyle
        {
            font-size: 13px;
        }
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
                                        Password</label>
                                    <label class=" nepalistyle col-form-label">
                                        [पासवर्ड]
                                    </label>
                                    <span class="mandatory">*</span>
                                </div>
                                <div class="col-sm-8">
                                    <div class="col-sm-12">
                                        <input type="password" class="form-control" data-bind="value:Passcode">
                                    </div>
                                </div>
                            </div>
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
                                        <input type="text" class="form-control" data-bind="value:EmailOtp">
                                    </div>
                                </div>
                            </div>
                            <div class=" form-group row">
                                <div class="col-md-2 padding-left-15 margin-top-15 pull-right">
                                    <%--<button data-bind="click:RedemptionVerified" title="Click To Save" value="Save" class="btn btn-primary btn-md "
                                        id="Button1">--%>
                                        <button data-bind="click:SaveRedemptionEntry" title="Click To Save" value="Save" class="btn btn-primary btn-md "
                                        id="Button1">
                                        Submit
                                    </button>
                                </div>
                            </div>
                            <div class="form-group row" style="display:none" id="Otpwaitmsg">
                                <div class="col-sm-8">
                                    <label for="Username" class=" col-form-label">
                                         Please wait OTP is being generated.....</label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
 

    <div class="card-header">
        <h3 align="center" style="font-weight: bold;">
            UNIT REDEMPTION REQUEST
        </h3>
        <h3 align="center" style="font-weight: bold; font-size: 18px;">
        </h3>
    </div>
    <br />
    <div class="card-body" style="padding: 10px">
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
                    <input type="date" id="txtapplydt" class="form-control" data-bind="value:APPLY_DT, valueUpdate: 'input', executeOnEnter:GetNavValue, event{blur:GetNavValue}" />
                </div>
            </div>
            <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                <div class="form-group">
                    <label for="Username">
                        Applicable NAV
                    </label>
                    <label class="nepalistyle">
                        [ प्रति एकाई खुद सम्पती मुल्य ]</label><span class="mandatory">*</span>
                    <input type="text" id="Text14" disabled="disabled" data-bind="value:current_nav"
                        class="form-control" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12" style="display: none">
                <div class="form-group">
                    <label for="Username">
                        Charge Type <span class="mandatory">*</span></label>
                    <select id="Select1" disabled="disabled" class="form-control" data-bind='options:ChargeTypes, optionsText:"SDescription", value:SelectedCharge, optionsCaption:"--- Select Charge Type ---"'>
                    </select>
                </div>
            </div>
            <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12" style="display: none">
                <div class="form-group">
                    <label for="Username">
                        Face Value Per Unit <span class="mandatory">*</span></label>
                    <input type="text" id="Text2" disabled="disabled" data-bind="value:face_val" class="form-control" />
                </div>
            </div>
            <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12" style="display: none">
                <div class="form-group">
                    <label for="Username">
                        NAV date <span class="mandatory">*</span></label>
                    <input type="date" id="Date2" disabled="disabled" data-bind="value:nav_date" class="form-control input-sm" />
                </div>
            </div>
        </div>
        <br />
        <h4 class="margin-bottom-15 margin-top-0 text-left" style="font-weight: bold;">
            APPLICANT DETAILS [ आवेदक विवरणहरू ]
        </h4>
        <hr />
        <div class="row">
            <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                <div class="form-group">
                    <label for="Username">
                        Depository Participants
                    </label>
                    <label class="nepalistyle">
                        [ निक्षेप सदस्य ]</label><span class="mandatory"></span>
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
                        [ हितग्राही खाता नम्बर ]</label><span class="mandatory"></span>
                    <input type="text" disabled="disabled" id="txtSHolder" onkeypress="return isNumberKey(event)"
                        class="form-control Existing " maxlength="8" data-bind="value:Boid_No " />
                </div>
            </div>
            <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                <div class="form-group">
                    <label for="Username">
                        Name
                    </label>
                    <label class="nepalistyle">
                        [ आवेदकको नाम ]</label><span class="mandatory"></span>
                    <input type="text" id="txtfname" class="form-control Existing " disabled="disabled"
                        data-bind="value:Name" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                <div class="form-group">
                    <label for="Username">
                        Contact No
                    </label>
                    <label class="nepalistyle">
                        [ सम्पर्क नम्बर ]</label><span class="mandatory"></span>
                    <input type="text" id="txttelno" class="form-control  " disabled="disabled" maxlength="10"
                        data-bind="value:P_Tel_No" />
                </div>
            </div>
            <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                <div class="form-group">
                    <label for="Username">
                        Contact No</label>
                    <label class="nepalistyle">
                        [ सम्पर्क नम्बर ]
                    </label>
                    <input type="text" id="txtmobno" class="form-control " disabled="disabled" maxlength="10"
                        data-bind="value:P_Mobile_no" />
                </div>
            </div>
        </div>
        <h4 class="margin-bottom-15 margin-top-0 text-left " style="font-weight: bold;">
            BANK DETAILS [ बैंक विवरण ]</h4>
        <hr />
        <div class="row">
            <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                <div class="form-group">
                    <label for="Username">
                        Bank Name
                    </label>
                    <label class="nepalistyle">
                        [ बैंकको नाम ]</label><span class="mandatory"></span>
                    <select id="ddlBankName" class="form-control Existing" data-bind='options:Banks, optionsText:"bankname", value:SelectedBank, optionsCaption:"--- Select Bank ---"'>
                    </select>
                </div>
            </div>
            <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                <div class="form-group">
                    <label for="Username">
                        Account No
                    </label>
                    <label class="nepalistyle">
                        [ खाता नम्बर ]</label><span class="mandatory"></span>
                    <input type="text" id="txtaccountno" class="form-control Existing" data-bind="value:Bank_Account_No" />
                </div>
            </div>
        </div>
        <h4 class="margin-bottom-15 margin-top-0 text-left" style="font-weight: bold;">
            ALLOTMENT DETAILS [ दर्ता विवरणहरू ]</h4>
        <hr />
        <div class="row">
            <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                <div class="form-group">
                    <label for="Username">
                        Balance Unit <span class="mandatory"></span>
                    </label>
                    <input type="text" onkeypress="return isNumberKey(event)" id="Text6" class="form-control"
                        disabled="disabled" data-bind="value:BalUnit" />
                </div>
            </div>
            <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                <div class="form-group">
                    <label for="Username">
                        Inv_Amount<span class="mandatory"></span>
                    </label>
                    <input type="text" id="Text7" class="form-control" onkeypress="return isNumberKey(event)"
                        disabled="disabled" data-bind="value:Inv_Amt" />
                </div>
            </div>
            <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                <div class="form-group">
                    <label for="Username">
                        Average Price<span class="mandatory"></span>
                    </label>
                    <input type="text" id="Text1" disabled="disabled" class="form-control" data-bind="value:Average_Price" />
                </div>
            </div>
            <div class="col-md-4 col-xs-4 col-lg-4 col-sm-4" style="display: none">
                <div class="form-group">
                    <label for="Username">
                        Actual Average Price<span class="mandatory"></span>
                    </label>
                    <input type="text" id="Text18" disabled="disabled" class="form-control" data-bind="value:ActAverage_Price" />
                </div>
            </div>
        </div>
       
        <div class="row">
        <div class="col-md-12">
                                    <table class="table table-bordered table-fixed-header resizable" id="tblSearch" width="450px">
                                        <thead class="header">
                                            <tr>
                                               <th>
                                                  SNO
                                                </th>
                                                <th>
                                                    Allocation No
                                                </th>
                                                <th>
                                                    lot_Seqno
                                                </th>
                                               
                                                <th>
                                                    value dt
                                                </th>
                                                <th>
                                                    Balance Unit
                                                </th>
                                                <th>
                                                    Unposted Unit
                                                </th>
                                                <th>
                                                    Locked Unit
                                                </th>
                                                <th>
                                                    Inv_Amount
                                                </th>
                                                <th>
                                                    Can Be Sell
                                                </th>
                                                 <th>
                                                    Trantype
                                                </th>
                                                <th>
                                                  Holding days
                                                </th>
                                                <th>
                                                Sip Reg Date
                                                </th>
                                                <th>
                                                Sip Holding Days
                                                </th>
                                            </tr>
                                        </thead>
                                        <tbody data-bind="foreach: SHolders">
                                            <tr class="Preview" >
                                                <td>
                                                    <span data-bind="text:SNO" />
                                                </td>
                                                <td style="display: none">
                                                    <span data-bind="text: scheme_code " />
                                                </td>
                                                <td>
                                                    <span data-bind="text:Allocation_no" />
                                                </td>
                                                <td>
                                                   <span data-bind="text:seqno" />
                                                </td>
                                                <td style="display: none">
                                                    <span data-bind="text:SHHOLDERNO" />
                                                </td>
                                                <td>
                                                    <span data-bind="text:value_dt" />
                                                </td>
                                                <td>
                                                    <span data-bind="text:balance_unit" />
                                                </td>
                                                <td>
                                                    <span data-bind="text:Unposted_Unit" />
                                                </td>
                                                <td>
                                                    <span data-bind="text:locked_unit" />
                                                </td>
                                                <td>
                                                    <span data-bind="text:inv_amt" />
                                                </td>
                                                <td>
                                                    <span data-bind="text:Can_be_Sell" />
                                                </td>
                                                 <td>
                                                    <span data-bind="text:tran_type" />
                                                </td>
                                                  <td>
                                                    <span data-bind="text:Holding_Days" />
                                                </td>
                                                <td>
                                                    <span data-bind="text:Sip_value_dt" />
                                                </td>
                                                <td>
                                                    <span data-bind="text:Sip_Holding_Days" />
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <div class="modal-footer  padding-0">
                                    <div id="divPage" style="margin: auto; display: none;">
                                    </div>
                                </div>
                                </div>
        </div>
   <%--     <div class="row">
            <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                <div class="form-group">
                    <label for="Username">
                        LOT UNIT<span class="mandatory">*</span>
                    </label>
                    <input type="text" onkeypress="return isNumberKey(event)" id="txtlotunit" disabled="disabled"
                        class="form-control" data-bind="value:balance_unit" />
                </div>
            </div>
            <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                <div class="form-group">
                    <label for="Username">
                        Lot_seqno<span class="mandatory">*</span>
                    </label>
                    <input type="text" id="Text8" disabled="disabled" onkeypress="return isNumberKey(event)"
                        class="form-control" data-bind="value:seqno" />
                </div>
            </div>
            <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                <div class="form-group">
                    <label for="Username">
                        UnPosted Unit<span class="mandatory">*</span>
                    </label>
                    <input type="text" id="Text11" class="form-control" disabled="disabled" data-bind="value:Unposted_Unit" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                <div class="form-group">
                    <label for="Username">
                        Locked Unit<span class="mandatory">*</span>
                    </label>
                    <input type="text" disabled="disabled" id="Text13" onkeypress="return isNumberKey(event)"
                        class="form-control" data-bind="value:locked_unit" />
                </div>
            </div>
            <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                <div class="form-group">
                    <label for="Username">
                        Purchase_Date<span class="mandatory">*</span>
                    </label>
                    <input type="text" id="txtinvamt" class="form-control" disabled="disabled" data-bind="value:p_dt" />
                </div>
            </div>
            <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                <div class="form-group">
                    <label for="Username">
                        Holding_Days<span class="mandatory">*</span>
                    </label>
                    <input type="text" id="Text12" disabled="disabled" class="form-control" data-bind="value:Holding_Days" />
                </div>
            </div>
        </div>--%>
        <div class="row">
            <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                <div class="form-group">
                    <label for="Username">
                        Redemption Unit<span class="mandatory">*</span>
                    </label>
                    <input type="text" decimals="2" id="txtredemunit" onkeypress="return isNumberKey(event)"
                        class="form-control fixed" value=0 data-bind="value:redem_unit" />
                </div>
            </div>
             <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12" style=" padding-top: 25px; padding-left: 25px;">
                <div class="form-group">
                    <button title="Click To Add" class="btn btn-primary btn-md" id="btnAdd" data-bind="click:AddData"
                        value="add">
                       Go
                    </button>
                </div>
            </div>
        </div>
        <div class="row">
           
        </div>
        <br />
        <div class="row">
            <div class="col-md-12 col-xs-12 col-lg-12 col-sm-12">
                <div class=" table-responsive">
                    <table id="tblUsers" data-bind="visible: true" border="0" class="dataTable table table-bordered table-condensed  sort">
                        <tr>
                            <th>
                                SNo
                            </th>
                            <th>
                                Lot No
                            </th>
                            <th>
                                Lot Unit
                            </th>
                            <th>
                                Purchase_Dt
                            </th>
                            <th>
                                Redem Unit
                            </th>
                            <th>
                                Redem Inv Unit
                            </th>
                            <th>
                                Exit Load
                            </th>
                            <th>
                                Holding Days
                            </th>
                            <th>
                                CG Amount
                            </th>
                            <th>
                                CGT Amount
                            </th>
                            <th style="display: none"></th>
                            <th style="display: none"></th>
                            <th style="display: none"></th>
                            <th>Sip Holding Days</th>

                        </tr>
                        <tbody id="tblBody" data-bind="foreach:UserCenters">
                            <tr>
                                <td>
                                    <span data-bind="text:($index() + 1)"></span>
                                </td>
                                <td>
                                    <span data-bind="text:Allocation_no"></span>
                                </td>

                                <td>
                                    <span data-bind="text:balance_unit"></span>
                                </td>
                                <td>
                                    <span data-bind="text:p_dt " />
                                </td>
                                <td>
                                    <span data-bind="text: redem_unit" />
                                </td>
                                <td>
                                    <span data-bind="text: inv_amt_redem_unit" />
                                </td>
                                <td>
                                    <span data-bind="text: exe_load" />
                                </td>
                                <td>
                                    <span data-bind="text:Holding_Days"></span>
                                </td>
                                <td>
                                  <span data-bind="text: capital_gain_amount" />
                                </td>
                                 <td>
                                    <span data-bind="text: capital_gain_tax_amount"  />
                                </td>
                                 <td style="display: none">
                                      <span data-bind="text:CGT"></span>
                                </td>
                                <td style="display: none">
                                      <span data-bind="text:SNO"></span>
                                </td>
                                <td style="display: none">
                                      <span data-bind="text:seqno"></span>
                                </td>
                                 <td>
                                    <span data-bind="text: Sip_Holding_Days"  />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
        <br />
        <br />
        <br />
        <div class="row">
            <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                <div class="form-group">
                    <label for="Username">
                        Total Enter Unit<span class="mandatory">*</span>
                    </label>
                    <input type="text" disabled="disabled" id="txttot_redem_unit" data-bind="value:tot_redem_unit"
                        class="form-control" />
                </div>
            </div>
            <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                <div class="form-group">
                    <label for="Username">
                        Total Inv_Amt <span class="mandatory">*</span>
                    </label>
                    <input type="text" disabled="disabled" id="txttot_inv_amt_redem_unit" class="form-control"
                        data-bind="value:tot_inv_amt_redem_unit" />
                </div>
            </div>
            <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                <div class="form-group">
                    <label for="Username">
                        Total Cur_Val <span class="mandatory">*</span>
                    </label>
                    <input type="text" id="txttot_cur_val" disabled="disabled" class="form-control" data-bind="value:tot_cur_val" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                <div class="form-group">
                    <label for="Username">
                        Total Exe_Load<span class="mandatory">*</span>
                    </label>
                    <input type="text" disabled="disabled" id="txttot_exe_load" class="form-control"
                        data-bind="value:tot_exe_load" />
                </div>
            </div>
            <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                <div class="form-group">
                    <label for="Username">
                        DP Fee
                    </label>
                    <label class="nepalistyle">
                        [ डिपी शुल्क ]</label><span class="mandatory">*</span>
                    <input type="text" id="Text5" onkeypress="return isNumberKey(event)" disabled="disabled"
                        class="form-control" data-bind="value:other_charges" />
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
                    <input type="text" id="txtsebonfee" disabled="disabled" class="form-control" data-bind="value:SEBON_Fee" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                <div class="form-group">
                    <label for="Username">
                        Amount Payable Before Tax<span class="mandatory">*</span>
                    </label>
                    <input type="text" id="txtantpayablebeforetax" disabled="disabled" class="form-control"
                        data-bind="value:amt_pay_before_tax" />
                </div>
            </div>
            <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                <div class="form-group">
                    <label for="Username">
                        Total Cap_Gain <span class="mandatory">*</span>
                    </label>
                    <input type="text" id="Text9" disabled="disabled" class="form-control" data-bind="value:tot_cap_gain" />
                </div>
            </div>
            <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                <div class="form-group">
                    <label for="Username">
                        GainLoss_Status<span class="mandatory">*</span>
                    </label>
                    <select disabled="disabled" class="form-control" data-bind="options: Status,
                                               optionsText: 'StatusName',
                                               value: selectedGLStatus,
                                               optionsCaption: '--Select--'">
                    </select>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                <div class="form-group">
                    <label for="Username">
                        Capital Gain Tax<span class="mandatory">*</span>
                    </label>
                    <select class="form-control" id="dllCapitalGain" data-bind="options: CapitalGains,
                                               optionsText: 'GainName',
                                               value: selectedGain,
                                               optionsCaption: '--Select--', event{change:GetCGTAmt}">
                    </select>
                </div>
            </div>
            <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                <div class="form-group">
                    <label for="Username">
                        Total Cap_Gain_Tax_Amt<span class="mandatory">*</span>
                    </label>
                    <input type="text" id="Text10" disabled="disabled" class="form-control" data-bind="value:capital_gain_tax_amt" />
                </div>
            </div>
             <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                <div class="form-group">
                   <label for="textinput" style="font-weight: bold;">
                           PAN No.<span class="mandatory">*</span>
                        </label>
                         <input type="text" id="txtpan" class="form-control" data-bind="value:PAN_No" />
                       <%-- <input id="ImgFile1" type="file" class="form-control  Submit" />
                        <input id="PAN" type="text" class="btn-link" style="display: none" data-bind="value:PanCard , click:ViewFile" />--%>
                </div>
            </div>
            </div>
            <div class ="row">
            <div class="col-md-5 col-xs-12 col-lg-5 col-sm-12">
                <div class="form-group">
                    <label for="Username" class=" col-form-label">
                        Transaction Pin</label>
                    <label class=" nepalistyle col-form-label">
                        [ ----- ]
                    </label>
                    <span class="mandatory">*</span>
                    <i class="fa fa-lock" aria-hidden="true"> 
                    <a  href="/Modules/Container/TransactionPin.aspx" style="color:Red"> Please, Click Here To Set New Transaction Pin.</a>
                    </i>
                    <input type="password" class="form-control" data-bind="value:TransPin">
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4padding-left-15 margin-top-15 pull-right">
                <button data-bind="click:CheckRedemptionSecurity" disabled="disabled" title="Click To Save"
                    value="Save" class="btn btn-primary btn-md " id="btnSave">
                    Save
                </button>
                <button title="Click To Cancel" value="Cancel" data-bind="click:ClearControls" disabled="disabled"
                    class="btn btn-primary btn-md " id="btnCancel">
                    Cancel
                </button>
            </div>
        </div>
    </div>
  </form>
  
      <script src="/JsLibrary/datatables.min.js" type="text/javascript"></script>
    <script src="/JsLibrary/dataTables.buttons.min.js" type="text/javascript"></script>
    <script src="/JsLibrary/jszip.min.js" type="text/javascript"></script>
    <script src="/JsLibrary/buttons.html5.min.js" type="text/javascript"></script>
    <script src="../../Scripts/RequestHandling/RedemptionRequestEntry.js?v=0.1" type="text/javascript"></script>
</asp:Content>
