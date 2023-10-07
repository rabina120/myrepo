function DPCharge(data) {
    var self = this;
    if (data != undefined) {
        self.Depo = ko.observable(data.Depo);
        self.DPName = ko.observable(data.DPName);
        self.DP_Id_Cds = ko.observable(data.DP_Id_Cds);


    }
}

var SignUpViewModel = function () {
    var self = this;
    //DP
    self.Depo = ko.observable();
    self.DPName = ko.observable();
    self.SelectedDp = ko.observable();
    self.DP_Id_Cds = ko.observable();
    self.Boid_No = ko.observable();

    self.Name = ko.observable();
    self.Email = ko.observable();
    self.DOB = ko.observable();
    self.UserName = ko.observable();
    self.Password = ko.observable();
    self.Contact_No = ko.observable();
    self.Contact_No2 = ko.observable();
    self.Name = ko.observable();
    self.Signature1 = ko.observable();
    self.SignName = ko.observable();
    self.UploadFile = ko.observable();
    self.FileName = ko.observable();
    self.Bo_Account_No = ko.observable();
    self.IS_UNIT_HOLDER = ko.observable();
    self.P_Mobile_no = ko.observable();
    self.Gender = ko.observable();
    var username = $("#username").text(); // logged in user 
    var ccode = '1000' // Distribution center id
    var scheme_code = '001'; /// company id 
    var date = $("#date").text();
    var UserId = $('#UserId').text();
    var l_company_id = '001';
    self.P_Tel_No = ko.observable();
    self.ShHolderNo = ko.observable();
    self.OTPPass = ko.observable();
    self.OTPContactPass = ko.observable();
    self.OTPPassSign = ko.observable();
    self.OTPPassSignCode = ko.observable();
    self.CitizenshipNo = ko.observable()
    self.VerifyOtp = ko.observable(false);
    self.VerifyContactNoOtp = ko.observable(false);

    $("#dp").select2({
        tags: true
    });
    self.openpdfe = function () {
        var objFra = window.open('../../Styles/Form_Login Registration.pdf', '_blank');
    }
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

    //self.GenerateRandomPassword = function () {
    //    //  #region To Create Random Characters for Agreement
    //    var len = 8;
    //    var code = "";
    //    var charset = "abcdefghijklmnopqrstuvwxyz0123456789";

    //    for (var i = 0; i < len; i++)
    //        code += charset.charAt(Math.floor(Math.random() * charset.length));

    //    self.Password(code);

    //    //#endregion of Agreement code generation
    //}

    self.GenerateOTPSign = function () {
        //  #region To Create Random Characters for Agreement
        if (self.Email()) {
            var len = 4;
            var code = "";
            var charset = "0123456789";

            for (var i = 0; i < len; i++) {
                code += charset.charAt(Math.floor(Math.random() * charset.length));
            }

            self.OTPPassSignCode(code);

            var url = "../../Handler/Security/EmailHandler.ashx";
            var data = { 'method': 'SendMailForOTP', 'otp': ko.toJS(self.OTPPassSignCode()), 'Email': ko.toJS(self.Email()) };
            $.post(url, data,
                function (result) {

                    var obj = jQuery.parseJSON(result);
                    if (obj.IsSucess) {
                        msg("OTP Send To Your Mail", "ALERT")
                    }
                });
        } else {
            msg("Please Enter Email Address", "ALTER")

        }
        //#endregion of Agreement code generation
    }

    self.GenerateOTP = function () {
        //  #region To Create Random Characters for Agreement
        if (self.Email() && !Validate.email(self.Email())) {
            var url = "../../Handler/Security/EmailHandler.ashx";
            var data = { 'method': 'SendMailForOTP', 'Email': ko.toJS(self.Email()), 'ContactNumber': ko.toJS(self.P_Tel_No()) };
            $.post(url, data,
                function (result) {

                    var obj = jQuery.parseJSON(result);
                    if (obj.IsSucess) {
                        msg("OTP Send To Your Mail and ContactNumber. Please enter OTP and click on 'Verify OTP' button to verify your OTP.", "ALERT")
                        $('#Verifyotp').css('display', 'inline');
                    }

                });
        }
        if (Validate.empty(self.Email())) {
            msg("Please Enter Email Address", "ALTER")
        }
        if (Validate.empty(self.P_Tel_No().length < 10)) {
            msg("Please Enter Contact Number", "ALTER")
        }
        else if (Validate.email(self.Email())) {
            msg("Please Enter Correct Email Address", "ALTER")

        }
        //#endregion of Agreement code generation
    }


    //Start OTP for Contact Number

    self.GenerateContactNoOTP = function () {

        //  #region To Create Random Characters for Agreement
        if (self.Contact_No() && !Validate.empty(self.Contact_No())) {
            var url = "../../Handler/Security/SMSHandler.ashx";
            var data = { 'method': 'SENDSMS', 'ContactNumber': ko.toJS(self.Contact_No()) };
            $.post(url, data,
                function (result) {

                    var obj = jQuery.parseJSON(result);
                    if (obj.IsSucess) {
                        msg("OTP Send To Your Contact Number. Please enter OTP and click on 'Verify OTP' button to verify your OTP.", "ALERT")
                        $('#VerifyContactotp').css('display', 'inline');
                    }
                });
        }
            if (Validate.empty(self.Contact_No())) {
            msg("Please Enter Contact Number", "ALTER")
        }
        else if (Validate.Contact_No(self.Contact_No())) {
            msg("Please Enter Correct Contact Number", "ALTER")

        }

        //#endregion of Agreement code generation
    }

    //End OTP for Contact Number

    self.CHECKOTP = function () {


        if (self.OTPPass() && !Validate.empty(self.OTPPass())) {

            var url = "../../Handler/Security/EmailHandler.ashx";
            var data = { 'method': 'CHECKOTP', 'Email': ko.toJS(self.Email()), 'OTP': ko.toJS(self.OTPPass()) };
            $.post(url, data,
                function (result) {

                    var obj = jQuery.parseJSON(result);
                    if (obj.IsSucess) {
                        msg("OTP Verified Successfully", "ALERT")
                        $('#Verifyotp').css('display', 'none');
                        $('#txtotp,#txtemail,#txtCnt1').attr('disabled', true);
                        self.VerifyOtp(true);

                    }
                    else {
                        msg("You have entered wrong OTP or the OTP time has expired. PLease Re-Generate the OTP and verify the OTP.", "ALERT")
                        $('#Verifyotp').css('display', 'inline');
                        $('#txtotp').attr('disabled', false);
                        self.VerifyOtp(false);
                    }
                });
        }
        if (Validate.empty(self.OTPPass())) {
            msg("Please Enter OTP", "ALTER")
        }
    }

    //Start verify contact number from OTP
    self.CheckContactNoOTP = function () {
        if (self.OTPContactPass() && !Validate.empty(self.OTPContactPass())) {

            var url = "../../Handler/Security/SMSHandler.ashx";
            var data = { 'method': 'CHECKContactNoOTP', 'ContactNo': ko.toJS(self.Contact_No()), 'ContatNoOTP': ko.toJS(self.OTPContactPass()) };
            $.post(url, data,
                function (result) {
                    var obj = jQuery.parseJSON(result);
                    if (obj.IsSucess) {
                        msg("OTP Verified Successfully", "ALERT")
                        $('#VerifyContactotp').css('display', 'none');
                        $('#txtContactOTP,#txtContact_No').attr('disabled', true);
                        self.VerifyContactNoOtp(obj.IsSucess);
                    }
                    else {
                        msg("You have entered wrong OTP or the OTP time has expired. PLease Re-Generate the OTP and verify the OTP.", "ALERT")
                        $('#VerifyContactotp').css('display', 'inline');
                        $('#txtContactOTP').attr('disabled', false);
                        self.VerifyContactNoOtp(obj.IsSucess);
                    }
                });
        }
        if (Validate.empty(self.OTPContactPass())) {
            msg("Please Enter OTP", "ALTER")
        }
    }

    //End verify contact number from OTP

    self.CheckSHolders = function () {

        if (self.BOIDValidation()) {
            var Bo_Account_No = self.SelectedDp().DP_Id_Cds() + self.Boid_No();
            self.Bo_Account_No(Bo_Account_No);

            var url = "/Handler/RequestHandling/ShHolderHandler.ashx";
            var data = { 'method': 'GetSHoldersforSignUp', 'scheme_code': scheme_code, 'l_company_id': l_company_id, 'Bo_Account_No': self.Bo_Account_No(), 'ccode': ccode, 'SHHOLDERNO': null };
            $.post(url, data,
                    function (result) {
                        
                        var data = jQuery.parseJSON(result);
                        //if (obj.ResponseData != null) {
                        //    if (obj.ResponseData.length == 1) {
                        //        var url = "/Handler/Security/UserHandler.ashx";
                        //        var data = { 'method': 'SearchWebLoginUser', 'scheme_code': scheme_code, 'l_company_id': l_company_id, 'Bo_Account_No': self.Bo_Account_No(), 'ccode': ccode, 'SHHOLDERNO': null };
                        //        $.post(url, data,
                        //           function (result) {

                        //               
                        //               var data = jQuery.parseJSON(result);
                        if (!data.IsSucess) {


                            msg(data.Message, alert);
                            self.SelectedDp(null);
                            self.Boid_No(null);
                        }
                        else {
                            //var SHolder = obj.ResponseData[0];
                            $('.Existing').attr("disabled", true);
                            $('#dp').attr("disabled", true);
                            document.getElementById("select2-dp-container").style.backgroundColor = "#f5f6f6";
                            //self.Name(SHolder.FName + " " + SHolder.MName + " " + SHolder.LName);
                            //self.P_Tel_No(SHolder.P_Tel_No);
                            //self.P_Mobile_no(SHolder.P_Mobile_no);
                            self.ShHolderNo(data.Message);
                            self.IS_UNIT_HOLDER('Y');
                        }
                        //               });
                        //    }
                        //    else {
                        //        msg("You are not Valid User for Sign Up", alert);
                        //        self.SelectedDp(null);
                        //        self.Boid_No(null);
                        //    }
                        //}

                    });

        }
    }
    self.validateUserName = function () {
        if (self.UserName() != undefined) {
            if (self.UserNameValidate()) {
                $.ajax({
                    dataType: "json",
                    url: '/Handler/Security/EmailHandler.ashx',
                    async: true,
                    data: { 'method': 'validateUserName', 'UserName': ko.toJS((self.UserName()).trim()) },
                    contentType: "application/json; charset=utf-8",
                    async: false,
                    success: function (result) {

                        var count = result.ResponseData.length;
                        if (count == 1) {
                            msg("UserName Address already exists !!!");
                            self.UserName('');

                        }
                    }
                });
            }
        }
    }

    self.UserNameValidate = function () {
        var errMsg = "";
        var objFocus = null;
        var testname = /^[\w@#$.&]+$/;
        //#region Validating required fields

        if (testname.test((self.UserName()).trim()) != true) {
            // fld.style.background = 'Yellow';
            errMsg += "The username must only contain a-z,A-Z,0-9 and _@#$.& \n";
            self.UserName(null);

            if (errMsg !== "") {

                msg(errMsg, "ALERT");

                return false;
            }

        }
        else {
            return true;
        }
    }
    self.validateEmailaddress = function () {
        if (self.Email() != undefined) {
            $.ajax({
                dataType: "json",
                url: '/Handler/Security/EmailHandler.ashx',
                async: true,
                data: { 'method': 'validateEmailaddress', 'Email': ko.toJS(self.Email()) },
                contentType: "application/json; charset=utf-8",
                async: false,
                success: function (result) {

                    var count = result.ResponseData.length;
                    self.CheckEmail();
                    if (count == 1) {
                        msg("Email Address already exists !!!");
                        self.Email('');

                    }
                }
            });
        }
    }
    self.CheckEmail = function () {
        if (self.Email() != undefined) {
            $.ajax({
                dataType: "json",
                url: '/Handler/Security/EmailHandler.ashx',
                async: true,
                data: { 'method': 'CheckEmail', 'Email': ko.toJS(self.Email()) },
                contentType: "application/json; charset=utf-8",
                async: false,
                success: function (result) {

                    if (!(result.IsSucess)) {
                        msg("Please Enter Valid Email Address", "FAILURE");
                        self.Email(null);
                    }
                },
                error: function (err) {
                    waitMsg.hide();
                    msg(err.status + " - " + err.statusText, "FAILURE");
                }
            });
        }
    }
    self.BOIDValidation = function () {
        var errMsg = "";
        var objFocus = null;
        //#region Validating required fields

        if (Validate.empty(self.Boid_No())) {
            errMsg += "Please Enter BOID!!!<br>";
        }
        if (self.SelectedDp() == undefined) {
            errMsg += "Please Select Depository Participants!!!<br>";
        }
//        if (self.Boid_No().length < 8) {
//            errMsg += "Please Enter 8-digit BOID!!!<br>";
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



    self.ClearControls = function () {

        self.Name(null);
        self.Email(null);
        self.DOB(null);
        self.UserName(null);
        self.Password(null);
        self.Contact_No(null);
        self.Signature1(null);
        self.UploadFile(null);
        self.SelectedDp(null);
        self.Boid_No(null);
        self.Gender(null);
        $('.Existing').attr("disabled", false);
        document.getElementById("select2-dp-container").style.backgroundColor = "#ffff";
        self.OTPPassSign(null);
        self.OTPPassSignCode(null);
        self.CitizenshipNo(null);
        $('#Verifyotp').css('display', 'none');
        $('#VerifyContactotp').css('display', 'none');
        $('#txtotp,#txtemail,#txtCnt1').attr('disabled', false);
        $('#txtContactOTP,#txttelno').attr('disabled', false);  
        location.reload();
    }

    $("#txtUploadFile").on("change", function () {

        if (this.files[0] != undefined) {
            edocerror2 = "";
            docsize2 = "";
            docsize2 = this.files[0].size / 1024 / 1024;

            var fileInput = document.getElementById('txtUploadFile');
            docname2 = fileInput.files[0].name;

            var files = !!this.files ? this.files : [];
            if (!files.length || !window.FileReader) return;

            doctype2 = files[0].type;

            var reader = new FileReader();
            reader.readAsDataURL(files[0]);
            if (files[0].type != "image/jpeg" && files[0].type != "image/png") {
                edocerror = 1;
                msg("Document format must only be jpeg, png and jpg format!!!<br>");
                $("#txtUploadFile").val("");
                self.UploadFile("");
                self.FileName("");

                return;
            }

            if (files[0].size > 1000000) {
                edocerror = 2;
                msg("Document size must be less than 1 mb !!!<br>");
                $("#txtUploadFile").val("");
                self.UploadFile("");
                self.FileName("");
                return;
            }

            reader.onloadend = function (event) {

                var dataUri = event.target.result
                docfile4 = dataUri;
                self.FileName(docname2);
                self.UploadFile(docfile4);
            }
        }
        else {
            self.UploadFile('');
        }
    });
    $("#txtSign").on("change", function () {

        if (this.files[0] != undefined) {
            edocerror2 = "";
            docsize2 = "";
            docsize2 = this.files[0].size / 1024 / 1024;

            var fileInput = document.getElementById('txtUploadFile');
            docname3 = fileInput.files[0].name;

            var files = !!this.files ? this.files : [];
            if (!files.length || !window.FileReader) return;

            doctype2 = files[0].type;

            var reader = new FileReader();
            reader.readAsDataURL(files[0]);
            if (files[0].type != "image/jpeg" && files[0].type != "image/png") {
                edocerror = 1;
                msg("Document format must only be jpeg, png and jpg format!!!<br>");
                $("#txtSign").val("");
                self.Signature1("");
                self.SignName("");

                return;
            }

            if (files[0].size > 1000000) {
                edocerror = 2;
                msg("Document size must be less than 1 mb !!!<br>");
                $("#txtSign").val("");
                self.Signature1("");
                self.SignName("");
                return;
            }

            reader.onloadend = function (event) {

                var dataUri = event.target.result
                docfile4 = dataUri;
                self.SignName(docname3);
                self.Signature1(docfile4);
            }
        }
        else {
            self.Signature1('');
        }
    });
    var count = 0;
    self.SubmitForm = function () {

        if (self.Validation()) {
            if (self.UserNameValidate()) {
                //self.GenerateRandomPassword();
                var Bo_Account_No = self.SelectedDp().DP_Id_Cds() + self.Boid_No();
                self.Bo_Account_No(Bo_Account_No);
                Confirm("Do you want to submit SignUp request? ", 'Confirmation Dialog', function (r) {
                    $('#btnProceed').attr('disabled', 'disabled');
                    waitMsg.show1();
                    if (r) {
                        var args = {
                            scheme_code: scheme_code,
                            l_company_id: l_company_id,
                            Name: self.Name(),
                            DOB: self.DOB(),
                            Boid_No: ko.toJS(self.SelectedDp().DP_Id_Cds) + ko.toJS(self.Boid_No()),
                            Email: self.Email(),
                            UserName: self.UserName(),
                            //Password: self.Password(),
                            Contact_No: self.P_Tel_No(),
                            Contact_No2: self.Contact_No2(),
                            UploadFile: self.UploadFile(),
                            Signature1: self.Signature1(),
                            BOID: self.Bo_Account_No(),
                            IS_UNIT_HOLDER: self.IS_UNIT_HOLDER(),
                            Gender: self.Gender(),
                            Origin: 'SIGN UP',
                            SHHOLDERNO: self.ShHolderNo(),
                            Citizenship_No: self.CitizenshipNo(),
                            SignName: self.SignName(),
                            FileName: self.FileName(),
                            OTP: self.OTPPass(),
                            OTPContact: self.OTPContactPass()

                        };
                        var url = "/Handler/Security/UserHandler.ashx";;
                        var data = { 'method': 'SaveWebUser', 'args': JSON.stringify(ko.toJS((args))) };
                        $.post(url, data,
                                        function (result) {
                                            waitMsg.hide();
                                            var data = jQuery.parseJSON(result);
                                            if (data.IsSucess) {
                                                waitMsg.hide();
                                                Confirm("Record Saved Successfully", 'Confirmation Dialog', function (r) {
                                                    if (r) {
                                                        //   waitMsg.hide1();
                                                        self.ClearControls();
                                                    }
                                                });
                                            }
                                        });
                    }
                });

            }
        }
    }
    self.Validation = function () {
        var errMsg = "";
        var objFocus = null;
        //#region Validating required fields
        if (self.SelectedDp() == undefined) {
            errMsg += "Please Select Depository Participants!!!<br>"
        }

        if (Validate.empty(self.Boid_No())) {
            errMsg += "Please Enter BOID!!!<br>"
        } else if (self.Boid_No().length < 8) {
            errMsg += "Please Enter 8-digit BOID!!!<br>";
        }

        if (Validate.empty(self.Name())) {
            errMsg += "Please Enter Name !!!<br>";
        }
        if (Validate.empty(self.UserName())) {
            errMsg += "Please  Enter UserName!!!<br>";
        }
        if (Validate.empty(self.Contact_No2())) {
            errMsg += "Please Enter Contact No !!!<br>";
        }

        else if (self.Contact_No2().length < 10) 
        {
            errMsg += "Please Enter Correct Contact No !!!<br>";
        }

        if (Validate.empty(self.CitizenshipNo())) {
            errMsg += "Please Enter Citizenship Number !!!<br>";
        }
//        if (Validate.empty(self.P_Tel_No())) {
//            errMsg += "Please Enter Contact No !!!<br>";
//        }

//        else if (self.P_Tel_No().length < 10) {
//            errMsg += "Please Enter Correct Contact No !!!<br>";
//        }
        
        if (Validate.empty(self.DOB())) {
            errMsg += "Please Enter DOB !!!<br>";
        }
        if (Validate.empty(self.Email())) {
            errMsg += "Please Enter Email !!!<br>";
        }
//        if (self.OTPPassSign() != self.OTPPassSignCode() || self.OTPPassSign() == undefined) {
//            errMsg += "Please Verify your OTP !!!<br>";
//        }
        if (self.VerifyOtp() == false) {
            errMsg += "Please Verify Your OTP!!!<br/>"
        }
//        if (self.VerifyContactNoOtp() == false) {
//            errMsg += "Please Verify Your Contact No. OTP!!!<br/>"
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

}
$(document).ready(function () {
    ValidatePage();
    ko.applyBindings(new SignUpViewModel());
    var now = new Date();
    maxDate = now.toISOString().substring(0, 10);
    $('#txtDOB').prop('max', maxDate);
});
