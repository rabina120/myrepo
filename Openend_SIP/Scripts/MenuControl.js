
var MenuControlViewModel = function () {
    var self = this;
    var username = $("#UserName").text(); // logged in user 
    var ccode = '1000' // Distribution center id
    var scheme_code = '001'; /// company id 
    var date = $("#date").text();
    var UserId = $('#UserId').text();
    var l_company_id = '001';
    var BOID = $('#BOID').text();
    var Name = $('#Name').text();
    var SHHOLDERNO = $('#SHHOLDERNO').text();
    GetDetail = function () {
        $.ajax({
            dataType: "json",
            url: '/Handler/Security/UserHandler.ashx',
            data: { 'method': 'GetDetail', 'scheme_code': scheme_code, 'Bo_Account_No': BOID, 'ShHolderNo': SHHOLDERNO },
            contentType: "application/json; charset=utf-8",
            async: false,
            success: function (data) {
            
                var sipcount = data.TCount;
                if (sipcount == 1) {
                    var html = "";
                    html += '<li>';
                    html += '<a href="/Modules/SIPHandling/SIP_Registration.aspx">';
                    html += '<i class="fa fa-angle-double-right">';
                    html += '</i>';
                    html += 'SIP REGISTRATION';
                    html += '</a>';
                    html += '</li>';
//                    html += '<li>';
//                    html += '<a href="/Modules/SIPHandling/SIPStatement.aspx">';
//                    html += '<i class="fa fa-angle-double-right">';
//                    html += '</i>';
//                    html += 'SIP STATEMENT';
//                    html += '</a>';
//                    html += '</li>';
                    html += '<li>';
                    html += '<a href="/Modules/SIPHandling/SIPPayment.aspx">';
                    html += '<i class="fa fa-angle-double-right">';
                    html += '</i>';
                    html += 'SIP PAYMENT';
                    html += '</a>';
                    html += '</li>';
//                    html += '<li>';
//                    html += '<a href="/Modules/SIPHandling/AmendmentRequest.aspx">';
//                    html += '<i class="fa fa-angle-double-right">';
//                    html += '</i>';
//                    html += 'SIP AMMENDEMENT';
//                    html += '</a>';
//                    html += '</li>';
//                    html += '<li>';
//                    html += '<a href="/Modules/SIPHandling/SIPRegistrationCancellation.aspx">';
//                    html += '<i class="fa fa-angle-double-right">';
//                    html += '</i>';
//                    html += 'SIP CANCELLATION';
//                    html += '</a>';
//                    html += '</li>';
                    $("#SIP").html(html);
                }
                if (sipcount == 0) {
                    var html = "";
                    html += '<li>';
                    html += '<a href="/Modules/SIPHandling/SIP_Registration.aspx">';
                    html += '<i class="fa fa-angle-double-right">';
                    html += '</i>';
                    html += 'SIP REGISTRATION';
                    html += '</a>';
                    html += '</li>';
                 
                    $("#SIP").html(html);
                }

            },
            error: function (err) {

                msg(err.status + " - " + err.statusText, "FAILURE");
            }
        });

    }
    GetDetail();


}


$(document).ready(function () {
    ValidateSession();
    ko.applyBindings(new MenuControlViewModel());
});