<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="UnitPurchaseStatement.aspx.cs" Inherits="Openend_SIP.Modules.RequestHandling.UnitPurchaseStatement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="Container" style="font-family: -webkit-body;">
        <style>
            .mandatory
            {
                color: red;
            }
            
            
            
            
        </style>
        <%-- <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.6.4/js/bootstrap-datepicker.js"></script>
        --%>
        <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.6.4/css/bootstrap-datepicker.css">
        </link>
        <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.0.13/css/all.css"
            integrity="sha384-DNOHZ68U8hZfKXOrtjWvjxusGo9WQnrNx2sqG0tfsghAvtVlRW3tvkXWZh58N9jp"
            crossorigin="anonymous">
        <div class="card">
            <div class="card-header">
                <h3 align="center" style="font-weight: bold;">
                    UNIT PURCHASE STATEMENT</h3>
            </div>
            <br />
            <br />
            <div class="card-body">
                <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12">
                    <div class="row" style="margin-right: 5%;margin-top:4% ;clear: both; width: ">
                        <div class="input-group date" data-provide="datepicker">
                            <input type="date" placeholder="Start Date" id="datepicker1" class="form-control"
                                width="270">
                            <span class="glyphicon glyphicon-calendar input-group-addon" ></span>
                        </div>
                        <%--<input id="datepicker1" data-provide="datepicker" data-bind="value:date1, valueUpdate: 'input'"
                            width="270" />--%>
                    </div>
                </div>
                <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12 ">
                    <div class="row" style="margin-right: 5%;margin-top:4%; clear: both;">
                        <div class="input-group date" data-provide="datepicker">
                            <input type="date" placeholder="End Date" id="datepicker2" class="form-control">
                            <span class="glyphicon glyphicon-calendar input-group-addon" ></span>
                        </div>
                        <%--<input id="" data-bind="value:date2" width="270" />--%>
                    </div>
                </div>
                <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12 pull-right">
                    <div class="row" style="clear: both; margin-top: 4%">
                        <button type="button" data-bind="click:Search" class="btn btn-primary">
                            Search</button>
                    </div>
                </div>
                <div class="col-lg-12 text-left ">
                    <div class="row" style="clear: both">
                    </div>
                </div>
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
                <div class="col-lg-12 margin-top-15 margin-top-0 text-left mt-1">
                    <div class="row" style="clear: both">
                        <div class="table-responsive">
                            <table id="tblUsers" data-bind="visible: true" border="0" class="table table-striped mt32 customers-list">
                                <thead style="background-color: #3c8dbc;">
                                    <tr>
                                        <th>
                                            S.No
                                        </th>
                                        <th>
                                            TRANS NO.
                                        </th>
                                        <th>
                                            Qty. (in Units)
                                        </th>
                                        <th>
                                            AMOUNT
                                        </th>
                                        <th>
                                            APPLY DATE
                                        </th>
                                        <th>
                                            STATUS
                                        </th>
                                        <th class="Preview">
                                            ACTION
                                        </th>
                                    </tr>
                                </thead>
                                <tbody id="tblBody" data-bind="foreach:UserCenters">
                                    <tr>
                                        <td data-bind="text:($index() + 1)">
                                        </td>
                                        <td data-bind="text:REQUEST_NO">
                                        </td>
                                        <td data-bind="text:APPLY_UNIT ">
                                        </td>
                                        <td data-bind="text:AMOUNT ">
                                        </td>
                                        <td data-bind="text:APPLY_DT ">
                                        </td>
                                        <td data-bind="text:APPSTATUS ">
                                        </td>
                                        <td class="Preview">
                                            <img src="../../Styles/Images/pdf.png" data-bind="click:$root.PrintPurchasenEntry" />
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
                </div>
            </div>
        </div>
    </div>
    <script src="../../Scripts/RequestHandling/UnitPurchaseStatement.js" type="text/javascript"></script>
</asp:Content>
