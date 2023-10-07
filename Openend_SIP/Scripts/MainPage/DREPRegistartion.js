
function DPCharge(data) {
    var self = this;
    if (data != undefined) {
        self.Depo = ko.observable(data.Depo);
        self.DPName = ko.observable(data.DPName);
        self.DP_Id_Cds = ko.observable(data.DP_Id_Cds);


    }
}


function ParaComp(data) {
    var self = this;
    if (data != undefined) {
        self.scheme_code = ko.observable(data.scheme_code);
        self.SchemeEnName = ko.observable(data.SchemeEnName);
        self.PerShVal = ko.observable(data.PerShVal);
        self.MaxKitta = ko.observable(data.MaxKitta);
        self.minkitta = ko.observable(data.Minkitta);

    }
}

var DREPREGViewModel = function () {
    var self = this;
    //DP
    self.Depo = ko.observable();
    self.DPName = ko.observable();
    self.SelectedDp = ko.observable();
    self.DP_Id_Cds = ko.observable();
    self.Boid_No = ko.observable();

    //Scheme
    self.scheme_code = ko.observable();
    self.SchemeEnName = ko.observable();
    self.SelectedScheme = ko.observable();
    self.Schemes = ko.observableArray();
    self.minkitta = ko.observable();
    self.MaxKitta = ko.observable();

    self.Name = ko.observable();
    self.Email = ko.observable();
    self.OTPPass = ko.observable();
    self.OTP = ko.observable();
    self.P_Tel_No = ko.observable();
    self.P_Mobile_no = ko.observable();
    self.DOB = ko.observable();
    self.CitizenshipNo = ko.observable();
    self.Bo_Account_No = ko.observable();
    self.HasDividend = ko.observable();
    self.IsPosted = ko.observable();
    self.ShHolderNo = ko.observable();
    self.VerifyOtp = ko.observable(false);
    
    var username = $("#username").text(); // logged in user 
    var ccode = '1000' // Distribution center id
    var scheme_code = '001'; /// company id 
    var date = $("#date").text();
    var UserId = $('#UserId').text();
    var l_company_id = '001';

    $("#dp").select2();
    self.LoadDp = function () {

        var url = "/Handler/RequestHandling/PurchaseRequestHandler.ashx";
        var data = { 'method': 'GetDPInfo' };
        $.post(url, data,
        function (result) {
            waitMsg.hide();
            var obj = jQuery.parseJSON(result);
            var mappedTasks = $.map(obj.ResponseData, function (item) {
                return new DPCharge(item)
            });

            self.Depo(mappedTasks);

        });
    }
    self.LoadDp();

    self.LoadScheme = function () {
        $.ajax({
            dataType: "json",
            url: '/Handler/Security/LoginHandler.ashx',
            async: true,
            data: { 'method': 'LoadSchemes' ,'l_company_id': '001', 'ccode':'1000'},
            contentType: "application/json; charset=utf-8",
            async: false,
            success: function (result) {
                var mappedTasks = $.map(result.ResponseData, function (item) {
                    return new ParaComp(item)
                });
              
                self.Schemes(mappedTasks); 
                self.SelectedScheme(self.Schemes().find(x => x.scheme_code() == "001"));
                
            },
            error: function (err) {
                waitMsg.hide();
                msg(err.status + " - " + err.statusText, "FAILURE");
            }
        });

    }
    self.LoadScheme();

    self.GenerateOTP = function () {
        //  #region To Create Random Characters for Agreement
        if(self.Email() && !Validate.email(self.Email())){
            var url = "../../Handler/Security/EmailHandler.ashx" ;
            var data = { 'method': 'SendMailForOTP',  'Email': ko.toJS(self.Email()) };
            $.post(url, data,
                function (result) {
              
                    var obj = jQuery.parseJSON(result);
                    if(obj.IsSucess){
                        msg("OTP Send To Your Mail. Please enter OTP and click on 'Verify OTP' button to verify your OTP.","ALERT")   
                        $('#Verifyotp').css('display', 'inline');          
                    }  
                });
        }
        if(Validate.empty(self.Email())){
            msg("Please Enter Email Address","ALTER")
        }
        else if(Validate.email(self.Email())){
            msg("Please Enter Correct Email Address","ALTER")
            
        }
        //#endregion of Agreement code generation
    }

    
    self.CHECKOTP = function () {

        
        if(self.OTPPass() && !Validate.empty(self.OTPPass())){
       
            var url = "../../Handler/Security/EmailHandler.ashx";
            var data = { 'method': 'CHECKOTP',  'Email': ko.toJS(self.Email()),'OTP':ko.toJS(self.OTPPass()) };
            $.post(url, data,
                function (result) {
              
                    var obj = jQuery.parseJSON(result);
                    if(obj.IsSucess){
                        msg("OTP Verified Successfully","ALERT")   
                        $('#Verifyotp').css('display', 'none');   
                        $('#txtotp,#txtemail').attr('disabled',true);   
                        self.VerifyOtp(true);    
                    }  
                    else{
                        msg("You have entered wrong OTP or the OTP time has expired. PLease Re-Generate the OTP and verify the OTP.","ALERT") 
                        $('#Verifyotp').css('display', 'inline');   
                        $('#txtotp').attr('disabled',false);    
                        self.VerifyOtp(false);
                    }
                });
        }
        if(Validate.empty(self.OTPPass())){
            msg("Please Enter OTP","ALTER")
        }
    }

    self.BOIDValidation = function () {
        var errMsg = "";
        var objFocus = null;
        //#region Validating required fields

        if (Validate.empty(self.Boid_No())) {
            errMsg += "Please Enter BOID!!!<br>";
        }
        else if (self.Boid_No().length < 8) {
            errMsg += "Please Enter 8-digit BOID!!!<br>";
        }
        if (self.SelectedDp() == undefined) {
            errMsg += "Please Select Depository Participants!!!<br>";
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
    self.Validation = function () {
        var errMsg = "";
        var objFocus = null;
        //#region Validating required fields

        if (Validate.empty(self.Boid_No())) {
            errMsg += "Please Enter BOID!!!<br>";
        }
        else if (self.Boid_No().length < 8) {
            errMsg += "Please Enter 8-digit BOID!!!<br>";
        }
        if (self.SelectedDp() == undefined) {
            errMsg += "Please Select Depository Participants!!!<br>";
        }
        if (Validate.empty(self.Name())) {
            errMsg += "Please Enter Name!!!<br>";
        }
        if (Validate.empty(self.DOB())) {
            errMsg += "Please Enter DOB!!!<br>";
        }
        if (Validate.empty(self.Email())) {
            errMsg += "Please Enter Email!!!<br>";
        }
        if (Validate.empty(self.P_Tel_No())) {
            errMsg += "Please Enter  Contact No 1 !!!<br>";
        }
        if (Validate.empty(self.P_Mobile_no())) {
            errMsg += "Please Enter Contact No 2!!!<br>";
        }
        if (Validate.empty(self.CitizenshipNo())) {
            errMsg += "Please Enter CitizenshipNo!!!<br>";
        }
        if(self.VerifyOtp() == false){
            errMsg += "Please Verify Your OTP!!!<br/>"
        }
        //        if(self.OTPPass() != self.OTP() || self.OTPPass() == undefined){
        //            errMsg += "Please Verify Your OTP!!!<br/>"
        //        }
        //#endregion
        if (errMsg !== "") {

            msg(errMsg, "ALERT");

            return false;
        }
        else {
            return true;
        }
    }
    //self.CheckPosted = function() {
    //    var boidToCheck = self.Bo_Account_No();
    //    var url = "/Handler/Dividend/DividendHandler.ashx";
    //    var data = {
    //        method: "CheckBoidPosted",
    //        Bo_Account_No: self.Bo_Account_No()
    //    };

    //    $.post(url, data, function(result) {
    //        var data = jQuery.parseJSON(result);
    //        if (data.IsSucess) {
    //            closeloader();
    //            var CheckBoid = data.ResponseData;
    //            if (CheckBoid.Status == "UNPOSTED"){
    //                self.IsPosted("UNPOSTED");
    //                var msg1 ='<span>';
    //                msg1 += "<b>Your Request for Enrollment for DReP has been sent. Please wait for approval.</b></br>"
    //                msg1 += "एनआइबिएल सहभागिता फण्डका लागि नामांकनको लागि तपाईंको अनुरोध पठाइएको छ। अनुमोदनको लागि प्रतीक्षा गर्नुहोस्।" 
    //                msg(msg1, alert);
    //                self.ClearControls();
                        
    //            }
    //            else{
    //                self.IsPosted(null);
    //                $('#dp,#txtBoid_No').attr('disabled','true');
    //                $('#btnSubmit').attr('disabled',false);
    //            }

                
    //        } 
    //        else {
    //            closeloader();
    //            msg("Error Occur, Please Try Later !!", "WARNING");
    //        }
    //    });
    //}
    self.CheckSHolders = function(){
        if (self.BOIDValidation()) {
            openloader();
            var Bo_Account_No = self.SelectedDp().DP_Id_Cds() + self.Boid_No();
            self.Bo_Account_No(Bo_Account_No);
            var url = "/Handler/RequestHandling/ShHolderHandler.ashx";
            var data = { 'method': 'GetSHolderForDREP', 'scheme_code': scheme_code, 'l_company_id': l_company_id, 'Bo_Account_No': self.Bo_Account_No(), 'ccode': ccode };
            $.post(url, data,
              function (result) {
                  closeloader();
                  waitMsg.hide();
                  var data = jQuery.parseJSON(result);
                  if(data.IsSucess){
                      self.ShHolderNo(data.Message);
                      $('#dp,#txtBoid_No').attr('disabled','true');
                      $('#btnSubmit').attr('disabled',false);
                      
                  }
                  else{
                      msg(data.Message,'error');
                      self.ClearControls();
                  }
              });
        }
    }

    self.SaveDividend = function(){ 
       
        if(self.Validation()){
            openloader();
            var args = {
                l_company_id: l_company_id,
                scheme_code: scheme_code,
                ccode: ccode,
                ShHolderNo: self.ShHolderNo(),
                Bo_Account_No: ko.toJS(self.SelectedDp().DP_Id_Cds()) + ko.toJS(self.Boid_No),
                ENTRY_BY: "Online User",
                ENTRY_Date: today,
                TranType: "02",
                RequestType: "01",
                Name: self.Name(),
                Email: self.Email(),
                P_Tel_No: self.P_Tel_No(),
                P_Mobile_no: self.P_Mobile_no(),
                CitizenshipNo: self.CitizenshipNo(),
                DOB: self.DOB(),
                TranType:'02',
                RequestType:'01'
            };
            
        var url = "../../Handler/Dividend/DividendHandler.ashx";
        var data = { method: "SubmitDREPRequest", args: JSON.stringify(args) };
        $.post(url, data,
        function (result1) {
            var result = jQuery.parseJSON(result1);
            closeloader();
                 if (result.IsSucess) {
                        closeloader();
                        msg("<b>DREP Request Send Successfully.</b>", alert);
                        self.ClearControls();
                    }
                    else{
                     msg(result.Message, "FAILURE");
                     self.ClearControls();
                    }

              });

//            $.ajax({
//                dataType: "json",
//                url: "../../Handler/Dividend/DividendHandler.ashx",
//                async: true,
//                data: { method: "SubmitDREPRequest", args: JSON.stringify(args) },
//                contentType: "application/json; charset=utf-8",
//                success: function(result) {
//                    if (result.IsSucess) {
//                        closeloader();
//                        msg("<b>DREP Request Send Successfully.</b>", alert);
//                        self.ClearControls();
//                    }
//                },
//                error: function(err) {
//                    closeloader();
//                    msg(err.status + " - " + err.statusText, "FAILURE");
//                    self.ClearControls();
//                }
//            });
        }
    }

    self.ClearControls = function(){
        self.Name(null);
        self.Email(null);
        self.OTPPass(null);
        self.OTP(null);
        self.P_Tel_No(null);
        self.P_Mobile_no(null);
        self.DOB(null);
        self.CitizenshipNo(null);
        self.Bo_Account_No(null);
        self.HasDividend(null);
        self.SelectedDp(null);
        self.Boid_No(null);
        $('#txtotp,#txtemail').attr('disabled',false);  
        $('#Verifyotp').css('display','none');  
        $('#btnSubmit').attr('disabled','true');
        $('#dp,#txtBoid_No').attr('disabled',false);
    }
   

}
$(document).ready(function () {
    ValidatePage();
    ko.applyBindings(new DREPREGViewModel());
    var now = new Date();
    maxDate = now.toISOString().substring(0, 10);
    $('#txtDOB').prop('max', maxDate);

});


