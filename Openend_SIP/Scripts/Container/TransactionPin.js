
var TransactionPin = function () {
    var self = this;

    //For User
    self.UserId = ko.observable();
    var name = $("#Name").text(); // logged in user 
    // var username = $("#username").text();

    self.OldPin = ko.observable()
    self.NewPin = ko.observable()
    self.ReNewPin = ko.observable()
    self.CNewPin = ko.observable()
    self.CReNewPin = ko.observable()

    var username = $("#UserName").text(); // logged in user 
    var ccode = '1000' // Distribution center id
    var scheme_code = '001'; /// company id 
    var date = $("#date").text();
    var UserId = $('#UserId').text();
    var l_company_id = '001';
    var BOID = $('#BOID').text();
    var Name = $('#Name').text();
    var SHHOLDERNO = $('#SHHOLDERNO').text();
    var Email = $("#Email").text();

    self.EmailOTP = ko.observable()

    self.Validation = function () {
        var errMsg = "";
        var objFocus = null;

        if (Validate.empty(self.OldPin())) {
            errMsg += "Please Enter Old Pin !!!<br>";
        }

        if (Validate.empty(self.NewPin())) {

        }
        else if (self.NewPin().length != 6) {
            errMsg += "Please Enter 6 Digit Numerical Value !!!<br>";

        }
        if (Validate.empty(self.ReNewPin())) {
            errMsg += "Please ReEnter New Pin !!!<br>";
        } else if (self.ReNewPin().length != 6) {
            errMsg += "Please Enter 6 Digit Numerical Value !!!<br>";

        } if (self.ReNewPin() != self.NewPin()) {
            errMsg += "Your New and ReNew Pin Didn't Match !!!<br>";
        }
        if (errMsg !== "") {

            msg(errMsg, "ALERT");

            return false;
        }
        else {
            return true;
        }

    }


    self.ForgetValidation = function () {
        var errMsg = "";
        var objFocus = null;

        if (Validate.empty(self.CNewPin())) {
            errMsg += "Please Enter New Pin !!!<br>";
        } else if (self.CNewPin().length != 6) {
            errMsg += "Please Enter 6 Digit Numerical Value !!!<br>";

        }
        if (Validate.empty(self.CReNewPin())) {
            errMsg += "Please ReEnter New Pin !!!<br>";
        } else if (self.CReNewPin().length != 6) {
            errMsg += "Please Enter 6 Digit Numerical Value !!!<br>";

        } if (self.CReNewPin() != self.CNewPin()) {
            errMsg += "Your New and ReNew Pin Didn't Match !!!<br>";
        }
        if (errMsg !== "") {

            msg(errMsg, "ALERT");

            return false;
        }
        else {
            return true;
        }

    }


    self.VerifyPinValidation = function () {
        var errMsg = "";
        var objFocus = null;

        if (Validate.empty(self.EmailOTP())) {
            errMsg += "Please Enter Email OTP !!!<br>";
        } else if (self.EmailOTP().length != 8) {
            errMsg += "Please Enter 8 Digit OTP Value !!!<br>";

        }

        if (errMsg !== "") {

            msg(errMsg, "ALERT");

            return false;
        }
        else {
            return true;
        }
    }
    self.VerifyPIn = function () {
        if (self.VerifyPinValidation()) {
            var args = {
                BOID: BOID,
                UserId: UserId,
                SHHOLDERNO: SHHOLDERNO,
                EmailOTP: ko.toJS(self.EmailOTP()),
                Action: 'U',
                Email: Email
            }
            waitMsg.show1();
            $('#VerifySercurity').modal('hide');


            url = '/Handler/Security/TransactionPin.ashx';
            data = { 'method': 'SubmitPinVerification', 'args': JSON.stringify(ko.toJS((args))) };
            $.post(url, data,
                function (result) {
                    waitMsg.hide1();
                    var data = jQuery.parseJSON(result);
                    if (data.IsSucess == true) {
                        console.log("", data)
                        if (data.Message == "true") {
                            msg("Successfully Changed PIN !!!", "ALERT")
                        } else {

                            msg("Failed to Change PIN !!!", "ALERT")
                        }
                        self.ClearControl()

                    } else {
                        msg("Something Gone Wrong", 'ALERT')
                    }
                });

        }
    }

    self.ForgetPin = function () {
        if (self.ForgetValidation()) {
            var args = {
                BOID: BOID,
                UserId: UserId,
                SHHOLDERNO: SHHOLDERNO,
                NewPin: ko.toJS(self.CNewPin()),
                CReNewPin: ko.toJS(self.CReNewPin()),
                Action: 'A',
                Email: Email
            }
            waitMsg.show1();

            url = '/Handler/Security/TransactionPin.ashx';
            data = { 'method': 'ForgetTransactionPin', 'args': JSON.stringify(ko.toJS((args))) };
            $.post(url, data,
                function (result) {
                    waitMsg.hide1();
                    var data = jQuery.parseJSON(result);
                    waitMsg.hide1();
                    console.log("", data)
                    if (data.ResponseData.IsSucess== true) {
                        $('#VerifySercurity').modal('show');
                        self.CNewPin('')
                        self.CReNewPin('')
                    } 
                    else {
                        msg(data.ResponseData.Message, "ALERT")
                    }
                });

        }

    }


    self.UpdatePin = function () {
        if (self.Validation()) {
            var args = {
                BOID: BOID,
                UserId: UserId,
                SHHOLDERNO: SHHOLDERNO,
                NewPin: ko.toJS(self.NewPin()),
                OldPin : ko.toJS(self.OldPin()),
                Email: Email
               
            }
            waitMsg.show1();

            url = '/Handler/Security/TransactionPin.ashx';
            data = { 'method': 'ChangeTransactionPin', 'args': JSON.stringify(ko.toJS((args))) };
            $.post(url, data,
                function (result) {
                    waitMsg.hide1();
                    var data = jQuery.parseJSON(result);
                    waitMsg.hide1();
                    console.log("", data)
                    if (data.IsSucess == true) {
                        console.log("", data)
                        if (data.Message == "true") {
                            msg("Successfully Changed PIN !!!", "ALERT")
                        } else {

                            msg("Failed to Change PIN !!!", "ALERT")
                        }
                        self.ClearControl()

                    } else {
                        msg("Something Gone Wrong", 'ALERT')
                    }
                });
        
        }
    }

    self.ClearControl = function () {
        self.EmailOTP('')
        self.CReNewPin('')
        self.CNewPin('')
        self.ReNewPin('')
        self.NewPin('')
        self.OldPin('')

    }







}

$(document).ready(function () {
    ValidateSession();
    ko.applyBindings(new TransactionPin());
});