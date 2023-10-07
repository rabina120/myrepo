<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="SIPRegistrationCancellation.aspx.cs" Inherits="Openend_SIP.Modules.SIPHandling.SIPRegistrationCancellation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<title>SIP Registration Cancellation |  </title>
  <link rel="icon" href="/Styles/Images/apple-icon-57x57.png" type="image/gif" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <form id ="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:HiddenField ID="forgeryToken" runat="server"/>
   <div id="Container" style="font-family: -webkit-body;">
        <div class="card">
            <div class="card-header">
                <h3 align="center" style="font-weight: bold;">
                    SIP CANCELLATION REGISTRATION FORM
                </h3>
                <h3 align="center" style="font-weight: bold; font-size: 18px;">
                  
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
                                    <td data-bind="text:Sip_amt">
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        SIP Start Date<label class="nepalistyle">
                                        </label>
                                        [ सुरुवात मिति ]
                                    </th>
                                    <td data-bind="text:SIP_DT">
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        Terms<label class="nepalistyle">
                                            [ अवधि तोकिएको ]</label>
                                    </th>
                                    <td data-bind="text:Terms">
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        Model Of SIP<label class="nepalistyle">
                                            [ योजनाको किसिम ]</label>
                                    </th>
                                    <td data-bind="text:SelectedModel">
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
                                    <td data-bind="text:Name">
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        SIP Interval
                                        <label class="nepalistyle">
                                            [ अन्तराल ]</label>
                                    </th>
                                    <td data-bind="text:selint">
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        SIP Active Date
                                        <label class="nepalistyle">
                                            [ प्रभावकारी मिति ]</label>
                                    </th>
                                    <td data-bind="text:Effective_Dt">
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        SIP Last_Date<label class="nepalistyle">
                                            [ अन्तिम मिति ]</label>
                                    </th>
                                    <td data-bind="text:Last_Dt">
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                 </div>
            <!--ko if: Count() == 0 -->
               <div class="row">
                        <div class="col-md-12 col-xs-12 col-lg-12 col-sm-12" style="padding-left: 23px; color: red;">
                            <div class="form-group">
                                <label for="Username" style="font-weight: bold;">
                                    DO YOU WANT TO CANCEL SIP REGISTRATION ?</label>
                                <input type="checkbox" id="cancelsipreg" class="ActiveDt"  data-bind='"checked:cancelsip", event{change:CheckcancelSip}' />
                            </div>
                        </div>
                        <div style="padding-left: 23px;" >
                            <h5>
                             <u><b>Declaration [ घोषणा ]:</b></u>
                            </h5>
                            <p class="text-justify">
                                <span><i class="fa fa-fw fa-star"></i> I/we would like to cancel the SIP registration of NIBL
                                Sahabhagita Fund and kindly request you to unlock the units which have been purchased through SIP; </span> 
                                <span class="nepalistyle"></span>
                            </p>
                         </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4padding-left-15 margin-top-15 pull-right">
                            <button data-bind="click:CancleSIPRegistration" disabled=disabled  title="Click To Cancle" value="Submit"
                                class="btn btn-primary btn-md " id="btnSumbit">
                                Save
                            </button>
                            <button title="Click To Cancel" class="btn btn-primary btn-md " data-bind="click:Cancel"
                                id="Button2">
                                Cancel
                            </button>
                        </div>
                    </div>
                    <!-- /ko -->
                    <!--ko if: Count() > 0 -->
                    <!--ko if: IsApproved() == "N" -->
                    <div style="padding-left: 7px;">
                        <p class="text-justify" style="color: Red;">
                            Your Request for Cancellation of SIP has been sent. Please wait for approval.</p>
                        <p class="text-justify" style="color: Red;">
                            तपाईंको अनुरोध एनआइबिएल सहभागिता फण्ड रद्दको लागि पठाइएको छ। अनुमोदनको लागि प्रतीक्षा
                            गर्नुहोस्।
                        </p>
                    </div>
                    <!-- /ko -->
                <!-- /ko -->
            </div>
        </div>
   </div>
   </form>
   
    <script src="../../Scripts/SIPHandling/SIP_RegistrationCancellation.js?v=0.1" type="text/javascript"></script>
</asp:Content>
