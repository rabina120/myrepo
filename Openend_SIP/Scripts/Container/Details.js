
var DetailViewModel = function () {
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
    self.DP_NAME = ko.observable();
    self.Name = ko.observable();
    self.Bo_Account_No = ko.observable();
    self.ActiveStatus = ko.observable();
    self.Gender = ko.observable();
    self.DOB = ko.observable();
    self.CreatedDate = ko.observable();
    self.Contact_No = ko.observable();
    self.Email = ko.observable();
    self.bankname = ko.observable();
    self.Bank_Account_No = ko.observable();
    self.Citizenship_No = ko.observable();
    self.PAN_No = ko.observable();
    $.ajax({
        dataType: "json",
        url: '/Handler/Security/UserHandler.ashx',
        data: { 'method': 'GetWebHolderDetail', 'scheme_code': scheme_code, 'Bo_Account_No': BOID, 'UserName': username, 'ShHolderNo': SHHOLDERNO },
        contentType: "application/json; charset=utf-8",
        async: false,
        success: function (data) {
            
          
            var web = data.ResponseData[0];
            self.Name(web.Name);
            self.DP_NAME(web.DP_NAME);
            self.ActiveStatus(web.ActiveStatus);
            self.Gender(web.Gender);
            self.DOB(web.DOB);
            self.Citizenship_No(web.Citizenship_No);
            self.PAN_No(web.PAN_No);
            self.CreatedDate(web.CreatedDate);
            self.CreatedDate(web.CreatedDate);
            self.bankname(web.bankname);
            self.Bank_Account_No(web.Bank_Account_No);
            self.Contact_No($("#Contact_No").text());
            self.DOB(web.DOB);
            self.Bo_Account_No(web.BOID);
            self.Email(web.Email);


        },
        error: function (err) {

            msg(err.status + " - " + err.statusText, "FAILURE");
        }
    });



}
$(document).ready(function () {
    ValidateSession();
    ko.applyBindings(new DetailViewModel());


});