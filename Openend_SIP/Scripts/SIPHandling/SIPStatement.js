
function SHolderDetails(data) {
    var self = this;
    if (data != undefined) {
        self.scheme_code = ko.observable(data.scheme_code)
        self.ccode = ko.observable(data.ccode)
        self.cname = ko.observable(data.cname)
        self.SIP_Reg_No = ko.observable(data.SIP_Reg_No);
        self.Name = ko.observable(data.Name);
        self.Amount_cr = ko.observable(data.Amount_cr);
        self.Amount_dr = ko.observable(data.Amount_dr);
        self.BOID = ko.observable(data.BOID);
        self.installmentDate = ko.observable(data.installmentDate);
        self.dueDate = ko.observable(data.dueDate);
        self.appnav = ko.observable(data.appnav);
        self.unit = ko.observable(data.unit);
        self.actionDate = ko.observable(data.actionDate)
        self.payment = ko.observable(data.payment)
        self.dp = ko.observable(data.dp)
        self.otherCharges = ko.observable(data.otherCharges)
        self.sebon_fee = ko.observable(data.sebon_fee)
        self.payment = ko.observable(data.payment)
        self.trans_no = ko.observable(data.trans_no)
    }
}





var SIPStatementViewModel = function () {
    var self = this;
    var username = $("#username").text(); // logged in user 
    var ccode = '1000' // Distribution center id
    var scheme_code = '001'; /// company id 
    var date = $("#date").text();
    var UserId = $('#UserId').text();
    var l_company_id = '001';
    var BOID = $('#BOID').text();
    var Name = $('#Name').text();

    self.date1 = ko.observable();
    self.date2 = ko.observable();

    self.boid = ko.observable(BOID);
    self.Bo_Account_No = ko.observable();
    self.REQUEST_NO = ko.observable();
    self.ShHolderNo = ko.observable();
    self.Name = ko.observable(Name);
    self.FName = ko.observable();
    self.LName = ko.observable();
    self.MName = ko.observable();
    self.P_Mobile_no = ko.observable();
    self.P_TelNo = ko.observable();
    self.APPLY_UNIT = ko.observable();
    self.APPLY_DT = ko.observable();
    self.AMOUNT = ko.observable();
    self.P_Tel_No = ko.observable();
    self.APPSTATUS = ko.observable();
    self.UserCenters = ko.observableArray([]);

    self.trans_no = ko.observable();
    self.actionDate = ko.observable();
    self.payment = ko.observable();
    self.dp = ko.observable()
    self.BOID = ko.observable();
    self.Name = ko.observable(Name);
    self.Amount_cr = ko.observable();
    self.Amount_dr = ko.observable();
    self.installmentDate = ko.observable();
    self.SIP_Reg_No = ko.observable();
    self.dueDate = ko.observable();
    self.appnav = ko.observable();
    self.unit = ko.observable();
    self.otherCharges = ko.observable()
    self.HolderDetails = ko.observableArray([]);


    var today = new Date();
    var dd = String(today.getDate()).padStart(2, '0');
    var mm = String(today.getMonth() + 1).padStart(2, '0'); //January is 0!
    var yyyy = today.getFullYear();

    today = yyyy + '-' + mm + '-' + dd;

    self.Search = function () {
        self.date1($('#datepicker1').val())
        self.date2($('#datepicker2').val())
        if (self.validate()) {
            if (self.date2() > today || self.date1() > today) {
                msg("You Cannt Choose Future Date","ALERT")
            } else {
            
                    self.GetHolderStatement();
                }
        }
    }


    self.validate = function () {
        var errMsg = "";
        var objFocus = null;
        //#region Validating required fields

        if (Validate.empty(self.date1())) {
            errMsg += "Please Enter Start Date !!!<br>";
        }
        if (Validate.empty(self.date2())) {
            errMsg += "Please Enter End Date !!!<br>";
        }
        //#endregion
        if (errMsg !== "") {

            msg(errMsg, "ALERT");

            return false;
        }
        else {
            return true;
        }
    }


    self.GetHolderStatement = function () {
    
        $.ajax({
            dataType: "json",
            url: '/Handler/SIPHandling/HolderStatement.ashx',
            data: { 'method': 'GetHolderStatement', 'scheme_code': scheme_code, 'Bo_Account_No': BOID, 'ccode': ccode, 'l_company_id': l_company_id, 'startdate': self.date1(), 'enddate': self.date2() },
            contentType: "application/json; charset=utf-8",
            async: false,
            success: function (data) {


                var mappedTasks = $.map(data.ResponseData, function (item) {
                    return new SHolderDetails(item)

                });

                self.UserCenters(mappedTasks);
                if (self.UserCenters().length == 0) {
                    msg("No Record Found", "ALERT");
                } else {
                    // $('.print').css('display', 'block');
                    self.PrintHolderDetails()
                }


            },
            error: function (err) {
             
                msg(err.status + " - " + err.statusText, "FAILURE");
            }
        });

    }

    self.PrintHolderDetails = function () {


        var holders = ko.toJSON(self.UserCenters())
        $.ajax({
            url: '/Handler/SIPHandling/CreateHolderStatement.ashx',
            type: 'POST',
            dataType: 'json',
            data: { 'method': 'CreateHolderStatementPdf', 'Name':Name,'BOID':BOID,'holders': holders, 'startdate': self.date1(), 'enddate': self.date2() },
            success: function (data) {

                var obj = data;
                var objFra = window.open('/Reports/HolderStatement/' + obj.ResponseData, '_blank');

                // self.DeleteFile(obj.ResponseData);

            },
            error: function (errorText) {
                alert("Wwoops something went wrong !");
            }
        });

    }


}



$(document).ready(function () {
    ValidateSession();

   ko.applyBindings(new SIPStatementViewModel());


});
