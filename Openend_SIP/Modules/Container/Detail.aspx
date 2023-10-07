<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="Detail.aspx.cs" Inherits="Openend_SIP.Modules.Container.Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <form id ="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:HiddenField ID="forgeryToken" runat="server"/>
    <div class="col-12">
        <div class="card">
            <div class="card-header">
                <h3 align="center" style="font-weight: bold;">
                    MY DETAILS
                </h3>
                <div class="heading-elements">
                    <ul class="list-inline mb-0">
                        <li><a data-action="collapse"><i class="ft-minus"></i></a></li>
                        <li><a data-action="reload"><i class="ft-rotate-cw"></i></a></li>
                        <li><a data-action="expand"><i class="ft-maximize"></i></a></li>
                        <li><a data-action="close"><i class="ft-x"></i></a></li>
                    </ul>
                </div>
            </div>
            <div class="card-content collapse show">
                <div class="card-body card-dashboard">
                </div>
                <div class="table-responsive">
                    <table class="table">
                        <tr>
                            <th>
                                DP Name
                            </th>
                            <td data-bind="text:DP_NAME">
                            </td>
                        </tr>
                        <tr>
                            <th>
                                BOID No.
                            </th>
                            <td data-bind="text:Bo_Account_No">
                            </td>
                        </tr>
                        <tr>
                            <th>
                                Name
                            </th>
                            <td data-bind="text:Name">
                            </td>
                        </tr>
                        <tr>
                            <th>
                                Account Status
                            </th>
                            <td data-bind="text:ActiveStatus">
                            </td>
                        </tr>
                        <%--<tr>
                        <th>Gender</th>
                        <td data-bind="text:Gender"></td>
                      </tr>
                        --%>
                        <tr>
                            <th>
                                Date Of Birth
                            </th>
                            <td data-bind="text:DOB">
                            </td>
                        </tr>
                        <tr>
                            <th>
                                Citizenship Number
                            </th>
                            <td data-bind="text:Citizenship_No">
                            </td>
                        </tr>
                       <%-- <tr>
                            <th>
                                PAN Number
                            </th>
                            <td data-bind="text:PAN_No">
                            </td>
                        </tr>--%>
                        <tr>
                            <th>
                                Account Open Date
                            </th>
                            <td data-bind="text:CreatedDate">
                            </td>
                        </tr>
                        <tr>
                            <th>
                                Contact Number
                            </th>
                            <td data-bind="text:Contact_No">
                            </td>
                        </tr>
                        <tr>
                            <th>
                                Email
                            </th>
                            <td data-bind="text:Email">
                            </td>
                        </tr>
                        <tr>
                            <th>
                                Bank Name
                            </th>
                            <td data-bind="text:bankname">
                            </td>
                        </tr>
                        <tr>
                            <th>
                                Account Number
                            </th>
                            <td data-bind="text:Bank_Account_No">
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>
      </form>
    <script src="../../Scripts/Container/Details.js?v=0.1" type="text/javascript"></script>
</asp:Content>
