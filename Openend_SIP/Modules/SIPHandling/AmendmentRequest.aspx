<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AmendmentRequest.aspx.cs" Inherits="Openend_SIP.Modules.SIPHandling.AmendmentRequest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<title>SIP Amendment Request |  </title>
  <link rel="icon" href="/Styles/Images/apple-icon-57x57.png" type="image/gif" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <form id ="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:HiddenField ID="forgeryToken" runat="server"/>
 <style>
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
<div id="Container" style="font-family: -webkit-body;">
        <div class="card">
            <div class="card-header">
                <h3 align="center" style="font-weight: bold;">
                    SIP Amendment Request
                </h3>
            </div>
            <div class="card-body" style="padding: 12px;">
               
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
                                [ निक्षेप सदस्य ]</label><span class="mandatory">*</span>
                            <select id="Select2" disabled="disabled" class="form-control Existing " data-bind='options:Depo, optionsText:"DPName", value:SelectedDp, optionsCaption:"   --- Select DP --- "'>
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
                                class="form-control Existing " maxlength="8" data-bind="value:BOID " />
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
                    <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12" >
                        <div class="form-group">
                            <label for="Username">
                                Sip_Reg_No
                            </label>
                            <%--<label class="nepalistyle">
                                [ आवेदकको नाम ]</label>--%><span class="mandatory">*</span>
                            <input type="text" id="sipregno" class="form-control Existing " disabled="disabled"
                                data-bind="value:Sip_Reg_No" />
                        </div>
                    </div>

                    <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12" >
                     <div class="form-group" id="ammend">
                                <label for="Username">
                                    Ammendment No <span class="mandatory">*</span></label>
                                <input type="text" class="form-control" disabled="disabled" id="Text24" placeholder="Ammendment No"
                                    data-bind="value:Amdnt_No" maxlength="100">
                            </div>
                       
                    </div>
                </div>
                    <div class="row">
                    <div class="col-md-6 col-xs-12 col-lg-6 col-sm-12 ">
                         <div class="form-group" style="padding-top: 10px;">
                           <label class="control-label text-top padding-left-0" for="textinput" style="font-weight: bold;">
                                Request Type  <span class="mandatory">*</span>
                            </label>
                            <input type="radio" value="02"  id="Ammendment" name="RefreshType" data-bind="checked:checkRptTyp" disabled="disabled" >Ammendement 
                          <input type="radio" value="04" style="margin-left:4%" id="Renewal" name="RefreshType" data-bind="checked:checkRptTyp" disabled="disabled">Renewal
                      
                        </div>
                    </div>
              </div>
              <div class="row">
                    <div class="col-md-4 col-xs-4 col-lg-4 col-sm-4">
                     <div class="form-group" style="font-weight: bold;">
                                <p><u>
                                   Can Be Amended</u>
                                </p>
                            </div>
                    </div>
                        <div class="col-md-4 col-xs-4 col-lg-4 col-sm-4">
                            <div class="form-group" style="font-weight: bold;">
                                <p><u>
                                    Previous Data</u>
                                </p>
                            </div>
                        </div>
                        <div class="col-md-4 col-xs-4 col-lg-4 col-sm-4">
                            <div class="form-group" style="font-weight: bold;">
                                <p><u>
                                    New Data</u>
                                </p>
                            </div>
                        </div>
                    </div>
                     <div class="row">
                        <div class="col-md-4 col-xs-4 col-lg-4 col-sm-4">
                            <div class="form-group">
                                <label for="Email" style="font-weight: bold;">
                                    ContactNo_1 </label>
                              <%--  <input type="text" data-bind="value:Contact1" class="form-control ActiveDt" id="txtCnt1"
                                    maxlength="50">--%>
                            </div>
                        </div>
                        <div class="col-md-4 col-xs-4 col-lg-4 col-sm-4">
                            <div class="form-group">
                            <input type="text" data-bind="value:Contact1" disabled="disabled" class="form-control ActiveDt" id="Text7"
                                    maxlength="10">
                            </div>
                            </div>
                             <div class="col-md-4 col-xs-4 col-lg-4 col-sm-4">
                            <div class="form-group">
                            <input type="text" data-bind="value:NewContact1"  class="form-control ActiveDt" id="Text12"
                                    maxlength="10">
                            </div>
                            </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4 col-xs-4 col-lg-4 col-sm-4">
                            <div class="form-group">
                                <label for="Email" style="font-weight: bold;">
                                    ContactNo_2 </label>
                              <%--  <input type="text" data-bind="value:Contact1" class="form-control ActiveDt" id="txtCnt1"
                                    maxlength="50">--%>
                            </div>
                        </div>
                        <div class="col-md-4 col-xs-4 col-lg-4 col-sm-4">
                            <div class="form-group">
                           <input type="text" data-bind="value:Contact2" disabled="disabled" class="form-control ActiveDt" id="Text13"
                                    maxlength="10">
                            </div>
                            </div>
                             <div class="col-md-4 col-xs-4 col-lg-4 col-sm-4">
                            <div class="form-group">
                            <input type="text" data-bind="value:NewContact2"  class="form-control ActiveDt" id="Text14"
                                    maxlength="10">
                            </div>
                            </div>
                     
                    </div>
                    <div class="row">
                        <div class="col-md-4 col-xs-4 col-lg-4 col-sm-4">
                            <div class="form-group">
                                <label for="Email" style="font-weight: bold;">
                                    Email <span class="mandatory"></span></label>
                              <%--  <input type="text" data-bind="value:Contact1" class="form-control ActiveDt" id="txtCnt1"
                                    maxlength="50">--%>
                            </div>
                        </div>
                        <div class="col-md-4 col-xs-4 col-lg-4 col-sm-4">
                            <div class="form-group">
                           <input type="text" data-bind="value:Email" disabled="disabled" class="form-control ActiveDt" id="Text15">
                            </div>
                            </div>
                             <div class="col-md-4 col-xs-4 col-lg-4 col-sm-4">
                            <div class="form-group">
                            <input type="text" data-bind="value:NewEmail"  class="form-control ActiveDt" id="Text16">
                            </div>
                            </div>
                     
                    </div>
                    <div class="row">
                        <div class="col-md-4 col-xs-4 col-lg-4 col-sm-4">
                            <div class="form-group">
                                <label for="Email" style="font-weight: bold;">
                                    PayeeName <span class="mandatory"></span></label>
                              <%--  <input type="text" data-bind="value:Contact1" class="form-control ActiveDt" id="txtCnt1"
                                    maxlength="50">--%>
                            </div>
                        </div>
                        <div class="col-md-4 col-xs-4 col-lg-4 col-sm-4">
                            <div class="form-group">
                           <input type="txtpname"  data-bind="value:payeename" disabled="disabled" class="form-control ActiveDt"
                                    id="Txtpname1" maxlength="50">
                            </div>
                            </div>
                             <div class="col-md-4 col-xs-4 col-lg-4 col-sm-4">
                            <div class="form-group">
                            <input type="text" data-bind="value:Newpayeename"  class="form-control ActiveDt" id="Text17"
                                    maxlength="50">
                            </div>
                            </div>
                     
                    </div>
                    <div class="row">
                        <div class="col-md-4 col-xs-4 col-lg-4 col-sm-4">
                            <div class="form-group">
                                <label for="Email" style="font-weight: bold;">
                                    Payee Contact No <span class="mandatory"></span></label>
                              <%--  <input type="text" data-bind="value:Contact1" class="form-control ActiveDt" id="txtCnt1"
                                    maxlength="50">--%>
                            </div>
                        </div>
                        <div class="col-md-4 col-xs-4 col-lg-4 col-sm-4">
                            <div class="form-group">
                            <input type="txtpname" data-bind="value:PayeeContactNo" disabled="disabled" class="form-control ActiveDt"
                                    id="Txtpname4" maxlength="50">
                            </div>
                            </div>
                             <div class="col-md-4 col-xs-4 col-lg-4 col-sm-4">
                            <div class="form-group">
                            <input type="text" data-bind="value:NewPayeeContactNo"  class="form-control ActiveDt" id="Text18"
                                    maxlength="10">
                            </div>
                            </div>
                     
                    </div>
                     <div class="row">
                        <div class="col-md-4 col-xs-4 col-lg-4 col-sm-4">
                            <div class="form-group">
                                <label for="Email" style="font-weight: bold;">
                                   SIP Interval<span class="mandatory"></span></label>
                              <%--  <input type="text" data-bind="value:Contact1" class="form-control ActiveDt" id="txtCnt1"
                                    maxlength="50">--%>
                            </div>
                        </div>
                        <div class="col-md-4 col-xs-4 col-lg-4 col-sm-4">
                            <div class="form-group">
                            <select id="Select9" class="form-control ActiveDt" disabled="disabled" data-bind='options:Intervals, optionsText:"SIP_Interval", value:SelectedInterval, optionsCaption:"--Select SIP Interval-- "'>
                                </select>
                            </div>
                            </div>
                             <div class="col-md-4 col-xs-4 col-lg-4 col-sm-4">
                            <div class="form-group">
                             <select id="Select11" class="form-control ActiveDt" data-bind='options:NewIntervals, optionsText:"NewSIP_Interval", value:NewSelectedInterval, optionsCaption:"--Select New SIP Interval-- "'> 
                                </select>
                            </div>
                            </div>
                     
                    </div>
                     <div class="row">
                        <div class="col-md-4 col-xs-4 col-lg-4 col-sm-4">
                            <div class="form-group">
                                <label for="Email" style="font-weight: bold;">
                                   SIP Amount<span class="mandatory"></span></label>
                              <%--  <input type="text" data-bind="value:Contact1" class="form-control ActiveDt" id="txtCnt1"
                                    maxlength="50">--%>
                            </div>
                        </div>
                        <div class="col-md-4 col-xs-4 col-lg-4 col-sm-4">
                            <div class="form-group">
                             <input type="text" data-bind="value:Sip_amt" disabled="disabled" class="form-control ActiveDt" id="Text19"
                                    maxlength="50">
                            </div>
                            </div>
                             <div class="col-md-4 col-xs-4 col-lg-4 col-sm-4">
                            <div class="form-group">
                              <input type="text"  data-bind="value:NewSip_amt,executeOnEnter:amountCheck, event{blur:amountCheck}"  class="form-control ActiveDt" id="Text20"
                                    maxlength="50">
                            </div>
                            </div>
                     
                    </div>
                    <div class="row">
                        <div class="col-md-4 col-xs-4 col-lg-4 col-sm-4">
                            <div class="form-group">
                                <label for="Email" style="font-weight: bold;">
                                  SIP Effective Date<span class="mandatory">*</span></label>
                              <%--  <input type="text" data-bind="value:Contact1" class="form-control ActiveDt" id="txtCnt1"
                                    maxlength="50">--%>
                            </div>
                        </div>
                        <div class="col-md-4 col-xs-4 col-lg-4 col-sm-4">
                            <div class="form-group">
                            <input type="date" id="Date3" class="form-control ActiveDt" disabled="disabled" data-bind="value:Effective_Dt, valueUpdate: 'input'" />
                            </div>
                            </div>
                             <div class="col-md-4 col-xs-4 col-lg-4 col-sm-4">
                            <div class="form-group">
                              <input type="date" id="Date4" class="form-control ActiveDt" data-bind="value:NewEffective_Dt, valueUpdate: 'input'"  />
                            </div>
                            </div>
                     
                    </div>
                     <div class="row">
                        <div class="col-md-4 col-xs-4 col-lg-4 col-sm-4">
                            <div class="form-group">
                                <label for="Email" style="font-weight: bold;">
                                 Introducer<span class="mandatory"></span></label>
                              <%--  <input type="text" data-bind="value:Contact1" class="form-control ActiveDt" id="txtCnt1"
                                    maxlength="50">--%>
                            </div>
                        </div>
                        <div class="col-md-4 col-xs-4 col-lg-4 col-sm-4">
                            <div class="form-group">
                            <input type="text" data-bind="value:Introducer" disabled="disabled" class="form-control ActiveDt" id="Text21"
                                    maxlength="50" />
                            </div>
                            </div>
                             <div class="col-md-4 col-xs-4 col-lg-4 col-sm-4">
                            <div class="form-group">
                              <input type="text" data-bind="value:NewIntroducer"  class="form-control ActiveDt" id="Text22"
                                    maxlength="50" />
                            </div>
                            </div>
                     
                    </div>
                     <div class="row">
                        <div class="col-md-4 col-xs-4 col-lg-4 col-sm-4">
                            <div class="form-group">
                                <label for="Email" style="font-weight: bold;">
                                  Payment By<span class="mandatory"></span></label>
                              <%--  <input type="text" data-bind="value:Contact1" class="form-control ActiveDt" id="txtCnt1"
                                    maxlength="50">--%>
                            </div>
                        </div>
                        <div class="col-md-4 col-xs-4 col-lg-4 col-sm-4">
                            <div class="form-group">
                           <select id="Select15" class="form-control ActiveDt" disabled="disabled" data-bind='options:PaymentLists, optionsText:"PaymentMode", value:SelPayments, optionsCaption:"--Select-- "'>
                                </select>
                            </div>
                            </div>
                             <div class="col-md-4 col-xs-4 col-lg-4 col-sm-4">
                            <div class="form-group">
                              <select id="Select16" class="form-control ActiveDt"  data-bind='options:NewPaymentLists, optionsText:"NewPaymentMode", value:NewSelPayments, optionsCaption:"--Select-- "' >
                                </select>
                            </div>
                            </div>
                     
                    </div>
                    <div class="row">
                        <div class="col-md-4 col-xs-4 col-lg-4 col-sm-4">
                            <div class="form-group">
                                 <label for="Username" style="font-weight: bold;">
                                    Model Of SIP <span class="mandatory"></span></label>
                              <%--  <input type="text" data-bind="value:Contact1" class="form-control ActiveDt" id="txtCnt1"
                                    maxlength="50">--%>
                            </div>
                        </div>
                        <div class="col-md-4 col-xs-4 col-lg-4 col-sm-4">
                            <div class="form-group">
                           <select id="Select17" class="form-control ActiveDt" disabled="disabled" data-bind='options:SipModel, value:SelectedModel, optionsCaption:"--- Select Model Of SIP ---"'>
                                </select>
                            </div>
                            </div>
                             <div class="col-md-4 col-xs-4 col-lg-4 col-sm-4">
                            <div class="form-group">
                               <select id="Select18" class="form-control ActiveDt" data-bind='options:NewSipModel, value:NewSelectedModel, optionsCaption:"--- Select New Model Of SIP ---", event{change:Getdate}' >
                                </select>
                            </div>
                            </div>
                     
                    </div>

                     <div class="row">
                     <div class="col-md-4 col-xs-4 col-lg-4 col-sm-4">
                     <div class="form-group">
                     <label for="Username" id="terms" style="font-weight: bold;">
                                    Terms<span class="mandatory"></span></label></div></div>
                        <div class="col-md-2 col-xs-2 col-lg-2 col-sm-2">
                            <div class="form-group">
                                <%--<label for="Username" id="Label1" style="font-weight: bold;">
                                    Terms<span class="mandatory">*</span></label>--%>
                                <input type="text"  id="txtnum" disabled="disabled" class="form-control ActiveDt" data-bind="value:termno, event{change:ClearTermType}" />
                            </div>
                        </div>
                        <div class="col-md-2 col-xs-2 col-lg-2 col-sm-2">
                            <div class="form-group">
                               <%-- <label for="Username" id="Label2" style="font-weight: bold;">
                                    <span class="mandatory">*</span></label>--%>
                                <select id="txttermtype" class="form-control ActiveDt" disabled="disabled" data-bind='options:TermTypes, optionsText:"TermTypeName", value:Selterm, optionsCaption:"--Select-- ", event{change:LoadLastDate}'>
                                </select>
                            </div>
                            </div>
                             <div class="col-md-2 col-xs-2 col-lg-2 col-sm-2">
                            <div class="form-group" >
                                <%--<label for="Username" id="Label3" style="font-weight: bold;">
                                    Terms<span class="mandatory">*</span></label>--%>
                                <input type="text" value="6" id="newterm" style="display:none"  class="form-control ActiveDt" data-bind="value:Newtermno, event{change:ClearTermType}" />
                            </div>
                        </div>
                        <div class="col-md-2 col-xs-2 col-lg-2 col-sm-2">
                            <div class="form-group" >
                               <%-- <label for="Username" id="Label4" style="font-weight: bold;">
                                    <span class="mandatory">*</span></label>--%>
                                <select id="newtxttermtype" style="display:none" class="form-control ActiveDt"  data-bind='options:NewTermTypes, optionsText:"NewTermTypeName", value:NewSelterm, optionsCaption:"--Select-- "'>
                                </select>
                            </div>
                        </div>
                       
                     
                    </div>
                    <div class="row">
                        <div class="col-md-4 col-xs-4 col-lg-4 col-sm-4">
                            <div class="form-group">
                                 <label for="Username" id="lstDt" style="font-weight: bold;">
                                  Last Date <span class="mandatory"></span></label>
                              <%--  <input type="text" data-bind="value:Contact1" class="form-control ActiveDt" id="txtCnt1"
                                    maxlength="50">--%>
                            </div>
                        </div>
                        <div class="col-md-4 col-xs-4 col-lg-4 col-sm-4">
                            <div class="form-group">
                            <input type="date" id="txtlstdt" class="form-control " disabled="disabled" data-bind="value:Last_Dt, valueUpdate: 'input'" />
                            </div>
                            </div>
                             <div class="col-md-4 col-xs-4 col-lg-4 col-sm-4">
                            <div class="form-group" >
                               <input type="date" id="newtxtlstdt" style="display:none" class="form-control " disabled="disabled" data-bind="value:NewLast_Dt, valueUpdate: 'input'" />
                            </div>
                            </div>
                     
                    </div>
                     <div class="row">
                        <div class="col-md-4 col-xs-4 col-lg-4 col-sm-4">
                            <div class="form-group">
                                 <label for="Username" style="font-weight: bold;">
                                  Standing Instruction Bank<span class="mandatory">*</span></label>
                              <%--  <input type="text" data-bind="value:Contact1" class="form-control ActiveDt" id="txtCnt1"
                                    maxlength="50">--%>
                            </div>
                        </div>
                        <div class="col-md-4 col-xs-4 col-lg-4 col-sm-4">
                            <div class="form-group">
                           <select id="Select21" class="form-control" disabled="disabled" data-bind='options:StandingBanks, optionsText:"bankname", value:SelStandingBanks, optionsCaption:"--- Select Bank ---"'>
                                </select>
                            </div>
                            </div>
                             <div class="col-md-4 col-xs-4 col-lg-4 col-sm-4">
                            <div class="form-group">
                            <select id="Select22" class="form-control" style="display:none" data-bind='options:NewStandingBanks, optionsText:"Newbankname", value:NewSelStandingBanks, optionsCaption:"--- Select Bank ---"'>
                                </select>
                            </div>
                            </div>
                     
                    </div>
                     <div class="row">
                        <div class="col-md-4 col-xs-4 col-lg-4 col-sm-4">
                            <div class="form-group">
                                 <label for="Username" style="font-weight: bold;">
                                  Standing Instruction Bank Account No <span class="mandatory"></span></label>
                              <%--  <input type="text" data-bind="value:Contact1" class="form-control ActiveDt" id="txtCnt1"
                                    maxlength="50">--%>
                            </div>
                        </div>
                        <div class="col-md-4 col-xs-4 col-lg-4 col-sm-4">
                            <div class="form-group">
                             <input type="text" data-bind="value:SI_BankAcc_no" disabled class="form-control ActiveDt"
                                    id="Text25" maxlength="50">
                            </div>
                            </div>
                             <div class="col-md-4 col-xs-4 col-lg-4 col-sm-4">
                            <div class="form-group">
                              <input type="text" data-bind="value:NewSI_BankAcc_no"  class="form-control ActiveDt" style="display:none"
                                    id="Text26" maxlength="50">
                            </div>
                            </div>
                     
                    </div>
                     <div class="row">
                        <div class="col-md-4 col-xs-4 col-lg-4 col-sm-4">
                            <div class="form-group">
                                 <label for="Username" style="font-weight: bold;">
                                    Bank Name <span class="mandatory">*</span></label>
                            </div>
                        </div>
                        <div class="col-md-4 col-xs-4 col-lg-4 col-sm-4">
                            <div class="form-group">
                          <select id="Select23" disabled class="form-control ActiveDt" data-bind='options:Banks, optionsText:"bankname", value:SelectedBank, optionsCaption:"--- Select Bank ---"'>
                                </select>
                            </div>
                            </div>
                             <div class="col-md-4 col-xs-4 col-lg-4 col-sm-4">
                            <div class="form-group">
                               <select id="Select24"  class="form-control ActiveDt" data-bind='options:NewBanks, optionsText:"Newbankname", value:NewSelectedBank, optionsCaption:"--- Select Bank ---"'>
                                </select>
                            </div>
                            </div>
                     
                    </div>
                     <div class="row">
                        <div class="col-md-4 col-xs-4 col-lg-4 col-sm-4">
                            <div class="form-group">
                                <label for="Username" style="font-weight: bold;">
                                    Account No<span class="mandatory"></span></label>
                            </div>
                        </div>
                        <div class="col-md-4 col-xs-4 col-lg-4 col-sm-4">
                            <div class="form-group">
                            <input type="text" data-bind="value:acc_no" disabled class="form-control ActiveDt"
                                    id="Text27" maxlength="50">
                            </div>
                            </div>
                             <div class="col-md-4 col-xs-4 col-lg-4 col-sm-4">
                            <div class="form-group">
                               <input type="text" data-bind="value:Newacc_no"  class="form-control ActiveDt"
                                    id="Text28" maxlength="50">
                            </div>
                            </div>
                     
                    </div>
               <!--ko if: Count() == 1 -->
                <div class="row">
                    <button title="Click To Cancel" data-bind="click:Cancel" class="btn btn-primary btn-md pull-right"
                        data-bind="click:" id="btnCancel">
                        Cancel
                    </button>
                     <button type="button" class="btn btn-primary btn-md pull-right" data-bind="click:SaveAmendment" id="btnProceed">
                        Proceed</button>
                </div>
               <!-- /ko -->

                <!--ko if: Count() > 1 -->
                  <!--ko if: IsApproved() == "N" -->
                      <div>
                        <p class="text-justify"  style="color :Red;">Your Request for SIP Ammendment has been sent. Please wait for approval.</p>
                        <%--<p class="text-justify" style="color :Red;">तपाईंको अनुरोध एनआइबिएल सहभागिता फण्ड रद्दको लागि पठाइएको छ। अनुमोदनको लागि प्रतीक्षा गर्नुहोस्। </p>--%>
                     </div>                    
            
                    <!-- /ko -->
                 <!-- /ko -->
            </div>
        </div>
    </div>
    </form>
        <script src="../../Scripts/SIPHandling/AmendmentRequest.js?v=0.1" type="text/javascript"></script>
</asp:Content>
