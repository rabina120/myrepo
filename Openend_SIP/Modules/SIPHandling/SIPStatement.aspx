<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="SIPStatement.aspx.cs" Inherits="Openend_SIP.Modules.SIPHandling.SIPStatement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<title>SIP Statement|  </title>
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
                    SIP STATEMENT</h3>
            </div>
            <br />
            <br />
            <div class="col-md-6 col-xs-12 col-lg-6 col-sm-12 mt-3" style="margin-top: 3%;">
                <div class="row" style="clear: both">
                    <div class="table-responsive">
                        <table class="table">
                            <tr>
                                <th>
                                     BOID No.
                                    <label class="nepalistyle">
                                        [ हितग्राही खाता ]</label>
                                </th>
                                <td data-bind="text:boid">
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
            <div class="col-md-6 col-xs-12 col-lg-6 col-sm-12" style="margin-top: 3%;">
                <div class="row" style="clear: both">
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
                        </table>
                    </div>
                </div>
            </div>
            <div class="col-md-6 col-xs-5 col-lg-4 col-sm-12 mt-3" style="margin-right: 2%">
                <div class="row" style="clear: both">
                    <div class="">
                        <label style="font: bold; margin-left: 2%;">
                            Start Date
                            <label class="nepalistyle">
                                [ सुरू मिति ]</label>
                        </label>
                    </div>
                </div>
            </div>
            <div class="col-md-4 col-xs-5 col-lg-5 col-sm-12" style="margin-top: ">
                <div class="row">
                    <div class="input-group date" data-provider="datepicker" style="width: ">
                        <input type="date" placeholder="Start Date" id="datepicker1" class="form-control">
                        <span class="glyphicon glyphicon-calendar input-group-addon"></span>
                    </div>
                    <%--<input id="datepicker1" data-provide="datepicker" data-bind="value:date1, valueUpdate: 'input'"
                            width="270" />--%>
                </div>
            </div>
            <div class="col-md-6 col-xs-5 col-lg-4 col-sm-12 mt-3" style="margin-right: 2%;margin-top:2.6%">
                <div class="row" style="clear: both">
                    <div class="">
                        <label style="font: bold; margin-left: 2%;">
                            End Date
                            <label class="nepalistyle">
                                [ अन्त्य मिति ]
                            </label>
                    </div>
                </div>
            </div>
            <div class="col-md-4 col-xs-5 col-lg-5 col-sm-12" style="margin-top:2% ">
                <div class="row" >
                    <div class="input-group date" data-provider="datepicker" style="width: %;">
                        <input type="date" placeholder="End Date" id="datepicker2" class="form-control">
                        <span class="glyphicon glyphicon-calendar input-group-addon"></span>
                    </div>
                </div>
            </div>
            <div class="col-lg-12 text-left ">
                <div class="row" style="clear: both">
                </div>
            </div>
            <div class="col-md-4 col-xs-3 col-lg-4 col-sm-12" style="margin-top: 2%">
                <div class="row" style="clear: both">
                    <button type="button" data-bind="click:Search" class="btn btn-primary">
                        PDF</button>
                </div>
            </div>
            <div class="col-lg-12 margin-top-15 margin-top-0 text-left " style="display: none">
                <div class="row" style="clear: both">
                    <div class="table-responsive">
                        <table id="tblUsers" data-bind="visible: true" border="0" class="table table-striped mt32 customers-list">
                            <thead style="background-color: #1fd12a;">
                                <tr>
                                    <th>
                                        S.No
                                    </th>
                                    <th>
                                        Trans NO.
                                    </th>
                                    <th>
                                        Installment Date
                                    </th>
                                    <th>
                                        Debit
                                    </th>
                                    <th>
                                        Credit
                                    </th>
                                </tr>
                            </thead>
                            <tbody id="tblBody" data-bind="foreach:UserCenters">
                                <tr>
                                    <td>
                                        <span data-bind="text:($index() + 1)"></span>
                                    </td>
                                    <td>
                                        <span data-bind="text:trans_no"></span>
                                    </td>
                                    <td>
                                        <span data-bind="text:installmentDate "></span>
                                    </td>
                                    <td>
                                        <span data-bind="text:Amount_dr "></span>
                                    </td>
                                    <td>
                                        <span data-bind="text: Amount_cr"></span>
                                    </td>
                                    <%-- <td data-bind=" click:$root.PrintPurchasenEntry">--%>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
            <div class="col-md-4 col-xs-3 col-lg-4 col-sm-12  print" style="display: none">
                <div class="row" style="clear: both">
                    <button type="button" data-bind="click:PrintHolderDetails" class="btn btn-danger">
                        PDF</button>
                </div>
            </div>
        </div>
    </div>
    </form>
   <%-- <div class="modal fade" id="PaymentType" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle"
            aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered" role="document">
                <div class="modal-content">
                    <div class="modal-header" style="background-color: #0a336f;">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span></button>
                       <h4 class="modal-title" id="H1" style="padding-top: 15px;color: white;">
                        PROCEED PAYMENT BY</h4>
                    </div>
                    <div class="modal-body">
                        <div class="col-md-12">
                            <table>
                    <tbody>
                    <tr>
                        <td><img src="../../Styles/Images/Connectips.jpg" style="  height: 77px;" data-bind="click:ProceedToPayment"></td>
                        <td><a target="_blank" ><img src="../../Styles/Images/niblebanking.jpg" style="height: 77px;"  data-bind="click:openpage"/></a></td>
                        <td><img src="../../Styles/Images/thaili.jpg" style=" height: 63px;"  data-bind="click:openpage"></td>
                    </tr>
                    </tbody>
                </table>
                            
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button title="Click To Cancel" data-dismiss="modal"  value="Cancel"
                                    class="btn btn-primary btn-md " id="Button1">
                                    Close
                                </button>
                        
                </div>
            </div>
        </div>
        </div>
        --%>

    <script src="../../Scripts/SIPHandling/SIPStatement.js?v=0.1" type="text/javascript"></script>
    <script type="text/javascript"> </script>
</asp:Content>
