function SHolderTransaction(data) {
    var self = this;
    if (data != undefined) {
        self.REQUEST_NO = ko.observable(data.REQUEST_NO);
        self.ShHolderNo = ko.observable(data.ShHolderNo);
        self.Bo_Account_No = ko.observable(data.Bo_Account_No);
        self.FName = ko.observable(data.FName);
        self.LName = ko.observable(data.LName);
        self.FaName = ko.observable(data.FaName);
        self.GFName = ko.observable(data.GFName);
        self.Name = ko.observable(data.FName + '' + data.LName);
        self.address = ko.observable(data.address);
        self.TELNO = ko.observable(data.TELNO);
        self.BankCode = ko.observable(data.BankCode);
        self.Bank_Account_No = ko.observable(data.Bank_Account_No);
        self.PAN_No = ko.observable(data.PAN_No);
        self.Citizenship_No = ko.observable(data.Citizenship_No);
        self.is_institution = ko.observable(data.is_institution);
        self.APPLY_UNIT = ko.observable(data.APPLY_UNIT);
        self.APPLY_DT = ko.observable(data.APPLY_DT);
        self.AMOUNT = ko.observable(data.AMOUNT);
        self.cashorcheque = ko.observable(data.cashorcheque);
        self.bcode_cheque = ko.observable(data.bcode_cheque);
        self.CHK_NO = ko.observable(data.CHK_NO);
        self.APPROVED = ko.observable(data.APPROVED);
        self.APPSTATUS = ko.observable(data.APPSTATUS);
        self.APP_DATE = ko.observable(data.APP_DATE);
        self.proceed_batch = ko.observable(data.proceed_batch);
        self.appno = ko.observable(data.appno);
        self.remarks = ko.observable(data.remarks);
        self.current_nav = ko.observable(data.current_nav);
        self.nav_date = ko.observable(data.nav_date);
        self.charge_amount = ko.observable(data.charge_amount);
        self.CashAmount = ko.observable(data.CashAmount);
        self.ChequeAmount = ko.observable(data.ChequeAmount);
        self.other_charges = ko.observable(data.other_charges);
        self.SCharge_Code = ko.observable(data.SCharge_Code);
        self.SEBON_Fee = ko.observable(data.SEBON_Fee);
        
    }
}
var PurchaseStatementViewModel = function () {
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


     function downloadURI(uri, name) {
    var link = document.createElement("a");
    link.download = name;
    link.href = uri;
    link.click();
    }

    self.PrintPurchasenEntry = function (data) {
        data.cname = "Online Client"
        $.ajax({
            dataType: "json",
            url: '/Handler/RequestHandling/CreatePurchasePdf.ashx',
            data: { 'method': 'CreatePurchasePdfReceipt', 'args': ko.toJSON(data) },
            contentType: "application/json; charset=utf-8",
            async: false,
            success: function (data) {
              
                var obj = JSON.parse(JSON.stringify(data));
                 var objFra ='/Reports/' + obj.ResponseData;
               // var objFra = window.open('/Reports' + obj.ResponseData, '_blank');
                downloadURI(objFra, 'Unit Purchase Statement');
                 deleteFile(objFra);


            },
            error: function (err) {
             

                alert("Woops something went wrong !");
            }
        });
    }


     self.GetHolderUnitRpt = function () {
       
        $('#tblUsers').DataTable().destroy();
        $('#tblUsers tbody').empty();
    
        $.ajax({
            dataType: "json",
            url: '/Handler/RequestHandling/PurchaseRequesthandler.ashx',
            data: { 'method': 'GetHolderUnitRpt', 'scheme_code': scheme_code, 'Bo_Account_No': BOID, 'ccode': ccode, 'l_company_id': l_company_id, 'startdate': self.date1(), 'enddate': self.date2() },
            contentType: "application/json; charset=utf-8",
            async: false,
            success: function (data) {
              

                var mappedTasks = $.map(data.ResponseData, function (item) {
                    return new SHolderTransaction(item)

                });

                self.UserCenters(mappedTasks);
                $('#tblUsers').DataTable({ 
                     responsive: true,
                                 searching: true ,
                                  dom: 'Bfrtip',
                                 buttons: [ {
                                    extend: 'excel',
                                   
                                    exclude: ".Preview",
                                   
                                    customize: function ( xlsx ) {
                                        var sheet = xlsx.xl.worksheets['sheet1.xml'];
                                        $('c[r=A1] t', sheet).text( "Date From : "+ko.toJS(self.date1())+" To : "+ko.toJS(self.date2()) );
                                    
                                        $('row:first c', sheet).attr( 's', '2' ); // first row is bold
                                        $('c[r=A2]', sheet).attr('s', '2');
                                    },
                                    
                                     filename: function(){
                                        var dateObj = new Date();
                                        var month = dateObj.getUTCMonth() + 1; //months from 1-12
                                        var day = dateObj.getUTCDate();
                                        var year = dateObj.getUTCFullYear();
                                        newdate = year + "/" + month + "/" + day;
                                        return 'Unit Purchase_' + newdate;
                                    },
                                    exportOptions: {
                                        orthogonal: 'sort',
                                        columns: [ 0, 1, 2, 3, 4, 5]
                                    },
                                    customizeData: function ( data ) {
                                        for (var i=0; i<data.body.length; i++){
                                            for (var j=0; j<data.body[i].length; j++ ){
                                                data.body[i][j] = '\u200C' + data.body[i][j];
                                            }
                                        }
                                    },    
                                    text: 'Export To Excel',

                                   
                                 }]
                });


                if (self.UserCenters().length == 0) {
                    msg("No Record Found", "ALERT");
                }


            },
            error: function (err) {
              
                msg(err.status + " - " + err.statusText, "FAILURE");
            }
        });

    }



    self.Search = function () {
        self.date1($('#datepicker1').val())
        self.date2($('#datepicker2').val())
      
        if (self.validate()) {
            self.GetHolderUnitRpt()
        }
    }

    self.validate = function () {
        var errMsg = "";
        var objFocus = null;
        //#region Validating required fields

        if (Validate.empty(self.date1())) {
            errMsg += "Please Enter Date1 !!!<br>";
        }
        if (Validate.empty(self.date2())) {
            errMsg += "Please Enter Date2!!!<br>";
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

//    self.GetHolderUnitRpt = function () {
//       
//        $('#tblUsers').DataTable().destroy();
//        $('#tblUsers tbody').empty();
//    
//        $.ajax({
//            dataType: "json",
//            url: '/Handler/RequestHandling/PurchaseRequesthandler.ashx',
//            data: { 'method': 'GetHolderUnitRpt', 'scheme_code': scheme_code, 'Bo_Account_No': BOID, 'ccode': ccode, 'l_company_id': l_company_id, 'startdate': self.date1(), 'enddate': self.date2() },
//            contentType: "application/json; charset=utf-8",
//            async: false,
//            success: function (data) {
//              

//                var mappedTasks = $.map(data.ResponseData, function (item) {
//                    return new SHolderTransaction(item)

//                });

//                self.UserCenters(mappedTasks);
//                $('#tblUsers').DataTable({ 
//                     responsive: true,
//                                 searching: true ,
//                                  dom: 'Bfrtip',
//                                 buttons: [ {
//                                    extend: 'excel',
//                                   
//                                    exclude: ".Preview",
//                                   
//                                    customize: function ( xlsx ) {
//                                        var sheet = xlsx.xl.worksheets['sheet1.xml'];
//                                        $('c[r=A1] t', sheet).text( "Date From : "+ko.toJS(self.date1())+" To : "+ko.toJS(self.date2()) );
//                                    
//                                        $('row:first c', sheet).attr( 's', '2' ); // first row is bold
//                                        $('c[r=A2]', sheet).attr('s', '2');
//                                    },
//                                    
//                                     filename: function(){
//                                        var dateObj = new Date();
//                                        var month = dateObj.getUTCMonth() + 1; //months from 1-12
//                                        var day = dateObj.getUTCDate();
//                                        var year = dateObj.getUTCFullYear();
//                                        newdate = year + "/" + month + "/" + day;
//                                        return 'Unit Purchase_' + newdate;
//                                    },
//                                    exportOptions: {
//                                        orthogonal: 'sort',
//                                        columns: [ 0, 1, 2, 3, 4, 5]
//                                    },
//                                    customizeData: function ( data ) {
//                                        for (var i=0; i<data.body.length; i++){
//                                            for (var j=0; j<data.body[i].length; j++ ){
//                                                data.body[i][j] = '\u200C' + data.body[i][j];
//                                            }
//                                        }
//                                    },    
//                                    text: 'Export To Excel',

//                                   
//                                 }]
//                });


//                if (self.UserCenters().length == 0) {
//                    msg("No Record Found", "ALERT");
//                }


//            },
//            error: function (err) {
//              
//                msg(err.status + " - " + err.statusText, "FAILURE");
//            }
//        });

//    }





}
$(document).ready(function () {
    ValidateSession();


    ko.applyBindings(new PurchaseStatementViewModel());


});
